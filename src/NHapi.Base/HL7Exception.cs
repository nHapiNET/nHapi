/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "HL7Exception.java".  Description:
  "Represents an exception encountered while processing
  an HL7 message"

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
using System.Text;

using NHapi.Base.Model;
using NHapi.Base.Util;

namespace NHapi.Base
{
   /// <summary> Represents an exception encountered while processing
   /// an HL7 message.
   /// </summary>
   /// <author>  Bryan Tripp (bryan_tripp@sourceforge.net)
   /// </author>
    [Serializable]
    public class HL7Exception : Exception
    {
        /// <value>
        /// The name of the segment where the error occurred
        /// <para>(returns null if not set)</para>
        /// </value>
        public virtual string SegmentName { get; set; }

        /// <value>
        /// The sequence number of the segment where the error occurred (if there
        /// are multiple segments with the same name)
        /// <para> Numbering starts at 1. </para>
        /// <para> (returns -1 if not set) </para>
        /// </value>
        public virtual int SegmentRepetition { get; set; } = -1;

        /// <value>
        /// The field number within the segment where the error occurred
        /// <para>Numbering starts at 1.</para>
        /// <para> (returns -1 if not set) </para>
        /// </value>
        public virtual int FieldPosition { get; set; } = -1;

        /// <value>
        /// The <see cref="Base.ErrorCode"/> value associated with the <see cref="HL7Exception"/>
        /// </value>
        public ErrorCode ErrorCode { get; private set; } = ErrorCode.APPLICATION_INTERNAL_ERROR;

        /// <value>
        /// The message that describes the current exception.
        /// </value>
        /// <remarks>Overrides <see cref="Exception.Message" /> to add
        /// the field location of the problem if available.</remarks>
        public override string Message
        {
            get
            {
                StringBuilder msg = new StringBuilder();
                msg.Append(base.Message);

                if (SegmentName != null)
                {
                    msg.Append(": Segment: ");
                    msg.Append(SegmentName);
                }

                if (SegmentRepetition != -1)
                {
                    msg.Append(" (rep ");
                    msg.Append(SegmentRepetition);
                    msg.Append(")");
                }

                if (FieldPosition != -1)
                {
                    msg.Append(" Field #");
                    msg.Append(FieldPosition);
                }

                return msg.ToString();
            }
        }

        /// <summary>
        /// Acknowledgement Application Accept
        /// </summary>
        /// <remarks>Deprecated use <see cref="AcknowledgmentCode.AA"/> instead.</remarks>
        [Obsolete("Deprecated use 'AcknowledgementCode.AA' instead.")]
        public const int ACK_AA = 1;

        /// <summary>
        /// Acknowledgement Application Error
        /// </summary>
        /// <remarks>Deprecated use <see cref="AcknowledgmentCode.AE"/> instead.</remarks>
        [Obsolete("Deprecated use 'AcknowledgementCode.AE' instead.")]
        public const int ACK_AE = 2;

        /// <summary>
        /// Acknowledgement Application Reject
        /// </summary>
        /// <remarks>Deprecated use <see cref="AcknowledgmentCode.AR"/> instead.</remarks>
        [Obsolete("Deprecated use 'AcknowledgmentCode.AR' instead.")]
        public const int ACK_AR = 3;

        /// <summary>
        /// Message accepted
        /// </summary>
        /// <remarks>Deprecated use <see cref="ErrorCode.MESSAGE_ACCEPTED"/> instead.</remarks>
        [Obsolete("Deprecated use 'ErrorCode.MESSAGE_ACCEPTED' instead.")]
        public const int MESSAGE_ACCEPTED = 0;

        /// <summary>
        /// Segment sequence error
        /// </summary>
        /// <remarks>Deprecated use <see cref="ErrorCode.SEGMENT_SEQUENCE_ERROR"/> instead.</remarks>
        [Obsolete("Deprecated use 'ErrorCode.SEGMENT_SEQUENCE_ERROR' instead.")]
        public const int SEGMENT_SEQUENCE_ERROR = 100;

        /// <summary>
        /// Required field missing
        /// </summary>
        /// <remarks>Deprecated use <see cref="ErrorCode.REQUIRED_FIELD_MISSING"/> instead.</remarks>
        [Obsolete("Deprecated use 'ErrorCode.REQUIRED_FIELD_MISSING' instead.")]
        public const int REQUIRED_FIELD_MISSING = 101;

