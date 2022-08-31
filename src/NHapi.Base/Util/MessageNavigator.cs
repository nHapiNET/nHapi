/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "MessageNaviagtor.java".  Description:
  "Used to navigate the nested group structure of a message."

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2002.  All Rights Reserved.

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

namespace NHapi.Base.Util
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using NHapi.Base.Model;

    /// <summary> <p>Used to navigate the nested group structure of a message.  This is an alternate
    /// way of accessing parts of a message, ie rather than getting a segment through
    /// a chain of getXXX() calls on the message, you can create a MessageNavigator
    /// for the message, "navigate" to the desired segment, and then call
    /// getCurrentStructure() to get the segment you have navigated to.  A message
    /// navigator always has a "current location" pointing to some structure location (segment
    /// or group location) within the message.  Note that a location exists whether or
    /// not there are any instances of the structure at that location. </p>
    /// <p>This class is used by Terser, which presents an even more convenient way
    /// of navigating a message.  </p>
    /// <p>This class also has an iterate() method, which iterates over
    /// segments (and optionally groups).  </p>
    /// </summary>
    /// <author>  Bryan Tripp.
    /// </author>
    public class MessageNavigator
    {
        private Stack<GroupContext> ancestors;
        private int currentChild; // -1 means current structure is current group (special case used for root)
        private string[] childNames;

        /// <summary> Creates a new instance of MessageNavigator.</summary>
        /// <param name="root">the root of navigation -- may be a message or a group
        /// within a message.  Navigation will only occur within the subtree
        /// of which the given group is the root.
        /// </param>
        public MessageNavigator(IGroup root)
        {
            Root = root;
            Reset();
        }

        /// <summary>
        /// THe root element of this message.
        /// </summary>
        public virtual IGroup Root { get; }

        /// <summary> Returns the group within which the pointer is currently located.
        /// If at the root, the root is returned.
        /// </summary>
        public virtual IGroup CurrentGroup { get; private set; }

        /// <summary> Returns the array of structures at the current location.
        /// Throws an exception if pointer is at root.
        /// </summary>
        public virtual IStructure[] CurrentChildReps
        {
            get
            {
                if (CurrentGroup == Root && currentChild == -1)
                {
                    throw new HL7Exception("Pointer is at root of navigator: there is no current child");
                }

                var childName = childNames[currentChild];
                return CurrentGroup.GetAll(childName);
            }
        }

        [Obsolete("This method has been replaced by 'DrillDown'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual void drillDown(int childNumber, int rep)
        {
            DrillDown(childNumber, rep);
        }

        /// <summary> Drills down into the group at the given index within the current
        /// group -- ie sets the location pointer to the first structure within the child.
        /// </summary>
        /// <param name="childNumber">the index of the group child into which to drill.
        /// </param>
        /// <param name="rep">the group repetition into which to drill.
        /// </param>
        public virtual void DrillDown(int childNumber, int rep)
        {
            if (childNumber != -1)
            {
                var s = CurrentGroup.GetStructure(childNames[childNumber], rep);
                if (s is not IGroup group)
                {
                    throw new HL7Exception("Can't drill into segment", ErrorCode.APPLICATION_INTERNAL_ERROR);
                }

                // stack the current group and location
                var gc = new GroupContext(this, CurrentGroup, currentChild);
                ancestors.Push(gc);

                CurrentGroup = group;
            }

            currentChild = 0;
            childNames = CurrentGroup.Names;
        }

        [Obsolete("This method has been replaced by 'DrillDown'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual void drillDown(int rep)
        {
            DrillDown(rep);
        }

        /// <summary> Drills down into the group at the CURRENT location.</summary>
        public virtual void DrillDown(int rep)
        {
            DrillDown(currentChild, rep);
        }

        [Obsolete("This method has been replaced by 'DrillUp'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual bool drillUp()
        {
            return DrillUp();
        }

        /// <summary> Switches the group context to the parent of the current group,
        /// and sets the child pointer to the next sibling.
        /// </summary>
        /// <returns> false if already at root.
        /// </returns>
        public virtual bool DrillUp()
        {
            // pop the top group and resume search there
            if (ancestors.Count != 0)
            {
                var gc = ancestors.Pop();
                CurrentGroup = gc.Group;
                currentChild = gc.Child;
                childNames = CurrentGroup.Names;
                return true;
            }
            else
            {
                if (currentChild == -1)
                {
                    return false;
                }
                else
                {
                    currentChild = -1;
                    return true;
                }
            }
        }

        [Obsolete("This method has been replaced by 'HasNextChild'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual bool hasNextChild()
        {
            return HasNextChild();
        }

        /// <summary>
        /// Returns true if there is a sibling following the current location.
        /// </summary>
        public virtual bool HasNextChild()
        {
            return childNames.Length > (currentChild + 1);
        }

        [Obsolete("This method has been replaced by 'NextChild'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual void nextChild()
        {
            NextChild();
        }

        /// <summary> Moves to the next sibling of the current location.</summary>
        public virtual void NextChild()
        {
            var child = currentChild + 1;
            ToChild(child);
        }

        [Obsolete("This method has been replaced by 'ToChild'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual string toChild(int child)
        {
            return ToChild(child);
        }

        /// <summary> Moves to the sibling of the current location at the specified index.</summary>
        public virtual string ToChild(int child)
        {
            if (child >= 0 && child < childNames.Length)
            {
                currentChild = child;
                return this.childNames[child];
            }
            else
            {
                throw new HL7Exception(
                    $"Can't advance to child {child} -- only {childNames.Length} children",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }
        }

        [Obsolete("This method has been replaced by 'Reset'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual void reset()
        {
            Reset();
        }

        /// <summary>Resets the location to the beginning of the tree (the root). </summary>
        public virtual void Reset()
        {
            ancestors = new Stack<GroupContext>();
            CurrentGroup = Root;
            currentChild = -1;
            childNames = CurrentGroup.Names;
        }

        [Obsolete("This method has been replaced by 'GetCurrentStructure'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual IStructure getCurrentStructure(int rep)
        {
            return GetCurrentStructure(rep);
        }

        /// <summary> Returns the given rep of the structure at the current location.
        /// If at root, always returns the root (the rep is ignored).
        /// </summary>
        public virtual IStructure GetCurrentStructure(int rep)
        {
            if (currentChild == -1)
            {
                return CurrentGroup;
            }

            var childName = childNames[currentChild];
            return this.CurrentGroup.GetStructure(childName, rep);
        }

        [Obsolete("This method has been replaced by 'Iterate'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual void iterate(bool segmentsOnly, bool loop)
        {
            Iterate(segmentsOnly, loop);
        }

        /// <summary> Iterates through the message tree to the next segment/group location (regardless
        /// of whether an instance of the segment exists).  If the end of the tree is
        /// reached, starts over at the root.  Only enters the first repetition of a
        /// repeating group -- explicit navigation (using the drill...() methods) is
        /// necessary to get to subsequent reps.
        /// </summary>
        /// <param name="segmentsOnly">if true, only stops at segments (not groups).
        /// </param>
        /// <param name="loop">if true, loops back to beginning when end of msg reached; if false,
        /// throws HL7Exception if end of msg reached.
        /// </param>
        public virtual string Iterate(bool segmentsOnly, bool loop)
        {
            var start = currentChild == -1
                ? CurrentGroup
                : CurrentGroup.GetStructure(childNames[currentChild]);

            // using a non-existent direction and not allowing segment creation means that only
            // the first rep of anything is traversed.
            IEnumerator it = new MessageIterator(start, "doesn't exist", false);
            if (segmentsOnly)
            {
                FilterIterator.IPredicate predicate = new IsSegmentPredicate(this);
                it = new FilterIterator(it, predicate);
            }

            if (it.MoveNext())
            {
                var next = (IStructure)it.Current;
                return DrillHere(next);
            }
            else if (loop)
            {
                Reset();
                return string.Empty;
            }
            else
            {
                throw new HL7Exception(
                    "End of message reached while iterating without loop",
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }
        }

        /// <summary> Navigates to a specific location in the message.</summary>
        private string DrillHere(IStructure destination)
        {
            var pathElem = destination;
            var pathStack = new Stack<IStructure>();
            var indexStack = new Stack<MessageIterator.Index>();
            do
            {
                var index = MessageIterator.GetIndex(pathElem.ParentStructure, pathElem);
                indexStack.Push(index);
                pathElem = pathElem.ParentStructure;
                pathStack.Push(pathElem);
            }
            while (!Root.Equals(pathElem) && pathElem is not IMessage);

            if (!Root.Equals(pathElem))
            {
                throw new HL7Exception("The destination provided is not under the root of this navigator");
            }

            Reset();
            string result = null;
            while (pathStack.Count != 0)
            {
                var parent = (IGroup)pathStack.Pop();
                var index = indexStack.Pop();
                var child = Search(parent.Names, index.Name);
                if (pathStack.Count != 0)
                {
                    DrillDown(child, 0);
                }
                else
                {
                    result = ToChild(child);
                }
            }

            return result;
        }

        /// <summary>Like Arrays.binarySearch, only probably slower and doesn't require
        /// a sorted list.  Also just returns -1 if item isn't found.
        /// </summary>
        private int Search(string[] list, object item)
        {
            var found = -1;
            for (var i = 0; i < list.Length && found == -1; i++)
            {
                if (list[i].Equals(item))
                {
                    found = i;
                }
            }

            return found;
        }

        /// <summary> A structure to hold current location information at
        /// one level of the message tree.  A stack of these
        /// identifies the current location completely.
        /// </summary>
        private class GroupContext
        {
            public GroupContext(MessageNavigator enclosingInstance, IGroup group, int child)
            {
                EnclosingInstance = enclosingInstance;
                Group = group;
                Child = child;
            }

            public MessageNavigator EnclosingInstance { get; }

            public IGroup Group { get; }

            public int Child { get; }
        }

        private sealed class IsSegmentPredicate : FilterIterator.IPredicate
        {
            public IsSegmentPredicate(MessageNavigator enclosingInstance)
            {
                EnclosingInstance = enclosingInstance;
            }

            public MessageNavigator EnclosingInstance { get; }

            public bool evaluate(object obj)
            {
                return Evaluate(obj);
            }

            public bool Evaluate(object obj)
            {
                return obj is ISegment;
            }
        }
    }
}