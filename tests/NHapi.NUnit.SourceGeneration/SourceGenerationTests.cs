namespace NHapi.NUnit.SourceGeneration
{
    using System.Collections.Concurrent;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    using global::NUnit.Framework;

    using Microsoft.Extensions.Configuration;

    using ModelGenerator;

    using NHapi.SourceGeneration;

    using VerifyNUnit;

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
        [TestCase("2.1")]
        [TestCase("2.2")]
        [TestCase("2.3")]
        [TestCase("2.3.1")]
        [TestCase("2.4")]
        [TestCase("2.5")]
        [TestCase("2.5.1")]
        [TestCase("2.6")]
        [TestCase("2.7")]
        [TestCase("2.7.1")]
        [TestCase("2.8")]
        [TestCase("2.8.1")]
        public async Task Test_Generate_Versions(string version)
        {
            var results = new ConcurrentDictionary<string, string>();

            FileAbstraction.UsingImplementation((filePath, bytes) =>
            {
                results.TryAdd(filePath, Encoding.UTF8.GetString(bytes));
            });

            var builder = new ModelBuilder();
            builder.BasePath = Path.Combine(Directory.GetCurrentDirectory(), "out");
            builder.ConnectionString = this.Configuration.GetConnectionString("Hl7Database");
            builder.MessageTypeToBuild = ModelBuilder.MessageType.All;

            // TODO: Should make these paths and connections strings configurable
            builder.Version = version;

            builder.Execute();

            Assert.That(results, Is.Not.Empty);

            await Verifier.Verify(results);
        }
    }
}