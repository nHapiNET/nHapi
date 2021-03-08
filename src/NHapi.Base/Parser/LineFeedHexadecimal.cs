namespace NHapi.Base.Parser
{
    public enum LineFeedHexadecimal
    {
        /// <summary>
        /// will use \X0A\ as the escape sequence
        /// </summary>
        X0A,

        /// <summary>
        /// will use \X00A\ as the escape sequence
        /// </summary>
        X00A,

        /// <summary>
        /// will use \X000a\ as the escape sequence
        /// </summary>
        X000a,
    }
}