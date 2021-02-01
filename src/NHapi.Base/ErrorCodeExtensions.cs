namespace NHapi.Base
{
    using System;
    using System.ComponentModel;
    using System.Linq;

   public static class ErrorCodeExtensions
    {
        /// <summary>
        /// Returns the ErrorCode for the given integer
        /// </summary>
        /// <param name="errorCode">integer error code</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">when given integer is not a valid <see cref="ErrorCode"/> value</exception>
        public static ErrorCode ToErrorCode(this int errorCode)
        {
            var errorCodeValues = Enum.GetValues(typeof(ErrorCode)).Cast<int>();

            if (!errorCodeValues.Contains(errorCode))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(errorCode), "The integer provided is not a valid ErrorCode value");
            }

            return (ErrorCode)errorCode;
        }

        /// <summary>
        /// Get the integer error code for the <see cref="ErrorCode"/>.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public static int GetCode(this ErrorCode errorCode)
        {
            return (int)errorCode;
        }

        /// <summary>
        /// Retrieves the name of the <see cref="ErrorCode"/> value
        /// from the <seealso cref="DescriptionAttribute"/> or the string
        /// representation of the enum value if there is no <seealso cref="DescriptionAttribute"/>
        /// present
        /// </summary>
        /// <param name="errorCode">the <see cref="ErrorCode"/> we will retrieve the description from</param>
        /// <returns></returns>
        public static string GetName(this ErrorCode errorCode)
        {
            var errorCodeType = typeof(ErrorCode);

            var errorCodeName = Enum.GetName(errorCodeType, errorCode);
            var fieldInfo = errorCodeType.GetField(errorCodeName);

            var attributes = fieldInfo?.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attributes != null && attributes.Length > 0)
            {
                errorCodeName = ((DescriptionAttribute)attributes[0]).Description;
            }

            return errorCodeName;
        }
    }
}