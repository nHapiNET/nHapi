namespace NHapi.NUnit.Parser
{
    using global::NUnit.Framework;
    using NHapi.Base.Parser;

    public class CarriageReturnHexadecimalTests
    {
        [TestCase(CarriageReturnHexadecimal.X0D, "X0D")]
        [TestCase(CarriageReturnHexadecimal.X00D, "X00D")]
        [TestCase(CarriageReturnHexadecimal.X000d, "X000d")]
        public void WhenEnumConvertedToString_IsExpectedValue(CarriageReturnHexadecimal sut, string expected)
        {
            // Arrange
            // Act
            // Assert
            Assert.That($"{sut}", Is.EqualTo(expected));
        }
    }
}