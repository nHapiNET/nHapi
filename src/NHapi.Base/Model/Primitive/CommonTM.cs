/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "CommmonTM.java".  Description:
  "Note: The class description below has been excerpted from the Hl7 2.4 documentation"

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

namespace NHapi.Base.Model.Primitive
{
    using System;
    using System.Globalization;

    using NHapi.Base.Log;

    /// <summary>
    /// This class contains functionality used by the TM class
    /// in the version 2.3.0, 2.3.1, and 2.4 packages
    ///
    /// Note: The class description below has been excerpted from the Hl7 2.4 documentation. Sectional
    /// references made below also refer to the same documentation.
    ///
    /// Format: HH[MM[SS[.S[S[S[S]]]]]][+/-ZZZZ]
    /// In prior versions of HL7, this data type was always specified to be in the
    /// format HHMM[SS[.SSSS]][+/-ZZZZ] using a 24 hour clock notation. In the
    /// current and future versions, the precision of a time may be expressed by
    /// limiting the number of digits used with the format specification as shown
    /// above. By site-specific agreement, HHMM[SS[.SSSS]][+/-ZZZZ] may be used where
    /// backward compatibility must be maintained.
    /// Thus, HH is used to specify a precision of "hour," HHMM is used to specify a
    /// precision of "minute," HHMMSS is used to specify a precision of seconds, and
    /// HHMMSS.SSSS is used to specify a precision of ten-thousandths of a second.
    /// In each of these cases, the time zone is an optional component. The fractional
    /// seconds could be sent by a transmitter who requires greater precision than whole
    /// seconds. Fractional representations of minutes, hours or other higher-order units
    /// of time are not permitted.
    /// Note: The time zone [+/-ZZZZ], when used, is restricted to legally-defined time zones
    /// and is represented in HHMM format.
    /// The time zone of the sender may be sent optionally as an offset from the coordinated
    /// universal time (previously known as Greenwich Mean Time). Where the time zone
    /// is not present in a particular TM field but is included as part of the date/time
    /// field in the MSH segment, the MSH value will be used as the default time zone.
    /// Otherwise, the time is understood to refer to the local time of the sender.
    /// Midnight is represented as 0000.
    /// Examples:|235959+1100| 1 second before midnight in a time zone eleven hours
    /// ahead of Universal Coordinated Time (i.e., east of Greenwich).
    /// |0800| Eight AM, local time of the sender.
    /// |093544.2312| 44.2312 seconds after Nine thirty-five AM, local time of sender.
    /// |13| 1pm (with a precision of hours), local time of sender.
    /// </summary>
    /// <author>Neal Acharya.</author>
    public class CommonTM
    {
        private static readonly IHapiLog Log;

        private string valueRenamed;
        private char omitOffsetFg = 'n';

        static CommonTM()
        {
            Log = HapiLogFactory.GetHapiLog(typeof(CommonTM));
        }

        /// <summary>
        /// Constructs a TM datatype with fields initialized to zero and the value set to null.
        /// </summary>
        public CommonTM()
        {
            // initialize all DT fields
            valueRenamed = null;
            Hour = 0;
            Minute = 0;
            Second = 0;
            FractSecond = 0;
            GMTOffset = -99;
        }

        /// <summary>
        /// Constructs a TM object with the given value.
        /// The stored value will be in the following
        /// format HH[MM[SS[.S[S[S[S]]]]]][+/-ZZZZ].
        /// </summary>
        public CommonTM(string val)
        {
            Value = val;
        }

