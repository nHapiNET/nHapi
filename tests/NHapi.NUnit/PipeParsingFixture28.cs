namespace NHapi.NUnit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::NUnit.Framework;

    using NHapi.Base.Model;
    using NHapi.Base.Parser;
    using NHapi.Model.V28.Datatype;
    using NHapi.Model.V28.Message;

    public class PipeParsingFixture28
    {
        public string GetMessage()
        {
            return @"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.8|||AL|||ASCII
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
        public void Test_28DataTypesParseCorrectly()
        {
            // OBX|4|ID|||IDValue||||||F //Doesn't work
            // OBX|5|IS|||ISValue||||||F //Doesn't work
            var message = @"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.8|||AL|||ASCII
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
            var hl7Data = @"MSH|^~\&|CohieCentral|COHIE|Clinical Data Provider|TCH|20060228155525||ADT^A04|1|P|2.8|
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
            var result = PipeParser.GetMessageStructureForEvent("ADT_A04", "2.8");
            var isSame = string.Compare("ADT_A01", result, StringComparison.InvariantCultureIgnoreCase) == 0;
            Assert.IsTrue(isSame, "ADT_A04 returns ADT_A01");

            result = PipeParser.GetMessageStructureForEvent("ADT_A13", "2.8");
            isSame = string.Compare("ADT_A01", result, StringComparison.InvariantCultureIgnoreCase) == 0;
            Assert.IsTrue(isSame, "ADT_A13 returns ADT_A01");

            result = PipeParser.GetMessageStructureForEvent("ADT_A08", "2.8");
            isSame = string.Compare("ADT_A01", result, StringComparison.InvariantCultureIgnoreCase) == 0;
            Assert.IsTrue(isSame, "ADT_A08 returns ADT_A01");

            result = PipeParser.GetMessageStructureForEvent("ADT_A01", "2.8");
            isSame = string.Compare("ADT_A01", result, StringComparison.InvariantCultureIgnoreCase) == 0;
            Assert.IsTrue(isSame, "ADT_A01 returns ADT_A01");
        }

        /// <summary>
        /// https://github.com/nHapiNET/nHapi/issues/135.
        /// </summary>
        [TestCaseSource(nameof(validV28ValueTypes))]
        public void TestObx5DataTypeIsSetFromObx2_AndAllDataTypesAreConstructable(Type expectedObservationValueType)
        {
            var message = $@"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.8|||AL|||ASCII
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