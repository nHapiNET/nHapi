using ModelGenerator;
using NUnit.Framework;

namespace NHapi.NUnit.SourceGeneration
{
	[TestFixture]
	public class SourceGenerationTests
	{
		[Test, Explicit]
		public void Test_Generate_Versions()
		{
			string[] versionsToGenerate = new[]
			{
				// Known good generations:
				"2.1",
				"2.2",
				"2.3",
				"2.3.1",
				"2.4",
				"2.5",
				"2.5.1",
				"2.6",
				"2.7",
				"2.7.1",
				"2.8",
				"2.8.1",
			};

			foreach (var versionToGenerate in versionsToGenerate)
			{
				var builder = new ModelBuilder();
				builder.BasePath = @"D:\Checkouts\duane\nHapi_monsterclean\NHapi20";
				builder.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=Z:\projects\hl7\hl7db.mdb;";
				builder.ConnectionString = @"Provider=SQLOLEDB;Data Source=lannister;Initial Catalog=HL7AllVersions;User Id=sa;Password=sa;";
				builder.MessageTypeToBuild = ModelBuilder.MessageType.All;
				builder.Version = versionToGenerate;

				builder.Execute();
			}
		}
	}
}
