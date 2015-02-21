using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Model.V24.Message;
using NUnit.Framework;


namespace NHapi.NUnit
{
	[TestFixture]
	public class PipeParsingFixture24
	{
		[Test]
		public void ParseQRYR02()
		{
			string message = @"MSH|^~\&|CohieCentral|COHIE|Clinical Data Provider|TCH|20060228155525||QRY^R02^QRY_R02|1|P|2.4|
QRD|20060228155525|R|I||||10^RD&Records&0126|38923^^^^^^^^&TCH|||";

			PipeParser Parser = new PipeParser();

			IMessage m = Parser.Parse(message);

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

			PipeParser Parser = new PipeParser();

			IMessage m = Parser.Parse(message);

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

			PipeParser Parser = new PipeParser();

			IMessage m = Parser.Parse(message);

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

			PipeParser Parser = new PipeParser();

			IMessage m = Parser.Parse(message);

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

			PipeParser Parser = new PipeParser();

			IMessage m = Parser.Parse(message);

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
	}
}