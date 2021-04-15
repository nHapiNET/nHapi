namespace NHapi.NUnit.Parser
{
    using global::NUnit.Framework;

    using NHapi.Base.Parser;

    /// <summary>
    /// Fixes https://github.com/nHapiNET/nHapi/issues/101.
    /// </summary>
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

        /// <summary>
        ///  fixes https://github.com/nHapiNET/nHapi/issues/51.
        /// </summary>
        [Test]
        public void Parse_V251_RDE_O11()
        {
            var message =
                "MSH|^~\\&|EXACTDATA||ALL|ALL|20101217181500||RDE^O11^RDE_O11|EF010000000071000000_4|T^T|2.5.1\r"
              + "PID|1||7010566270^^^^DODID~EM010000008000000^^^^MR||ZZEDConner^Dean^J^^Mr.||19810611|MALE||WHITE^^HL70005|^^^^^USA^H||||ENGLISH^^HL70296|SINGLE^^HL70002||EF010000000071000000||||NOTHISPANICORLATINO^^HL70189|||||ACTIVEDUTY^^HL70172\r"
              + "PV1|1|OUTPATIENT|^^^MBCC^^AMBLOC||||1853210951^Pennington^Zachary|||MEDICINEGENERAL|||||||1853210951^Pennington^Zachary|||||||||||||||||||01|||||ACTIVE|||20101217181500|20101217184500||||||V\r"
              + "PV2|||V70.0^General medical examination^I9C|||||||||||||||||||||||||||||||||||||||||N\r"
              + "AL1|1|DRUG^^HL70127|70618^Penicillin^RXNORM|MODERATE^^HL70128|Dry Mouth|20100928\r"
              + "ORC|NW|101217-833651^ExD|||ORDERED\r"
              + "RXE|^^^20101217184500|54569-4888-0^Oseltamivir|1||75 mg||^po bid x 5d||N|10||0||||||||||||||||||||20101217184500\r"
              + "RXR|^Oral^HL70162";

            var parser = new PipeParser();

            var result = parser.Parse(message);

            var rdeO11 = result as NHapi.Model.V251.Message.RDE_O11;

            Assert.IsNotNull(rdeO11);
            Assert.AreEqual("Oral", rdeO11.GetORDER().GetRXR().Route.Text.Value);
            Assert.AreEqual("HL70162", rdeO11.GetORDER().GetRXR().Route.NameOfCodingSystem.Value);
        }

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