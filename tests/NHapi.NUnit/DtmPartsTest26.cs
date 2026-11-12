namespace NHapi.NUnit
{
    using System;

    using global::NUnit.Framework;

    using NHapi.Model.V26.Message;

    /// <summary>
    /// Reading the parts of a DTM must not change its value. See nHapiNET/nHapi#917.
    /// </summary>
    [TestFixture]
    public class DtmPartsTest26
    {
        [TestCase("20100101")]
        [TestCase("201001011230")]
        [TestCase("20100101123045")]
        [TestCase("20100101123045+0200")]
        public void ReadingParts_DoesNotChangeValue(string value)
        {
            var pid = new ADT_A05().PID;
            pid.DateTimeOfBirth.Value = value;

            _ = pid.DateTimeOfBirth.Year;
            _ = pid.DateTimeOfBirth.Month;
            _ = pid.DateTimeOfBirth.Day;
            _ = pid.DateTimeOfBirth.Hour;
            _ = pid.DateTimeOfBirth.GMTOffset;

            Assert.That(pid.DateTimeOfBirth.Value, Is.EqualTo(value));
        }

        [Test]
        public void ReadingParts_ReturnsTheParts_AndGetAsDateStillWorks()
        {
            var pid = new ADT_A05().PID;
            pid.DateTimeOfBirth.Value = "20100102";

            Assert.That(pid.DateTimeOfBirth.Year, Is.EqualTo(2010));
            Assert.That(pid.DateTimeOfBirth.Month, Is.EqualTo(1));
            Assert.That(pid.DateTimeOfBirth.Day, Is.EqualTo(2));
            Assert.That(pid.DateTimeOfBirth.GetAsDate(), Is.EqualTo(new DateTime(2010, 1, 2)));
        }

        [Test]
        public void SettingValueAfterReadingParts_UpdatesTheParts()
        {
            var pid = new ADT_A05().PID;
            pid.DateTimeOfBirth.Value = "20100102";
            _ = pid.DateTimeOfBirth.Year;

            pid.DateTimeOfBirth.Value = "19991231";

            Assert.That(pid.DateTimeOfBirth.Value, Is.EqualTo("19991231"));
            Assert.That(pid.DateTimeOfBirth.Year, Is.EqualTo(1999));
            Assert.That(pid.DateTimeOfBirth.Day, Is.EqualTo(31));
        }

        [Test]
        public void PrecisionSetters_StillUpdateValue()
        {
            var pid = new ADT_A05().PID;

            pid.DateTimeOfBirth.SetDatePrecision(2010, 1, 2);
            Assert.That(pid.DateTimeOfBirth.Value, Is.EqualTo("20100102"));

            pid.DateTimeOfBirth.SetDateMinutePrecision(2010, 1, 2, 12, 30);
            Assert.That(pid.DateTimeOfBirth.Value, Does.StartWith("201001021230"));
            Assert.That(pid.DateTimeOfBirth.Minute, Is.EqualTo(30));
        }
    }
}
