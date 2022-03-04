namespace NHapi.NUnit.SourceGeneration.Generators
{
    using System.Collections.Concurrent;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    using global::NUnit.Framework;

    using Microsoft.Extensions.Configuration;

    using NHapi.SourceGeneration;
    using NHapi.SourceGeneration.Generators;

    using VerifyNUnit;

    [TestFixture]
    public class EventMappingGeneratorTests
    {
        public EventMappingGeneratorTests()
        {
            this.Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@"appsettings.test.json", false, false)
                .Build();
        }

        private IConfiguration Configuration { get; set; }

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
        public async Task MakeAll_GeneratesAllEventMaps(string version)
        {
            // Arrange
            var results = new ConcurrentDictionary<string, string>();

            FileAbstraction.UsingImplementation((filePath, bytes) =>
            {
                results.TryAdd(filePath, Encoding.UTF8.GetString(bytes));
            });

            ConfigurationSettings.ConnectionString = this.Configuration.GetConnectionString("Hl7Database");

            // Act
            EventMappingGenerator.MakeAll("basepath", version);

            // Assert
            Assert.IsNotEmpty(results);

            await Verifier.Verify(results)
                .UseTextForParameters(version.Replace(".", string.Empty));
        }
    }
}