namespace NHapi.Base.NUnit
{
    using System;
    using System.Collections.Generic;

    using global::NUnit.Framework;

    using NHapi.Base.Model;

    [TestFixture]
    public class DataTypeUtilTests
    {
        private bool IsWindows { get; set; }

        [SetUp]
        public void Setup()
        {
            var nonWindows = new List<PlatformID>
            {
                PlatformID.MacOSX,
                PlatformID.Unix,
            };

            IsWindows = !nonWindows.Contains(Environment.OSVersion.Platform);
        }

        [Test]
        public void GetGMTOffset_PST()
        {
            var timeZone = GetAppropriateTimeZoneId("Pacific Standard Time");

            var offset = DataTypeUtil.GetGMTOffset(
                TimeZoneInfo.FindSystemTimeZoneById(timeZone),
                new DateTime(2014, 12, 1));

            Assert.That(offset, Is.EqualTo(-800));
        }

        [Test]
        public void GetGMTOffset_PDT()
        {
            var timeZone = GetAppropriateTimeZoneId("Pacific Standard Time");

            var offset = DataTypeUtil.GetGMTOffset(
                TimeZoneInfo.FindSystemTimeZoneById(timeZone),
                new DateTime(2014, 10, 1));

            Assert.That(offset, Is.EqualTo(-700));
        }

        [Test]
        public void GetGMTOffset_For_TimeZone_With_Non_Zero_Minutes()
        {
            var timeZone = GetAppropriateTimeZoneId("Myanmar Standard Time");

            var offset = DataTypeUtil.GetGMTOffset(
                TimeZoneInfo.FindSystemTimeZoneById(timeZone),
                new DateTime(2014, 11, 1));

            Assert.That(offset, Is.EqualTo(630));
        }

        [Test]
        public void GetGMTOffset_For_TimeZone_With_Offset_Greater_Than_12()
        {
            var timeZone = GetAppropriateTimeZoneId("Line Islands Standard Time");

            var offset = DataTypeUtil.GetGMTOffset(
                TimeZoneInfo.FindSystemTimeZoneById(timeZone),
                new DateTime(2014, 11, 1));

            Assert.That(offset, Is.EqualTo(1400));
        }

        private string GetAppropriateTimeZoneId(string timeZoneId)
        {
            return IsWindows
                ? timeZoneId
                : TimeZoneConverter.TZConvert.WindowsToIana(timeZoneId);
        }
    }
}