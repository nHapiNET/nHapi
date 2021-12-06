namespace NHapi.NUnit.Parser
{
    using System.IO;
    using System.Threading.Tasks;

    using global::NUnit.Framework;

    using NHapi.Base.Parser;
    using NHapi.Base.Validation.Implementation;
    using NHapi.Model.V23.Datatype;
    using NHapi.Model.V23.Message;

    [TestFixture]
    public class EscapeTests
    {
        private readonly EncodingCharacters encodingCharacters = new EncodingCharacters('|', null);

        #region EscapeText

        [TestCase("|", "\\F\\")]
        [TestCase("~", "\\R\\")]
        [TestCase("^", "\\S\\")]
        [TestCase("&", "\\T\\")]
        [TestCase("\\", "\\E\\")]
        [TestCase("\n", "\\X0A\\")]
        [TestCase("\r", "\\X0D\\")]
        public void EscapeText_InputIsEscapable_ReturnsEscapedValue(string input, string expected)
        {
            // Arrange
            // Act
            var actual = Escape.EscapeText(input, encodingCharacters);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EscapeText_ValidEscapableInput_ReturnsExpectedResult()
        {
            // Arrange
            var input = "GLUCOSE^1H POST 75 G GLUCOSE PO:SCNC:PT:SER/PLAS:QN";
            var expected = "GLUCOSE\\S\\1H POST 75 G GLUCOSE PO:SCNC:PT:SER/PLAS:QN";

            // Act
            var actual = Escape.EscapeText(input, encodingCharacters);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EscapeText_TruncatableInput_ReturnsUntruncatedResult()
        {
            // Arrange
            var input = "Truncation#escape";
            var expected = "Truncation#escape";

            // Act
            var actual = Escape.EscapeText(input, encodingCharacters);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Repeat(1000)]
        [TestCase("|", "\\F\\")]
        [TestCase("~", "\\R\\")]
        [TestCase("^", "\\S\\")]
        [TestCase("&", "\\T\\")]
        [TestCase("\\", "\\E\\")]
        [TestCase("\n", "\\X0A\\")]
        [TestCase("\r", "\\X0D\\")]
        public void EscapeText_InputIsEscapable_ReturnsEscapedValue_Concurrent(string input, string expected)
        {
            // Arrange
            string actual;

            Parallel.For(0, 100, iteration =>
            {
                // Act
                actual = Escape.EscapeText(input, encodingCharacters);

                // Assert
                Assert.AreEqual(expected, actual);
            });
        }

        #endregion

        #region UnescapeText

        [TestCase("Parker \\T\\ Sons", "Parker & Sons")]
        [TestCase("XR CHEST PA\\T\\LAT", "XR CHEST PA&LAT")]
        public void UnescapeText_WithValidInput_ReturnsUnescapedValue(string input, string expected)
        {
            // Arrange
            // Action
            var actual = Escape.UnescapeText(input, encodingCharacters);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("\\F\\", "|")]
        [TestCase("\\R\\", "~")]
        [TestCase("\\S\\", "^")]
        [TestCase("\\T\\", "&")]
        [TestCase("\\E\\", "\\")]
        [TestCase("\\X0A\\", "\n")]
        [TestCase("\\X0D\\", "\r")]
        public void UnescapeText_InputIsUnescapable_ReturnsUnescapedValue(string input, string expected)
        {
            // Arrange
            // Act
            var actual = Escape.UnescapeText(input, encodingCharacters);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Repeat(1000)]
        [TestCase("\\F\\", "|")]
        [TestCase("\\R\\", "~")]
        [TestCase("\\S\\", "^")]
        [TestCase("\\T\\", "&")]
        [TestCase("\\E\\", "\\")]
        [TestCase("\\X0A\\", "\n")]
        [TestCase("\\X0D\\", "\r")]
        public void UnescapeText_InputIsUnescapable_ReturnsUnescapedValue_Concurrent(string input, string expected)
        {
            string actual;

            Parallel.For(0, 100, iteration =>
            {
                // Arrange
                // Act
                actual = Escape.UnescapeText(input, encodingCharacters);

                // Assert
                Assert.AreEqual(expected, actual);
            });
        }

        [Test]
        public void UnescapeText_StringAlreadyEscaped_ReturnsStringUnescaped()
        {
            // Arrange
            var testDataDir = $"{TestContext.CurrentContext.TestDirectory}/TestData/Parser";
            var uuenEncodedEscapeString = File.ReadAllText($"{testDataDir}/uuencoded_escaped.txt");
            var expected = File.ReadAllText($"{testDataDir}/uuencoded_unescaped.txt");

            // Action
            // Assert
            var actual = Escape.UnescapeText(uuenEncodedEscapeString, encodingCharacters);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region IntegrationTests, some copied from Hapi

        [Test]
        public void WhenMessageParsedAndEscaped_ThenEncodedAndUnescaped_MessageIsIdentical()
        {
            // Arrange
            var expected
                = "MSH|^~\\&|ULTRA|TML|OLIS|OLIS|200911231509||ORU^R01|5951|T|2.3\r" +
                      "PID|||7005728^^^TML^MR||LEIGHTON^RACHEL^DIAMOND||19310313|F|||200 ANYWHERE ST^^TORONTO^ON^M6H 2T9||(416)888-8888||||||1014071185^KR\r" +
                      "PV1|1||OLIS||||OLIST^BLAKE^DONALD^THOR^^^^^921379^^^^OLIST|||||||||^N\r" +
                      "ORC|RE||T09-106575-CHO-0^^OLIS_Site_ID^ISO|||||||||OLIST^BLAKE^DONALD^THOR^^^^L^921379\r" +
                      "OBR|0||T09-106575-CHO-0^^OLIS_Site_ID^ISO|CHO^CHOLESTEROL (SERUM)^HL79901 literal|||200911231455|||||||200911231455||OLIST^BLAKE^DONALD^THOR^^^^L^921379||10015716|10015716|T09-106575|MOHLTC|200911231509||B1|F||1^^^200911231455^^R\r" +
                      "NTE|1|L|\\.br\\                  Lipid - Target Levels for Treatment \\.br\\\\.br\\  ****************************************************************\\.br\\  \\F\\  Risk   \\F\\                  \\F\\                                 \\F\\\\.br\\  \\F\\ Level   \\F\\ 10-year CAD risk \\F\\         Recommendations         \\F\\\\.br\\  \\F\\---------\\F\\------------------\\F\\---------------------------------\\F\\\\.br\\  \\F\\         \\F\\                  \\F\\Treatment targets:               \\F\\\\.br\\  \\F\\High*    \\F\\      >=20%       \\F\\ Primary:   LDL-C    <2.0 mmol/L \\F\\\\.br\\  \\F\\         \\F\\                  \\F\\ Secondary: TC/HDL-C <4.0        \\F\\\\.br\\  \\F\\---------\\F\\------------------\\F\\---------------------------------\\F\\\\.br\\  \\F\\         \\F\\                  \\F\\Treat when:                      \\F\\\\.br\\  \\F\\Moderate \\F\\    10 - 19 %     \\F\\            LDL-C    >=3.5 mmol/L\\F\\\\.br\\  \\F\\         \\F\\                  \\F\\         or TC/HDL-C >=5.0       \\F\\\\.br\\  \\F\\---------\\F\\------------------\\F\\---------------------------------\\F\\\\.br\\  \\F\\         \\F\\                  \\F\\Treat when:                      \\F\\\\.br\\  \\F\\Low      \\F\\      <10%        \\F\\            LDL-C    >=5.0 mmol/L\\F\\\\.br\\  \\F\\         \\F\\                  \\F\\         or TC/HDL-C >=6.0       \\F\\\\.br\\****************************************************************\\.br\\  Notes:\\.br\\  *  10-year coronary artery disease (CAD) risk is accessed by\\.br\\     Framingham risk estimate tables.\\.br\\  *  *High risk includes CAD, peripheral artery disease, cerebro-\\.br\\     vascular disease (CVD) and most patients with chronic kidney\\.br\\     disease or established diabetes mellitus.\\.br\\  *  The patient must have been fasting for at least 12 hours prior\\.br\\     to taking ablood sample.\\.br\\  *  Calculation:  LDL-C (mmol/L) = Chol - (HDL-C + 0.46 x TG).\\.br\\     Calculation is invalid if TG exceed 4.5 mmol/L.\\.br\\  Ref:  McPherson R et al. Can J Cardiol. 2006 Sep;22(11):913-27\r" +
                      "OBX|1|NM|Z049107^Cholesterol-serum^L||2.30|mmol/L|||||F|||200911231508|STP\r" +
                      "OBX|2|FT|Z101068^Tech Comment^L||Lab STP||||||F|||200911231508|STP\r";

            var parser = new PipeParser { ValidationContext = new DefaultValidation() };

            // Act
            var oruR01 = (ORU_R01)parser.Parse(expected);
            var actual = parser.Encode(oruR01);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Repeat(100)]
        public void WhenMessageParsedAndEscaped_ThenEncodedAndUnescaped_MessageIsIdentical_Concurrent()
        {
            // Arrange
            var expected
                = "MSH|^~\\&|ULTRA|TML|OLIS|OLIS|200911231509||ORU^R01|5951|T|2.3\r" +
                      "PID|||7005728^^^TML^MR||LEIGHTON^RACHEL^DIAMOND||19310313|F|||200 ANYWHERE ST^^TORONTO^ON^M6H 2T9||(416)888-8888||||||1014071185^KR\r" +
                      "PV1|1||OLIS||||OLIST^BLAKE^DONALD^THOR^^^^^921379^^^^OLIST|||||||||^N\r" +
                      "ORC|RE||T09-106575-CHO-0^^OLIS_Site_ID^ISO|||||||||OLIST^BLAKE^DONALD^THOR^^^^L^921379\r" +
                      "OBR|0||T09-106575-CHO-0^^OLIS_Site_ID^ISO|CHO^CHOLESTEROL (SERUM)^HL79901 literal|||200911231455|||||||200911231455||OLIST^BLAKE^DONALD^THOR^^^^L^921379||10015716|10015716|T09-106575|MOHLTC|200911231509||B1|F||1^^^200911231455^^R\r" +
                      "NTE|1|L|\\.br\\                  Lipid - Target Levels for Treatment \\.br\\\\.br\\  ****************************************************************\\.br\\  \\F\\  Risk   \\F\\                  \\F\\                                 \\F\\\\.br\\  \\F\\ Level   \\F\\ 10-year CAD risk \\F\\         Recommendations         \\F\\\\.br\\  \\F\\---------\\F\\------------------\\F\\---------------------------------\\F\\\\.br\\  \\F\\         \\F\\                  \\F\\Treatment targets:               \\F\\\\.br\\  \\F\\High*    \\F\\      >=20%       \\F\\ Primary:   LDL-C    <2.0 mmol/L \\F\\\\.br\\  \\F\\         \\F\\                  \\F\\ Secondary: TC/HDL-C <4.0        \\F\\\\.br\\  \\F\\---------\\F\\------------------\\F\\---------------------------------\\F\\\\.br\\  \\F\\         \\F\\                  \\F\\Treat when:                      \\F\\\\.br\\  \\F\\Moderate \\F\\    10 - 19 %     \\F\\            LDL-C    >=3.5 mmol/L\\F\\\\.br\\  \\F\\         \\F\\                  \\F\\         or TC/HDL-C >=5.0       \\F\\\\.br\\  \\F\\---------\\F\\------------------\\F\\---------------------------------\\F\\\\.br\\  \\F\\         \\F\\                  \\F\\Treat when:                      \\F\\\\.br\\  \\F\\Low      \\F\\      <10%        \\F\\            LDL-C    >=5.0 mmol/L\\F\\\\.br\\  \\F\\         \\F\\                  \\F\\         or TC/HDL-C >=6.0       \\F\\\\.br\\****************************************************************\\.br\\  Notes:\\.br\\  *  10-year coronary artery disease (CAD) risk is accessed by\\.br\\     Framingham risk estimate tables.\\.br\\  *  *High risk includes CAD, peripheral artery disease, cerebro-\\.br\\     vascular disease (CVD) and most patients with chronic kidney\\.br\\     disease or established diabetes mellitus.\\.br\\  *  The patient must have been fasting for at least 12 hours prior\\.br\\     to taking ablood sample.\\.br\\  *  Calculation:  LDL-C (mmol/L) = Chol - (HDL-C + 0.46 x TG).\\.br\\     Calculation is invalid if TG exceed 4.5 mmol/L.\\.br\\  Ref:  McPherson R et al. Can J Cardiol. 2006 Sep;22(11):913-27\r" +
                      "OBX|1|NM|Z049107^Cholesterol-serum^L||2.30|mmol/L|||||F|||200911231508|STP\r" +
                      "OBX|2|FT|Z101068^Tech Comment^L||Lab STP||||||F|||200911231508|STP\r";

            var parser = new PipeParser { ValidationContext = new DefaultValidation() };

            ORU_R01 oruR01;
            string actual;

            Parallel.For(0, 10, _ =>
            {
                // Arrange
                // Act
                oruR01 = (ORU_R01)parser.Parse(expected);
                actual = parser.Encode(oruR01);

                // Assert
                Assert.AreEqual(expected, actual);
            });
        }

        [Test]
        public void WhenStringIsEscaped_AndThenUnescaped_InputIsIdenticalToOutput()
        {
            var expected =
                "\\.br\\                  Lipid - Target Levels for Treatment \\.br\\\\.br\\  ****************************************************************\\.br\\  \\F\\  Risk   \\F\\                  \\F\\                                 \\F\\\\.br\\  \\F\\ Level   \\F\\ 10-year CAD risk \\F\\         Recommendations         \\F\\\\.br\\  \\F\\---------\\F\\------------------\\F\\---------------------------------\\F\\\\.br\\  \\F\\         \\F\\                  \\F\\Treatment targets:               \\F\\\\.br\\  \\F\\High*    \\F\\      >=20%       \\F\\ Primary:   LDL-C    <2.0 mmol/L \\F\\\\.br\\  \\F\\         \\F\\                  \\F\\ Secondary: TC/HDL-C <4.0        \\F\\\\.br\\  \\F\\---------\\F\\------------------\\F\\---------------------------------\\F\\\\.br\\  \\F\\         \\F\\                  \\F\\Treat when:                      \\F\\\\.br\\  \\F\\Moderate \\F\\    10 - 19 %     \\F\\            LDL-C    >=3.5 mmol/L\\F\\\\.br\\  \\F\\         \\F\\                  \\F\\         or TC/HDL-C >=5.0       \\F\\\\.br\\  \\F\\---------\\F\\------------------\\F\\---------------------------------\\F\\\\.br\\  \\F\\         \\F\\                  \\F\\Treat when:                      \\F\\\\.br\\  \\F\\Low      \\F\\      <10%        \\F\\            LDL-C    >=5.0 mmol/L\\F\\\\.br\\  \\F\\         \\F\\                  \\F\\         or TC/HDL-C >=6.0       \\F\\\\.br\\****************************************************************\\.br\\  Notes:\\.br\\  *  10-year coronary artery disease (CAD) risk is accessed by\\.br\\     Framingham risk estimate tables.\\.br\\  *  *High risk includes CAD, peripheral artery disease, cerebro-\\.br\\     vascular disease (CVD) and most patients with chronic kidney\\.br\\     disease or established diabetes mellitus.\\.br\\  *  The patient must have been fasting for at least 12 hours prior\\.br\\     to taking ablood sample.\\.br\\  *  Calculation:  LDL-C (mmol/L) = Chol - (HDL-C + 0.46 x TG).\\.br\\     Calculation is invalid if TG exceed 4.5 mmol/L.\\.br\\  Ref:  McPherson R et al. Can J Cardiol. 2006 Sep;22(11):913-27\r";

            var escaped = Escape.EscapeText(expected, encodingCharacters);
            var actual = Escape.UnescapeText(escaped, encodingCharacters);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WhenSegmentParsedAndEscaped_SegmentValueIsEncoded()
        {
            // Arrange
            var oruR01 = new ORU_R01();

            var ft = new FT(oruR01);
            oruR01.GetRESPONSE().GetORDER_OBSERVATION().GetOBSERVATION().OBX.ValueType.Value = "FT";
            oruR01.GetRESPONSE().GetORDER_OBSERVATION().GetOBSERVATION().OBX.GetObservationValue(0).Data = ft;

            ft.Value = "H \\H\\ N \\N\\ ";

            // Act / Assert
            Assert.AreEqual("H \\H\\ N \\N\\ ", ft.Value);
            Assert.AreEqual("H \\H\\ N \\N\\ ", PipeParser.Encode(ft, encodingCharacters));

            ft.Value = "H \\C00FF\\ N";

            Assert.AreEqual("H \\C00FF\\ N", ft.Value);
            Assert.AreEqual("H \\C00FF\\ N", PipeParser.Encode(ft, encodingCharacters));
        }

        #endregion
    }
}
