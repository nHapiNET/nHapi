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
            Assert.That(
                () => EncodingDetector.AssertEr7Encoded(input),
                Throws.ArgumentException);
        }

        [Test]
        public void AssertEr7Encoded_4thCharacterOfgivenSegmentNotDelimiter_ThrowsInvalidOperationException()
        {
            // Arrange
            var input = "MSH|^~\\&||\rUNKNOWN|";

            // Act / Assert
            Assert.That(
                () => EncodingDetector.AssertEr7Encoded(input),
                Throws.InvalidOperationException);
        }

        [Test]
        public void AssertEr7Encoded_ValidInput_NoExceptionThrown()
        {
            // Arrange
            var input = "MSH|^~\\&|LABGL1||DMCRES||19951002185200||ADT^A01|LABGL1199510021852632|P|2.2\r"
                        + "PID|||T12345||TEST^PATIENT^P||19601002|M||||||||||123456\r"
                        + "PV1|||NER|||||||GSU||||||||E||||||||||||||||||||||||||19951002174900|19951006\r";

            // Act / Assert
            Assert.That(
                () => EncodingDetector.AssertEr7Encoded(input),
                Throws.Nothing);
        }

        [TestCase("asd")]
        [TestCase("Anything")]
        [TestCase("asdsadsdasadasdasd")]
        [TestCase("MSH")]
        [TestCase("MSH|")]
        public void AssertXmlEncoded_InValidInput_ThrowsArgumentException(string input)
        {
            // Arrange / Act / Assert
            Assert.That(
                () => EncodingDetector.AssertXmlEncoded(input),
                Throws.ArgumentException);
        }

        [Test]
        public void AssertXmlEncoded_ValidInput_NoExceptionThrown()
        {
            // Arrange
            var input = "MSH.1>MSH.2>";

            // Arrange / Act / Assert
            Assert.That(
                () => EncodingDetector.AssertXmlEncoded(input),
                Throws.Nothing);
        }

        [TestCase("asd")]
        [TestCase("DoesNotStartWithMsh")]
        public void IsEr7Encoded_InvalidInput_ReturnsFalse(string input)
        {
            // Arrange / Act / Assert
            Assert.That(EncodingDetector.IsEr7Encoded(input), Is.False);
        }

        [Test]
        public void IsEr7Encoded_InvalidInput_ReturnsTrue()
        {
            // Arrange
            var input = "MSH|^~\\&|LABGL1||DMCRES||19951002185200||ADT^A01|LABGL1199510021852632|P|2.2\r"
                        + "PID|||T12345||TEST^PATIENT^P||19601002|M||||||||||123456\r"
                        + "PV1|||NER|||||||GSU||||||||E||||||||||||||||||||||||||19951002174900|19951006\r";

            // Act / Assert
            Assert.That(EncodingDetector.IsEr7Encoded(input), Is.True);
        }

        [TestCase("asd")]
        [TestCase("Anything")]
        [TestCase("asdsadsdasadasdasd")]
        [TestCase("MSH")]
        [TestCase("MSH|")]
        public void IsXmlEncoded_InvalidInput_ReturnsFalse(string input)
        {
            // Arrange / Act / Assert
            Assert.That(EncodingDetector.IsXmlEncoded(input), Is.False);
        }

        [Test]
        public void IsXmlEncoded_ValidInput_ReturnsTrue()
        {
            // Arrange
            var input = "MSH.1>MSH.2>";

            // Act / Assert
            Assert.That(EncodingDetector.IsXmlEncoded(input), Is.True);
        }
    }
}