namespace NHapi.NUnit
{
    using System;

    using global::NUnit.Framework;

    using NHapi.Base;
    using NHapi.Base.Parser;
    using NHapi.Model.V26.Datatype;
    using NHapi.Model.V26.Message;

    [TestFixture]
    public class DateTypeTest26
    {
        private static readonly TimeSpan PlusEight = TimeSpan.FromHours(8);

        private static readonly object[] OffsetCases =
        {
            // Fractional seconds with an offset: the Mindray V9 value from issue #411.
            new object[] { "20230211140114.0000+0800", new DateTimeOffset(2023, 2, 11, 14, 1, 14, PlusEight) },
            new object[] { "20230211140114.1234+0800", new DateTimeOffset(2023, 2, 11, 14, 1, 14, 123, PlusEight).AddTicks(4000) },
            new object[] { "20230211140114.5-0530", new DateTimeOffset(2023, 2, 11, 14, 1, 14, 500, TimeSpan.FromMinutes(-330)) },
            new object[] { "202302111401+0800", new DateTimeOffset(2023, 2, 11, 14, 1, 0, PlusEight) },
            new object[] { "2023021114+0800", new DateTimeOffset(2023, 2, 11, 14, 0, 0, PlusEight) },
            new object[] { "20230211+0800", new DateTimeOffset(2023, 2, 11, 0, 0, 0, PlusEight) },
        };

        private static readonly object[] PrecisionCases =
        {
            new object[] { "2023021114", new DateTime(2023, 2, 11, 14, 0, 0) },
            new object[] { "202302", new DateTime(2023, 2, 1) },
            new object[] { "2023", new DateTime(2023, 1, 1) },
        };

        [TestCaseSource(nameof(OffsetCases))]
        public void GetAsDate_DtmWithOffset_ConvertsToLocalTime(string value, DateTimeOffset expected)
        {
            var dtm = new DTM(new ACK()) { Value = value };

            Assert.That(dtm.GetAsDate(), Is.EqualTo(expected.LocalDateTime));
        }

        [TestCaseSource(nameof(PrecisionCases))]
        public void GetAsDate_ReducedPrecisionDtm_Parses(string value, DateTime expected)
        {
            var dtm = new DTM(new ACK()) { Value = value };

            Assert.That(dtm.GetAsDate(), Is.EqualTo(expected));
        }

        [TestCase("20230211140114.12345")]
        [TestCase("2023021114011")]
        [TestCase("20231311")]
        [TestCase("not a date")]
        public void GetAsDate_InvalidDtm_StillThrows(string value)
        {
            var dtm = new DTM(new ACK()) { Value = value };

            Assert.Throws<HL7Exception>(() => dtm.GetAsDate());
        }

        [Test]
        public void GetAsDate_MindrayOruR01_ParsesMessageAndObservationTimes()
        {
            var message =
                "MSH|^~\\&|MINDRAY_^00B0353000000^EUI-64|MINDRAY|||20230211140114.0000+0800||ORU^R01^ORU_R01|10|P|2.6|||AL|NE||UNICODE UTF-8|||IHE_PCD_001^IHE PCD^1.3.6.1.4.1.19376.1.6.1.1.1^ISO\r"
                + "PID|||1234^^^Hospital^PI||Uui^Kki^^^^^L|||M\r"
                + "PV1||I|ED^^RED VS9\r"
                + "OBR|1|10^MINDRAY_^00B0353000000^EUI-64|10^MINDRAY_^00A037000000^EUI-64|182777000^monitoring of patient^SCT|||20230211134735.0000+0800\r"
                + "OBX|1|NM|150456^MDC_PULS_OXIM_SAT_O2^MDC|1.3.1.150456|97|262688^MDC_DIM_PERCENT^MDC|||||R|||20230211134735.0000+0800||||00A037000000^^00A037000000^EUI-64\r";

            var oru = (ORU_R01)new PipeParser().Parse(message);
            var obx = oru.GetPATIENT_RESULT().GetORDER_OBSERVATION().GetOBSERVATION().OBX;

            Assert.Multiple(() =>
            {
                Assert.That(
                    oru.MSH.DateTimeOfMessage.GetAsDate(),
                    Is.EqualTo(new DateTimeOffset(2023, 2, 11, 14, 1, 14, PlusEight).LocalDateTime));
                Assert.That(
                    obx.DateTimeOfTheObservation.GetAsDate(),
                    Is.EqualTo(new DateTimeOffset(2023, 2, 11, 13, 47, 35, PlusEight).LocalDateTime));
            });
        }
    }
}
