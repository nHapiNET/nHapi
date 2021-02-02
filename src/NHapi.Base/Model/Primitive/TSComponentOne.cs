/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "TSComponentOne.java".  Description:
  "Represents an HL7 timestamp, which is related to the HL7 TS type."

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

namespace NHapi.Base.Model.Primitive
{
    using System;
    using System.Globalization;
    using System.Threading;

   /// <summary>
   /// <para>
   /// Represents an HL7 timestamp, which is related to the HL7 TS type.
   /// </para>
   ///
   /// <para>
   /// In version 2.5, TS is a composite type. The first component is type DTM, which corresponds to this class
   /// (actually Model.v25.datatype.DTM inherits from this class at time of writing).
   /// </para>
   ///
   /// <para>
   /// In HL7 versions 2.2-2.4, it wasn't perfectly clear whether TS was composite or primitive. HAPI interprets
   /// it as composite, with the first component having a type that isn't defined by HL7, and we call
   /// this type TSComponentOne.
   /// </para>
   ///
   /// <para>
   /// In v2.1, TS is primitive, and corresponds one-to-one with this class.
   /// </para>
   /// </summary>
   /// <author><a href="mailto:neal.acharya@uhn.on.ca">Neal Acharya</a></author>
   /// <author><a href="mailto:bryan.tripp@uhn.on.ca">Bryan Tripp</a></author>
   /// <version>
   /// $Revision: 1.4 $ updated on $Date: 2005/06/14 20:09:39 $ by $Author: bryan_tripp $
   /// </version>
    public class TSComponentOne : AbstractPrimitive
    {
        private CommonTS Detail
        {
            get
            {
                if (myDetail == null)
                {
                    myDetail = new CommonTS(Value);
                }

                return myDetail;
            }
        }

