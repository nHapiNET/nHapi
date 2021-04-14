namespace NHapi.NUnit.Parser
{
    using global::NUnit.Framework;

    using NHapi.Base.Parser;

    public class PipeParserUnexpectedSegmentTests
    {
        #region v23

        [Test]
        public void Parse_V23_ORM_O01()
        {
            var message =
                "MSH|^~\\&|sys1|sys1|sys2|sys2|20180503174921||ORM^O01|1234567890|P|2.3\r"
              + "PID|||1^^^XXX~2^^^YYY||LastName^FirstName||19660429|F\r"
              + "PV1||I|3906||||||||||||||||100001\r"
              + "ORC|CA|1410|3121||CA\r"
              + "OBR|1|1410|3121|RX50^ADDOME SUPINO";

            var parser = new PipeParser();

            var result = parser.Parse(message);

            var orm = result as NHapi.Model.V23.Message.ORM_O01;

            Assert.IsNotNull(orm);
            Assert.AreEqual("FirstName", orm.PATIENT.PID.GetPatientName(0).GivenName.Value);
        }

        [Test]
        public void Parse_V23_ORM_O01_WithCustomEvnSegment()
        {
            var message =
                "MSH|^~\\&|sys1|sys1|sys2|sys2|20180503174921||ORM^O01|1234567890|P|2.3\r"
              + "EVN||20180503\r"
              + "PID|||1^^^XXX~2^^^YYY||LastName^FirstName||19660429|F\r"
              + "PV1||I|3906||||||||||||||||100001\r"
              + "ORC|CA|1410|3121||CA\r"
              + "OBR|1|1410|3121|RX50^ADDOME SUPINO";

            var parser = new PipeParser();

            var result = parser.Parse(message);

            var orm = result as NHapi.Model.V23.Message.ORM_O01;

            Assert.IsNotNull(orm);
            Assert.AreEqual("FirstName", orm.PATIENT.PID.GetPatientName(0).GivenName.Value);
        }

        #endregion

        #region v24

        [Test]
        public void Parse_V24_ORM_O01()
        {
            var message =
                "MSH|^~\\&|sys1|sys1|sys2|sys2|20180503174921||ORM^O01|1234567890|P|2.4\r"
              + "PID|||1^^^XXX~2^^^YYY||LastName^FirstName||19660429|F\r"
              + "PV1||I|3906||||||||||||||||100001\r"
              + "ORC|CA|1410|3121||CA\r"
              + "OBR|1|1410|3121|RX50^ADDOME SUPINO";

            var parser = new PipeParser();

            var result = parser.Parse(message);

            var orm = result as NHapi.Model.V24.Message.ORM_O01;

            Assert.IsNotNull(orm);
            Assert.AreEqual("FirstName", orm.PATIENT.PID.GetPatientName(0).GivenName.Value);
        }

        [Test]
        public void Parse_V24_ORM_O01_WithCustomEvnSegment()
        {
            var message =
                "MSH|^~\\&|sys1|sys1|sys2|sys2|20180503174921||ORM^O01|1234567890|P|2.4\r"
              + "EVN||20180503\r"
              + "PID|||1^^^XXX~2^^^YYY||LastName^FirstName||19660429|F\r"
              + "PV1||I|3906||||||||||||||||100001\r"
              + "ORC|CA|1410|3121||CA\r"
              + "OBR|1|1410|3121|RX50^ADDOME SUPINO";

            var parser = new PipeParser();

            var result = parser.Parse(message);

            var orm = result as NHapi.Model.V24.Message.ORM_O01;

            Assert.IsNotNull(orm);
            Assert.AreEqual("FirstName", orm.PATIENT.PID.GetPatientName(0).GivenName.Value);
        }

        #endregion

        #region v25

        [Test]
        public void Parse_V25_ORM_O01()
        {
            var message =
                "MSH|^~\\&|sys1|sys1|sys2|sys2|20180503174921||ORM^O01|1234567890|P|2.5\r"
              + "PID|||1^^^XXX~2^^^YYY||LastName^FirstName||19660429|F\r"
              + "PV1||I|3906||||||||||||||||100001\r"
              + "ORC|CA|1410|3121||CA\r"
              + "OBR|1|1410|3121|RX50^ADDOME SUPINO";

            var parser = new PipeParser();

            var result = parser.Parse(message);

            var orm = result as NHapi.Model.V25.Message.ORM_O01;

            Assert.IsNotNull(orm);
            Assert.AreEqual("FirstName", orm.PATIENT.PID.GetPatientName(0).GivenName.Value);
        }

        [Test]
        public void Parse_V25_ORM_O01_WithCustomEvnSegment()
        {
            var message =
                "MSH|^~\\&|sys1|sys1|sys2|sys2|20180503174921||ORM^O01|1234567890|P|2.5\r"
              + "EVN||20180503\r"
              + "PID|||1^^^XXX~2^^^YYY||LastName^FirstName||19660429|F\r"
              + "PV1||I|3906||||||||||||||||100001\r"
              + "ORC|CA|1410|3121||CA\r"
              + "OBR|1|1410|3121|RX50^ADDOME SUPINO";

            var parser = new PipeParser();

            var result = parser.Parse(message);

            var orm = result as NHapi.Model.V25.Message.ORM_O01;

            Assert.IsNotNull(orm);
            Assert.AreEqual("FirstName", orm.PATIENT.PID.GetPatientName(0).GivenName.Value);
        }

        #endregion

        #region v251

        [Test]
        public void Parse_V251_ORM_O01()
        {
            var message =
                "MSH|^~\\&|sys1|sys1|sys2|sys2|20180503174921||ORM^O01|1234567890|P|2.5.1\r"
              + "PID|||1^^^XXX~2^^^YYY||LastName^FirstName||19660429|F\r"
              + "PV1||I|3906||||||||||||||||100001\r"
              + "ORC|CA|1410|3121||CA\r"
              + "OBR|1|1410|3121|RX50^ADDOME SUPINO";

            var parser = new PipeParser();

            var result = parser.Parse(message);

            var orm = result as NHapi.Model.V251.Message.ORM_O01;

            Assert.IsNotNull(orm);
            Assert.AreEqual("FirstName", orm.PATIENT.PID.GetPatientName(0).GivenName.Value);
        }

        [Test]
        public void Parse_V251_ORM_O01_WithCustomEvnSegment()
        {
            var message =
                "MSH|^~\\&|sys1|sys1|sys2|sys2|20180503174921||ORM^O01|1234567890|P|2.5.1\r"
              + "EVN||20180503\r"
              + "PID|||1^^^XXX~2^^^YYY||LastName^FirstName||19660429|F\r"
              + "PV1||I|3906||||||||||||||||100001\r"
              + "ORC|CA|1410|3121||CA\r"
              + "OBR|1|1410|3121|RX50^ADDOME SUPINO";

            var parser = new PipeParser();

            var result = parser.Parse(message);

            var orm = result as NHapi.Model.V251.Message.ORM_O01;

            Assert.IsNotNull(orm);
            Assert.AreEqual("FirstName", orm.PATIENT.PID.GetPatientName(0).GivenName.Value);
        }

        #endregion
    }
}