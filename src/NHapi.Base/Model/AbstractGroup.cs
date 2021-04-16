/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "AbstractGroup.java".  Description:
  "A partial implementation of Group"

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2001.  All Rights Reserved.

  Contributor(s): ______________________________________.

  Alternatively, the contents of this file may be used under the terms of the
  GNU General Public License (the "GPL"), in which case the provisions of the GPL are
  applicable instead of those above.  If you wish to allow use of your version of this
  file only under the terms of the GPL and not to allow others to use your version
  of this file under the MPL, indicate your decision by deleting  the provisions above
  and replace  them with the notice and other provisions required by the GPL License.
  If you do not delete the provisions above, a recipient may use your version of
  this file under either the MPL or the GPL.
*/

namespace NHapi.Base.Model
{
    using System;
    using System.Collections.Generic;

    using NHapi.Base.Log;
    using NHapi.Base.Parser;

    /// <summary> A partial implementation of Group.  Subclasses correspond to specific
    /// groups of segments (and/or other sub-groups) that are implicitly defined by message structures
    /// in the HL7 specification.  A subclass should define it's group structure by putting repeated calls to
    /// the add(...) method in it's constructor.  Each call to add(...) adds a specific component to the
    /// Group.
    /// </summary>
    /// <author>  Bryan Tripp (bryan_tripp@sourceforge.net).
    /// </author>
    public abstract class AbstractGroup : IGroup
    {
        private static readonly IHapiLog Log;

        private List<AbstractGroupItem> items;
        private IModelClassFactory myFactory;

        static AbstractGroup()
        {
            Log = HapiLogFactory.GetHapiLog(typeof(AbstractGroup));
        }

        /// <summary> This constructor should be used by implementing classes that do not
        /// also implement Message.
        ///
        /// </summary>
        /// <param name="parentStructure">the group to which this Group belongs.
        /// </param>
        /// <param name="factory">the factory for classes of segments, groups, and datatypes under this group.
        /// </param>
        protected internal AbstractGroup(IGroup parentStructure, IModelClassFactory factory)
        {
            ParentStructure = parentStructure;
            myFactory = factory;
            Init();
        }

        /// <summary>
        /// This constructor should only be used by classes that implement Message directly.
        /// </summary>
        /// <param name="factory">the factory for classes of segments, groups, and datatypes under this group.
        /// </param>
        protected internal AbstractGroup(IModelClassFactory factory)
        {
            myFactory = factory;
            Init();
        }

        /// <inheritdoc />
        public virtual string[] Names
        {
            get
            {
                var retVal = new string[items.Count];
                for (var i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    retVal[i] = item.Name;
                }

                return retVal;
            }
        }

        /// <inheritdoc />
        public virtual IMessage Message
        {
            get
            {
                IStructure s = this;
                while (!(s is IMessage))
                {
                    s = s.ParentStructure;
                }

                return (IMessage)s;
            }
        }

        /// <inheritdoc />
        public virtual IGroup ParentStructure { get; }

        /// <inheritdoc />
        public virtual IStructure GetStructure(string name)
        {
            return GetStructure(name, 0);
        }