        /// <summary> Returns the HL7 TM string value.</summary>
        /// <summary> This method takes in a string HL7 Time value and performs validations
        /// then sets the value field.  The stored value will be in the following
        /// format HH[MM[SS[.S[S[S[S]]]]]][+/-ZZZZ].
        /// Note: Trailing zeros supplied in the time value (HH[MM[SS[.S[S[S[S]]]]]])
        /// and GMT offset ([+/-ZZZZ]) will be preserved.
        /// Note: If the GMT offset is not supplied then the local
        /// time zone (using standard time zone format which is not modified for daylight savings)
        /// will be stored as a default.
        /// </summary>
        public virtual string Value
        {
            get
            {
                // combine the value field with the offSet field and return it
                string returnVal = null;
                if (valueRenamed != null && !valueRenamed.Equals(string.Empty))
                {
                    if (omitOffsetFg == 'n' && !valueRenamed.Equals("\"\""))
                    {
                        var absOffset = Math.Abs(GMTOffset);
                        var sign = string.Empty;
                        if (GMTOffset >= 0)
                        {
                            sign = "+";
                        }
                        else
                        {
                            sign = "-";
                        }

                        returnVal = valueRenamed + sign + DataTypeUtil.PreAppendZeroes(absOffset, 4);
                    }
                    else
                    {
                        returnVal = valueRenamed;
                    }
                }

                return returnVal;
            }

            set
            {
                if (value != null && !value.Equals(string.Empty) && !value.Equals("\"\""))
                {
                    // check to see if any of the following characters exist: "." or "+/-"
                    // this will help us determine the acceptable lengths
                    var d = value.IndexOf(".");
                    var sp = value.IndexOf("+");
                    var sm = value.IndexOf("-");
                    var indexOfSign = -1;
                    var offsetExists = false;
                    if ((sp != -1) || (sm != -1))
                    {
                        offsetExists = true;
                    }

                    if (sp != -1)
                    {
                        indexOfSign = sp;
                    }

                    if (sm != -1)
                    {
                        indexOfSign = sm;
                    }

                    try
                    {
                        // If the GMT offset exists then extract it from the input string and store it
                        // in another variable called tempOffset. Also, store the time value
                        // (without the offset)in a separate variable called timeVal.
                        // If there is no GMT offset then simply set timeVal to val.
                        var timeVal = value;
                        string tempOffset = null;
                        if (offsetExists)
                        {
                            timeVal = value.Substring(0, indexOfSign - 0);
                            tempOffset = value.Substring(indexOfSign);
                        }

                        if (offsetExists && (tempOffset.Length != 5))
                        {
                            // The length of the GMT offset must be 5 characters (including the sign)
                            var msg = "The length of the TM datatype value does not conform to an allowable" +
                                             " format. Format should conform to HH[MM[SS[.S[S[S[S]]]]]][+/-ZZZZ]";
                            var e = new DataTypeException(msg);
                            throw e;
                        }

                        if (d != -1)
                        {
                            // here we know that decimal exists
                            // thus length of the time value can be between 8 and 11 characters
                            if ((timeVal.Length < 8) || (timeVal.Length > 11))
                            {
                                var msg = "The length of the TM datatype value does not conform to an allowable" +
                                                 " format. Format should conform to HH[MM[SS[.S[S[S[S]]]]]][+/-ZZZZ]";
                                var e = new DataTypeException(msg);
                                throw e;
                            }
                        }

                        if (d == -1)
                        {
                            // here we know that the decimal does not exist
                            // thus length of the time value can be 2 or 4 or 6 characters
                            if ((timeVal.Length != 2) && (timeVal.Length != 4) && (timeVal.Length != 6))
                            {
                                var msg = "The length of the TM datatype value does not conform to an allowable" +
                                                 " format. Format should conform to HH[MM[SS[.S[S[S[S]]]]]][+/-ZZZZ]";
                                var e = new DataTypeException(msg);
                                throw e;
                            }
                        }

                        // We will now try to validate the timeVal portion of the TM datatype value
                        if (timeVal.Length >= 2)
                        {
                            // extract the hour data from the input value.  If the first 2 characters
                            // are not numeric then a number format exception will be generated
                            var hrInt = int.Parse(timeVal.Substring(0, 2 - 0));

                            // check to see if the hour value is valid
                            if ((hrInt < 0) || (hrInt > 23))
                            {
                                var msg = "The hour value of the TM datatype must be >=0 and <=23";
                                var e = new DataTypeException(msg);
                                throw e;
                            }

                            Hour = hrInt;
                        }

                        if (timeVal.Length >= 4)
                        {
                            // extract the minute data from the input value
                            // If these characters are not numeric then a number
                            // format exception will be generated
                            var minInt = int.Parse(timeVal.Substring(2, 4 - 2));

                            // check to see if the minute value is valid
                            if ((minInt < 0) || (minInt > 59))
                            {
                                var msg = "The minute value of the TM datatype must be >=0 and <=59";
                                var e = new DataTypeException(msg);
                                throw e;
                            }

                            Minute = minInt;
                        }

                        if (timeVal.Length >= 6)
                        {
                            // extract the seconds data from the input value
                            // If these characters are not numeric then a number
                            // format exception will be generated
                            var secInt = int.Parse(timeVal.Substring(4, 6 - 4));

                            // check to see if the seconds value is valid
                            if ((secInt < 0) || (secInt > 59))
                            {
                                var msg = "The seconds value of the TM datatype must be >=0 and <=59";
                                var e = new DataTypeException(msg);
                                throw e;
                            }

                            Second = secInt;
                        }

                        if (timeVal.Length >= 8)
                        {
                            // extract the fractional second value from the input value
                            // If these characters are not numeric then a number
                            // format exception will be generated
                            var fract = float.Parse(timeVal.Substring(6), CultureInfo.InvariantCulture);

                            // check to see if the fractional second value is valid
                            if ((fract < 0) || (fract >= 1))
                            {
                                var msg = "The fractional second value of the TM datatype must be >= 0 and < 1";
                                var e = new DataTypeException(msg);
                                throw e;
                            }

                            FractSecond = fract;
                        }

                        // We will now try to validate the tempOffset portion of the TM datatype value
                        if (offsetExists)
                        {
                            // in case the offset are a series of zeros we should not omit displaying
                            // it in the return value from the getValue() method
                            omitOffsetFg = 'n';

                            // remove the sign from the temp offset
                            var tempOffsetNoS = tempOffset.Substring(1);

                            // extract the hour data from the offset value.  If the first 2 characters
                            // are not numeric then a number format exception will be generated
                            var offsetInt = int.Parse(tempOffsetNoS.Substring(0, 2 - 0));

                            // check to see if the hour value is valid
                            if ((offsetInt < 0) || (offsetInt > 23))
                            {
                                var msg = "The GMT offset hour value of the TM datatype must be >=0 and <=23";
                                var e = new DataTypeException(msg);
                                throw e;
                            }

                            // extract the minute data from the offset value.  If these characters
                            // are not numeric then a number format exception will be generated
                            offsetInt = int.Parse(tempOffsetNoS.Substring(2, 4 - 2));

                            // check to see if the minute value is valid
                            if ((offsetInt < 0) || (offsetInt > 59))
                            {
                                var msg = "The GMT offset minute value of the TM datatype must be >=0 and <=59";
                                var e = new DataTypeException(msg);
                                throw e;
                            }

                            // validation done, update the offSet field
                            GMTOffset = int.Parse(tempOffsetNoS);

                            // add the sign back to the offset if it is negative
                            if (sm != -1)
                            {
                                GMTOffset = (-1) * GMTOffset;
                            }
                        }

                        // If the GMT offset has not been supplied then set the offset to the
                        // local timezone
                        // [Bryan: changing this to omit time zone because erroneous if parser in different zone than sender]
                        if (!offsetExists)
                        {
                            omitOffsetFg = 'y';
                        }

                        // validations are now done store the time value into the private value field
                        valueRenamed = timeVal;
                    }
                    catch (DataTypeException e)
                    {
                        // TODO: this will remove the stack trace - is that correct?
                        throw e;
                    }
                    catch (Exception e)
                    {
                        throw new DataTypeException("An unexpected exception occurred", e);
                    }
                }
                else
                {
                    // set the private value field to null or empty space.
                    valueRenamed = value;
                }
            }
        }