        public override string Value
        {
            get
            {
                string result = base.Value;

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

        /// <summary>
        /// <seealso cref="CommonTS.Offset" />
        /// </summary>
        public virtual int Offset
        {
            set { Detail.Offset = value; }
        }

        /// <summary>
        /// Returns the year as an integer.
        /// </summary>
        public virtual int Year
        {
            get { return Detail.Year; }
        }

        /// <summary>
        /// Returns the month as an integer.
        /// </summary>
        public virtual int Month
        {
            get { return Detail.Month; }
        }

        /// <summary>
        /// Returns the day as an integer.
        /// </summary>
        public virtual int Day
        {
            get { return Detail.Day; }
        }

        /// <summary>
        /// Returns the hour as an integer.
        /// </summary>
        public virtual int Hour
        {
            get { return Detail.Hour; }
        }

        /// <summary>
        /// Returns the minute as an integer.
        /// </summary>
        public virtual int Minute
        {
            get { return Detail.Minute; }
        }

        /// <summary>
        /// Returns the second as an integer.
        /// </summary>
        public virtual int Second
        {
            get { return Detail.Second; }
        }

        /// <summary>
        /// Returns the fractional second value as a float.
        /// </summary>
        public virtual float FractSecond
        {
            get { return Detail.FractSecond; }
        }

        /// <summary>
        /// Returns the GMT offset value as an integer.
        /// </summary>
        public virtual int GMTOffset
        {
            get { return Detail.GMTOffset; }
        }

        private CommonTS myDetail;

        /// <param name="theMessage">message to which this Type belongs
        /// </param>
        public TSComponentOne(IMessage theMessage)
            : base(theMessage)
        {
        }

        public TSComponentOne(IMessage theMessage, string description)
            : base(theMessage, description)
        {
        }

        /// <seealso cref="CommonTS.setDatePrecision(int, int, int)">
        /// </seealso>
        /// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
        /// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until
        /// this method is called.
        /// </summary>
        public virtual void setDatePrecision(int yr, int mnth, int dy)
        {
            Detail.setDatePrecision(yr, mnth, dy);
        }

        /// <seealso cref="CommonTS.setDateMinutePrecision(int, int, int, int, int)">
        /// </seealso>
        /// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
        /// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until
        /// this method is called.
        /// </summary>
        public virtual void setDateMinutePrecision(int yr, int mnth, int dy, int hr, int min)
        {
            Detail.setDateMinutePrecision(yr, mnth, dy, hr, min);
        }

        /// <seealso cref="CommonTS.setDateSecondPrecision(int, int, int, int, int, float)">
        /// </seealso>
        /// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this  </throws>
        /// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until
        /// this method is called.
        /// </summary>
        public virtual void setDateSecondPrecision(int yr, int mnth, int dy, int hr, int min, float sec)
        {
            Detail.setDateSecondPrecision(yr, mnth, dy, hr, min, sec);
        }

        /// <summary>
        /// Used for setting the format of a long date (Year, Month, Day, Hour, Minute)
        /// </summary>
        protected virtual string LongDateTimeFormat
        {
            get { return "yyyyMMddHHmm"; }
        }

        /// <summary>
        /// Used for setting the format of a long date (Year, Month, Day, Hour, Minute, Second)
        /// </summary>
        protected virtual string LongDateTimeFormatWithSecond
        {
            get { return "yyyyMMddHHmmss"; }
        }

        /// <summary>
        /// Used for setting the format of a long date (Year, Month, Day, Hour, Minute, Second, Offset from GMT)
        /// </summary>
        protected virtual string LongDateTimeFormatWithOffset
        {
            get { return "yyyyMMddHHmmsszzz"; }
        }

        /// <summary>
        /// Used for setting the format of a long date (Year, Month, Day, Hour, Minute, Second, Fraction of second)
        /// </summary>
        protected virtual string LongDateTimeFormatWithFractionOfSecond
        {
            get { return "yyyyMMddHHmmss.FFFF"; }
        }

        /// <summary>
        /// Used for setting the format of a short date (Year, Month, Day)
        /// </summary>
        protected virtual string ShortDateTimeFormat
        {
            get { return "yyyyMMdd"; }
        }

        /// <summary>
        /// Get the value as a date.  Throws hl7Exception if error.
        /// </summary>
        /// <returns>Data/Time</returns>
        public virtual DateTime GetAsDate()
        {
            try
            {
                string[] dateFormats = new string[] { LongDateTimeFormat, ShortDateTimeFormat, LongDateTimeFormatWithSecond, LongDateTimeFormatWithOffset, LongDateTimeFormatWithFractionOfSecond };
                DateTime val = DateTime.MinValue;
                CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                if (Value != null && Value.Length > 0)
                {
                    val = DateTime.ParseExact(Value, dateFormats, culture, DateTimeStyles.NoCurrentDateDefault);
                }

                return val;
            }
            catch (Exception)
            {
                throw new HL7Exception("Could not get field as dateTime");
            }
        }

        /// <summary>
        /// Set the value as a short date
        /// </summary>
        /// <param name="value"></param>
        public virtual void SetShortDate(DateTime value)
        {
            Set(value, ShortDateTimeFormat);
        }

        /// <summary>
        /// Set the value as a long date
        /// </summary>
        /// <param name="value"></param>
        public virtual void SetLongDate(DateTime value)
        {
            Set(value, LongDateTimeFormat);
        }

        /// <summary>
        /// Set the value as a long date with second
        /// </summary>
        /// <param name="value"></param>
        public virtual void SetLongDateWithSecond(DateTime value)
        {
            Set(value, LongDateTimeFormatWithSecond);
        }

        /// <summary>
        /// Set the value as a long date with fraction of second
        /// </summary>
        /// <param name="value"></param>
        public virtual void SetLongDateWithFractionOfSecond(DateTime value)
        {
            Set(value, LongDateTimeFormatWithFractionOfSecond);
        }

        /// <summary>
        /// Sets the value (to the format specified) using a date.
        /// </summary>
        /// <param name="value">Valid date/time</param>
        /// <param name="format">The format to set the value (yyyyMMdd, etc)</param>
        public virtual void Set(DateTime value, string format)
        {
            try
            {
                Value = value.ToString(format);
            }
            catch (FormatException)
            {
                throw new HL7Exception("Could not format the date " + value + " to a long date.  Format must be " +
                                              LongDateTimeFormat);
            }
        }
    }
}