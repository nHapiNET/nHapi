using System.ComponentModel;

namespace NHapi.Base
{
   public enum AcknowledgmentCode
    {
        /// <summary>
        /// Application Accept
        /// </summary>
        [Description("Application Accept")]
        AA = 1,

        /// <summary>
        /// Application Error
        /// </summary>
        [Description("Application Error")]
        AE = 2,

        /// <summary>
        /// Application Reject
        /// </summary>
        [Description("Application Reject")]
        AR = 3,

        /// <summary>
        /// Commit Accept
        /// </summary>
        [Description("Commit Accept")]
        CA = 5,

        /// <summary>
        /// Commit Error
        /// </summary>
        [Description("Commit Error")]
        CE = 6,

        /// <summary>
        /// Commit Reject
        /// </summary>
        [Description("Commit Reject")]
        CR = 7
    }
}