namespace NHapi.NUnit.Util
{
    using System.IO;

    using global::NUnit.Framework;

    using NHapi.Base.Model;
    using NHapi.Base.Parser;
    using NHapi.Base.Util;
    using NHapi.Model.V24.Message;
    using NHapi.Model.V26.Group;
    using NHapi.Model.V26.Segment;

    using ORU_R01 = NHapi.Model.V26.Message.ORU_R01;
    using ROL = NHapi.Model.V24.Segment.ROL;

    [TestFixture]
    public class SegmentFinderTests
    {
        [Test]
        public void FindSegment_ReturnsExpectedValue()
        {
            // Arrange
            var message = new ADT_A01();
            message.GetROL().ActionCode.Value = "a";
            message.GetROL2().ActionCode.Value = "b";
            message.GetPROCEDURE().GetROL().ActionCode.Value = "c";
            message.GetINSURANCE().GetROL().ActionCode.Value = "d";

            var finder = new SegmentFinder(message);

            // Act
            var first = ((ROL)finder.FindSegment("ROL", 0)).ActionCode.Value;
            var second = ((ROL)finder.FindSegment("ROL", 0)).ActionCode.Value;
            var third = ((ROL)finder.FindSegment("ROL", 0)).ActionCode.Value;
            var fourth = ((ROL)finder.FindSegment("ROL", 0)).ActionCode.Value;

            // Assert
            Assert.AreEqual("a", first);
            Assert.AreEqual("b", second);
            Assert.AreEqual("c", third);
            Assert.AreEqual("d", fourth);
        }

        [Test]
        public void GetSegment_ReturnExpectedValue()
        {
            // Arrange
            var r01 = new ORU_R01();
            r01.MSH.MessageType.MessageStructure.Value = "ORU";
            r01.MSH.MessageType.TriggerEvent.Value = "R01";
            r01.MSH.FieldSeparator.Value = "|";
            r01.MSH.EncodingCharacters.Value = @"^~\&";
            r01.MSH.VersionID.VersionID.Value = "2.4";
            r01.MSH.ProcessingID.ProcessingID.Value = "T";

            r01.GetSFT(0).SoftwareVendorOrganization.OrganizationName.Value = "A";
            r01.GetSFT(1).SoftwareVendorOrganization.OrganizationName.Value = "B";
            r01.GetSFT(2).SoftwareVendorOrganization.OrganizationName.Value = "C";

            var encodingCharacters = EncodingCharacters.FromMessage(r01);

            var finder = new SegmentFinder(r01);

            // Act
            var sft1 = (SFT)finder.GetSegment("SFT", 0);
            var sft2 = (SFT)finder.GetSegment("SFT", 1);
            var sft3 = (SFT)finder.GetSegment("SFT", 2);

            // Assert
            Assert.AreEqual("A", PipeParser.Encode(sft1.SoftwareVendorOrganization, encodingCharacters));
            Assert.AreEqual("B", PipeParser.Encode(sft2.SoftwareVendorOrganization, encodingCharacters));
            Assert.AreEqual("C", PipeParser.Encode(sft3.SoftwareVendorOrganization, encodingCharacters));
        }

        [Test]
        public void FindGroup_ReturnsExpectedValue()
        {
            // Arrange
            var r01 = new ORU_R01();
            r01.MSH.MessageType.MessageStructure.Value = "ORU";
            r01.MSH.MessageType.TriggerEvent.Value = "R01";
            r01.MSH.FieldSeparator.Value = "|";
            r01.MSH.EncodingCharacters.Value = @"^~\&";
            r01.MSH.VersionID.VersionID.Value = "2.4";
            r01.MSH.ProcessingID.ProcessingID.Value = "T";

            r01.GetPATIENT_RESULT().PATIENT.PID.SetIDPID.Value = "1";
            r01.GetPATIENT_RESULT().GetORDER_OBSERVATION(0).OBR.SetIDOBR.Value = "2";
            r01.GetPATIENT_RESULT().GetORDER_OBSERVATION(1).OBR.SetIDOBR.Value = "3";
            r01.GetPATIENT_RESULT().GetORDER_OBSERVATION(2).OBR.SetIDOBR.Value = "4";

            var encodingCharacters = EncodingCharacters.FromMessage(r01);

            var finder = new SegmentFinder(r01);

            // Act
            var pid = (PID)finder.FindSegment("PID", 0);
            finder = new SegmentFinder(r01);
            var patient = (ORU_R01_PATIENT)finder.FindGroup("PATIENT", 0);

            var orderObservation = (ORU_R01_ORDER_OBSERVATION)finder.FindGroup("ORDER_OBSERVATION", 0);

            // Assert
            Assert.AreEqual("1", PipeParser.Encode(pid.SetIDPID, encodingCharacters));
            Assert.AreEqual("1", PipeParser.Encode(patient.PID.SetIDPID, encodingCharacters));

            Assert.AreEqual("2", PipeParser.Encode(orderObservation.OBR.SetIDOBR, encodingCharacters));
        }

        [Test]
        public void TestPID1()
        {
            // Arrange
            var message = LoadMessage();
            var finder = new SegmentFinder(message);

            // Act
            var segment = finder.FindSegment("PID", 0);

            // Assert
            Assert.AreEqual("1", ((IPrimitive)segment.GetField(1, 0)).Value);
        }

        [Test]
        public void TestPID2()
        {
            // Arrange
            var message = LoadMessage();
            var finder = new SegmentFinder(message);

            // Act
            var segment = finder.FindSegment("PID2", 0);

            // Assert
            Assert.AreEqual("2", ((IPrimitive)segment.GetField(1, 0)).Value);
        }

        private static IMessage LoadMessage()
        {
            var parser = new PipeParser();
            var testDataDir = $"{TestContext.CurrentContext.TestDirectory}/TestData/Util/";
            var messageString = File.ReadAllText($"{testDataDir}/segmentfinder_a24.hl7");
            return parser.Parse(messageString);
        }
    }
}