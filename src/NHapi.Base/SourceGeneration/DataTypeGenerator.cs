/// <summary>The contents of this file are subject to the Mozilla Public License Version 1.1 
/// (the "License"); you may not use this file except in compliance with the License. 
/// You may obtain a copy of the License at http://www.mozilla.org/MPL/ 
/// Software distributed under the License is distributed on an "AS IS" basis, 
/// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the 
/// specific language governing rights and limitations under the License. 
/// The Original Code is "DataTypeGenerator.java".  Description: 
/// "Generates skeletal source code for Datatype classes based on the 
/// HL7 database" 
/// The Initial Developer of the Original Code is University Health Network. Copyright (C) 
/// 2001.  All Rights Reserved. 
/// Contributor(s):  Eric Poiseau. 
/// Alternatively, the contents of this file may be used under the terms of the 
/// GNU General Public License (the  “GPL”), in which case the provisions of the GPL are 
/// applicable instead of those above.  If you wish to allow use of your version of this 
/// file only under the terms of the GPL and not to allow others to use your version 
/// of this file under the MPL, indicate your decision by deleting  the provisions above 
/// and replace  them with the notice and other provisions required by the GPL License.  
/// If you do not delete the provisions above, a recipient may use your version of 
/// this file under either the MPL or the GPL. 
/// </summary>

using System;
using System.Collections;
using System.Data.Common;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Text;
using NHapi.Base.Log;

namespace NHapi.Base.SourceGeneration
{
	/// <summary> Generates skeletal source code for Datatype classes based on the 
	/// HL7 database.  
	/// </summary>
	/// <author>  Bryan Tripp (bryan_tripp@sourceforge.net)
	/// </author>
	/// <author>  Eric Poiseau
	/// </author>
	public class DataTypeGenerator : Object
	{
		private static readonly IHapiLog log;

		/// <summary> Creates skeletal source code (without correct data structure but no business
		/// logic) for all data types found in the normative database.  For versions > 2.2, Primitive data types
		/// are not generated, because they are coded manually (as of HAPI 0.3).  
		/// </summary>
		public static void makeAll(String baseDirectory, String version)
		{
			//make base directory
			if (!(baseDirectory.EndsWith("\\") || baseDirectory.EndsWith("/")))
			{
				baseDirectory = baseDirectory + "/";
			}
			FileInfo targetDir =
				SourceGenerator.makeDirectory(baseDirectory + PackageManager.GetVersionPackagePath(version) + "Datatype");
			SourceGenerator.makeDirectory(baseDirectory + PackageManager.GetVersionPackagePath(version) + "Datatype");
			//get list of data types
			ArrayList types = new ArrayList();
			OdbcConnection conn = NormativeDatabase.Instance.Connection;
			DbCommand stmt = SupportClass.TransactionManager.manager.CreateStatement(conn);
			//get normal data types ... 
			DbCommand temp_OleDbCommand;
			temp_OleDbCommand = stmt;
			temp_OleDbCommand.CommandText =
				"select data_type_code from HL7DataTypes, HL7Versions where HL7Versions.version_id = HL7DataTypes.version_id and HL7Versions.hl7_version = '" +
				version + "'";
			DbDataReader rs = temp_OleDbCommand.ExecuteReader();
			while (rs.Read())
			{
				types.Add(Convert.ToString(rs[1 - 1]));
			}
			rs.Close();
			//get CF, CK, CM, CN, CQ sub-types ... 

			DbCommand temp_OleDbCommand2;
			temp_OleDbCommand2 = stmt;
			temp_OleDbCommand2.CommandText = "select data_structure from HL7DataStructures, HL7Versions where (" +
			                                 "data_type_code  = 'CF' or " + "data_type_code  = 'CK' or " +
			                                 "data_type_code  = 'CM' or " + "data_type_code  = 'CN' or " +
			                                 "data_type_code  = 'CQ') and " +
			                                 "HL7Versions.version_id = HL7DataStructures.version_id and  HL7Versions.hl7_version = '" +
			                                 version + "'";
			rs = temp_OleDbCommand2.ExecuteReader();
			while (rs.Read())
			{
				types.Add(Convert.ToString(rs[1 - 1]));
			}

			stmt.Dispose();
			NormativeDatabase.Instance.returnConnection(conn);

			Console.Out.WriteLine("Generating " + types.Count + " datatypes for version " + version);
			if (types.Count == 0)
			{
				log.Warn("No version " + version + " data types found in database " + conn.Database);
			}

			foreach (string type in types.Cast<string>())
			{
				if (!type.Equals("*"))
					make(targetDir, type, version);
			}
		}

