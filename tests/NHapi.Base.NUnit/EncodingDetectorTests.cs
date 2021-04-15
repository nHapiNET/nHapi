namespace NHapi.Base.NUnit
{
    using System;

    using global::NUnit.Framework;

    using NHapi.Base.Parser;

    [TestFixture]
    public class EncodingDetectorTests
    {
        [TestCase("asd")]
        [TestCase("DoesNotStartWithMsh")]
        public void AssertEr7Encoded_InvalidInput_ThrowsArgumentException(string input)
        {
            // Arrange / Act / Assert
            Assert.Throws<ArgumentException>(
                () => EncodingDetector.AssertEr7Encoded(input));
        }

        [Test]
        public void AssertEr7Encoded_4thCharacterOfgivenSegmentNotDelimiter_ThrowsInvalidOperationException()
        {
            // Arrange
            var input = "MSH|^~\\&||\rUNKNOWN|";

            // Act / Assert
            Assert.Throws<InvalidOperationException>(
                () => EncodingDetector.AssertEr7Encoded(input));
        }

        [Test]
        public void AssertEr7Encoded_ValidInput_NoExceptionThrown()
        {
            // Arrange
            var input = "MSH|^~\\&|LABGL1||DMCRES||19951002185200||ADT^A01|LABGL1199510021852632|P|2.2\r"
                        + "PID|||T12345||TEST^PATIENT^P||19601002|M||||||||||123456\r"
                        + "PV1|||NER|||||||GSU||||||||E||||||||||||||||||||||||||19951002174900|19951006\r";

            // Act / Assert
            Assert.DoesNotThrow(
                () => EncodingDetector.AssertEr7Encoded(input));
        }

        [TestCase("asd")]
        [TestCase("Anything")]
        [TestCase("asdsadsdasadasdasd")]
        [TestCase("MSH")]
        [TestCase("MSH|")]
        public void AssertXmlEncoded_InValidInput_ThrowsArgumentException(string input)
        {
            // Arrange / Act / Assert
            Assert.Throws<ArgumentException>(
                () => EncodingDetector.AssertXmlEncoded(input));
        }

        [Test]
        public void AssertXmlEncoded_ValidInput_NoExceptionThrown()
        {
            // Arrange
            var input = "MSH.1>MSH.2>";

            // Arrange / Act / Assert
            Assert.DoesNotThrow(
                () => EncodingDetector.AssertXmlEncoded(input));
        }

        [TestCase("asd")]
        [TestCase("DoesNotStartWithMsh")]
        public void IsEr7Encoded_InvalidInput_ReturnsFalse(string input)
        {
            // Arrange / Act / Assert
            Assert.IsFalse(EncodingDetector.IsEr7Encoded(input));
        }

        [Test]
        public void IsEr7Encoded_InvalidInput_ReturnsTrue()
        {
            // Arrange
            var input = "MSH|^~\\&|LABGL1||DMCRES||19951002185200||ADT^A01|LABGL1199510021852632|P|2.2\r"
                        + "PID|||T12345||TEST^PATIENT^P||19601002|M||||||||||123456\r"
                        + "PV1|||NER|||||||GSU||||||||E||||||||||||||||||||||||||19951002174900|19951006\r";

            // Act / Assert
            Assert.IsTrue(EncodingDetector.IsEr7Encoded(input));
        }

        [TestCase("asd")]
        [TestCase("Anything")]
        [TestCase("asdsadsdasadasdasd")]
        [TestCase("MSH")]
        [TestCase("MSH|")]
        public void IsXmlEncoded_InvalidInput_ReturnsFalse(string input)
        {
            // Arrange / Act / Assert
            Assert.IsFalse(EncodingDetector.IsXmlEncoded(input));
        }

        [Test]
        public void IsXmlEncoded_ValidInput_ReturnsTrue()
        {
            // Arrange
            var input = "MSH.1>MSH.2>";

            // Act / Assert
            Assert.IsTrue(EncodingDetector.IsXmlEncoded(input));
        }
    }
}
