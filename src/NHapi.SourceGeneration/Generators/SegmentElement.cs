/*
    The contents of this file are subject to the Mozilla Public License Version 1.1
    (the "License"); you may not use this file except in compliance with the License.
    You may obtain a copy of the License at http://www.mozilla.org/MPL/
    Software distributed under the License is distributed on an "AS IS" basis,
    WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
    specific language governing rights and limitations under the License.

    The Original Code is "SegmentElement.java".  Description:
    "A structure for storing a single data element of a segment .."

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
    /// <summary>
    /// A structure for storing a single data element of a segment ...
    /// </summary>
    /// <author>Bryan Tripp (bryan_tripp@sourceforge.net).</author>
    internal class SegmentElement
    {
        /// <summary>
        /// Creates new SegmentElement.
        /// </summary>
        public SegmentElement()
        {
        }

        public int Field { get; set; }

        public string Rep { get; set; }

        public string AccessorNameToAppend { get; set; } = string.Empty;

        public int Repetitions { get; set; }

        public string Desc { get; set; }

        public int Length { get; set; }

        public int Table { get; set; }

        public string Opt { get; set; }

        public string Type { get; set; }

        public virtual string GetDescriptionWithoutSpecialCharacters()
        {
            return Desc
                .Replace('\n', ' ')
                .Replace('\"', '\'')
                .Replace("&", "and");
        }
    }
}