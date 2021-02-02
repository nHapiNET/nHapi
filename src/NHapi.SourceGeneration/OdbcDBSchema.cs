namespace NHapi.SourceGeneration
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using System.Data.Odbc;

    /// <summary>
    /// Manager for the connection with the database.
    /// </summary>
    public class OdbcDBSchema
    {
        private DataTable schemaData = null;
        private OdbcConnection Connection;
        private ConnectionState ConnectionState;

        /// <summary>
        /// Constructs a new member with the provided connection.
        /// </summary>
        /// <param name="Connection">The connection to assign to the new member.</param>
        public OdbcDBSchema(OdbcConnection Connection)
        {
            this.Connection = Connection;
        }

        /// <summary>
        /// Gets the Driver name of the connection.
        /// </summary>
        public string DriverName
        {
            get
            {
                string result = string.Empty;
                OpenConnection();
                result = Connection.Driver;
                CloseConnection();
                return result;
            }
        }

        /// <summary>
        /// Opens the connection.
        /// </summary>
        private void OpenConnection()
        {
            ConnectionState = Connection.State;
            Connection.Close();
            Connection.Open();
            schemaData = null;
        }

        /// <summary>
        /// Closes the connection.
        /// </summary>
        private void CloseConnection()
        {
            if (this.ConnectionState == ConnectionState.Open)
            {
                Connection.Close();
            }
        }

        /// <summary>
        /// Gets the info of the row.
        /// </summary>
        /// <param name="filter">Filter to apply to the row.</param>
        /// <param name="RowName">The row from which to obtain the filter.</param>
        /// <returns>A new String with the info from the row.</returns>
        private string GetMaxInfo(string filter, string RowName)
        {
            string result = string.Empty;
            schemaData = null;
            OpenConnection();
            schemaData = Connection.GetSchema("DbInfoLiterals", null);
            foreach (DataRow DataRow in schemaData.Rows)
            {
                if (DataRow["LiteralName"].ToString() == filter)
                {
                    result = DataRow[RowName].ToString();
                    break;
                }
            }

            CloseConnection();
            return result;
        }

        /// <summary>
        /// Gets the catalogs from the database to which it is connected.
        /// </summary>
        public DataTable Catalogs
        {
            get
            {
                OpenConnection();
                schemaData = Connection.GetSchema("Catalogs", null);
                CloseConnection();
                return schemaData;
            }
        }

        /// <summary>
        /// Gets the OleDBConnection for the current member.
        /// </summary>
        /// <returns></returns>
        public OdbcConnection GetConnection()
        {
            return Connection;
        }

        /// <summary>
        /// Gets a description of the stored procedures available.
        /// </summary>
        /// <param name="catalog">The catalog from which to obtain the procedures.</param>
        /// <param name="schemaPattern">Schema pattern, retrieves those without the schema.</param>
        /// <param name="procedureNamePattern">a procedure name pattern.</param>
        /// <returns>each row but withing a procedure description.</returns>
        public DataTable GetProcedures(string catalog, string schemaPattern, string procedureNamePattern)
        {
            OpenConnection();
            schemaData = Connection.GetSchema(
                "Procedures",
                new[] { catalog, schemaPattern, procedureNamePattern, null });
            CloseConnection();
            return schemaData;
        }

        /// <summary>
        /// Gets a collection of the descriptions of the stored procedures parameters and result columns.
        /// </summary>
        /// <param name="catalog">Retrieves those without a catalog.</param>
        /// <param name="schemaPattern">Schema pattern, retrieves those without the schema.</param>
        /// <param name="procedureNamePattern">a procedure name pattern.</param>
        /// <param name="columnNamePattern">a columng name patterm.</param>
        /// <returns>Each row but withing a procedure description or column.</returns>
        public DataTable GetProcedureColumns(string catalog, string schemaPattern, string procedureNamePattern,
            string columnNamePattern)
        {
            OpenConnection();
            schemaData = Connection.GetSchema(
                "Procedure_Parameters",
                new[] { catalog, schemaPattern, procedureNamePattern, columnNamePattern });
            CloseConnection();
            return schemaData;
        }

        /// <summary>
        /// Gets a description of the tables available for the catalog.
        /// </summary>
        /// <param name="catalog">A catalog, retrieves those without a catalog.</param>
        /// <param name="schemaPattern">Schema pattern, retrieves those without the schema.</param>
        /// <param name="tableNamePattern">A table name pattern.</param>
        /// <param name="types">a list of table types to include.</param>
        /// <returns>Each row.</returns>
        public DataTable GetTables(string catalog, string schemaPattern, string tableNamePattern, string[] types)
        {
            OpenConnection();
            schemaData = Connection.GetSchema(
                "Tables",
                new[] { catalog, schemaPattern, tableNamePattern, types[0] });
            if (types != null)
            {
                for (int i = 1; i < types.Length; i++)
                {
                    DataTable temp_Table = Connection.GetSchema(
                        "Tables",
                        new[] { catalog, schemaPattern, tableNamePattern, types[i] });
                    for (int j = 0; j < temp_Table.Rows.Count; j++)
                    {
                        schemaData.ImportRow(temp_Table.Rows[j]);
                    }
                }
            }

            CloseConnection();
            return schemaData;
        }

        /// <summary>
        /// Gets a description of the table rights.
        /// </summary>
        /// <param name="catalog">A catalog, retrieves those without a catalog.</param>
        /// <param name="schemaPattern">Schema pattern, retrieves those without the schema.</param>
        /// <param name="tableNamePattern">A table name pattern.</param>
        /// <returns>A description of the table rights.</returns>
        public DataTable GetTablePrivileges(string catalog, string schemaPattern, string tableNamePattern)
        {
            OpenConnection();
            schemaData = Connection.GetSchema(
                "Table_Privileges",
                new[] { catalog, schemaPattern, tableNamePattern });
            CloseConnection();
            return schemaData;
        }

        /// <summary>
        /// Gets the table types available.
        /// </summary>
        public DataTable TableTypes
        {
            get
            {
                OpenConnection();
                schemaData = Connection.GetSchema("Tables", null);
                ArrayList tableTypes = new ArrayList(schemaData.Rows.Count);

                string tableType = string.Empty;
                foreach (DataRow DataRow in schemaData.Rows)
                {
                    tableType = DataRow[schemaData.Columns["TABLE_TYPE"]].ToString();
                    if (! tableTypes.Contains(tableType))
                    {
                        tableTypes.Add(tableType);
                    }
                }

                schemaData = new DataTable();
                schemaData.Columns.Add("TABLE_TYPE");
                for (int index = 0; index < tableTypes.Count; index++)
                {
                    schemaData.Rows.Add(new object[] { tableTypes[index] });
                }

                CloseConnection();
                return schemaData;
            }
        }

        /// <summary>
        /// Gets a description of the table columns available.
        /// </summary>
        /// <param name="catalog">A catalog, retrieves those without a catalog.</param>
        /// <param name="schemaPattern">Schema pattern, retrieves those without the schema.</param>
        /// <param name="tableNamePattern">A table name pattern.</param>
        /// <param name="columnNamePattern">a columng name patterm.</param>
        /// <returns>A description of the table columns available.</returns>
        public DataTable GetColumns(string catalog, string schemaPattern, string tableNamePattern, string columnNamePattern)
        {
            OpenConnection();
            schemaData = Connection.GetSchema(
                "Columns",
                new[] { catalog, schemaPattern, tableNamePattern, columnNamePattern });
            CloseConnection();
            return schemaData;
        }

        /// <summary>
        /// Gets a description of the primary keys available.
        /// </summary>
        /// <param name="catalog">A catalog, retrieves those without a catalog.</param>
        /// <param name="schema">Schema name, retrieves those without the schema.</param>
        /// <param name="table">A table name.</param>
        /// <returns>A description of the primary keys available.</returns>
        public DataTable GetPrimaryKeys(string catalog, string schema, string table)
        {
            OpenConnection();
            schemaData = Connection.GetSchema("Primary_Keys", new[] { catalog, schema, table });
            CloseConnection();
            return schemaData;
        }

        /// <summary>
        /// Gets a description of the foreign keys available.
        /// </summary>
        /// <param name="catalog">A catalog, retrieves those without a catalog.</param>
        /// <param name="schema">Schema name, retrieves those without the schema.</param>
        /// <param name="table">A table name.</param>
        /// <returns>A description of the foreign keys available.</returns>
        public DataTable GetForeignKeys(string catalog, string schema, string table)
        {
            OpenConnection();
            schemaData = Connection.GetSchema("Foreign_Keys", new[] { catalog, schema, table });
            CloseConnection();
            return schemaData;
        }

        /// <summary>
        /// Gets a description of the access rights for a table columns.
        /// </summary>
        /// <param name="catalog">A catalog, retrieves those without a catalog.</param>
        /// <param name="schema">Schema name, retrieves those without the schema.</param>
        /// <param name="table">A table name.</param>
        /// <param name="columnNamePattern">A column name patter.</param>
        /// <returns>A description of the access rights for a table columns.</returns>
        public DataTable GetColumnPrivileges(string catalog, string schema, string table, string columnNamePattern)
        {
            OpenConnection();
            schemaData = Connection.GetSchema(
                "Column_Privileges",
                new[] { catalog, schema, table, columnNamePattern });
            CloseConnection();
            return schemaData;
        }

        /// <summary>
        /// Gets the provider version.
        /// </summary>
        public string ProviderVersion
        {
            get
            {
                string result = string.Empty;
                OpenConnection();
                result = Connection.ServerVersion;
                CloseConnection();
                return result;
            }
        }

        /// <summary>
        /// Gets the default transaction isolation integer value.
        /// </summary>
        public int DefaultTransactionIsolation
        {
            get
            {
                int result = -1;
                OpenConnection();
                DbTransaction Transaction = Connection.BeginTransaction();
                result = (int)Transaction.IsolationLevel;
                CloseConnection();
                return result;
            }
        }

        /// <summary>
        /// Gets the schemata for the member.
        /// </summary>
        public DataTable Schemata
        {
            get
            {
                OpenConnection();
                schemaData = Connection.GetSchema("Schemata", null);
                CloseConnection();
                return schemaData;
            }
        }

        /// <summary>
        /// Gets the provider types for the member.
        /// </summary>
        public DataTable ProviderTypes
        {
            get
            {
                OpenConnection();
                schemaData = Connection.GetSchema("Provider_Types", null);
                CloseConnection();
                return schemaData;
            }
        }

        /// <summary>
        /// Gets the catalog separator.
        /// </summary>
        public string CatalogSeparator
        {
            get { return GetMaxInfo("Catalog_Separator", "LiteralValue"); }
        }

        /// <summary>
        /// Gets the maximum binary length permited.
        /// </summary>
        public int MaxBinaryLiteralLength
        {
            get
            {
                string len = GetMaxInfo("Binary_Literal", "Maxlen");
                if (len.Equals(string.Empty))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(len) * 4;
                }
            }
        }

        /// <summary>
        /// Gets the maximum catalog name length permited.
        /// </summary>
        public int MaxCatalogNameLength
        {
            get
            {
                string len = GetMaxInfo("Catalog_Name", "Maxlen");
                if (len.Equals(string.Empty))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(len);
                }
            }
        }

        /// <summary>
        /// Gets the maximum character literal length permited.
        /// </summary>
        public int MaxCharLiteralLength
        {
            get
            {
                string len = GetMaxInfo("Char_Literal", "Maxlen");
                if (len.Equals(string.Empty))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(len) * 4;
                }
            }
        }

        /// <summary>
        /// Gets the maximum column name length.
        /// </summary>
        public int MaxColumnNameLength
        {
            get
            {
                string len = GetMaxInfo("Column_Name", "Maxlen");
                if (len.Equals(string.Empty))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(len);
                }
            }
        }

        /// <summary>
        /// Gets the maximum cursor name length.
        /// </summary>
        public int MaxCursorNameLength
        {
            get
            {
                string len = GetMaxInfo("Cursor_Name", "Maxlen");
                if (len.Equals(string.Empty))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(len);
                }
            }
        }

        /// <summary>
        /// Gets the maximum procedure name length.
        /// </summary>
        public int MaxProcedureNameLength
        {
            get
            {
                string len = GetMaxInfo("Procedure_Name", "Maxlen");
                if (len.Equals(string.Empty))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(len);
                }
            }
        }

        /// <summary>
        /// Gets the maximum schema name length.
        /// </summary>
        public int MaxSchemaNameLength
        {
            get
            {
                string len = GetMaxInfo("Schema_Name", "Maxlen");
                if (len.Equals(string.Empty))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(len);
                }
            }
        }

        /// <summary>
        /// Gets the maximum table name length.
        /// </summary>
        public int MaxTableNameLength
        {
            get
            {
                string len = GetMaxInfo("Table_Name", "Maxlen");
                if (len.Equals(string.Empty))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(len);
                }
            }
        }

        /// <summary>
        /// Gets the maximum user name length.
        /// </summary>
        public int MaxUserNameLength
        {
            get
            {
                string len = GetMaxInfo("User_Name", "Maxlen");
                if (len.Equals(string.Empty))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(len);
                }
            }
        }
    }

}