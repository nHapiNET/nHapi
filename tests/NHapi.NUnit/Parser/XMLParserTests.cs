namespace NHapi.NUnit.Parser
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    using global::NUnit.Framework;

    using NHapi.Base.Model;
    using NHapi.Base.Parser;
    using NHapi.Base.Util;
    using NHapi.Model.V25.Datatype;
    using NHapi.Model.V25.Message;

    using ADT_A01 = NHapi.Model.V23.Message.ADT_A01;
    using ED = NHapi.Model.V25.Datatype.ED;
    using ORU_R01 = NHapi.Model.V25.Message.ORU_R01;
    using ST = NHapi.Model.V25.Datatype.ST;

    [TestFixture]
    public class XMLParserTests
    {
        private static readonly string TestDataDir = $"{TestContext.CurrentContext.TestDirectory}/TestData/Parser";

        [Test]
        public void Encode_DuplicateSegmentInStructureDefinition_IsHandledCorrectly()
        {
            // Arrange
            var message = File.ReadAllText($"{TestDataDir}/adt_a17.xml");
            var defaultXmlParser = new DefaultXMLParser();
            var pipeParser = new PipeParser();

            // Act
            var parsed = defaultXmlParser.Parse(message);
            var er7Encoded = pipeParser.Encode(parsed);
            var er7Message = Regex.Replace(er7Encoded, "\\r", "\\r\\n");

            var firstIndex = er7Message.IndexOf("PID", StringComparison.Ordinal);
            var secondIndex = er7Message.IndexOf("PID", firstIndex + 1, StringComparison.Ordinal);
            var thirdIndex = er7Message.IndexOf("PID", secondIndex + 1, StringComparison.Ordinal);

            // Assert
            Assert.True(firstIndex > 0);
            Assert.True(secondIndex > firstIndex);
            Assert.AreEqual(-1, thirdIndex, $"Found third PID {firstIndex} {secondIndex} {thirdIndex}:\r\n{er7Message}");
        }

        [Test]
        public void Parse_XmlContainsExtraComponents_HandledCorrectly()
        {
            // Arrange
            var xmlMessage = File.ReadAllText($"{TestDataDir}/extracmp_xml.xml");
            var xmlParser = new DefaultXMLParser();
            var pipeParser = new PipeParser();

            var message = xmlParser.Parse(xmlMessage);
            var er7Encoded = pipeParser.Encode(message);

            Assert.IsTrue(er7Encoded.Contains("HD.4"));
            Assert.IsTrue(er7Encoded.Contains("HD.5"));
        }

        [TestCase("<MSA.2>12</MSA.2>", "12")]
        [TestCase("<thing<foo> help >>><msa.2> *** </i forget", "***")]
        [TestCase("<MSA.2>   12   \r</MSA.2>", "12")]
        [TestCase("<there is no msa.2>x</msa.2>", null)]
        [TestCase("<msa.2>x", null)]
        public void GetAckID_ValidInput_ReturnsExpectedResult(string input, string expected)
        {
            // Arrange
            var parser = new DefaultXMLParser();

            // Act / Assert
            Assert.AreEqual(expected, parser.GetAckID(input));
        }

        [Test]
        public void GetAckID_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            var expected = "876";
            var xmlMessage = File.ReadAllText($"{TestDataDir}/get_ack_id.xml");
            var parser = new DefaultXMLParser();

            // Act / Assert
            Assert.AreEqual(expected, parser.GetAckID(xmlMessage));
        }

        [TestCase("<MSH>\r<MSH.1>|</MSH.1>\r<MSH.2>^~\\&amp;</MSH.2>\r</MSH>", "XML")]
        [TestCase("blorg gablorg", null)]
        public void GetEncoding_ValidInput_ReturnsExpectedResult(string input, string expected)
        {
            // Arrange
            var parser = new DefaultXMLParser();

            // Act / Assert
            Assert.AreEqual(expected, parser.GetEncoding(input));
        }

        [Test]
        public void GetVersion_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            var expected = "2.4";
            var xmlMessage = File.ReadAllText($"{TestDataDir}/get_version.xml");
            var parser = new DefaultXMLParser();

            // Act / Assert
            Assert.AreEqual(expected, parser.GetVersion(xmlMessage));
        }

        [TestCase("\t\r\nhello ", "hello")]
        [TestCase(" hello \t \rthere\r\n", "hello there")]
        public void RemoveWhitespace_ValidInput_ReturnsExpectedResult(string input, string expected)
        {
            // Arrange
            var parser = new DefaultXMLParser();

            // Act / Assert
            Assert.AreEqual(expected, parser.RemoveWhitespace(input));
        }

        [Test]
        public void Parse_XmlHasNamespaces_ReturnsExpectedResult()
        {
            // Arrange
            var expectedVersion = "2.2";
            var expectedMsh7 = "19951010134000";
            var xmlMessage = File.ReadAllText($"{TestDataDir}/parse_and_encode_with_ns.xml");
            var parser = new DefaultXMLParser();
            var message = parser.Parse(xmlMessage);
            var terser = new Terser(message);

            // Act / Assert
            Assert.AreEqual(expectedVersion, parser.GetVersion(xmlMessage));
            Assert.AreEqual(expectedMsh7, terser.Get("MSH-7"));
        }

        [Test]
        public void GetCriticalResponseData_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            var xmlMessage = File.ReadAllText($"{TestDataDir}/critical_response_data.xml");
            var parser = new DefaultXMLParser();
            var segment = parser.GetCriticalResponseData(xmlMessage);
            var actual = segment.GetField(2, 0);
            var expected = "^~\\&";

            // Act / Assert
            Assert.AreEqual(expected, actual.ToString());
        }

        [Test]
        public void Parse_OruR01_CorrectlyHandlesEDEscaping()
        {
            // Arrange
            var xmlMessage = File.ReadAllText($"{TestDataDir}/ed_issue.xml");
            var parser = new DefaultXMLParser();
            var message = parser.Parse(xmlMessage) as ORU_R01;

            // Act
            var obx5 =
                message?.GetPATIENT_RESULT().GetORDER_OBSERVATION().GetOBSERVATION(1)
                    .OBX.GetObservationValue(0).Data as ED;

            // Assert
            Assert.True(obx5?.Data.Value.StartsWith("JVBERi0xLjMKJeLjz9MKCjEgMCBvYmoKPDwgL1R5cG"));
        }

        [Test]
        public void Parse_FollowedByEncode_WorksAsExpected()
        {
            // Arrange
            var xmlMessage = File.ReadAllText($"{TestDataDir}/parse_and_encode.xml");
            var xmlParser = new DefaultXMLParser();

            var oruR01 = new NHapi.Model.V26.Message.ORU_R01();

            // Action
            xmlParser.Parse(oruR01, xmlMessage);
            var encodedOruR01 = xmlParser.Encode(oruR01);

            // Assert
            Assert.AreEqual("LABMI1199510101340007", oruR01.MSH.MessageControlID.Value);
            StringAssert.Contains("<MSH.10>LABMI1199510101340007</MSH.10>", encodedOruR01);
        }

        [Test]
        public void Parse_OmdO03_OrderDietSegmentIsNotMissing()
        {
            // Arrange
            var xmlMessage = File.ReadAllText($"{TestDataDir}/OMD_O03.xml");
            var xmlParser = new DefaultXMLParser();

            // Action
            var omdO03 = (OMD_O03)xmlParser.Parse(xmlMessage);

            // Assert
            Assert.AreEqual("S", omdO03.GetORDER_DIET().DIET.GetODS().Type.Value);
        }

        [Test]
        public void Parse_EncodedMessageIsModifiedWithEscapeSequence_IsParsedCorrectly()
        {
            // Arrange
            var obx5Value = "CONTENT";

            var oruR01 = new ORU_R01();

            SetMessageHeader(oruR01, "ORU", "R01", "T");
            var obx = oruR01.GetPATIENT_RESULT().GetORDER_OBSERVATION().GetOBSERVATION().OBX;
            obx.ValueType.Value = "FT";
            obx.GetObservationValue(0).Data = new FT(oruR01) { Value = obx5Value };

            var xmlParser = new DefaultXMLParser();

            // Act
            var xml = xmlParser.Encode(oruR01);
            xml = xml.Replace(
                obx5Value,
                $"<escape V=\"H\" />{obx5Value}<escape V=\".br\" />{obx5Value}<escape V=\"N\" />");

            var message = (ORU_R01)xmlParser.Parse(xml);
            var parsedObx5Value =
                ((FT)message.GetPATIENT_RESULT().GetORDER_OBSERVATION().GetOBSERVATION()
                    .OBX.GetObservationValue(0).Data).Value;

            // Assert
            Assert.AreEqual($"\\H\\{obx5Value}\\.br\\{obx5Value}\\N\\", parsedObx5Value);
        }

        [Test]
        public void Parse_MessageContainsLongNameAttributes_ParsedAsExpected()
        {
            // Arrange
            var message = "<ADT_A01 xmlns=\"urn:hl7-org:v2xml\"><MSH><MSH.1 LongName=\"Field Separator\">|</MSH.1><MSH.2 LongName=\"Encoding Characters\">^~\\&amp;</MSH.2><MSH.3 LongName=\"Sending Application\"><HD.1 LongName=\"Namespace ID\">MILL</HD.1></MSH.3><MSH.4 LongName=\"Sending Facility\"><HD.1 LongName=\"Namespace ID\">EMRY</HD.1></MSH.4><MSH.5 LongName=\"Receiving Application\"><HD.1 LongName=\"Namespace ID\">MQ</HD.1></MSH.5><MSH.6 LongName=\"Receiving Facility\"><HD.1 LongName=\"Namespace ID\">EMRY</HD.1></MSH.6><MSH.7 LongName=\"Date / Time of Message\"><TS.1 LongName=\"Time of an event\">20150619155451</TS.1></MSH.7><MSH.9 LongName=\"Message Type\"><CM_MSG.1 LongName=\"Message type\">ADT</CM_MSG.1><CM_MSG.2 LongName=\"Trigger event\">A08</CM_MSG.2></MSH.9><MSH.10 LongName=\"Message Control ID\">Q2043855220T2330403781X928163</MSH.10><MSH.11 LongName=\"Processing ID\"><PT.1 LongName=\"Processing ID\">P</PT.1></MSH.11><MSH.12 LongName=\"Version ID\">2.3</MSH.12><MSH.18 LongName=\"Character Set\">8859/1</MSH.18></MSH><EVN><EVN.1 LongName=\"Event Type Code\">A08</EVN.1><EVN.2 LongName=\"Recorded Date/Time\"><TS.1 LongName=\"Time of an event\">20150619155451</TS.1></EVN.2></EVN><PID><PID.1 LongName=\"Set ID - Patient ID\">1</PID.1><PID.2 LongName=\"Patient ID (External ID)\"><CX.1 LongName=\"ID\">935307</CX.1><CX.4 LongName=\"Assigning authority\"><HD.1 LongName=\"Namespace ID\">EUH MRN</HD.1></CX.4><CX.5 LongName=\"Identifier type code\">MRN</CX.5><CX.6 LongName=\"Assigning facility\"><HD.1 LongName=\"Namespace ID\">EH01</HD.1></CX.6></PID.2><PID.3 LongName=\"Patient ID (Internal ID)\"><CX.1 LongName=\"ID\">25106376</CX.1><CX.4 LongName=\"Assigning authority\"><HD.1 LongName=\"Namespace ID\">TEC MRN</HD.1></CX.4></PID.3><PID.3 LongName=\"Patient ID (Internal ID)\"><CX.1 LongName=\"ID\">1781893</CX.1><CX.4 LongName=\"Assigning authority\"><HD.1 LongName=\"Namespace ID\">CLH MRN</HD.1></CX.4></PID.3><PID.3 LongName=\"Patient ID (Internal ID)\"><CX.1 LongName=\"ID\">935307</CX.1><CX.4 LongName=\"Assigning authority\"><HD.1 LongName=\"Namespace ID\">EUH MRN</HD.1></CX.4></PID.3><PID.3 LongName=\"Patient ID (Internal ID)\"><CX.1 LongName=\"ID\">5938067</CX.1><CX.4 LongName=\"Assigning authority\"><HD.1 LongName=\"Namespace ID\">EMPI</HD.1></CX.4></PID.3><PID.4 LongName=\"Alternate Patient ID\"><CX.1 LongName=\"ID\">1167766</CX.1><CX.4 LongName=\"Assigning authority\"><HD.1 LongName=\"Namespace ID\">CPI NBR</HD.1></CX.4><CX.6 LongName=\"Assigning facility\"><HD.1 LongName=\"Namespace ID\">EXTERNAL</HD.1></CX.6></PID.4><PID.4 LongName=\"Alternate Patient ID\"><CX.1 LongName=\"ID\">90509411</CX.1><CX.4 LongName=\"Assigning authority\"><HD.1 LongName=\"Namespace ID\">HNASYSID</HD.1></CX.4></PID.4><PID.4 LongName=\"Alternate Patient ID\"><CX.1 LongName=\"ID\">10341880</CX.1><CX.4 LongName=\"Assigning authority\"><HD.1 LongName=\"Namespace ID\">HNASYSID</HD.1></CX.4></PID.4><PID.4 LongName=\"Alternate Patient ID\"><CX.1 LongName=\"ID\">50627780</CX.1><CX.4 LongName=\"Assigning authority\"><HD.1 LongName=\"Namespace ID\">HNASYSID</HD.1></CX.4></PID.4><PID.4 LongName=\"Alternate Patient ID\"><CX.1 LongName=\"ID\">5938067</CX.1><CX.4 LongName=\"Assigning authority\"><HD.1 LongName=\"Namespace ID\">MSG_CERNPHR</HD.1></CX.4></PID.4><PID.5 LongName=\"Patient Name\"><XPN.1 LongName=\"Family name\">Patient</XPN.1><XPN.2 LongName=\"Given name\">Test</XPN.2><XPN.3 LongName=\"Middle initial or name\">Test</XPN.3><XPN.7 LongName=\"Name type code\">Cur_Name</XPN.7></PID.5><PID.7 LongName=\"Date of Birth\"><TS.1 LongName=\"Time of an event\">19400101</TS.1></PID.7><PID.8 LongName=\"Sex\">F</PID.8><PID.10 LongName=\"Race\">WHI</PID.10><PID.11 LongName=\"Patient Address\"><XAD.1 LongName=\"Street address\">123 ENDOFTHE RD</XAD.1><XAD.2 LongName=\"Other designation\">UNIT 123</XAD.2><XAD.3 LongName=\"City\">ATLANTA</XAD.3><XAD.4 LongName=\"State or province\">GA</XAD.4><XAD.5 LongName=\"Zip or postal code\">40000</XAD.5><XAD.6 LongName=\"Country\">USA</XAD.6><XAD.7 LongName=\"Address type\">HOME</XAD.7></PID.11><PID.13 LongName=\"Phone Number - Home\"><XTN.1 LongName=\"[(999)] 999-9999 [X99999][C any text]\">5555555555</XTN.1><XTN.2 LongName=\"Telecommunication use code\">HOME</XTN.2></PID.13><PID.13 LongName=\"Phone Number - Home\"><XTN.1 LongName=\"[(999)] 999-9999 [X99999][C any text]\">6666666666</XTN.1><XTN.2 LongName=\"Telecommunication use code\">YAHOO@YAHOO.COM</XTN.2><XTN.3 LongName=\"Telecommunication equipment type (ID)\">EMAIL</XTN.3></PID.13><PID.14 LongName=\"Phone Number - Business\"><XTN.1 LongName=\"[(999)] 999-9999 [X99999][C any text]\">6666666666</XTN.1><XTN.2 LongName=\"Telecommunication use code\">BUS</XTN.2></PID.14><PID.15 LongName=\"Primary Language\"><CE.1 LongName=\"Identifier\">ENG</CE.1></PID.15><PID.16 LongName=\"Marital Status\">M</PID.16><PID.17 LongName=\"Religion\">OTH</PID.17><PID.18 LongName=\"Patient Account Number\"><CX.1 LongName=\"ID\">12345665161</CX.1><CX.4 LongName=\"Assigning authority\"><HD.1 LongName=\"Namespace ID\">EUH FIN</HD.1></CX.4><CX.5 LongName=\"Identifier type code\">FIN NBR</CX.5><CX.6 LongName=\"Assigning facility\"><HD.1 LongName=\"Namespace ID\">EH01</HD.1></CX.6></PID.18><PID.19 LongName=\"SSN Number - Patient\">123454103</PID.19><PID.20 LongName=\"Driver's License Number\"><DLN.1 LongName=\"Driver's License Number\">GA123450071</DLN.1></PID.20><PID.22 LongName=\"Ethnic Group\">Non-Hispanic</PID.22><PID.25 LongName=\"Birth Order\">0</PID.25><PID.26 LongName=\"Citizenship\">\"\"</PID.26><PID.27 LongName=\"Veterans Military Status\"><CE.1 LongName=\"Identifier\">\"\"</CE.1></PID.27><PID.28 LongName=\"Nationality Code\"><CE.1 LongName=\"Identifier\">\"\"</CE.1></PID.28><PID.30 LongName=\"Patient Death Indicator\">N</PID.30></PID></ADT_A01>";
            var expectedMessageControlId = "Q2043855220T2330403781X928163";
            var expectedDob = "19400101";

            var parser = new DefaultXMLParser();

            // Act
            var parsed = parser.Parse(message);

            var adtA01 = parsed as ADT_A01; // a08 is mapped to a01

            // Assert
            Assert.IsNotNull(adtA01);
            Assert.AreEqual(expectedMessageControlId, adtA01.MSH.MessageControlID.Value);
            Assert.AreEqual(expectedDob, adtA01.PID.DateOfBirth.TimeOfAnEvent.Value);
        }

        [Test]
        public void Encode_OmdO03_CorrectlyHandlesEscaping()
        {
            // Arrange
            var er7Message = File.ReadAllText($"{TestDataDir}/omd_o03.txt");
            var xmlParser = new DefaultXMLParser();
            var pipeParser = new PipeParser();
            var message = pipeParser.Parse(er7Message);

            // Action
            var xml = xmlParser.Encode(message);

            // Assert
            Assert.IsTrue(xml.Contains("OMD_O03.DIET"));
        }

        [Test]
        public void Encode_WhenMessageContainsLongValues_DoesNotWrap()
        {
            // Arrange
            var obx5Value = "AAAABBBB CCCCDDDD ";
            obx5Value = obx5Value + obx5Value + obx5Value + obx5Value + obx5Value;
            obx5Value = obx5Value + obx5Value + obx5Value + obx5Value + obx5Value;
            obx5Value = obx5Value.Trim();

            var oruR01 = new ORU_R01();

            SetMessageHeader(oruR01, "ORU", "R01", "T");
            var obx = oruR01.GetPATIENT_RESULT().GetORDER_OBSERVATION().GetOBSERVATION().OBX;
            obx.ValueType.Value = "ST";
            obx.GetObservationValue(0).Data = new ST(oruR01) { Value = obx5Value };

            var xmlParser = new DefaultXMLParser();

            // Act
            var xml = xmlParser.Encode(oruR01);

            var message = (ORU_R01)xmlParser.Parse(xml);
            var parsedObx5Value =
                ((ST)message.GetPATIENT_RESULT().GetORDER_OBSERVATION().GetOBSERVATION()
                    .OBX.GetObservationValue(0).Data).Value;

            // Assert
            Assert.AreEqual(obx5Value, parsedObx5Value);
        }

        [TestCase("ABC\\H\\highlighted\\N\\EFG", "<OBX.5>ABC<escape V=\"H\" />highlighted<escape V=\"N\" />EFG</OBX.5>")]
        [TestCase("\\H\\highlighted\\N\\EFG", "<escape V=\"H\" />highlighted<escape V=\"N\" />EFG</OBX.5>")]
        [TestCase("ABC\\H\\highlighted\\N\\", "<OBX.5>ABC<escape V=\"H\" />highlighted<escape V=\"N\" />")]
        [TestCase("ABC\\E\\no escape sequence\\H\\highlighted\\N\\EFG", "<OBX.5>ABC\\no escape sequence<escape")]
        [TestCase("\\E\\no escape sequence", "<OBX.5>\\no escape sequence</OBX.5>")]
        public void Encode_MessageHasEscapedSequences_IsHandledCorrectly(string obx5Value, string expectedXml)
        {
            // Arrange
            var parserOptions = new ParserOptions { PrettyPrintEncodedXml = false };
            var xmlParser = new DefaultXMLParser();

            var oruR01 = new ORU_R01();

            SetMessageHeader(oruR01, "ORU", "R01", "T");
            var obx = oruR01.GetPATIENT_RESULT().GetORDER_OBSERVATION().GetOBSERVATION().OBX;

            var encodingCharacters = EncodingCharacters.FromMessage(oruR01);

            obx.ValueType.Value = "FT";
            obx.GetObservationValue(0).Data = new FT(oruR01) { Value = Escape.UnescapeText(obx5Value, encodingCharacters) };

            // Test a couple of cases of escape sequences
            // Action
            var encoded = xmlParser.Encode(oruR01, parserOptions);

            // Assert
            StringAssert.Contains(expectedXml, encoded);
        }

        [TestCase("1234", "<MSH.10>1234</MSH.10>")]
        [TestCase("1234\\E\\1234", "<MSH.10>1234\\E\\1234</MSH.10>")]
        [TestCase("1234\\E\\", "<MSH.10>1234\\E\\</MSH.10>")]
        [TestCase("1234\\E\\\\E\\", "<MSH.10>1234\\E\\\\E\\</MSH.10>")]
        [TestCase("1234\\E\\\\.BR\\", "<MSH.10>1234\\E\\<escape V=\".BR\" />")]
        public void Encode_HandlesMessagesWithTrailingEncodedBackslash(string messageControlId, string expectedXml)
        {
            // Arrange
            var adtA01 = new ADT_A01();

            SetMessageHeader(adtA01, "ADT", "A01", "T");
            adtA01.MSH.MessageControlID.Value = messageControlId;

            // Test a couple of cases of escape sequences
            var parserOptions = new ParserOptions { PrettyPrintEncodedXml = false };
            var xmlParser = new DefaultXMLParser();

            // Action
            var encoded = xmlParser.Encode(adtA01, parserOptions);

            // Assert
            StringAssert.Contains(expectedXml, encoded);
        }

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
        public void Encode_GenericMessage_WorksAsExpected(string version)
        {
            // Arrange
            var xmlParser = new DefaultXMLParser();
            var type = GenericMessage.GetGenericMessageClass(version);
            var expectedElementName = $"GenericMessageV{version.Replace(".", string.Empty)}";

            var constructor = type.GetConstructor(new[] { typeof(IModelClassFactory) });
            var message = (IMessage)constructor?.Invoke(new object[] { new DefaultModelClassFactory() });

            // Action
            var document = xmlParser.EncodeDocument(message);

            // Assert
            Assert.IsNotNull(document);
            Assert.AreEqual(expectedElementName, document.DocumentElement?.LocalName);
            Assert.IsNotNull(xmlParser.Encode(message));
        }

        [Test]
        public void Encode_AdtA01_CanBeParsedAgain()
        {
            // Arrange
            var er7Message = File.ReadAllText($"{TestDataDir}/adt_a03.txt");
            var xmlParser = new DefaultXMLParser();
            var pipeParser = new PipeParser();
            var message = pipeParser.Parse(er7Message);

            // Action
            var document = xmlParser.EncodeDocument(message);
            var decodedMessage = xmlParser.ParseDocument(document, message.Version);

            Console.WriteLine(decodedMessage.ToString());
        }

        [Test]
        public void Encode_WithParserOption_IncludeLongNameInEncodedXMLIsTrue_ResultContainsLongNameAttribute()
        {
            // Arrange
            var message = "MSH|^~\\&|KISsystem|ZTM|NIDAklinikserver|HL7Proxy|201902271130||ADT^A01|68371142|P|2.3\r"
                + "EVN|A01|201902271130|201902271130";

            var expectedEncodedMessage = @"<?xml version=""1.0"" encoding=""utf-8""?><ADT_A01 xmlns=""urn:hl7-org:v2xml""><MSH><MSH.1 LongName=""Field Separator"">|</MSH.1><MSH.2 LongName=""Encoding Characters"">^~\&amp;</MSH.2><MSH.3 LongName=""Sending Application""><HD.1 LongName=""Namespace ID"">KISsystem</HD.1></MSH.3><MSH.4 LongName=""Sending Facility""><HD.1 LongName=""Namespace ID"">ZTM</HD.1></MSH.4><MSH.5 LongName=""Receiving Application""><HD.1 LongName=""Namespace ID"">NIDAklinikserver</HD.1></MSH.5><MSH.6 LongName=""Receiving Facility""><HD.1 LongName=""Namespace ID"">HL7Proxy</HD.1></MSH.6><MSH.7 LongName=""Date / Time of Message""><TS.1 LongName=""Time of an event"">201902271130</TS.1></MSH.7><MSH.9 LongName=""Message Type""><CM_MSG.1 LongName=""Message type"">ADT</CM_MSG.1><CM_MSG.2 LongName=""Trigger event"">A01</CM_MSG.2></MSH.9><MSH.10 LongName=""Message Control ID"">68371142</MSH.10><MSH.11 LongName=""Processing ID""><PT.1 LongName=""Processing ID"">P</PT.1></MSH.11><MSH.12 LongName=""Version ID"">2.3</MSH.12></MSH><EVN><EVN.1 LongName=""Event Type Code"">A01</EVN.1><EVN.2 LongName=""Recorded Date/Time""><TS.1 LongName=""Time of an event"">201902271130</TS.1></EVN.2><EVN.3 LongName=""Date/Time Planned Event""><TS.1 LongName=""Time of an event"">201902271130</TS.1></EVN.3></EVN></ADT_A01>";

            var parser = new PipeParser();
            var xmlParser = new DefaultXMLParser();
            var options = new ParserOptions { IncludeLongNameInEncodedXml = true, PrettyPrintEncodedXml = false };

            var parsed = parser.Parse(message);

            // Act
            var encodedMessage = xmlParser.Encode(parsed, options);

            // Assert
            Assert.AreEqual(expectedEncodedMessage, encodedMessage);
        }

        private static void SetMessageHeader(IMessage msg, string messageCode, string messageTriggerEvent, string processingId)
        {
            var msh = (ISegment)msg.GetStructure("MSH");

            var version27 = new Version("2.7");
            var messageVersion = new Version(msg.Version);

            Terser.Set(msh, 1, 0, 1, 1, "|");
            Terser.Set(msh, 2, 0, 1, 1, version27 > messageVersion ? "^~\\&" : "^~\\&#");
            Terser.Set(msh, 7, 0, 1, 1, DateTime.Now.ToString("yyyyMMddHHmmssK"));
            Terser.Set(msh, 9, 0, 1, 1, messageCode);
            Terser.Set(msh, 9, 0, 2, 1, messageTriggerEvent);
            Terser.Set(msh, 10, 0, 1, 1, Guid.NewGuid().ToString());
            Terser.Set(msh, 11, 0, 1, 1, processingId);
            Terser.Set(msh, 12, 0, 1, 1, msg.Version);
        }
    }
}