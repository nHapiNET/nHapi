/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "ValidationContextImpl.java".  Description:
  "A default implementation of ValidationContext."

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
using System.Collections;

using NHapi.Base.Model;

namespace NHapi.Base.validation.impl
{
   /// <summary> A default implementation of <code>ValidationContext</code>.
   ///
   /// </summary>
   /// <author>  <a href="mailto:bryan.tripp@uhn.on.ca">Bryan Tripp</a>
   /// </author>
   /// <version>  $Revision: 1.5 $ updated on $Date: 2005/06/27 22:42:18 $ by $Author: bryan_tripp $
   /// </version>
   public class ValidationContextImpl : IValidationContext
    {
        /// <returns> a List of <code>RuleBinding</code>s for <code>PrimitiveTypeRule</code>s.
        /// </returns>
        public virtual IList PrimitiveRuleBindings
        {
            get { return myPrimitiveRuleBindings; }
        }

        /// <returns> a List of <code>RuleBinding</code>s for <code>MessageRule</code>s.
        /// </returns>
        public virtual IList MessageRuleBindings
        {
            get { return myMessageRuleBindings; }
        }

        /// <returns> a List of <code>RuleBinding</code>s for <code>EncodingRule</code>s.
        /// </returns>
        public virtual IList EncodingRuleBindings
        {
            get { return myEncodingRuleBindings; }

            // /**
            //     * @see NHapi.Base.validation.ValidationContext#getCheckPrimitivesOnSet()
            //     */
            //    public boolean getCheckPrimitivesOnSet() {
            //        return myCheckPrimitivesFlag;
            //    }
            //
            //    /**
            //     * @see NHapi.Base.validation.ValidationContext#setCheckPrimitivesOnSet(boolean)
            //     */
            //    public void setCheckPrimitivesOnSet(boolean check) {
            //        myCheckPrimitivesFlag = check;
            //    }
        }

        private IList myPrimitiveRuleBindings;
        private IList myMessageRuleBindings;
        private IList myEncodingRuleBindings;

        public ValidationContextImpl()
        {
            myPrimitiveRuleBindings = new ArrayList(30);
            myMessageRuleBindings = new ArrayList(20);
            myEncodingRuleBindings = new ArrayList(10);
        }

        public virtual IPrimitiveTypeRule[] getPrimitiveRules(string theVersion, string theTypeName, IPrimitive theType)
        {
            IList active = new ArrayList(myPrimitiveRuleBindings.Count);
            for (int i = 0; i < myPrimitiveRuleBindings.Count; i++)
            {
                object o = myPrimitiveRuleBindings[i];
                if (!(o is RuleBinding))
                {
                    throw new InvalidCastException("Item in rule binding list is not a RuleBinding");
                }

                RuleBinding binding = (RuleBinding)o;
                if (binding.Active && binding.appliesToVersion(theVersion) && binding.appliesToScope(theTypeName))
                {
                    active.Add(binding.Rule);
                }
            }

            return (IPrimitiveTypeRule[])SupportClass.ICollectionSupport.ToArray(active, new IPrimitiveTypeRule[0]);
        }

        public virtual IMessageRule[] getMessageRules(string theVersion, string theMessageType, string theTriggerEvent)
        {
            IList active = new ArrayList(myMessageRuleBindings.Count);
            for (int i = 0; i < myMessageRuleBindings.Count; i++)
            {
                object o = myMessageRuleBindings[i];
                if (!(o is RuleBinding))
                {
                    throw new InvalidCastException("Item in rule binding list is not a RuleBinding");
                }

                RuleBinding binding = (RuleBinding)o;
                if (binding.Active && binding.appliesToVersion(theVersion) &&
                     binding.appliesToScope(theMessageType + "^" + theTriggerEvent))
                {
                    active.Add(binding.Rule);
                }
            }

            return (IMessageRule[])SupportClass.ICollectionSupport.ToArray(active, new IMessageRule[0]);
        }

        public virtual IEncodingRule[] getEncodingRules(string theVersion, string theEncoding)
        {
            IList active = new ArrayList(myEncodingRuleBindings.Count);
            for (int i = 0; i < myEncodingRuleBindings.Count; i++)
            {
                object o = myEncodingRuleBindings[i];
                if (!(o is RuleBinding))
                {
                    throw new InvalidCastException("Item in rule binding list is not a RuleBinding");
                }

                RuleBinding binding = (RuleBinding)o;
                if (binding.Active && binding.appliesToVersion(theVersion) && binding.appliesToScope(theEncoding))
                {
                    active.Add(binding.Rule);
                }
            }

            return (IEncodingRule[])SupportClass.ICollectionSupport.ToArray(active, new IEncodingRule[0]);
        }
    }
}