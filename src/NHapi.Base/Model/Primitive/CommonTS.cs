/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "CommonTS.java".  Description:


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

using System;
using System.Globalization;

using NHapi.Base.Log;

namespace NHapi.Base.Model.Primitive
{
   /// <summary>
   /// This class contains functionality used by the TS class
   /// in the version 2.3.0, 2.3.1, and 2.4 packages
   ///
   /// Note: The class description below has been excerpted from the Hl7 2.4 documentation. Sectional
   /// references made below also refer to the same documentation.
   ///
   /// Format: YYYY[MM[DD[HHMM[SS[.S[S[S[S]]]]]]]][+/-ZZZZ]^[Degree of precision]
   /// Contains the exact time of an event, including the date and time. The date portion of a time stamp follows the rules of a
   /// date field and the time portion follows the rules of a time field. The time zone (+/-ZZZZ) is represented as +/-HHMM
   /// offset from UTC (formerly Greenwich Mean Time (GMT)), where +0000 or -0000 both represent UTC (without offset).
   /// The specific data representations used in the HL7 encoding rules are compatible with ISO 8824-1987(E).
   /// In prior versions of HL7, an optional second component indicates the degree of precision of the time stamp (Y = year, L
   /// = month, D = day, H = hour, M = minute, S = second). This optional second component is retained only for purposes of
   /// backward compatibility.
   /// By site-specific agreement, YYYYMMDD[HHMM[SS[.S[S[S[S]]]]]][+/-ZZZZ]^[degree of precision] may be used
   /// where backward compatibility must be maintained.
   /// In the current and future versions of HL7, the precision is indicated by limiting the number of digits used, unless the
   /// optional second component is present. Thus, YYYY is used to specify a precision of "year," YYYYMM specifies a
   /// precision of "month," YYYYMMDD specifies a precision of "day," YYYYMMDDHH is used to specify a precision of
   /// "hour," YYYYMMDDHHMM is used to specify a precision of "minute," YYYYMMDDHHMMSS is used to specify a
   /// precision of seconds, and YYYYMMDDHHMMSS.SSSS is used to specify a precision of ten thousandths of a second.
   /// In each of these cases, the time zone is an optional component. Note that if the time zone is not included, the timezone
   /// defaults to that of the local time zone of the sender. Also note that a TS valued field with the HHMM part set to "0000"
   /// represents midnight of the night extending from the previous day to the day given by the YYYYMMDD part (see example
   /// below). Maximum length of the time stamp is 26. Examples:
   /// |19760704010159-0500|
   /// 1:01:59 on July 4, 1976 in the Eastern Standard Time zone (USA).
   /// |19760704010159-0400|
   /// 1:01:59 on July 4, 1976 in the Eastern Daylight Saving Time zone (USA).
   /// |198807050000|
   /// Midnight of the night extending from July 4 to July 5, 1988 in the local time zone of the sender.
   /// |19880705|
   /// Same as prior example, but precision extends only to the day. Could be used for a birthdate, if the time of birth is
   /// unknown.
   /// |19981004010159+0100|
   /// 1:01:59 on October 4, 1998 in Amsterdam, NL. (Time zone=+0100).
   /// The HL7 Standard strongly recommends that all systems routinely send the time zone offset but does not require it. All
   /// HL7 systems are required to accept the time zone offset, but its implementation is application specific. For many
   /// applications the time of interest is the local time of the sender. For example, an application in the Eastern Standard Time
   /// zone receiving notification of an admission that takes place at 11:00 PM in San Francisco on December 11 would prefer
   /// to treat the admission as having occurred on December 11 rather than advancing the date to December 12.
   /// Note: The time zone [+/-ZZZZ], when used, is restricted to legally-defined time zones and is represented in HHMM
   /// format.
   /// One exception to this rule would be a clinical system that processed patient data collected in a clinic and a nearby hospital
   /// that happens to be in a different time zone. Such applications may choose to convert the data to a common
   /// representation. Similar concerns apply to the transitions to and from daylight saving time. HL7 supports such requirements
   /// by requiring that the time zone information be present when the information is sent. It does not, however, specify which of
   /// the treatments discussed here will be applied by the receiving system.
   /// </summary>
   /// <author>  Neal Acharya
   /// </author>
   public class CommonTS
    {
        /// <summary> Returns the HL7 TS string value.</summary>
        /// <summary> This method takes in a string HL7 Time Stamp value and performs validations.
        /// The stored value will be in the following
        /// format YYYY[MM[DD[HHMM[SS[.S[S[S[S]]]]]]]][+/-ZZZZ].
        /// Note: Trailing zeros supplied in the time value (HHMM[SS[.S[S[S[S]]]]]])
        /// and GMT offset ([+/-ZZZZ]) will be preserved.
        /// Note: If the GMT offset is not supplied then the local
        /// time zone (using standard time zone format which is not modified for daylight savings)
        /// will be stored as a default.
        /// </summary>
        public virtual String Value
        {
            get
            {
                String value_Renamed = null;
                if (dt != null)
                {
                    value_Renamed = dt.Value;
                } //end if

                if (tm != null && value_Renamed != null && !value_Renamed.Equals(""))
                {
                    if (tm.Value != null && !tm.Value.Equals(""))
                    {
                        //here we know we have a delete value or separate date and the time values supplied
                        if (tm.Value.Equals("\"\"") && dt.Value.Equals("\"\""))
                        {
                            //set value to the delete value ("")
                            value_Renamed = "\"\"";
                        }
                        else
                        {
                            //set value to date concatonated with time value
                            value_Renamed = value_Renamed + tm.Value;
                        }
                    } //end if

                    if (tm.Value == null || tm.Value.Equals(""))
                    {
                        //here we know we both have the date and just the time offset value
                        //change the offset value from an integer to a signed string
                        int offset = tm.GMTOffset;
                        String offsetStr = "";
                        if (offset > -99)
                        {
                            offsetStr = DataTypeUtil.preAppendZeroes(Math.Abs(offset), 4);
                            if (tm.GMTOffset >= 0)
                            {
                                offsetStr = "+" + offsetStr;
                            }

                            //end if
                            else
                            {
                                offsetStr = "-" + offsetStr;
                            } //end else
                        }

                        value_Renamed = value_Renamed + offsetStr;
                    } //end if
                } //end if

                return value_Renamed;
            }


            set
            {
                if (value != null && !value.Equals("") && !value.Equals("\"\""))
                {
                    try
                    {
                        //check the length of the input value, ensure that it is no less than
                        //8 characters in length
                        if (value.Length < 4)
                        {
                            String msg = "The length of the TS datatype value must be at least 4 characters in length.";
                            DataTypeException e = new DataTypeException(msg);
                            throw e;
                        }

                        //check the length of the input value, ensure that it is not greater
                        //than 24 characters in length
                        if (value.Length > 24)
                        {
                            String msg = "The length of the TS datatype value must not be more than 24 characters in length.";
                            DataTypeException e = new DataTypeException(msg);
                            throw e;
                        }

                        //at this point we know that we have a value that should conform to the DT
                        //datatype and possibly a value that should conform to the TM datatype
                        String dateVal = null;
                        String timeVal = null;
                        String timeValLessOffset = null;
                        int sp = value.IndexOf("+");
                        int sm = value.IndexOf("-");
                        int indexOfSign = -1;
                        bool offsetExists = false;
                        bool timeValIsOffsetOnly = false;
                        if ((sp != -1) || (sm != -1))
                        {
                            offsetExists = true;
                        }

                        if (sp != -1)
                            indexOfSign = sp;
                        if (sm != -1)
                            indexOfSign = sm;

                        if (offsetExists == false)
                        {
                            if (value.Length <= 8)
                            {
                                dateVal = value;
                            }
                            else
                            {
                                //here we know that a time value is present
                                dateVal = value.Substring(0, (8) - (0));
                                timeVal = value.Substring(8);
                                timeValLessOffset = timeVal;
                            }
                        } //offset not exist

                        if (offsetExists == true)
                        {
                            if (indexOfSign > 8)
                            {
                                dateVal = value.Substring(0, (8) - (0));
                                timeVal = value.Substring(8);
                                timeValLessOffset = value.Substring(8, (indexOfSign) - (8));
                            }
                            else
                            {
                                //we know that the time val is simply the offset
                                dateVal = value.Substring(0, (indexOfSign) - (0));
                                timeVal = value.Substring(indexOfSign);
                                timeValIsOffsetOnly = true;
                            }
                        } //offset exists

                        //create date object
                        dt = new CommonDT();
                        //set the value of the date object to the input date value
                        dt.Value = dateVal;
                        //if the offset does not exist and a timvalue does not exist then
                        //we must provide a default offset = to the local time zone
                        if (timeVal == null && offsetExists == false)
                        {
                            int defaultOffset = DataTypeUtil.LocalGMTOffset;
                            tm = new CommonTM();
                            tm.Offset = defaultOffset;
                        } //end if

                        //if we have a time value then make a new time object and set it to the
                        //input time value (as long as the time val has time + offset or just time only)
                        if (timeVal != null && timeValIsOffsetOnly == false)
                        {
                            //must make sure that the time component contains both hours and minutes
                            //at the very least -- must be at least 4chars in length.
                            if (timeValLessOffset.Length < 4)
                            {
                                String msg = "The length of the time component for the TM datatype" +
                                                 " value does not conform to the allowable format" +
                                                 " YYYY[MM[DD[HHMM[SS[.S[S[S[S]]]]]]]][+/-ZZZZ].";
                                DataTypeException e = new DataTypeException(msg);
                                throw e;
                            } //end if

                            tm = new CommonTM();
                            tm.Value = timeVal;
                        } //end if

                        //if we have a time value and it only has the offset then make a new
                        //time object and set the offset value to the input value
                        if (timeVal != null && timeValIsOffsetOnly == true)
                        {
                            //we know that the time value is just the offset so we
                            //must check to see if it is the right length before setting the
                            //offset field in the tm object
                            if (timeVal.Length != 5)
                            {
                                String msg = "The length of the GMT offset for the TM datatype value does" +
                                                 " not conform to the allowable format [+/-ZZZZ]";
                                DataTypeException e = new DataTypeException(msg);
                                throw e;
                            } //end if

                            tm = new CommonTM();
                            //first extract the + sign from the offset value string if it exists
                            if (timeVal.IndexOf("+") == 0)
                            {
                                timeVal = timeVal.Substring(1);
                            } //end if

                            int signedOffset = Int32.Parse(timeVal);
                            tm.Offset = signedOffset;
                        } //end if
                    }

                    //end try
                    catch (DataTypeException e)
                    {
                        throw e;
                    }

                    //end catch
                    catch (Exception e)
                    {
                        throw new DataTypeException("An unexpected exception ocurred", e);
                    } //end catch
                }

                //end if
                else
                {
                    //set the private value field to null or empty space.
                    if (value == null)
                    {
                        dt = null;
                        tm = null;
                    } //end if

                    if (value != null && value.Equals(""))
                    {
                        dt = new CommonDT();
                        dt.Value = "";
                        tm = new CommonTM();
                        tm.Value = "";
                    } //end if

                    if (value != null && value.Equals("\"\""))
                    {
                        dt = new CommonDT();
                        dt.Value = "\"\"";
                        tm = new CommonTM();
                        tm.Value = "\"\"";
                    } //end if
                } //end else
            }

            // end method
        }

