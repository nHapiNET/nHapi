namespace NHapi.Base.NUnit
{
    using System;

    using global::NUnit.Framework;

    [TestFixture]
    public class ErrorCodeExtensionsTests
    {
        #region ToErrorCode

        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(20)]
        public void ToErrorCode_InvalidInput_ThrowsArgumentOutOfRangeException(int sut)
        {
#if NETCOREAPP
            var expectedMessage = "The integer provided is not a valid ErrorCode value (Parameter 'errorCode')";
#elif NETFRAMEWORK
            var expectedMessage =
                $"The integer provided is not a valid ErrorCode value{Environment.NewLine}Parameter name: errorCode";
#endif
            Assert.That(
                () => sut.ToErrorCode(),
                Throws.TypeOf<ArgumentOutOfRangeException>()
                    .With.Message.EqualTo(expectedMessage)
                    .And.Property("ParamName").EqualTo("errorCode"));
        }

        [TestCase(0, ErrorCode.MESSAGE_ACCEPTED)]
        [TestCase(100, ErrorCode.SEGMENT_SEQUENCE_ERROR)]
        [TestCase(200, ErrorCode.UNSUPPORTED_MESSAGE_TYPE)]
        public void ToErrorCode_ValidInput_ReturnsExpectedErrorCode(int sut, ErrorCode expected)
        {
            // Arrange / Action
            var actual = sut.ToErrorCode();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        #endregion

        #region GetCode

        [TestCase(ErrorCode.MESSAGE_ACCEPTED, 0)]
        [TestCase(ErrorCode.SEGMENT_SEQUENCE_ERROR, 100)]
        [TestCase(ErrorCode.UNSUPPORTED_MESSAGE_TYPE, 200)]
        public void GetCode_ReturnsErrorCodeAsInt(ErrorCode sut, int expected)
        {
            // Arrange / Action
            var actual = sut.GetCode();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        #endregion

        #region GetName

        [TestCase(ErrorCode.MESSAGE_ACCEPTED, "Message accepted")]
        [TestCase(ErrorCode.SEGMENT_SEQUENCE_ERROR, "Segment sequence error")]
        [TestCase(ErrorCode.UNSUPPORTED_MESSAGE_TYPE, "Unsupported message type")]
        public void GetName_ReturnsErrorCodeDescription(ErrorCode sut, string expected)
        {
            // Arrange / Action
            var actual = sut.GetName();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        #endregion
    }
}