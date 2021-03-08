namespace NHapi.Base.Parser
{
    public enum CarriageReturnHexadecimal
    {
        /// <summary>
        /// will use \X0D\ as the escape sequence
        /// </summary>
        X0D,

        /// <summary>
        /// will use \X00D\ as the escape sequence
        /// </summary>
        X00D,

        /// <summary>
        /// will use \X000d\ as the escape sequence
        /// </summary>
        X000d,
    }
}