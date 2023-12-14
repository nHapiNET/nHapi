namespace NHapi.NUnit.Parser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::NUnit.Framework;

    using NHapi.Base.Model;
    using NHapi.Base.Parser;
    using NHapi.Model.V25.Datatype;
    using NHapi.Model.V25.Message;

    /// <summary>
    /// This test case is in response to BUG 1807858 on source forge.  This BUG really isn't a bug, but the expected functionality.
    /// </summary>
    [TestFixture]
    public class PipeParserV25Tests
    {
        [Test]
        public void TestAdtA28MappingFromHl7()
        {
            var hl7Data =
                "MSH|^~\\&|CohieCentral|COHIE|Clinical Data Provider|TCH|20060228155525||ADT^A28^ADT_A05|1|P|2.5|\r"
              + "EVN|\r"
              + "PID|1|12345\r"
              + "PV1|1";

            var parser = new PipeParser();
            var msg = parser.Parse(hl7Data);

            Assert.That(msg, Is.Not.Null, "Message should not be null");
            var a05 = (ADT_A05)msg;

            Assert.Multiple(() =>
            {
                Assert.That(a05.MSH.MessageType.TriggerEvent.Value, Is.EqualTo("A28"));
                Assert.That(a05.PID.SetIDPID.Value, Is.EqualTo("1"));
            });
        }

        [Test]
        public void TestAdtA28MappingToHl7()
        {
            var a05 = new ADT_A05();

            a05.MSH.MessageType.MessageCode.Value = "ADT";
            a05.MSH.MessageType.TriggerEvent.Value = "A28";
            a05.MSH.MessageType.MessageStructure.Value = "ADT_A05";
            var parser = new PipeParser();
            var msg = parser.Encode(a05);

            var data = msg.Split('|');
            Assert.That(data[8], Is.EqualTo("ADT^A28^ADT_A05"));
        }

        [Test]
        public void TestAdtA04AndA01MessageStructure()
        {
            var result = PipeParser.GetMessageStructureForEvent("ADT_A04", "2.5");
            Assert.That(result, Is.EqualTo("ADT_A01").IgnoreCase, "ADT_A04 returns ADT_A01");

            result = PipeParser.GetMessageStructureForEvent("ADT_A13", "2.5");
            Assert.That(result, Is.EqualTo("ADT_A01").IgnoreCase, "ADT_A13 returns ADT_A01");

            result = PipeParser.GetMessageStructureForEvent("ADT_A08", "2.5");
            Assert.That(result, Is.EqualTo("ADT_A01").IgnoreCase, "ADT_A08 returns ADT_A01");

            result = PipeParser.GetMessageStructureForEvent("ADT_A01", "2.5");
            Assert.That(result, Is.EqualTo("ADT_A01").IgnoreCase, "ADT_A01 returns ADT_A01");
        }

        /// <summary>
        /// https://github.com/nHapiNET/nHapi/issues/135.
        /// </summary>
        [TestCaseSource(nameof(validV25ValueTypes))]
        public void TestObx5DataTypeIsSetFromObx2_AndAllDataTypesAreConstructable(Type expectedObservationValueType)
        {
            var message =
                "MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5|||AL|||ASCII\r"
              + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
              + "ORC|||||F\r"
              + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
             + $"OBX|1|{expectedObservationValueType.Name}|||{expectedObservationValueType.Name}Value||||||F";

            var parser = new PipeParser();

            var parsed = (ORU_R01)parser.Parse(message);

            var actualObservationValueType = parsed.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data;

            Assert.That(actualObservationValueType, Is.AssignableFrom(expectedObservationValueType));
        }

        /// <summary>
        /// https://github.com/nHapiNET/nHapi/issues/276.
        /// </summary>
        [Test]
        public void TestParsingQPD3_WhenQPD3HasMultipleRepetitions_NoExceptionIsThrown()
        {
            var message =
                "MSH|^~\\&|PatientManager|IHE|ICS|FORTH|20220215130712||QBP^Q22^QBP_Q21|5b2e49550924456db9e0844e35348144|P|2.5||||||UNICODE UTF-8\r"
              + "QPD|IHE PDQ Query|20220215130712|@PID.5.2^fname~@PID.7.1^20220202~@PID.8^M|||||^^^IHEFACILITY&1.3.6.1.4.1.21367.3000.1.6&ISO~^^^IHEBLUE&1.3.6.1.4.1.21367.13.20.3000&ISO\r"
              + "RCP|I";

            var parser = new PipeParser();
            var parsed = (QBP_Q21)parser.Parse(message);

            var qpd3Fields = parsed.QPD.GetField(3).Cast<Varies>().ToList();

            Assert.Multiple(() =>
            {
                Assert.That(qpd3Fields, Has.Count.EqualTo(3));

                Assert.That(((GenericPrimitive)((Varies)((GenericComposite)qpd3Fields[0].Data)[0]).Data).Value, Is.EqualTo("@PID.5.2"));
                Assert.That(((GenericPrimitive)((Varies)((GenericComposite)qpd3Fields[0].Data)[1]).Data).Value, Is.EqualTo("fname"));

                Assert.That(((GenericPrimitive)((Varies)((GenericComposite)qpd3Fields[1].Data)[0]).Data).Value, Is.EqualTo("@PID.7.1"));
                Assert.That(((GenericPrimitive)((Varies)((GenericComposite)qpd3Fields[1].Data)[1]).Data).Value, Is.EqualTo("20220202"));

                Assert.That(((GenericPrimitive)((Varies)((GenericComposite)qpd3Fields[2].Data)[0]).Data).Value, Is.EqualTo("@PID.8"));
                Assert.That(((GenericPrimitive)((Varies)((GenericComposite)qpd3Fields[2].Data)[1]).Data).Value, Is.EqualTo("M"));
            });
        }

        [Test]
        public void TestObx5DataTypeIsSetFromObx2_WhenObx2IsEmptyAndDefaultIsSet_DefaultTypeIsUsed()
        {
            var expectedObservationValueType = typeof(ST);

            var message =
                "MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5|||AL|||ASCII\r"
              + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
              + "ORC|||||F\r"
              + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
              + "OBX|1||||STValue||||||F\r";

            var parser = new PipeParser();
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
        private static IEnumerable<Type> validV25ValueTypes = new List<Type>
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