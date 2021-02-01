using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace NHapi.Base.Log
{
    /// <summary>
    /// Logger implementation logging to Enterprise Library Logging Block.
    /// </summary>
    internal class EntLibLogger : ILog
    {
        private const string DefaultDebugCategory = "Debug";
        private static TraceSwitch _traceSwitch = new TraceSwitch("nHapi", "nHapi Trace Switch");

        #region Log Members

        /// <summary>
        /// EntLib does not allow us to check for DebugEnabled, so we return true always.  
        /// This can be filtered out at the configuration level.
        /// </summary>
        public bool DebugEnabled
        {
            get { return false; }
        }

        public bool ErrorEnabled
        {
            get { return false; }
        }

        public bool FatalEnabled
        {
            get { return false; }
        }

        public bool InfoEnabled
        {
            get { return false; }
        }

        public bool TraceEnabled
        {
            get { return false; }
        }

        public bool WarnEnabled
        {
            get { return false; }
        }

        public void Debug(object message)
        {
            Debug(message, null);
        }

        public void Debug(object message, Exception t)
        {
            // Instead of setting a category, we use the Verbose severity to indicate
            // the need for debugging.  This avoids the need to have a consumer of 
            // the library setup a category in the logging configuration.
            WriteLog(message, t, TraceLevel.Verbose);
        }

        public void Error(object message)
        {
            Error(message, null);
        }

        public void Error(object message, Exception t)
        {
            WriteLog(message, t, TraceLevel.Error);
        }

        public void Fatal(object message)
        {
            Fatal(message, null);
        }

        public void Fatal(object message, Exception t)
        {
            WriteLog(message, t, TraceLevel.Error);
        }

        public void Info(object message)
        {
            Info(message, null);
        }

        public void Info(object message, Exception t)
        {
            WriteLog(message, t, TraceLevel.Info);
        }

        public void Trace(object message)
        {
            Trace(message, null);
        }

        public void Trace(object message, Exception t)
        {
            WriteLog(message, t, TraceLevel.Info);
        }

        public void Warn(object message)
        {
            Warn(message, null);
        }

        public void Warn(object message, Exception t)
        {
            WriteLog(message, t, TraceLevel.Warning);
        }

        #endregion

        private static void WriteLog(object message, Exception t, TraceLevel severity)
        {
            WriteLog(message, t, severity, null);
        }


        private static void WriteLog(object message, Exception t, TraceLevel severity, string category)
        {
            bool writeTrace = false;
            if (_traceSwitch.Level >= severity)
                writeTrace = true;

            if (writeTrace)
            {
                Exception ex;
                if (message == null)
                    ex = t;
                else
                    ex = new Exception(message.ToString(), t);


                WriteTrace(_traceSwitch, ex, category);
            }
        }

        private static void WriteTrace(TraceSwitch ts, Exception ex, string category)
        {
            if (category == null)
                System.Diagnostics.Trace.WriteLine(ex);
            else
                System.Diagnostics.Trace.WriteLine(ex, category);
        }
    }
}