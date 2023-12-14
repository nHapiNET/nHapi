namespace NHapi.NUnit
{
    using System;

    using global::NUnit.Framework;

    using NHapi.Model.V231.Message;

    [TestFixture]
    public class DateTypeTest231
    {
        [Test]
        public void ConvertToDate()
        {
            var checkDate = DateTime.Now;
            var a01 = new ADT_A01();
            a01.PV1.AdmitDateTime.TimeOfAnEvent.Set(checkDate, "yyyyMMdd");
            Assert.That(checkDate.ToString("yyyyMMdd"), Is.EqualTo(a01.PV1.AdmitDateTime.TimeOfAnEvent.Value));
        }

        [Test]
        public void ConvertToLongDate()
        {
            var checkDate = DateTime.Now;
            var ack = new ACK();
            ack.MSH.DateTimeOfMessage.TimeOfAnEvent.SetLongDate(checkDate);
            Assert.That(checkDate.ToString("yyyyMMddHHmm"), Is.EqualTo(ack.MSH.DateTimeOfMessage.TimeOfAnEvent.Value));
        }

        [Test]
        public void ConvertToLongDateWithSecond()
        {
            var checkDate = DateTime.Now;
            var ack = new ACK();
            ack.MSH.DateTimeOfMessage.TimeOfAnEvent.SetLongDateWithSecond(checkDate);
            Assert.That(checkDate.ToString("yyyyMMddHHmmss"), Is.EqualTo(ack.MSH.DateTimeOfMessage.TimeOfAnEvent.Value));
        }

        [Test]
        public void ConvertToLongDateWithFractionOfSecond()
        {
            var checkDate = DateTime.Now;
            var ack = new ACK();
            ack.MSH.DateTimeOfMessage.TimeOfAnEvent.SetLongDateWithFractionOfSecond(checkDate);
            Assert.That(checkDate.ToString("yyyyMMddHHmmss.FFFF"), Is.EqualTo(ack.MSH.DateTimeOfMessage.TimeOfAnEvent.Value));
        }

        [Test]
        public void ConvertToShortDate()
        {
            var checkDate = DateTime.Now;
            var ack = new ACK();
            ack.MSH.DateTimeOfMessage.TimeOfAnEvent.SetShortDate(checkDate);
            Assert.That(checkDate.ToString("yyyyMMdd"), Is.EqualTo(ack.MSH.DateTimeOfMessage.TimeOfAnEvent.Value));
        }

        [Test]
        public void ConvertBackToShortDate()
        {
            var checkDate = DateTime.Now;
            var ack = new ACK();
            ack.MSH.DateTimeOfMessage.TimeOfAnEvent.SetShortDate(checkDate);

            var checkDate2 = ack.MSH.DateTimeOfMessage.TimeOfAnEvent.GetAsDate();

            Assert.That(checkDate2.ToShortDateString(), Is.EqualTo(checkDate.ToShortDateString()));
        }

        [Test]
        public void ConvertBackToLongDate()
        {
            var checkDate = DateTime.Now;
            var ack = new ACK();
            ack.MSH.DateTimeOfMessage.TimeOfAnEvent.SetLongDate(checkDate);

            var checkDate2 = ack.MSH.DateTimeOfMessage.TimeOfAnEvent.GetAsDate();

            Assert.That(checkDate2.ToLongDateString(), Is.EqualTo(checkDate.ToLongDateString()));
        }
    }
}