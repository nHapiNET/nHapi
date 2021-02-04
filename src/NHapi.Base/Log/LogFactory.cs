namespace NHapi.Base.Log
{
    using System;

    /// <summary>
    /// Placeholder for LogFactory to get project to compile.
    /// </summary>
    internal class LogFactory
    {
        public static ILog GetLog(Type classType)
        {
            return new EntLibLogger();
        }

        public static ILog GetLog(string name)
        {
            return new EntLibLogger();
        }
    }
}