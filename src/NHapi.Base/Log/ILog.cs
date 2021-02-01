using System;
using System.Collections.Generic;
using System.Text;

namespace NHapi.Base.Log
{
    /// <summary>
    ///
    /// </summary>
    /// <remarks>Added for conversion will need to replace.</remarks>
    public interface ILog
    {
        bool DebugEnabled { get; }

        bool ErrorEnabled { get; }

        bool FatalEnabled { get; }

        bool InfoEnabled { get; }

        bool TraceEnabled { get; }

        bool WarnEnabled { get; }


        void Debug(object message);

        void Debug(object message, Exception t);

        void Error(object message);

        void Error(object message, Exception t);

        void Fatal(object message);

        void Fatal(object message, Exception t);

        void Info(object message);

        void Info(object message, Exception t);

        void Trace(object message);

        void Trace(object message, Exception t);

        void Warn(object message);

        void Warn(object message, Exception t);
    }

    /// <summary>
    /// Dummy logger
    /// </summary>
    public sealed class DummyLogger : ILog
    {
        #region Log Members

        /// <summary>
        /// Is debug enabled
        /// </summary>
        public bool DebugEnabled
        {
            get { return false; }
        }

        /// <summary>
        /// Is error enabled
        /// </summary>
        public bool ErrorEnabled
        {
            get { return false; }
        }

        /// <summary>
        /// Is fatal enabled
        /// </summary>
        public bool FatalEnabled
        {
            get { return false; }
        }

        /// <summary>
        /// Is info enabled
        /// </summary>
        public bool InfoEnabled
        {
            get { return false; }
        }

        /// <summary>
        /// is trace enabled
        /// </summary>
        public bool TraceEnabled
        {
            get { return false; }
        }

        /// <summary>
        /// Is warn enabled
        /// </summary>
        public bool WarnEnabled
        {
            get { return false; }
        }

        /// <summary>
        /// Write debug message
        /// </summary>
        /// <param name="message"></param>
        public void Debug(object message)
        {
            // No implementation
        }

        /// <summary>
        /// Write debug message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="t"></param>
        public void Debug(object message, Exception t)
        {
            // No implementation
        }

        /// <summary>
        /// Write error
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message)
        {
            // No implementation
        }

        /// <summary>
        /// Write error
        /// </summary>
        /// <param name="message"></param>
        /// <param name="t"></param>
        public void Error(object message, Exception t)
        {
            // No implementation
        }

        /// <summary>
        /// Write fatal
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(object message)
        {
            // No implementation
        }

        /// <summary>
        /// Write fatal
        /// </summary>
        /// <param name="message"></param>
        /// <param name="t"></param>
        public void Fatal(object message, Exception t)
        {
            // No implementation
        }

        /// <summary>
        /// Write info
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message)
        {
            // No implementation
        }

        /// <summary>
        /// Write info
        /// </summary>
        /// <param name="message"></param>
        /// <param name="t"></param>
        public void Info(object message, Exception t)
        {
            // No implementation
        }

        /// <summary>
        /// Write trace
        /// </summary>
        /// <param name="message"></param>
        public void Trace(object message)
        {
            // No implementation
        }

        /// <summary>
        /// Write trace
        /// </summary>
        /// <param name="message"></param>
        /// <param name="t"></param>
        public void Trace(object message, Exception t)
        {
            // No implementation
        }

        /// <summary>
        /// Write warn
        /// </summary>
        /// <param name="message"></param>
        public void Warn(object message)
        {
            // No implementation
        }

        /// <summary>
        /// Write warn
        /// </summary>
        /// <param name="message"></param>
        /// <param name="t"></param>
        public void Warn(object message, Exception t)
        {
            // No implementation
        }

        #endregion
    }
}