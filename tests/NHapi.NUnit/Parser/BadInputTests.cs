namespace NHapi.NUnit.Parser
{
    using System;
    using System.IO;

    using global::NUnit.Framework;

    using NHapi.Base;
    using NHapi.Base.Parser;

    [TestFixture]
    public class BadInputTests
    {
        private const string AOOR1 = "TestData/BadInputs/aoor1";
        private const string SYS1 = "TestData/BadInputs/sys1";
        private const string NULLREF1 = "TestData/BadInputs/nullref1";
        private const string IOOR1 = "TestData/BadInputs/ioor1";
        private const string REGEX1 = "TestData/BadInputs/regex1";
        private const string SYS2 = "TestData/BadInputs/sys2";
        private const string HANG1 = "TestData/BadInputs/hang1";

        [Test]
        [Timeout(2000)]
        [TestCase(new object[] { AOOR1 })]
        [TestCase(new object[] { SYS1 })]
        [TestCase(new object[] { NULLREF1 })]
        [TestCase(new object[] { IOOR1 })]
        [TestCase(new object[] { REGEX1 })]
        [TestCase(new object[] { SYS2 })]
        [TestCase(new object[] { HANG1 })]
        public void TestBadInputs(string path)
        {
            // Arrange
            var parser = new PipeParser();
            var text = File.ReadAllText(path);

            // Assert
            Assert.DoesNotThrow(() =>
            {
                try
                {
                    var msg = parser.Parse(text);
                }
                catch (HL7Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }
    }
}
