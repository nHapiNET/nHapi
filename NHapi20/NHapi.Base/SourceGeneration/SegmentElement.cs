/// <summary>The contents of this file are subject to the Mozilla Public License Version 1.1 
/// (the "License"); you may not use this file except in compliance with the License. 
/// You may obtain a copy of the License at http://www.mozilla.org/MPL/ 
/// Software distributed under the License is distributed on an "AS IS" basis, 
/// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the 
/// specific language governing rights and limitations under the License. 
/// The Original Code is "SegmentElement.java".  Description: 
/// "A structure for storing a single data element of a segment .." 
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

    /// <summary> A structure for storing a single data element of a segment ... </summary>
    /// <author>  Bryan Tripp (bryan_tripp@sourceforge.net)
    /// </author>
    class SegmentElement
    {

        public int field;
        public System.String rep;
        public int repetitions;
        public System.String desc;
        public int length;
        public int table;
        public System.String opt;
        public System.String type;


        virtual public string GetDescriptionWithoutSpecialCharacters()
        {
            string desc = this.desc;
            desc = desc.Replace('\n', ' ');
            desc = desc.Replace('\"', '\'');
            desc = desc.Replace("&", "and");
            return desc;
        }

        /// <summary>Creates new SegmentElement </summary>
        public SegmentElement()
        {
        }
    }
}