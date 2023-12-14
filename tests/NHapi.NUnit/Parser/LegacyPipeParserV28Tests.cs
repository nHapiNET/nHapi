namespace NHapi.NUnit.Parser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::NUnit.Framework;

    using NHapi.Base.Parser;
    using NHapi.Model.V28.Datatype;
    using NHapi.Model.V28.Message;

    public class LegacyPipeParserV28Tests
    {
        private string GetMessage()
        {
            return "MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.8|||AL|||ASCII\r"
                 + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
                 + "ORC|||||F\r"
                 + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
                 + "OBX|1|FT|||This\\.br\\is\\.br\\A Test~MoreText~SomeMoreText||||||F\r"
                 + "OBX|2|FT|||This\\.br\\is\\.br\\A Test~MoreText~SomeMoreText||||||F\r"
                 + "OBX|3|FT|||This\\.br\\is\\.br\\A Test~MoreText~SomeMoreText||||||F";
        }

        [Test]
        public void TestOBR5RepeatingValuesMessage_DataTypesAndRepetitions()
        {
            var parser = new LegacyPipeParser();
            var oru = (ORU_R01)parser.Parse(GetMessage());

            var expectedObservationCount = 3;
            var parsedObservations = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBSERVATIONRepetitionsUsed;
            Assert.That(
                parsedObservations,
                Is.EqualTo(expectedObservationCount),
                $"Expected 3 OBX repetitions used for this segment, found {parsedObservations}");

            foreach (var obs in oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION().OBX.GetObservationValue())
            {
                Assert.That(obs.Data, Is.InstanceOf<FT>());
            }
        }

        [Test]
        public void Test_28DataTypesParseCorrectly()
        {
            var message =
                "MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.8|||AL|||ASCII\r"
              + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
              + "ORC|||||F\r"
              + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
              + "OBX|1|DT|||DTValue||||||F\r"
              + "OBX|2|ST|||STValue||||||F\r"
              + "OBX|3|TM|||TMValue||||||F\r"
              + "OBX|4|ID|||IDValue||||||F\r"
              + "OBX|5|IS|||ISValue||||||F";

            var parser = new LegacyPipeParser();
            var oru = (ORU_R01)parser.Parse(message);

            var expectedObservationCount = 5;
            var parsedObservations = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBSERVATIONRepetitionsUsed;
            Assert.That(
                parsedObservations,
                Is.EqualTo(expectedObservationCount),
                $"Expected {expectedObservationCount} OBX repetitions used for this segment, found {parsedObservations}");

            var index = 0;
            var obs = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(index).OBX.GetObservationValue().FirstOrDefault();
            Assert.That(obs.Data, Is.InstanceOf<DT>());
            index++;
            obs = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(index).OBX.GetObservationValue().FirstOrDefault();
            Assert.That(obs.Data, Is.InstanceOf<ST>());
            index++;
            obs = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(index).OBX.GetObservationValue().FirstOrDefault();
            Assert.That(obs.Data, Is.InstanceOf<TM>());
            index++;
            obs = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(index).OBX.GetObservationValue().FirstOrDefault();
            Assert.That(obs.Data, Is.InstanceOf<ID>());
            index++;
            obs = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(index).OBX.GetObservationValue().FirstOrDefault();
            Assert.That(obs.Data, Is.InstanceOf<IS>());
        }

        [Test]
        public void TestADTA04IsMappedAsA01()
        {
            var hl7Data =
                "MSH|^~\\&|CohieCentral|COHIE|Clinical Data Provider|TCH|20060228155525||ADT^A04|1|P|2.8|\r"
              + "EVN|\r"
              + "PID|1|12345\r"
              + "PV1|1";

            var parser = new LegacyPipeParser();
            var msg = parser.Parse(hl7Data);

            Assert.That(msg, Is.Not.Null, "Message should not be null");
            var a04 = (ADT_A01)msg;

            Assert.Multiple(() =>
            {
                Assert.That(a04.MSH.MessageType.TriggerEvent.Value, Is.EqualTo("A04"));
                Assert.That(a04.PID.SetIDPID.Value, Is.EqualTo("1"));
            });
        }

        [Test]
        public void TestAdtA04AndA01MessageStructure()
        {
            var result = PipeParser.GetMessageStructureForEvent("ADT_A04", "2.8");
            Assert.That(result, Is.EqualTo("ADT_A01").IgnoreCase, "ADT_A04 returns ADT_A01");

            result = PipeParser.GetMessageStructureForEvent("ADT_A13", "2.8");
            Assert.That(result, Is.EqualTo("ADT_A01").IgnoreCase, "ADT_A13 returns ADT_A01");

            result = PipeParser.GetMessageStructureForEvent("ADT_A08", "2.8");
            Assert.That(result, Is.EqualTo("ADT_A01").IgnoreCase, "ADT_A08 returns ADT_A01");

            result = PipeParser.GetMessageStructureForEvent("ADT_A01", "2.8");
            Assert.That(result, Is.EqualTo("ADT_A01").IgnoreCase, "ADT_A01 returns ADT_A01");
        }

        /// <summary>
        /// https://github.com/nHapiNET/nHapi/issues/135.
        /// </summary>
        [TestCaseSource(nameof(validV28ValueTypes))]
        public void TestObx5DataTypeIsSetFromObx2_AndAllDataTypesAreConstructable(Type expectedObservationValueType)
        {
            var message =
                "MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.8|||AL|||ASCII\r"
              + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
              + "ORC|||||F\r"
              + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
             + $"OBX|1|{expectedObservationValueType.Name}|||{expectedObservationValueType.Name}Value||||||F";

            var parser = new LegacyPipeParser();

            var parsed = (ORU_R01)parser.Parse(message);

            var actualObservationValueType = parsed.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data;

            Assert.That(actualObservationValueType, Is.AssignableFrom(expectedObservationValueType));
        }

        [Test]
        public void TestObx5DataTypeIsSetFromObx2_WhenObx2IsEmptyAndDefaultIsSet_DefaultTypeIsUsed()
        {
            var expectedObservationValueType = typeof(ST);

            var message =
                "MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.8|||AL|||ASCII\r"
              + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
              + "ORC|||||F\r"
              + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
              + "OBX|1||||STValue||||||F\r";

            var parser = new LegacyPipeParser();
            var options = new ParserOptions { DefaultObx2Type = "ST" };

            var parsed = (ORU_R01)parser.Parse(message, options);

            var actualObservationValueType = parsed.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data;
            var obx2 = parsed.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.ValueType;

            Assert.Multiple(() =>
            {
                Assert.That(obx2.Value, Is.EqualTo("ST"));
                Assert.That(actualObservationValueType, Is.AssignableFrom(expectedObservationValueType));
                Assert.That(((ST)actualObservationValueType).Value, Is.EqualTo("STValue"));
            });
        }

        /// <summary>
        /// Specified in Table 0125.
        /// </summary>
        private static IEnumerable<Type> validV28ValueTypes = new List<Type>
        {
            typeof(AD),
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
            typeof(TX),
            typeof(XAD),
            typeof(XCN),
            typeof(XON),
            typeof(XPN),
            typeof(XTN),
        };
    }
}