/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "SizeRule.java".  Description:
  "Checks that Primitive values conform to a certain size limit"

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

namespace NHapi.Base.validation.impl
{
    using System;

   /// <summary> Checks that Primitive values conform to a certain size limit.
   ///
   /// </summary>
   /// <author>  <a href="mailto:bryan.tripp@uhn.on.ca">Bryan Tripp</a>
   /// </author>
   /// <version>  $Revision: 1.3 $ updated on $Date: 2005/06/14 20:16:01 $ by $Author: bryan_tripp $.
   /// </version>
    public class SizeRule : IPrimitiveTypeRule
    {
        /// <summary>
        /// <seealso cref="IRule.Description" />
        /// </summary>
        public virtual string Description
        {
            get { return "Maximum size <= " + myMaxChars + " characters"; }
        }

        /// <summary>
        /// <seealso cref="IRule.SectionReference" />
        /// </summary>
        public virtual string SectionReference
        {
            get { return null; }
        }

        private int myMaxChars;

        /// <param name="theMaxChars">the maximum number of characters this rule allows in a
        /// primitive value.
        /// </param>
        public SizeRule(int theMaxChars)
        {
            myMaxChars = theMaxChars;
        }

        /// <summary>
        /// Does nothing. If what you wanted was to trim the value to the max size, you should
        /// make a separate rule for that.
        /// </summary>
        /// <seealso cref="IPrimitiveTypeRule.correct" />
        /// <returns>The value that was passed in as <paramref name="value_Renamed"/>.</returns>
        public virtual string correct(string value_Renamed)
        {
            return value_Renamed;
        }

        /// <seealso cref="IPrimitiveTypeRule.test" />
        public virtual bool test(string value_Renamed)
        {
            bool ok = true;
            if (value_Renamed != null && value_Renamed.Length > myMaxChars)
            {
                ok = false;
            }

            return ok;
        }
    }
}
