namespace NHapi.NUnit.Parser
{
    using System;

    using global::NUnit.Framework;

    using NHapi.Base;
    using NHapi.Base.Model;
    using NHapi.Base.Parser;
    using NHapi.Base.Util;
    using NHapi.Model.V26.Message;

    [TestFixture]
    public class ParserBaseTests
    {
        [TestCase("2.1", typeof(Model.V21.Segment.MSH))]
        [TestCase("2.2", typeof(Model.V22.Segment.MSH))]
        [TestCase("2.3", typeof(Model.V23.Segment.MSH))]
        [TestCase("2.3.1", typeof(Model.V231.Segment.MSH))]
        [TestCase("2.4", typeof(Model.V24.Segment.MSH))]
        [TestCase("2.5", typeof(Model.V25.Segment.MSH))]
        [TestCase("2.5.1", typeof(Model.V251.Segment.MSH))]
        [TestCase("2.6", typeof(Model.V26.Segment.MSH))]
        [TestCase("2.7", typeof(Model.V27.Segment.MSH))]
        [TestCase("2.7.1", typeof(Model.V271.Segment.MSH))]
        [TestCase("2.8", typeof(Model.V28.Segment.MSH))]
        [TestCase("2.8.1", typeof(Model.V281.Segment.MSH))]
        public void MakeControlMSH_ValidVersion_ReturnsExpectedMsh(string version, Type expectedType)
        {
            // Arrange
            var factory = new DefaultModelClassFactory();

            // Act
            var msh = ParserBase.MakeControlMSH(version, factory);

            // Assert
            Assert.IsInstanceOf(expectedType, msh);
        }

        [Test]
        public void MakeControlMSH_UnknownVersion_ThrowsHL7Exception()
        {
            // Arrange
            var version = "1";
            var factory = new DefaultModelClassFactory();

            // Act / Assert
            Assert.Throws<HL7Exception>(() => ParserBase.MakeControlMSH(version, factory));
        }

        [TestCase("MSH|^~\\&|||||||ADT^A04|1|D|2.4\r", "ADT_A01")] // mapped to ADT_A01
        [TestCase("MSH|^~\\&|||||||ACK|1|D|2.4\r", "ACK")] // shouldn't be a map entry, so should return an ACK
        [TestCase("MSH|^~\\&|||||||ADT^A01|1|D|2.1\r", "ADT_A01")] // no maps so should map to self
        public void EventMapMappsCorrectly(string input, string expectedName)
        {
            // Arrange
            var sut = new PipeParser();

            // Act
            var message = sut.Parse(input);

            // Assert
            Assert.AreEqual(expectedName, message.GetStructureName());
        }

        [TestCase("2.1", typeof(GenericMessage.V21))]
        [TestCase("2.2", typeof(GenericMessage.V22))]
        [TestCase("2.3", typeof(GenericMessage.V23))]
        [TestCase("2.3.1", typeof(GenericMessage.V231))]
        [TestCase("2.4", typeof(GenericMessage.V24))]
        [TestCase("2.5", typeof(GenericMessage.V25))]
        [TestCase("2.5.1", typeof(GenericMessage.V251))]
        [TestCase("2.6", typeof(GenericMessage.V26))]
        [TestCase("2.7", typeof(GenericMessage.V27))]
        [TestCase("2.7.1", typeof(GenericMessage.V271))]
        [TestCase("2.8", typeof(GenericMessage.V28))]
        [TestCase("2.8.1", typeof(GenericMessage.V281))]
        public void Parse_UnknownMessageType_ReturnsGenericMessage(string version, Type expectedType)
        {
            // Arrange
            // a valid ORU_R01 message in which MSH-9 has been changed
            var input = $"MSH|^~\\&|LABGL1||DMCRES||19951002185200||ZZZ^ZZZ|LABGL1199510021852632|P|{version}\r"
                        + "PID|||T12345||TEST^PATIENT^P||19601002|M||||||||||123456\r"
                        + "PV1|||NER|||||||GSU||||||||E||||||||||||||||||||||||||19951002174900|19951006\r"
                        + "OBR|1||09527539437000040|7000040^ETHANOL^^^ETOH|||19951002180500|||||||19951002182500||||1793561||0952753943||19951002185200||100|F||^^^^^RT\r"
                        + "OBX||NM|7000040^ETHANOL^^^ETOH|0001|224|mg/dL|||||F|||19951002185200||182\r"
                        + "NTE|||          Reference Ranges\r" + "NTE|||          ****************\r"
                        + "NTE|||           Normal:              Negative\r"
                        + "NTE|||           Toxic Concentration: >80 mg/dL\r";

            var expectedMsh5 = "DMCRES";
            var expectedObx2 = "NM";

            var sut = new PipeParser();

            // Act
            var message = sut.Parse(input);
            sut.Encode(message);

            var terser = new Terser(message);

            // Assert
            Assert.AreEqual(expectedType, message.GetType());
            Assert.AreEqual(expectedMsh5, terser.Get("/MSH-5"));
            Assert.AreEqual(expectedObx2, terser.Get("/OBX-2"));
        }

