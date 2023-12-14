namespace NHapi.NUnit.Parser
{
    using System;
    using System.IO;

    using global::NUnit.Framework;

    using NHapi.Base;
    using NHapi.Base.Model;
    using NHapi.Base.Parser;
    using NHapi.Base.Util;
    using NHapi.Model.V231.Datatype;
    using NHapi.Model.V231.Message;

    [TestFixture]
    public class PipeParserTests
    {
        private string GetMessage()
        {
            return "MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.3.1|||AL|||ASCII\r"
                 + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
                 + "ORC|||||F\r"
                 + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
                 + "OBX|1|FT|||This\\.br\\is\\.br\\A Test~MoreText~SomeMoreText||||||F";
        }

        [Test]
        public void TestOBR5RepeatingValuesMessage()
        {
            var parser = new PipeParser();
            var oru = (ORU_R01)parser.Parse(GetMessage());

            foreach (var obs in oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION().OBX.GetObservationValue())
            {
                Assert.That(obs.Data, Is.InstanceOf<FT>());
            }
        }

        [Test]
        public void TestSpecialCharacterEncoding()
        {
            var parser = new PipeParser();
            var oru = (ORU_R01)parser.Parse(GetMessage());

            var data = (FT)oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data;
            Assert.That(data.Value, Is.EqualTo(@"This\.br\is\.br\A Test"));
        }

        [Test]
        public void TestSpecialCharacterEntry()
        {
            var parser = new PipeParser();
            var oru = new ORU_R01();
            oru.MSH.MessageType.MessageType.Value = "ORU";
            oru.MSH.MessageType.TriggerEvent.Value = "R01";
            oru.MSH.EncodingCharacters.Value = @"^~\&";
            oru.MSH.VersionID.VersionID.Value = "2.3.1";
            oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.ValueType.Value = "FT";
            oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBR.SetIDOBR.Value = "1";
            var v =
                oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0);
            var text = new ST(oru);
            text.Value = @"This\.br\is\.br\A Test";
            v.Data = text;

            var encodedData = parser.Encode(oru);
            Console.WriteLine(encodedData);
            var msg = parser.Parse(encodedData);
            Console.WriteLine(msg.GetStructureName());
            oru = (ORU_R01)msg;
            var data = (FT)oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data;
            Assert.That(data.Value, Is.EqualTo(@"This\.br\is\.br\A Test"));
        }

        [Test]
        public void TestSpecialCharacterEntryEndingSlash()
        {
            var parser = new PipeParser();
            var oru = new ORU_R01();
            oru.MSH.MessageType.MessageType.Value = "ORU";
            oru.MSH.MessageType.TriggerEvent.Value = "R01";
            oru.MSH.EncodingCharacters.Value = @"^~\&";
            oru.MSH.VersionID.VersionID.Value = "2.3.1";
            oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.ValueType.Value = "FT";
            oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBR.SetIDOBR.Value = "1";
            var v =
                oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0);
            var text = new ST(oru);
            text.Value = @"This\.br\is\.br\A Test~";
            v.Data = text;

            var encodedData = parser.Encode(oru);
            var msg = parser.Parse(encodedData);
            oru = (ORU_R01)msg;
            var data = (FT)oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data;
            Assert.That(data.Value, Is.EqualTo(@"This\.br\is\.br\A Test~"));
        }

        [Test]
        public void TestSpecialCharacterEntryWithAllSpecialCharacters()
        {
            var parser = new PipeParser();
            var oru = new ORU_R01();
            oru.MSH.MessageType.MessageType.Value = "ORU";
            oru.MSH.MessageType.TriggerEvent.Value = "R01";
            oru.MSH.EncodingCharacters.Value = @"^~\&";
            oru.MSH.VersionID.VersionID.Value = "2.3.1";
            oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.ValueType.Value = "FT";
            oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBR.SetIDOBR.Value = "1";
            var v =
                oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0);
            var text = new ST(oru);
            text.Value = @"Th&is\.br\is\.br\A T|e\H\st\";
            v.Data = text;

            var encodedData = parser.Encode(oru);
            Console.WriteLine(encodedData);
            var msg = parser.Parse(encodedData);
            oru = (ORU_R01)msg;
            var data = (FT)oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data;
            Assert.That(data.Value, Is.EqualTo(@"Th&is\.br\is\.br\A T|e\H\st\"));
        }

        [Test]
        public void TestValidHl7Data()
        {
            var parser = new PipeParser();
            var oru = new ORU_R01();
            oru.MSH.MessageType.MessageType.Value = "ORU";
            oru.MSH.MessageType.TriggerEvent.Value = "R01";
            oru.MSH.EncodingCharacters.Value = @"^~\&";
            oru.MSH.VersionID.VersionID.Value = "2.3.1";
            oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.ValueType.Value = "FT";
            oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBR.SetIDOBR.Value = "1";
            var v =
                oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0);
            var text = new ST(oru);
            text.Value = @"Th&is\.br\is\.br\A T|est\";
            v.Data = text;

            var encodedData = parser.Encode(oru);

            var segs = encodedData.Split('\r');
            var fields = segs[2].Split('|');
            var data = fields[5];

            Assert.That(data, Is.EqualTo(@"Th\T\is\.br\is\.br\A T\F\est\E\"));
        }

        [Test]
        public void UnEscapesData()
        {
            // Arrange
            const string content =
                "MSH|^~\\&|TestSys|432^testsys practice|TEST||201402171537||MDM^T02|121906|P|2.3.1||||||||\r"
              + "OBX|1|TX|PROBLEM FOCUSED^PROBLEM FOCUSED^test|1|\\T\\#39;Thirty days have September,\\X0D\\April\\X0A\\June,\\X0A\\and November.\\X0A\\When short February is done,\\E\\X0A\\E\\all the rest have\\T\\nbsp;31.\\T\\#39";

            var parser = new PipeParser();
            var msg = parser.Parse(content);

            // Act
            var segment = msg.GetStructure("OBX") as ISegment;
            var idx = Terser.GetIndices("OBX-5");
            var segmentData = Terser.Get(segment, idx[0], idx[1], idx[2], idx[3]);

            // Assert

            // verify that data was properly un-escaped by NHapi
            // \E\X0A\E\ should be escaped to \X0A\
            // \X0A\ should be un-escaped to \n - this is configurable
            // \X0D\ should be un-escaped to \r - this is configurable
            // \t\ should be un-escaped to &
            const string expectedResult =
                "&#39;Thirty days have September,\rApril\nJune,\nand November.\nWhen short February is done,\\X0A\\all the rest have&nbsp;31.&#39";
            Assert.That(segmentData, Is.EqualTo(expectedResult));
        }

        private static void SetMessageHeader(Model.V251.Message.OML_O21 msg, string messageCode, string messageTriggerEvent, string processingId)
        {
            var msh = msg.MSH;

            Terser.Set(msh, 1, 0, 1, 1, "|");
            Terser.Set(msh, 2, 0, 1, 1, "^~\\&");
            Terser.Set(msh, 7, 0, 1, 1, DateTime.Now.ToString("yyyyMMddHHmmssK"));
            Terser.Set(msh, 9, 0, 1, 1, messageCode);
            Terser.Set(msh, 9, 0, 2, 1, messageTriggerEvent);
            Terser.Set(msh, 10, 0, 1, 1, Guid.NewGuid().ToString());
            Terser.Set(msh, 11, 0, 1, 1, processingId);
            Terser.Set(msh, 12, 0, 1, 1, msg.Version);
        }

        /// <summary>
        /// This test is ported from HAPI:
        /// https://github.com/hapifhir/hapi-hl7v2/blob/3333e3aeae60afb7493f6570456e6280c0e16c0b/hapi-test/src/test/java/ca/uhn/hl7v2/parser/NewPipeParserTest.java#L158
        /// See http://sourceforge.net/p/hl7api/bugs/171/.
        /// </summary>
        [Test]
        public void GreedyMode()
        {
            var msg = new Model.V251.Message.OML_O21();
            SetMessageHeader(msg, "OML", "O21", "T");

            for (var i = 0; i < 5; i++)
            {
                var orc = msg.GetORDER(i).ORC;
                var obr4 = msg.GetORDER(i).OBSERVATION_REQUEST.OBR.UniversalServiceIdentifier;

                orc.OrderControl.Value = "NW";
                orc.PlacerOrderNumber.EntityIdentifier.Value = "ORCID1";
                orc.PlacerOrderNumber.NamespaceID.Value = "HCE";
                orc.PlacerGroupNumber.EntityIdentifier.Value = "grupo";

                obr4.Identifier.Value = "STDIO1";
                obr4.NameOfCodingSystem.Value = "LOINC";
            }

            // Parse and encode
            var parser = new PipeParser();
            msg = parser.Parse(
                parser.Encode(msg),
                new ParserOptions { NonGreedyMode = true }) as Model.V251.Message.OML_O21;
            Assert.That(msg, Is.Not.Null);

            for (var i = 0; i < 5; i++)
            {
                var actual = msg.GetORDER(i).ORC.OrderControl.Value;
                Assert.That(actual, Is.EqualTo("NW"));

                actual = msg.GetORDER(i).OBSERVATION_REQUEST.OBR.UniversalServiceIdentifier.Identifier.Value;
                Assert.That(actual, Is.EqualTo("STDIO1"));
            }

            // Now turn off greedy mode
            msg = parser.Parse(
                parser.Encode(msg),
                new ParserOptions { NonGreedyMode = false }) as Model.V251.Message.OML_O21;
            Assert.That(msg, Is.Not.Null);
            {
                var actual = msg.GetORDER(0).ORC.OrderControl.Value;
                Assert.That(actual, Is.EqualTo("NW"));

                actual = msg.GetORDER(0).OBSERVATION_REQUEST.OBR.UniversalServiceIdentifier.Identifier.Value;
                Assert.That(actual, Is.EqualTo("STDIO1"));
            }

            for (var i = 1; i < 5; i++)
            {
                var actual = msg.GetORDER(i).ORC.OrderControl.Value;
                Assert.That(actual, Is.Null);

                actual = msg.GetORDER(i).OBSERVATION_REQUEST.OBR.UniversalServiceIdentifier.Identifier.Value;
                Assert.That(actual, Is.Null);
            }
        }

        /// <summary>
        /// This test is ported from HAPI:
        /// https://github.com/hapifhir/hapi-hl7v2/blob/3333e3aeae60afb7493f6570456e6280c0e16c0b/hapi-test/src/test/java/ca/uhn/hl7v2/parser/NewPipeParserTest.java#L217
        /// See http://sourceforge.net/p/hl7api/bugs/171/.
        /// </summary>
        [Test]
        public void MoreGreedyMode()
        {
            var testDataDir = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Parser");
            var messageFilename = "OML_O21_messages.txt";
            var messagesAsString = File.ReadAllText(Path.Combine(testDataDir, messageFilename));
            var messages = messagesAsString.Split(
                new[] { "\r\n\r\n" },
                StringSplitOptions.RemoveEmptyEntries);

            var parser = new PipeParser();
            var greedyConfig = new ParserOptions { NonGreedyMode = true };

            foreach (var message in messages)
            {
                var parsedMessage = parser.Parse(message, greedyConfig);

                switch (parsedMessage)
                {
                    case Model.V251.Message.OML_O21 oml251:
                        Assert.That(oml251, Is.Not.Null);
                        Assert.That(oml251.GetORDER(0).OBSERVATION_REQUEST.PRIOR_RESULTRepetitionsUsed, Is.EqualTo(0));
                        break;
                    case Model.V25.Message.OML_O21 oml25:
                        Assert.That(oml25, Is.Not.Null);
                        Assert.That(oml25.GetORDER(0).OBSERVATION_REQUEST.PRIOR_RESULTRepetitionsUsed, Is.EqualTo(0));
                        break;
                    default:
                        Assert.Fail($"Could not parse messages from {messageFilename} into v2.5 nor v.2.5.1 OML_O21.");
                        return;
                }
            }
        }

        /// <summary>
        /// The following 4 tests are ported from hapi
        /// https://github.com/hapifhir/hapi-hl7v2/blob/master/hapi-examples/src/main/java/ca/uhn/hl7v2/examples/ParseInvalidObx2Values.java.
        /// </summary>
        [Test]
        public void Obx5DataTypeIsSetFromObx2_WhenObx2IsEmpty_Hl7ExceptionIsThrown()
        {
            var message =
                "MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.3|||AL|||ASCII\r"
              + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
              + "ORC|||||F\r"
              + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
              + "OBX|1||||STValue||||||F\r";

            var expectedExceptionMessage =
                "OBX-5 is valued, but OBX-2 is not.  A datatype for OBX-5 must be specified using OBX-2.";

            var parser = new PipeParser();

            Assert.That(
                () => parser.Parse(message),
                Throws.TypeOf<HL7Exception>()
                    .With.Message.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void Obx5DataTypeIsSetFromObx2_WhenObx2IsEmptyAndDefaultOptionIsSet_DefaultTypeIsUsed()
        {
            var message =
                "MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.3|||AL|||ASCII\r"
              + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
              + "ORC|||||F\r"
              + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
              + "OBX|1||||STValue||||||F\r";

            var expectedEncodedMessage =
                "MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.3|||AL|||ASCII\r"
              + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
              + "ORC|||||F\r"
              + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
              + "OBX|1|ST|||STValue||||||F\r";

            var parser = new PipeParser();
            var options = new ParserOptions { DefaultObx2Type = "ST" };

            var parsed = parser.Parse(message, options);
            var encodedMessage = parser.Encode(parsed);

            Assert.That(encodedMessage, Is.EqualTo(expectedEncodedMessage));
        }

        [Test]
        public void Obx5DataTypeIsSetFromObx2_WhenObx2IsAnInvalidType_Hl7ExceptionIsThrown()
        {
            var message =
                "MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.3|||AL|||ASCII\r"
              + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
              + "ORC|||||F\r"
              + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
              + "OBX|1|BAD|||STValue||||||F\r";

            var expectedExceptionMessage = "'BAD' in record 1 is invalid for version 2.3: Segment: OBX Field #2";

            var parser = new PipeParser();

            Assert.That(
                () => parser.Parse(message),
                Throws.TypeOf<HL7Exception>()
                    .With.Message.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void Obx5DataTypeIsSetFromObx2_WhenObx2IsAnInvalidTypeAndInvalidOptionIsSet_ConfiguredInvalidTypeIsUsed()
        {
            var expectedObservationValueType = typeof(Model.V23.Datatype.ST);

            var message =
                "MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.3|||AL|||ASCII\r"
              + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
              + "ORC|||||F\r"
              + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
              + "OBX|1|BAD|||STValue||||||F\r";

            var parser = new PipeParser();
            var options = new ParserOptions { InvalidObx2Type = "ST" };

            var parsed = (Model.V23.Message.ORU_R01)parser.Parse(message, options);

            var actualObservationValueType =
                parsed.GetRESPONSE(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX
                    .GetObservationValue(0).Data;

            Assert.Multiple(() =>
            {
                Assert.That(actualObservationValueType, Is.AssignableFrom(expectedObservationValueType));
                Assert.That(((IPrimitive)actualObservationValueType).Value, Is.EqualTo("STValue"));
            });
        }

        /// <summary>
        /// Test that the critical response fields can be parsed from a valid message.
        /// </summary>
        [Test]
        public void GetCriticalResponseDataFromValidMessage()
        {
            var parser = new PipeParser();

            var parsed = parser.GetCriticalResponseData(GetMessage()) as Model.V231.Segment.MSH;
            Assert.That(parsed, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(parsed.FieldSeparator.Value, Is.EqualTo("|"));
                Assert.That(parsed.EncodingCharacters.Value, Is.EqualTo(@"^~\&"));
                Assert.That(parsed.ProcessingID.ProcessingID.Value, Is.EqualTo("P"));
                Assert.That(parsed.MessageControlID.Value, Is.EqualTo("EBzH1711114101206"));
            });
        }

        /// <summary>
        /// Test that a <see cref="HL7Exception"/> is thrown when one of the critical components is missing
        /// from the message.
        /// </summary>
        [Test]
        public void GetCriticalResponseData_FailToParseInvalidMessage()
        {
            var invalidMessage = GetMessage().Replace("P", string.Empty);
            var parser = new PipeParser();

            var expectedExceptionMessage = "Can't parse critical fields from MSH segment";

            Assert.That(
                () => parser.GetCriticalResponseData(invalidMessage),
                Throws.TypeOf<HL7Exception>()
                    .With.Message.Contains(expectedExceptionMessage));
        }

        [Test]
        public void TestUnexpectedSegmentHintsDefault()
        {
            var message =
                "MSH|^~\\&|DATASERVICES|CORPORATE|||20120711120510.2-0500||ADT^A01^ADT_A01|9c906177-dfca-4bbe-9abd-d8eb43df93a0|D|2.6\r"
              + "EVN||20120701000000-0500\r"
              + "PID|1||397979797^^^SN^SN~4242^^^BKDMDM^PI~1000^^^YARDI^PI||Williams^Rory^H^^^^A||19641028000000-0600|M||||||||||31592^^^YARDI^AN\r"
              + "NK1|1|Pond^Amelia^Q^^^^A|SPO|1234 Main St^^Sussex^WI^53089|^PRS^CP^^^^^^^^^555-1212||N\r"
              + "NK1|2|Smith^John^^^^^A~^The Doctor^^^^^A|FND|1234 S Water St^^New London^WI^54961||^WPN^PH^^^^^^^^^555-9999|C\r"
              + "PV1|2|I||R\r"
              + "GT1|1||Doe^John^A^^^^A||5678 Maple Ave^^Sussex^WI^53089|^PRS^PH^^^^^^^^^555-9999|||||OTH\r"
              + "IN1|1|CAP1000|YYDN|ACME HealthCare||||GR0000001|||||||HMO|||||||||||||||||||||PCY-0000042\r"
              + "IN1|2||||||||||||||Medicare|||||||||||||||||||||123-45-6789-A\r"
              + "IN1|3||||||||||||||Medicaid|||||||||||||||||||||987654321L\r"
              + "ZFA|6|31592|12345|YARDI|20120201000000-0600";

            var parser = new PipeParser();

            var msg = (NHapi.Model.V26.Message.ADT_A01)parser.Parse(message);

            var zfas = msg.GetINSURANCE(2).GetAll("ZFA");

            Assert.That(zfas.Length, Is.EqualTo(1));
        }

        /// <summary>
        /// the following 3 tests were ported from
        /// <see href="https://github.com/hapifhir/hapi-hl7v2/blob/3333e3aeae60afb7493f6570456e6280c0e16c0b/hapi-test/src/test/java/ca/uhn/hl7v2/parser/NewPipeParserTest.java#L313">hapi</see>.
        /// <para>
        /// The original feature request for hapi is <seealso href="http://sourceforge.net/p/hl7api/feature-requests/64/">here</seealso>.
        /// </para>
        /// </summary>
        [Test]
        public void TestUnexpectedSegmentHintsInline()
        {
            var message =
                "MSH|^~\\&|DATASERVICES|CORPORATE|||20120711120510.2-0500||ADT^A01^ADT_A01|9c906177-dfca-4bbe-9abd-d8eb43df93a0|D|2.6\r"
              + "EVN||20120701000000-0500\r"
              + "PID|1||397979797^^^SN^SN~4242^^^BKDMDM^PI~1000^^^YARDI^PI||Williams^Rory^H^^^^A||19641028000000-0600|M||||||||||31592^^^YARDI^AN\r"
              + "NK1|1|Pond^Amelia^Q^^^^A|SPO|1234 Main St^^Sussex^WI^53089|^PRS^CP^^^^^^^^^555-1212||N\r"
              + "NK1|2|Smith^John^^^^^A~^The Doctor^^^^^A|FND|1234 S Water St^^New London^WI^54961||^WPN^PH^^^^^^^^^555-9999|C\r"
              + "PV1|2|I||R\r"
              + "GT1|1||Doe^John^A^^^^A||5678 Maple Ave^^Sussex^WI^53089|^PRS^PH^^^^^^^^^555-9999|||||OTH\r"
              + "IN1|1|CAP1000|YYDN|ACME HealthCare||||GR0000001|||||||HMO|||||||||||||||||||||PCY-0000042\r"
              + "IN1|2||||||||||||||Medicare|||||||||||||||||||||123-45-6789-A\r"
              + "IN1|3||||||||||||||Medicaid|||||||||||||||||||||987654321L\r"
              + "ZFA|6|31592|12345|YARDI|20120201000000-0600";

            var parser = new PipeParser();
            var options = new ParserOptions { UnexpectedSegmentBehaviour = UnexpectedSegmentBehaviour.AddInline };

            var msg = (NHapi.Model.V26.Message.ADT_A01)parser.Parse(message, options);

            var zfas = msg.GetINSURANCE(2).GetAll("ZFA");

            Assert.That(zfas.Length, Is.EqualTo(1));
        }

        [Test]
        public void TestUnexpectedSegmentHintsDropToRoot()
        {
            var message =
                "MSH|^~\\&|DATASERVICES|CORPORATE|||20120711120510.2-0500||ADT^A01^ADT_A01|9c906177-dfca-4bbe-9abd-d8eb43df93a0|D|2.6\r"
              + "ZZA|1\r"
              + "EVN||20120701000000-0500\r"
              + "PID|1||397979797^^^SN^SN~4242^^^BKDMDM^PI~1000^^^YARDI^PI||Williams^Rory^H^^^^A||19641028000000-0600|M||||||||||31592^^^YARDI^AN\r"
              + "NK1|1|Pond^Amelia^Q^^^^A|SPO|1234 Main St^^Sussex^WI^53089|^PRS^CP^^^^^^^^^555-1212||N\r"
              + "NK1|2|Smith^John^^^^^A~^The Doctor^^^^^A|FND|1234 S Water St^^New London^WI^54961||^WPN^PH^^^^^^^^^555-9999|C\r"
              + "PV1|2|I||R\r"
              + "GT1|1||Doe^John^A^^^^A||5678 Maple Ave^^Sussex^WI^53089|^PRS^PH^^^^^^^^^555-9999|||||OTH\r"
              + "IN1|1|CAP1000|YYDN|ACME HealthCare||||GR0000001|||||||HMO|||||||||||||||||||||PCY-0000042\r"
              + "IN1|2||||||||||||||Medicare|||||||||||||||||||||123-45-6789-A\r"
              + "IN1|3||||||||||||||Medicaid|||||||||||||||||||||987654321L\r"
              + "ZFA|6|31592|12345|YARDI|20120201000000-0600";

            var parser = new PipeParser();
            var options = new ParserOptions { UnexpectedSegmentBehaviour = UnexpectedSegmentBehaviour.DropToRoot };

            var msg = (NHapi.Model.V26.Message.ADT_A01)parser.Parse(message, options);

            var zzas = msg.GetAll("ZZA");
            var zfas = msg.GetAll("ZFA");

            Assert.Multiple(() =>
            {
                Assert.That(zfas.Length, Is.EqualTo(1));
                Assert.That(zzas.Length, Is.EqualTo(1));
            });
        }

        [Test]
        public void TestUnexpectedSegmentHintsThrowHl7Exception()
        {
            var message =
                "MSH|^~\\&|DATASERVICES|CORPORATE|||20120711120510.2-0500||ADT^A01^ADT_A01|9c906177-dfca-4bbe-9abd-d8eb43df93a0|D|2.6\r"
              + "EVN||20120701000000-0500\r"
              + "PID|1||397979797^^^SN^SN~4242^^^BKDMDM^PI~1000^^^YARDI^PI||Williams^Rory^H^^^^A||19641028000000-0600|M||||||||||31592^^^YARDI^AN\r"
              + "NK1|1|Pond^Amelia^Q^^^^A|SPO|1234 Main St^^Sussex^WI^53089|^PRS^CP^^^^^^^^^555-1212||N\r"
              + "NK1|2|Smith^John^^^^^A~^The Doctor^^^^^A|FND|1234 S Water St^^New London^WI^54961||^WPN^PH^^^^^^^^^555-9999|C\r"
              + "PV1|2|I||R\r"
              + "GT1|1||Doe^John^A^^^^A||5678 Maple Ave^^Sussex^WI^53089|^PRS^PH^^^^^^^^^555-9999|||||OTH\r"
              + "IN1|1|CAP1000|YYDN|ACME HealthCare||||GR0000001|||||||HMO|||||||||||||||||||||PCY-0000042\r"
              + "IN1|2||||||||||||||Medicare|||||||||||||||||||||123-45-6789-A\r"
              + "IN1|3||||||||||||||Medicaid|||||||||||||||||||||987654321L\r"
              + "ZFA|6|31592|12345|YARDI|20120201000000-0600";

            var parser = new PipeParser();
            var options =
                new ParserOptions { UnexpectedSegmentBehaviour = UnexpectedSegmentBehaviour.ThrowHl7Exception };

            var expectedExceptionMessage = "Found unknown segment: ZFA";

            Assert.That(
                () => parser.Parse(message, options),
                Throws.TypeOf<HL7Exception>()
                    .With.Message.EqualTo(expectedExceptionMessage));
        }

        /// <summary>
        /// Tests that the acknowledgement ID can be parsed from valid ACK and NAK messages.
        /// </summary>
        [Test]
        public void TestGetAckId()
        {
            const string ackMsg =
                "MSH|^~\\&|Main_HIS|XYZ_HOSPITAL|iFW|ABC_Lab|20160915003015||ACK|9B38584D|P|2.6.1|\r"
              + "MSA|AA|9B38584D|Everything was okay dokay!|";
            const string nakMsg =
                "MSH|^~\\&|^^|DOE^^|DCC^^|DOE^^|20050829141336||ACK^|1125342816253.100000055|P|2.3.1|\r"
              + "MSA|AE|00000001|Patient id was not found, must be of type 'MR'|||^^HL70357|\r"
              + "ERR|PID^1^3^^^HL70357|";
            const string messageRejection =
                "MSH|^~\\&|DCS|MYIIS|MYIIS||200906040000-0500||ACK^V04^ACK|12343467|P|2.5.1|||\r"
              + "MSA|AR|9299381\r"
              + "ERR||MSH^1^12|203^unsupported version id^^HL70357|E||||Unsupported HL7 Version ID-Message rejected\r";

            var parser = new PipeParser();

            Assert.Multiple(
                () =>
                {
                    Assert.That(parser.GetAckID(ackMsg), Is.EqualTo("9B38584D"));
                    Assert.That(parser.GetAckID(nakMsg), Is.EqualTo("00000001"));
                    Assert.That(parser.GetAckID(messageRejection), Is.EqualTo("9299381"));
                });
        }

        /// <summary>
        /// Tests that null is returned when attempting to parse the acknowledgement ID from invalid messages.
        /// </summary>
        [Test]
        public void TestGetAckIdForInvalidMessages()
        {
            const string missingMSASegment =
                "MSH|^~\\&|Main_HIS|XYZ_HOSPITAL|iFW|ABC_Lab|20160915003015||ACK|9B38584D|P|2.6.1|\r"
              + "ZSA|AA|9B38584D|Everything was okay dokay!|";
            const string msaOnly = "MSA|AA|1|";

            var parser = new PipeParser();

            Assert.Multiple(() =>
            {
                Assert.That(parser.GetAckID(missingMSASegment), Is.EqualTo(null));
                Assert.That(parser.GetAckID(msaOnly), Is.EqualTo(null));
            });
        }

        [Test]
        [Explicit]
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
        public void TestParseORL_O34(string version)
        {
            var message =
                $"MSH|^~\\&|LIS|LAB|HIS|HOSP_SYS|20110329142202||ORL^O34^ORL_O34|90|P|{version}\r"
               + "MSA|AA|12201\r"
               + "PID|1||32XX77^^^^HIS_PAC||SAMPLE^PATIENT^^^^^L||19981126|M\r"
               + "SPM|25081299|36201^0310170||K^kri-EDTA|||||||||||||20110329142201.267+0200|||||||||1\r"
               + "ORC|OK|36201|02000110170|40201|||||20110329142201.312+0200||||||||||||44129-A^^^^^^ORG^^^Redna ambulanta\r"
               + "TQ1|||||||||R\r"
               + "OBR||36201|02000110170|020001^K-Hemogram^KC_PEK_LIS_PRE||||||||||||12345^TEST^DOCTOR||||||||O\r"
               + "SPM|25081299|36201^0310170||K^kri-EDTA|||||||||||||20110329142201.267+0200|||||||||1\r";

            Console.WriteLine($"Testing ORL^O34 parse for version {version}");

            var parser = new PipeParser();

            Assert.That(() => parser.Parse(message), Throws.Nothing);
        }
    }
}