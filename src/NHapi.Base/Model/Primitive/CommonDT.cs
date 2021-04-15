/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "CommonDT.java".  Description:
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
    /// This class contains functionality used by the DT class
    /// in the version 2.3.0, 2.3.1, and 2.4 packages
    ///
    /// Note: The class description below has been excerpted from the Hl7 2.4 documentation. Sectional
    /// references made below also refer to the same documentation.
    ///
    /// Format: YYYY[MM[DD]]
    /// In prior versions of HL7, this data type was always specified to be in the format YYYYMMDD. In the current and future
    /// versions, the precision of a date may be expressed by limiting the number of digits used with the format specification
    /// YYYY[MM[DD]]. Thus, YYYY is used to specify a precision of "year," YYYYMM specifies a precision of "month,"
    /// and YYYYMMDD specifies a precision of "day."
    /// By site-specific agreement, YYYYMMDD may be used where backward compatibility must be maintained.
    /// Examples:   |19880704|  |199503|.
    /// </summary>
    /// <author>Neal Acharya.</author>
    public class CommonDT
    {
        private static readonly IHapiLog Log;

        private string valueRenamed;

        static CommonDT()
        {
            Log = HapiLogFactory.GetHapiLog(typeof(CommonDT));
        }

        /// <summary>
        /// Constructs a DT datatype with fields initialized to zero and value initialized to null.
        /// </summary>
        public CommonDT()
        {
            // initialize all DT fields
            valueRenamed = null;
            Year = 0;
            Month = 0;
            Day = 0;
        }

        /// <summary>
        /// Constructs a DT object with the given value.
        /// The stored value will be in the following
        /// format YYYY[MM[DD]].
        /// </summary>
        public CommonDT(string val)
        {
            Value = val;
        }

        /// <summary>
        /// Gets or sets the HL7 DT string value.
        /// </summary>
        /// <remarks>
        /// This method takes in a string HL7 date value and performs validations
        /// then sets the value field. The stored value will be in the following
        /// format YYYY[MM[DD]].
        /// </remarks>
        public virtual string Value
        {
            get
            {
                return valueRenamed;
            }

            set
            {
                if (value != null && !value.Equals(string.Empty) && !value.Equals("\"\""))
                {
                    try
                    {
                        // check the length, must be either four, six, or eight digits
                        if ((value.Length != 4) && (value.Length != 6) && (value.Length != 8))
                        {
                            const string msg =
                                "The length of the DT datatype value does not conform to an allowable format. Format should conform to YYYY[MM[DD]]";
                            var e = new DataTypeException(msg);
                            throw e;
                        }

                        var cal = new GregorianCalendar();

                        if (value.Length >= 4)
                        {
                            // extract the year from the input value
                            var yrInt = int.Parse(value.Substring(0, 4 - 0));

                            // check to see if the year is valid by creating a DateTime value with the Gregorian calendar and
                            // this value.  If an error occurs then processing will stop in this try block
                            new DateTime(yrInt, 1, 1, cal);
                            Year = yrInt;
                        }

                        if (value.Length >= 6)
                        {
                            // extract the month from the input value
                            var mnthInt = int.Parse(value.Substring(4, 6 - 4));

                            // check to see if the month is valid by creating a DateTime value with the Gregorian calendar and
                            // this value.  If an error occurs then processing will stop in this try block
                            new DateTime(Year, mnthInt, 1);
                            Month = mnthInt;
                        }

                        if (value.Length == 8)
                        {
                            // extract the day from the input value
                            var dayInt = int.Parse(value.Substring(6, 8 - 6));

                            // check to see if the day is valid by creating a DateTime value with the Gregorian calendar and
                            // the year/month/day combination.  If an error occurs then processing will stop
                            // in this try block
                            new DateTime(Year, Month, dayInt);
                            Day = dayInt;
                        }

                        // validations are complete now store the input value into the private value field
                        valueRenamed = value;
                    }
                    catch (DataTypeException e)
                    {
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
        /// This method takes in an integer value for the year and performs validations,
        /// it then sets the value field formatted as an HL7 date.
        /// value with year precision (YYYY).
        /// </summary>
        public virtual int YearPrecision
        {
            set
            {
                try
                {
                    // ensure that the year field is four digits long
                    if (Convert.ToString(value).Length != 4)
                    {
                        var msg = "The input year value must be four digits long";
                        var e = new DataTypeException(msg);
                        throw e;
                    }

                    var cal = new GregorianCalendar();

                    // check is input year is valid
                    new DateTime(value, 1, 1, cal);
                    Year = value;
                    Month = 0;
                    Day = 0;
                    valueRenamed = Convert.ToString(value);
                }
                catch (DataTypeException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new DataTypeException("An unexpected exception occurred", e);
                }
            }
        }

        /// <summary> Returns the year as an integer.</summary>
        public virtual int Year { get; private set; }

        /// <summary> Returns the month as an integer.</summary>
        public virtual int Month { get; private set; }

        /// <summary> Returns the day as an integer.</summary>
        public virtual int Day { get; private set; }

        [Obsolete("This method has been replaced by 'ToHl7DTFormat'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public static string toHl7DTFormat(GregorianCalendar cal)
        {
            return ToHl7DTFormat(cal);
        }

        /// <summary> Returns a string value representing the input Gregorian Calendar object in
        /// an Hl7 Date Format.
        /// </summary>
        public static string ToHl7DTFormat(GregorianCalendar cal)
        {
            var val = string.Empty;
            try
            {
                // set the input cal object so that it can report errors
                // on it's value
                var calYear = SupportClass.CalendarManager.manager.Get(cal, SupportClass.CalendarManager.YEAR);
                var calMonth = SupportClass.CalendarManager.manager.Get(cal, SupportClass.CalendarManager.MONTH) + 1;
                var calDay = SupportClass.CalendarManager.manager.Get(cal, SupportClass.CalendarManager.DAY_OF_MONTH);
                var dt = new CommonDT();
                dt.SetYearMonthDayPrecision(calYear, calMonth, calDay);
                val = dt.Value;
            }
            catch (DataTypeException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new DataTypeException("An unexpected exception occurred", e);
            }

            return val;
        }

        [Obsolete("This method has been replaced by 'SetYearMonthPrecision'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual void setYearMonthPrecision(int yr, int mnth)
        {
            SetYearMonthPrecision(yr, mnth);
        }

        /// <summary> This method takes in integer values for the year and month and performs validations,
        /// it then sets the value field formatted as an HL7 date
        /// value with year and month precision (YYYYMM).
        /// Note: The first month = 1 = January.
        /// </summary>
        public virtual void SetYearMonthPrecision(int yr, int mnth)
        {
            try
            {
                // ensure that the year field is four digits long
                if (Convert.ToString(yr).Length != 4)
                {
                    var msg = "The input year value must be four digits long";
                    var e = new DataTypeException(msg);
                    throw e;
                }

                var cal = new GregorianCalendar();

                // validate the input month
                new DateTime(yr, mnth, 1, cal);
                Year = yr;
                Month = mnth;
                Day = 0;
                valueRenamed = Convert.ToString(yr) + DataTypeUtil.PreAppendZeroes(mnth, 2);
            }
            catch (DataTypeException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new DataTypeException("An unexpected exception occurred", e);
            }
        }

        [Obsolete("This method has been replaced by 'SetYearMonthDayPrecision'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual void setYearMonthDayPrecision(int yr, int mnth, int dy)
        {
            SetYearMonthDayPrecision(yr, mnth, dy);
        }

        /// <summary> This method takes in integer values for the year and month and day
        /// and performs validations, it then sets the value in the object
        /// formatted as an HL7 date value with year and month and day precision (YYYYMMDD).
        /// </summary>
        public virtual void SetYearMonthDayPrecision(int yr, int mnth, int dy)
        {
            try
            {
                // ensure that the year field is four digits long
                if (Convert.ToString(yr).Length != 4)
                {
                    var msg = "The input year value must be four digits long";
                    var e = new DataTypeException(msg);
                    throw e;
                }

                var cal = new GregorianCalendar();

                // validate the input month/day combination
                new DateTime(yr, mnth, dy, cal);
                Year = yr;
                Month = mnth;
                Day = dy;
                valueRenamed = Convert.ToString(yr) + DataTypeUtil.PreAppendZeroes(mnth, 2) + DataTypeUtil.PreAppendZeroes(dy, 2);
            }
            catch (DataTypeException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new DataTypeException("An unexpected exception occurred", e);
            }
        }
    }
}