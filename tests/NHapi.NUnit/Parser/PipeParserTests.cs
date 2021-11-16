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

        private static void SetMessageHeader(Model.V251.Message.OML_O21 msg, string messageCode, string messageTriggerEvent, string processingId)
        {
            var msh = msg.MSH;

            Terser.Set(msh, 1, 0, 1, 1, "|");
            Terser.Set(msh, 2, 0, 1, 1, "^~\\&");
            Terser.Set(msh, 7, 0, 1, 1, DateTime.Now.ToString("yyyyMMddHHmmssK"));
            Terser.Set(msh, 9, 0, 1, 1, messageCode);
            Terser.Set(msh, 9, 0, 2, 1, messageTriggerEvent);
            Terser.Set(msh, 10, 0, 1, 1, Guid.NewGuid().ToString());
            Terser.Set(msh, 11, 0, 1, 1, processingId);
            Terser.Set(msh, 12, 0, 1, 1, msg.Version);
        }

        /// <summary>
        /// This test is ported from HAPI:
        /// https://github.com/hapifhir/hapi-hl7v2/blob/3333e3aeae60afb7493f6570456e6280c0e16c0b/hapi-test/src/test/java/ca/uhn/hl7v2/parser/NewPipeParserTest.java#L158
        /// See http://sourceforge.net/p/hl7api/bugs/171/.
        /// </summary>
        [Test]
        public void GreedyMode()
        {
            var msg = new Model.V251.Message.OML_O21();
            SetMessageHeader(msg, "OML", "O21", "T");

            for (var i = 0; i < 5; i++)
            {
                var orc = msg.GetORDER(i).ORC;
                var obr4 = msg.GetORDER(i).OBSERVATION_REQUEST.OBR.UniversalServiceIdentifier;

                orc.OrderControl.Value = "NW";
                orc.PlacerOrderNumber.EntityIdentifier.Value = "ORCID1";
                orc.PlacerOrderNumber.NamespaceID.Value = "HCE";
                orc.PlacerGroupNumber.EntityIdentifier.Value = "grupo";

                obr4.Identifier.Value = "STDIO1";
                obr4.NameOfCodingSystem.Value = "LOINC";
            }

            // Parse and encode
            var pp = new PipeParser();
            msg = pp.Parse(
                pp.Encode(msg),
                new ParserConfiguration { NonGreedyMode = true }) as Model.V251.Message.OML_O21;
            Assert.NotNull(msg);

            for (var i = 0; i < 5; i++)
            {
                var actual = msg.GetORDER(i).ORC.OrderControl.Value;
                Assert.AreEqual("NW", actual);

                actual = msg.GetORDER(i).OBSERVATION_REQUEST.OBR.UniversalServiceIdentifier.Identifier.Value;
                Assert.AreEqual("STDIO1", actual);
            }

            // Now turn off greedy mode
            msg = pp.Parse(
                pp.Encode(msg),
                new ParserConfiguration { NonGreedyMode = false }) as Model.V251.Message.OML_O21;
            Assert.NotNull(msg);

            {
                var actual = msg.GetORDER(0).ORC.OrderControl.Value;
                Assert.AreEqual("NW", actual);

                actual = msg.GetORDER(0).OBSERVATION_REQUEST.OBR.UniversalServiceIdentifier.Identifier.Value;
                Assert.AreEqual("STDIO1", actual);
            }

            for (var i = 1; i < 5; i++)
            {
                var actual = msg.GetORDER(i).ORC.OrderControl.Value;
                Assert.IsNull(actual);

                actual = msg.GetORDER(i).OBSERVATION_REQUEST.OBR.UniversalServiceIdentifier.Identifier.Value;
                Assert.IsNull(actual);
            }
        }

        /// <summary>
        /// This test is ported from HAPI:
        /// https://github.com/hapifhir/hapi-hl7v2/blob/3333e3aeae60afb7493f6570456e6280c0e16c0b/hapi-test/src/test/java/ca/uhn/hl7v2/parser/NewPipeParserTest.java#L217
        /// See http://sourceforge.net/p/hl7api/bugs/171/.
        /// </summary>
        [Test]
        public void MoreGreedyMode()
        {
            // OML_O21 messages extracted from https://sourceforge.net/p/hl7api/bugs/171/attachment/IHE_LTW_Examples.java
            var messages = new System.Collections.Generic.List<string>
            {
                "MSH|^~\\&|OP|Entero-gastric|OF|Chemistry|200309060820||OML^O21^OML_O21|msgOP123|T|2.5.1|123\r" +
                "PID|1||12345^5^M10^Memphis_Hosp^PI||EVERYMAN^ADAM^^JR^^^L||19800101|M\r" +
                "PV1|1|O|Ward|||||||||||||||12345\r" +
                "ORC|NW|12345678^gastric||666^gastric|||||200309060710|222221^NURSE^NANCY|||||||||||Entero-gastric^^^^^^FI^^^EG02\r" +
                "TQ1|||||||||A\r" +
                "OBR||12345678^gastric||82951^Glucose Tolerance Test^C4||||||1234^BLEEDER|P|||||222222^PHYSICIAN^^^^DR|821\r" +
                "OBX|1|NM|GLUCOSE||75|g|||||F|||200309060735\r" +
                "SPM|1|123456781^gastric||SER|||||||P||||||200309060735|||||||||1\r" +
                "SPM|2|123456782^gastric||SER|||||||P||||||200309060755|||||||||1\r" +
                "SPM|3|123456783^gastric||SER|||||||P||||||200309060815|||||||||1",

                "MSH|^~\\&|OF|Chemistry|OP|Entero-gastric|200309060825||OML^O21^OML_O21|msgOF102|T|2.5.1|123\r" +
                "PID|1||12345^5^M10^Memphis_Hosp^PI||EVERYMAN^ADAM^^JR^^^L||19800101|M\r" +
                "PV1|1|O|Ward|||||||||||||||12345\r" +
                "ORC|SC|12345678^gastric||666^gastric|IP||||200309060824|222221^NURSE^NANCY |||||||||||Entero-gastric^^^^^^FI^^^EG02\r" +
                "TQ1|||||||||A\r" +
                "OBR||12345678^gastric|555^chemistry|82951^Glucose Tolerance Test^C4||||||1234^BLEEDER|P|||||222222^PHYSICIAN^^^^DR|821||||||||I\r" +
                "SPM|1|123456781^gastric||SER|||||||P||||||200309060735|200309060821||Y||||||1\r" +
                "SPM|2|123456782^gastric||SER|||||||P||||||200309060755|200309060821||Y||||||1\r" +
                "SPM|3|123456783^gastric||SER|||||||P||||||200309060815|200309060821||N|RB^Broken container|||||1",

                "MSH|^~\\&|OP|Entero-gastric|OF|Chemistry|200309060900||OML^O21^OML_O21|msgOP124|T|2.5.1|123\r" +
                "PID|1||12345^5^M10^Memphis_Hosp^PI||EVERYMAN^ADAM^^JR^^^L||19800101|M\r" +
                "PV1|1|O|Ward|||||||||||||||12345\r" +
                "ORC|XO|12345678^gastric||666^gastric|||||200309060855|222221^NURSE^NANCY|||||||||||Entero-gastric^^^^^^FI^^^EG02\r" +
                "TQ1|||||||||A\r" +
                "OBR||12345678^gastric||82951^Glucose Tolerance Test^C4||||||1234^BLEEDER|S|||||222222^PHYSICIAN^^^^DR|821\r" +
                "OBX|1|NM|GLUCOSE||75|g|||||F|||200309060735\r" +
                "SPM|1|123456781^gastric||SER|||||||P||||||200309060735|||||||||1\r" +
                "SPM|2|123456782^gastric||SER|||||||P||||||200309060755|||||||||1\r" +
                "SPM|3|123456783^gastric||SER|||||||P||||||200309060815|||||||||1\r" +
                "SPM|4|123456784^gastric||SER|||||||P||||||200309060835|||||||||1\r" +
                "SPM|5|123456785^gastric||SER|||||||P||||||200309060855|||||||||1",

                "MSH|^~\\&|OF|Chemistry|OP|Entero-gastric|200309060930||OML^O21^OML_O21|msgOF109|T|2.5.1|123\r" +
                "PID|1||12345^5^M10^Memphis_Hosp^PI||EVERYMAN^ADAM^^JR^^^L||19800101|M\r" +
                "PV1|1|O|Ward|||||||||||||||12345\r" +
                "ORC|SC|12345678^gastric||666^gastric|CM||||200309060929|222221^NURSE^NANCY|||||||||||Entero-gastric^^^^^^FI^^^EG02\r" +
                "TQ1|||||||||A\r" +
                "OBR||12345678^gastric|555^chemistry|82951^Glucose Tolerance Test^C4||||||1234^BLEEDER|S|||||222222^PHYSICIAN^^^^DR|821|||||200309060929|||F|||||||444444&CHEMISTRY-EXPERT&Jane&&&&&&MEMPHIS HOSPITAL^200309060929\r" +
                "SPM|1|123456781^gastric ||SER|||||||P||||||200309060735|200309060821||Y||||||1\r" +
                "SPM|2|123456782^gastric ||SER|||||||P||||||200309060755|200309060821||Y||||||1\r" +
                "SPM|3|123456783^gastric ||SER|||||||P||||||200309060815|200309060821||N|RB|||||1\r" +
                "SPM|4|123456784^gastric ||SER|||||||P||||||200309060835|200309060902||Y||||||1\r" +
                "SPM|5|123456785^gastric ||SER|||||||P||||||200309060855|200309060902||Y||||||1",

                "MSH|^~\\&|HIS|ASE|LIS|Rapela|||OML^O21||T|2.5\r" +
                "PID|||14^^^^HC-HCE||BARRIONUEVO^RODOLFO SEBASTIÁN\r" +
                "IN1|1|260^^Planes-HCE|10464^^^^OOSS-HCE|OSDE 210\r" +
                "ORC|NW|1^HCE\r" +
                "OBR|1|1^HCE||1041^FAUCES RAPIDO (EIA O LATEX)^Desarrollo^2117^FAUCES RAPIDO (EIA O LATEX)^Cod-HCE|S|201301221046\r" +
                "ORC|NW|2^HCE\r" +
                "OBR|2|2^HCE||1050^OSTEOCALCINA SERICA^Desarrollo^2121^OSTEOCALCINA SERICA^Cod-HCE|S|201301221046\r" +
                "ORC|NW|3^HCE\r" +
                "OBR|3|3^HCE||10525^HEPATITIS B GENOTIPO^Desarrollo^2126^HEPATITIS B GENOTIPO^Cod-HCE|S|201301221046\r" +
                "ORC|NW|4^HCE\r" +
                "OBR|4|4^HCE||10526^HEMOCULTIVO BACTEC - 1 MUESTRA (CULTIVO RAPIDO)^Desarrollo^2127^HEMOCULTIVO BACTEC - 1 MUESTRA (CULTIVO RAPIDO)^Cod-HCE|S|201301221046",

                "MSH|^~\\&|OF|Chemistry|AM|Automation|200309060825||OML^O21^OML_O21|msgOF101|T|2.5|123||||USA||EN\r" +
                "PID|1||12345^5^M10^Memphis_Hosp^PI||EVERYMAN^ADAM^^JR^^^L||19800101|M\r" +
                "PV1|1|O|Ward|||||||||||||||12345\r" +
                "ORC|NW|||666^gastric|||||200309060824|222221^NURSE^NANCY|||||||||||Entero-gastric^^^^^^FI^^^EG02\r" +
                "TQ1|||||||||A\r" +
                "OBR||555_1^chemistry||GLUC^GLUCOSE^L||||||1234^BLEEDER|S|||||222222^PHYSICIAN^^^^DR|821\r" +
                "SPM|1|123456781^gastric ||SER|||||||P||||||200309060735|200309060821||||||||1\r" +
                "ORC|NW|||666^gastric|||||200309060710|222221^NURSE^NANCY|||||||||||Entero-gastric^^^^^^FI^^^EG02\r" +
                "TQ1|||||||||A\r" +
                "OBR||555_2^chemistry||GLUC^GLUCOSE^L||||||1234^BLEEDER|S|||||222222^PHYSICIAN^^^^DR|821\r" +
                "SPM|1|123456782^gastric||SER|||||||P||||||200309060755|200309060821||||||||1",

                "MSH|^~\\&|HIS|ASE|LIS|Rapela|||OML^O21||T|2.5\r" +
                "PID|||14^^^^HC-HCE||BARRIONUEVO^RODOLFO SEBASTIÁN\r" +
                "ORC|NW|||GROUP1^HCE\r" +
                "TQ1|\r" +
                "OBR||id1^HCE|81641^RAD|73666^Bilateral Feet|\r" +
                "SPM|1|123456781^gastric||SER\r" +
                "ORC|NW|||GROUP1^HCE\r" +
                "TQ1|\r" +
                "OBR||id2^HCE|81642^RAD|73642^Bilateral Hand PA|\r" +
                "SPM|2|123456782^gastric||SER\r" +
                "ORC|NW|||GROUP1^HCE\r" +
                "TQ1|\r" +
                "OBR||id3^HCE|81643^RAD|73916^Bilateral Knees|\r" +
                "SPM|3|123456783^gastric||SER",
            };

            var parser = new PipeParser();
            var greedyConfig = new ParserConfiguration { NonGreedyMode = true };

            foreach (var message in messages)
            {
                var oml25 = parser.Parse(message, greedyConfig) as Model.V25.Message.OML_O21;
                var oml251 = parser.Parse(message, greedyConfig) as Model.V251.Message.OML_O21;

                if (oml25 is null)
                {
                    Assert.NotNull(oml251);
                    Assert.AreEqual(0, oml251.GetORDER(0).OBSERVATION_REQUEST.PRIOR_RESULTRepetitionsUsed);
                }
                else
                {
                    Assert.NotNull(oml25);
                    Assert.AreEqual(0, oml25.GetORDER(0).OBSERVATION_REQUEST.PRIOR_RESULTRepetitionsUsed);
                }
            }
        }
    }
}