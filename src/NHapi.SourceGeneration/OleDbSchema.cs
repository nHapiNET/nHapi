namespace NHapi.SourceGeneration
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using System.Data.OleDb;

    /// <summary>
    /// Manager for the connection with the database.
    /// </summary>
    public class OleDbSchema
    {
        /// <summary>
        /// Constructs a new member with the provided connection.
        /// </summary>
        /// <param name="connection">The connection to assign to the new member.</param>
        public OleDbSchema(OleDbConnection connection)
        {
            this.Connection = connection;
        }

        /// <summary>
        /// Gets the Driver name of the connection.
        /// </summary>
        public string DriverName
        {
            get
            {
                var result = string.Empty;
                OpenConnection();
                result = Connection.Provider;
                CloseConnection();
                return result;
            }
        }

        /// <summary>
        /// Gets the provider version.
        /// </summary>
        public string ProviderVersion
        {
            get
            {
                var result = string.Empty;
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
                var result = -1;
                OpenConnection();
                DbTransaction transaction = Connection.BeginTransaction();
                result = (int)transaction.IsolationLevel;
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
                SchemaData = Connection.GetSchema("Schemata", null);
                CloseConnection();
                return SchemaData;
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
                SchemaData = Connection.GetSchema("Provider_Types", null);
                CloseConnection();
                return SchemaData;
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
        /// Gets the maximum binary length permitted.
        /// </summary>
        public int MaxBinaryLiteralLength
        {
            get
            {
                var len = GetMaxInfo("Binary_Literal", "Maxlen");
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
        /// Gets the maximum catalog name length permitted.
        /// </summary>
        public int MaxCatalogNameLength
        {
            get
            {
                var len = GetMaxInfo("Catalog_Name", "Maxlen");
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
        /// Gets the maximum character literal length permitted.
        /// </summary>
        public int MaxCharLiteralLength
        {
            get
            {
                var len = GetMaxInfo("Char_Literal", "Maxlen");
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
                var len = GetMaxInfo("Column_Name", "Maxlen");
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
                var len = GetMaxInfo("Cursor_Name", "Maxlen");
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
                var len = GetMaxInfo("Procedure_Name", "Maxlen");
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
                var len = GetMaxInfo("Schema_Name", "Maxlen");
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
                var len = GetMaxInfo("Table_Name", "Maxlen");
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
                var len = GetMaxInfo("User_Name", "Maxlen");
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
        /// Gets the catalogs from the database to which it is connected.
        /// </summary>
        public DataTable Catalogs
        {
            get
            {
                OpenConnection();
                SchemaData = Connection.GetSchema("Catalogs", null);
                CloseConnection();
                return SchemaData;
            }
        }

        /// <summary>
        /// Gets the table types available.
        /// </summary>
        public DataTable TableTypes
        {
            get
            {
                OpenConnection();
                SchemaData = Connection.GetSchema("Tables", null);
                var tableTypes = new ArrayList(SchemaData.Rows.Count);

                var tableType = string.Empty;
                foreach (DataRow dataRow in SchemaData.Rows)
                {
                    tableType = dataRow[SchemaData.Columns["TABLE_TYPE"]].ToString();
                    if (!tableTypes.Contains(tableType))
                    {
                        tableTypes.Add(tableType);
                    }
                }

                SchemaData = new DataTable();
                SchemaData.Columns.Add("TABLE_TYPE");
                for (var index = 0; index < tableTypes.Count; index++)
                {
                    SchemaData.Rows.Add(new[] { tableTypes[index] });
                }

                CloseConnection();
                return SchemaData;
            }
        }

        private OleDbConnection Connection { get; }

        private ConnectionState ConnectionState { get; set; }

        private DataTable SchemaData { get; set; }

        /// <summary>
        /// Gets the OleDBConnection for the current member.
        /// </summary>
        /// <returns></returns>
        public OleDbConnection GetConnection()
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
            SchemaData = Connection.GetSchema(
                "Procedures",
                new[] { catalog, schemaPattern, procedureNamePattern, null });
            CloseConnection();
            return SchemaData;
        }

        /// <summary>
        /// Gets a collection of the descriptions of the stored procedures parameters and result columns.
        /// </summary>
        /// <param name="catalog">Retrieves those without a catalog.</param>
        /// <param name="schemaPattern">Schema pattern, retrieves those without the schema.</param>
        /// <param name="procedureNamePattern">a procedure name pattern.</param>
        /// <param name="columnNamePattern">a column name pattern.</param>
        /// <returns>Each row but withing a procedure description or column.</returns>
        public DataTable GetProcedureColumns(
            string catalog,
            string schemaPattern,
            string procedureNamePattern,
            string columnNamePattern)
        {
            OpenConnection();
            SchemaData = Connection.GetSchema(
                "Procedure_Parameters",
                new[] { catalog, schemaPattern, procedureNamePattern, columnNamePattern });
            CloseConnection();
            return SchemaData;
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
            SchemaData = Connection.GetSchema(
                "Tables",
                new[] { catalog, schemaPattern, tableNamePattern, types[0] });

            for (var i = 1; i < types.Length; i++)
            {
                var tempTable = Connection.GetSchema(
                    "Tables",
                    new[] { catalog, schemaPattern, tableNamePattern, types[i] });
                for (var j = 0; j < tempTable.Rows.Count; j++)
                {
                    SchemaData.ImportRow(tempTable.Rows[j]);
                }
            }

            CloseConnection();
            return SchemaData;
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
            SchemaData = Connection.GetSchema(
                "Table_Privileges",
                new[] { catalog, schemaPattern, tableNamePattern });
            CloseConnection();
            return SchemaData;
        }

        /// <summary>
        /// Gets a description of the table columns available.
        /// </summary>
        /// <param name="catalog">A catalog, retrieves those without a catalog.</param>
        /// <param name="schemaPattern">Schema pattern, retrieves those without the schema.</param>
        /// <param name="tableNamePattern">A table name pattern.</param>
        /// <param name="columnNamePattern">a column name pattern.</param>
        /// <returns>A description of the table columns available.</returns>
        public DataTable GetColumns(string catalog, string schemaPattern, string tableNamePattern, string columnNamePattern)
        {
            OpenConnection();
            SchemaData = Connection.GetSchema(
                "Columns",
                new[] { catalog, schemaPattern, tableNamePattern, columnNamePattern });
            CloseConnection();
            return SchemaData;
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
            SchemaData = Connection.GetSchema("Primary_Keys", new[] { catalog, schema, table });
            CloseConnection();
            return SchemaData;
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
            SchemaData = Connection.GetSchema("Foreign_Keys", new[] { catalog, schema, table });
            CloseConnection();
            return SchemaData;
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
            SchemaData = Connection.GetSchema(
                "Column_Privileges",
                new[] { catalog, schema, table, columnNamePattern });
            CloseConnection();
            return SchemaData;
        }

        /// <summary>
        /// Opens the connection.
        /// </summary>
        private void OpenConnection()
        {
            ConnectionState = Connection.State;
            Connection.Close();
            Connection.Open();
            SchemaData = null;
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
        /// <param name="rowName">The row from which to obtain the filter.</param>
        /// <returns>A new String with the info from the row.</returns>
        private string GetMaxInfo(string filter, string rowName)
        {
            var result = string.Empty;
            SchemaData = null;
            OpenConnection();
            SchemaData = Connection.GetSchema("DbInfoLiterals", null);
            foreach (DataRow dataRow in SchemaData.Rows)
            {
                if (dataRow["LiteralName"].ToString() == filter)
                {
                    result = dataRow[rowName].ToString();
                    break;
                }
            }

            CloseConnection();
            return result;
        }
    }
}