        /// <summary> This method takes in the four digit (signed) GMT offset and sets the offset
        /// field
        /// </summary>
        public virtual int Offset
        {
            set
            {
                try
                {
                    //create new time object is there isn't one
                    if (tm == null)
                    {
                        tm = new CommonTM();
                    }

                    //set the offset value of the time object to the input value
                    tm.Offset = value;
                }
                catch (DataTypeException e)
                {
                    throw e;
                }

                //end catch
                catch (Exception e)
                {
                    throw new DataTypeException("An unexpected exception ocurred", e);
                } //end catch
            }
        }

        /// <summary> Returns the year as an integer.</summary>
        public virtual int Year
        {
            get
            {
                int year = 0;
                if (dt != null)
                {
                    year = dt.Year;
                } //end if

                return year;
            }
        }

        /// <summary> Returns the month as an integer.</summary>
        public virtual int Month
        {
            get
            {
                int month = 0;
                if (dt != null)
                {
                    month = dt.Month;
                } //end if

                return month;
            }
        }

        /// <summary> Returns the day as an integer.</summary>
        public virtual int Day
        {
            get
            {
                int day = 0;
                if (dt != null)
                {
                    day = dt.Day;
                } //end if

                return day;
            }
        }

        /// <summary> Returns the hour as an integer.</summary>
        public virtual int Hour
        {
            get
            {
                int hour = 0;
                if (tm != null)
                {
                    hour = tm.Hour;
                } //end if

                return hour;
            }
        }

