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

namespace NHapi.Base.Model.Primitive
{
    using System;

    /// <summary>
    /// Represents an HL7 TM (time) datatype.
    /// </summary>
    /// <author><a href="mailto:neal.acharya@uhn.on.ca">Neal Acharya</a></author>
    /// <author><a href="mailto:bryan.tripp@uhn.on.ca">Bryan Tripp</a></author>
    /// <version>
    /// $Revision: 1.3 $ updated on $Date: 2005/06/08 00:28:25 $ by $Author: bryan_tripp $.
    /// </version>
    public abstract class TM : AbstractPrimitive
    {
        private CommonTM myDetail;

        /// <param name="theMessage">message to which this Type belongs.
        /// </param>
        protected TM(IMessage theMessage)
            : base(theMessage)
        {
        }

        /// <summary>Construct the type.</summary>
        /// <param name="theMessage">message to which this Type belongs.</param>
        /// <param name="description">The description of this type.</param>
        protected TM(IMessage theMessage, string description)
            : base(theMessage, description)
        {
        }

        /// <inheritdoc />
        public override string Value
        {
            get
            {
                return (myDetail != null) ? myDetail.Value : base.Value;
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
        /// <seealso cref="CommonTM.HourPrecision" />
        /// </summary>
        public virtual int HourPrecision
        {
            set { Detail.HourPrecision = value; }
        }

        /// <summary>
        /// <seealso cref="CommonTM.Offset" />
        /// </summary>
        public virtual int Offset
        {
            set { Detail.Offset = value; }
        }

        /// <summary>
        /// Returns the hour as an integer.
        /// </summary>
        public virtual int Hour => Detail.Hour;

        /// <summary>
        /// Returns the minute as an integer.
        /// </summary>
        public virtual int Minute => Detail.Minute;

        /// <summary>
        /// Returns the second as an integer.
        /// </summary>
        public virtual int Second => Detail.Second;

        /// <summary>
        /// Returns the fractional second value as a float.
        /// </summary>
        public virtual float FractSecond => Detail.FractSecond;

        /// <summary>
        /// Returns the GMT offset value as an integer.
        /// </summary>
        public virtual int GMTOffset => Detail.GMTOffset;

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

        [Obsolete("This method has been replaced by 'SetHourMinutePrecision'.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "StyleCop.CSharp.NamingRules",
            "SA1300:Element should begin with upper-case letter",
            Justification = "As this is a public member, we will duplicate the method and mark this one as obsolete.")]
        public virtual void setHourMinutePrecision(int hr, int min)
        {
            SetHourMinutePrecision(hr, min);
        }

        /// <seealso cref="CommonTM.setHourMinutePrecision(int, int)">
        /// </seealso>
        /// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this.  </throws>
        /// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until
        /// this method is called.
        /// </summary>
        public virtual void SetHourMinutePrecision(int hr, int min)
        {
            Detail.SetHourMinutePrecision(hr, min);
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

        /// <seealso cref="CommonTM.setHourMinSecondPrecision(int, int, float)">
        /// </seealso>
        /// <throws>  DataTypeException if the value is incorrectly formatted.  If validation is enabled, this.  </throws>
        /// <summary>      exception should be thrown at setValue(), but if not, detailed parsing may be deferred until
        /// this method is called.
        /// </summary>
        public virtual void SetHourMinSecondPrecision(int hr, int min, float sec)
        {
            Detail.SetHourMinSecondPrecision(hr, min, sec);
        }
    }
}