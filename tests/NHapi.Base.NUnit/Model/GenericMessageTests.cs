namespace NHapi.Base.NUnit.Model
{
    using System;

    using global::NUnit.Framework;

    using NHapi.Base.Model;

    [TestFixture]
    public class GenericMessageTests
    {
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
        public void GetGenericMessageClass_ValidVersion_ReturnsExpectedGenericMessageType(string version, Type expected)
        {
            // Arrange / Act
            var genericMessageType = GenericMessage.GetGenericMessageClass(version);

            // Assert
            Assert.AreEqual(expected, genericMessageType);
        }

        [Test]
        public void GetGenericMessageClass_InValidVersion_ThrowsArgumentException()
        {
            // Arrange / Act / Assert
            Assert.Throws<ArgumentException>(
                () => GenericMessage.GetGenericMessageClass("unknown"));
        }
    }
}