        /// <summary> Returns the minute as an integer.</summary>
        public virtual int Minute
        {
            get
            {
                int minute = 0;
                if (tm != null)
                {
                    minute = tm.Minute;
                } //end if

                return minute;
            }
        }

        /// <summary> Returns the second as an integer.</summary>
        public virtual int Second
        {
            get
            {
                int seconds = 0;
                if (tm != null)
                {
                    seconds = tm.Second;
                } //end if

                return seconds;
            }
        }

        /// <summary> Returns the fractional second value as a float.</summary>
        public virtual float FractSecond
        {
            get
            {
                float fractionOfSec = 0;
                if (tm != null)
                {
                    fractionOfSec = tm.FractSecond;
                } //end if

                return fractionOfSec;
            }
        }

        /// <summary> Returns the GMT offset value as an integer.</summary>
        public virtual int GMTOffset
        {
            get
            {
                int offSet = 0;
                if (tm != null)
                {
                    offSet = tm.GMTOffset;
                } //end if

                return offSet;
            }
        }

        private static readonly IHapiLog log;

        private CommonDT dt;
        private CommonTM tm;

        /// <summary>Creates new ValidTS
        /// zero argument constructor.
        /// Creates an uninitailized TS datatype
        /// </summary>
        public CommonTS()
        {
        } //zero arg constructor

