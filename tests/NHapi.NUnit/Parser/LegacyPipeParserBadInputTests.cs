namespace NHapi.NUnit.Parser
{
    using System;
    using System.IO;

    using global::NUnit.Framework;

    using NHapi.Base;
    using NHapi.Base.Parser;

    [TestFixture]
    public class LegacyPipeParserBadInputTests
    {
        private const string AOOR1 = "TestData/BadInputs/aoor1";
        private const string SYS1 = "TestData/BadInputs/sys1";
        private const string NULLREF1 = "TestData/BadInputs/nullref1";
        private const string IOOR1 = "TestData/BadInputs/ioor1";
        private const string REGEX1 = "TestData/BadInputs/regex1";
        private const string SYS2 = "TestData/BadInputs/sys2";
        private const string HANG1 = "TestData/BadInputs/hang1";
        private const string SO = "TestData/BadInputs/stackoverflow1";
        private const string SO2 = "TestData/BadInputs/stackoverflow2";

        [TestCase(AOOR1)]
        [TestCase(SYS1)]
        [TestCase(NULLREF1)]
        [TestCase(IOOR1)]
        [TestCase(SYS2)]
        public void TestBadInputsThrowHL7Exception(string path)
        {
            // Arrange
            var parser = new LegacyPipeParser();
            var text = File.ReadAllText(path);

            // Act / Assert
            var exception = Assert.Throws<HL7Exception>(
                () => parser.Parse(text));

            // Write exception details to console
            Console.WriteLine(exception);
        }

        [Timeout(2000)]
        [TestCase(REGEX1)]
        [TestCase(HANG1)]
        [TestCase(SO)]
        [TestCase(SO2)]
        public void TestBadInputsAreHandledGracefully(string path)
        {
            // Arrange
            var parser = new LegacyPipeParser();
            var text = File.ReadAllText(path);

            // Assert
            Assert.DoesNotThrow(
                () => parser.Parse(text));
        }
    }
}