        /// <summary>
        /// Date type error
        /// </summary>
        /// <remarks>Deprecated use <see cref="ErrorCode.DATA_TYPE_ERROR"/> instead.</remarks>
        [Obsolete("Deprecated use 'ErrorCode.DATA_TYPE_ERROR' instead.")]
        public const int DATA_TYPE_ERROR = 102;

        /// <summary>
        /// Table value not found
        /// </summary>
        /// <remarks>Deprecated use <see cref="ErrorCode.TABLE_VALUE_NOT_FOUND"/> instead.</remarks>
        [Obsolete("Deprecated use 'ErrorCode.TABLE_VALUE_NOT_FOUND' instead.")]
        public const int TABLE_VALUE_NOT_FOUND = 103;

        /// <summary>
        /// Unsupported message type
        /// </summary>
        /// <remarks>Deprecated use <see cref="ErrorCode.UNSUPPORTED_MESSAGE_TYPE"/> instead.</remarks>
        [Obsolete("Deprecated use 'ErrorCode.UNSUPPORTED_MESSAGE_TYPE' instead.")]
        public const int UNSUPPORTED_MESSAGE_TYPE = 200;

        /// <summary>
        /// Unsupported event code
        /// </summary>
        /// <remarks>Deprecated use <see cref="ErrorCode.UNSUPPORTED_EVENT_CODE"/> instead.</remarks>
        [Obsolete("Deprecated use 'ErrorCode.UNSUPPORTED_EVENT_CODE' instead.")]
        public const int UNSUPPORTED_EVENT_CODE = 201;

        /// <summary>
        /// Unsupported processing id
        /// </summary>
        /// <remarks>Deprecated use <see cref="ErrorCode.UNSUPPORTED_PROCESSING_ID"/> instead.</remarks>
        [Obsolete("Deprecated use 'ErrorCode.UNSUPPORTED_PROCESSING_ID' instead.")]
        public const int UNSUPPORTED_PROCESSING_ID = 202;

        /// <summary>
        /// Unsupported version id
        /// </summary>
        /// <remarks>Deprecated use <see cref="ErrorCode.UNSUPPORTED_VERSION_ID"/> instead.</remarks>
        [Obsolete("Deprecated use 'ErrorCode.UNSUPPORTED_VERSION_ID' instead.")]
        public const int UNSUPPORTED_VERSION_ID = 203;

        /// <summary>
        /// Unknown key id
        /// </summary>
        /// <remarks>Deprecated use <see cref="ErrorCode.MESSAGE_ACCEPTED"/> instead.</remarks>
        [Obsolete("Deprecated use 'ErrorCode.UNKNOWN_KEY_IDENTIFIER' instead.")]
        public const int UNKNOWN_KEY_IDENTIFIER = 204;

        /// <summary>
        /// Duplicate key id
        /// </summary>
        /// <remarks>Deprecated use <see cref="ErrorCode.DUPLICATE_KEY_IDENTIFIER"/> instead.</remarks>
        [Obsolete("Deprecated use 'ErrorCode.DUPLICATE_KEY_IDENTIFIER' instead.")]
        public const int DUPLICATE_KEY_IDENTIFIER = 205;

        /// <summary>
        /// Application record locked
        /// </summary>
        /// <remarks>Deprecated use <see cref="ErrorCode.APPLICATION_RECORD_LOCKED"/> instead.</remarks>
        [Obsolete("Deprecated use 'ErrorCode.APPLICATION_RECORD_LOCKED' instead.")]
        public const int APPLICATION_RECORD_LOCKED = 206;

        /// <summary>
        /// Application error
        /// </summary>
        /// <remarks>Deprecated use <see cref="ErrorCode.APPLICATION_INTERNAL_ERROR"/> instead.</remarks>
        [Obsolete("Deprecated use 'ErrorCode.APPLICATION_INTERNAL_ERROR' instead.")]
        public const int APPLICATION_INTERNAL_ERROR = 207;

        /// <summary> Creates an <see cref="HL7Exception" />.
        /// <param name="message">The error message</param>
        /// <param name="errorCondition">a code describing the the error condition, from HL7
        /// table 0357 (see section 2.16.8 of standard v 2.4) - <see cref="Base.ErrorCode" /> defines
        /// these codes as integer constants that can be used here (e.g.
        /// <c>ErrorCode.UNSUPPORTED_MESSAGE_TYPE.GetCode()</c>)
        /// </param>
        /// <param name="cause">The exception that caused this exception to be thrown.
        /// </param>
        /// </summary>
        [Obsolete("Deprecated use 'public HL7Exception(String message, ErrorCode errorCondition, Exception cause)' constructor instead.")]
        public HL7Exception(string message, int errorCondition, Exception cause)
             : this(message, errorCondition.ToErrorCode(), cause)
        {
        }