        /// <summary> Constructs a TS object with the given value.
        /// The stored value will be in the following
        /// format YYYY[MM[DD[HHMM[SS[.S[S[S[S]]]]]]]][+/-ZZZZ]
        /// </summary>
        public CommonTS(String val)
        {
            Value = val;
        } //end constructor

        /// <summary> This method takes in integer values for the year and month and day
        /// and performs validations, it then sets the value in the object
        /// formatted as an HL7 Time Stamp value with year and month and day precision (YYYYMMDD).
        ///
        /// </summary>
        public virtual void setDatePrecision(int yr, int mnth, int dy)
        {
            try
            {
                //create date object if there isn't one
                if (dt == null)
                {
                    dt = new CommonDT();
                }

                //set the value of the date object to the input date value
                dt.setYearMonthDayPrecision(yr, mnth, dy);
                //clear the time value object
                tm = null;
            }

            //end try
            catch (DataTypeException e)
            {
                throw e;
            }

            //end catch
            catch (Exception e)
            {
                throw new DataTypeException("An unexpected exception ocurred", e);
            } //end catch
        }

        /// <summary> This method takes in integer values for the year, month, day, hour
        /// and minute and performs validations, it then sets the value in the object
        /// formatted as an HL7 Time Stamp value with year and month and day and hour and minute precision (YYYYMMDDHHMM).
        /// </summary>
        public virtual void setDateMinutePrecision(int yr, int mnth, int dy, int hr, int min)
        {
            try
            {
                //set the value of the date object to the input date value
                setDatePrecision(yr, mnth, dy);
                //create new time object is there isn't one
                if (tm == null)
                {
                    tm = new CommonTM();
                }

                //set the value of the time object to the minute precision with the input values
                tm.setHourMinutePrecision(hr, min);
            }

            //end try
            catch (DataTypeException e)
            {
                throw e;
            }

            //end catch
            catch (Exception e)
            {
                throw new DataTypeException("An unexpected exception ocurred", e);
            } //end catch
        }

