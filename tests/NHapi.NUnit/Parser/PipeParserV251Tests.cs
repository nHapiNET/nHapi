namespace NHapi.NUnit.Parser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::NUnit.Framework;

    using NHapi.Base.Parser;
    using NHapi.Model.V251.Datatype;
    using NHapi.Model.V251.Message;

    internal class PipeParserV251Tests
    {
        public string GetMessage()
        {
            return "MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5.1|||AL|||ASCII\r"
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
        public void Test_251DataTypesParseCorrectly()
        {
            var message =
                "MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5.1|||AL|||ASCII\r"
              + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
              + "ORC|||||F\r"
              + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
              + "OBX|1|DT|||DTValue||||||F\r"
              + "OBX|2|ST|||STValue||||||F\r"
              + "OBX|3|TM|||TMValue||||||F\r"
              + "OBX|4|ID|||IDValue||||||F\r"
              + "OBX|5|IS|||ISValue||||||F";

            var parser = new PipeParser();
            var oru = new ORU_R01();
            oru = (ORU_R01)parser.Parse(message);

            var expectedObservationCount = 5;
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
            index++;
            obs = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(index).OBX.GetObservationValue().FirstOrDefault();
            Assert.IsTrue(obs.Data is ID);
            index++;
            obs = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(index).OBX.GetObservationValue().FirstOrDefault();
            Assert.IsTrue(obs.Data is IS);
        }

        [Test]
        public void TestADTA04IsMappedAsA01()
        {
            var hl7Data =
                "MSH|^~\\&|CohieCentral|COHIE|Clinical Data Provider|TCH|20060228155525||ADT^A04|1|P|2.5.1|\r"
              + "EVN|\r"
              + "PID|1|12345\r"
              + "PV1|1";

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
            var result = PipeParser.GetMessageStructureForEvent("ADT_A04", "2.5.1");
            var isSame = string.Compare("ADT_A01", result, StringComparison.InvariantCultureIgnoreCase) == 0;
            Assert.IsTrue(isSame, "ADT_A04 returns ADT_A01");

            result = PipeParser.GetMessageStructureForEvent("ADT_A13", "2.5.1");
            isSame = string.Compare("ADT_A01", result, StringComparison.InvariantCultureIgnoreCase) == 0;
            Assert.IsTrue(isSame, "ADT_A13 returns ADT_A01");

            result = PipeParser.GetMessageStructureForEvent("ADT_A08", "2.5.1");
            isSame = string.Compare("ADT_A01", result, StringComparison.InvariantCultureIgnoreCase) == 0;
            Assert.IsTrue(isSame, "ADT_A08 returns ADT_A01");

            result = PipeParser.GetMessageStructureForEvent("ADT_A01", "2.5.1");
            isSame = string.Compare("ADT_A01", result, StringComparison.InvariantCultureIgnoreCase) == 0;
            Assert.IsTrue(isSame, "ADT_A01 returns ADT_A01");
        }

        /// <summary>
        /// https://github.com/nHapiNET/nHapi/issues/135.
        /// </summary>
        [TestCaseSource(nameof(validV251ValueTypes))]
        public void TestObx5DataTypeIsSetFromObx2_AndAllDataTypesAreConstructable(Type expectedObservationValueType)
        {
            var message =
                "MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5.1|||AL|||ASCII\r"
              + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
              + "ORC|||||F\r"
              + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
             + $"OBX|1|{expectedObservationValueType.Name}|||{expectedObservationValueType.Name}Value||||||F";

            var parser = new PipeParser();

            var parsed = (ORU_R01)parser.Parse(message);

            var actualObservationValueType = parsed.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data;

            Assert.IsAssignableFrom(expectedObservationValueType, actualObservationValueType);
        }

        /// <summary>
        /// Specified in Table 0125.
        /// </summary>
        private static IEnumerable<Type> validV251ValueTypes = new List<Type>
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

        /// <summary>
        /// https://github.com/nHapiNET/nHapi/issues/232.
        /// </summary>
        [Test]
        public void ParseORDERGroupRepetitionsIn_OML_O33()
        {
            const string twoTestOrderMessage =
                "MSH|^~\\&|||||20210921154451+1000||OML^O33^OML_O33|20210921154451|P|2.5.1|||NE|AL||UNICODE UTF-8|||LAB-28^IHE\r"
                + "SPM|1|||SER^Serum^HL70487|||||||P^Patient^HL70369\r"
                + "SAC|||Found_TT1_TT2_SER_098\r"
                + "ORC|NW||||||||20210921154451\r"
                + "OBR|1|AWOS_ID_Found_TT1_TT2_SER_098_0||TT1^Test Type 1^99000\r"
                + "ORC|NW||||||||20210921154451\r"
                + "OBR|2|AWOS_ID_Found_TT1_TT2_SER_098_1||TT2^Test Type 2^99000";

            var parser = new PipeParser();
            var oml = parser.Parse(twoTestOrderMessage, new ParserOptions { NonGreedyMode = true }) as OML_O33;

            Assert.NotNull(oml);

            var specimen = oml.SPECIMENs.ElementAt(0);
            Assert.AreEqual(2, specimen.ORDERRepetitionsUsed);

            var firstOrder = specimen.ORDERs.ElementAt(0);
            var firstObr = firstOrder.OBSERVATION_REQUEST.OBR.UniversalServiceIdentifier;
            Assert.AreEqual("TT1", firstObr.Identifier.Value);

            var secondOrder = specimen.ORDERs.ElementAt(1);
            var secondObr = secondOrder.OBSERVATION_REQUEST.OBR.UniversalServiceIdentifier;
            Assert.AreEqual("TT2", secondObr.Identifier.Value);
        }

        /// <summary>
        /// https://github.com/nHapiNET/nHapi/issues/65.
        /// </summary>
        [Test]
        public void ParseORDERGroupRepetitionsIn_OML_O21()
        {
            const string message =
                "MSH|^~\\&|PracticeFusion|1|||20130903193451+0000||OML^O21^OML_O21|PFOMSGID999999999|T|2.5.1|||AL|NE|||||ELINCS_MT-OML-1_1.0\r"
                + "PID|1||JD256960^^^^PT~b79a936f-eefb-4d39-8a8f-09ab61a8d6b4^^^^PI||Test^Patient^M||20040229|M|||10 Main St^^San Francisco^CA^94100||^^^patientemail@email.com^^555^5555555~^^^^^555^5555555\r"
                + "PV1|1|U||||||||||||||||||T\r"
                + "IN1|1|Other|47198|Anthem Blue Cross|10 Main St^^Fairfax^CA^94930|||GRP100|||Acme Co|||||Doe^Jane^O|SPO^Spouse^HL70063|20000410|10 Main St^^San Francisco^CA^94100|||||||||||||||||887766\r"
                + "GT1|1||Doe^John^M||10 Main St^^San Francisco^CA^94100|||||P\r"
                + "ORC|NW|1403R8NY||1403R8NY||||||||1234567893^Provider^Test^^^^^^^^^^NPI||^^^^^555^5555555||||||||||420 Taylor St^^San Francisco^CA^94102\r"
                + "TQ1|1||||||||S\r"
                + "OBR|1|PF-13-00011||0029-9^ACID FAST BACILLI STAIN,SPUTUM^99BIO^^^LN|||20130815110800+0000||||O|||||||||RO\r"
                + "NTE|1||Here is note with special characters like \\& and \\~ and even \\\\| just for you\r"
                + "DG1|1||800.3^Closed fracture of vault of skull with other and unspecified intracranial hemorrhage^I9C|||F\r"
                + "DG1|2||601.1^Chronic prostatitis^I9C|||F\r"
                + "ORC|NW|1403R8NY||PF-13-00011||||||||1234567893^Provider^Test^^^^^^^^^^NPI||^^^^^555^5555555||||||||||420 Taylor St^^San Francisco^CA^94102\r"
                + "OBR|2|PF-13-00011||0004-2^CHEM 12 PROFILE^99BIO^^^LN|||20130820111100+0000||||O|||||||||RO\r"
                + "DG1|1||552^Other hernia of abdominal cavity, with obstruction, but without mention of gangrene^I9C|||F\r"
                + "DG1|2||350.2^Atypical face pain^I9C|||F\r"
                + "DG1|3||352.3^Disorders of pneumogastric [10th] nerve^I9C|||F\r"
                + "DG1|4||401^Essential hypertension^I9C|||F\r"
                + "OBX|1|ST|How are you feeling?^How are you feeling?^99BIO||True||||||F\r"
                + "ORC|NW|1403R8NY||1403R8NY||||||||1234567893^Provider^Test^^^^^^^^^^NPI||^^^^^555^5||||||||||420 Taylor St^^San Francisco^CA^94102\r"
                + "OBR|3|1403R8NY||1165-0^ANTI-JO^99BIO^^^LN|||20130814111300+0000||||O|||||||||RO\r"
                + "NTE|1||And another note\r"
                + "DG1|1||666^Postpartum hemorrhage^I9C|||F";

            var parser = new PipeParser();
            var oml = parser.Parse(message, new ParserOptions { NonGreedyMode = true }) as OML_O21;

            Assert.NotNull(oml);

            Assert.AreEqual(3, oml.ORDERRepetitionsUsed);

            var firstOrder = oml.ORDERs.ElementAt(0);
            var firstObr = firstOrder.OBSERVATION_REQUEST.OBR.UniversalServiceIdentifier;
            Assert.AreEqual("0029-9", firstObr.Identifier.Value);

            var secondOrder = oml.ORDERs.ElementAt(1);
            var secondObr = secondOrder.OBSERVATION_REQUEST.OBR.UniversalServiceIdentifier;
            Assert.AreEqual("0004-2", secondObr.Identifier.Value);

            var thirdOrder = oml.ORDERs.ElementAt(2);
            var thirdObr = thirdOrder.OBSERVATION_REQUEST.OBR.UniversalServiceIdentifier;
            Assert.AreEqual("1165-0", thirdObr.Identifier.Value);
        }
    }
}