using System;
using System.IO;
using System.Linq;
using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Model.V26.Datatype;
using NHapi.Model.V26.Group;
using NHapi.Model.V26.Message;
using NUnit.Framework;

namespace NHapi.NUnit
{
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
			@"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.6|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|DT|||DTValue||||||F
OBX|2|ST|||STValue||||||F
OBX|3|TM|||TMValue||||||F"
		//OBX|4|ID|||IDValue||||||F //Doesn't work
		//OBX|5|IS|||ISValue||||||F //Doesn't work
		)]
		public void Test_26DataTypesParseCorrectly(string message)
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
			string hl7Data = @"MSH|^~\&|CohieCentral|COHIE|Clinical Data Provider|TCH|20060228155525||ADT^A04|1|P|2.6|
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
			var result = PipeParser.GetMessageStructureForEvent("ADT_A04", "2.6");
			bool isSame = string.Compare("ADT_A01", result, StringComparison.InvariantCultureIgnoreCase) == 0;
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
			string hl7Data = @"MSH|^~\&|Paceart|Medtronic|||20160628142621||ORU^R01^ORU_R01|20160628142621000001|P|2.6|||AL|NE|||||IHE_PCD_ORU_R01^IHE PCD^1.3.6.1.4.1.19376.1.6.1.9.1^ISO
PID|||MODEL:A3DR01 Advisa DR MRI/SERIAL:PZK600806S^^^MDT^U~^^^^Patient ID~A10000641^^^^Paceart||Patient^Test||19100000000000+0000
PV1|1|A
OBR|1||dfac748c-213c-e611-80c5-000c2996266c|754050^MDC_IDC_ENUM_SESS_TYPE_InClinic^MDC^INCLINIC^INCLINIC^MDT|||20160627041809+0000||||||||||||||||||P
OBX|1|DTM|721025^MDC_IDC_SESS_DTM^MDC||20160627041809+0000||||||P";

			PipeParser parser = new PipeParser();
			IMessage msg = parser.Parse(hl7Data);

			Assert.IsNotNull(msg, "Message should not be null");
			ORU_R01 oruR01 = (ORU_R01)msg;

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
			string hl7Data = @"MSH|^~\&|Paceart|Medtronic|||20160628142621||ORU^R01^ORU_R01|20160628142621000001|P|2.6|||AL|NE|||||IHE_PCD_ORU_R01^IHE PCD^1.3.6.1.4.1.19376.1.6.1.9.1^ISO
