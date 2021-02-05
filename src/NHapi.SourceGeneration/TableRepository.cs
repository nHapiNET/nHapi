/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "TableRepository.java".  Description:
  "A place where table keys and values are stored"

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

namespace NHapi.SourceGeneration
{
    /// <summary> A place where table keys and values are stored.  This may be implemented
    /// with a database, an LDAP directory, local RAM, etc.  At a minimum, any
    /// underlying repository must supply the values for standard HL7 tables.
    /// Site-defined tables may also be supported.
    /// </summary>
    /// <author>  Bryan Tripp (bryan_tripp@sourceforge.net).
    /// </author>
    public abstract class TableRepository
    {
        private static TableRepository rep = null;

        /// <summary> Returns a TableRepository object.</summary>
        public static TableRepository Instance
        {
            get
            {
                if (rep == null)
                {
                    // currently using DBTableRepository ...
                    rep = new DBTableRepository();
                }

                return rep;
            }
        }

        /// <summary> Returns a list of HL7 tables.  </summary>
        public abstract int[] Tables { get; }

        /// <summary> Returns true if the given value exists in the given table.</summary>
        public abstract bool CheckValue(int table, string value_Renamed);

        /// <summary> Returns a list of the values in the given table. </summary>
        public abstract string[] GetValues(int table);

        /// <summary> Returns the value corresponding to the given table and key.</summary>
        /// <throws>  UnknownValueException if the value can not be found.  This may be an UnknownTableException.   </throws>
        public abstract string GetDescription(int table, string value_Renamed);
    }
}