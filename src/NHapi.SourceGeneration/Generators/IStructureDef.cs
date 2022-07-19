/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "StructureDef.java".  Description:
  "Information about a structure within a message (e.g"

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
    /// <summary> Information about a structure within a message (eg group, segment)
    /// that is used in creating source for a Group class.
    /// </summary>
    /// <author>  Bryan Tripp (bryan_tripp@sourceforge.net).
    /// </author>
    public interface IStructureDef
    {
        /// <summary>
        /// Returns the name of the structure.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the group name without message name pre-pended.
        /// This is only different for group definitions, where the qualification
        /// is the message type (i.e. this will return PROCEDURE instead of ADT_A01_PROCEDURE).
        /// </summary>
        string UnqualifiedName { get; }

        /// <summary>
        /// Returns a text description of the structure.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Returns true if this structure is required in the Group.
        /// </summary>
        bool Required { get; }

        /// <summary>
        /// Returns true if this structure can repeat in the Group.
        /// </summary>
        bool Repeating { get; }

        /// <summary> Returns a list of the names of the segments that are children of this Structure.
        /// If the structure is a Segment, a 1-element array is returned containing the segment
        /// name.  If a Group, an array of all the segments in the Group, including those nested
        /// in subgroups (depth first).  This method is used to support the XML SIG's convention
        /// for deriving group names.
        /// </summary>
        string[] ChildSegments { get; }
    }
}