        /// <inheritdoc />
        public virtual IStructure GetStructure(string name, int rep)
        {
            var item = GetGroupItem(name);

            if (item == null)
            {
                throw new HL7Exception(
                    $"{name} does not exist in the group {GetType().FullName}",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            IStructure ret;
            if (rep < item.Structures.Count)
            {
                // return existing Structure if it exists
                ret = item.Structures[rep];
            }
            else if (rep == item.Structures.Count)
            {
                // verify that Structure is repeating ...
                var repeats = item.IsRepeating;
                if (!repeats && item.Structures.Count > 0)
                {
                    throw new HL7Exception(
                        $"Can't create repetition #{rep} of Structure {name} - this Structure is non-repeating",
                        ErrorCode.APPLICATION_INTERNAL_ERROR);
                }

                // create a new Structure, add it to the list, and return it
                var classType = item.ClassType;
                ret = TryToInstantiateStructure(classType, name);
                item.Structures.Add(ret);
            }
            else
            {
                throw new HL7Exception(
                    $"Can't return repetition #{rep} of {name} - there are only {items.Count} repetitions.",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            return ret;
        }

        /// <summary>
        /// Adds a new item to the Structure.
        /// </summary>
        /// <exception cref="HL7Exception">
        /// Thrown when the named Structure is not part of this group
        /// or if the structure is not repeatable and an item already exists.
        /// </exception>
        public virtual IStructure AddStructure(string name)
        {
            var item = GetGroupItem(name);

            if (item == null)
            {
                throw new HL7Exception(
                    $"{name} does not exist in the group {GetType().FullName}",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            // Verify that Structure is repeating ...
            var repeats = item.IsRepeating;
            if (!repeats && item.Structures.Count > 0)
            {
                throw new HL7Exception(
                    $"Can't create repetition of Structure {name} - this Structure is non-repeating and this Structure already has an item present.",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            // Create a new Structure, add it to the list, and return it
            var classType = item.ClassType;
            var ret = TryToInstantiateStructure(classType, name);
            item.Structures.Add(ret);
            return ret;
        }

        /// <summary>
        /// Removes the given structure from the named Structure.
        /// </summary>
        /// <exception cref="HL7Exception">
        /// Thrown when the named Structure is not part of this Group.
        /// </exception>
        public virtual void RemoveStructure(string name, IStructure toRemove)
        {
            var item = GetGroupItem(name);

            if (item == null)
            {
                throw new HL7Exception(
                    $"{name} does not exist in the group {GetType().FullName}",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            item.Structures.Remove(toRemove);
        }

        /// <summary> Removes the structure at the given index from the named Structure. </summary>
        /// <exception cref = "HL7Exception" > Thrown when the named Structure is not part of this Group
        /// or an index greater than the number of items in the structure is supplied.
        /// </exception>
        public virtual void RemoveRepetition(string name, int rep)
        {
            var item = GetGroupItem(name);
            if (item == null)
            {
                throw new HL7Exception(
                    $"The structure {name} does not exist in the group {GetType().FullName}",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            if (rep >= item.Structures.Count)
            {
                throw new HL7Exception(
                    $"The structure {name} does not have {rep} repetitions. ",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            item.Structures.RemoveAt(rep);
        }

        [Obsolete("This method has been replaced by 'AddNonstandardSegment'.")]
        public virtual string addNonstandardSegment(string name)
        {
            return AddNonstandardSegment(name);
        }

        /// <inheritdoc />
        public virtual string AddNonstandardSegment(string name)
        {
            var version = Message.Version;
            if (version == null)
            {
                throw new HL7Exception("Need message version to add segment by name; message.Version returns null");
            }

            var c = myFactory.GetSegmentClass(name, version) ?? typeof(GenericSegment);

            var index = Names.Length;

            TryToInstantiateStructure(c, name); // may throw exception

            return Insert(c, false, true, false, index, name);
        }

        /// <inheritdoc />
        public virtual string AddNonstandardSegment(string name, int index)
        {
            if (this is IMessage && index == 0)
            {
                throw new HL7Exception($"Cannot add nonstandard segment '{name}' to start of message.");
            }

            var version = Message.Version;
            if (version == null)
            {
                throw new HL7Exception("Need message version to add segment by name; message.Version returns null");
            }

            var c = myFactory.GetSegmentClass(name, version) ?? typeof(GenericSegment);

            TryToInstantiateStructure(c, name); // may throw exception

            return Insert(c, false, true, false, index, name);
        }

        /// <inheritdoc />
        public virtual bool IsRequired(string name)
        {
            var item = GetGroupItem(name);
            if (item == null)
            {
                throw new HL7Exception(
                    $"The structure {name} does not exist in the group {GetType().FullName}",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            return item.IsRequired;
        }

        /// <inheritdoc />
        public virtual bool IsRepeating(string name)
        {
            var item = GetGroupItem(name);
            if (item == null)
            {
                throw new HL7Exception(
                    $"The structure {name} does not exist in the group {GetType().FullName}",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            return item.IsRepeating;
        }

        /// <inheritdoc />
        public virtual bool IsChoiceElement(string name)
        {
            var item = GetGroupItem(name);
            if (item == null)
            {
                throw new HL7Exception(
                    $"The structure {name} does not exist in the group {GetType().FullName}",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            return item.IsChoiceElement;
        }

        /// <inheritdoc />
        public virtual bool IsGroup(string name)
        {
            var item = GetGroupItem(name);
            if (item == null)
            {
                throw new HL7Exception(
                    $"The structure {name} does not exist in the group {GetType().FullName}",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            return typeof(IGroup).IsAssignableFrom(item.ClassType);
        }

        [Obsolete("This method has been replaced by 'CurrentReps'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual int currentReps(string name)
        {
            return CurrentReps(name);
        }

        /// <summary> Returns the number of existing repetitions of the named structure.</summary>
        public virtual int CurrentReps(string name)
        {
            var item = GetGroupItem(name);
            if (item == null)
            {
                throw new HL7Exception(
                    $"The structure {name} does not exist in the group {GetType().FullName}",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            return item.Structures.Count;
        }

        /// <summary> Returns an array of Structure objects by name.  For example, if the Group contains
        /// an MSH segment and "MSH" is supplied then this call would return a 1-element array
        /// containing the MSH segment.  Multiple elements are returned when the segment or
        /// group repeats.  The array may be empty if no repetitions have been accessed
        /// yet using the get(...) methods.
        /// </summary>
        /// <throws>  HL7Exception if the named Structure is not part of this Group.  </throws>
        public virtual IStructure[] GetAll(string name)
        {
            var item = GetGroupItem(name);
            if (item == null)
            {
                throw new HL7Exception(
                    $"The structure {name} does not exist in the group {GetType().FullName}",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            var all = new IStructure[item.Structures.Count];
            for (var i = 0; i < item.Structures.Count; i++)
            {
                all[i] = item.Structures[i];
            }

            return all;
        }

        /// <summary> Returns the Class of the Structure at the given name index.  </summary>
        public virtual Type GetClass(string name)
        {
            var item = GetGroupItem(name);
            return item.ClassType;
        }

        /// <summary> Returns the class name (excluding package). </summary>
        public virtual string GetStructureName()
        {
            return GetStructureName(GetType());
        }

        [Obsolete("This method has been replaced by 'Add'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        protected internal virtual string add(Type c, bool required, bool repeating)
        {
            return Add(c, required, repeating);
        }

        /// <summary> Adds a new Structure (group or segment) to this Group.  A place for the
        /// Structure is added to the group but there are initially zero repetitions.
        /// This method should be used by the constructors of implementing classes
        /// to specify which Structures the Group contains - Structures should be
        /// added in the order in which they appear.
        /// Note that the class is supplied instead of an instance because we want
        /// there initially to be zero instances of each structure but we want the
        /// AbstractGroup code to be able to create instances as necessary to support
        /// get(...) calls.
        /// </summary>
        /// <returns> the actual name used to store this structure (may be appended with
        /// an integer if there are duplicates in the same Group).
        /// </returns>
        protected internal virtual string Add(Type c, bool required, bool repeating)
        {
            var name = GetStructureName(c);

            return Insert(c, required, repeating, false, items.Count, name);
        }

        /// <summary>
        /// Gets a group item by name.
        /// </summary>
        /// <param name="name">The name of the group item.</param>
        /// <returns>Group item if found, null otherwise.</returns>
        protected AbstractGroupItem GetGroupItem(string name)
        {
            AbstractGroupItem ret = null;
            foreach (var item in items)
            {
                if (item.Name.Equals(name))
                {
                    ret = item;
                    break;
                }
            }

            return ret;
        }

        private void Init()
        {
            items = new List<AbstractGroupItem>();
        }

        /// <summary> Inserts the given structure into this group, at the
        /// indicated index number.  This method is used to support handling
        /// of unexpected segments (e.g. Z-segments).  In contrast, specification
        /// of the group's normal children should be done at construction time, using the
        /// add(...) method.
        /// </summary>
        private string Insert(Type classType, bool required, bool repeating, bool choiceElement, int index, string name)
        {
            // see if there is already something by this name and make a new name if necessary ...
            if (NameExists(name))
            {
                var version = 2;
                var newName = name;
                while (NameExists(newName))
                {
                    newName = name + version++;
                }

                name = newName;
            }

            var item = new AbstractGroupItem(name, required, repeating, choiceElement, classType);
            items.Insert(index, item);
            return name;
        }

        /// <summary> Returns true if the class name is already being used. </summary>
        private bool NameExists(string name)
        {
            var exists = false;
            var item = GetGroupItem(name);
            if (item != null)
            {
                exists = true;
            }

            return exists;
        }

        /// <summary> Attempts to create an instance of the given class and return
        /// it as a Structure.
        /// </summary>
        /// <param name="c">the Structure implementing class.
        /// </param>
        /// <param name="name">an optional name of the structure (used by Generic structures; may be null).
        /// </param>
        private IStructure TryToInstantiateStructure(Type c, string name)
        {
            IStructure s;
            try
            {
                if (typeof(GenericSegment).IsAssignableFrom(c))
                {
                    s = new GenericSegment(this, name);
                }
                else if (typeof(GenericGroup).IsAssignableFrom(c))
                {
                    s = new GenericGroup(this, name, myFactory);
                }
                else
                {
                    // first try to instantiate using constructor w/ Message arg ...
                    object o;
                    try
                    {
                        var argClasses = new[] { typeof(IGroup), typeof(IModelClassFactory) };
                        var argObjects = new object[] { this, myFactory };
                        var con = c.GetConstructor(argClasses);
                        o = con.Invoke(argObjects);
                    }
                    catch (MethodAccessException)
                    {
                        o = Activator.CreateInstance(c);
                    }

                    if (!(o is IStructure))
                    {
                        throw new HL7Exception(
                            $"Class {c.FullName} does not implement ca.on.uhn.hl7.message.Structure",
                            ErrorCode.APPLICATION_INTERNAL_ERROR);
                    }

                    s = (IStructure)o;
                }
            }
            catch (Exception e)
            {
                if (e is HL7Exception)
                {
                    throw (HL7Exception)e;
                }

                throw new HL7Exception($"Can't instantiate class {c.FullName}", ErrorCode.APPLICATION_INTERNAL_ERROR, e);
            }

            return s;
        }

        /// <summary>
        /// returns a name for a class of a Structure in this Message.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private string GetStructureName(Type c)
        {
            var fullName = c.FullName;
            var dotLoc = fullName.LastIndexOf('.');
            var name = fullName.Substring(dotLoc + 1, fullName.Length - (dotLoc + 1));

            // remove message name prefix from group names for compatibility with getters ...
            if (typeof(IGroup).IsAssignableFrom(c) && !typeof(IMessage).IsAssignableFrom(c))
            {
                var messageName = Message.GetStructureName();
                if (name.StartsWith(messageName) && name.Length > messageName.Length)
                {
                    name = name.Substring(messageName.Length + 1);
                }
            }

            return name;
        }
    }
}