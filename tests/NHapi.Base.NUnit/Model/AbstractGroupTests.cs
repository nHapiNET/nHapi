namespace NHapi.Base.NUnit.Model
{
    using global::NUnit.Framework;

    using NHapi.Base.Model;
    using NHapi.Base.Parser;
    using NHapi.Model.V24.Message;
    using NHapi.Model.V24.Segment;

    [TestFixture]
    public class AbstractGroupTests
    {
        [Test]
        public void AddNonstandardSegment_WithKnownType_AllowsReturnOfSegment()
        {
            // Arrange
            var segmentToTest = "ARQ";
            var expectedSegmentType = typeof(ARQ);
            var message = new ADT_A01();

            // Act
            message.AddNonstandardSegment(segmentToTest);
            message.GetStructure(segmentToTest, 0);
            var result = message.GetStructure(segmentToTest, 1);

            // Assert
            Assert.That(result.GetType(), Is.EqualTo(expectedSegmentType));
        }

        [Test]
        public void AddNonstandardSegment_WithUnknownType_AllowsReturnOfSegment()
        {
            // Arrange
            var segmentToTest = "ZZZ";
            var expectedSegmentType = typeof(GenericSegment);
            var message = new ADT_A01();

            // Act
            message.AddNonstandardSegment(segmentToTest);
            var result = message.GetStructure(segmentToTest);

            // Assert
            Assert.That(result.GetType(), Is.EqualTo(expectedSegmentType));
        }

        [Test]
        [Ignore("Cant test this properly since NHapi doesn't yet support adding repetitions at specific locations")]
        public void TestInsertNewRepetition()
        {
            // Arrange
            var input = "MSH|^~\\&|ULTRA|TML|OLIS|OLIS|200905011130||ORU^R01|20169838|T|2.5\r"
                            + "PID|||7005728^^^TML^MR||TEST^RACHEL^DIAMOND||19310313|F|||200 ANYWHERE ST^^TORONTO^ON^M6G 2T9||(416)888-8888||||||1014071185^KR\r"
                            + "PV1|1||OLIS||||OLIST^BLAKE^DONALD^THOR^^^^^921379^^^^OLIST\r"
                            + "ORC|RE||T09-100442-RET-0^^OLIS_Site_ID^ISO|||||||||OLIST^BLAKE^DONALD^THOR^^^^L^921379\r"
                            + "OBR|0||T09-100442-RET-0^^OLIS_Site_ID^ISO|RET^RETICULOCYTE COUNT^HL79901 literal|||200905011106|||||||200905011106||OLIST^BLAKE^DONALD^THOR^^^^L^921379||7870279|7870279|T09-100442|MOHLTC|200905011130||B7|F||1^^^200905011106^^R\r"
                            + "OBX|1\r"
                            + "OBX|3\r"
                            + "OBX|4\r";

            var expected = "MSH|^~\\&|ULTRA|TML|OLIS|OLIS|200905011130||ORU^R01|20169838|T|2.5\r"
                           + "PID|||7005728^^^TML^MR||TEST^RACHEL^DIAMOND||19310313|F|||200 ANYWHERE ST^^TORONTO^ON^M6G 2T9||(416)888-8888||||||1014071185^KR\r"
                           + "PV1|1||OLIS||||OLIST^BLAKE^DONALD^THOR^^^^^921379^^^^OLIST\r"
                           + "ORC|RE||T09-100442-RET-0^^OLIS_Site_ID^ISO|||||||||OLIST^BLAKE^DONALD^THOR^^^^L^921379\r"
                           + "OBR|0||T09-100442-RET-0^^OLIS_Site_ID^ISO|RET^RETICULOCYTE COUNT^HL79901 literal|||200905011106|||||||200905011106||OLIST^BLAKE^DONALD^THOR^^^^L^921379||7870279|7870279|T09-100442|MOHLTC|200905011130||B7|F||1^^^200905011106^^R\r"
                           + "OBX|1\r"
                           + "OBX|2\r"
                           + "OBX|3\r"
                           + "OBX|4\r";

            var oruR01 = new ORU_R01();
            var parser = new PipeParser();

            parser.Parse(oruR01, input);

            // Action
            var newGroup = oruR01.GetPATIENT_RESULT().GetORDER_OBSERVATION().AddOBSERVATION();
            newGroup.OBX.SetIDOBX.Value = "2";

            var result = parser.Encode(oruR01);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestRemoveRepetition()
        {
            // Arrange
            var input = "MSH|^~\\&|ULTRA|TML|OLIS|OLIS|200905011130||ORU^R01|20169838|T|2.5\r"
                        + "PID|||7005728^^^TML^MR||TEST^RACHEL^DIAMOND||19310313|F|||200 ANYWHERE ST^^TORONTO^ON^M6G 2T9||(416)888-8888||||||1014071185^KR\r"
                        + "PV1|1||OLIS||||OLIST^BLAKE^DONALD^THOR^^^^^921379^^^^OLIST\r"
                        + "ORC|RE||T09-100442-RET-0^^OLIS_Site_ID^ISO|||||||||OLIST^BLAKE^DONALD^THOR^^^^L^921379\r"
                        + "OBR|0||T09-100442-RET-0^^OLIS_Site_ID^ISO|RET^RETICULOCYTE COUNT^HL79901 literal|||200905011106|||||||200905011106||OLIST^BLAKE^DONALD^THOR^^^^L^921379||7870279|7870279|T09-100442|MOHLTC|200905011130||B7|F||1^^^200905011106^^R\r"
                        + "OBX|1\r"
                        + "OBX|2\r"
                        + "OBX|3\r";

            var expected = "MSH|^~\\&|ULTRA|TML|OLIS|OLIS|200905011130||ORU^R01|20169838|T|2.5\r"
                       + "PID|||7005728^^^TML^MR||TEST^RACHEL^DIAMOND||19310313|F|||200 ANYWHERE ST^^TORONTO^ON^M6G 2T9||(416)888-8888||||||1014071185^KR\r"
                       + "PV1|1||OLIS||||OLIST^BLAKE^DONALD^THOR^^^^^921379^^^^OLIST\r"
                       + "ORC|RE||T09-100442-RET-0^^OLIS_Site_ID^ISO|||||||||OLIST^BLAKE^DONALD^THOR^^^^L^921379\r"
                       + "OBR|0||T09-100442-RET-0^^OLIS_Site_ID^ISO|RET^RETICULOCYTE COUNT^HL79901 literal|||200905011106|||||||200905011106||OLIST^BLAKE^DONALD^THOR^^^^L^921379||7870279|7870279|T09-100442|MOHLTC|200905011130||B7|F||1^^^200905011106^^R\r"
                       + "OBX|1\r"
                       + "OBX|3\r";

            var oruR01 = new ORU_R01();
            var parser = new PipeParser();

            parser.Parse(oruR01, input);

            // Action
            var obx = oruR01.GetPATIENT_RESULT().GetORDER_OBSERVATION().GetOBSERVATION(1);
            oruR01.GetPATIENT_RESULT().GetORDER_OBSERVATION().RemoveOBSERVATIONAt(1);

            var result = parser.Encode(oruR01);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(PipeParser.Encode(obx.OBX, EncodingCharacters.FromMessage(oruR01)), Is.EqualTo("OBX|2"));
                Assert.That(result, Is.EqualTo(expected));
            });
        }
    }
}
