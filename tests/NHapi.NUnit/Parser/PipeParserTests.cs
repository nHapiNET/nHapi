namespace NHapi.NUnit.Parser
{
    using System;

    using global::NUnit.Framework;

    using NHapi.Base.Model;
    using NHapi.Base.Parser;
    using NHapi.Base.Util;
    using NHapi.Model.V231.Datatype;
    using NHapi.Model.V231.Message;

    [TestFixture]
    public class PipeParserTests
    {
        public string GetMessage()
        {
            return "MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.3.1|||AL|||ASCII\r"
                + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
                + "ORC|||||F\r"
                + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
                + "OBX|1|FT|||This\\.br\\is\\.br\\A Test~MoreText~SomeMoreText||||||F";
        }

        [Test]
        public void TestOBR5RepeatingValuesMessage()
        {
            var parser = new PipeParser();
            var oru = (ORU_R01)parser.Parse(GetMessage());

            foreach (var obs in oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION().OBX.GetObservationValue())
            {
                Assert.IsTrue(obs.Data is FT);
            }
        }

        [Test]
        public void TestSpecialCharacterEncoding()
        {
            var parser = new PipeParser();
            var oru = new ORU_R01();
            oru = (ORU_R01)parser.Parse(GetMessage());

            var data = (FT)oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data;
            Assert.AreEqual(@"This\.br\is\.br\A Test", data.Value);
        }

        [Test]
        public void TestSpecialCharacterEntry()
        {
            var parser = new PipeParser();
            var oru = new ORU_R01();
            oru.MSH.MessageType.MessageType.Value = "ORU";
            oru.MSH.MessageType.TriggerEvent.Value = "R01";
            oru.MSH.EncodingCharacters.Value = @"^~\&";
            oru.MSH.VersionID.VersionID.Value = "2.3.1";
            oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.ValueType.Value = "FT";
            oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBR.SetIDOBR.Value = "1";
            var v =
                oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0);
            var text = new ST(oru);
            text.Value = @"This\.br\is\.br\A Test";
            v.Data = text;

            var encodedData = parser.Encode(oru);
            Console.WriteLine(encodedData);
            var msg = parser.Parse(encodedData);
            Console.WriteLine(msg.GetStructureName());
            oru = (ORU_R01)msg;
            var data = (FT)oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data;
            Assert.AreEqual(@"This\.br\is\.br\A Test", data.Value);
        }

        [Test]
        public void TestSpecialCharacterEntryEndingSlash()
        {
            var parser = new PipeParser();
            var oru = new ORU_R01();
            oru.MSH.MessageType.MessageType.Value = "ORU";
            oru.MSH.MessageType.TriggerEvent.Value = "R01";
            oru.MSH.EncodingCharacters.Value = @"^~\&";
            oru.MSH.VersionID.VersionID.Value = "2.3.1";
            oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.ValueType.Value = "FT";
            oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBR.SetIDOBR.Value = "1";
            var v =
                oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0);
            var text = new ST(oru);
            text.Value = @"This\.br\is\.br\A Test~";
            v.Data = text;

            var encodedData = parser.Encode(oru);
            var msg = parser.Parse(encodedData);
            oru = (ORU_R01)msg;
            var data = (FT)oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data;
            Assert.AreEqual(@"This\.br\is\.br\A Test~", data.Value);
        }

        [Test]
        public void TestSpecialCharacterEntryWithAllSpecialCharacters()
        {
            var parser = new PipeParser();
            var oru = new ORU_R01();
            oru.MSH.MessageType.MessageType.Value = "ORU";
            oru.MSH.MessageType.TriggerEvent.Value = "R01";
            oru.MSH.EncodingCharacters.Value = @"^~\&";
            oru.MSH.VersionID.VersionID.Value = "2.3.1";
            oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.ValueType.Value = "FT";
            oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBR.SetIDOBR.Value = "1";
            var v =
                oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0);
            var text = new ST(oru);
            text.Value = @"Th&is\.br\is\.br\A T|e\H\st\";
            v.Data = text;

            var encodedData = parser.Encode(oru);
            Console.WriteLine(encodedData);
            var msg = parser.Parse(encodedData);
            oru = (ORU_R01)msg;
            var data = (FT)oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0).Data;
            Assert.AreEqual(@"Th&is\.br\is\.br\A T|e\H\st\", data.Value);
        }

        [Test]
        public void TestValidHl7Data()
        {
            var parser = new PipeParser();
            var oru = new ORU_R01();
            oru.MSH.MessageType.MessageType.Value = "ORU";
            oru.MSH.MessageType.TriggerEvent.Value = "R01";
            oru.MSH.EncodingCharacters.Value = @"^~\&";
            oru.MSH.VersionID.VersionID.Value = "2.3.1";
            oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.ValueType.Value = "FT";
            oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBR.SetIDOBR.Value = "1";
            var v =
                oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.GetObservationValue(0);
            var text = new ST(oru);
            text.Value = @"Th&is\.br\is\.br\A T|est\";
            v.Data = text;

            var encodedData = parser.Encode(oru);

            var segs = encodedData.Split('\r');
            var fields = segs[2].Split('|');
            var data = fields[5];

            Assert.AreEqual(@"Th\T\is\.br\is\.br\A T\F\est\E\", data);
        }

        [Test]
        public void UnEscapesData()
        {
            // Arrange
            const string content = "MSH|^~\\&|TestSys|432^testsys practice|TEST||201402171537||MDM^T02|121906|P|2.3.1||||||||\r"
                                + "OBX|1|TX|PROBLEM FOCUSED^PROBLEM FOCUSED^test|1|\\T\\#39;Thirty days have September,\\X0D\\April\\X0A\\June,\\X0A\\and November.\\X0A\\When short February is done,\\E\\X0A\\E\\all the rest have\\T\\nbsp;31.\\T\\#39";

            var parser = new PipeParser();
            var msg = parser.Parse(content);

            // Act
            var segment = msg.GetStructure("OBX") as ISegment;
            var idx = Terser.GetIndices("OBX-5");
            var segmentData = Terser.Get(segment, idx[0], idx[1], idx[2], idx[3]);

            // Assert

            // verify that data was properly un-escaped by NHapi
            // \E\X0A\E\ should be escaped to \X0A\
            // \X0A\ should be un-escaped to \n - this is configurable
            // \X0D\ should be un-escaped to \r - this is configurable
            // \t\ should be un-escaped to &
            const string expectedResult =
                "&#39;Thirty days have September,\rApril\nJune,\nand November.\nWhen short February is done,\\X0A\\all the rest have&nbsp;31.&#39";
            Assert.AreEqual(expectedResult, segmentData);
        }

        /// <summary>
        /// Check that an <see cref="ArgumentNullException"/> is thrown when a null <see cref="ParserConfiguration"/> is
        /// provided to <c>Parse</c> method calls.
        /// </summary>
        [Test]
        public void ParseWithNullConfigThrows()
        {
            var parser = new PipeParser();
            IMessage nullMessage = null;
            const string version = "2.5.1";
            ParserConfiguration nullConfiguration = null;

            Assert.Throws<ArgumentNullException>(() => parser.Parse(GetMessage(), nullConfiguration));
            Assert.Throws<ArgumentNullException>(() =>
                parser.Parse(nullMessage, GetMessage(), nullConfiguration));
            Assert.Throws<ArgumentNullException>(() => parser.Parse(GetMessage(), version, nullConfiguration));
        }
    }
}