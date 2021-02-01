using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;

namespace NHapi.SourceGeneration
{
   public class TransactionManager
    {
        public static ConnectionHashTable manager = new ConnectionHashTable();

        public class ConnectionHashTable : Hashtable
        {
            public DbCommand CreateStatement(OdbcConnection connection)
            {
                DbCommand command = connection.CreateCommand();
                DbTransaction transaction;
                if (this[connection] != null)
                {
                    ConnectionProperties Properties = ((ConnectionProperties)this[connection]);
                    transaction = Properties.Transaction;
                    command.Transaction = transaction;
                    command.CommandTimeout = 0;
                }
                else
                {
                    ConnectionProperties TempProp = new ConnectionProperties();
                    TempProp.AutoCommit = true;
                    TempProp.TransactionLevel = 0;
                    command.Transaction = TempProp.Transaction;
                    command.CommandTimeout = 0;
                    Add(connection, TempProp);
                }

                return command;
            }

            public void Commit(OdbcConnection connection)
            {
                if (this[connection] != null && !((ConnectionProperties)this[connection]).AutoCommit)
                {
                    ConnectionProperties Properties = ((ConnectionProperties)this[connection]);
                    DbTransaction transaction = Properties.Transaction;
                    transaction.Commit();
                    if (Properties.TransactionLevel == 0)
                        Properties.Transaction = connection.BeginTransaction();
                    else
                        Properties.Transaction = connection.BeginTransaction(Properties.TransactionLevel);
                }
            }

            public void RollBack(OdbcConnection connection)
            {
                if (this[connection] != null && !((ConnectionProperties)this[connection]).AutoCommit)
                {
                    ConnectionProperties Properties = ((ConnectionProperties)this[connection]);
                    DbTransaction transaction = Properties.Transaction;
                    transaction.Rollback();
                    if (Properties.TransactionLevel == 0)
                        Properties.Transaction = connection.BeginTransaction();
                    else
                        Properties.Transaction = connection.BeginTransaction(Properties.TransactionLevel);
                }
            }

            public void SetAutoCommit(OdbcConnection connection, bool boolean)
            {
                if (this[connection] != null)
                {
                    ConnectionProperties Properties = ((ConnectionProperties)this[connection]);
                    if (Properties.AutoCommit != boolean)
                    {
                        Properties.AutoCommit = boolean;
                        if (!boolean)
                        {
                            if (Properties.TransactionLevel == 0)
                                Properties.Transaction = connection.BeginTransaction();
                            else
                                Properties.Transaction = connection.BeginTransaction(Properties.TransactionLevel);
                        }
                        else
                        {
                            DbTransaction transaction = Properties.Transaction;
                            if (transaction != null)
                            {
                                transaction.Commit();
                            }
                        }
                    }
                }
                else
                {
                    ConnectionProperties TempProp = new ConnectionProperties();
                    TempProp.AutoCommit = boolean;
                    TempProp.TransactionLevel = 0;
                    if (!boolean)
                        TempProp.Transaction = connection.BeginTransaction();
                    Add(connection, TempProp);
                }
            }

            public DbCommand PrepareStatement(OdbcConnection connection, String sql)
            {
                DbCommand command = CreateStatement(connection);
                command.CommandText = sql;
                command.CommandTimeout = 0;
                return command;
            }

            public DbCommand PrepareCall(OdbcConnection connection, String sql)
            {
                DbCommand command = CreateStatement(connection);
                command.CommandText = sql;
                command.CommandTimeout = 0;
                return command;
            }

            public void SetTransactionIsolation(OdbcConnection connection, int level)
            {
                ConnectionProperties Properties;
                if (level == (int)IsolationLevel.ReadCommitted)
                    SetAutoCommit(connection, false);
                else if (level == (int)IsolationLevel.ReadUncommitted)
                    SetAutoCommit(connection, false);
                else if (level == (int)IsolationLevel.RepeatableRead)
                    SetAutoCommit(connection, false);
                else if (level == (int)IsolationLevel.Serializable)
                    SetAutoCommit(connection, false);

                if (this[connection] != null)
                {
                    Properties = ((ConnectionProperties)this[connection]);
                    Properties.TransactionLevel = (IsolationLevel)level;
                }
                else
                {
                    Properties = new ConnectionProperties();
                    Properties.AutoCommit = true;
                    Properties.TransactionLevel = (IsolationLevel)level;
                    Add(connection, Properties);
                }
            }

