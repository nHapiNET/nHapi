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
    using System.Collections;
    using System.Text;

    /// <summary>
    /// Contains the information needed to create source code for a Group (a
    /// Group is a part of a message that may repeat, and that contains two or
    /// more segments or other groups).
    /// </summary>
    /// <author>Bryan Tripp (bryan_tripp@sourceforge.net).</author>
    public class GroupDef : IStructureDef
    {
        /// <summary>Creates new GroupDef. </summary>
        public GroupDef(string messageName, string groupName, bool required, bool repeating, string description)
        {
            MessageName = messageName;
            GroupName = groupName;
            Required = required;
            Repeating = repeating;
            Description = description;
        }

        /// <summary>
        /// Returns the Java class name of this Group. This is derived from the
        /// message structure and the group elements. This should only be called
        /// after all the elements are added.
        /// </summary>
        public virtual string Name
        {
            get
            {
                string result;
                if (GroupName != null && GroupName.Length > 0)
                {
                    result = $"{MessageName}_{GroupName}";
                }
                else
                {
                    var name = new StringBuilder();
                    name.Append(MessageName);
                    name.Append("_");
                    var children = ChildSegments;
                    for (var i = 0; i < children.Length; i++)
                    {
                        name.Append(children[i]);
                    }

                    result = name.ToString();
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the group name without message name pre-pended.
        /// </summary>
        public virtual string UnqualifiedName => Name.Substring(MessageName.Length + 1);

        /// <summary>
        /// Gets the structures in this group.
        /// </summary>
        public virtual IStructureDef[] Structures
        {
            get
            {
                var ret = new IStructureDef[Elements.Count];
                for (var i = 0; i < ret.Length; i++)
                {
                    ret[i] = (IStructureDef)Elements[i];
                }

                return ret;
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not this structure is required in the group.
        /// </summary>
        public virtual bool Required { get; }

        /// <summary>
        /// Gets a value indicating whether or not this structure can repeat in the group.</summary>
        public virtual bool Repeating { get; }

        /// <summary>
        /// Gets the text description of the structure.
        /// </summary>
        public virtual string Description { get; }

        /// <summary>
        /// Returns a list of the names of the segments that are children of this Structure.
        /// If the structure is a Segment, a 1-element array is returned containing the segment
        /// name.  If a Group, an array of all the segments in the Group, including those nested
        /// in subgroups (depth first). This method is used to support the XML SIG's convention
        /// for deriving group names.
        /// </summary>
        public virtual string[] ChildSegments
        {
            get
            {
                var deepChildList = new ArrayList();
                for (var i = 0; i < Elements.Count; i++)
                {
                    var childStruct = (IStructureDef)Elements[i];
                    var childStructChildren = childStruct.ChildSegments;
                    for (var j = 0; j < childStructChildren.Length; j++)
                    {
                        deepChildList.Add(childStructChildren[j]);
                    }
                }

                var result = new string[deepChildList.Count];
                for (var i = 0; i < result.Length; i++)
                {
                    result[i] = (string)deepChildList[i];
                }

                return result;
            }
        }

        private ArrayList Elements { get; } = new ArrayList();

        private Hashtable ExistingNames { get; } = new Hashtable();

        private string MessageName { get; }

        private string GroupName { get; }

        /// <summary> Adds an element (segment or group) to this group.  </summary>
        public virtual void AddStructure(IStructureDef s)
        {
            Elements.Add(s);
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
        protected internal virtual string GetIndexName(string name)
        {
            // see if this name is already being used
            var o = ExistingNames[name];
            var c = 2;
            var newName = name;
            while (o != null)
            {
                newName = name + c++;
                o = ExistingNames[newName];
            }

            name = newName;
            ExistingNames[name] = name;
            return name;
        }
    }
}