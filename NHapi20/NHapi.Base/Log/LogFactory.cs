using System;
using System.Collections.Generic;
using System.Text;

namespace NHapi.Base.Log
{
    /// <summary>
    /// Placeholder for LogFactory to get project to compile.
    /// </summary>
    class LogFactory
    {
        public static ILog GetLog(System.Type classType)
        {
            return new EntLibLogger();
        }

        public static ILog GetLog(System.String name)
        {
            return new EntLibLogger();
        }
    }
}