PID|||MODEL:A3DR01 Advisa DR MRI/SERIAL:PZK600806S^^^MDT^U~^^^^Patient ID~A10000641^^^^Paceart||Patient^Test||19100000000000+0000
PV1|1|A
OBR|1||dfac748c-213c-e611-80c5-000c2996266c|754050^MDC_IDC_ENUM_SESS_TYPE_InClinic^MDC^INCLINIC^INCLINIC^MDT|||20160627041809+0000||||||||||||||||||P
OBX|1|ST|||TestString||||||P
OBX|2|NM|||9001||||||P
OBX|3|DTM|||20160627041809+0000||||||P";

			PipeParser parser = new PipeParser();
			IMessage msg = parser.Parse(hl7Data);

			Assert.IsNotNull(msg, "Message should not be null");
			ORU_R01 oruR01 = (ORU_R01)msg;

			Assert.AreEqual("R01", oruR01.MSH.MessageType.TriggerEvent.Value);
			Assert.AreEqual(null, oruR01.GetPATIENT_RESULT(0).PATIENT.PID.SetIDPID.Value);

			foreach (var result in oruR01.PATIENT_RESULTs)
			{
				foreach (var orderObservation in result.ORDER_OBSERVATIONs)
				{
					int index = 1;
					foreach (var observation in orderObservation.OBSERVATIONs)
					{
						if (index == 1)
						{
							Assert.IsTrue("ST" == observation.OBX.ValueType.Value);
						}
						else if (index == 2)
						{
							Assert.IsTrue("NM" == observation.OBX.ValueType.Value);
						}
						else if (index == 3)
						{
							Assert.IsTrue("DTM" == observation.OBX.ValueType.Value);
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
			string hl7Data = @"MSH|^~\&|Paceart|Medtronic|||20160628142621||ORU^R01^ORU_R01|20160628142621000001|P|2.6|||AL|NE|||||IHE_PCD_ORU_R01^IHE PCD^1.3.6.1.4.1.19376.1.6.1.9.1^ISO
PID|||MODEL:A3DR01 Advisa DR MRI/SERIAL:PZK600806S^^^MDT^U~^^^^Patient ID~A10000641^^^^Paceart||Patient^Test||19100000000000+0000
PV1|1|A
OBR|1||dfac748c-213c-e611-80c5-000c2996266c|754050^MDC_IDC_ENUM_SESS_TYPE_InClinic^MDC^INCLINIC^INCLINIC^MDT|||20160627041809+0000||||||||||||||||||P
OBX|1|ST|||TestString||||||P
OBX|2|NM|||9001||||||P
OBX|3|DTM|||20160627041809+0000||||||P";

			PipeParser parser = new PipeParser();
			IMessage msg = parser.Parse(hl7Data);

			Assert.IsNotNull(msg, "Message should not be null");
			ORU_R01 oruR01 = (ORU_R01)msg;

			Assert.AreEqual("R01", oruR01.MSH.MessageType.TriggerEvent.Value);
			Assert.AreEqual(null, oruR01.GetPATIENT_RESULT(0).PATIENT.PID.SetIDPID.Value);

			foreach (var result in oruR01.PATIENT_RESULTs)
			{
				foreach (var orderObservation in result.ORDER_OBSERVATIONs)
				{
					// Add observation of value type 'NO' and assert that the array reflects the expected state

					int beforeCount = orderObservation.OBSERVATIONs.Count();
					var newObservation = orderObservation.AddOBSERVATION();
					newObservation.OBX.ValueType.Value = "NO";
					int afterAddCount = orderObservation.OBSERVATIONs.Count();
					Assert.IsTrue(afterAddCount > beforeCount);

					var last = orderObservation.OBSERVATIONs.Last().OBX.ValueType.Value;
					Assert.IsTrue("NO" == last);

					// Remove added observation of value type 'NO' using object reference and assert that the array reflects the expected state
					orderObservation.RemoveOBSERVATION(newObservation);
					int afterRemoveCount = orderObservation.OBSERVATIONs.Count();
					Assert.IsTrue(afterRemoveCount == beforeCount);

					last = orderObservation.OBSERVATIONs.Last().OBX.ValueType.Value;
					Assert.IsTrue("DTM" == last);

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
					Assert.IsTrue("DTM" == last);

					// Assert that the array reflects the expected initial state
					int index = 1;
					foreach (var observation in orderObservation.OBSERVATIONs)
					{
						if (index == 1)
						{
							Assert.IsTrue("ST" == observation.OBX.ValueType.Value);
						}
						else if (index == 2)
						{
							Assert.IsTrue("NM" == observation.OBX.ValueType.Value);
						}
						else if (index == 3)
						{
							Assert.IsTrue("DTM" == observation.OBX.ValueType.Value);
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
							Assert.IsTrue("ST" == observation.OBX.ValueType.Value);
						}
						else if (index == 2)
						{
							Assert.IsTrue("DTM" == observation.OBX.ValueType.Value);
						}
						index++;
					}
					Assert.IsTrue(index == 3);

					// Remove the first Item by object reference and assert that the remaining item is the 'DTM' field
					orderObservation.RemoveOBSERVATION(orderObservation.OBSERVATIONs.First());

					var lastRemaining = orderObservation.OBSERVATIONs.First();
					Assert.IsTrue("DTM" == lastRemaining.OBX.ValueType.Value);

					Assert.IsTrue(orderObservation.OBSERVATIONRepetitionsUsed == 1);
				}
			}
		}

		[Test, Explicit]
		public void ParseKnownMessageTypeFromFile()
		{
			string filePath = @"C:\Users\Duane\Desktop\ParseErrors\20160628_142635469_b94dde77-857a-4881-8915-6814809c5442.HL7";
			string fileContents = File.ReadAllText(filePath);

			PipeParser parser = new PipeParser();
			IMessage msg = parser.Parse(fileContents);

			Assert.IsNotNull(msg, "Message should not be null");
			ORU_R01 oruR01 = (ORU_R01)msg;

			Assert.AreEqual("R01", oruR01.MSH.MessageType.TriggerEvent.Value);
			Assert.AreEqual(null, oruR01.GetPATIENT_RESULT(0).PATIENT.PID.SetIDPID.Value);
			var knownDTM = oruR01.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.ValueType.Value;
			Assert.AreEqual("DTM", knownDTM);
			var knownDTMValue = oruR01.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data as DTM;
			Assert.AreEqual("20160627041809+0000", knownDTMValue.ToString());
		}
	}
}