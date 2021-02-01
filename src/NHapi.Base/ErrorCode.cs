using System;
using System.ComponentModel;
using System.Linq;

namespace NHapi.Base
{
   public enum ErrorCode
    {
        /// <summary>
        /// Message accepted
        /// </summary>
        [Description("Message accepted")]
        MESSAGE_ACCEPTED = 0,

        /// <summary>
        /// Segment sequence error
        /// </summary>
        [Description("Segment sequence error")]
        SEGMENT_SEQUENCE_ERROR = 100,

        /// <summary>
        /// Required field missing
        /// </summary>
        [Description("Required field missing")]
        REQUIRED_FIELD_MISSING = 101,

        /// <summary>
        /// Date type error
        /// </summary>
        [Description("Data type error")]
        DATA_TYPE_ERROR = 102,

        /// <summary>
        /// Table value not found
        /// </summary>
        [Description("Table value not found")]
        TABLE_VALUE_NOT_FOUND = 103,

        /// <summary>
        /// Unsupported message type
        /// </summary>
        [Description("Unsupported message type")]
        UNSUPPORTED_MESSAGE_TYPE = 200,

        /// <summary>
        /// Unsupported event code
        /// </summary>
        [Description("Unsupported event code")]
        UNSUPPORTED_EVENT_CODE = 201,

        /// <summary>
        /// Unsupported processing id
        /// </summary>
        [Description("Unsupported processing id")]
        UNSUPPORTED_PROCESSING_ID = 202,

        /// <summary>
        /// Unsupported version id
        /// </summary>
        [Description("Unsupported version id")]
        UNSUPPORTED_VERSION_ID = 203,

        /// <summary>
        /// Unknown key id
        /// </summary>
        [Description("Unknown key identifier")]
        UNKNOWN_KEY_IDENTIFIER = 204,

        /// <summary>
        /// Duplicate key id
        /// </summary>
        [Description("Duplicate key identifier")]
        DUPLICATE_KEY_IDENTIFIER = 205,

        /// <summary>
        /// Application record locked
        /// </summary>
        [Description("Application record locked")]
        APPLICATION_RECORD_LOCKED = 206,

        /// <summary>
        /// Application error
        /// </summary>
        [Description("Application internal error")]
        APPLICATION_INTERNAL_ERROR = 207
    }
}