namespace NHapi.Base.NUnit
{
    using System;

    using global::NUnit.Framework;

    using NHapi.Base;

    [TestFixture]
    public class SupportClassTests
    {
        [TestCase("^~\\&")]
        [TestCase("@#&^")]
        [TestCase("1234")]
        [TestCase("qwer")]
        [TestCase("abcd")]
        [TestCase("efgh")]
        [TestCase("!\"£$")]
        public void CharsAreUnique_InputCharsAreUnique_ReturnsTrue(string input)
        {
            // Arrange / Act
            var actual = SupportClass.CharsAreUnique(input);

            // Assert
            Assert.That(actual, Is.True);
        }

        [TestCase("^^^^")]
        [TestCase("~~~~")]
        [TestCase("^~\\\\")]
        [TestCase("^\\&&")]
        [TestCase("0000")]
        [TestCase("@#$$")]
        [TestCase("****")]
        public void CharsAreUnique_InputCharsAreNotUnique_ReturnsFalse(string input)
        {
            // Arrange / Act
            var actual = SupportClass.CharsAreUnique(input);

            // Assert
            Assert.That(actual, Is.False);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CharsAreUnique_InputIsNullOrEmpty_ThrowsArgumentException(string input)
        {
            // Arrange / Act / Assert
            Assert.That(
                () => SupportClass.CharsAreUnique(input),
                Throws.ArgumentException);
        }
    }
}