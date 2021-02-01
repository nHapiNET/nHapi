/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "TrimLeadingWhitespaceRule.java".  Description:
  "Performs no validation but removes leading whitespace in the correct() method."

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2004.  All Rights Reserved.

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

using System;

namespace NHapi.Base.validation.impl
{
   /// <summary> Performs no validation but removes leading whitespace in the correct() method.
   ///
   /// </summary>
   /// <author>  <a href="mailto:bryan.tripp@uhn.on.ca">Bryan Tripp</a>
   /// </author>
   /// <version>  $Revision: 1.2 $ updated on $Date: 2005/06/14 20:16:01 $ by $Author: bryan_tripp $
   /// </version>
   public class TrimLeadingWhitespace : IPrimitiveTypeRule
    {
        /// <summary>
        /// Description of the rule
        /// </summary>
        public virtual String Description
        {
            get { return "Leading whitespace removed"; }
        }

        /// <summary>
        /// Section reference
        /// </summary>
        public virtual String SectionReference
        {
            get { return null; }
        }

        /// <summary> Removes leading whitespace.</summary>
        public virtual String correct(String value_Renamed)
        {
            String trmValue = null;
            if (value_Renamed != null)
            {
                char[] stringChr = value_Renamed.ToCharArray();
                for (int i = 0; i < stringChr.Length && trmValue == null; i++)
                {
                    if (!Char.IsWhiteSpace(stringChr[i]))
                    {
                        trmValue = new String(stringChr, i, (stringChr.Length - i));
                    }
                }
            }
            return trmValue;
        }

        /// <summary> Returns true. </summary>
        public virtual bool test(String value_Renamed)
        {
            return true;
        }
    }
}