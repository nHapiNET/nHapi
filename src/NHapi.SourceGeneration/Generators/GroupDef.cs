/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "GroupDef.java".  Description:
  "Contains the information needed to create source code for a Group (a
  Group is a part of a message that may repeat, and that contains two or
  more segments or other groups)"

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

namespace NHapi.SourceGeneration.Generators
{
    using System;
    using System.Collections;
    using System.Text;

   /// <summary> Contains the information needed to create source code for a Group (a
   /// Group is a part of a message that may repeat, and that contains two or
   /// more segments or other groups).
   /// </summary>
   /// <author>  Bryan Tripp (bryan_tripp@sourceforge.net).
   /// </author>
    public class GroupDef : IStructureDef
    {
        /// <summary> Returns the Java class name of this Group.  This is derived from the
        /// message structure and the group elements.  This should only be called
        /// after all the elements are added.
        /// </summary>
        public virtual string Name
        {
            get
            {
                string result = null;

                if (groupName != null && groupName.Length > 0)
                {
                    result = messageName + "_" + groupName;
                }
                else
                {
                    StringBuilder name = new StringBuilder();
                    name.Append(messageName);
                    name.Append("_");
                    string[] children = ChildSegments;
                    for (int i = 0; i < children.Length; i++)
                    {
                        name.Append(children[i]);
                    }

                    result = name.ToString();
                }

                return result;
            }
        }

        /// <returns> group name without message name prepended.
        /// </returns>
        public virtual string UnqualifiedName
        {
            get
            {
                string name = Name;
                return name.Substring(messageName.Length + 1);
            }
        }

        /// <summary> Returns the structures in this group. </summary>
        public virtual IStructureDef[] Structures
        {
            get
            {
                IStructureDef[] ret = new IStructureDef[elements.Count];
                for (int i = 0; i < ret.Length; i++)
                {
                    ret[i] = (IStructureDef)elements[i];
                }

                return ret;
            }
        }

        /// <summary> Returns true if this structure is required in the Group.  </summary>
        public virtual bool Required
        {
            get { return required; }
        }

        /// <summary> Returns true if this structure can repeat in the Group.  </summary>
        public virtual bool Repeating
        {
            get { return repeating; }
        }

        /// <summary> Returns a text description of the structure.</summary>
        public virtual string Description
        {
            get { return description; }
        }

        /// <summary> Returns a list of the names of the segments that are children of this Structure.
        /// If the structure is a Segment, a 1-element array is returned containing the segment
        /// name.  If a Group, an array of all the segments in the Group, including those nested
        /// in subgroups (depth first).  This method is used to support the XML SIG's convention
        /// for deriving group names.
        /// </summary>
        public virtual string[] ChildSegments
        {
            get
            {
                ArrayList deepChildList = new ArrayList();
                for (int i = 0; i < elements.Count; i++)
                {
                    IStructureDef childStruct = (IStructureDef)elements[i];
                    string[] childStructChildren = childStruct.ChildSegments;
                    for (int j = 0; j < childStructChildren.Length; j++)
                    {
                        deepChildList.Add(childStructChildren[j]);
                    }
                }

                string[] result = new string[deepChildList.Count];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = (string)deepChildList[i];
                }

                return result;
            }
        }

        private ArrayList elements;
        private string messageName;
        private string groupName;
        private string description;
        private bool required;
        private bool repeating;
        private Hashtable existingNames;

        /// <summary>Creates new GroupDef. </summary>
        public GroupDef(string messageName, string groupName, bool required, bool repeating, string description)
        {
            this.messageName = messageName;
            this.groupName = groupName;
            elements = new ArrayList();
            this.required = required;
            this.repeating = repeating;
            this.description = description;
            existingNames = new Hashtable();
        }

        /// <summary> Adds an element (segment or group) to this group.  </summary>
        public virtual void addStructure(IStructureDef s)
        {
            elements.Add(s);
        }

        /// <summary> Returns the name by which a particular structure can be accessed (eg for use
        /// in writing accessor source code).  This may differ from the class name of the
        /// structure of there are >1 structures in the same group with the same class.
        /// For example in ADT_A01 there are two ROL's that are not in sub-groups - AbstractGroup
        /// stores the first one under the name ROL and the second under the name ROL2.  This
        /// method returns names using the same naming scheme.  The order in which this
        /// method is called matters: it should be called ONCE for each element of the group in the
        /// order in which they appear.
        /// </summary>
        protected internal virtual string getIndexName(string name)
        {
            // see if this name is already being used
            object o = existingNames[name];
            int c = 2;
            string newName = name;
            while (o != null)
            {
                newName = name + c++;
                o = existingNames[newName];
            }

            name = newName;
            existingNames[name] = name;
            return name;
        }
    }
}