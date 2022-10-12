namespace NHapi.Base.NUnit.PreParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::NUnit.Framework;

    using NHapi.Base.PreParser;

    [TestFixture]
    public class Er7Tests
    {
        private const string MESSAGE = "MSH|^~\\&|x|x|x|x|199904140038||ADT^A01||P|2.2\r" +
                                       "PID|||||Smith&Booth&Jones^X^Y\r" +
                                       "NTE|a||one~two~three\r" +
                                       "NTE|b||four\r";

        [TestCase("MSH|")]
        [TestCase("MSH|^")]
        [TestCase("MSH|^~")]
        [TestCase("MSH|^~\\")]
        public void ParseMessage_MessageNotLongEnough_ReturnsFalse(string input)
        {
            // Arrange
            var pathSpecs = Array.Empty<DatumPath>();

            // Act
            var result = Er7.ParseMessage(input, pathSpecs, out _);

            // Assert
            Assert.False(result);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void ParseMessage_MessageIsNullEmptyOrWhiteSpace_ReturnsFalse(string input)
        {
            // Arrange
            var pathSpecs = Array.Empty<DatumPath>();

            // Act
            var result = Er7.ParseMessage(input, pathSpecs, out _);

            // Assert
            Assert.False(result);
        }

        [TestCase("MSH|^~\\&|\rG")]
        [TestCase("MSH|^~\\&|\rGR")]
        public void ParseMessage_MessageSegmentIsTooShort_ArgumentOutOfRangeExceptionIsIgnored(string input)
        {
            // Arrange
            var pathSpecs = Array.Empty<DatumPath>();

            // Act
            var result = Er7.ParseMessage(input, pathSpecs, out _);

            // Assert
            Assert.True(result);
        }

        [TestCase("NTE(0)-1", "a")]
        [TestCase("NTE(1)-1", "b")]
        [TestCase("NTE-3(0)", "one")]
        [TestCase("NTE-3(1)", "two")]
        [TestCase("PID-5", "Smith")]
        [TestCase("PID-5-1-1", "Smith")]
        [TestCase("MSH-9-2", "A01")]
        [TestCase("PID-5-1-2", "Booth")]
        public void ParseMessage_ValidADT_A01Er7_ReturnsExpectedResult(string pathSpec, string expectedValue)
        {
            // Arrange
            var pathSpecs = new List<DatumPath> { pathSpec.FromPathSpec() };

            // Act
            var parsed = Er7.ParseMessage(MESSAGE, pathSpecs, out var results);
            var actualResults = results.Select(r => r.Value).ToArray();

            // Assert
            Assert.True(parsed);
            Assert.Contains(expectedValue, actualResults);
        }
    }
}