		/// <summary> Creates source code for a single data type in the HL7 normative
		/// database. 
		/// </summary>
		/// <param name="targetDirectory">the directory into which the file will be written
		/// </param>
		/// <param name="datatype">the name (e.g. ST, ID, etc.) of the data type to be created
		/// </param>
		/// <param name="version">the HL7 version of the intended data type
		/// </param>
		public static void make(FileInfo targetDirectory, String dataType, String version)
		{
			Console.WriteLine(" Writing " + targetDirectory.FullName + dataType);
			//make sure that targetDirectory is a directory ... 
			if (!Directory.Exists(targetDirectory.FullName))
				throw new IOException("Can't create file in " + targetDirectory + " - it is not a directory.");

			//get any components for this data type
			OdbcConnection conn = NormativeDatabase.Instance.Connection;
			DbCommand stmt = SupportClass.TransactionManager.manager.CreateStatement(conn);
			StringBuilder sql = new StringBuilder();
			//this query is adapted from the XML SIG informative document
			sql.Append(
				"SELECT HL7DataStructures.data_structure, HL7DataStructureComponents.seq_no, HL7DataStructures.description, HL7DataStructureComponents.table_id,  ");
			sql.Append(
				"HL7Components.description, HL7Components.table_id, HL7Components.data_type_code, HL7Components.data_structure ");
			sql.Append(
				"FROM HL7Versions LEFT JOIN (HL7DataStructures LEFT JOIN (HL7DataStructureComponents LEFT JOIN HL7Components ");
			sql.Append("ON HL7DataStructureComponents.comp_no = HL7Components.comp_no AND ");
			sql.Append("HL7DataStructureComponents.version_id = HL7Components.version_id) ");
			sql.Append("ON HL7DataStructures.version_id = HL7DataStructureComponents.version_id ");
			sql.Append("AND HL7DataStructures.data_structure = HL7DataStructureComponents.data_structure) ");
			sql.Append("ON HL7DataStructures.version_id = HL7Versions.version_id ");
			sql.Append("WHERE HL7DataStructures.data_structure = '");
			sql.Append(dataType);
			sql.Append("' AND HL7Versions.hl7_version = '");
			sql.Append(version);
			sql.Append("' ORDER BY HL7DataStructureComponents.seq_no");
			DbCommand temp_OleDbCommand;
			temp_OleDbCommand = stmt;
			temp_OleDbCommand.CommandText = sql.ToString();
			DbDataReader rs = temp_OleDbCommand.ExecuteReader();

			ArrayList dataTypes = new ArrayList(20);
			ArrayList descriptions = new ArrayList(20);
			ArrayList tables = new ArrayList(20);
			String description = null;
			while (rs.Read())
			{
				if (description == null)
					description = Convert.ToString(rs[3 - 1]);

				String de = Convert.ToString(rs[5 - 1]);
				String dt = Convert.ToString(rs[8 - 1]);
				int ta = -1;
				if (!rs.IsDBNull(4 - 1))
					ta = rs.GetInt32(4 - 1);
				//trim all CE_x to CE
				if (dt != null)
					if (dt.StartsWith("CE"))
						dt = "CE";
				//System.out.println("Component: " + de + "  Data Type: " + dt);  //for debugging
				dataTypes.Add(dt);
				descriptions.Add(de);
				tables.Add(ta);
			}
			if (dataType.ToUpper().Equals("TS"))
			{
				dataTypes[0] = "TSComponentOne";
			}

			rs.Close();
			stmt.Dispose();
			NormativeDatabase.Instance.returnConnection(conn);

			//if there is only one component make a Primitive, otherwise make a Composite
			String source = null;
			if (dataTypes.Count == 1)
			{
				if (dataType.Equals("FT") || dataType.Equals("ST") || dataType.Equals("TX") || dataType.Equals("NM") ||
				    dataType.Equals("SI") || dataType.Equals("TN") || dataType.Equals("GTS"))
				{
					source = makePrimitive(dataType, description, version);
				}
				else
				{
					source = null; //note: IS, ID, DT, DTM, and TM are coded manually
				}
			}
			else if (dataTypes.Count > 1)
			{
				int numComponents = dataTypes.Count;
				//copy data into arrays ... 
				String[] type = new String[numComponents];
				String[] desc = new String[numComponents];
				int[] table = new int[numComponents];
				for (int i = 0; i < numComponents; i++)
				{
					type[i] = ((String) dataTypes[i]);
					desc[i] = ((String) descriptions[i]);
					table[i] = ((Int32) tables[i]);
				}
				source = makeComposite(dataType, description, type, desc, table, version);
			}
			else
			{
				//no components?  
				//throw new DataTypeException("The data type " + dataType + " could not be found");
				Console.WriteLine("No components for " + dataType);
			}
			//System.out.println(source);

			//write to file ... 
			if (source != null)
			{
				String targetFile = targetDirectory + "/" + dataType + ".cs";
				using (StreamWriter writer = new StreamWriter(targetFile))
				{
					writer.Write(source);
					writer.Write("}"); //End namespace
				}
			}
			else
				Console.WriteLine("No Source for " + dataType);
		}

