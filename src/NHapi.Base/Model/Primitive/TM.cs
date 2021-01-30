/*
	The contents of this file are subject to the Mozilla Public License Version 1.1
	(the "License"); you may not use this file except in compliance with the License.
	You may obtain a copy of the License at http://www.mozilla.org/MPL/
	Software distributed under the License is distributed on an "AS IS" basis,
	WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
	specific language governing rights and limitations under the License.
	
	The Original Code is "TM.java".  Description:
	"Represents an HL7 TM (time) datatype."
	
	The Initial Developer of the Original Code is University Health Network. Copyright (C)
	2005.  All Rights Reserved.
	
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

namespace NHapi.Base.Model.Primitive
{
   /// <summary> Represents an HL7 TM (time) datatype. 
   /// 
   /// </summary>
   /// <author>  <a href="mailto:neal.acharya@uhn.on.ca">Neal Acharya</a>
   /// </author>
   /// <author>  <a href="mailto:bryan.tripp@uhn.on.ca">Bryan Tripp</a>
   /// </author>
   /// <version>  $Revision: 1.3 $ updated on $Date: 2005/06/08 00:28:25 $ by $Author: bryan_tripp $
   /// </version>
   public abstract class TM : AbstractPrimitive
	{
		private CommonTM Detail
		{
			get
			{
				if (myDetail == null)
				{
					myDetail = new CommonTM(Value);
				}
				return myDetail;
			}
		}

		/// <seealso cref="AbstractPrimitive.get_Value">
		/// </seealso>
		/// <seealso cref="AbstractPrimitive.set_Value(String)">
		/// </seealso>
		/// <throws>  DataTypeException if the value is incorrectly formatted and either validation is  </throws>
		/// <summary>      enabled for this primitive or detail setters / getters have been called, forcing further
		/// parsing.   
		/// </summary>
		public override String Value
		{
			get
			{
				String result = base.Value;

				if (myDetail != null)
				{
					result = myDetail.Value;
				}

				return result;
			}

			set
			{
				base.Value = value;

				if (myDetail != null)
				{
					myDetail.Value = value;
				}
			}
		}

		/// <seealso cref="CommonTM.set_HourPrecision(int)">
		/// </seealso>
		/// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
		/// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
		/// this method is called.  
		/// </summary>
		public virtual int HourPrecision
		{
			set { Detail.HourPrecision = value; }
		}

		/// <seealso cref="CommonTM.set_Offset(int)">
		/// </seealso>
		/// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
		/// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
		/// this method is called.  
		/// </summary>
		public virtual int Offset
		{
			set { Detail.Offset = value; }
		}

		/// <summary> Returns the hour as an integer.</summary>
		/// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
		/// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
		/// this method is called.  
		/// </summary>
		public virtual int Hour
		{
			get { return Detail.Hour; }
		}

		/// <summary> Returns the minute as an integer.</summary>
		/// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
		/// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
		/// this method is called.  
		/// </summary>
		public virtual int Minute
		{
			get { return Detail.Minute; }
		}

		/// <summary> Returns the second as an integer.</summary>
		/// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
		/// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
		/// this method is called.  
		/// </summary>
		public virtual int Second
		{
			get { return Detail.Second; }
		}

		/// <summary> Returns the fractional second value as a float.</summary>
		/// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
		/// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
		/// this method is called.  
		/// </summary>
		public virtual float FractSecond
		{
			get { return Detail.FractSecond; }
		}

		/// <summary> Returns the GMT offset value as an integer.</summary>
		/// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
		/// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
		/// this method is called.  
		/// </summary>
		public virtual int GMTOffset
		{
			get { return Detail.GMTOffset; }
		}

		private CommonTM myDetail;

		/// <param name="theMessage">message to which this Type belongs
		/// </param>
		protected TM(IMessage theMessage)
			: base(theMessage)
		{
		}

		/// <summary>Construct the type</summary>
		/// <param name="theMessage">message to which this Type belongs</param>
		/// <param name="description">The description of this type</param>
		protected TM(IMessage theMessage, string description)
			: base(theMessage, description)
		{
		}

		/// <seealso cref="CommonTM.setHourMinutePrecision(int, int)">
		/// </seealso>
		/// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
		/// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
		/// this method is called.  
		/// </summary>
		public virtual void setHourMinutePrecision(int hr, int min)
		{
			Detail.setHourMinutePrecision(hr, min);
		}

		/// <seealso cref="CommonTM.setHourMinSecondPrecision(int, int, float)">
		/// </seealso>
		/// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
		/// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until 
		/// this method is called.  
		/// </summary>
		public virtual void setHourMinSecondPrecision(int hr, int min, float sec)
		{
			Detail.setHourMinSecondPrecision(hr, min, sec);
		}
	}
}