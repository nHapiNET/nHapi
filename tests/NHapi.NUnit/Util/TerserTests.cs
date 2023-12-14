namespace NHapi.NUnit.Util
{
    using System;

    using global::NUnit.Framework;

    using NHapi.Base;
    using NHapi.Base.Model;
    using NHapi.Base.Parser;
    using NHapi.Base.Util;
    using NHapi.Model.V24.Datatype;
    using NHapi.Model.V24.Message;

    using RSP_K23 = NHapi.Model.V25.Message.RSP_K23;

    [TestFixture]
    public class TerserTests
    {
        private SIU_S12 suiS12;
        private Terser sut;

        [SetUp]
        public void Init()
        {
            suiS12 = new SIU_S12();
            suiS12.MSH.MessageType.TriggerEvent.Value = "a";
            suiS12.GetPATIENT().PID.BirthPlace.Value = "b";
            suiS12.GetRESOURCES().GetGENERAL_RESOURCE().AIG.GetResourceGroup(0).Identifier.Value = "c";
            suiS12.GetRESOURCES().GetGENERAL_RESOURCE().AIG.GetResourceGroup(1).Identifier.Value = "d";
            suiS12.GetRESOURCES(1).GetGENERAL_RESOURCE().AIG.GetResourceGroup(0).Identifier.Value = "e";
            suiS12.SCH.GetPlacerContactPerson(0).AssigningAuthority.UniversalID.Value = "subcomp";
            sut = new Terser(suiS12);
        }

        [Test]
        [TestCase("MSH-9-2", "a")]
        [TestCase("/MSH-9-2", "a")]
        [TestCase("/*H-9-2", "a")]
        [TestCase("/.PID-23", "b")]
        [TestCase("/.*ID-23-1-1", "b")]
        [TestCase("/.AIG-5-1", "c")]
        [TestCase("/*RES*/GENERAL_RESOURCE/AIG-5-1", "c")]
        [TestCase("/*RES*/GENERAL_RESOURCE/AIG-5(1)-1", "d")]
        [TestCase("/*RES*(1)/GENERAL_RESOURCE/AIG-5(0)-1", "e")]
        [TestCase("/SCH-12-9-2", "subcomp")]
        public void Get_ValidSpec_ReturnsExpectedValue(string path, string expected)
        {
            var actual = sut.Get(path);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Set_ValidSpec_SetsExpectedValue()
        {
            var path = "/*RES*(1)/GENERAL_RESOURCE/AIG-5-1";
            var expected = "foot";
            sut.Set(path, expected);

            var actual = sut.Get(path);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestVaries()
        {
            var n = suiS12.MSH.NumFields() + 1;
            var v = (Varies)suiS12.MSH.GetField(n, 0);
            var p = (IPrimitive)v.Data; // will be generic primitive
            var expected = "x";

            p.Value = expected;

            Assert.That(sut.Get($"MSH-{n}"), Is.EqualTo(expected));

            v.Data = new CE(suiS12);

            Assert.That(sut.Get($"MSH-{n}"), Is.EqualTo(expected));

            ((CE)v.Data).Text.Value = "text";
            Assert.That(sut.Get($"MSH-{n}-2"), Is.EqualTo("text"));
        }

        [Test]
        public void TestExtraComponents()
        {
            sut.Set("/MSH-9-4", "foo");
            Assert.That(sut.Get("/MSH-9-4"), Is.EqualTo("foo"));

            sut.Set("/MSH-9-4-2", "bar");
            Assert.Multiple(() =>
            {
                Assert.That(sut.Get("/MSH-9-4-2"), Is.EqualTo("bar"));
                Assert.That(sut.Get("/MSH-9-4-1"), Is.EqualTo("foo"));
            });
        }

        [Test]
        [TestCase("*MSH-9-2", "a")]
        [TestCase("*SH-9-2", "a")]
        [TestCase("*S*-9-2", "a")]
        [TestCase("*H-9-2", "a")]
        [TestCase("MS*-9-2", "a")]
        [TestCase("*-9-2", "a")]
        [TestCase("?SH-9-2", "a")]
        [TestCase("?S?-9-2", "a")]
        [TestCase("?S*-9-2", "a")]
        public void Get_ValidPathWithWildcards_ReturnsExpectedValue(string path, string expected)
        {
            var actual = sut.Get(path);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("*QQQ-9-2")]
        [TestCase("?MSH-9-2")]
        public void Get_InValidPathWithWildcards_ThrowsHL7Exception(string path)
        {
            Assert.That(() => sut.Get(path), Throws.TypeOf<HL7Exception>());
        }

        /// <summary>
        /// This test was copied wholesale from the hapi test suite.
        /// </summary>
        [Test]
        public void TestSearch()
        {
            var msg = "MSH|^~\\&|POW|100||100|200012171800||RDE^O11|14718|P|2.4|||AL|NE|0\r"
                    + "PID|0001|99999|2000006|000077777|Possible^Kim^||195002220000|F||1|100 E San Marcos Blvd^^San Marcos^CA^92069^USA^^^San Diego|||||M||2000006|123-45-6789|A0012345^CA||1|||||||||\r"
                    + "ORC|NW|RX1|RX1||IP||^BID^X001^200012171800^200308200600|2045&OE^123&PH|200012171800|Nurse1|Nurse2|1^Order MD|||200012171800||||\r"
                    + "RXR|XXX\r"
                    + "RXE|^BID^X001^200012171800^200308200600|99089^DIGOXIN (LANOXIN) -- 0.25 mg|0.2500|0.2500|mg|TA|111^||||||||||||||222^||||0.0000|||||\r"
                    + "RXR|PO||\r";

            /*
             * Note, these test cases assume the old behaviour of handling
             * unexpected segments
             */
            var pipeParser = new LegacyPipeParser();

            var message = pipeParser.Parse(msg);
            var terser = new Terser(message);

            var value = terser.Get("/.ORC-2");
            Assert.That(value, Is.EqualTo("RX1"));

            value = terser.Get("/ORDER*/RXR-1");
            Assert.That(value, Is.EqualTo("PO"));
            value = terser.Get("/*ORDER*/RXR-1");
            Assert.That(value, Is.EqualTo("PO"));
            value = terser.Get("/ORDER*/RXE-1-2");
            Assert.That(value, Is.EqualTo("BID"));
            value = terser.Get("/.ORC-1-1");
            Assert.That(value, Is.EqualTo("NW"));

            // fixed ... original error: yields HL7Exception: End of message reached --
            // this is a peer to ORC, which does work with same syntax
            value = terser.Get("/.RXE-1-2");
            Assert.That(value, Is.EqualTo("BID"));

            // makes sense ... value is in 2nd RXR ... adding segment before RXE to test this
            // ... original error: yields "null" instead of "PO"
            value = terser.Get("/.RXR-1");
            Assert.That(value, Is.EqualTo("XXX"));

            // makes sense ... value is in 2nd RXR ... original error: yields "null" instead of "PO"
            // value = terser.Get("/.RDE_O11_RXR/RXR-1");
            // Assert.That(value, Is.EqualTo("XXX"));

            // as above
            value = terser.Get("/ORDER*/.RXR(0)-1");
            Assert.That(value, Is.EqualTo("XXX"));

            // as above
            value = terser.Get("/ORDER*/.RXR-1");
            Assert.That(value, Is.EqualTo("XXX"));

            // try getting to the PO value
            // value = terser.Get("/RDE_O11_ORC*/.RXR-1");
            // Assert.That(value, Is.EqualTo("PO"));

            // OK (* finds first structure): yields NoSuchElementException
            // value = terser.Get("/RDE_O11_ORC*/*/RXR-1");

            // OK (* finds first structure): yields NoSuchElementException
            // value = terser.Get("/*/RDE_O11_RXR/RXR-1");
        }

        /// <summary>
        /// This test was copied wholesale from the hapi test suite.
        /// </summary>
        [Test]
        public void TestEnumerators()
        {
            var segment = sut.GetSegment("MSH");
            Assert.That(Terser.numComponents(segment.GetField(9, 0)), Is.EqualTo(3));

            segment.GetField(9, 0).ExtraComponents.GetComponent(0);
            Assert.That(Terser.numComponents(segment.GetField(9, 0)), Is.EqualTo(4));

            segment.GetField(9, 0).ExtraComponents.GetComponent(1);
            Assert.That(Terser.numComponents(segment.GetField(9, 0)), Is.EqualTo(5));

            segment.GetField(2, 0).ExtraComponents.GetComponent(0);
            Assert.That(Terser.numComponents(segment.GetField(2, 0)), Is.EqualTo(2));

            ((IPrimitive)((IComposite)segment.GetField(9, 0)).Components[0].ExtraComponents.GetComponent(0).Data).Value = "xxx";
            Assert.That(Terser.numSubComponents(segment.GetField(9, 0), 1), Is.EqualTo(2));
        }

        [Test]
        public void TestPatientId()
        {
            var msgString = "MSH|^~\\&|XYZ|a1510aae-cbcd-43d0-b0e2-4ad082f03775|HU|7d15ac56-8b12-4a07-8b10-3d2ae367f407|20100831104406||RSP^K23|20100831104406208095|P|2.5\r"
                        + "MSA|AA|20100831104406208095\r"
                        + "QAK||OK\r"
                        + "QPD|QRY_1001^Query for Corresponding Identifiers^ICDO|QRY10502106|QBPQ231176^^^57f31a9b-8eff-4736-84c4-6fafd6f25039\r"
                        + "PID|||QBPQ231177^^^DD95666A-76BA-444E-8FE8-C4E6BFC83E2D";

            var qryMsg = (RSP_K23)new PipeParser().Parse(msgString);
            var terser = new Terser(qryMsg);
            var expected = "QBPQ231177";

            Assert.Multiple(() =>
            {
                Assert.That(terser.Get("/.PID-3-1"), Is.EqualTo(expected));
                Assert.That(terser.Get("/QUERY_RESPONSE(0)/.PID-3-1"), Is.EqualTo(expected));
            });
        }

        /// <summary>
        /// https://github.com/nHapiNET/nHapi/issues/319.
        /// </summary>
        [Test]
        public void Get_OMD_O03_ValidTerserPathSpecifaction_ReturnsExpectedResult()
        {
            var parser = new PipeParser();

            var omdText = "MSH|^~\\&|EDITE|TEST|TEST|TEST|20210519141200||OMD^O03^OMD_O03|202105191412001|P|2.5|||||FRA|8859/1\r" +
                          "PID|1|465 306 5961||407623|Wood^Patrick^^^MR||19700101|1|||High Street^^Oxford^^Ox1 4DP~George St ^^Oxford^^Ox1 5AP|||||||\r" +
                          "ORC|NW|1254481^EDITEUR|||||^^^20210519143000||20210519143000|611014333^PRESCRIPTEUR^TEST1^^^^^^EDITEUR^^^^ADELI~10002129790^PRESCRIPTEUR^TEST1 ^^^^^^EDITEUR ^^^^RPPS~1027^PRESCRIPTEUR^TEST1^^^^^^EDITEUR^^^^EI||||||||||||||||||||\r" +
                          "TQ1|1||||||20210519143000|\r" +
                          "ODS|R||SANSSEL^Sans sel^EDITEUR|";

            var parsed = parser.Parse(omdText);

            var terser = new Terser(parsed);

            var tq17 = terser.Get("/.ORDER_DIET(0)/TIMING_DIET/TQ1-7");
            var ods1 = terser.Get("/.ORDER_DIET(0)/DIET/ODS(0)-1");

            Assert.Multiple(() =>
            {
                Assert.That(tq17, Is.EqualTo("20210519143000"));
                Assert.That(ods1, Is.EqualTo("R"));
            });
        }

        #region Static Methods

        [Test]
        public void Get_SegmentIsNull_ThrowsArgumentNullException()
        {
            Assert.That(
                () => Terser.Get(null, 0, 0, 0, 0),
                Throws.ArgumentNullException);
        }

        [Test]
        public void Get_ComponentIsLessThan0_ThrowsArgumentOutOfRangeException()
        {
            var segment = suiS12.MSH;

            Assert.That(
                () => Terser.Get(segment, 0, 0, -1, 0),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Get_SubComponentIsLessThan0_ThrowsArgumentOutOfRangeException()
        {
            var segment = suiS12.MSH;

            Assert.That(
                () => Terser.Get(segment, 0, 0, 0, -1),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Get_RepIsLessThan0_ThrowsArgumentOutOfRangeException()
        {
            var segment = suiS12.MSH;

            Assert.That(
                () => Terser.Get(segment, 0, -1, 0, 0),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void GetPrimitive_TypeIsNull_ThrowsArgumentNullException()
        {
            Assert.That(
                () => Terser.GetPrimitive(null, 0, 0),
                Throws.ArgumentNullException);
        }

        [Test]
        public void GetPrimitive_ComponentIsLessThen0_ArgumentOutOfRangeException()
        {
            var type = suiS12.MSH.MessageType;

            Assert.That(
                () => Terser.GetPrimitive(type, -1, 0),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void GetPrimitive_SubComponentIsLessThen0_ArgumentOutOfRangeException()
        {
            var type = suiS12.MSH.MessageType;

            Assert.That(
                () => Terser.GetPrimitive(type, 0, -1),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void TestMultiArg()
        {
            var msh = suiS12.MSH;
            var test = Terser.Get(msh, 9, 0, 2, 1);

            Assert.That(test, Is.EqualTo("a"));
        }

        #endregion
    }
}