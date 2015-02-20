using NHapi.Base.Parser;
using NHapi.Model.V251.Datatype;
using NHapi.Model.V251.Message;
using NUnit.Framework;

namespace NHapi.NUnit
{
	class PipeParsingFixture251
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
			oru = (ORU_R01)parser.Parse(GetMessage());

			int expectedObservationCount = 3;
			int parsedObservations = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBSERVATIONRepetitionsUsed;
			bool parsedCorrectNumberOfObservations = parsedObservations == expectedObservationCount;
			Assert.IsTrue(parsedCorrectNumberOfObservations, string.Format("Expected 3 OBX repetitions used for this segment, found {0}", parsedObservations));
			
			foreach (var obs in oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION().OBX.GetObservationValue())
			{
				Assert.IsTrue(obs.Data is FT);
			}
		}
	}
}
