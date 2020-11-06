using NHapi.Base;
using NHapi.Base.Model.Primitive;
using NUnit.Framework;

namespace NHapi.NUnit
{
	[TestFixture]
	public class CommonDtTest
	{
		[Test]
		public void Constructor_Sets_Value()
		{
			var commonDt = new CommonDT("20010203");
			Assert.AreEqual("20010203", commonDt.Value);
		}

		[Test]
		public void Value__Set_to_Null()
		{
			var commonDt = new CommonDT();
			commonDt.Value = null;
			Assert.AreEqual(null, commonDt.Value);
		}

		[Test]
		public void Value__Set_to_Empty_String()
		{
			var commonDt = new CommonDT();
			commonDt.Value = "";
			Assert.AreEqual("", commonDt.Value);
		}

		[Test]
		public void Value__Set_to_Empty_Quoted_String()
		{
			var commonDt = new CommonDT();
			commonDt.Value = "\"\"";
			Assert.AreEqual("\"\"", commonDt.Value);
		}

		[Test]
		public void Value__Set_to_Invalid_Length()
		{
			var commonDt = new CommonDT();
			Assert.Throws<DataTypeException>(
				() => commonDt.Value = "20010");
		}

		[Test]
		public void Value__Set_to_Valid_Year()
		{
			var commonDt = new CommonDT();
			commonDt.Value = "2001";
			Assert.AreEqual("2001", commonDt.Value);
			Assert.AreEqual(2001, commonDt.Year);
		}

		[Test]
		public void Value__Set_to_Valid_Year_and_Month()
		{
			var commonDt = new CommonDT();
			commonDt.Value = "200102";
			Assert.AreEqual("200102", commonDt.Value);
			Assert.AreEqual(2001, commonDt.Year);
			Assert.AreEqual(2, commonDt.Month);
		}

		[Test]
		public void Value__Set_to_Valid_Year_and_Month_and_Day()
		{
			var commonDt = new CommonDT();
			commonDt.Value = "20010203";
			Assert.AreEqual("20010203", commonDt.Value);
			Assert.AreEqual(2001, commonDt.Year);
			Assert.AreEqual(2, commonDt.Month);
			Assert.AreEqual(3, commonDt.Day);
		}

		[Test]
		public void Value__Set_to_Invalid_Year()
		{
			var commonDt = new CommonDT();

			Assert.Throws<DataTypeException>(
				() => commonDt.Value = "200a");
        }

		[Test]
		public void Value__Set_to_Invalid_Month()
		{
			var commonDt = new CommonDT();

			Assert.Throws<DataTypeException>(
				() => commonDt.Value = "20010a");
        }

		[Test]
		public void Value__Set_to_Invalid_Day()
		{
			var commonDt = new CommonDT();

			Assert.Throws<DataTypeException>(
				() => commonDt.Value = "2001020a");
        }


		[Test]
		public void YearPrecision__Set_to_Valid_Year()
		{
			var commonDt = new CommonDT();
			commonDt.YearPrecision = 2001;
			Assert.AreEqual("2001", commonDt.Value);
			Assert.AreEqual(2001, commonDt.Year);
			Assert.AreEqual(0, commonDt.Month);
			Assert.AreEqual(0, commonDt.Day);
		}

		[Test]
		public void YearPrecision__Set_to_Invalid_Year()
		{
			var commonDt = new CommonDT();

			Assert.Throws<DataTypeException>(
				() => commonDt.YearPrecision = 20010);
        }


		[Test]
		public void setYearMonthPrecision_With_Valid_Year_and_Month()
		{
			var commonDt = new CommonDT();
			commonDt.setYearMonthPrecision(2001, 02);
			Assert.AreEqual("200102", commonDt.Value);
			Assert.AreEqual(2001, commonDt.Year);
			Assert.AreEqual(2, commonDt.Month);
		}

		[Test]
		public void setYearMonthPrecision_With_Invalid_Year()
		{
			var commonDt = new CommonDT();

			Assert.Throws<DataTypeException>(
				() => commonDt.setYearMonthPrecision(20010, 02));
        }

		[Test]
		public void setYearMonthPrecision_With_Invalid_Month()
		{
			var commonDt = new CommonDT();

			Assert.Throws<DataTypeException>(
				() => commonDt.setYearMonthPrecision(2001, 13));
        }


		[Test]
		public void setYearMonthDayPrecision_With_Valid_Year_and_Month_and_Day()
		{
			var commonDt = new CommonDT();
			commonDt.setYearMonthDayPrecision(2001, 2, 3);
			Assert.AreEqual("20010203", commonDt.Value);
			Assert.AreEqual(2001, commonDt.Year);
			Assert.AreEqual(2, commonDt.Month);
			Assert.AreEqual(3, commonDt.Day);
		}

		[Test]
		public void setYearMonthDayPrecision_With_Invalid_Year()
		{
			var commonDt = new CommonDT();

			Assert.Throws<DataTypeException>(
				() => commonDt.setYearMonthDayPrecision(20010, 2, 3));
        }

		[Test]
		public void setYearMonthDayPrecision_With_Invalid_Month()
		{
			var commonDt = new CommonDT();

			Assert.Throws<DataTypeException>(
				() => commonDt.setYearMonthDayPrecision(2001, 13, 3));
        }

		[Test]
		public void setYearMonthDayPrecision_With_Invalid_Day()
		{
			var commonDt = new CommonDT();

			Assert.Throws<DataTypeException>(
				() => commonDt.setYearMonthDayPrecision(2001, 2, 29));
        }
	}
}