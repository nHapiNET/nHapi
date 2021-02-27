namespace NHapi.NUnit.Parser
{
    using global::NUnit.Framework;
    using NHapi.Base.Parser;

    public class LineFeedHexadecimalTests
    {
        [TestCase(LineFeedHexadecimal.X0A, "X0A")]
        [TestCase(LineFeedHexadecimal.X00A, "X00A")]
        [TestCase(LineFeedHexadecimal.X000a, "X000a")]
        public void WhenEnumConvertedToString_IsExpectedValue(LineFeedHexadecimal sut, string expected)
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(expected, $"{sut}");
        }
    }
}