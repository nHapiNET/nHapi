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
        private const string aoor1 = "tests/NHapi.NUnit/TestData/BadInputs/aoor1";
        private const string sys1 = "tests/NHapi.NUnit/TestData/BadInputs/sys1";
        private const string nullref1 = "tests/NHapi.NUnit/TestData/BadInputs/nullref1";
        private const string ioor1 = "tests/NHapi.NUnit/TestData/BadInputs/ioor1";
        private const string regex1 = "tests/NHapi.NUnit/TestData/BadInputs/regex1";
        private const string sys2 = "tests/NHapi.NUnit/TestData/BadInputs/sys2";
        private const string hang1 = "tests/NHapi.NUnit/TestData/BadInputs/hang1";

        [Test]
        [Timeout(2000)]
        [TestCase(new object[] { aoor1 })]
        [TestCase(new object[] { sys1 })]
        [TestCase(new object[] { nullref1 })]
        [TestCase(new object[] { ioor1 })]
        [TestCase(new object[] { regex1 })]
        [TestCase(new object[] { sys2 })]
        [TestCase(new object[] { hang1 })]
        public void TestBadInputs(string path)
        {
            var parser = new PipeParser();
            var text = File.ReadAllText(path);
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
