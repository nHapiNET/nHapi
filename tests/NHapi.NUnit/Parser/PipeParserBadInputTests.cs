namespace NHapi.NUnit.Parser
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using global::NUnit.Framework;

    using NHapi.Base;
    using NHapi.Base.Parser;

    [TestFixture]
    public class PipeParserBadInputTests
    {
        [TestCaseSource(nameof(TestPaths), new object[] { "EncodingNotSupportedException", typeof(EncodingNotSupportedException) })]
        [TestCaseSource(nameof(TestPaths), new object[] { "HL7Exception", typeof(HL7Exception) })]
        public void TestBadInputsThrowException(string path, Type expectedExceptionType)
        {
            // Arrange
            var parser = new PipeParser();
            var text = File.ReadAllText(path);

            // Act / Assert
            var exception = Assert.Throws(expectedExceptionType, () => parser.Parse(text));

            // Write exception details to console
            Console.WriteLine(exception);
        }

        [Timeout(2000)]
        [TestCaseSource(nameof(TestPaths), new object[] { "NoException", null })]
        public void TestBadInputsAreHandledGracefully(string path, Type not_required)
        {
            // Arrange
            var parser = new PipeParser();
            var text = File.ReadAllText(path);

            // Assert
            Assert.DoesNotThrow(
                () => parser.Parse(text));
        }

        private static IEnumerable<object[]> TestPaths(string dirName, Type exception)
        {
            var testDataDir =
                $"{TestContext.CurrentContext.TestDirectory}/TestData/BadInputs/PipeParser/{dirName}";

            foreach (var filepath in Directory.GetFiles(testDataDir))
            {
                yield return new object[] { filepath, exception };
            }
        }
    }
}
