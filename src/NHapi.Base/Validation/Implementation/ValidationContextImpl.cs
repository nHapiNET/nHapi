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

namespace NHapi.Base.Validation.Implementation
{
    using System;
    using System.Collections;

    using NHapi.Base.Model;

    /// <summary>
    /// A default implementation of. <code>ValidationContext</code>.
    /// </summary>
    /// <author><a href="mailto:bryan.tripp@uhn.on.ca">Bryan Tripp</a></author>
    /// <version>
    /// $Revision: 1.5 $ updated on $Date: 2005/06/27 22:42:18 $ by $Author: bryan_tripp $.
    /// </version>
    public class ValidationContextImpl : IValidationContext
    {
        public ValidationContextImpl()
        {
            PrimitiveRuleBindings = new ArrayList(30);
            MessageRuleBindings = new ArrayList(20);
            EncodingRuleBindings = new ArrayList(10);
        }

        /// <returns> a List of. <code>RuleBinding</code>s for. <code>PrimitiveTypeRule</code>s.
        /// </returns>
        public virtual IList PrimitiveRuleBindings { get; }

        /// <returns> a List of. <code>RuleBinding</code>s for. <code>MessageRule</code>s.
        /// </returns>
        public virtual IList MessageRuleBindings { get; }

        /// <returns> a List of. <code>RuleBinding</code>s for. <code>EncodingRule</code>s.
        /// </returns>
        public virtual IList EncodingRuleBindings { get; }

        /// <inheritdoc />
        public virtual IPrimitiveTypeRule[] getPrimitiveRules(string theVersion, string theTypeName, IPrimitive theType)
        {
            return GetPrimitiveRules(theVersion, theTypeName, theType);
        }

        /// <inheritdoc />
        public virtual IPrimitiveTypeRule[] GetPrimitiveRules(string theVersion, string theTypeName, IPrimitive theType)
        {
            IList active = new ArrayList(PrimitiveRuleBindings.Count);
            for (var i = 0; i < PrimitiveRuleBindings.Count; i++)
            {
                var o = PrimitiveRuleBindings[i];
                if (!(o is RuleBinding))
                {
                    throw new InvalidCastException("Item in rule binding list is not a RuleBinding");
                }

                var binding = (RuleBinding)o;
                if (binding.Active && binding.AppliesToVersion(theVersion) && binding.AppliesToScope(theTypeName))
                {
                    active.Add(binding.Rule);
                }
            }

            return (IPrimitiveTypeRule[])SupportClass.ICollectionSupport.ToArray(active, new IPrimitiveTypeRule[0]);
        }

        /// <inheritdoc />
        public virtual IMessageRule[] getMessageRules(string theVersion, string theMessageType, string theTriggerEvent)
        {
            return GetMessageRules(theVersion, theMessageType, theTriggerEvent);
        }

        /// <inheritdoc />
        public virtual IMessageRule[] GetMessageRules(string theVersion, string theMessageType, string theTriggerEvent)
        {
            IList active = new ArrayList(MessageRuleBindings.Count);
            for (var i = 0; i < MessageRuleBindings.Count; i++)
            {
                var o = MessageRuleBindings[i];
                if (!(o is RuleBinding))
                {
                    throw new InvalidCastException("Item in rule binding list is not a RuleBinding");
                }

                var binding = (RuleBinding)o;
                if (binding.Active && binding.AppliesToVersion(theVersion) &&
                     binding.AppliesToScope(theMessageType + "^" + theTriggerEvent))
                {
                    active.Add(binding.Rule);
                }
            }

            return (IMessageRule[])SupportClass.ICollectionSupport.ToArray(active, new IMessageRule[0]);
        }

        /// <inheritdoc />
        public virtual IEncodingRule[] getEncodingRules(string theVersion, string theEncoding)
        {
            return GetEncodingRules(theVersion, theEncoding);
        }

        /// <inheritdoc />
        public virtual IEncodingRule[] GetEncodingRules(string theVersion, string theEncoding)
        {
            IList active = new ArrayList(EncodingRuleBindings.Count);
            for (var i = 0; i < EncodingRuleBindings.Count; i++)
            {
                var o = EncodingRuleBindings[i];
                if (!(o is RuleBinding))
                {
                    throw new InvalidCastException("Item in rule binding list is not a RuleBinding");
                }

                var binding = (RuleBinding)o;
                if (binding.Active && binding.AppliesToVersion(theVersion) && binding.AppliesToScope(theEncoding))
                {
                    active.Add(binding.Rule);
                }
            }

            return (IEncodingRule[])SupportClass.ICollectionSupport.ToArray(active, new IEncodingRule[0]);
        }
    }
}