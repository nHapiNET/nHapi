/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "AbstractSegment.java".  Description:
  "Provides common functionality needed by implementers of the Segment interface.

  Implementing classes should define all the fields for the segment they represent
  in their constructor"
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
    using System.Reflection;
    using System.Text.RegularExpressions;

    using NHapi.Base.Log;
    using NHapi.Base.Parser;

    /// <summary> Provides common functionality needed by implementers of the Segment interface.
    /// Implementing classes should define all the fields for the segment they represent
    /// in their constructor.  The add() method is useful for this purpose.
    /// For example the constructor for an MSA segment might contain the following code:
    /// <code>this.add(new ID(), true, 2, null);
    /// this.add(new ST(), true, 20, null);</code>
    /// <author>  Bryan Tripp (bryan_tripp@sourceforge.net)
    /// </author>
    /// </summary>
    public abstract class AbstractSegment : ISegment
    {
        private static readonly IHapiLog Log;

        private readonly List<AbstractSegmentItem> items;

        /// <summary> Sets the segment name.  This would normally be called by a Parser. </summary>
        static AbstractSegment()
        {
            Log = HapiLogFactory.GetHapiLog(typeof(AbstractSegment));
        }

        /// <summary> Calls the abstract init() method to create the fields in this segment.
        ///
        /// </summary>
        /// <param name="parentStructure">parent group.
        /// </param>
        /// <param name="factory">all implementors need a model class factory to find datatype classes, so we
        /// include it as an arg here to emphasize that fact ... AbstractSegment doesn't actually
        /// use it though.
        /// </param>
        public AbstractSegment(IGroup parentStructure, IModelClassFactory factory)
        {
            ParentStructure = parentStructure;
            items = new List<AbstractSegmentItem>();
        }

        /// <summary> Returns the Message to which this segment belongs.  </summary>
        public virtual IMessage Message
        {
            get
            {
                IStructure s = this;
                while (!typeof(IMessage).IsAssignableFrom(s.GetType()))
                {
                    s = s.ParentStructure;
                }

                return (IMessage)s;
            }
        }

        /// <summary>
        /// Immediate parent Group or message containing this segment.
        /// </summary>
        public virtual IGroup ParentStructure { get; }

        /// <summary> Returns an array of Field objects at the specified location in the segment.  In the case of
        /// non-repeating fields the array will be of length one.  Fields are numbered from 1.
        /// </summary>
        public virtual IType[] GetField(int number)
        {
            EnsureEnoughFields(number);

            if (number < 1 || number > items.Count)
            {
                throw new HL7Exception(
                    $"Can't retrieve field {number} from segment {GetType().FullName} - there are only {items[number - 1].Fields.Count} fields.",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            return items[number - 1].GetAllFieldsAsITypeArray();
        }

        /// <summary> Return the field description.  Fields are numbered from 1.
        /// </summary>
        public virtual string GetFieldDescription(int number)
        {
            EnsureEnoughFields(number);
            if (number < 1 || number > items.Count)
            {
                throw new HL7Exception(
                    $"Can't retrieve field {number} from segment {GetType().FullName} - there are only {items.Count} fields.",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            return items[number - 1].Description;
        }

        /// <summary>
        /// Returns the total number of items used for the field X.  Fields are numbered from 1.
        /// </summary>
        /// <param name="number">Field Number (Starts at 1).</param>
        /// <returns>0 if no fields users, otherwise, the number of fields used.</returns>
        public virtual int GetTotalFieldRepetitionsUsed(int number)
        {
            return items[number - 1].Fields.Count;
        }

        /// <summary> Returns a specific repetition of field at the specified index.  If there exist
        /// fewer repetitions than are required, the number of repetitions can be increased
        /// by specifying the lowest repetition that does not yet exist.  For example
        /// if there are two repetitions but three are needed, the third can be created
        /// and accessed using the following code:
        /// <code>Type t = GetField(x, 3);</code>
        /// <param name="number">the field number</param>
        /// <param name="rep">the repetition number (starting at 0) </param>
        /// <throws>  HL7Exception if field index is out of range, if the specified  </throws>
        /// repetition is greater than the maximum allowed, or if the specified
        /// repetition is more than 1 greater than the existing # of repetitions.
        /// </summary>
        public virtual IType GetField(int number, int rep)
        {
            EnsureEnoughFields(number);

            if (number < 1 || number > items.Count)
            {
                throw new HL7Exception(
                    $"Can't retrieve field {number} from segment {GetType().FullName} - there are only {items[number - 1].Fields.Count} fields.",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            var currentReps = items[number - 1].Fields.Count;

            // check if out of range ...
            if (rep > currentReps)
            {
                throw new HL7Exception(
                    $"Can't get repetition {rep} from field {number} - there are currently only {currentReps} reps.",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            // add a rep if necessary ...
            if (rep == currentReps)
            {
                items[number - 1].Fields.Add(CreateNewType(number));
            }

            return items[number - 1].Fields[rep];
        }

        /// <summary> Returns true if the given field is required in this segment - fields are
        /// numbered from 1.
        /// </summary>
        /// <throws>  HL7Exception if field index is out of range.   </throws>
        public virtual bool IsRequired(int number)
        {
            if (number < 1 || number > items.Count)
            {
                throw new HL7Exception(
                    $"Can't retrieve optionality of field {number} from segment {GetType().FullName} - there are only {items[number - 1].Fields.Count} fields.",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            var ret = false;
            try
            {
                ret = items[number - 1].IsRequired;
            }
            catch (Exception e)
            {
                throw new HL7Exception(
                    $"Can't retrieve optionality of field {number}: {e.Message}",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            return ret;
        }

        /// <summary> Returns the maximum length of the field at the given index, in characters -
        /// fields are numbered from 1.
        /// </summary>
        /// <throws>  HL7Exception if field index is out of range.   </throws>
        public virtual int GetLength(int number)
        {
            if (number < 1 || number > items.Count)
            {
                throw new HL7Exception(
                    $"Can't retrieve max length of field {number} from segment {GetType().FullName} - there are only {items[number - 1].Fields.Count} fields.",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            var ret = 0;
            try
            {
                ret = items[number - 1].Length; // fields #d from 1 to user
            }
            catch (Exception e)
            {
                throw new HL7Exception(
                    $"Can't retrieve max length of field {number}: {e.Message}",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            return ret;
        }

        /// <summary> Returns the number of repetitions of this field that are allowed.  </summary>
        /// <throws>  HL7Exception if field index is out of range. </throws>
        public virtual int GetMaxCardinality(int number)
        {
            if (number < 1 || number > items.Count)
            {
                throw new HL7Exception(
                    $"Can't retrieve cardinality of field {number} from segment {GetType().FullName} - there are only {items[number - 1].Fields.Count} fields.",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            var reps = 0;
            try
            {
                reps = items[number - 1].MaxRepetitions; // fields #d from 1 to user
            }
            catch (Exception e)
            {
                throw new HL7Exception(
                    $"Can't retrieve max repetitions of field {number}: {e.Message}",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            return reps;
        }

        /// <summary>
        /// Remove a valid index from a repeatable field.
        /// </summary>
        /// <param name="fieldNum">Repeatable field number.</param>
        /// <param name="index">0-based index to be removed.</param>
        /// <exception cref="HL7Exception">If field has no repetitions.</exception>
        /// <exception cref="HL7Exception">If field index does not exist.</exception>
        public void RemoveRepetition(int fieldNum, int index)
        {
            if (fieldNum < 1 || fieldNum > items.Count)
            {
                throw new HL7Exception(
                    $"Can't retrieve field {fieldNum} from segment {GetType().FullName} - there are only {items[fieldNum - 1].Fields.Count} fields.",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            var fields = items[fieldNum - 1].Fields;

            if (fields.Count == 0)
            {
                throw new HL7Exception(
                    $"Invalid index: {index}, structure {fields.GetType().FullName} has no repetitions");
            }

            if (fields.Count <= index)
            {
                throw new HL7Exception(
                    $"Invalid index: {index}, structure {fields.GetType().FullName} must be between 0 and {fields.Count - 1}");
            }

            fields.RemoveAt(index);

            return;
        }

        /// <summary>
        /// Remove a valid item from a repeatable field.
        /// </summary>
        /// <param name="fieldNum">Repeatable field number.</param>
        /// <param name="removeItem">Item to be removed.</param>
        /// <exception cref="HL7Exception">If field number is not valid.</exception>
        /// <exception cref="HL7Exception">If field has no repetitions.</exception>
        /// <exception cref="HL7Exception">If field does not contain the repetition to remove.</exception>
        public void RemoveRepetition(int fieldNum, IType removeItem)
        {
            if (fieldNum < 1 || fieldNum > items.Count)
            {
                throw new HL7Exception(
                    $"Can't retrieve field {fieldNum} from segment {GetType().FullName} - there are only {items[fieldNum - 1].Fields.Count} fields.",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            var fields = items[fieldNum - 1].Fields;

            if (fields.Count == 0)
            {
                throw new HL7Exception(
                    $"Structure {fields.GetType().FullName} has no repetitions");
            }

            if (!fields.Contains(removeItem))
            {
                throw new HL7Exception(
                    $"Invalid item specified, structure {fields.GetType().FullName} does not contain {removeItem}");
            }

            fields.Remove(removeItem);

            return;
        }

        /// <summary>
        /// Get the 0-based index for an AbstractSegmentItem with a description that matches the given name.
        /// </summary>
        /// <param name="name">Item name, with all whitespace removed.</param>
        /// <returns>0-based index, if found.  Otherwise, -1.</returns>
        public int FindField(string name)
        {
            return items.FindIndex(x => Regex.Replace(x.Description, @"\s", string.Empty) == name);
        }

        /// <summary> Returns the number of fields defined by this segment (repeating
        /// fields are not counted multiple times).
        /// </summary>
        public virtual int NumFields()
        {
            return items.Count;
        }

        /// <summary> Returns the class name (excluding package). </summary>
        public virtual string GetStructureName()
        {
            var fullName = GetType().FullName;
            return fullName.Substring(fullName.LastIndexOf('.') + 1, fullName.Length - (fullName.LastIndexOf('.') + 1));
        }

        [Obsolete("This method has been replaced by 'Add'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        protected internal virtual void add(Type c, bool required, int maxReps, int length, object[] constructorArgs)
        {
            Add(c, required, maxReps, length, constructorArgs);
        }

        /// <summary> Adds a field to the segment.  The field is initially empty (zero repetitions).
        /// The field number is sequential depending on previous add() calls.  Implementing
        /// classes should use the add() method in their constructor in order to define fields
        /// in their segment.
        /// </summary>
        /// <param name="c">the class of the data for this field - this should inherit from Type.
        /// </param>
        /// <param name="required">whether a value for this field is required in order for the segment
        /// to be valid.
        /// </param>
        /// <param name="maxReps">the maximum number of repetitions - 0 implies that there is no limit.
        /// </param>
        /// <param name="length">the maximum length of each repetition of the field (in characters).
        /// </param>
        /// <param name="constructorArgs">an array of objects that will be used as constructor arguments
        /// if new instances of this class are created (use null for zero-arg constructor).
        /// </param>
        /// <throws>  HL7Exception if the given class does not inherit from Type or if it can.  </throws>
        /// <summary>    not be instantiated.
        /// </summary>
        protected internal virtual void Add(Type c, bool required, int maxReps, int length, object[] constructorArgs)
        {
            Add(c, required, maxReps, length, constructorArgs, null);
        }

        [Obsolete("This method has been replaced by 'Add'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        protected internal virtual void add(
            Type c,
            bool required,
            int maxReps,
            int length,
            object[] constructorArgs,
            string description)
        {
            Add(c, required, maxReps, length, constructorArgs, description);
        }

        /// <summary>
        /// Add a segment.
        /// </summary>
        /// <param name="c">The type of segment.</param>
        /// <param name="required"></param>
        /// <param name="maxReps"></param>
        /// <param name="length"></param>
        /// <param name="constructorArgs"></param>
        /// <param name="description"></param>
        protected internal virtual void Add(
            Type c,
            bool required,
            int maxReps,
            int length,
            object[] constructorArgs,
            string description)
        {
            if (!typeof(IType).IsAssignableFrom(c))
            {
                throw new HL7Exception(
                    $"Class {c.FullName} does not inherit from ca.on.uhn.datatype.Type",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            items.Add(new AbstractSegmentItem(c, required, maxReps, length, constructorArgs, description));
        }

        /// <summary> Creates a new instance of the Type at the given field number in this segment.  </summary>
        private IType CreateNewType(int field)
        {
            var number = field - 1;
            var c = items[number].FieldType;

            var description = items[number].Description;

            IType newType = null;
            try
            {
                var args = GetArgs(number, description);
                var argClasses = new Type[args.Length];
                for (var i = 0; i < args.Length; i++)
                {
                    if (args[i] is IMessage)
                    {
                        argClasses[i] = typeof(IMessage);
                    }
                    else
                    {
                        argClasses[i] = args[i].GetType();
                    }
                }

                newType = (IType)c.GetConstructor(argClasses).Invoke(args);
            }
            catch (UnauthorizedAccessException iae)
            {
                throw new HL7Exception(
                    $"Can't access class {c.FullName} ({iae.GetType().FullName}): {iae.Message}",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }
            catch (TargetInvocationException ite)
            {
                throw new HL7Exception(
                    $"Can't instantiate class {c.FullName} ({ite.GetType().FullName}): {ite.Message}",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }
            catch (MethodAccessException nme)
            {
                throw new HL7Exception(
                    $"Can't instantiate class {c.FullName} ({nme.GetType().FullName}): {nme.Message}",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }
            catch (Exception ie)
            {
                throw new HL7Exception(
                    $"Can't instantiate class {c.FullName} ({ie.GetType().FullName}): {ie.Message}",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            return newType;
        }

        // defaults to {this.getMessage}
        private object[] GetArgs(int fieldNum, string description)
        {
            object[] result = null;

            object o = items[fieldNum].Args;
            if (o != null && o is object[] && ((object[])o).Length > 0)
            {
                result = o as object[];
            }
            else
            {
                result = new object[] { Message };
            }

            var appendDescription = !string.IsNullOrEmpty(description);
            if (appendDescription)
            {
                Array.Resize(ref result, result.Length + 1);
                result[result.Length - 1] = description;
            }

            return result;
        }

        /// <summary> Called from GetField(...) methods.  If a field has been requested that
        /// doesn't exist (eg GetField(15) when only 10 fields in segment) adds Varies
        /// fields to the end of the segment up to the required number.
        /// </summary>
        private void EnsureEnoughFields(int fieldRequested)
        {
            var fieldsToAdd = fieldRequested - NumFields();
            if (fieldsToAdd < 0)
            {
                fieldsToAdd = 0;
            }

            try
            {
                for (var i = 0; i < fieldsToAdd; i++)
                {
                    Add(typeof(Varies), false, 0, 65536, null); // using 65536 following example of OBX-5
                }
            }
            catch (HL7Exception e)
            {
                Log.Error(
                    $"Can't create additional generic fields to handle request for field {fieldRequested}",
                    e);
            }
        }
    }
}