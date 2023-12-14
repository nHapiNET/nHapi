namespace NHapi.Base.NUnit.PreParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::NUnit.Framework;

    using NHapi.Base.PreParser;

    [TestFixture]
    public class XmlTests
    {
        [Test]
        public void TryParseMessage_InvalidXml_ReturnsFalse()
        {
            // Arrange
            var message = "6696A3E8-AEBE-4B7D-B2BB-3288261898A1";

            var pathSpecs = Array.Empty<DatumPath>();

            // Act
            var parsed = Xml.TryParseMessage(message, pathSpecs, out _);

            // Assert
            Assert.That(parsed, Is.False);
        }

        [Test]
        public void TryParseMessage_ValidXml_ReturnsTrue()
        {
            // Arrange
            var message = "<?xml version=\"1.0\" standalone=\"no\"?><root><child>value</child></root>";

            var pathSpecs = Array.Empty<DatumPath>();

            // Act
            var parsed = Xml.TryParseMessage(message, pathSpecs, out _);

            // Assert
            Assert.That(parsed, Is.True);
        }

        [Test]
        public void TryParseMessage_ValidXML_NullPathSpec_ReturnsExpectedResult()
        {
            // Arrange
            const string message = "<?xml version=\"1.0\" standalone=\"no\"?> <QBP_Q22>  <MSH>   <MSH.1>|</MSH.1>   <MSH.2>^~/&amp;</MSH.2>   <MSH.3>    <HD.1>UHN Vista</HD.1>    <HD.3>ISO</HD.3>   </MSH.3>   <MSH.4>    <HD.1>UHN</HD.1>    <HD.3>ISO</HD.3>   </MSH.4>   <MSH.5>    <HD.1>MPI</HD.1>    <HD.3>ISO</HD.3>   </MSH.5>   <MSH.6>    <HD.1>HealthLink</HD.1>    <HD.3>ISO</HD.3>   </MSH.6>   <MSH.7>20020429132718.734-0400</MSH.7>   <MSH.9>    <CM_MSG_TYPE.1>QBP</CM_MSG_TYPE.1>    <CM_MSG_TYPE.2>Q22</CM_MSG_TYPE.2>  <CM_MSG_TYPE.3>QBP_Q21</CM_MSG_TYPE.3>   </MSH.9>   <MSH.10>855</MSH.10>   <MSH.11>    <PT.1>P</PT.1>   </MSH.11>   <MSH.12>    <VID.1>2.4</VID.1>      </MSH.12>   <MSH.21>Q22</MSH.21>  </MSH>  <QPD>   <QPD.1>    <CE.1>Q22</CE.1>    <CE.2>Find Candidates</CE.2>    <CE.3>HL7nnnn</CE.3>   </QPD.1>   <QPD.3><QIP><QIP.1>@PID.3.1</QIP.1><QIP.2>9583518684</QIP.2></QIP><QIP><QIP.1>@PID.3.4.1</QIP.1><QIP.2>CANON</QIP.2></QIP><QIP><QIP.1>@PID.5.1.1</QIP.1><QIP.2>ECG-Acharya</QIP.2></QIP><QIP><QIP.1>@PID.5.2</QIP.1><QIP.2>Nf</QIP.2></QIP><QIP><QIP.1>@PID.5.7</QIP.1><QIP.2>L</QIP.2></QIP><QIP><QIP.1>@PID.7</QIP.1><QIP.2>197104010000</QIP.2></QIP><QIP><QIP.1>@PID.8</QIP.1><QIP.2>M</QIP.2></QIP></QPD.3>   <QPD.4>100</QPD.4>   <QPD.8><CX.4><HD.2>TTH</HD.2></CX.4></QPD.8>  <QPD.9>13831</QPD.9><QPD.10>ULTIuser2</QPD.10><QPD.11>234564</QPD.11><QPD.12>R&amp;H Med</QPD.12></QPD>  <RCP>   <RCP.1>I</RCP.1>   <RCP.2><CQ.1>100</CQ.1><CQ.2>RD</CQ.2></RCP.2>   <RCP.3>   <CE.1>R</CE.1>   </RCP.3>  </RCP> </QBP_Q22>";
            const string expectedValue =
                "|^~/&UHN VistaISOUHNISOMPIISOHealthLinkISO20020429132718.734-0400QBPQ22QBP_Q21855P2.4Q22Q22Find CandidatesHL7nnnn@PID.3.19583518684@PID.3.4.1CANON@PID.5.1.1ECG-Acharya@PID.5.2Nf@PID.5.7L@PID.7197104010000@PID.8M100TTH13831ULTIuser2234564R&H MedI100RDR";

            // Act
            var parsed = Xml.TryParseMessage(message, null, out var results);
            var actualResults = results.Select(r => r.Value).ToArray();

            // Assert
            Assert.That(parsed, Is.True);
            Assert.That(actualResults, Does.Contain(expectedValue));
        }

        [TestCase("PID-1", "grouped")]
        [TestCase("PID(1)-1", "not grouped")]
        public void TryParseMessage_MessageContainsSegmentGroupElements_ReturnsExpectedResult(string pathSpec, string expectedValue)
        {
            // Arrange
            const string message = "<?xml version=\"1.0\" standalone=\"no\"?><root><root.group><PID>grouped</PID></root.group><PID>not grouped</PID></root>";

            var pathSpecs = new List<DatumPath> { pathSpec.FromPathSpec() };

            // Act
            var parsed = Xml.TryParseMessage(message, pathSpecs, out var results);
            var actualResults = results.Select(r => r.Value).ToArray();

            // Assert
            Assert.That(parsed, Is.True);
            Assert.That(actualResults, Does.Contain(expectedValue));
        }

        [TestCase("MSH-9", "QBP")]
        [TestCase("MSH-9-2", "Q22")]
        [TestCase("QPD-8-4-2", "TTH")]
        public void TryParseMessage_ValidQBP_Q22Xml_ReturnsExpectedResult(string pathSpec, string expectedValue)
        {
            // Arrange
            const string message = "<?xml version=\"1.0\" standalone=\"no\"?> <QBP_Q22>  <MSH>   <MSH.1>|</MSH.1>   <MSH.2>^~/&amp;</MSH.2>   <MSH.3>    <HD.1>UHN Vista</HD.1>    <HD.3>ISO</HD.3>   </MSH.3>   <MSH.4>    <HD.1>UHN</HD.1>    <HD.3>ISO</HD.3>   </MSH.4>   <MSH.5>    <HD.1>MPI</HD.1>    <HD.3>ISO</HD.3>   </MSH.5>   <MSH.6>    <HD.1>HealthLink</HD.1>    <HD.3>ISO</HD.3>   </MSH.6>   <MSH.7>20020429132718.734-0400</MSH.7>   <MSH.9>    <CM_MSG_TYPE.1>QBP</CM_MSG_TYPE.1>    <CM_MSG_TYPE.2>Q22</CM_MSG_TYPE.2>  <CM_MSG_TYPE.3>QBP_Q21</CM_MSG_TYPE.3>   </MSH.9>   <MSH.10>855</MSH.10>   <MSH.11>    <PT.1>P</PT.1>   </MSH.11>   <MSH.12>    <VID.1>2.4</VID.1>      </MSH.12>   <MSH.21>Q22</MSH.21>  </MSH>  <QPD>   <QPD.1>    <CE.1>Q22</CE.1>    <CE.2>Find Candidates</CE.2>    <CE.3>HL7nnnn</CE.3>   </QPD.1>   <QPD.3><QIP><QIP.1>@PID.3.1</QIP.1><QIP.2>9583518684</QIP.2></QIP><QIP><QIP.1>@PID.3.4.1</QIP.1><QIP.2>CANON</QIP.2></QIP><QIP><QIP.1>@PID.5.1.1</QIP.1><QIP.2>ECG-Acharya</QIP.2></QIP><QIP><QIP.1>@PID.5.2</QIP.1><QIP.2>Nf</QIP.2></QIP><QIP><QIP.1>@PID.5.7</QIP.1><QIP.2>L</QIP.2></QIP><QIP><QIP.1>@PID.7</QIP.1><QIP.2>197104010000</QIP.2></QIP><QIP><QIP.1>@PID.8</QIP.1><QIP.2>M</QIP.2></QIP></QPD.3>   <QPD.4>100</QPD.4>   <QPD.8><CX.4><HD.2>TTH</HD.2></CX.4></QPD.8>  <QPD.9>13831</QPD.9><QPD.10>ULTIuser2</QPD.10><QPD.11>234564</QPD.11><QPD.12>R&amp;H Med</QPD.12></QPD>  <RCP>   <RCP.1>I</RCP.1>   <RCP.2><CQ.1>100</CQ.1><CQ.2>RD</CQ.2></RCP.2>   <RCP.3>   <CE.1>R</CE.1>   </RCP.3>  </RCP> </QBP_Q22>";

            var pathSpecs = new List<DatumPath> { pathSpec.FromPathSpec() };

            // Act
            var parsed = Xml.TryParseMessage(message, pathSpecs, out var results);
            var actualResults = results.Select(r => r.Value).ToArray();

            // Assert
            Assert.That(parsed, Is.True);
            Assert.That(actualResults, Does.Contain(expectedValue));
        }

        [TestCase("NTE(0)-1", "a")]
        [TestCase("NTE(1)-1", "b")]
        [TestCase("NTE-3(0)", "one")]
        [TestCase("NTE-3(1)", "two")]
        [TestCase("PID-5", "Smith")]
        [TestCase("PID-5-1-1", "Smith")]
        [TestCase("MSH-9-2", "A01")]
        [TestCase("PID-5-1-2", "Booth")]
        public void TryParseMessage_ValidADT_A01Xml_ReturnsExpectedResult(string pathSpec, string expectedValue)
        {
            // Arrange
            const string message = "<?xml version=\"1.0\" standalone=\"no\"?><ADT_A01 xmlns=\"urn:hl7-org:v2xml\"><MSH><MSH.1>|</MSH.1><MSH.2>^~\\&amp;</MSH.2><MSH.3><HD.1>x</HD.1></MSH.3><MSH.4><HD.1>x</HD.1></MSH.4><MSH.5><HD.1>x</HD.1></MSH.5><MSH.6><HD.1>x</HD.1></MSH.6><MSH.7><TS.1>199904140038</TS.1></MSH.7><MSH.9><MSG.1>ADT</MSG.1><MSG.2>A01</MSG.2></MSH.9><MSH.11><PT.1>P</PT.1></MSH.11><MSH.12><VID.1>2.4</VID.1></MSH.12></MSH><PID><PID.5><XPN.1><FN.1>Smith</FN.1><FN.2>Booth</FN.2><FN.3>Jones</FN.3></XPN.1><XPN.2>X</XPN.2><XPN.3>Y</XPN.3></PID.5></PID><NTE><NTE.1>a</NTE.1><NTE.3>one</NTE.3><NTE.3>two</NTE.3><NTE.3>three</NTE.3></NTE><NTE><NTE.1>b</NTE.1><NTE.3>four</NTE.3></NTE></ADT_A01>";

            var pathSpecs = new List<DatumPath> { pathSpec.FromPathSpec() };

            // Act
            var parsed = Xml.TryParseMessage(message, pathSpecs, out var results);
            var actualResults = results.Select(r => r.Value).ToArray();

            // Assert
            Assert.That(parsed, Is.True);
            Assert.That(actualResults, Does.Contain(expectedValue));
        }
    }
}