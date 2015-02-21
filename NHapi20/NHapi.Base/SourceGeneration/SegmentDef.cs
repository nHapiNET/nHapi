/// <summary>The contents of this file are subject to the Mozilla Public License Version 1.1 
/// (the "License"); you may not use this file except in compliance with the License. 
/// You may obtain a copy of the License at http://www.mozilla.org/MPL/ 
/// Software distributed under the License is distributed on an "AS IS" basis, 
/// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the 
/// specific language governing rights and limitations under the License. 
/// The Original Code is "SegmentDef.java".  Description: 
/// "Information about a message segment used in the creation of 
/// source code for a Group class" 
/// The Initial Developer of the Original Code is University Health Network. Copyright (C) 
/// 2001.  All Rights Reserved. 
/// Contributor(s): ______________________________________. 
/// Alternatively, the contents of this file may be used under the terms of the 
/// GNU General Public License (the  “GPL”), in which case the provisions of the GPL are 
/// applicable instead of those above.  If you wish to allow use of your version of this 
/// file only under the terms of the GPL and not to allow others to use your version 
/// of this file under the MPL, indicate your decision by deleting  the provisions above 
/// and replace  them with the notice and other provisions required by the GPL License.  
/// If you do not delete the provisions above, a recipient may use your version of 
/// this file under either the MPL or the GPL. 
/// </summary>
using System;
namespace NHapi.Base.SourceGeneration
{

    /// <summary> Information about a message segment used in the creation of 
    /// source code for a Group class.  SegmentDef is a slight misnomer because this 
    /// also includes group start/end indicators, with group names.  
    /// 
    /// </summary>
    /// <author>  Bryan Tripp (bryan_tripp@sourceforge.net)
    /// </author>
    public class SegmentDef : IStructureDef
    {
        /// <returns> name of segment 
        /// </returns>
        virtual public String Name
        {
            get
            {
                String result = name;
                if (result != null && result.Equals("?"))
                {
                    result = "GenericSegment";
                }
                return result;
            }

        }
        /// <returns> name of group, if this is not really a segment but a group start indicator 
        /// </returns>
        virtual public String GroupName
        {
            get
            {
                return groupName;
            }

        }
        /// <summary> Returns true if this structure is required in the Group.  </summary>
        virtual public bool Required
        {
            get
            {
                return required;
            }

        }
        /// <summary> Returns true if this structure can repeat in the Group.  </summary>
        virtual public bool Repeating
        {
            get
            {
                return repeating;
            }

        }
        /// <summary> Returns a text description of the structure.</summary>
        virtual public String Description
        {
            get
            {
                return description;
            }

        }
        /// <summary> Returns a list of the names of the segments that are children of this Structure.
        /// If the structure is a Segment, a 1-element array is returned containing the segment
        /// name.  If a Group, an array of all the segments in the Group, including those nested
        /// in subgroups (depth first).  This method is used to support the XML SIG's convention
        /// for deriving group names.
        /// </summary>
        virtual public String[] ChildSegments
        {
            get
            {
                String[] result = new String[] { Name };
                return result;
            }

        }

        private String name;
        private String groupName;
        private String description;
        private bool required;
        private bool repeating;

        /// <summary>Creates new SegmentDef </summary>
        public SegmentDef(String name, String groupName, bool required, bool repeating, String description)
        {
            this.name = name;
            this.groupName = groupName;
            this.required = required;
            this.repeating = repeating;
            this.description = description;
        }
    }
}