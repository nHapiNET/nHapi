/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "NormativeDatabase.java".  Description:
  "Point of access to a copy of the HL7 normative database"

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2001.  All Rights Reserved.

  Contributor(s): ______________________________________.

  Alternatively, the contents of this file may be used under the terms of the
  GNU General Public License (the "GPL"), in which case the provisions of the GPL are
  applicable instead of those above.  If you wish to allow use of your version of this
  file only under the terms of the GPL and not to allow others to use your version
  of this file under the MPL, indicate your decision by deleting  the provisions above
  and replace  them with the notice and other provisions required by the GPL License.
  If you do not delete the provisions above, a recipient may use your version of
  this file under either the MPL or the GPL.
*/

namespace NHapi.SourceGeneration
{
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.Odbc;
    using System.Diagnostics;

    using NHapi.Base.Log;

    /// <summary>
    /// Point of access to a copy of the HL7 normative database.
    /// </summary>
    /// <example>
    /// A typical way of obtaining and using a database connection would be ...
    /// <para>
    /// <code>
    /// Connection c = NormativeDatabase.getInstance().getConnection();<br />
    /// // ... use the database ... <br />
    /// NormativeDatabase.returnConnection(c);
    /// </code>
    /// </para>
    /// <para>
    /// Since the database may be installed differently on different systems, certain system
    /// properties must be set with the required connection information, as follows: <br />
    /// <code>ca.on.uhn.hl7.database.url</code> - the URL of the JDBC connection.<br />
    /// <code>ca.on.uhn.hl7.database.user</code> - the user ID needed to connect (if required).<br />
    /// <code>ca.on.uhn.hl7.database.passsword</code> - the password associated with the above user (if required).<br />
    /// </para>
    /// <para>
    /// The required JDBC driver must also be loaded (this can be done by ensuring that the
    /// required driver appears in the class path and appending the class name to the
    /// "jdbc.drivers" system property.
    /// </para>
    /// </example>
    /// <author>Bryan Tripp (bryan_tripp@sourceforge.net).</author>
    public class NormativeDatabase
    {
        private static readonly IHapiLog Log;

        private static NormativeDatabase db = null;
        private string connectionString;

        /// <summary> Returns the singleton instance of NormativeDatabase.  </summary>
        private OdbcConnection odbcConnection;

        static NormativeDatabase()
        {
            Log = HapiLogFactory.GetHapiLog(typeof(NormativeDatabase));
        }

        /// <summary> Private constructor ... checks system properties for connection
        /// information.
        /// </summary>
        private NormativeDatabase()
        {
            connectionString = ConfigurationSettings.ConnectionString;
            odbcConnection = new OdbcConnection(connectionString);
            odbcConnection.Open();
        }

        // TODO: Consider using Lazy<T> or other locking semantics to make this thread safe
        public static NormativeDatabase Instance
        {
            get
            {
                lock (typeof(NormativeDatabase))
                {
                    if (db == null)
                    {
                        db = new NormativeDatabase();
                    }

                    return db;
                }
            }
        }

        /// <summary> Provides a Connection to the normative database.
        /// A new connection may be created if none are available.
        /// </summary>
        public virtual OdbcConnection Connection
        {
            get
            {
                lock (this)
                {
                    OpenConnectionIfNeeded();
                    return odbcConnection;
                }
            }
        }

        // test
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                var conn = Instance.Connection;
                var stmt = TransactionManager.Manager.CreateStatement(conn);
                DbCommand temp_OleDbCommand;
                temp_OleDbCommand = stmt;
                temp_OleDbCommand.CommandText = "select * from TableValues";
                var rs = temp_OleDbCommand.ExecuteReader();
                while (rs.Read())
                {
                    var tabNum = rs.GetValue(1 - 1);
                    var val = rs.GetValue(3 - 1);
                    var desc = rs.GetValue(4 - 1);
                    Console.Out.WriteLine("Table: " + tabNum + " Value: " + val + " Description: " + desc);
                }
            }
            catch (DbException e)
            {
                Log.Error("test msg!!", e);
            }
            catch (Exception e)
            {
                Log.Error("test msg!!", e);
            }
        }

        public void OpenNewConnection(string conn)
        {
            lock (this)
            {
                connectionString = conn;
                if (this.odbcConnection.State == ConnectionState.Open)
                {
                    this.odbcConnection.Close();
                }

                this.odbcConnection.ConnectionString = conn;
                this.odbcConnection.Open();
            }
        }

        /// <summary> Used to return an HL7 normative database connection to the connection pool.  If the
        /// given connection is not in fact a connection to the normative database, it is
        /// discarded.
        /// </summary>
        public virtual void ReturnConnection(OdbcConnection conn)
        {
            // check if this is a normative DB connection
            this.odbcConnection.Close();
        }

        [DebuggerHidden]
        private void OpenConnectionIfNeeded()
        {
            try
            {
                if (odbcConnection.State != ConnectionState.Open)
                {
                    odbcConnection.Open();
                }
            }
            catch (Exception)
            {
                odbcConnection = new OdbcConnection(connectionString);
                odbcConnection.Open();
            }
        }
    }
}