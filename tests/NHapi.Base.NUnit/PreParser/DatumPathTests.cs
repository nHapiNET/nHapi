namespace NHapi.Base.NUnit.PreParser
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using global::NUnit.Framework;

    using NHapi.Base.PreParser;

    [TestFixture]
    public class DatumPathTests
    {
        [TestCase(1)]
        [TestCase(20)]
        [TestCase(6)]
        [TestCase(0)]
        public void Add_Int_SizeIsLessThan1_ThrowsInvalidOperationException(int value)
        {
            // Arrange
            var sut = new DatumPath();

            // Act / Assert
            Assert.Throws<InvalidOperationException>(() => sut.Add(1));
        }

        [Test]
        public void Add_Int_SizeIsEqualTo6_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var sut =
                new DatumPath()
                    .Add("ZXY")
                    .Add(1)
                    .Add(1)
                    .Add(1)
                    .Add(1)
                    .Add(1);

            // Act / Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Add(1));
        }

        [Test]
        public void Add_Int_SizeIsGreaterThen0_AddsValueToPath()
        {
            // Arrange
            var sut =
                new DatumPath()
                    .Add("ZXY");

            // Act / Assert
            Assert.DoesNotThrow(() => sut.Add(1));
        }

        [TestCase("ZXY")]
        [TestCase("ABC")]
        [TestCase("dkldjsf")]
        [TestCase("65454sadad")]
        public void Add_String_SizeIsGreaterThen0_ThrowsInvalidOperationException(string input)
        {
            // Arrange
            var sut =
                new DatumPath()
                    .Add("ZXY");

            // Act / Assert
            Assert.Throws<InvalidOperationException>(() => sut.Add(input));
        }

        [Test]
        public void Add_String_SizeIs0_AddsValueToPath()
        {
            // Arrange
            var sut = new DatumPath();

            // Act / Assert
            Assert.DoesNotThrow(() => sut.Add("ZXY"));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-7)]
        [TestCase(-80)]
        [TestCase(-999)]
        public void Set_Int_IndexIsLess0_ThrowsArgumentOutOfRangeException(int input)
        {
            // Arrange
            var sut = new DatumPath();

            // Act / Assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => sut.Set(input, 1));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void Set_Int_GreaterThanOrEqualToSize_ThrowsArgumentOutOfRangeException(int input)
        {
            // Arrange
            var sut = new DatumPath();

            // Act / Assert
            Assert.GreaterOrEqual(input, sut.Size);
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Set(input, 1));
        }

        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(80)]
        [TestCase(999)]
        public void Set_Int_GreaterThanOrEqualTo6_ThrowsArgumentOutOfRangeException(int input)
        {
            // Arrange
            var sut = new DatumPath();

            // Act / Assert
            Assert.GreaterOrEqual(input, 6);
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Set(input, 1));
        }

        [Test]
        public void Set_Int_IndexIs0_ThrowsArgumentException()
        {
            // Arrange
            var sut =
                new DatumPath()
                    .Add("ZXY");

            // Act / Assert
            Assert.Throws<ArgumentException>(() => sut.Set(0, 1));
        }

        [Test]
        public void Set_Int_NewValueIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var sut =
                new DatumPath()
                    .Add("ZXY")
                    .Add(2);

            // Act / Assert
            Assert.Throws<ArgumentNullException>(() => sut.Set(1, (int?)null));
        }

        [Test]
        public void Set_Int_InputIsValid_InsertsValueAtIndex()
        {
            // Arrange
            var index = 1;
            var expected = 10;
            var sut =
                new DatumPath()
                    .Add("ZXY")
                    .Add(2);

            // Act
            sut.Set(index, 10);

            // Assert
            Assert.AreEqual(expected, sut.Get(index));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(7)]
        [TestCase(80)]
        [TestCase(999)]
        public void Set_String_IndexDoesNotEqual0_ThrowsArgumentException(int input)
        {
            // Arrange
            var sut = new DatumPath();

            // Act / Assert
            Assert.AreNotEqual(0, input);
            Assert.Throws<ArgumentException>(() => sut.Set(input, "ZXY"));
        }

        [Test]
        public void Set_String_NewValueIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var sut = new DatumPath();

            // Act / Assert
            Assert.Throws<ArgumentNullException>(() => sut.Set(0, (string)null));
        }

        [Test]
        public void Set_String_InputIsValid_InsertsValueAtIndex()
        {
            // Arrange
            var index = 0;
            var expectedValue = "ABC";
            var sut =
                new DatumPath()
                    .Add("ZXY")
                    .Add(2);

            // Act
            sut.Set(index, expectedValue);

            // Assert
            Assert.AreEqual(expectedValue, sut.Get(index));
        }

        [Test]
        public void ReSize_NewSizeIsGreaterThanMaxSize6_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var newSize = 7;
            var sut = new DatumPath();

            // Act / Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.ReSize(newSize));
        }

        [Test]
        public void ReSize_NewSizeIsGreaterThanSize_SetsDefaultValues()
        {
            // Arrange
            var newSize = 6;
            var sut = new DatumPath();

            var expected =
                new DatumPath()
                    .Add(string.Empty)
                    .Add(0)
                    .Add(1)
                    .Add(0)
                    .Add(1)
                    .Add(1);

            // Act
            Assert.GreaterOrEqual(newSize, sut.Size);
            sut.ReSize(newSize);

            // Assert
            Assert.AreEqual(expected, sut);
        }

        [Test]
        public void ReSize_NewSizeIsLessThanSize_DropsAdditionalValues()
        {
            // Arrange
            var newSize = 2;
            var sut =
                new DatumPath()
                    .Add(string.Empty)
                    .Add(0)
                    .Add(1)
                    .Add(0)
                    .Add(1)
                    .Add(1);

            var expected =
                new DatumPath()
                    .Add(string.Empty)
                    .Add(0);

            // Act
            Assert.Less(newSize, sut.Size);
            sut.ReSize(newSize);

            // Assert
            Assert.AreEqual(expected, sut);
        }

        [TestCaseSource(nameof(equalityTestCases))]
        public void Equals_InputsAreEqual_ReturnsExpectedResult(DatumPath inputA, object inputB, bool expected)
        {
            // Arrange
            // Act / Assert
            Assert.AreEqual(expected, inputA.Equals(inputB));
        }

        [TestCaseSource(nameof(equalityTestCasesOperator))]
        public void EqualsOperator_InputsValid_ReturnsExpectedResults(DatumPath inputA, DatumPath inputB, bool expected)
        {
            // Arrange
            // Act / Assert
            Assert.AreEqual(expected, inputA == inputB);
        }

        [TestCaseSource(nameof(equalityTestCasesOperator))]
        public void NotEqualsOperator_InputsValid_ReturnsExpectedResults(DatumPath inputA, DatumPath inputB, bool expected)
        {
            // Arrange
            // Act / Assert
            Assert.AreEqual(!expected, inputA != inputB);
        }

        [Test]
        public void ToString_SizeIsEqualTo0_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            // Act / Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new DatumPath().ToString());
        }

        [TestCaseSource(nameof(toStringTestCases))]
        public void ToString_ValidInput_ReturnsExpectedValue(DatumPath input, string expected)
        {
            // Arrange
            // Act / Assert
            Assert.AreEqual(expected, input.ToString());
        }

        [Test]
        public void Copy_PathValueIsNull_ThrowsInvalidOperationException()
        {
            // Arrange
            var other = new DatumPath().Add("XXX");
            var internalPath =
                other.GetType()
                    .GetField("path", BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.GetValue(other) as List<object>;

            internalPath?.Add(null);

            var sut = new DatumPath();

            // Act / Assert
            Assert.Throws<InvalidOperationException>(() => sut.Copy(other));
        }

        [Test]
        public void Copy_PathValueIsNotStringOrInt_ThrowsInvalidOperationException()
        {
            // Arrange
            var other = new DatumPath().Add("XXX");
            var internalPath =
                other.GetType()
                    .GetField("path", BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.GetValue(other) as List<object>;

            internalPath?.Add(DateTime.Now);

            var sut = new DatumPath();

            // Act / Assert
            Assert.Throws<InvalidOperationException>(() => sut.Copy(other));
        }

        [Test]
        public void Clear_ResetsDatumPathToDefaultState()
        {
            // Arrange
            var sut =
                new DatumPath()
                    .Add("ZXY")
                    .Add(2);

            // Act
            sut.Clear();

            // Assert
            Assert.AreEqual(new DatumPath(), sut);
        }

#pragma warning disable SA1201
        private static object[] equalityTestCases =
        {
            new object[] { new DatumPath().Add("ZXY").Add(1).Add(2), new DatumPath().Add("ZXY").Add(1).Add(2), true, },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(1).Add(1),
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(1).Add(1), true,
            },
            new object[] { new DatumPath().Add("ZXY").Add(1).Add(2), null, false, },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(1).Add(1),
                new DatumPath().Add("YXZ").Add(1).Add(1).Add(1).Add(1), false,
            },
            new object[] { new DatumPath().Add("ZXY").Add(1).Add(1).Add(1).Add(1), new { }, false, },
        };

        private static object[] equalityTestCasesOperator =
        {
            new object[] { new DatumPath().Add("ZXY").Add(1).Add(2), new DatumPath().Add("ZXY").Add(1).Add(2), true, },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(1).Add(1),
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(1).Add(1), true,
            },
            new object[] { new DatumPath().Add("ZXY").Add(1).Add(2), null, false, },
            new object[]
            {
                new DatumPath().Add("ZXY").Add(1).Add(1).Add(1).Add(1),
                new DatumPath().Add("YXZ").Add(1).Add(1).Add(1).Add(1), false,
            },
            new object[] { null, new DatumPath().Add("ZXY").Add(1).Add(1).Add(1).Add(1), false, },
            new object[] { null, null, true },
        };

        private static object[] toStringTestCases =
        {
            new object[] { new DatumPath().Add("ZXY").Add(1).Add(2), "ZXY[1]-2[0]-1-1", },
            new object[] { new DatumPath().Add("ZXY").Add(1).Add(0).Add(1).Add(1), "ZXY[1]-0[1]-1-1", },
            new object[] { new DatumPath().Add("ZXY").Add(1).Add(5), "ZXY[1]-5[0]-1-1", },
            new object[] { new DatumPath().Add("ZXY").Add(1).Add(2).Add(3).Add(4), "ZXY[1]-2[3]-4-1", },
            new object[] { new DatumPath().Add("ZXY").Add(4).Add(3).Add(2).Add(1), "ZXY[4]-3[2]-1-1", },
        };
#pragma warning restore SA1201
    }
}