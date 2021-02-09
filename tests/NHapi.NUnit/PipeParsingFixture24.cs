namespace NHapi.NUnit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::NUnit.Framework;

    using NHapi.Base;
    using NHapi.Base.Model;
    using NHapi.Base.Parser;
    using NHapi.Model.V24.Datatype;
    using NHapi.Model.V24.Message;
    using NHapi.Model.V24.Segment;

    [TestFixture]
    public class PipeParsingFixture24
    {
        [Test]
        public void ParseQRYR02()
        {
            string message = @"MSH|^~\&|CohieCentral|COHIE|Clinical Data Provider|TCH|20060228155525||QRY^R02^QRY_R02|1|P|2.4|
QRD|20060228155525|R|I||||10^RD&Records&0126|38923^^^^^^^^&TCH|||";

            PipeParser parser = new PipeParser();

            IMessage m = parser.Parse(message);

            QRY_R02 qryR02 = m as QRY_R02;

            Assert.IsNotNull(qryR02);
            Assert.AreEqual("38923", qryR02.QRD.GetWhoSubjectFilter(0).IDNumber.Value);
        }

        [Test]
        public void ParseORFR04()
        {
            string message =
                @"MSH|^~\&|Query Result Locator|Query Facility Name|Query Application Name|ST ELSEWHERE HOSPITAL|20051024074506||ORF^R04|432|P|2.4|
MSA|AA|123456789|
QRD|20060228160421|R|I||||10^RD&Records&0126|38923^^^^^^^^&TCH|||
QRF||20050101000000||
PID|||38923^^^ST ELSEWHERE HOSPITAL Medical Record Numbers&              MEDIC              AL RECORD NUMBER&ST ELSEWHERE HOSPITAL^MR^ST ELSEWHERE HOSPITAL||Bombadill^Tom||19450605|M|||1&Main Street^^Littleton^CO^80122||^^^^^303^4376329^22|
OBR|1|0015566|DH2211223|83036^HEMOGLOBIN A1C^^83036^HEMOGLOBIN A1C|||20040526094000|||||||20040526094000||J12345^JENS^JENNY^^^DR^MD^^^^^^^112233&TCH|||||          TP QUEST DIAGNOSTICS-TAMPA 4225 E. FOWLER AVE TAMPA          FL 33617|20030622070400|||F|
OBX|1|NM|50026400^HEMOGLOBIN A1C^^50026400^HEMOGLOBIN A1C||12|^% TOTAL HGB|4.0 - 6.0|H|||F|||20040510094000|TP^^L|";

            PipeParser parser = new PipeParser();

            IMessage m = parser.Parse(message);

            ORF_R04 orfR04 = m as ORF_R04;
            Assert.IsNotNull(orfR04);
            Assert.AreEqual("12", orfR04.GetRESPONSE().GetORDER().GetOBSERVATION().OBX.GetObservationValue()[0].Data.ToString());
        }

        [Test]
        public void ParseORFR04ToXML()
        {
            string message =
                @"MSH|^~\&|Query Result Locator|Query Facility Name|Query Application Name|ST ELSEWHERE HOSPITAL|20051024074506||ORF^R04|432|P|2.4|
MSA|AA|123456789|
QRD|20060228160421|R|I||||10^RD&Records&0126|38923^^^^^^^^&TCH|||
QRF||20050101000000||
PID|||38923^^^ST ELSEWHERE HOSPITAL Medical Record Numbers&              MEDIC              AL RECORD NUMBER&ST ELSEWHERE HOSPITAL^MR^ST ELSEWHERE HOSPITAL||Bombadill^Tom||19450605|M|||1&Main Street^^Littleton^CO^80122||^^^^^303^4376329^22|
OBR|1|0015566|DH2211223|83036^HEMOGLOBIN A1C^^83036^HEMOGLOBIN A1C|||20040526094000|||||||20040526094000||J12345^JENS^JENNY^^^DR^MD^^^^^^^112233&TCH|||||          TP QUEST DIAGNOSTICS-TAMPA 4225 E. FOWLER AVE TAMPA          FL 33617|20030622070400|||F|
OBX|1|NM|50026400^HEMOGLOBIN A1C^^50026400^HEMOGLOBIN A1C||12|^% TOTAL HGB|4.0 - 6.0|H|||F|||20040510094000|TP^^L|";

            PipeParser parser = new PipeParser();

            IMessage m = parser.Parse(message);

            ORF_R04 orfR04 = m as ORF_R04;

            Assert.IsNotNull(orfR04);

            XMLParser xmlParser = new DefaultXMLParser();

            string recoveredMessage = xmlParser.Encode(orfR04);

            Assert.IsNotNull(recoveredMessage);
            Assert.IsFalse(string.Empty.Equals(recoveredMessage));
        }

        [Test]
        public void ParseXMLToHL7()
        {
            string message = GetQRYR02XML();

            XMLParser xmlParser = new DefaultXMLParser();
            IMessage m = xmlParser.Parse(message);

            QRY_R02 qryR02 = m as QRY_R02;

            Assert.IsNotNull(qryR02);

            PipeParser pipeParser = new PipeParser();

            string pipeOutput = pipeParser.Encode(qryR02);

            Assert.IsNotNull(pipeOutput);
            Assert.IsFalse(string.Empty.Equals(pipeOutput));
        }

        [Test]
        public void ParseORFR04ToXmlNoOCR()
        {
            string message =
                @"MSH|^~\&|Query Result Locator|Query Facility Name|Query Application Name|ST ELSEWHERE HOSPITAL|20051024074506||ORF^R04|432|P|2.4|
MSA|AA|123456789|
QRD|20060228160421|R|I||||10^RD&Records&0126|38923^^^^^^^^&TCH|||
QRF||20050101000000||
PID|||38923^^^ST ELSEWHERE HOSPITAL Medical Record Numbers&              MEDIC              AL RECORD NUMBER&ST ELSEWHERE HOSPITAL^MR^ST ELSEWHERE HOSPITAL||Bombadill^Tom||19450605|M|||1&Main Street^^Littleton^CO^80122||^^^^^303^4376329^22|
OBR|1|0015566|DH2211223|83036^HEMOGLOBIN A1C^^83036^HEMOGLOBIN A1C|||20040526094000|||||||20040526094000||J12345^JENS^JENNY^^^DR^MD^^^^^^^112233&TCH|||||          TP QUEST DIAGNOSTICS-TAMPA 4225 E. FOWLER AVE TAMPA          FL 33617|20030622070400|||F|
OBX|1|NM|50026400^HEMOGLOBIN A1C^^50026400^HEMOGLOBIN A1C||12|^% TOTAL HGB|4.0 - 6.0|H|||F|||20040510094000|TP^^L|";

            PipeParser parser = new PipeParser();

            IMessage m = parser.Parse(message);

            ORF_R04 orfR04 = m as ORF_R04;

            Assert.IsNotNull(orfR04);

            XMLParser xmlParser = new DefaultXMLParser();

            string recoveredMessage = xmlParser.Encode(orfR04);

            Assert.IsNotNull(recoveredMessage);
            Assert.IsFalse(recoveredMessage.IndexOf("ORC") > -1, "Returned message added ORC segment.");
        }

        [Test]
        public void TestOBXDataTypes()
        {
            string message = @"MSH|^~\&|EPIC|AIDI|||20070921152053|ITFCOHIEIN|ORF^R04^ORF_R04|297|P|2.4|||
MSA|CA|1
QRD|20060725141358|R|||||10^RD|1130851^^^^MRN|RES|||
QRF|||||||||
OBR|1|5149916^EPC|20050118113415533318^|E8600^ECG^^^ECG|||200501181134||||||Age: 17  yrs ~Criteria: C-HP708 ~|||||1||Zztesttwocorhoi|Results||||F||^^^^^Routine|||||||||200501181134|||||||||
OBX|1|ST|:8601-7^ECG IMPRESSION|2|Normal sinus rhythm, rate  77     Normal P axis, PR, rate & rhythm ||||||F||1|200501181134||
OBX|2|ST|:8625-6^PR INTERVAL|3|141||||||F||1|200501181134||
OBX|3|ST|:8633-0^QRS DURATION|4|83||||||F||1|200501181134||
OBX|4|ST|:8634-8^QT INTERVAL|5|358||||||F||1|200501181134||
OBX|5|ST|:8636-3^QT INTERVAL CORRECTED|6|405||||||F||1|200501181134||
OBX|6|ST|:8626-4^FRONTAL AXIS P|7|-1||||||F||1|200501181134||
OBX|7|ST|:99003^FRONTAL AXIS INITIAL 40 MS|8|41||||||F||1|200501181134||
OBX|8|ST|:8632-2^FRONTAL AXIS MEAN QRS|9|66||||||F||1|200501181134||
OBX|9|ST|:99004^FRONTAL AXIS TERMINAL 40 MS|10|80||||||F||1|200501181134||
OBX|10|ST|:99005^FRONTAL AXIS ST|11|36||||||F||1|200501181134||
OBX|11|ST|:8638-9^FRONTAL AXIS T|12|40||||||F||1|200501181134||
OBX|12|ST|:99006^ECG SEVERITY T|13|- NORMAL ECG - ||||||F||1|200501181134||
OBX|13|DT|5315037^Start Date^Start Collection Dat^ABC||18APR06||||||F|||20060419125100|PPKMG|PPJW^SMITH, Fred 
QAK||OK||1|1|0
";

            PipeParser parser = new PipeParser();

            IMessage m = parser.Parse(message);

            ORF_R04 orfR04 = m as ORF_R04;

            Assert.IsNotNull(orfR04);

            XMLParser xmlParser = new DefaultXMLParser();

            string recoveredMessage = xmlParser.Encode(orfR04);
        }

        [Test]
        public void ParseORFR04ToXmlNoNTE()
        {
            string message =
                @"MSH|^~\&|Query Result Locator|Query Facility Name|Query Application Name|ST ELSEWHERE HOSPITAL|20051024074506||ORF^R04|432|P|2.4|
MSA|AA|123456789|
QRD|20060228160421|R|I||||10^RD&Records&0126|38923^^^^^^^^&TCH|||
QRF||20050101000000||
PID|||38923^^^ST ELSEWHERE HOSPITAL Medical Record Numbers&              MEDIC              AL RECORD NUMBER&ST ELSEWHERE HOSPITAL^MR^ST ELSEWHERE HOSPITAL||Bombadill^Tom||19450605|M|||1&Main Street^^Littleton^CO^80122||^^^^^303^4376329^22|
OBR|1|0015566|DH2211223|83036^HEMOGLOBIN A1C^^83036^HEMOGLOBIN A1C|||20040526094000|||||||20040526094000||J12345^JENS^JENNY^^^DR^MD^^^^^^^112233&TCH|||||          TP QUEST DIAGNOSTICS-TAMPA 4225 E. FOWLER AVE TAMPA          FL 33617|20030622070400|||F|
OBX|1|NM|50026400^HEMOGLOBIN A1C^^50026400^HEMOGLOBIN A1C||12|^% TOTAL HGB|4.0 - 6.0|H|||F|||20040510094000|TP^^L|";

            PipeParser parser = new PipeParser();

            IMessage m = parser.Parse(message);

            ORF_R04 orfR04 = m as ORF_R04;

            Assert.IsNotNull(orfR04);

            XMLParser xmlParser = new DefaultXMLParser();

            string recoveredMessage = xmlParser.Encode(orfR04);

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
      <VID.1>2.4</VID.1>
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

        /// <summary>
        /// https://github.com/duaneedwards/nHapi/issues/24.
        /// </summary>
        [Test]
        public void TestGithubIssue24CantGetIN1Segment()
        {
            string message = @"MSH|^~\&|SUNS1|OVI02|AZIS|CMD|200606221348||ADT^A01|1049691900|P|2.4
	EVN|A01|200601060800
	PID||8912716038^^^51276|0216128^^^51276||BARDOUN^LEA SACHA||19981201|F|||AVENUE FRANC GOLD 8^^LUXEMBOURGH^^6780^150||053/12456789||N|S|||99120162652||^^^|||||B
	PV1||O|^^|U|||07632^MORTELO^POL^^^DR.|^^^^^|||||N||||||0200001198
	PV2|||^^AZIS||N|||200601060800
	IN1|0001|2|314000|||||||||19800101|||1|BARDOUN^LEA SACHA|1|19981201|AVENUE FRANC GOLD 8^^LUXEMBOURGH^^6780^150|||||||||||||||||
	ZIN|0164652011399|0164652011399|101|101|45789^Broken bone";

            var parser = new PipeParser();
            var abstractMessage = parser.Parse(message);

            var typedMessage = abstractMessage as ADT_A01;

            // This is supposed to throw an exception with error 'IN1 does not exist in the group NHapi.Model.V24.Message.ADT_A01'
            Assert.Throws<HL7Exception>(() =>
            {
                var causesException = (IN1)typedMessage.GetStructure("IN1");
            });

            // This will work as the IN1 resides within the insurance group's structure
            var in1 = (IN1)typedMessage.GetINSURANCE(0).GetStructure("IN1");

            // old style of accessing the data
            Assert.IsTrue(typedMessage.GetINSURANCE(0).IN1.SetIDIN1.Value == "0001");

            // new style of accessing the data
            Assert.IsTrue(typedMessage.INSURANCEs.First().IN1.SetIDIN1.Value == "0001");
        }

        /// <summary>
        /// https://github.com/duaneedwards/nHapi/issues/58.
        /// </summary>
        [Test]
        public void TestGithubIssue58ProblemWithMultipleOrder_Observations()
        {
            var message = @"MSH|^~\&|MOLIS|TEAMW|||20040322151046||ORU^R01|2116|P|2.4||||||8859
PID|1|1847|50381^^^^^MOLIS~^^^^^VTD||TEST A^||19711125|F|||test^^Roma^^00144^||||
ORC|NW|FA9999020000^MOLIS|FA9999020000^MOLIS|FA99990200^MOLIS|CM||^^^20030331053409^^R|||||MOLIS^SYSMEX MOLIS^^^^^^^^^^MOLIS||||||||||||
OBR|1|FA9999020000^MOLIS|FA9999020000^MOLIS|00^^MOLIS||20030327000000|20030331053409|||||||||MOLIS^SYSMEX MOLIS^^^^^^^^^^MOLIS|||||||||||^^^20030331053409^^R||||||||||||||||||||
NTE|0||Isolierte Cardiolipin-Autoantik�rper vom Typ IgM in niedriger Konzentration sind von fraglicher klinischer Relevanz. Es empfiehlt sich eine Kontrolle aus einer neuen Probe und die zus�tzliche Bestimmung der beta-2-Glykoprotein-Autoantik�rper.|RE
NTE|0||Umlaute Test : ������������|RE
NTE|0||Ende Test Umlaute|RE
OBX|1|FT|ALLERG^Allergie^MOLIS||vv Dies eist ein Test zum Drucke\.br\ etwas l�ngeren Textes auf dem Allergiepass||||||C|||20030331053409|||||
ORC|NW|FA9999020018^MOLIS|FA9999020018^MOLIS|FA99990200^MOLIS|CM||^^^20030331053409^^R|||||MOLIS^SYSMEX MOLIS^^^^^^^^^^MOLIS||||||||||||
OBR|2|FA9999020018^MOLIS|FA9999020018^MOLIS|18^Immunologie^MOLIS||20030327000000|20030331053409|||||||||MOLIS^SYSMEX MOLIS^^^^^^^^^^MOLIS|||||||||||^^^20030331053409^^R||||||||||||||||||||
OBX|1|TX|ACLAS^Anti-Cardiolipin-Screen^MOLIS||negativ|MOC^^L|(<1.0)||||C|||20030331053409|||||
OBX|2|NM|ACLAG^Anti-Cardiolipin IgG^MOLIS||0.2|MOC^^L|(<1.0)||||F|||20030331053409|||||
NTE|1||Bitte beachten: Normwert- und Methoden�nderung zum 13.03.03.|RE
OBX|3|NM|ACLAM^Anti-Cardiolipin IgM^MOLIS||111.3|MOC^^L|(<1.0)|H|||C|||20030331053409|||||
NTE|1||Bitte beachten: Normwert- und Methoden�nderung zum 13.03.03.|RE
ORC|NW|FA9999020026^MOLIS|FA9999020026^MOLIS|FA99990200^MOLIS|CM||^^^20030331053409^^R|||||MOLIS^SYSMEX MOLIS^^^^^^^^^^MOLIS||||||||||||
OBR|3|FA9999020026^MOLIS|FA9999020026^MOLIS|26^Hormone^MOLIS||20030327000000|20030331053409|||||||||MOLIS^SYSMEX MOLIS^^^^^^^^^^MOLIS|||||||||||^^^20030331053409^^R||||||||||||||||||||
OBX|1|NM|FSH^FSH^MOLIS||1.0|U/l^^L|(1.6-12.0)Follikul�r \ (8.0-22.0)Peak \ (0.9-12.0)Luteal \ (1.0-17.0)Kontrazeptiva \ (35-151)Menopause||||C|||20030331053409|||||
OBX|2|NM|LH^LH^MOLIS||37.4|U/l^^L|(1.8-13.4)Follikul�r \ (15.6-78.9)Peak \ (0.7-19.4)Luteal \ (1.0-15.0)Kontrazeptiva \ (10.8-61.4)Menopause||||F|||20030331053409|||||
OBX|3|NM|LHFSHQ^LH-FSH-Quotient^MOLIS||37.4||(<2.0)|H|||F|||20030331053409|||||
OBX|4|NM|PROL^Prolactin^MOLIS||10.3|�g/l^^L|(2.3-25.0) \ (2.3-10.0)Menopause||||F|||20030331053409|||||
OBX|5|NM|E2^Estradiol, E2^MOLIS||39|pmol/l^^L|(70-672)Follikul�r \ (551-1938)Peak \ (220-774)Luteal \ (<114)Menopause||||F|||20030331053409||||| ";

            PipeParser parser = new PipeParser();

            IMessage m = parser.Parse(message);

            var oru_r = m as ORU_R01;

            foreach (var pr in oru_r.PATIENT_RESULTs)
            {
                int resultSet = 1;

                int expectedRepetitions = 3; // 3 orders
                Assert.IsTrue(pr.ORDER_OBSERVATIONRepetitionsUsed == expectedRepetitions, string.Format("Expected {0} in result {1}", expectedRepetitions, resultSet));
                foreach (var oo in pr.ORDER_OBSERVATIONs)
                {
                    if (resultSet == 1)
                    {
                        expectedRepetitions = 1;
                        Assert.IsTrue(oo.OBSERVATIONRepetitionsUsed == expectedRepetitions, string.Format("Expected {0} in result {1}", expectedRepetitions, resultSet));

                        var obx = oo.OBSERVATIONs.First().OBX;
                        var valueType = obx.ValueType.Value;
                        string expectedValueType = "FT";

                        Assert.IsTrue(valueType == expectedValueType, string.Format("Expected Value Type of {0} but found {1} for result set {2}", expectedValueType, valueType, resultSet));

                        var data = obx.GetObservationValue(0);
                        string value = data.Data.ToString();
                        string toFind = "Allergiepass";

                        Assert.IsTrue(value.Contains(toFind), string.Format("Expected to find '{0}' in data '{1}' but didn't.", toFind, value));
                    }

                    if (resultSet == 2)
                    {
                        expectedRepetitions = 3;
                        Assert.IsTrue(oo.OBSERVATIONRepetitionsUsed == expectedRepetitions, string.Format("Expected {0} in result {1}", expectedRepetitions, resultSet));

                        var obx = oo.OBSERVATIONs.First().OBX;
                        var valueType = obx.ValueType.Value;
                        string expectedValueType = "TX";

                        Assert.IsTrue(valueType == expectedValueType, string.Format("Expected Value Type of {0} but found {1} for result set {2}", expectedValueType, valueType, resultSet));

                        var data = obx.GetObservationValue(0);
                        string value = data.Data.ToString();
                        string toFind = "negativ";

                        Assert.IsTrue(value.Contains(toFind), string.Format("Expected to find '{0}' in data '{1}' but didn't.", toFind, value));
                    }

                    if (resultSet == 3)
                    {
                        expectedRepetitions = 5;
                        Assert.IsTrue(oo.OBSERVATIONRepetitionsUsed == expectedRepetitions, string.Format("Expected {0} in result {1}", expectedRepetitions, resultSet));

                        var obx = oo.OBSERVATIONs.First().OBX;
                        var valueType = obx.ValueType.Value;
                        string expectedValueType = "NM";

                        Assert.IsTrue(valueType == expectedValueType, string.Format("Expected Value Type of {0} but found {1} for result set {2}", expectedValueType, valueType, resultSet));

                        var data = obx.GetObservationValue(0);
                        string value = data.Data.ToString();
                        string toFind = "1.0";

                        Assert.IsTrue(value.Contains(toFind), string.Format("Expected to find '{0}' in data '{1}' but didn't.", toFind, value));
                    }

                    resultSet++;
                }
            }
        }

        /// <summary>
        /// https://github.com/nHapiNET/nHapi/issues/135.
        /// </summary>
        [TestCaseSource(nameof(validV24ValueTypes))]
        public void TestObx5DataTypeIsSetFromObx2_AndAllDataTypesAreConstructable(Type expectedObservationValueType)
        {
            var message = $@"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.4|||AL|||ASCII
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
        private static IEnumerable<Type> validV24ValueTypes = new List<Type>
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
            typeof(PN),
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