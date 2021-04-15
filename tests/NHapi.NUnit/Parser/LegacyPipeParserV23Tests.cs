namespace NHapi.NUnit.Parser
{
    using System;
    using System.Collections.Generic;

    using global::NUnit.Framework;

    using NHapi.Base.Model;
    using NHapi.Base.Parser;
    using NHapi.Model.V23.Datatype;
    using NHapi.Model.V23.Message;
    using NHapi.Model.V23.Segment;

    [TestFixture]
    public class LegacyPipeParserV23Tests
    {
        [Test]
        public void ParseQRYR02()
        {
            var message =
                "MSH|^~\\&|CohieCentral|COHIE|Clinical Data Provider|TCH|20060228155525||QRY^R02^QRY_R02|1|P|2.3|\r"
              + "QRD|20060228155525|R|I||||10^RD&Records&0126|38923^^^^^^^^&TCH|||";

            var parser = new LegacyPipeParser();

            var m = parser.Parse(message);

            var qryR02 = m as QRY_R02;

            Assert.IsNotNull(qryR02);
            Assert.AreEqual("38923", qryR02.QRD.GetWhoSubjectFilter(0).IDNumber.Value);
        }

        [Test]
        public void CreateBlankMessage()
        {
            var a01 = new ADT_A01();
            var birthDate = new DateTime(1980, 4, 1);
            a01.MSH.SendingApplication.UniversalID.Value = "ThisOne";
            a01.MSH.ReceivingApplication.UniversalID.Value = "COHIE";
            a01.PID.PatientIDExternalID.ID.Value = "123456";
            a01.PV1.GetAttendingDoctor(0).FamilyName.Value = "Jones";
            a01.PV1.GetAttendingDoctor(0).GivenName.Value = "Mike";
            a01.PID.DateOfBirth.TimeOfAnEvent.SetShortDate(birthDate);

            var parser = new LegacyPipeParser();

            var pipeMessage = parser.Encode(a01);

            Assert.IsNotNull(pipeMessage);

            var test = parser.Parse(pipeMessage);
            var a01Test = test as ADT_A01;
            Assert.IsNotNull(a01Test);

            Assert.AreEqual(a01Test.MSH.ReceivingApplication.UniversalID.Value, "COHIE");
            Assert.AreEqual(a01Test.PID.PatientIDExternalID.ID.Value, "123456");

            Assert.AreEqual(a01Test.PID.DateOfBirth.TimeOfAnEvent.GetAsDate().ToShortDateString(), birthDate.ToShortDateString());

            Assert.AreEqual(a01Test.PV1.GetAttendingDoctor(0).FamilyName.Value, "Jones");
            Assert.AreEqual(a01Test.MSH.MessageType.MessageType.Value, "ADT");
            Assert.AreEqual(a01Test.MSH.MessageType.TriggerEvent.Value, "A01");
        }

        [Test]
        public void ParseORFR04()
        {
            var message =
                "MSH|^~\\&|Query Result Locator|Query Facility Name|Query Application Name|ST ELSEWHERE HOSPITAL|20051024074506||ORF^R04|432|P|2.3|\r"
              + "MSA|AA|123456789|\r"
              + "QRD|20060228160421|R|I||||10^RD&Records&0126|38923^^^^^^^^&TCH|||\r"
              + "QRF||20050101000000||\r"
              + "PID|||38923^^^ST ELSEWHERE HOSPITAL Medical Record Numbers&              MEDIC              AL RECORD NUMBER&ST ELSEWHERE HOSPITAL^MR^ST ELSEWHERE HOSPITAL||Bombadill^Tom||19450605|M|||1&Main Street^^Littleton^CO^80122||^^^^^303^4376329^22|\r"
              + "OBR|1|0015566|DH2211223|83036^HEMOGLOBIN A1C^^83036^HEMOGLOBIN A1C|||20040526094000|||||||20040526094000||J12345^JENS^JENNY^^^DR^MD^^^^^^^112233&TCH|||||          TP QUEST DIAGNOSTICS-TAMPA 4225 E. FOWLER AVE TAMPA          FL 33617|20030622070400|||F|\r"
              + "OBX|1|NM|50026400^HEMOGLOBIN A1C^^50026400^HEMOGLOBIN A1C||12|^% TOTAL HGB|4.0 - 6.0|H|||F|||20040510094000|TP^^L|";

            var parser = new LegacyPipeParser();

            var m = parser.Parse(message);

            var orfR04 = m as ORF_R04;
            Assert.IsNotNull(orfR04);
            Assert.AreEqual(
                "12",
                orfR04.GetQUERY_RESPONSE().GetORDER().GetOBSERVATION().OBX.GetObservationValue()[0].Data.ToString());
        }

        [Test]
        public void ParseORFR04ToXML()
        {
            var message =
                "MSH|^~\\&|Query Result Locator|Query Facility Name|Query Application Name|ST ELSEWHERE HOSPITAL|20051024074506||ORF^R04|432|P|2.3|\r"
              + "MSA|AA|123456789|\r"
              + "QRD|20060228160421|R|I||||10^RD&Records&0126|38923^^^^^^^^&TCH|||\r"
              + "QRF||20050101000000||\r"
              + "PID|||38923^^^ST ELSEWHERE HOSPITAL Medical Record Numbers&              MEDIC              AL RECORD NUMBER&ST ELSEWHERE HOSPITAL^MR^ST ELSEWHERE HOSPITAL||Bombadill^Tom||19450605|M|||1&Main Street^^Littleton^CO^80122||^^^^^303^4376329^22|\r"
              + "OBR|1|0015566|DH2211223|83036^HEMOGLOBIN A1C^^83036^HEMOGLOBIN A1C|||20040526094000|||||||20040526094000||J12345^JENS^JENNY^^^DR^MD^^^^^^^112233&TCH|||||          TP QUEST DIAGNOSTICS-TAMPA 4225 E. FOWLER AVE TAMPA          FL 33617|20030622070400|||F|\r"
              + "OBX|1|NM|50026400^HEMOGLOBIN A1C^^50026400^HEMOGLOBIN A1C||12|^% TOTAL HGB|4.0 - 6.0|H|||F|||20040510094000|TP^^L|";

            var parser = new LegacyPipeParser();

            var m = parser.Parse(message);

            var orfR04 = m as ORF_R04;

            Assert.IsNotNull(orfR04);

            XMLParser xmlParser = new DefaultXMLParser();

            var recoveredMessage = xmlParser.Encode(orfR04);

            Assert.IsNotNull(recoveredMessage);
            Assert.IsFalse(string.Empty.Equals(recoveredMessage));
        }

        [Test]
        public void ParseXMLToHL7()
        {
            var message = GetQRYR02XML();

            XMLParser xmlParser = new DefaultXMLParser();
            var m = xmlParser.Parse(message);

            var qryR02 = m as QRY_R02;

            Assert.IsNotNull(qryR02);

            var pipeParser = new LegacyPipeParser();

            var pipeOutput = pipeParser.Encode(qryR02);

            Assert.IsNotNull(pipeOutput);
            Assert.IsFalse(string.Empty.Equals(pipeOutput));
        }

        [Test]
        public void ParseORFR04ToXmlNoOCR()
        {
            var message =
                "MSH|^~\\&|Query Result Locator|Query Facility Name|Query Application Name|ST ELSEWHERE HOSPITAL|20051024074506||ORF^R04|432|P|2.3|\r"
              + "MSA|AA|123456789|\r"
              + "QRD|20060228160421|R|I||||10^RD&Records&0126|38923^^^^^^^^&TCH|||\r"
              + "QRF||20050101000000||\r"
              + "PID|||38923^^^ST ELSEWHERE HOSPITAL Medical Record Numbers&              MEDIC              AL RECORD NUMBER&ST ELSEWHERE HOSPITAL^MR^ST ELSEWHERE HOSPITAL||Bombadill^Tom||19450605|M|||1&Main Street^^Littleton^CO^80122||^^^^^303^4376329^22|\r"
              + "OBR|1|0015566|DH2211223|83036^HEMOGLOBIN A1C^^83036^HEMOGLOBIN A1C|||20040526094000|||||||20040526094000||J12345^JENS^JENNY^^^DR^MD^^^^^^^112233&TCH|||||          TP QUEST DIAGNOSTICS-TAMPA 4225 E. FOWLER AVE TAMPA          FL 33617|20030622070400|||F|\r"
              + "OBX|1|NM|50026400^HEMOGLOBIN A1C^^50026400^HEMOGLOBIN A1C||12|^% TOTAL HGB|4.0 - 6.0|H|||F|||20040510094000|TP^^L|";

            var parser = new LegacyPipeParser();

            var m = parser.Parse(message);

            var orfR04 = m as ORF_R04;

            Assert.IsNotNull(orfR04);

            XMLParser xmlParser = new DefaultXMLParser();

            var recoveredMessage = xmlParser.Encode(orfR04);

            Assert.IsNotNull(recoveredMessage);
            Assert.IsFalse(recoveredMessage.IndexOf("ORC") > -1, "Returned message added ORC segment.");
        }

        [Test]
        public void TestOBXDataTypes()
        {
            var message =
                "MSH|^~\\&|EPIC|AIDI|||20070921152053|ITFCOHIEIN|ORF^R04|297|P|2.3|||\r"
              + "MSA|CA|1\r"
              + "QRD|20060725141358|R|||||10^RD|1130851^^^^MRN|RES|||\r"
              + "QRF|||||||||\r"
              + "OBR|1|5149916^EPC|20050118113415533318^|E8600^ECG^^^ECG|||200501181134||||||Age: 17  yrs ~Criteria: C-HP708 ~|||||1||Zztesttwocorhoi|Results||||F||^^^^^Routine|||||||||200501181134|||||||||\r"
              + "OBX|1|ST|:8601-7^ECG IMPRESSION|2|Normal sinus rhythm, rate  77     Normal P axis, PR, rate & rhythm ||||||F||1|200501181134||\r"
              + "OBX|2|ST|:8625-6^PR INTERVAL|3|141||||||F||1|200501181134||\r"
              + "OBX|3|ST|:8633-0^QRS DURATION|4|83||||||F||1|200501181134||\r"
              + "OBX|4|ST|:8634-8^QT INTERVAL|5|358||||||F||1|200501181134||\r"
              + "OBX|5|ST|:8636-3^QT INTERVAL CORRECTED|6|405||||||F||1|200501181134||\r"
              + "OBX|6|ST|:8626-4^FRONTAL AXIS P|7|-1||||||F||1|200501181134||\r"
              + "OBX|7|ST|:99003^FRONTAL AXIS INITIAL 40 MS|8|41||||||F||1|200501181134||\r"
              + "OBX|8|ST|:8632-2^FRONTAL AXIS MEAN QRS|9|66||||||F||1|200501181134||\r"
              + "OBX|9|ST|:99004^FRONTAL AXIS TERMINAL 40 MS|10|80||||||F||1|200501181134||\r"
              + "OBX|10|ST|:99005^FRONTAL AXIS ST|11|36||||||F||1|200501181134||\r"
              + "OBX|11|ST|:8638-9^FRONTAL AXIS T|12|40||||||F||1|200501181134||\r"
              + "OBX|12|ST|:99006^ECG SEVERITY T|13|- NORMAL ECG - ||||||F||1|200501181134||\r"
              + "OBX|13|DT|5315037^Start Date^Start Collection Dat^ABC||18APR06||||||F|||20060419125100|PPKMG|PPJW^SMITH, Fred\r"
              + "QAK||OK||1|1|0";

            var parser = new LegacyPipeParser();

            var m = parser.Parse(message);

            var orfR04 = m as ORF_R04;

            Assert.IsNotNull(orfR04);

            XMLParser xmlParser = new DefaultXMLParser();

            var recoveredMessage = xmlParser.Encode(orfR04);
        }

        [Test]
        public void ParseORFR04ToXmlNoNTE()
        {
            var message =
                "MSH|^~\\&|Query Result Locator|Query Facility Name|Query Application Name|ST ELSEWHERE HOSPITAL|20051024074506||ORF^R04|432|P|2.3|\r"
              + "MSA|AA|123456789|\r"
              + "QRD|20060228160421|R|I||||10^RD&Records&0126|38923^^^^^^^^&TCH|||\r"
              + "QRF||20050101000000||\r"
              + "PID|||38923^^^ST ELSEWHERE HOSPITAL Medical Record Numbers&              MEDIC              AL RECORD NUMBER&ST ELSEWHERE HOSPITAL^MR^ST ELSEWHERE HOSPITAL||Bombadill^Tom||19450605|M|||1&Main Street^^Littleton^CO^80122||^^^^^303^4376329^22|\r"
              + "OBR|1|0015566|DH2211223|83036^HEMOGLOBIN A1C^^83036^HEMOGLOBIN A1C|||20040526094000|||||||20040526094000||J12345^JENS^JENNY^^^DR^MD^^^^^^^112233&TCH|||||          TP QUEST DIAGNOSTICS-TAMPA 4225 E. FOWLER AVE TAMPA          FL 33617|20030622070400|||F|\r"
              + "OBX|1|NM|50026400^HEMOGLOBIN A1C^^50026400^HEMOGLOBIN A1C||12|^% TOTAL HGB|4.0 - 6.0|H|||F|||20040510094000|TP^^L|";

            var parser = new LegacyPipeParser();

            var m = parser.Parse(message);

            var orfR04 = m as ORF_R04;

            Assert.IsNotNull(orfR04);

            XMLParser xmlParser = new DefaultXMLParser();

            var recoveredMessage = xmlParser.Encode(orfR04);

            Assert.IsNotNull(recoveredMessage);
            Assert.IsFalse(recoveredMessage.IndexOf("NTE") > -1, "Returned message added ORC segment.");
        }

        private static string GetQRYR02XML()
        {
            return @"<QRY_R02 xmlns=""urn:hl7-org:v2xml"">
  <MSH>
    <MSH.1>|</MSH.1>
    <MSH.2>^~\&amp;</MSH.2>
    <MSH.1 />
    <MSH.2 />
    <MSH.3>
      <HD.1>CohieCentral</HD.1>
    </MSH.3>
    <MSH.4>
      <HD.1>COHIE</HD.1>
    </MSH.4>
    <MSH.5>
      <HD.1>Clinical Data Provider</HD.1>
    </MSH.5>
    <MSH.6>
      <HD.1>UCH</HD.1>
    </MSH.6>
    <MSH.7>
      <TS.1>20060228152640</TS.1>
    </MSH.7>
    <MSH.9>
      <MSG.1>QRY</MSG.1>
      <MSG.2>R02</MSG.2>
      <MSG.3>QRY_R02</MSG.3>
    </MSH.9>
    <MSH.10>1</MSH.10>
    <MSH.11>
      <PT.1>P</PT.1>
    </MSH.11>
    <MSH.12>
      <VID.1>2.3</VID.1>
    </MSH.12>
  </MSH>
  <QRD>
    <QRD.1>
      <TS.1>20060228152640</TS.1>
    </QRD.1>
    <QRD.2>R</QRD.2>
    <QRD.3>I</QRD.3>
    <QRD.4></QRD.4>
    <QRD.7>
      <CQ.1>10</CQ.1>
      <CQ.2>
        <CE.1>RD</CE.1>
        <CE.2>Records</CE.2>
        <CE.3>0126</CE.3>
      </CQ.2>
    </QRD.7>
    <QRD.8>
      <XCN.1>99388244</XCN.1>
      <XCN.9>
        <HD.2>UCH</HD.2>
      </XCN.9>
    </QRD.8>
    <QRD.9 />
    <QRD.10 />
  </QRD>
  <QRF>
    <QRF.1 />
    <QRF.2>
      <TS.1>20050101000000</TS.1>
    </QRF.2>
    <QRF.3 />
  </QRF>
</QRY_R02>
";
        }

        [Test]
        public void TestPopulateEVNSegmenValuesGenerically()
        {
            var message =
                "MSH|^~\\&|SUNS1|OVI02|AZIS|CMD|200606221348||ADT^A01|1049691900|P|2.3\r"
              + "EVN|A01|200601060800\r"
              + "PID||8912716038^^^51276|0216128^^^51276||BARDOUN^LEA SACHA||19981201|F|||AVENUE FRANC GOLD 8^^LUXEMBOURGH^^6780^150||053/12456789||N|S|||99120162652||^^^|||||B\r"
              + "PV1||O|^^|U|||07632^MORTELO^POL^^^DR.|^^^^^|||||N||||||0200001198\r"
              + "PV2|||^^AZIS||N|||200601060800\r"
              + "IN1|0001|2|314000|||||||||19800101|||1|BARDOUN^LEA SACHA|1|19981201|AVENUE FRANC GOLD 8^^LUXEMBOURGH^^6780^150|||||||||||||||||\r"
              + "ZIN|0164652011399|0164652011399|101|101|45789^Broken bone";

            var parser = new LegacyPipeParser();
            var abstractMessage = parser.Parse(message);

            // this is the normal / expected way of working with NHapi parsed messages
            var typedMessage = abstractMessage as ADT_A01;
            if (typedMessage != null)
            {
                typedMessage.EVN.OperatorID.FamilyName.Value = "Surname";
                typedMessage.EVN.OperatorID.GivenName.Value = "Firstname";
            }

            var pipeDelimitedMessage = parser.Encode(typedMessage);

            // alternatively, you can apply this modification to any HL7 2.3 message
            // with an EVN segment using this more generic method
            var genericMethod = abstractMessage as AbstractMessage;
            var evn = genericMethod.GetStructure("EVN") as EVN;
            if (evn != null)
            {
                evn.OperatorID.FamilyName.Value = "SurnameGeneric";
                evn.OperatorID.GivenName.Value = "FirstnameGeneric";
            }

            pipeDelimitedMessage = parser.Encode(typedMessage);
        }

        /// <summary>
        /// https://github.com/duaneedwards/nHapi/issues/25.
        /// </summary>
        [Test]
        public void TestGithubIssue25CantGetRepetition()
        {
            var message =
                "MSH|^~\\&|MILL|EMRY|MQ|EMRY|20150619155451||ADT^A08|Q2043855220T2330403781X928163|P|2.3||||||8859/1\r"
              + "EVN|A08|20150619155451\r"
              + "PID|1|935307^^^EUH MRN^MRN^EH01|25106376^^^TEC MRN~1781893^^^CLH MRN~935307^^^EUH MRN~5938067^^^EMPI|1167766^^^CPI NBR^^EXTERNAL~90509411^^^HNASYSID~10341880^^^HNASYSID~50627780^^^HNASYSID~5938067^^^MSG_CERNPHR|Patient^Test^Test^^^^Cur_Name||19400101|F||WHI|123 ENDOFTHE RD^UNIT 123^ATLANTA^GA^40000^USA^HOME^^||5555555555^HOME~6666666666^YAHOO@YAHOO.COM^EMAIL|6666666666^BUS|ENG|M|OTH|12345665161^^^EUH FIN^FIN NBR^EH01|123454103|GA123450071||Non-Hispanic|||0|\"\"|\"\"|\"\"||N";

            var parser = new LegacyPipeParser();

            var m = parser.Parse(message);

            var adtA01 = m as ADT_A01; // a08 is mapped to a01

            Assert.IsNotNull(adtA01);

            for (var rep = 0; rep < adtA01.PID.PatientIDInternalIDRepetitionsUsed; rep++)
            {
                var cx = adtA01.PID.GetPatientIDInternalID(rep);
                Console.WriteLine(cx.ID.Value);
            }

            for (var rep = 0; rep < adtA01.PID.AlternatePatientIDRepetitionsUsed; rep++)
            {
                var cx = adtA01.PID.GetAlternatePatientID(rep);
                Console.WriteLine(cx.ID.Value);
            }
        }

        /// <summary>
        /// https://github.com/nHapiNET/nHapi/issues/191.
        /// </summary>
        [Test]
        public void TestIN1andIN2fieldRepetitions()
        {
            var message =
                "MSH|^~\\&|EMM|SKL|TOE|SKL|202102031237||ADT^A08|36711904|P|2.3|||||D||DE\r"
              + "EVN|A08|202102031237|202102031027||KKLLNN||\r"
              + "PID|1|1000|1000||Test^Max^^^^||19370609|F|||NoSuch Str. 20^^Luneburg^^21337^D^L||04131/9786438^^PH|||||||||||N||D|\r"
              + "NK1|1|Fr.Test^|6^Tochter|^^^^|||||||||||U|^YYYYMMDDHHMMSS|||||||||||||||||^^^ORBIS^PN^^^^~^^^ORBIS^PI^^^^~^^^ORBIS^PT^^^^|||||\r"
              + "IN1|1||102114819^^^^NII~17101^^^^NIIP~AOK_00044^^^^XX|Die Gesundheitskasse~Comp 2~Comp 3|Hans-Böckler-Allee 30^^Hannover^^30001^D^P~Street 2^^Berlin~Street 3^^Moscow|John^Peak~Kit^Fin|0413189314641^PRN^PH^^^04131^89314641^~^PRN^FX^^^^^||AOK^1^^^&gesetzliche Krankenkasse^^NII~AOK^1^^^^^U|9283~7766~786~77663|Org1~Org2|||||Test^Max^^^^~Testor^N~Testoff^J~Testior^Y||19370609|Wilhelm Str. 44^^Lüneburg^^21337^D^P~Best Str^^Berlin|||H|||||||||R|||||S890768688|||||||W|Addr1~Addr2|||||S8907^^^^^^^~S9999|\r"
              + "IN2|1234^^^^AMA~4567^^^^LANR||^Fam1~^Fam2||P~G~E||FN1~FN2~FN3~FN4||SP1~SP2~SP3^Tomas|||||||||||||SpCov1~SpCov2|||||||^PC^100||||D  |||J|||||||||||||||||||||||||||041319786438||||||||\r"
              + "ZBE|13033374^ORBIS|202102031027|202102031237|UPDATE|";

            var parser = new LegacyPipeParser();

            var m = parser.Parse(message);

            var adtA08 = m as ADT_A01; // a08 is mapped to a01

            Assert.IsNotNull(adtA08);

            var in1_3 = adtA08.GetINSURANCE().IN1.GetInsuranceCompanyID();
            Assert.AreEqual(in1_3.Length, 3);
            Assert.AreEqual(in1_3[0].IdentifierTypeCode.Value, "NII");
            Assert.AreEqual(in1_3[1].IdentifierTypeCode.Value, "NIIP");
            Assert.AreEqual(in1_3[2].IdentifierTypeCode.Value, "XX");

            var in1_4 = adtA08.GetINSURANCE().IN1.GetInsuranceCompanyName();
            Assert.AreEqual(in1_4.Length, 3);
            Assert.AreEqual(in1_4[2].OrganizationName.Value, "Comp 3");

            var in1_5 = adtA08.GetINSURANCE().IN1.GetInsuranceCompanyAddress();
            Assert.AreEqual(in1_5.Length, 3);
            Assert.AreEqual(in1_5[0].City.Value, "Hannover");
            Assert.AreEqual(in1_5[1].City.Value, "Berlin");
            Assert.AreEqual(in1_5[2].City.Value, "Moscow");

            var in1_6 = adtA08.GetINSURANCE().IN1.GetInsuranceCoContactPpers();
            Assert.AreEqual(in1_6.Length, 2);
            Assert.AreEqual(in1_6[0].GivenName.Value, "Peak");
            Assert.AreEqual(in1_6[1].GivenName.Value, "Fin");

            var in1_7 = adtA08.GetINSURANCE().IN1.GetInsuranceCoPhoneNumber();
            Assert.AreEqual(in1_7.Length, 2);
            Assert.AreEqual(in1_7[0].TelecommunicationEquipmentType.Value, "PH");
            Assert.AreEqual(in1_7[1].TelecommunicationEquipmentType.Value, "FX");

            var in1_9 = adtA08.GetINSURANCE().IN1.GetGroupName();
            Assert.AreEqual(in1_9.Length, 2);
            Assert.AreEqual(in1_9[0].IdentifierTypeCode.Value, "NII");
            Assert.AreEqual(in1_9[1].IdentifierTypeCode.Value, "U");

            var in1_10 = adtA08.GetINSURANCE().IN1.GetInsuredSGroupEmployerID();
            Assert.AreEqual(in1_10.Length, 4);

            var in1_11 = adtA08.GetINSURANCE().IN1.GetInsuredSGroupEmpName();
            Assert.AreEqual(in1_11.Length, 2);

            var in1_16 = adtA08.GetINSURANCE().IN1.GetNameOfInsured();
            Assert.AreEqual(in1_16.Length, 4);
            Assert.AreEqual(in1_16[3].GivenName.Value, "Y");

            var in1_19 = adtA08.GetINSURANCE().IN1.GetInsuredSAddress();
            Assert.AreEqual(in1_19.Length, 2);
            Assert.AreEqual(in1_19[1].City.Value, "Berlin");

            var in1_44 = adtA08.GetINSURANCE().IN1.GetInsuredSEmployerAddress();
            Assert.AreEqual(in1_44.Length, 2);
            Assert.AreEqual(in1_44[0].StreetAddress.Value, "Addr1");
            Assert.AreEqual(in1_44[1].StreetAddress.Value, "Addr2");

            var in1_49 = adtA08.GetINSURANCE().IN1.GetInsuredSIDNumber();
            Assert.AreEqual(in1_49.Length, 2);
            Assert.AreEqual(in1_49[0].ID.Value, "S8907");
            Assert.AreEqual(in1_49[1].ID.Value, "S9999");

            var in2_1 = adtA08.GetINSURANCE().IN2.GetInsuredSEmployeeID();
            Assert.AreEqual(in2_1.Length, 2);
            Assert.AreEqual(in2_1[0].IdentifierTypeCode.Value, "AMA");
            Assert.AreEqual(in2_1[1].IdentifierTypeCode.Value, "LANR");

            var in2_3 = adtA08.GetINSURANCE().IN2.GetInsuredSEmployerName();
            Assert.AreEqual(in2_3.Length, 2);
            Assert.AreEqual(in2_3[0].FamilyName.Value, "Fam1");
            Assert.AreEqual(in2_3[1].FamilyName.Value, "Fam2");

            var in2_5 = adtA08.GetINSURANCE().IN2.GetMailClaimParty();
            Assert.AreEqual(in2_5.Length, 3);
            Assert.AreEqual(in2_5[0].Value, "P");
            Assert.AreEqual(in2_5[1].Value, "G");
            Assert.AreEqual(in2_5[2].Value, "E");

            var in2_7 = adtA08.GetINSURANCE().IN2.GetMedicaidCaseName();
            Assert.AreEqual(in2_7.Length, 4);
            Assert.AreEqual(in2_7[3].FamilyName.Value, "FN4");

            var in2_9 = adtA08.GetINSURANCE().IN2.GetChampusSponsorName();
            Assert.AreEqual(in2_9.Length, 3);
            Assert.AreEqual(in2_9[2].GivenName.Value, "Tomas");

            var in2_22 = adtA08.GetINSURANCE().IN2.GetSpecialCoverageApprovalName();
            Assert.AreEqual(in2_22.Length, 2);
            Assert.AreEqual(in2_22[1].FamilyName.Value, "SpCov2");
        }

        /// <summary>
        /// https://github.com/nHapiNET/nHapi/issues/135.
        /// </summary>
        [TestCaseSource(nameof(validV23ValueTypes))]
        public void TestObx5DataTypeIsSetFromObx2_AndAllDataTypesAreConstructable(Type expectedObservationValueType)
        {
            var message =
                    "MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.3|||AL|||ASCII\r"
                  + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
                  + "ORC|||||F\r"
                  + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
                  + $"OBX|1|{expectedObservationValueType.Name}|||{expectedObservationValueType.Name}Value||||||F";

            var parser = new LegacyPipeParser();

            var parsed = (ORU_R01)parser.Parse(message);

            var actualObservationValueType = parsed.GetRESPONSE(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data;

            Assert.IsAssignableFrom(expectedObservationValueType, actualObservationValueType);
        }

        /// <summary>
        /// Specified in Table 0125.
        /// </summary>
        private static IEnumerable<Type> validV23ValueTypes = new List<Type>
        {
            typeof(AD),
            typeof(CE),
            typeof(CF),
            typeof(CK),
            typeof(CN),
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
            typeof(TN),
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