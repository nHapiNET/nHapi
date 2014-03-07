using System;
using NHapi.Model.V231;
using NHapi.Model.V231.Datatype;
using NHapi.Model.V231.Message;
using NHapi.Base.Parser;
using NUnit.Framework;

namespace NHapi.NUnit
{
	[TestFixture]
	public	class ParserTest
	{
		public string GetMessage()
		{
			return @"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.3.1|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|FT|||This\.br\is\.br\A Test||||||F
";
		}
		[Test]
		public void TestSpecialCharacterEncoding()
		{
			PipeParser parser = new PipeParser();
			ORU_R01 oru = new ORU_R01();
			oru = (ORU_R01)parser.Parse(GetMessage());
			
			FT data = (FT)oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data;
			Assert.AreEqual(@"This\.br\is\.br\A Test",data.Value);
		}

		


		[Test]
		public void TestSpecialCharacterEntry()
		{
			PipeParser parser = new PipeParser();
			ORU_R01 oru = new ORU_R01();
			oru.MSH.MessageType.MessageType.Value = "ORU";
			oru.MSH.MessageType.TriggerEvent.Value = "R01";
			oru.MSH.EncodingCharacters.Value = @"^~\&";
			oru.MSH.VersionID.VersionID.Value = "2.3.1";
			oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.ValueType.Value  = "FT";
			oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBR.SetIDOBR.Value = "1";
			NHapi.Base.Model.Varies v = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0);
			ST text = new ST(oru);
			text.Value = @"This\.br\is\.br\A Test";
			v.Data = text;

			
			string encodedData = parser.Encode(oru);
			Console.WriteLine(encodedData);
			NHapi.Base.Model.IMessage msg = parser.Parse(encodedData);
			Console.WriteLine(msg.GetStructureName());
			oru = (ORU_R01)msg;
			FT data = (FT)oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data;
			Assert.AreEqual(@"This\.br\is\.br\A Test", data.Value);
			
			
		}

		[Test]
		public void TestSpecialCharacterEntryEndingSlash()
		{
			PipeParser parser = new PipeParser();
			ORU_R01 oru = new ORU_R01();
			oru.MSH.MessageType.MessageType.Value = "ORU";
			oru.MSH.MessageType.TriggerEvent.Value = "R01";
			oru.MSH.EncodingCharacters.Value = @"^~\&";
			oru.MSH.VersionID.VersionID.Value = "2.3.1";
			oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.ValueType.Value = "FT";
			oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBR.SetIDOBR.Value = "1";
			NHapi.Base.Model.Varies v = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0);
			ST text = new ST(oru);
			text.Value = @"This\.br\is\.br\A Test~";
			v.Data = text;


			string encodedData = parser.Encode(oru);
			NHapi.Base.Model.IMessage msg = parser.Parse(encodedData);
			oru = (ORU_R01)msg;
			FT data = (FT)oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data;
			Assert.AreEqual(@"This\.br\is\.br\A Test~", data.Value);
		}

		[Test]
		public void TestSpecialCharacterEntryWithAllSpecialCharacters()
		{
			PipeParser parser = new PipeParser();
			ORU_R01 oru = new ORU_R01();
			oru.MSH.MessageType.MessageType.Value = "ORU";
			oru.MSH.MessageType.TriggerEvent.Value = "R01";
			oru.MSH.EncodingCharacters.Value = @"^~\&";
			oru.MSH.VersionID.VersionID.Value = "2.3.1";
			oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.ValueType.Value = "FT";
			oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBR.SetIDOBR.Value = "1";
			NHapi.Base.Model.Varies v = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0);
			ST text = new ST(oru);
			text.Value = @"Th&is\.br\is\.br\A T|e\H\st\";
			v.Data = text;


			string encodedData = parser.Encode(oru);
			Console.WriteLine(encodedData);
			NHapi.Base.Model.IMessage msg = parser.Parse(encodedData);
			oru = (ORU_R01)msg;
			FT data = (FT)oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data;
			Assert.AreEqual(@"Th&is\.br\is\.br\A T|e\H\st\", data.Value);
		}

		[Test]
		public void TestValidHl7Data()
		{
			PipeParser parser = new PipeParser();
			ORU_R01 oru = new ORU_R01();
			oru.MSH.MessageType.MessageType.Value = "ORU";
			oru.MSH.MessageType.TriggerEvent.Value = "R01";
			oru.MSH.EncodingCharacters.Value = @"^~\&";
			oru.MSH.VersionID.VersionID.Value = "2.3.1";
			oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.ValueType.Value = "FT";
			oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBR.SetIDOBR.Value = "1";
			NHapi.Base.Model.Varies v = oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0);
			ST text = new ST(oru);
			text.Value = @"Th&is\.br\is\.br\A T|est\";
			v.Data = text;


			string encodedData = parser.Encode(oru);
			
			//Console.WriteLine(encodedData);
			string[] segs = encodedData.Split('\r');
			string[] fields = segs[2].Split('|');
			string data = fields[5];

			Assert.AreEqual(@"Th\T\is\.br\is\.br\A T\F\est\E\", data);
		}
	}
}
