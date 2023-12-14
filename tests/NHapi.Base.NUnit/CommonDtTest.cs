namespace NHapi.Base.NUnit
{
    using global::NUnit.Framework;

    using NHapi.Base.Model.Primitive;

    [TestFixture]
    public class CommonDtTest
    {
        [Test]
        public void Constructor_Sets_Value()
        {
            var commonDt = new CommonDT("20010203");

            Assert.That(commonDt.Value, Is.EqualTo("20010203"));
        }

        [Test]
        public void Value__Set_to_Null()
        {
            var commonDt = new CommonDT
            {
                Value = null,
            };

            Assert.That(commonDt.Value, Is.EqualTo(null));
        }

        [Test]
        public void Value__Set_to_Empty_String()
        {
            var commonDt = new CommonDT
            {
                Value = string.Empty,
            };

            Assert.That(commonDt.Value, Is.EqualTo(string.Empty));
        }

        [Test]
        public void Value__Set_to_Empty_Quoted_String()
        {
            var commonDt = new CommonDT
            {
                Value = "\"\"",
            };

            Assert.That(commonDt.Value, Is.EqualTo("\"\""));
        }

        [Test]
        public void Value__Set_to_Invalid_Length()
        {
            var commonDt = new CommonDT();
            Assert.That(() => commonDt.Value = "20010", Throws.TypeOf<DataTypeException>());
        }

        [Test]
        public void Value__Set_to_Valid_Year()
        {
            var commonDt = new CommonDT
            {
                Value = "2001",
            };

            Assert.Multiple(() =>
            {
                Assert.That(commonDt.Value, Is.EqualTo("2001"));
                Assert.That(commonDt.Year, Is.EqualTo(2001));
            });
        }

        [Test]
        public void Value__Set_to_Valid_Year_and_Month()
        {
            var commonDt = new CommonDT
            {
                Value = "200102",
            };

            Assert.Multiple(() =>
            {
                Assert.That(commonDt.Value, Is.EqualTo("200102"));
                Assert.That(commonDt.Year, Is.EqualTo(2001));
                Assert.That(commonDt.Month, Is.EqualTo(2));
            });
        }

        [Test]
        public void Value__Set_to_Valid_Year_and_Month_and_Day()
        {
            var commonDt = new CommonDT
            {
                Value = "20010203",
            };

            Assert.Multiple(() =>
            {
                Assert.That(commonDt.Value, Is.EqualTo("20010203"));
                Assert.That(commonDt.Year, Is.EqualTo(2001));
                Assert.That(commonDt.Month, Is.EqualTo(2));
                Assert.That(commonDt.Day, Is.EqualTo(3));
            });
        }

        [Test]
        public void Value__Set_to_Invalid_Year()
        {
            var commonDt = new CommonDT();

            Assert.That(
                () => commonDt.Value = "200a",
                Throws.TypeOf<DataTypeException>());
        }

        [Test]
        public void Value__Set_to_Invalid_Month()
        {
            var commonDt = new CommonDT();

            Assert.That(
                () => commonDt.Value = "20010a",
                Throws.TypeOf<DataTypeException>());
        }

        [Test]
        public void Value__Set_to_Invalid_Day()
        {
            var commonDt = new CommonDT();

            Assert.That(
                () => commonDt.Value = "2001020a",
                Throws.TypeOf<DataTypeException>());
        }

        [Test]
        public void YearPrecision__Set_to_Valid_Year()
        {
            var commonDt = new CommonDT
            {
                YearPrecision = 2001,
            };

            Assert.Multiple(() =>
            {
                Assert.That(commonDt.Value, Is.EqualTo("2001"));
                Assert.That(commonDt.Year, Is.EqualTo(2001));
                Assert.That(commonDt.Month, Is.EqualTo(0));
                Assert.That(commonDt.Day, Is.EqualTo(0));
            });
        }

        [Test]
        public void YearPrecision__Set_to_Invalid_Year()
        {
            var commonDt = new CommonDT();

            Assert.That(
                () => commonDt.YearPrecision = 20010,
                Throws.TypeOf<DataTypeException>());
        }

        [Test]
        public void SetYearMonthPrecision_With_Valid_Year_and_Month()
        {
            var commonDt = new CommonDT();
            commonDt.SetYearMonthPrecision(2001, 02);

            Assert.Multiple(() =>
            {
                Assert.That(commonDt.Value, Is.EqualTo("200102"));
                Assert.That(commonDt.Year, Is.EqualTo(2001));
                Assert.That(commonDt.Month, Is.EqualTo(2));
            });
        }

        [Test]
        public void SetYearMonthPrecision_With_Invalid_Year()
        {
            var commonDt = new CommonDT();

            Assert.That(
                () => commonDt.SetYearMonthPrecision(20010, 02),
                Throws.TypeOf<DataTypeException>());
        }

        [Test]
        public void SetYearMonthPrecision_With_Invalid_Month()
        {
            var commonDt = new CommonDT();

            Assert.That(
                () => commonDt.SetYearMonthPrecision(2001, 13),
                Throws.TypeOf<DataTypeException>());
        }

        [Test]
        public void SetYearMonthDayPrecision_With_Valid_Year_and_Month_and_Day()
        {
            var commonDt = new CommonDT();
            commonDt.SetYearMonthDayPrecision(2001, 2, 3);

            Assert.Multiple(() =>
            {
                Assert.That(commonDt.Value, Is.EqualTo("20010203"));
                Assert.That(commonDt.Year, Is.EqualTo(2001));
                Assert.That(commonDt.Month, Is.EqualTo(2));
                Assert.That(commonDt.Day, Is.EqualTo(3));
            });
        }

        [Test]
        public void SetYearMonthDayPrecision_With_Invalid_Year()
        {
            var commonDt = new CommonDT();

            Assert.That(
                () => commonDt.SetYearMonthDayPrecision(20010, 2, 3),
                Throws.TypeOf<DataTypeException>());
        }

        [Test]
        public void SetYearMonthDayPrecision_With_Invalid_Month()
        {
            var commonDt = new CommonDT();

            Assert.That(
                () => commonDt.SetYearMonthDayPrecision(2001, 13, 3),
                Throws.TypeOf<DataTypeException>());
        }

        [Test]
        public void SetYearMonthDayPrecision_With_Invalid_Day()
        {
            var commonDt = new CommonDT();

            Assert.That(
                () => commonDt.SetYearMonthDayPrecision(2001, 2, 29),
                Throws.TypeOf<DataTypeException>());
        }
    }
}