            public int GetTransactionIsolation(OdbcConnection connection)
            {
                if (this[connection] != null)
                {
                    ConnectionProperties Properties = ((ConnectionProperties)this[connection]);
                    if (Properties.TransactionLevel != 0)
                        return (int)Properties.TransactionLevel;
                    else
                        return 2;
                }
                else
                    return 2;
            }

            public bool GetAutoCommit(OdbcConnection connection)
            {
                if (this[connection] != null)
                    return ((ConnectionProperties)this[connection]).AutoCommit;
                else
                    return true;
            }

            /// <summary>
            /// Sets the value of a parameter using any permitted object.  The given argument object will be converted to the
            /// corresponding SQL type before being sent to the database.
            /// </summary>
            /// <param name="command">Command object to be changed.</param>
            /// <param name="parameterIndex">One-based index of the parameter to be set.</param>
            /// <param name="parameter">The object containing the input parameter value.</param>
            public void SetValue(DbCommand command, int parameterIndex, Object parameter)
            {
                if (command.Parameters.Count < parameterIndex)
                    command.Parameters.Add(command.CreateParameter());
                command.Parameters[parameterIndex - 1].Value = parameter;
            }

            /// <summary>
            /// Sets a parameter to SQL NULL.
            /// </summary>
            /// <param name="command">Command object to be changed.</param>
            /// <param name="parameterIndex">One-based index of the parameter to be set.</param>
            /// <param name="sqlType">The SQL type to be sent to the database.</param>
            public void SetNull(DbCommand command, int parameterIndex, int sqlType)
            {
                if (command.Parameters.Count < parameterIndex)
                    command.Parameters.Add(command.CreateParameter());
                command.Parameters[parameterIndex - 1].Value = Convert.DBNull;
                command.Parameters[parameterIndex - 1].DbType = (DbType)sqlType;
            }

            /// <summary>
            /// Sets the value of a parameter using an object.  The given argument object will be converted to the
            /// corresponding SQL type before being sent to the database.
            /// </summary>
            /// <param name="command">Command object to be changed.</param>
            /// <param name="parameterIndex">One-based index of the parameter to be set.</param>
            /// <param name="parameter">The object containing the input parameter value.</param>
            /// <param name="targetSqlType">The SQL type to be sent to the database.</param>
            public void SetObject(DbCommand command, int parameterIndex, Object parameter, int targetSqlType)
            {
                if (command.Parameters.Count < parameterIndex)
                    command.Parameters.Add(command.CreateParameter());
                command.Parameters[parameterIndex - 1].Value = parameter;
                command.Parameters[parameterIndex - 1].DbType = (DbType)targetSqlType;
            }

            /// <summary>
            /// Sets the value of a parameter using an object.  The given argument object will be converted to the
            /// corresponding SQL type before being sent to the database.
            /// </summary>
            /// <param name="command">Command object to be changed.</param>
            /// <param name="parameterIndex">One-based index of the parameter to be set.</param>
            /// <param name="parameter">The object containing the input parameter value.</param>
            public void SetObject(DbCommand command, int parameterIndex, Object parameter)
            {
                if (command.Parameters.Count < parameterIndex)
                    command.Parameters.Add(command.CreateParameter());
                command.Parameters[parameterIndex - 1].Value = parameter;
            }

            /// <summary>
            /// This method is for such prepared statements verify if the connection is autoCommit for assign the transaction to the command.
            /// </summary>
            /// <param name="command">The command to be tested.</param>
            /// <returns>The number of rows affected.</returns>
            public int ExecuteUpdate(DbCommand command)
            {
                if (!(((ConnectionProperties)this[command.Connection]).AutoCommit))
                {
                    command.Transaction = ((ConnectionProperties)this[command.Connection]).Transaction;
                    return command.ExecuteNonQuery();
                }
                else
                    return command.ExecuteNonQuery();
            }

            /// <summary>
            /// This method Closes the connection, and if the property of auto commit is true make the commit operation
            /// </summary>
            /// <param name="Connection"> The command to be closed</param>
            public void Close(OdbcConnection Connection)
            {
                if ((this[Connection] != null) && !(((ConnectionProperties)this[Connection]).AutoCommit))
                {
                    Commit(Connection);
                }

                Connection.Close();
            }

            private class ConnectionProperties
            {
                public bool AutoCommit;
                public DbTransaction Transaction;
                public IsolationLevel TransactionLevel;
            }
        }
    }
}