        /// <summary>
        /// This method takes in an integer value for the hour and performs validations,
        /// it then sets the value field formatted as an HL7 time
        /// value with hour precision (HH).
        /// </summary>
        public virtual int HourPrecision
        {
            set
            {
                try
                {
                    // validate input value
                    if ((value < 0) || (value > 23))
                    {
                        var msg = "The hour value of the TM datatype must be >=0 and <=23";
                        var e = new DataTypeException(msg);
                        throw e;
                    }

                    Hour = value;
                    Minute = 0;
                    Second = 0;
                    FractSecond = 0;
                    GMTOffset = 0;

                    // Here the offset is not defined, we should omit showing it in the
                    // return value from the getValue() method
                    omitOffsetFg = 'y';
                    valueRenamed = DataTypeUtil.PreAppendZeroes(value, 2);
                }
                catch (DataTypeException e)
                {
                    // TODO: this will remove the stack trace - is that correct?
                    throw e;
                }
                catch (Exception e)
                {
                    throw new DataTypeException(e.Message);
                }
            }
        }

        /// <summary>
        /// This method takes in the four digit (signed) GMT offset and sets the offset field.
        /// </summary>
        public virtual int Offset
        {
            set
            {
                try
                {
                    // When this function is called an offset is being created/updated
                    // we should not omit displaying it in the return value from
                    // the getValue() method
                    omitOffsetFg = 'n';
                    var offsetStr = Convert.ToString(value);
                    if ((value >= 0 && offsetStr.Length > 4) || (value < 0 && offsetStr.Length > 5))
                    {
                        // The length of the GMT offset must be no greater than 5 characters (including the sign)
                        var msg = "The length of the GMT offset for the TM datatype value does" +
                                         " not conform to the allowable format [+/-ZZZZ]. Value: " + value;
                        var e = new DataTypeException(msg);
                        throw e;
                    }

                    // obtain the absolute value of the input
                    var absOffset = Math.Abs(value);

                    // extract the hour data from the offset value.
                    // first pre-append zeros so we have a 4 char offset value (without sign)
                    offsetStr = DataTypeUtil.PreAppendZeroes(absOffset, 4);
                    var hrOffsetInt = int.Parse(offsetStr.Substring(0, 2 - 0));

                    // check to see if the hour value is valid
                    if ((hrOffsetInt < 0) || (hrOffsetInt > 23))
                    {
                        var msg = "The GMT offset hour value of the TM datatype must be >=0 and <=23";
                        var e = new DataTypeException(msg);
                        throw e;
                    }

                    // extract the minute data from the offset value.
                    var minOffsetInt = int.Parse(offsetStr.Substring(2, 4 - 2));

                    // check to see if the minute value is valid
                    if ((minOffsetInt < 0) || (minOffsetInt > 59))
                    {
                        var msg = "The GMT offset minute value of the TM datatype must be >=0 and <=59";
                        var e = new DataTypeException(msg);
                        throw e;
                    }

                    // The input value is valid, now store it in the offset field
                    GMTOffset = value;
                }
                catch (DataTypeException e)
                {
                    // TODO: this will remove the stack trace - is that correct?
                    throw e;
                }
                catch (Exception e)
                {
                    throw new DataTypeException("An unexpected exception occurred", e);
                }
            }
        }

