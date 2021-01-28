/*
 * The contents of this file are subject to the Mozilla Public License Version 1.1 
 * (the "License"); you may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at http://www.mozilla.org/MPL/ 
 * Software distributed under the License is distributed on an "AS IS" basis, 
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the 
 * specific language governing rights and limitations under the License. 
 * 
 * The Original Code is "ValidationContext.java".  Description: 
 * "A set of rules for message validation" 
 * 
 * The Initial Developer of the Original Code is University Health Network. Copyright (C) 
 * 2004.  All Rights Reserved. 
 * 
 * Contributor(s): ______________________________________. 
 * 
 * Alternatively, the contents of this file may be used under the terms of the 
 * GNU General Public License (the  �GPL�), in which case the provisions of the GPL are 
 * applicable instead of those above.  If you wish to allow use of your version of this 
 * file only under the terms of the GPL and not to allow others to use your version 
 * of this file under the MPL, indicate your decision by deleting  the provisions above 
 * and replace  them with the notice and other provisions required by the GPL License.  
 * If you do not delete the provisions above, a recipient may use your version of 
 * this file under either the MPL or the GPL. 
**/

using System;

using NHapi.Base.Model;

namespace NHapi.Base.validation
{
   /// <summary> A set of rules for message validation.  
   /// 
   /// </summary>
   /// <author>  <a href="mailto:bryan.tripp@uhn.on.ca">Bryan Tripp</a>
   /// </author>
   /// <version>  $Revision: 1.4 $ updated on $Date: 2005/06/27 22:42:18 $ by $Author: bryan_tripp $
   /// </version>
   public interface IValidationContext
	{
		/// <param name="theVersion">an HL7 version (eg "2.1")
		/// </param>
		/// <param name="theTypeName">a primitive datatype name (eg "ST")
		/// </param>
		/// <param name="theType">the Primitive being validated 
		/// </param>
		/// <returns> active rules for checking the given type in the given version 
		/// </returns>
		IPrimitiveTypeRule[] getPrimitiveRules(String theVersion, String theTypeName, IPrimitive theType);

		/// <param name="theVersion">an HL7 version (eg "2.1")
		/// </param>
		/// <param name="theMessageType">a value valid for MSH-9-1
		/// </param>
		/// <param name="theTriggerEvent">a value valid fro MSH-9-2
		/// </param>
		/// <returns> the active rules that apply to message of the given version, message type, 
		/// and trigger event 
		/// </returns>
		IMessageRule[] getMessageRules(String theVersion, String theMessageType, String theTriggerEvent);

		/// <param name="theVersion">an HL7 version (eg "2.1")
		/// </param>
		/// <param name="theEncoding">an encoding name (eg "VB", "XML)
		/// </param>
		/// <returns> the active encoding rules that apply to the given version and encoding
		/// </returns>
		IEncodingRule[] getEncodingRules(String theVersion, String theEncoding);
	}
}