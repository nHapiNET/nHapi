using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Model.V25.Message;
using NHapi.Model.V251.Datatype;
using NUnit.Framework;

namespace NHapi.NUnit
{
	/// <summary>
	/// This test case is in response to BUG 1807858 on source forge.  This BUG really isn't a bug, but the expected functionality.
	/// </summary>
	[TestFixture]
	public class Parsing25
	{
		[Test]
		public void TestAdtA28MappingFromHl7()
		{
			string hl7Data=@"MSH|^~\&|CohieCentral|COHIE|Clinical Data Provider|TCH|20060228155525||ADT^A28^ADT_A05|1|P|2.5|
EVN|
PID|1|12345
PV1|1";
			PipeParser parser = new PipeParser();
			IMessage msg = parser.Parse(hl7Data);

			Assert.IsNotNull(msg, "Message should not be null");
			ADT_A05 a05 = (ADT_A05)msg;

			Assert.AreEqual("A28", a05.MSH.MessageType.TriggerEvent.Value);
			Assert.AreEqual("1", a05.PID.SetIDPID.Value);
		}

		[Test]
		public void TestAdtA28MappingToHl7()
		{
			ADT_A05 a05 = new ADT_A05();

			a05.MSH.MessageType.MessageCode.Value = "ADT";
			a05.MSH.MessageType.TriggerEvent.Value = "A28";
			a05.MSH.MessageType.MessageStructure.Value = "ADT_A05";
			PipeParser parser = new PipeParser();
			string msg = parser.Encode(a05);

			string[] data = msg.Split('|');
			Assert.AreEqual("ADT^A28^ADT_A05", data[8]);
		}
	}
}