        /// <summary> This method takes in integer values for the year, month, day, hour, minute, seconds,
        /// and fractional seconds (going to the tenthousandths precision).
        /// The method performs validations and then sets the value in the object formatted as an
        /// HL7 time value with a precision that starts from the year and goes down to the tenthousandths
        /// of a second (YYYYMMDDHHMMSS.SSSS).
        /// The Gmt Offset will not be effected.
        /// Note: all of the precisions from tenths down to
        /// tenthousandths of a second are optional. If the precision goes below tenthousandths
        /// of a second then the second value will be rounded to the nearest tenthousandths of a second.
        /// </summary>
        public virtual void setDateSecondPrecision(int yr, int mnth, int dy, int hr, int min, float sec)
        {
            try
            {
                //set the value of the date object to the input date value
                setDatePrecision(yr, mnth, dy);
                //create new time object is there isn't one
                if (tm == null)
                {
                    tm = new CommonTM();
                }

                //set the value of the time object to the second precision with the input values
                tm.setHourMinSecondPrecision(hr, min, sec);
            }

            //end try
            catch (DataTypeException e)
            {
                throw e;
            }

            //end catch
            catch (Exception e)
            {
                throw new DataTypeException("An unexpected exception ocurred", e);
            } //end catch
        }

        /// <summary> Returns a string value representing the input Gregorian Calendar object in
        /// an Hl7 TimeStamp Format.
        /// </summary>
        public static String toHl7TSFormat(GregorianCalendar cal)
        {
            String val = "";
            try
            {
                //set the input cal object so that it can report errors
                //on it's value
                int calYear = SupportClass.CalendarManager.manager.Get(cal, SupportClass.CalendarManager.YEAR);
                int calMonth = SupportClass.CalendarManager.manager.Get(cal, SupportClass.CalendarManager.MONTH) + 1;
                int calDay = SupportClass.CalendarManager.manager.Get(cal, SupportClass.CalendarManager.DAY_OF_MONTH);
                int calHour = SupportClass.CalendarManager.manager.Get(cal, SupportClass.CalendarManager.HOUR_OF_DAY);
                int calMin = SupportClass.CalendarManager.manager.Get(cal, SupportClass.CalendarManager.MINUTE);
                int calSec = SupportClass.CalendarManager.manager.Get(cal, SupportClass.CalendarManager.SECOND);
                int calMilli = SupportClass.CalendarManager.manager.Get(cal, SupportClass.CalendarManager.MILLISECOND);
                //the inputs seconds and milli seconds should be combined into a float type
                float fractSec = calMilli / 1000F;
                float calSecFloat = calSec + fractSec;
                int calOffset = SupportClass.CalendarManager.manager.Get(cal, SupportClass.CalendarManager.ZONE_OFFSET);
                //Note the input's Offset value is in milliseconds, we must convert it to
                //a 4 digit integer in the HL7 Offset format.
                int offSetSignInt;
                if (calOffset < 0)
                {
                    offSetSignInt = -1;
                }
                else
                {
                    offSetSignInt = 1;
                }

                //get the absolute value of the gmtOffSet
                int absGmtOffSet = Math.Abs(calOffset);
                int gmtOffSetHours = absGmtOffSet / (3600 * 1000);
                int gmtOffSetMin = (absGmtOffSet / 60000) % (60);
                //reset calOffset
                calOffset = ((gmtOffSetHours * 100) + gmtOffSetMin) * offSetSignInt;
                //Create an object of the TS class and populate it with the above values
                //then return the HL7 string value from the object
                CommonTS ts = new CommonTS();
                ts.setDateSecondPrecision(calYear, calMonth, calDay, calHour, calMin, calSecFloat);
                ts.Offset = calOffset;
                val = ts.Value;
            }

            // end try
            catch (DataTypeException e)
            {
                throw e;
            }

            //end catch
            catch (Exception e)
            {
                throw new DataTypeException("An unexpected exception ocurred", e);
            } //end catch

            return val;
        }

        static CommonTS()
        {
            log = HapiLogFactory.GetHapiLog(typeof(CommonTS));
        }
    } //end class
}