		/// <summary> Returns a String containing the complete source code for a Primitive HL7 data
		/// type.  Note: this method is no longer used, as all Primitives are now coded manually.  
		/// </summary>
		private static String makePrimitive(String datatype, String description, String version)
		{
			StringBuilder source = new StringBuilder();

			source.Append("using System;\n");
			source.Append("using NHapi.Base.Model;\n");
			source.Append("using NHapi.Base;\n");
			source.Append("using NHapi.Base.Model.Primitive;\r\n");
			source.Append("namespace ");
			source.Append(PackageManager.GetVersionPackageName(version));
			source.Append("Datatype\r\n");
			source.Append("{\r\n");
			source.Append("///<summary>\r\n");
			source.Append("///Represents the HL7 ");
			source.Append(datatype);
			source.Append(" (");
			source.Append(description);
			source.Append(") datatype.  A ");
			source.Append(datatype);
			source.Append(" contains a single String value.\r\n");
			source.Append("///</summary>\r\n");
			source.Append("[Serializable]\r\n");
			source.Append("public class ");
			source.Append(datatype);
			source.Append(" : AbstractPrimitive ");
			source.Append(" {\r\n\r\n");
			//source.append("\tprotected String value;\r\n\r\n");
			source.Append("\t///<summary>\r\n");
			source.Append("\t///Constructs an uninitialized ");
			source.Append(datatype);
			source.Append(".\r\n");
			source.Append("\t///<param name=\"message\">The Message to which this Type belongs</param>\r\n");
			source.Append("\t///</summary>\r\n");
			source.Append("\tpublic ");
			source.Append(datatype);
			source.Append("(IMessage message) : base(message){\r\n");
			source.Append("\t}\r\n\r\n");

			source.Append("\t///<summary>\r\n");
			source.Append("\t///Constructs an uninitialized ");
			source.Append(datatype);
			source.Append(".\r\n");
			source.Append("\t///<param name=\"message\">The Message to which this Type belongs</param>\r\n");
			source.Append("\t///<param name=\"description\">The description of this type</param>\r\n");
			source.Append("\t///</summary>\r\n");
			source.Append("\tpublic ");
			source.Append(datatype);
			source.Append("(IMessage message, string description) : base(message,description){\r\n");
			source.Append("\t}\r\n\r\n");
			source.Append("\t///<summary>\r\n");
			source.Append("\t///  @return \"");
			source.Append(version);
			source.Append("\"\r\n");
			source.Append("\t///</summary>\r\n");
			source.Append("\tpublic string getVersion() {\r\n");
			source.Append("\t    return \"");
			if (version.IndexOf("UCH") > -1)
				source.Append("2.3");
			else
				source.Append(version);
			source.Append("\";\r\n");
			source.Append("}\r\n");
			source.Append("}\r\n");

			return source.ToString();
		}

