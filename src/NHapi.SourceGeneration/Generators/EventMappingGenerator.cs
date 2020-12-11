using System;
using System.Data.Common;
using System.Data.Odbc;
using System.IO;
using NHapi.Base;

namespace NHapi.SourceGeneration.Generators
{
	public class EventMappingGenerator
	{
		public static void makeAll(String baseDirectory, String version)
		{
			//make base directory
			if (!(baseDirectory.EndsWith("\\") || baseDirectory.EndsWith("/")))
			{
				baseDirectory = baseDirectory + "/";
			}
			FileInfo targetDir =
				SourceGenerator.makeDirectory(baseDirectory + PackageManager.GetVersionPackagePath(version) + "EventMapping");

			//get list of data types
			OdbcConnection conn = NormativeDatabase.Instance.Connection;
			String sql =
				"SELECT * from HL7EventMessageTypes inner join HL7Versions on HL7EventMessageTypes.version_id = HL7Versions.version_id where HL7Versions.hl7_version = '" +
				version + "'";
			DbCommand temp_OleDbCommand = conn.CreateCommand();
			temp_OleDbCommand.Connection = conn;
			temp_OleDbCommand.CommandText = sql;
			DbDataReader rs = temp_OleDbCommand.ExecuteReader();


			using (StreamWriter sw = new StreamWriter(targetDir.FullName + @"\EventMap.properties", false))
			{
				sw.WriteLine("#event -> structure map for " + version);
				while (rs.Read())
				{
					string messageType = string.Format("{0}_{1}", rs["message_typ_snd"], rs["event_code"]);
					string structure = (string) rs["message_structure_snd"];

					sw.WriteLine(string.Format("{0} {1}", messageType, structure));
				}
			}
		}
	}
}