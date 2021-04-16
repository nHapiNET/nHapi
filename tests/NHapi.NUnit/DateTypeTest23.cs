namespace NHapi.NUnit
{
    using System;

    using global::NUnit.Framework;

    using NHapi.Model.V23.Message;

    [TestFixture]
    public class DateTypeTest23
    {
        [Test]
        public void ConvertToDate()
        {
            var checkDate = DateTime.Now;
            var a01 = new ADT_A01();
            a01.PV1.AdmitDateTime.TimeOfAnEvent.Set(checkDate, "yyyyMMdd");
            Assert.AreEqual(a01.PV1.AdmitDateTime.TimeOfAnEvent.Value, checkDate.ToString("yyyyMMdd"));
        }

        [Test]
        public void ConvertToLongDate()
        {
            var checkDate = DateTime.Now;
            var ack = new ACK();
            ack.MSH.DateTimeOfMessage.TimeOfAnEvent.SetLongDate(checkDate);
            Assert.AreEqual(ack.MSH.DateTimeOfMessage.TimeOfAnEvent.Value, checkDate.ToString("yyyyMMddHHmm"));
        }

        [Test]
        public void ConvertToLongDateWithSecond()
        {
            var checkDate = DateTime.Now;
            var ack = new ACK();
            ack.MSH.DateTimeOfMessage.TimeOfAnEvent.SetLongDateWithSecond(checkDate);
            Assert.AreEqual(ack.MSH.DateTimeOfMessage.TimeOfAnEvent.Value, checkDate.ToString("yyyyMMddHHmmss"));
        }

        [Test]
        public void ConvertToLongDateWithFractionOfSecond()
        {
            var checkDate = DateTime.Now;
            var ack = new ACK();
            ack.MSH.DateTimeOfMessage.TimeOfAnEvent.SetLongDateWithFractionOfSecond(checkDate);
            Assert.AreEqual(ack.MSH.DateTimeOfMessage.TimeOfAnEvent.Value, checkDate.ToString("yyyyMMddHHmmss.FFFF"));
        }

        [Test]
        public void ConvertToShortDate()
        {
            var checkDate = DateTime.Now;
            var ack = new ACK();
            ack.MSH.DateTimeOfMessage.TimeOfAnEvent.SetShortDate(checkDate);
            Assert.AreEqual(ack.MSH.DateTimeOfMessage.TimeOfAnEvent.Value, checkDate.ToString("yyyyMMdd"));
        }

        [Test]
        public void ConvertBackToShortDate()
        {
            var checkDate = DateTime.Now;
            var ack = new ACK();
            ack.MSH.DateTimeOfMessage.TimeOfAnEvent.SetShortDate(checkDate);

            var checkDate2 = ack.MSH.DateTimeOfMessage.TimeOfAnEvent.GetAsDate();

            Assert.AreEqual(checkDate.ToShortDateString(), checkDate2.ToShortDateString());
        }

        [Test]
        public void ConvertBackToLongDate()
        {
            var checkDate = DateTime.Now;
            var ack = new ACK();
            ack.MSH.DateTimeOfMessage.TimeOfAnEvent.SetLongDate(checkDate);

            var checkDate2 = ack.MSH.DateTimeOfMessage.TimeOfAnEvent.GetAsDate();

            Assert.AreEqual(checkDate.ToLongDateString(), checkDate2.ToLongDateString());
        }
    }
}