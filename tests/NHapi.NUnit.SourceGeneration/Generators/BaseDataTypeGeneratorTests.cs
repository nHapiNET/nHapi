namespace NHapi.NUnit.SourceGeneration.Generators
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    using global::NUnit.Framework;

    using NHapi.SourceGeneration;
    using NHapi.SourceGeneration.Generators;
    using VerifyNUnit;

    [TestFixture]
    public class BaseDataTypeGeneratorTests
    {
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
        public async Task BuildBaseDataTypes_GeneratesBaseDataTypes(string version)
        {
            // Arrange
            var results = new ConcurrentDictionary<string, string>();

            FileAbstraction.UsingImplementation((filePath, bytes) =>
            {
                filePath = Path.GetRelativePath(Directory.GetCurrentDirectory(), filePath);
                results.TryAdd(filePath, Encoding.UTF8.GetString(bytes));
            });

            // Act
            BaseDataTypeGenerator.BuildBaseDataTypes("basepath", version);

            // Assert
            Assert.That(results, Is.Not.Empty);

            await Verifier.Verify(results)
                .UseTextForParameters(version.Replace(".", string.Empty));
        }
    }
}