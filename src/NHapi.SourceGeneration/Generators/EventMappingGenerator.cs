namespace NHapi.SourceGeneration.Generators
{
    using System.Data.Common;
    using System.IO;
    using System.Text;

    using NHapi.Base;

    public class EventMappingGenerator
    {
        public static void MakeAll(string baseDirectory, string version)
        {
            // make base directory
            if (!(baseDirectory.EndsWith("\\") || baseDirectory.EndsWith("/")))
            {
                baseDirectory += Path.DirectorySeparatorChar;
            }

            var targetDir =
                SourceGenerator.MakeDirectory(
                    Path.Combine(baseDirectory, PackageManager.GetVersionPackagePath(version), "EventMapping"));

            // get list of data types
            var conn = NormativeDatabase.Instance.Connection;
            var sql =
                "SELECT * from HL7EventMessageTypes inner join HL7Versions on HL7EventMessageTypes.version_id = HL7Versions.version_id where HL7Versions.hl7_version = '" +
                version + "'";
            DbCommand temp_OleDbCommand = conn.CreateCommand();
            temp_OleDbCommand.Connection = conn;
            temp_OleDbCommand.CommandText = sql;
            var rs = temp_OleDbCommand.ExecuteReader();

            var targetFile = Path.Combine(targetDir.FullName, "EventMap.properties");

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"#event -> structure map for {version}");
            if (version == "2.1" || version == "2.2")
            {
                stringBuilder.AppendLine("#note: no mappings are defined for 2.1 and 2.2");
            }
            else
            {
                while (rs.Read())
                {
                    var messageType = $"{rs["message_typ_snd"]}_{rs["event_code"]}";
                    var structure = (string)rs["message_structure_snd"];

                    stringBuilder.AppendLine($"{messageType} {structure}");
                }
            }

            FileAbstraction.WriteAllBytes(targetFile, Encoding.UTF8.GetBytes(stringBuilder.ToString()));
        }
    }
}