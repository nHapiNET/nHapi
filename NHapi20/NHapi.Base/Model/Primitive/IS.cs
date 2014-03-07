/// <summary> The contents of this file are subject to the Mozilla Public License Version 1.1
/// (the "License"); you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at http://www.mozilla.org/MPL/
/// Software distributed under the License is distributed on an "AS IS" basis,
/// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
/// specific language governing rights and limitations under the License.
/// 
/// The Original Code is "IS.java".  Description:
/// "This class contains functionality used by the ID class
/// in the version 2.3.0, 2.3.1, 2.4, and 2.5 packages"
/// 
/// The Initial Developer of the Original Code is University Health Network. Copyright (C)
/// 2005.  All Rights Reserved.
/// 
/// Contributor(s): ______________________________________.
/// 
/// Alternatively, the contents of this file may be used under the terms of the
/// GNU General Public License (the  “GPL”), in which case the provisions of the GPL are
/// applicable instead of those above.  If you wish to allow use of your version of this
/// file only under the terms of the GPL and not to allow others to use your version
/// of this file under the MPL, indicate your decision by deleting  the provisions above
/// and replace  them with the notice and other provisions required by the GPL License.
/// If you do not delete the provisions above, a recipient may use your version of
/// this file under either the MPL or the GPL.
/// 
/// </summary>
using System;
using NHapi.Base.Model;
namespace NHapi.Base.Model.Primitive
{

    /// <summary> This class contains functionality used by the IS class
    /// in the version 2.3.0, 2.3.1, 2.4, and 2.5 packages
    /// 
    /// Note: The class description below has been excerpted from the Hl7 2.4 documentation. Sectional
    /// references made below also refer to the same documentation.
    /// 
    /// The value of such a field follows the formatting rules for a ST field except that it is
    /// drawn from a site-defined (or user-defined) table of legal values. There shall be an HL7
    /// table number associated with IS data types. An example of an IS field is the Event reason
    /// code defined in Section 3.3.1.4, "Event reason code." This data type should be used only for
    /// user-defined tables (see Section 2.7.6, "Table"). The reverse is not true, since in some
    /// circumstances, it is more appropriate to use the CE data type for user-defined tables.
    /// 
    /// </summary>
    /// <author>  <a href="mailto:neal.acharya@uhn.on.ca">Neal Acharya</a>
    /// </author>
    /// <author>  <a href="mailto:bryan.tripp@uhn.on.ca">Bryan Tripp</a>
    /// </author>
    /// <version>  $Revision: 1.3 $ updated on $Date: 2005/06/08 00:28:25 $ by $Author: bryan_tripp $
    /// </version>
    public abstract class IS : AbstractPrimitive
    {
        /// <returns> number of HL7 table from which values should be drawn (defaults to 0) 
        /// </returns>
        /// <param name="theTable">HL7 table from which values are to be drawn 
        /// </param>
        virtual public int Table
        {
            get
            {
                return myTable;
            }

            set
            {
                myTable = value;
            }

        }

        private int myTable = 0;

        /// <param name="theMessage">message to which this Type belongs
        /// </param>
        public IS(IMessage theMessage)
            : base(theMessage)
        {
        }


        public IS(IMessage theMessage, string description)
            : base(theMessage, description)
        {
        }

        /// <param name="theMessage">message to which this Type belongs
        /// </param>
        /// <param name="theTable">HL7 table from which values are to be drawn 
        /// </param>
        public IS(IMessage theMessage, int theTable)
            : base(theMessage)
        {
            myTable = theTable;
        }

        /// <param name="theMessage">message to which this Type belongs
        /// </param>
        /// <param name="theTable">HL7 table from which values are to be drawn 
        /// </param>
        public IS(IMessage theMessage, int theTable, string description)
            : base(theMessage, description)
        {
            myTable = theTable;
        }
    }
}