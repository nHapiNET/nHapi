namespace NHapi.Base.Log
{
    using System;

    /// <summary>
    ///
    /// </summary>
    /// <remarks>Added for conversion will need to replace.</remarks>
    public interface ILog
    {
        /// <summary>
        /// Gets a value indicating whether or not debug level logging is enabled.
        /// </summary>
        bool DebugEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether or not error level logging is enabled.
        /// </summary>
        bool ErrorEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether or not fatal level logging is enabled.
        /// </summary>
        bool FatalEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether or not info level logging is enabled.
        /// </summary>
        bool InfoEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether or not trace level logging is enabled.
        /// </summary>
        bool TraceEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether or not warning level logging is enabled.
        /// </summary>
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
    /// Dummy logger.
    /// </summary>
    public sealed class DummyLogger : ILog
    {
        /// <inheritdoc />
        public bool DebugEnabled
        {
            get { return false; }
        }

        /// <inheritdoc />
        public bool ErrorEnabled
        {
            get { return false; }
        }

        /// <inheritdoc />
        public bool FatalEnabled
        {
            get { return false; }
        }

        /// <inheritdoc />
        public bool InfoEnabled
        {
            get { return false; }
        }

        /// <inheritdoc />
        public bool TraceEnabled
        {
            get { return false; }
        }

        /// <inheritdoc />
        public bool WarnEnabled
        {
            get { return false; }
        }

        /// <inheritdoc />
        public void Debug(object message)
        {
            // No implementation
        }

        /// <inheritdoc />
        public void Debug(object message, Exception t)
        {
            // No implementation
        }

        /// <inheritdoc />
        public void Error(object message)
        {
            // No implementation
        }

        /// <inheritdoc />
        public void Error(object message, Exception t)
        {
            // No implementation
        }

        /// <inheritdoc />
        public void Fatal(object message)
        {
            // No implementation
        }

        /// <inheritdoc />
        public void Fatal(object message, Exception t)
        {
            // No implementation
        }

        /// <inheritdoc />
        public void Info(object message)
        {
            // No implementation
        }

        /// <inheritdoc />
        public void Info(object message, Exception t)
        {
            // No implementation
        }

        /// <inheritdoc />
        public void Trace(object message)
        {
            // No implementation
        }

        /// <inheritdoc />
        public void Trace(object message, Exception t)
        {
            // No implementation
        }

        /// <inheritdoc />
        public void Warn(object message)
        {
            // No implementation
        }

        /// <inheritdoc />
        public void Warn(object message, Exception t)
        {
            // No implementation
        }
    }
}