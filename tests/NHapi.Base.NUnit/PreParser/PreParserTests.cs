// <copyright file="PreParserTests.cs" company="nHapiNET">
// Copyright (c) nHapiNET. All rights reserved.
// </copyright>

namespace NHapi.Base.NUnit.PreParser
{
    using global::NUnit.Framework;

    using NHapi.Base.PreParser;

    [TestFixture]
    public class PreParserTests
    {
        private const string ER7MESSAGE = "MSH|^~\\&|x|x|x|x|199904140038||ADT^A01||P|2.2\r" +
                                       "PID|||||Smith&Booth&Jones^X^Y\r" +
                                       "NTE|a||one~two~three\r" +
                                       "NTE|b||four\r";

        private const string XMLMESSAGE = "<?xml version=\"1.0\" standalone=\"no\"?><ADT_A01 xmlns=\"urn:hl7-org:v2xml\"><MSH><MSH.1>|</MSH.1><MSH.2>^~\\&amp;</MSH.2><MSH.3><HD.1>x</HD.1></MSH.3><MSH.4><HD.1>x</HD.1></MSH.4><MSH.5><HD.1>x</HD.1></MSH.5><MSH.6><HD.1>x</HD.1></MSH.6><MSH.7><TS.1>199904140038</TS.1></MSH.7><MSH.9><MSG.1>ADT</MSG.1><MSG.2>A01</MSG.2></MSH.9><MSH.11><PT.1>P</PT.1></MSH.11><MSH.12><VID.1>2.4</VID.1></MSH.12></MSH><PID><PID.5><XPN.1><FN.1>Smith</FN.1><FN.2>Booth</FN.2><FN.3>Jones</FN.3></XPN.1><XPN.2>X</XPN.2><XPN.3>Y</XPN.3></PID.5></PID><NTE><NTE.1>a</NTE.1><NTE.3>one</NTE.3><NTE.3>two</NTE.3><NTE.3>three</NTE.3></NTE><NTE><NTE.1>b</NTE.1><NTE.3>four</NTE.3></NTE></ADT_A01>";

        [TestCase(null, "Message encoding is not recognized")]
        [TestCase("", "Message encoding is not recognized")]
        [TestCase("   ", "Message encoding is not recognized")]
        [TestCase("NOTMSH", "Message encoding is not recognized")]
        [TestCase("MSH|", "Parse failed")]
        [TestCase("MSH.3", "Parse failed")]
        public void GetFields_MessageIsInvalid_ThrowsHl7Exception(string message, string expectedExceptionMessage)
        {
            // Arrange / Act / Assert
            Assert.That(
                () => PreParser.GetFields(message),
                Throws.TypeOf<HL7Exception>()
                    .With.Message.EqualTo(expectedExceptionMessage));
        }

        [TestCase("NTE(0)-1", "a")]
        [TestCase("NTE(1)-1", "b")]
        [TestCase("NTE-3(0)", "one")]
        [TestCase("NTE-3(1)", "two")]
        [TestCase("PID-5", "Smith")]
        [TestCase("PID-5-1-1", "Smith")]
        [TestCase("MSH-9-2", "A01")]
        [TestCase("PID-5-1-2", "Booth")]
        public void GetFields_Er7MessageIsValid_ReturnsExpectedResult(string pathSpec, string expectedValue)
        {
            // Arrange / Act
            var results = PreParser.GetFields(ER7MESSAGE, pathSpec);

            // Assert
            Assert.That(results, Does.Contain(expectedValue));
        }

        [TestCase("NTE(0)-1", "a")]
        [TestCase("NTE(1)-1", "b")]
        [TestCase("NTE-3(0)", "one")]
        [TestCase("NTE-3(1)", "two")]
        [TestCase("PID-5", "Smith")]
        [TestCase("PID-5-1-1", "Smith")]
        [TestCase("MSH-9-2", "A01")]
        [TestCase("PID-5-1-2", "Booth")]
        public void GetFields_XmlMessageIsValid_ReturnsExpectedResult(string pathSpec, string expectedValue)
        {
            // Arrange / Act
            var results = PreParser.GetFields(XMLMESSAGE, pathSpec);

            // Assert
            Assert.That(results, Does.Contain(expectedValue));
        }
    }
}