/*
  HapiLog.java

  Created on May 7, 2003 at 2:23:45 PM
*/

namespace NHapi.Base.Log
{
    using System;

    /// <summary> Provides a base implementation of the. <code>HapiLog</code> interface.
    ///
    /// It delegates all method calls declared by. <code>Log</code> to the delegate specified in
    /// the constructor.
    ///
    /// </summary>
    /// <author>  <a href="mailto:alexei.guevara@uhn.on.ca">Alexei Guevara</a>
    /// </author>
    /// <version>  $Revision: 1.2 $ updated on $Date: 2003/05/26 20:17:06 $ by $Author: aguevara $.
    /// </version>
    public class HapiLogImpl : IHapiLog
    {
        private ILog innerLog;

        internal HapiLogImpl(ILog log)
        {
            innerLog = log;
        }

        /// <inheritdoc />
        public virtual bool DebugEnabled => innerLog.DebugEnabled;

        /// <inheritdoc />
        public virtual bool ErrorEnabled => innerLog.ErrorEnabled;

        /// <inheritdoc />
        public virtual bool FatalEnabled => innerLog.FatalEnabled;

        /// <inheritdoc />
        public virtual bool InfoEnabled => innerLog.InfoEnabled;

        /// <inheritdoc />
        public virtual bool TraceEnabled => innerLog.TraceEnabled;

        /// <inheritdoc />
        public virtual bool WarnEnabled => innerLog.WarnEnabled;

        /// <inheritdoc />
        public virtual void Debug(object message)
        {
            innerLog.Debug(message);
        }

        /// <inheritdoc />
        public virtual void Debug(object message, Exception t)
        {
            innerLog.Debug(message, t);
        }

        /// <inheritdoc />
        public virtual void Error(object message)
        {
            innerLog.Error(message);
        }

        /// <inheritdoc />
        public virtual void Error(object message, Exception t)
        {
            innerLog.Error(message, t);
        }

        /// <inheritdoc />
        public virtual void Fatal(object message)
        {
            innerLog.Fatal(message);
        }

        /// <inheritdoc />
        public virtual void Fatal(object message, Exception t)
        {
            innerLog.Fatal(message, t);
        }

        /// <inheritdoc />
        public virtual void Info(object message)
        {
            innerLog.Info(message);
        }

        /// <inheritdoc />
        public virtual void Info(object message, Exception t)
        {
            innerLog.Info(message, t);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return innerLog.ToString();
        }

        /// <inheritdoc />
        public virtual void Trace(object message)
        {
            innerLog.Trace(message);
        }

        /// <inheritdoc />
        public virtual void Trace(object message, Exception t)
        {
            innerLog.Trace(message, t);
        }

        /// <inheritdoc />
        public virtual void Warn(object message)
        {
            innerLog.Warn(message);
        }

        /// <inheritdoc />
        public virtual void Warn(object message, Exception t)
        {
            innerLog.Warn(message, t);
        }

        /// <inheritdoc />
        public virtual void Debug(string msgPattern, object[] values, Exception t)
        {
            var message = string.Format(msgPattern, values);
            innerLog.Debug(message, t);
        }
    }
}