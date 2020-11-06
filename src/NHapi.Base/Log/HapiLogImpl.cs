/*
* HapiLog.java
* 
* Created on May 7, 2003 at 2:23:45 PM
*/

using System;

namespace NHapi.Base.Log
{
	/// <summary> Provides a base implementation of the <code>HapiLog</code> interface.
	/// 
	/// It delegates all method calls declared by <code>Log</code> to the delegate specified in
	/// the contructor.
	/// 
	/// </summary>
	/// <author>  <a href="mailto:alexei.guevara@uhn.on.ca">Alexei Guevara</a>
	/// </author>
	/// <version>  $Revision: 1.2 $ updated on $Date: 2003/05/26 20:17:06 $ by $Author: aguevara $
	/// </version>
	public class HapiLogImpl : IHapiLog
	{
		/// <returns>
		/// </returns>
		public virtual bool DebugEnabled
		{
			get { return innerLog.DebugEnabled; }
		}

		/// <returns>
		/// </returns>
		public virtual bool ErrorEnabled
		{
			get { return innerLog.ErrorEnabled; }
		}

		/// <returns>
		/// </returns>
		public virtual bool FatalEnabled
		{
			get { return innerLog.FatalEnabled; }
		}

		/// <returns>
		/// </returns>
		public virtual bool InfoEnabled
		{
			get { return innerLog.InfoEnabled; }
		}

		/// <returns>
		/// </returns>
		public virtual bool TraceEnabled
		{
			get { return innerLog.TraceEnabled; }
		}

		/// <returns>
		/// </returns>
		public virtual bool WarnEnabled
		{
			get { return innerLog.WarnEnabled; }
		}

		private ILog innerLog;

		internal HapiLogImpl(ILog log)
		{
			innerLog = log;
		}

		/// <param name="message">
		/// </param>
		public virtual void Debug(Object message)
		{
			innerLog.Debug(message);
		}

		/// <param name="message">
		/// </param>
		/// <param name="t">
		/// </param>
		public virtual void Debug(Object message, Exception t)
		{
			innerLog.Debug(message, t);
		}

		/// <param name="message">
		/// </param>
		public virtual void Error(Object message)
		{
			innerLog.Error(message);
		}

		/// <param name="message">
		/// </param>
		/// <param name="t">
		/// </param>
		public virtual void Error(Object message, Exception t)
		{
			innerLog.Error(message, t);
		}

		/// <summary>
		/// fatal
		/// </summary>
		/// <param name="message"></param>
		public virtual void Fatal(Object message)
		{
			innerLog.Fatal(message);
		}

		/// <summary>
		/// fatal
		/// </summary>
		/// <param name="message"></param>
		/// <param name="t"></param>
		public virtual void Fatal(Object message, Exception t)
		{
			innerLog.Fatal(message, t);
		}

		/// <summary>
		/// info
		/// </summary>
		/// <param name="message"></param>
		public virtual void Info(Object message)
		{
			innerLog.Info(message);
		}

		/// <summary>
		/// info
		/// </summary>
		/// <param name="message"></param>
		/// <param name="t"></param>
		public virtual void Info(Object message, Exception t)
		{
			innerLog.Info(message, t);
		}

		/// <summary>
		/// To string
		/// </summary>
		/// <returns></returns>
		public override String ToString()
		{
			return innerLog.ToString();
		}

		/// <param name="message">
		/// </param>
		public virtual void Trace(Object message)
		{
			innerLog.Trace(message);
		}

		/// <summary>
		/// Trace
		/// </summary>
		/// <param name="message"></param>
		/// <param name="t"></param>
		public virtual void Trace(Object message, Exception t)
		{
			innerLog.Trace(message, t);
		}

		/// <summary>
		/// Warn
		/// </summary>
		/// <param name="message"></param>
		public virtual void Warn(Object message)
		{
			innerLog.Warn(message);
		}

		/// <summary>
		/// Warn
		/// </summary>
		/// <param name="message"></param>
		/// <param name="t"></param>
		public virtual void Warn(Object message, Exception t)
		{
			innerLog.Warn(message, t);
		}


		/// <summary>
		/// debug method
		/// </summary>
		/// <param name="msgPattern"></param>
		/// <param name="values"></param>
		/// <param name="t"></param>
		public virtual void Debug(String msgPattern, Object[] values, Exception t)
		{
			String message = String.Format(msgPattern, values);
			innerLog.Debug(message, t);
		}
	}
}