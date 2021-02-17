namespace NHapi.NUnit
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using global::NUnit.Framework;

    using NHapi.Base.Model;
    using NHapi.Base.Parser;
    using NHapi.Model.V26.Datatype;
    using NHapi.Model.V26.Message;

    public class PipeParsingFixture26
    {
        public string GetMessage()
        {
            return @"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.6|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|FT|||This\.br\is\.br\A Test~MoreText~SomeMoreText||||||F
OBX|2|FT|||This\.br\is\.br\A Test~MoreText~SomeMoreText||||||F
OBX|3|FT|||This\.br\is\.br\A Test~MoreText~SomeMoreText||||||F"
            .Replace(Environment.NewLine, "\r");
        }

        [Test]
        public void TestOBR5RepeatingValuesMessage_DataTypesAndRepetitions()
        {
            var parser = new PipeParser();
            var oru = new ORU_R01();
            oru = (ORU_R01)parser.Parse(GetMessage());

            var expectedObservationCount = 3;
            var parsedObservations = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBSERVATIONRepetitionsUsed;
            var parsedCorrectNumberOfObservations = parsedObservations == expectedObservationCount;
            Assert.IsTrue(
                parsedCorrectNumberOfObservations,
                string.Format("Expected 3 OBX repetitions used for this segment, found {0}", parsedObservations));

            foreach (var obs in oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION().OBX.GetObservationValue())
            {
                Assert.IsTrue(obs.Data is FT);
            }
        }

        [Test]
        public void Test_26DataTypesParseCorrectly()
        {
            // OBX|4|ID|||IDValue||||||F //Doesn't work
            // OBX|5|IS|||ISValue||||||F //Doesn't work
            var message = @"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.6|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|DT|||DTValue||||||F
OBX|2|ST|||STValue||||||F
OBX|3|TM|||TMValue||||||F".Replace(Environment.NewLine, "\r");

            var parser = new PipeParser();
            var oru = new ORU_R01();
            oru = (ORU_R01)parser.Parse(message);

            var expectedObservationCount = 3;
            var parsedObservations = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBSERVATIONRepetitionsUsed;
            var parsedCorrectNumberOfObservations = parsedObservations == expectedObservationCount;
            Assert.IsTrue(
                parsedCorrectNumberOfObservations,
                string.Format("Expected {1} OBX repetitions used for this segment, found {0}", parsedObservations, expectedObservationCount));

            var index = 0;
            var obs = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(index).OBX.GetObservationValue().FirstOrDefault();
            Assert.IsTrue(obs.Data is DT);
            index++;
            obs = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(index).OBX.GetObservationValue().FirstOrDefault();
            Assert.IsTrue(obs.Data is ST);
            index++;
            obs = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(index).OBX.GetObservationValue().FirstOrDefault();
            Assert.IsTrue(obs.Data is TM);
        }

        [Test]
        public void TestADTA04IsMappedAsA01()
        {
            var hl7Data = @"MSH|^~\&|CohieCentral|COHIE|Clinical Data Provider|TCH|20060228155525||ADT^A04|1|P|2.6|
EVN|
PID|1|12345
PV1|1".Replace(Environment.NewLine, "\r");

            var parser = new PipeParser();
            var msg = parser.Parse(hl7Data);

            Assert.IsNotNull(msg, "Message should not be null");
            var a04 = (ADT_A01)msg;

            Assert.AreEqual("A04", a04.MSH.MessageType.TriggerEvent.Value);
            Assert.AreEqual("1", a04.PID.SetIDPID.Value);
        }

        [Test]
        public void TestAdtA04AndA01MessageStructure()
        {
            var result = PipeParser.GetMessageStructureForEvent("ADT_A04", "2.6");
            var isSame = string.Compare("ADT_A01", result, StringComparison.InvariantCultureIgnoreCase) == 0;
            Assert.IsTrue(isSame, "ADT_A04 returns ADT_A01");

            result = PipeParser.GetMessageStructureForEvent("ADT_A13", "2.6");
            isSame = string.Compare("ADT_A01", result, StringComparison.InvariantCultureIgnoreCase) == 0;
            Assert.IsTrue(isSame, "ADT_A13 returns ADT_A01");

            result = PipeParser.GetMessageStructureForEvent("ADT_A08", "2.6");
            isSame = string.Compare("ADT_A01", result, StringComparison.InvariantCultureIgnoreCase) == 0;
            Assert.IsTrue(isSame, "ADT_A08 returns ADT_A01");

            result = PipeParser.GetMessageStructureForEvent("ADT_A01", "2.6");
            isSame = string.Compare("ADT_A01", result, StringComparison.InvariantCultureIgnoreCase) == 0;
            Assert.IsTrue(isSame, "ADT_A01 returns ADT_A01");
        }

        [Test]
        public void TestORUR01_HasDTMFieldParsed()
        {
            var hl7Data = @"MSH|^~\&|Paceart|Medtronic|||20160628142621||ORU^R01^ORU_R01|20160628142621000001|P|2.6|||AL|NE|||||IHE_PCD_ORU_R01^IHE PCD^1.3.6.1.4.1.19376.1.6.1.9.1^ISO
PID|||MODEL:A3DR01 Advisa DR MRI/SERIAL:PZK600806S^^^MDT^U~^^^^Patient ID~A10000641^^^^Paceart||Patient^Test||19100000000000+0000
PV1|1|A
OBR|1||dfac748c-213c-e611-80c5-000c2996266c|754050^MDC_IDC_ENUM_SESS_TYPE_InClinic^MDC^INCLINIC^INCLINIC^MDT|||20160627041809+0000||||||||||||||||||P
OBX|1|DTM|721025^MDC_IDC_SESS_DTM^MDC||20160627041809+0000||||||P";

            var parser = new PipeParser();
            var msg = parser.Parse(hl7Data);

            Assert.IsNotNull(msg, "Message should not be null");
            var oruR01 = (ORU_R01)msg;

            Assert.AreEqual("R01", oruR01.MSH.MessageType.TriggerEvent.Value);
            Assert.AreEqual(null, oruR01.GetPATIENT_RESULT(0).PATIENT.PID.SetIDPID.Value);
            var knownDTM = oruR01.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.ValueType.Value;
            Assert.AreEqual("DTM", knownDTM);
            var knownDTMValue = oruR01.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data as DTM;
            Assert.AreEqual("20160627041809+0000", knownDTMValue.ToString());
        }

        [Test]
        public void TestORUR01_Enumerators()
        {
            var hl7Data = @"MSH|^~\&|Paceart|Medtronic|||20160628142621||ORU^R01^ORU_R01|20160628142621000001|P|2.6|||AL|NE|||||IHE_PCD_ORU_R01^IHE PCD^1.3.6.1.4.1.19376.1.6.1.9.1^ISO
PID|||MODEL:A3DR01 Advisa DR MRI/SERIAL:PZK600806S^^^MDT^U~^^^^Patient ID~A10000641^^^^Paceart||Patient^Test||19100000000000+0000
PV1|1|A
OBR|1||dfac748c-213c-e611-80c5-000c2996266c|754050^MDC_IDC_ENUM_SESS_TYPE_InClinic^MDC^INCLINIC^INCLINIC^MDT|||20160627041809+0000||||||||||||||||||P
OBX|1|ST|||TestString||||||P
OBX|2|NM|||9001||||||P
OBX|3|DTM|||20160627041809+0000||||||P";

            var parser = new PipeParser();
            var msg = parser.Parse(hl7Data);

            Assert.IsNotNull(msg, "Message should not be null");
            var oruR01 = (ORU_R01)msg;

            Assert.AreEqual("R01", oruR01.MSH.MessageType.TriggerEvent.Value);
            Assert.AreEqual(null, oruR01.GetPATIENT_RESULT(0).PATIENT.PID.SetIDPID.Value);

            foreach (var result in oruR01.PATIENT_RESULTs)
            {
                foreach (var orderObservation in result.ORDER_OBSERVATIONs)
                {
                    var index = 1;
                    foreach (var observation in orderObservation.OBSERVATIONs)
                    {
                        if (index == 1)
                        {
                            Assert.IsTrue(observation.OBX.ValueType.Value == "ST");
                        }
                        else if (index == 2)
                        {
                            Assert.IsTrue(observation.OBX.ValueType.Value == "NM");
                        }
                        else if (index == 3)
                        {
                            Assert.IsTrue(observation.OBX.ValueType.Value == "DTM");
                        }

                        index++;
                    }

                    Assert.IsTrue(index == 4);
                }
            }
        }

        [Test]
        public void TestORUR01_AddAndRemoveMethods()
        {
            var hl7Data = @"MSH|^~\&|Paceart|Medtronic|||20160628142621||ORU^R01^ORU_R01|20160628142621000001|P|2.6|||AL|NE|||||IHE_PCD_ORU_R01^IHE PCD^1.3.6.1.4.1.19376.1.6.1.9.1^ISO
PID|||MODEL:A3DR01 Advisa DR MRI/SERIAL:PZK600806S^^^MDT^U~^^^^Patient ID~A10000641^^^^Paceart||Patient^Test||19100000000000+0000
PV1|1|A
OBR|1||dfac748c-213c-e611-80c5-000c2996266c|754050^MDC_IDC_ENUM_SESS_TYPE_InClinic^MDC^INCLINIC^INCLINIC^MDT|||20160627041809+0000||||||||||||||||||P
OBX|1|ST|||TestString||||||P
OBX|2|NM|||9001||||||P
OBX|3|DTM|||20160627041809+0000||||||P";

            var parser = new PipeParser();
            var msg = parser.Parse(hl7Data);

            Assert.IsNotNull(msg, "Message should not be null");
            var oruR01 = (ORU_R01)msg;

            Assert.AreEqual("R01", oruR01.MSH.MessageType.TriggerEvent.Value);
            Assert.AreEqual(null, oruR01.GetPATIENT_RESULT(0).PATIENT.PID.SetIDPID.Value);

            foreach (var result in oruR01.PATIENT_RESULTs)
            {
                foreach (var orderObservation in result.ORDER_OBSERVATIONs)
                {
                    // Add observation of value type 'NO' and assert that the array reflects the expected state
                    var beforeCount = orderObservation.OBSERVATIONs.Count();
                    var newObservation = orderObservation.AddOBSERVATION();
                    newObservation.OBX.ValueType.Value = "NO";
                    var afterAddCount = orderObservation.OBSERVATIONs.Count();
                    Assert.IsTrue(afterAddCount > beforeCount);

                    var last = orderObservation.OBSERVATIONs.Last().OBX.ValueType.Value;
                    Assert.IsTrue(last == "NO");

                    // Remove added observation of value type 'NO' using object reference and assert that the array reflects the expected state
                    orderObservation.RemoveOBSERVATION(newObservation);
                    var afterRemoveCount = orderObservation.OBSERVATIONs.Count();
                    Assert.IsTrue(afterRemoveCount == beforeCount);

                    last = orderObservation.OBSERVATIONs.Last().OBX.ValueType.Value;
                    Assert.IsTrue(last == "DTM");

                    // Added observation of value type 'NO' using object reference and assert that the array reflects the expected state
                    newObservation = orderObservation.AddOBSERVATION();
                    newObservation.OBX.ValueType.Value = "NO";
                    afterAddCount = orderObservation.OBSERVATIONs.Count();
                    Assert.IsTrue(afterAddCount > beforeCount);

                    // Remove added observation of value type 'NO' using index and assert that the array reflects the expected state
                    orderObservation.RemoveOBSERVATIONAt(orderObservation.OBSERVATIONRepetitionsUsed - 1);
                    afterRemoveCount = orderObservation.OBSERVATIONs.Count();
                    Assert.IsTrue(afterRemoveCount == beforeCount);

                    last = orderObservation.OBSERVATIONs.Last().OBX.ValueType.Value;
                    Assert.IsTrue(last == "DTM");

                    // Assert that the array reflects the expected initial state
                    var index = 1;
                    foreach (var observation in orderObservation.OBSERVATIONs)
                    {
                        if (index == 1)
                        {
                            Assert.IsTrue(observation.OBX.ValueType.Value == "ST");
                        }
                        else if (index == 2)
                        {
                            Assert.IsTrue(observation.OBX.ValueType.Value == "NM");
                        }
                        else if (index == 3)
                        {
                            Assert.IsTrue(observation.OBX.ValueType.Value == "DTM");
                        }

                        index++;
                    }

                    Assert.IsTrue(index == 4);

                    // Remove the middle 'NM' Field and assert that the array reflects the expected state
                    orderObservation.RemoveOBSERVATIONAt(1);

                    index = 1;
                    foreach (var observation in orderObservation.OBSERVATIONs)
                    {
                        if (index == 1)
                        {
                            Assert.IsTrue(observation.OBX.ValueType.Value == "ST");
                        }
                        else if (index == 2)
                        {
                            Assert.IsTrue(observation.OBX.ValueType.Value == "DTM");
                        }

                        index++;
                    }

                    Assert.IsTrue(index == 3);

                    // Remove the first Item by object reference and assert that the remaining item is the 'DTM' field
                    orderObservation.RemoveOBSERVATION(orderObservation.OBSERVATIONs.First());

                    var lastRemaining = orderObservation.OBSERVATIONs.First();
                    Assert.IsTrue(lastRemaining.OBX.ValueType.Value == "DTM");

                    Assert.IsTrue(orderObservation.OBSERVATIONRepetitionsUsed == 1);
                }
            }
        }

        [Test]
        [Explicit]
        public void ParseKnownMessageTypeFromFile()
        {
            var filePath = @"C:\Users\Duane\Desktop\ParseErrors\20160628_142635469_b94dde77-857a-4881-8915-6814809c5442.HL7";
            var fileContents = File.ReadAllText(filePath);

            var parser = new PipeParser();
            var msg = parser.Parse(fileContents);

            Assert.IsNotNull(msg, "Message should not be null");
            var oruR01 = (ORU_R01)msg;

            Assert.AreEqual("R01", oruR01.MSH.MessageType.TriggerEvent.Value);
            Assert.AreEqual(null, oruR01.GetPATIENT_RESULT(0).PATIENT.PID.SetIDPID.Value);
            var knownDTM = oruR01.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.ValueType.Value;
            Assert.AreEqual("DTM", knownDTM);
            var knownDTMValue = oruR01.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data as DTM;
            Assert.AreEqual("20160627041809+0000", knownDTMValue.ToString());
        }

        /// <summary>
        /// https://github.com/nHapiNET/nHapi/issues/135.
        /// </summary>
        [TestCaseSource(nameof(validV26ValueTypes))]
        public void TestObx5DataTypeIsSetFromObx2_AndAllDataTypesAreConstructable(Type expectedObservationValueType)
        {
            var message = $@"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.6|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|{expectedObservationValueType.Name}|||{expectedObservationValueType.Name}Value||||||F"
            .Replace(Environment.NewLine, "\r");

            var parser = new PipeParser();

            var parsed = (ORU_R01)parser.Parse(message);

            var actualObservationValueType = parsed.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data;

            Assert.IsAssignableFrom(expectedObservationValueType, actualObservationValueType);
        }

        /// <summary>
        /// Specified in Table 0125.
        /// </summary>
        private static IEnumerable<Type> validV26ValueTypes = new List<Type>
        {
            typeof(AD),
            typeof(CE),
            typeof(CF),
            typeof(CP),
            typeof(CX),
            typeof(DT),
            typeof(ED),
            typeof(FT),
            typeof(ID),
            typeof(MO),
            typeof(NM),
            typeof(RP),
            typeof(SN),
            typeof(ST),
            typeof(TM),
            typeof(TS),
            typeof(TX),
            typeof(XAD),
            typeof(XCN),
            typeof(XON),
            typeof(XPN),
            typeof(XTN),
        };
    }
}