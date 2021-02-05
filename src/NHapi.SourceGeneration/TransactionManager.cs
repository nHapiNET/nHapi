namespace NHapi.SourceGeneration
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using System.Data.Odbc;

    public class TransactionManager
    {
        public static ConnectionHashTable Manager { get; set; } = new ConnectionHashTable();

        public class ConnectionHashTable : Hashtable
        {
            public DbCommand CreateStatement(OdbcConnection connection)
            {
                DbCommand command = connection.CreateCommand();
                DbTransaction transaction;
                if (this[connection] != null)
                {
                    ConnectionProperties properties = (ConnectionProperties)this[connection];
                    transaction = properties.Transaction;
                    command.Transaction = transaction;
                    command.CommandTimeout = 0;
                }
                else
                {
                    ConnectionProperties tempProp = new ConnectionProperties();
                    tempProp.AutoCommit = true;
                    tempProp.TransactionLevel = 0;
                    command.Transaction = tempProp.Transaction;
                    command.CommandTimeout = 0;
                    Add(connection, tempProp);
                }

                return command;
            }

            public void Commit(OdbcConnection connection)
            {
                if (this[connection] != null && !((ConnectionProperties)this[connection]).AutoCommit)
                {
                    ConnectionProperties properties = (ConnectionProperties)this[connection];
                    DbTransaction transaction = properties.Transaction;
                    transaction.Commit();
                    if (properties.TransactionLevel == 0)
                    {
                        properties.Transaction = connection.BeginTransaction();
                    }
                    else
                    {
                        properties.Transaction = connection.BeginTransaction(properties.TransactionLevel);
                    }
                }
            }

            public void RollBack(OdbcConnection connection)
            {
                if (this[connection] != null && !((ConnectionProperties)this[connection]).AutoCommit)
                {
                    ConnectionProperties properties = (ConnectionProperties)this[connection];
                    DbTransaction transaction = properties.Transaction;
                    transaction.Rollback();
                    if (properties.TransactionLevel == 0)
                    {
                        properties.Transaction = connection.BeginTransaction();
                    }
                    else
                    {
                        properties.Transaction = connection.BeginTransaction(properties.TransactionLevel);
                    }
                }
            }

            public void SetAutoCommit(OdbcConnection connection, bool boolean)
            {
                if (this[connection] != null)
                {
                    ConnectionProperties properties = (ConnectionProperties)this[connection];
                    if (properties.AutoCommit != boolean)
                    {
                        properties.AutoCommit = boolean;
                        if (!boolean)
                        {
                            if (properties.TransactionLevel == 0)
                            {
                                properties.Transaction = connection.BeginTransaction();
                            }
                            else
                            {
                                properties.Transaction = connection.BeginTransaction(properties.TransactionLevel);
                            }
                        }
                        else
                        {
                            DbTransaction transaction = properties.Transaction;
                            if (transaction != null)
                            {
                                transaction.Commit();
                            }
                        }
                    }
                }
                else
                {
                    ConnectionProperties tempProp = new ConnectionProperties();
                    tempProp.AutoCommit = boolean;
                    tempProp.TransactionLevel = 0;
                    if (!boolean)
                    {
                        tempProp.Transaction = connection.BeginTransaction();
                    }

                    Add(connection, tempProp);
                }
            }

            public DbCommand PrepareStatement(OdbcConnection connection, string sql)
            {
                DbCommand command = CreateStatement(connection);
                command.CommandText = sql;
                command.CommandTimeout = 0;
                return command;
            }

            public DbCommand PrepareCall(OdbcConnection connection, string sql)
            {
                DbCommand command = CreateStatement(connection);
                command.CommandText = sql;
                command.CommandTimeout = 0;
                return command;
            }

            public void SetTransactionIsolation(OdbcConnection connection, int level)
            {
                ConnectionProperties properties;
                if (level == (int)IsolationLevel.ReadCommitted)
                {
                    SetAutoCommit(connection, false);
                }
                else if (level == (int)IsolationLevel.ReadUncommitted)
                {
                    SetAutoCommit(connection, false);
                }
                else if (level == (int)IsolationLevel.RepeatableRead)
                {
                    SetAutoCommit(connection, false);
                }
                else if (level == (int)IsolationLevel.Serializable)
                {
                    SetAutoCommit(connection, false);
                }

                if (this[connection] != null)
                {
                    properties = (ConnectionProperties)this[connection];
                    properties.TransactionLevel = (IsolationLevel)level;
                }
                else
                {
                    properties = new ConnectionProperties();
                    properties.AutoCommit = true;
                    properties.TransactionLevel = (IsolationLevel)level;
                    Add(connection, properties);
                }
            }

            public int GetTransactionIsolation(OdbcConnection connection)
            {
                if (this[connection] != null)
                {
                    ConnectionProperties properties = (ConnectionProperties)this[connection];
                    if (properties.TransactionLevel != 0)
                    {
                        return (int)properties.TransactionLevel;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    return 2;
                }
            }

            public bool GetAutoCommit(OdbcConnection connection)
            {
                if (this[connection] != null)
                {
                    return ((ConnectionProperties)this[connection]).AutoCommit;
                }
                else
                {
                    return true;
                }
            }

            /// <summary>
            /// Sets the value of a parameter using any permitted object.  The given argument object will be converted to the
            /// corresponding SQL type before being sent to the database.
            /// </summary>
            /// <param name="command">Command object to be changed.</param>
            /// <param name="parameterIndex">One-based index of the parameter to be set.</param>
            /// <param name="parameter">The object containing the input parameter value.</param>
            public void SetValue(DbCommand command, int parameterIndex, object parameter)
            {
                if (command.Parameters.Count < parameterIndex)
                {
                    command.Parameters.Add(command.CreateParameter());
                }

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
                {
                    command.Parameters.Add(command.CreateParameter());
                }

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
            public void SetObject(DbCommand command, int parameterIndex, object parameter, int targetSqlType)
            {
                if (command.Parameters.Count < parameterIndex)
                {
                    command.Parameters.Add(command.CreateParameter());
                }

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
            public void SetObject(DbCommand command, int parameterIndex, object parameter)
            {
                if (command.Parameters.Count < parameterIndex)
                {
                    command.Parameters.Add(command.CreateParameter());
                }

                command.Parameters[parameterIndex - 1].Value = parameter;
            }

            /// <summary>
            /// This method is for such prepared statements verify if the connection is autoCommit for assign the transaction to the command.
            /// </summary>
            /// <param name="command">The command to be tested.</param>
            /// <returns>The number of rows affected.</returns>
            public int ExecuteUpdate(DbCommand command)
            {
                if (!((ConnectionProperties)this[command.Connection]).AutoCommit)
                {
                    command.Transaction = ((ConnectionProperties)this[command.Connection]).Transaction;
                    return command.ExecuteNonQuery();
                }
                else
                {
                    return command.ExecuteNonQuery();
                }
            }

            /// <summary>
            /// This method Closes the connection, and if the property of auto commit is true make the commit operation.
            /// </summary>
            /// <param name="connection"> The command to be closed.</param>
            public void Close(OdbcConnection connection)
            {
                if ((this[connection] != null) && !((ConnectionProperties)this[connection]).AutoCommit)
                {
                    Commit(connection);
                }

                connection.Close();
            }

            private class ConnectionProperties
            {
                public bool AutoCommit { get; set; }

                public DbTransaction Transaction { get; set; }

                public IsolationLevel TransactionLevel { get; set; }
            }
        }
    }
}