		/// <summary> Returns a String containing source code for a Composite data type. The 
		/// dataTypes array contains the data type names (e.g. ST) of each component. 
		/// The descriptions array contains the corresponding descriptions (e.g. string).
		/// </summary>
		private static String makeComposite(String dataType, String description, String[] dataTypes, String[] descriptions,
			int[] tables, String version)
		{
			StringBuilder source = new StringBuilder();
			source.Append("using System;\n");
			source.Append("using NHapi.Base.Model;\n");
			source.Append("using NHapi.Base.Log;\n");
			source.Append("using NHapi.Base;\n");
			source.Append("using NHapi.Base.Model.Primitive;\r\n\r\n");
			source.Append("namespace ");
			source.Append(PackageManager.GetVersionPackageName(version));
			source.Append("Datatype\r\n");
			source.Append("{\r\n\r\n");
			source.Append("///<summary>\r\n");
			source.Append("/// <p>The HL7 ");
			source.Append(dataType);
			source.Append(" (");
			source.Append(description);
			source.Append(") data type.  Consists of the following components: </p><ol>\r\n");
			for (int i = 0; i < dataTypes.Length; i++)
			{
				source.Append("/// <li>");
				source.Append(GetDescription(descriptions[i]));
				source.Append(" (");
				source.Append(dataTypes[i]);
				source.Append(")</li>\r\n");
			}
			source.Append("/// </ol>\r\n");
			source.Append("///</summary>\r\n");
			source.Append("[Serializable]\r\n");
			source.Append("public class ");
			source.Append(dataType);
			source.Append(" : AbstractType, IComposite");
			source.Append("{\r\n");
			source.Append("\tprivate IType[] data;\r\n\r\n");
			source.Append("\t///<summary>\r\n");
			source.Append("\t/// Creates a ");
			source.Append(dataType);
			source.Append(".\r\n");
			source.Append("\t/// <param name=\"message\">The Message to which this Type belongs</param>\r\n");
			source.Append("\t///</summary>\r\n");
			source.Append("\tpublic ");
			source.Append(dataType);
			source.Append("(IMessage message) : this(message, null){}\r\n\r\n");
			source.Append("\t///<summary>\r\n");
			source.Append("\t/// Creates a ");
			source.Append(dataType);
			source.Append(".\r\n");
			source.Append("\t/// <param name=\"message\">The Message to which this Type belongs</param>\r\n");
			source.Append("\t/// <param name=\"description\">The description of this type</param>\r\n");
			source.Append("\t///</summary>\r\n");
			source.Append("\tpublic ");
			source.Append(dataType);
			source.Append("(IMessage message, string description) : base(message, description){\r\n");
			source.Append("\t\tdata = new IType[");
			source.Append(dataTypes.Length);
			source.Append("];\r\n");
			for (int i = 0; i < dataTypes.Length; i++)
			{
				source.Append("\t\tdata[");
				source.Append(i);
				source.Append("] = new ");
				source.Append(SourceGenerator.getAlternateType(dataTypes[i], version));
				if (dataTypes[i].Equals("ID") || dataTypes[i].Equals("IS"))
				{
					source.Append("(message, ");
					source.Append(tables[i]);
				}
				else
				{
					source.Append("(message");
				}
				if (descriptions[i] != null && descriptions[i].Trim().Length > 0)
				{
					string desc = descriptions[i];
					desc = desc.Replace("\"", "'");
					desc = desc.Substring(0, 1).ToUpper() + desc.Substring(1);
					source.Append(",\"" + desc + "\"");
				}
				source.Append(")");
				source.Append(";\r\n");
			}
			source.Append("\t}\r\n\r\n");
			source.Append("\t///<summary>\r\n");
			source.Append("\t/// Returns an array containing the data elements.\r\n");
			source.Append("\t///</summary>\r\n");
			source.Append("\tpublic IType[] Components\r\n");
			source.Append("\t{ \r\n");
			source.Append("\t\tget{\r\n");
			source.Append("\t\t\treturn this.data; \r\n");
			source.Append("\t\t}\r\n");
			source.Append("\t}\r\n\r\n");
			source.Append("\t///<summary>\r\n");
			source.Append("\t/// Returns an individual data component.\r\n");
			source.Append("\t/// @throws DataTypeException if the given element number is out of range.\r\n");
			source.Append("\t///<param name=\"index\">The index item to get (zero based)</param>\r\n");
			source.Append("\t///<returns>The data component (as a type) at the requested number (ordinal)</returns>\r\n");
			source.Append("\t///</summary>\r\n");
			source.Append("\tpublic IType this[int index] { \r\n\r\n");
			source.Append("get{\r\n");
			source.Append("\t\ttry { \r\n");
			source.Append("\t\t\treturn this.data[index]; \r\n");
			source.Append("\t\t} catch (System.ArgumentOutOfRangeException) { \r\n");
			source.Append("\t\t\tthrow new DataTypeException(\"Element \" + index + \" doesn't exist in ");
			source.Append(dataTypes.Length);
			source.Append(" element ");
			source.Append(dataType);
			source.Append(" composite\"); \r\n");
			source.Append("\t\t} \r\n");
			source.Append("\t} \r\n");
			source.Append("\t} \r\n");
			//make type-specific accessors ... 
			for (int i = 0; i < dataTypes.Length; i++)
			{
				String dtName = SourceGenerator.getAlternateType(dataTypes[i], version);
				source.Append("\t///<summary>\r\n");
				source.Append("\t/// Returns ");
				source.Append(GetDescription(descriptions[i]));
				source.Append(" (component #");
				source.Append(i);
				source.Append(").  This is a convenience method that saves you from \r\n");
				source.Append("\t/// casting and handling an exception.\r\n");
				source.Append("\t///</summary>\r\n");
				source.Append("\tpublic ");
				source.Append(dtName);
				source.Append(" ");
				source.Append(SourceGenerator.MakeAccessorName(descriptions[i]));
				bool duplicateField = descriptions.Count(element => GetDescription(element) == GetDescription(descriptions[i])) > 1;
				if (duplicateField)
				{
					source.Append("_" + i);
				}
				source.Append(" {\r\n");
				source.Append("get{\r\n");
				source.Append("\t   ");
				source.Append(dtName);
				source.Append(" ret = null;\r\n");
				source.Append("\t   try {\r\n");
				source.Append("\t      ret = (");
				source.Append(dtName);
				source.Append(")this[");
				source.Append(i);
				source.Append("];\r\n");
				source.Append("\t   } catch (DataTypeException e) {\r\n");
				source.Append(
					"\t      HapiLogFactory.GetHapiLog(this.GetType()).Error(\"Unexpected problem accessing known data type component - this is a bug.\", e);\r\n");
				source.Append("\t      throw new System.Exception(\"An unexpected error ocurred\",e);\r\n");
				source.Append("\t   }\r\n");
				source.Append("\t   return ret;\r\n");
				source.Append("}\r\n\r\n");
				source.Append("}\r\n");
			}
			/*if (correspondingControlInterface != null) {
            source.append(Control.getImplementation(correspondingControlInterface, version));
            } */
			source.Append("}");

			return source.ToString();
		}

		private static string GetDescription(string description)
		{
			string ret = description;
			ret = ret.Replace("&", "and");
			return ret;
		}

		//test
		[STAThread]
		public static void Main(String[] args)
		{
			//System.out.println(makePrimitive("ID", "identifier"));
			try
			{
				Type.GetType("sun.jdbc.odbc.JdbcOdbcDriver");
				//System.setProperty("ca.on.uhn.hl7.database.url", "jdbc:odbc:hl7v25");        
				//make(new File("c:/testsourcegen"), args[0], args[1]);
				//make(new File("c:/testsourcegen"), "CE_0048", "2.3");
				makeAll("c:/testsourcegen", "2.5");
			}
			catch (Exception e)
			{
				SupportClass.WriteStackTrace(e, Console.Error);
			}
		}

		static DataTypeGenerator()
		{
			log = HapiLogFactory.GetHapiLog(typeof (DataTypeGenerator));
		}
	}
}