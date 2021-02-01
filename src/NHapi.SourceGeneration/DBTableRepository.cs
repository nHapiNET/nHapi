/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "DBTableRepository.java".  Description:
  "Implements TableRepository by looking up values from the default HL7
  normative database" 
  
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

using System;
using System.Collections;
using System.Data.Common;
using System.Data.Odbc;
using System.Text;

using NHapi.Base.Log;

namespace NHapi.SourceGeneration
{
   /// <summary> Implements TableRepository by looking up values from the default HL7
   /// normative database.  Values are cached after they are looked up once.
   /// </summary>
   /// <author>  Bryan Tripp (bryan_tripp@sourceforge.net)
   /// </author>
   public class DBTableRepository : TableRepository
    {
        /// <summary> Returns a list of HL7 lookup tables that are defined in the normative database.  </summary>
        public override int[] Tables
        {
            get
            {
                if (tableList == null)
                {
                    try
                    {
                        OdbcConnection conn = NormativeDatabase.Instance.Connection;
                        DbCommand stmt = TransactionManager.manager.CreateStatement(conn);
                        DbCommand temp_OleDbCommand;
                        temp_OleDbCommand = stmt;
                        temp_OleDbCommand.CommandText = "select distinct table_id from TableValues";
                        DbDataReader rs = temp_OleDbCommand.ExecuteReader();
                        int[] roomyList = new int[bufferSize];
                        int c = 0;
                        while (rs.Read())
                        {
                            roomyList[c++] = rs.GetInt32(1 - 1);
                        }

                        stmt.Dispose();
                        NormativeDatabase.Instance.returnConnection(conn);

                        tableList = new int[c];
                        Array.Copy(roomyList, 0, tableList, 0, c);
                    }
                    catch (DbException sqle)
                    {
                        throw new LookupException("Can't get table list from database: " + sqle.Message);
                    }
                }

                return tableList;
            }
        }

        private static readonly IHapiLog log;

        private int[] tableList;
        private Hashtable tables;
        private int bufferSize = 3000; // max # of tables or values that can be cached at a time

        /// <summary>
        /// Table repository
        /// </summary>
        protected internal DBTableRepository()
        {
            tableList = null;
            tables = new Hashtable();
        }

        /// <summary> Returns true if the given value exists in the given table.</summary>
        public override bool checkValue(int table, String value_Renamed)
        {
            bool exists = false;

            String[] values = getValues(table);

            int c = 0;
            while (c < values.Length && !exists)
            {
                if (value_Renamed.Equals(values[c++]))
                    exists = true;
            }

            return exists;
        }

        /// <summary> Returns a list of the values for the given table in the normative database. </summary>
        public override String[] getValues(int table)
        {
            Int32 key = (Int32)table;
            String[] values = null;

            // see if the value list exists in the cache
            Object o = tables[key];

            if (o != null)
            {
                values = (String[])o;
            }
            else
            {
                // not cached yet ...
                int c;
                String[] roomyValues = new String[bufferSize];

                try
                {
                    OdbcConnection conn = NormativeDatabase.Instance.Connection;
                    DbCommand stmt = TransactionManager.manager.CreateStatement(conn);
                    StringBuilder sql = new StringBuilder("select table_value from TableValues where table_id = ");
                    sql.Append(table);
                    DbCommand temp_OleDbCommand;
                    temp_OleDbCommand = stmt;
                    temp_OleDbCommand.CommandText = sql.ToString();
                    DbDataReader rs = temp_OleDbCommand.ExecuteReader();

                    c = 0;
                    while (rs.Read())
                    {
                        roomyValues[c++] = Convert.ToString(rs[1 - 1]);
                    }

                    stmt.Dispose();
                    NormativeDatabase.Instance.returnConnection(conn);
                }
                catch (DbException sqle)
                {
                    throw new LookupException("Couldn't look up values for table " + table + ": " + sqle.Message);
                }

                if (c == 0)
                    throw new UndefinedTableException("No values found for table " + table);

                values = new String[c];
                Array.Copy(roomyValues, 0, values, 0, c);

                tables[key] = values;
            }

            return values;
        }

        /// <summary> Returns the description matching the table and value given.  As currently implemented
        /// this method performs a database call each time - caching should probably be added,
        /// although this method will probably not be used very often.
        /// </summary>
        public override String getDescription(int table, String value_Renamed)
        {
            String description = null;

            StringBuilder sql = new StringBuilder("select Description from TableValues where table_id = ");
            sql.Append(table);
            sql.Append(" and table_value = '");
            sql.Append(value_Renamed);
            sql.Append("'");

            try
            {
                OdbcConnection conn = NormativeDatabase.Instance.Connection;
                DbCommand stmt = TransactionManager.manager.CreateStatement(conn);
                DbCommand temp_OleDbCommand;
                temp_OleDbCommand = stmt;
                temp_OleDbCommand.CommandText = sql.ToString();
                DbDataReader rs = temp_OleDbCommand.ExecuteReader();
                if (rs.Read())
                {
                    description = Convert.ToString(rs[1 - 1]);
                }
                else
                {
                    throw new UnknownValueException("The value " + value_Renamed + " could not be found in the table " + table +
                                                              " - SQL: " + sql.ToString());
                }

                stmt.Dispose();
                NormativeDatabase.Instance.returnConnection(conn);
            }
            catch (DbException e)
            {
                throw new LookupException("Can't find value " + value_Renamed + " in table " + table, e);
            }

            return description;
        }


        static DBTableRepository()
        {
            log = HapiLogFactory.GetHapiLog(typeof(DBTableRepository));
        }
    }
}