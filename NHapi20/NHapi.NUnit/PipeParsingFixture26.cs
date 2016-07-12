using System;
using System.Linq;
using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Model.V26.Datatype;
using NHapi.Model.V26.Message;
using NUnit.Framework;

namespace NHapi.NUnit
{
	internal class PipeParsingFixture26
	{
		public string GetMessage()
		{
			return @"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5.1|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|FT|||This\.br\is\.br\A Test~MoreText~SomeMoreText||||||F
OBX|2|FT|||This\.br\is\.br\A Test~MoreText~SomeMoreText||||||F
OBX|3|FT|||This\.br\is\.br\A Test~MoreText~SomeMoreText||||||F";
		}

		[Test]
		public void TestOBR5RepeatingValuesMessage_DataTypesAndRepetitions()
		{
			var parser = new PipeParser();
			var oru = new ORU_R01();
			oru = (ORU_R01) parser.Parse(GetMessage());

			int expectedObservationCount = 3;
			int parsedObservations = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBSERVATIONRepetitionsUsed;
			bool parsedCorrectNumberOfObservations = parsedObservations == expectedObservationCount;
			Assert.IsTrue(parsedCorrectNumberOfObservations,
				string.Format("Expected 3 OBX repetitions used for this segment, found {0}", parsedObservations));

			foreach (var obs in oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION().OBX.GetObservationValue())
			{
				Assert.IsTrue(obs.Data is FT);
			}
		}

		[TestCase(
			@"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5.1|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|DT|||DTValue||||||F
OBX|2|ST|||STValue||||||F
OBX|3|TM|||TMValue||||||F"
		//OBX|4|ID|||IDValue||||||F //Doesn't work
		//OBX|5|IS|||ISValue||||||F //Doesn't work
		)]
		public void Test_251DataTypesParseCorrectly(string message)
		{
			var parser = new PipeParser();
			var oru = new ORU_R01();
			oru = (ORU_R01)parser.Parse(message);

			int expectedObservationCount = 3;
			int parsedObservations = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBSERVATIONRepetitionsUsed;
			bool parsedCorrectNumberOfObservations = parsedObservations == expectedObservationCount;
			Assert.IsTrue(parsedCorrectNumberOfObservations,
				string.Format("Expected {1} OBX repetitions used for this segment, found {0}", parsedObservations, expectedObservationCount));

			int index = 0;
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
			string hl7Data = @"MSH|^~\&|CohieCentral|COHIE|Clinical Data Provider|TCH|20060228155525||ADT^A04|1|P|2.5.1|
EVN|
PID|1|12345
PV1|1";
			PipeParser parser = new PipeParser();
			IMessage msg = parser.Parse(hl7Data);

			Assert.IsNotNull(msg, "Message should not be null");
			ADT_A01 a04 = (ADT_A01)msg;

			Assert.AreEqual("A04", a04.MSH.MessageType.TriggerEvent.Value);
			Assert.AreEqual("1", a04.PID.SetIDPID.Value);
		}

		[Test]
		public void TestAdtA04AndA01MessageStructure()
		{
			var result = PipeParser.GetMessageStructureForEvent("ADT_A04", "2.5.1");
			bool isSame = string.Compare("ADT_A01", result, StringComparison.InvariantCultureIgnoreCase) == 0;
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
	}
}