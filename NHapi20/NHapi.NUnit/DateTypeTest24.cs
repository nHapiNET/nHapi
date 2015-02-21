using System;
using NHapi.Model.V24.Message;
using NHapi.Base.Parser;
using NUnit.Framework;

namespace NHapi.NUnit
{
	/// <summary>
	/// Summary description for DateTypeTest.
	/// </summary>
	[TestFixture]
	public class DateTypeTest24
	{
		[Test]
		public void ConvertToDate()
		{
			DateTime checkDate = DateTime.Now;
			PipeParser parser = new PipeParser();
			ADT_A01 a01 = new ADT_A01();
			a01.PV1.AdmitDateTime.TimeOfAnEvent.Set(checkDate, "yyyyMMdd");
			Assert.AreEqual(a01.PV1.AdmitDateTime.TimeOfAnEvent.Value, checkDate.ToString("yyyyMMdd"));
		}

		[Test]
		public void ConvertToLongDate()
		{
			DateTime checkDate = DateTime.Now;
			ACK ack = new ACK();
			ack.MSH.DateTimeOfMessage.TimeOfAnEvent.SetLongDate(checkDate);
			Assert.AreEqual(ack.MSH.DateTimeOfMessage.TimeOfAnEvent.Value, checkDate.ToString("yyyyMMddHHmm"));
		}

		[Test]
		public void ConvertToLongDateWithSecond()
		{
			DateTime checkDate = DateTime.Now;
			ACK ack = new ACK();
			ack.MSH.DateTimeOfMessage.TimeOfAnEvent.SetLongDateWithSecond(checkDate);
			Assert.AreEqual(ack.MSH.DateTimeOfMessage.TimeOfAnEvent.Value, checkDate.ToString("yyyyMMddHHmmss"));
		}

		[Test]
		public void ConvertToLongDateWithFractionOfSecond()
		{
			DateTime checkDate = DateTime.Now;
			ACK ack = new ACK();
			ack.MSH.DateTimeOfMessage.TimeOfAnEvent.SetLongDateWithFractionOfSecond(checkDate);
			Assert.AreEqual(ack.MSH.DateTimeOfMessage.TimeOfAnEvent.Value, checkDate.ToString("yyyyMMddHHmmss.FFFF"));
		}

		[Test]
		public void ConvertToShortDate()
		{
			DateTime checkDate = DateTime.Now;
			ACK ack = new ACK();
			ack.MSH.DateTimeOfMessage.TimeOfAnEvent.SetShortDate(checkDate);
			Assert.AreEqual(ack.MSH.DateTimeOfMessage.TimeOfAnEvent.Value, checkDate.ToString("yyyyMMdd"));
		}

		[Test]
		public void ConvertBackToShortDate()
		{
			DateTime checkDate = DateTime.Now;
			ACK ack = new ACK();
			ack.MSH.DateTimeOfMessage.TimeOfAnEvent.SetShortDate(checkDate);

			DateTime checkDate2 = ack.MSH.DateTimeOfMessage.TimeOfAnEvent.GetAsDate();

			Assert.AreEqual(checkDate.ToShortDateString(), checkDate2.ToShortDateString());
		}

		[Test]
		public void ConvertBackToLongDate()
		{
			DateTime checkDate = DateTime.Now;
			ACK ack = new ACK();
			ack.MSH.DateTimeOfMessage.TimeOfAnEvent.SetLongDate(checkDate);

			DateTime checkDate2 = ack.MSH.DateTimeOfMessage.TimeOfAnEvent.GetAsDate();

			Assert.AreEqual(checkDate.ToLongDateString(), checkDate2.ToLongDateString());
		}
	}
}