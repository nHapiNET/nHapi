namespace NHapi.NUnit.SourceGeneration
{
    using System.IO;

    using global::NUnit.Framework;

    using Microsoft.Extensions.Configuration;

    using ModelGenerator;

    [TestFixture]
    public class SourceGenerationTests
    {
        public SourceGenerationTests()
        {
            this.Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@"appsettings.test.json", false, false)
                .Build();
        }

        private IConfiguration Configuration { get; }

        [Test]
        [Explicit]
        public void Test_Generate_Versions()
        {
            var versionsToGenerate = new[]
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

            var builder = new ModelBuilder();
            builder.BasePath = Path.Combine(Directory.GetCurrentDirectory(), "out");
            builder.ConnectionString = this.Configuration.GetConnectionString("Hl7Database");
            builder.MessageTypeToBuild = ModelBuilder.MessageType.All;

            foreach (var versionToGenerate in versionsToGenerate)
            {
                // TODO: Should make these paths and connections strings configurable
                builder.Version = versionToGenerate;

                builder.Execute();
            }
        }
    }
}