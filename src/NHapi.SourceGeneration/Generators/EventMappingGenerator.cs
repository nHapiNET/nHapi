namespace NHapi.SourceGeneration.Generators
{
    using System.Data.Common;
    using System.Data.Odbc;
    using System.IO;

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

            using (var sw = new StreamWriter(targetFile, false))
            {
                sw.WriteLine("#event -> structure map for " + version);
                while (rs.Read())
                {
                    var messageType = string.Format("{0}_{1}", rs["message_typ_snd"], rs["event_code"]);
                    var structure = (string)rs["message_structure_snd"];

                    sw.WriteLine(string.Format("{0} {1}", messageType, structure));
                }
            }
        }
    }
}