        /// <summary>
        /// Returns the hour as an integer.
        /// </summary>
        public virtual int Hour { get; private set; }

        /// <summary>
        /// Returns the minute as an integer.
        /// </summary>
        public virtual int Minute { get; private set; }

        /// <summary>
        /// Returns the second as an integer.
        /// </summary>
        public virtual int Second { get; private set; }

        /// <summary>
        /// Returns the fractional second value as a float.
        /// </summary>
        public virtual float FractSecond { get; private set; }

        /// <summary>
        /// Returns the GMT offset value as an integer, -99 if not set.
        /// </summary>
        public virtual int GMTOffset { get; private set; }

        [Obsolete("This method has been replaced by 'ToHl7TMFormat'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public static string toHl7TMFormat(GregorianCalendar cal)
        {
            return ToHl7TMFormat(cal);
        }

        /// <summary>
        /// Returns a string value representing the input Gregorian Calendar object in
        /// an Hl7 Time Format.
        /// </summary>
        public static string ToHl7TMFormat(GregorianCalendar cal)
        {
            var val = string.Empty;
            try
            {
                // set the input cal object so that it can report errors
                // on it's value
                var calHour = SupportClass.CalendarManager.manager.Get(cal, SupportClass.CalendarManager.HOUR_OF_DAY);
                var calMin = SupportClass.CalendarManager.manager.Get(cal, SupportClass.CalendarManager.MINUTE);
                var calSec = SupportClass.CalendarManager.manager.Get(cal, SupportClass.CalendarManager.SECOND);
                var calMilli = SupportClass.CalendarManager.manager.Get(cal, SupportClass.CalendarManager.MILLISECOND);

                // the inputs seconds and milliseconds should be combined into a float type
                var fractSec = calMilli / 1000F;
                var calSecFloat = calSec + fractSec;
                var calOffset = SupportClass.CalendarManager.manager.Get(cal, SupportClass.CalendarManager.ZONE_OFFSET) +
                                     SupportClass.CalendarManager.manager.Get(cal, SupportClass.CalendarManager.DST_OFFSET);

                // Note the input's Offset value is in milliseconds, we must convert it to
                // a 4 digit integer in the HL7 Offset format.
                int offSetSignInt;
                if (calOffset < 0)
                {
                    offSetSignInt = -1;
                }
                else
                {
                    offSetSignInt = 1;
                }

                // get the absolute value of the gmtOffSet
                var absGmtOffSet = Math.Abs(calOffset);
                var gmtOffSetHours = absGmtOffSet / (3600 * 1000);
                var gmtOffSetMin = (absGmtOffSet / 60000) % 60;

                // reset calOffset
                calOffset = ((gmtOffSetHours * 100) + gmtOffSetMin) * offSetSignInt;

                // Create an object of the TS class and populate it with the above values
                // then return the HL7 string value from the object
                var tm = new CommonTM();
                tm.SetHourMinSecondPrecision(calHour, calMin, calSecFloat);
                tm.Offset = calOffset;
                val = tm.Value;
            }
            catch (DataTypeException e)
            {
                // TODO: this will remove the stack trace - is that correct?
                throw e;
            }
            catch (Exception e)
            {
                throw new DataTypeException("An unexpected exception occurred", e);
            }

            return val;
        }

        [Obsolete("This method has been replaced by 'SetHourMinutePrecision'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual void setHourMinutePrecision(int hr, int min)
        {
            SetHourMinutePrecision(hr, min);
        }

        /// <summary>
        /// This method takes in integer values for the hour and minute and performs validations,
        /// it then sets the value field formatted as an HL7 time value
        /// with hour and minute precision (HHMM).
        /// </summary>
        public virtual void SetHourMinutePrecision(int hr, int min)
        {
            try
            {
                HourPrecision = hr;

                // validate input minute value
                if ((min < 0) || (min > 59))
                {
                    var msg = "The minute value of the TM datatype must be >=0 and <=59";
                    var e = new DataTypeException(msg);
                    throw e;
                }

                Minute = min;
                Second = 0;
                FractSecond = 0;
                GMTOffset = 0;

                // Here the offset is not defined, we should omit showing it in the
                // return value from the getValue() method
                omitOffsetFg = 'y';
                valueRenamed = valueRenamed + DataTypeUtil.PreAppendZeroes(min, 2);
            }
            catch (DataTypeException e)
            {
                // TODO: this will remove the stack trace - is that correct?
                throw e;
            }
            catch (Exception e)
            {
                throw new DataTypeException(e.Message);
            }
        }

        [Obsolete("This method has been replaced by 'SetHourMinSecondPrecision'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual void setHourMinSecondPrecision(int hr, int min, float sec)
        {
            SetHourMinSecondPrecision(hr, min, sec);
        }

        /// <summary>
        /// This method takes in integer values for the hour, minute, seconds, and fractional seconds
        /// (going to the ten thousandths precision).
        /// The method performs validations and then sets the value field formatted as an
        /// HL7 time value with a precision that starts from the hour and goes down to the ten thousandths
        /// of a second (HHMMSS.SSSS).
        /// Note: all of the precisions from tenths down to ten thousandths of a
        /// second are optional. If the precision goes below ten thousandths of a second then the second
        /// value will be rounded to the nearest ten thousandths of a second.
        /// </summary>
        public virtual void SetHourMinSecondPrecision(int hr, int min, float sec)
        {
            try
            {
                SetHourMinutePrecision(hr, min);

                // multiply the seconds input value by 10000 and round the result
                // then divide the number by ten thousand and store it back.
                // This will round the fractional seconds to the nearest ten thousandths
                var secMultRound = (int)Math.Round((double)(10000F * sec));
                sec = secMultRound / 10000F;

                // Now store the second and fractional component
                Second = (int)Math.Floor(sec);

                // validate input seconds value
                if ((Second < 0) || (Second >= 60))
                {
                    var msg = "The (rounded) second value of the TM datatype must be >=0 and <60";
                    var e = new DataTypeException(msg);
                    throw e;
                }

                var fractionOfSecInt = (int)(secMultRound - (Second * 10000));
                FractSecond = fractionOfSecInt / 10000F;
                var fractString = string.Empty;

                // Now convert the fractionOfSec field to a string without the leading zero
                if (FractSecond != 0.0F)
                {
                    fractString = FractSecond.ToString().Substring(1);
                }

                // Now update the value field
                GMTOffset = 0;

                // Here the offset is not defined, we should omit showing it in the
                // return value from the getValue() method
                omitOffsetFg = 'y';
                valueRenamed = valueRenamed + DataTypeUtil.PreAppendZeroes(Second, 2) + fractString;
            }
            catch (DataTypeException e)
            {
                // TODO: this will remove the stack trace - is that correct?
                throw e;
            }
            catch (Exception e)
            {
                throw new DataTypeException("An unexpected exception occurred", e);
            }
        }
    }
}