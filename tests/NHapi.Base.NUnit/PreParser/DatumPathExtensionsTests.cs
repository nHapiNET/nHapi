namespace NHapi.Base.NUnit.PreParser
{
    using System;

    using global::NUnit.Framework;

    using NHapi.Base.PreParser;

    [TestFixture]
    public class DatumPathExtensionsTests
    {
        [TestCaseSource(nameof(startsWithTestCases))]
        public void StartsWith_ValidInput_ReturnsExpectedResult(DatumPath inputA, DatumPath inputB, bool expected)
        {
            // Arrange / Act / Assert
            Assert.That(inputA.StartsWith(inputB), Is.EqualTo(expected));
        }

        [Test]
        public void StartsWith_InputIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var other = new DatumPath().Add("ZXY").Add(1).Add(2);

            // Act / Assert
            Assert.That(
                () => ((DatumPath)null).StartsWith(other),
                Throws.ArgumentNullException);
        }

        [Test]
        public void NumbersLessThan_InputIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var other = new DatumPath().Add("ZXY").Add(1).Add(2);

            // Act / Assert
            Assert.That(
                () => ((DatumPath)null).NumbersLessThan(other),
                Throws.ArgumentNullException);
        }

        [TestCaseSource(nameof(numbersLessThanTestCases))]
        public void NumbersLessThan_ValidInput_ReturnsExpectedResult(DatumPath inputA, DatumPath inputB, bool expected)
        {
            // Arrange / Act / Assert
            Assert.That(inputA.NumbersLessThan(inputB), Is.EqualTo(expected), $"{inputA} !< {inputB}");
        }

        [Test]
        public void FromPathSpec_PathIsNull_ThrowsArgumentNullException()
        {
            // Arrange / Act / Assert
            Assert.That(
                () => (null as string).FromPathSpec(),
                Throws.ArgumentNullException);
        }

        [TestCase("not-a-valid-path")]
        [TestCase("MSHY-0-0")]
        [TestCase("PID-1-1-1-1-1")]
        [TestCase("54CC83C2-2FAE-4B5E-A325-AF29596A9E94")]
        [TestCase("db9aabf8-bed1-4303-956f-683c0e895854")]
        public void FromPathSpec_InValidPath_ThrowsArgumentException(string input)
        {
            // Arrange / Act / Assert
            Assert.That(() => input.FromPathSpec(), Throws.ArgumentException);
        }

        [TestCaseSource(nameof(fromPathSpecTestCases))]
        public void FromPathSpec_ValidPath_ReturnsExpectedDatumPath(string input, DatumPath expected)
        {
            // Arrange / Act
            var actual = input.FromPathSpec();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

#pragma warning disable SA1313
        [TestCaseSource(nameof(fromPathSpecTestCases))]
        public void FromPathSpec_FromPathSpecOriginal_AreEqual(string input, DatumPath _)
        {
            // Arrange / Act
            var actual = input.FromPathSpec();
            var expected = input.FromPathSpecOriginal();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
#pragma warning restore SA1313
#pragma warning disable SA1201

        private static object[] fromPathSpecTestCases =
        {
            new object[]
            {
                "MSH-9-1",
                new DatumPath().Add("MSH").Add(0).Add(9).Add(0).Add(1).Add(1),
            },
            new object[]
            {
                "MSH-9(0)-1",
                new DatumPath().Add("MSH").Add(0).Add(9).Add(0).Add(1).Add(1),
            },
            new object[]
            {
                "PID-5-1-1",
                new DatumPath().Add("PID").Add(0).Add(5).Add(0).Add(1).Add(1),
            },
            new object[]
            {
                "NTE(0)-1-1",
                new DatumPath().Add("NTE").Add(0).Add(1).Add(0).Add(1).Add(1),
            },
            new object[]
            {
                "NTE(0)-1(2)-3-234",
                new DatumPath().Add("NTE").Add(0).Add(1).Add(2).Add(3).Add(234),
            },
        };

        private static object[] startsWithTestCases =
        {
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(1).Add(1),
                new DatumPath().Add("ZXY").Add(1).Add(1), true,
            },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(2).Add(1).Add(1),
                new DatumPath().Add("ZXY").Add(1).Add(2).Add(1), true,
            },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(3).Add(5).Add(5),
                new DatumPath().Add("ZXY").Add(1).Add(3),
                true,
            },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(1),
                new DatumPath().Add("ZXY").Add(1).Add(1),
                true,
            },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(1).Add(2),
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(1).Add(1), false,
            },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(2).Add(1).Add(2),
                new DatumPath().Add("ZXY").Add(1).Add(3), false,
            },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(2),
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(5).Add(5),
                false,
            },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(5).Add(5),
                new DatumPath().Add("ZXY").Add(1).Add(2),
                false,
            },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(5).Add(5),
                null,
                false,
            },
        };

        private static object[] numbersLessThanTestCases =
        {
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(1).Add(1),
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(1).Add(2), true,
            },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(2).Add(1).Add(1),
                new DatumPath().Add("ZXY").Add(1).Add(2).Add(1).Add(2), true,
            },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(5).Add(5),
                new DatumPath().Add("ZXY").Add(1).Add(2),
                true,
            },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(1),
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(5).Add(5),
                true,
            },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(1).Add(2),
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(1).Add(1), false,
            },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(2).Add(1).Add(2),
                new DatumPath().Add("ZXY").Add(1).Add(2).Add(1).Add(1), false,
            },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(2),
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(5).Add(5),
                false,
            },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(5).Add(5),
                new DatumPath().Add("ZXY").Add(1).Add(1),
                false,
            },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(5).Add(5),
                null,
                false,
            },
        };
#pragma warning restore SA1201
    }
}