        #region Unknown Test Value
        /*
           These tests were copied from ParserTest.java in the hapi project
           It is unclear what the tests are actually proving.
         */

        [Test]
        public void Parse_WithTruncationCharacter()
        {
            // Arrange
            var input = "MSH|^~\\&#|Send App|Send Fac|Rec App|Rec Fac|20070504141816||ORM^O01||P|2.7\r"
                        + "PID|||12345678||Lastname^^INI^^PREFIX||19340207|F|||Street 15^^S GRAVENHAGE^^2551HL^NEDERLAND|||||||||||||||NL\r"
                        + "ORC|NW|8100088345^ORDERNR||LN1||C|^^^20070504080000||20070504141816|||0^Doctor\r"
                        + "OBR|1|8100088345^ORDERNR||ADR^Something||||||||||||0^Doctor\r"
                        + "OBX|1|ST|ADR^Something||item1^item2^item3^^item5||||||F\r";

            var sut = new PipeParser();

            // Act
            var message = sut.Parse(input);
            var encoded = sut.Encode(message);

            // Assert
            Assert.AreEqual(input, encoded);
        }

        [Test]
        public void Test1714219()
        {
            // Arrange
            var input = "MSH|^~\\&|Send App|Send Fac|Rec App|Rec Fac|20070504141816||ORM^O01||P|2.2\r"
                        + "PID|||12345678||Lastname^^INI^^PREFIX||19340207|F|||Street 15^^S GRAVENHAGE^^2551HL^NEDERLAND|||||||||||||||NL\r"
                        + "ORC|NW|8100088345^ORDERNR||LN1||C|^^^20070504080000||20070504141816|||0^Doctor\r"
                        + "OBR|1|8100088345^ORDERNR||ADR^Something||||||||||||0^Doctor\r"
                        + "OBX|1|ST|ADR^Something||item1^item2^item3^^item5||||||F\r";

            var sut = new PipeParser();

            // Act
            var message = sut.Parse(input);
            var encoded = sut.Encode(message);

            // Assert
            Assert.AreEqual(input, encoded);
        }

        [Test]
        public void Test17142192()
        {
            // Arrange
            var input = "MSH|^~\\&|Send App|Send Fac|Rec App|Rec Fac|20070504141816||ORM^O01||P|2.3\r"
                        + "PID|||12345678||Lastname^^INI^^PREFIX||19340207|F|||Street 15^^S GRAVENHAGE^^2551HL^NEDERLAND|||||||||||||||NL\r"
                        + "ORC|NW|8100088345^ORDERNR||LN1||C|^^^20070504080000||20070504141816|||0^Doctor\r"
                        + "OBR|1|8100088345^ORDERNR||ADR^Something||||||||||||0^Doctor\r"
                        + "OBX|1|RP|ADR^Something||http://TRACEMASTERVUE/TMVWebAPIClient/ShowTIFFImage.aspx?ECGID=0595f00-317e-11e2-4823-00201fe00029||||||F\r";

            var sut = new PipeParser();

            // Act
            var message = sut.Parse(input);
            var encoded = sut.Encode(message);

            // Assert
            Assert.AreEqual(input, encoded);
        }

        [Test]
        public void TestParserDoesntFailWithoutValidationExceptionHandlerFactory()
        {
            var adt = new ADT_A01();

            var sut = new PipeParser();
            var xmlParser = new DefaultXMLParser();

            var msg = sut.Encode(adt);
            sut.Parse(msg);

            msg = xmlParser.Encode(adt);
            xmlParser.Parse(msg);
        }

        #endregion
    }
}