        /// <summary> Creates an <see cref="HL7Exception" />.
        /// <param name="message">The error message</param>
        /// <param name="errorCondition">a code describing the the error condition, from HL7
        /// table 0357 (see section 2.16.8 of standard v 2.4) - <see cref="Base.ErrorCode"/> defines
        /// these codes as integer constants that can be used here (e.g.
        /// <seealso cref="ErrorCode.UNSUPPORTED_MESSAGE_TYPE" />)
        /// </param>
        /// <param name="cause">The exception that caused this exception to be thrown.
        /// </param>
        /// </summary>
        public HL7Exception(string message, ErrorCode errorCondition, Exception cause)
             : base(message, cause)
        {
            ErrorCode = errorCondition;
        }

        /// <summary> Creates an <see cref="HL7Exception" />.
        /// <param name="message">the error message</param>
        /// <param name="errorCondition">a code describing the the error condition, from HL7
        /// table 0357 (see section 2.16.8 of standard v 2.4) - <see cref="Base.ErrorCode"/> defines
        /// these codes as integer constants that can be used here (e.g.
        /// <c>ErrorCode.UNSUPPORTED_MESSAGE_TYPE.GetCode()</c>)
        /// </param>
        /// </summary>
        [Obsolete("Deprecated use 'public HL7Exception(String message, ErrorCode errorCondition)' constructor instead.")]
        public HL7Exception(string message, int errorCondition)
            : this(message, errorCondition.ToErrorCode())
        {
        }

        /// <summary> Creates an <see cref="HL7Exception" />.
        /// <param name="message">the error message</param>
        /// <param name="errorCondition">a code describing the the error condition, from HL7
        /// table 0357 (see section 2.16.8 of standard v 2.4) - <see cref="Base.ErrorCode"/> defines
        /// these codes as integer constants that can be used here (e.g.
        /// <seealso cref="ErrorCode.UNSUPPORTED_MESSAGE_TYPE" />)
        /// </param>
        /// </summary>
        public HL7Exception(string message, ErrorCode errorCondition)
             : base(message)
        {
            ErrorCode = errorCondition;
        }

        /// <summary> Creates an <see cref="HL7Exception" /> with the code
        /// <seealso cref="ErrorCode.APPLICATION_INTERNAL_ERROR" />
        /// <param name="cause">The exception that caused this exception to be thrown.</param>
        /// <param name="message">the error message</param>
        /// </summary>
        public HL7Exception(string message, Exception cause)
             : base(message, cause)
        {
        }

        /// <summary> Creates an <see cref="HL7Exception" /> with the code
        /// <seealso cref="ErrorCode.APPLICATION_INTERNAL_ERROR" /></summary>
        public HL7Exception(string message)
             : base(message)
        {
        }

        /// <summary> Populates the given error segment with information from this Exception.</summary>
        // TODO: this is out of sync with hapi see
        // https://github.com/hapifhir/hapi-hl7v2/blob/809516e3f4851d7cd97573efb6dedf24959a1063/hapi-base/src/main/java/ca/uhn/hl7v2/AbstractHL7Exception.java#L134
        public virtual void populate(ISegment errorSegment)
        {
            //make sure it's an ERR
            if (!errorSegment.GetStructureName().Equals("ERR"))
            {
                throw new HL7Exception("Can only populate an ERR segment with an exception -- got: " +
                                              errorSegment.GetType().FullName);
            }

            var rep = errorSegment.GetField(1).Length; //append after existing reps

            if (SegmentName != null)
            {
                Terser.Set(errorSegment, 1, rep, 1, 1, SegmentName);
            }


            if (SegmentRepetition >= 0)
            {
                Terser.Set(errorSegment, 1, rep, 2, 1, Convert.ToString(SegmentRepetition));
            }


            if (FieldPosition >= 0)
            {
                Terser.Set(errorSegment, 1, rep, 3, 1, Convert.ToString(FieldPosition));
            }

            Terser.Set(errorSegment, 1, rep, 4, 1, Convert.ToString(ErrorCode));
            // this replaces the need to connect to the database
            Terser.Set(errorSegment, 1, rep, 4, 2, ErrorCode.GetName());
            Terser.Set(errorSegment, 1, rep, 4, 3, "hl70357");
            Terser.Set(errorSegment, 1, rep, 4, 5, Message);
        }
    }
}