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

        /// <summary>
        ///  Fixes https://github.com/nHapiNET/nHapi/issues/72.
        /// </summary>
        [Test]
        public void Parse_V23_ADT_A01()
        {
            var message =
                "MSH|^~\\&|V500|01010|TEST|TEST|20170130125848||ADT^A01|12345||2.3||||||8859/1\r"
                + "EVN|A01|20170130125600|||12345|20170130125600\r"
                + "PID|1|12345^^^PATIENT MASTER^MRN^|12345^^^PATIENT MASTER^MRN^||TEST||20101114|F||4|16 Bothar Na Tra^^Ireland^^^1101^home^^||||2303|1||12345^^^EPISODE NUMBER^FIN NBR^|12312312310||||||0|Not Known / Not Stated||1101||\r"
                + "PV1|1|I|TEST^08^011^A207^^Bed(s)^A207|01||^^^^^^|0121212J^Stephen^Peter^J^^Dr^^^Doctor Provider Number^Personnel^^^DOCUPIN^|||ONC|||1|01|||0121212J^Stephen^Peter^J^^Dr^^^Doctor Provider Number^Personnel^^^DOCUPIN^|8|12345^0^^^Visit Id|5M^20170130125600|||||||||||||||||||B2021||Active|||20170130125600\r"
                + "NK1|1||||0404111111^^^test@test.com||Proxy\r"
                + "NK1|2||||0404111112^^^test2@test.com||Proxy 2";

            var parser = new PipeParser();

            var adtA01 = (NHapi.Model.V23.Message.ADT_A01)parser.Parse(message);
            var allNextOfKin = adtA01.GetAll("NK12");

            Assert.That(allNextOfKin, Is.Not.Null);
            Assert.That(allNextOfKin, Is.Not.Empty);
            Assert.Multiple(() =>
            {
                Assert.That(
                            ((Model.V23.Segment.NK1)allNextOfKin[0]).GetPhoneNumber(0).EmailAddress.Value, Is.EqualTo("test@test.com"));
                Assert.That(
                    ((Model.V23.Segment.NK1)allNextOfKin[1]).GetPhoneNumber(0).EmailAddress.Value, Is.EqualTo("test2@test.com"));
            });
        }

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

            Assert.That(orm, Is.Not.Null);
            Assert.That(orm.PATIENT.PID.GetPatientName(0).GivenName.Value, Is.EqualTo("FirstName"));
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

            Assert.That(orm, Is.Not.Null);
            Assert.That(orm.PATIENT.PID.GetPatientName(0).GivenName.Value, Is.EqualTo("FirstName"));
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

            Assert.That(orm, Is.Not.Null);
            Assert.That(orm.PATIENT.PID.GetPatientName(0).GivenName.Value, Is.EqualTo("FirstName"));
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

            Assert.That(orm, Is.Not.Null);
            Assert.That(orm.PATIENT.PID.GetPatientName(0).GivenName.Value, Is.EqualTo("FirstName"));
        }

        #endregion

        #region v25

        /// <summary>
        ///  Fixes https://github.com/nHapiNET/nHapi/issues/55.
        /// </summary>
        [Test]
        public void Parse_V25_OUL_R22()
        {
            var message =
                "MSH|^~\\&|XXX|LIFE|YYY|EFIL|20160804220502.3210+0100||OUL^R22^OUL_R22|HL7Gtw01565728BAF100|P|2.5||||||8859/1\r"
              + "PID|1||11^^^PK^PK~15.478.857-3^^^CF^NNITA~15478857-3^^^CS^SS~2000091931^^^LIS^LIS||TEST@PINO^TEST TEST||19880218|M|||||28888888^PRN^PH^^^^^^^^^28888888|||||15.478.857-3|15478857-3\r"
              + "PV1|1|I|100^^^^^^^^DiagnomedLab||||||||||||||||109101|||||||||||||||||||||||||20160804\r"
              + "SPM|1|2007402901||15^Suero|||||||||||||20160804000000\r"
              + "OBR|1|109101-1|20074029^DN^109101-20074029-201608040000|0302047^GLUCOSA^DN^0302047@1^^DN|||201608040000|||||||||admin241-1||||||||LAB-1|C||^^^201608040000\r"
              + "ORC|SC|109101-1|20074029^DN^109101-20074029-201608040000|109101^DN|CM||^^^201608040000||20160804160500|||admin241-1|||||||||DiagnomedLab^^^^^^FI^^^100\r"
              + "TQ1|1||||||201608040000||R\r"
              + "OBX|1|NM|0302047^GLUCOSA^DN^0302047@1^^DN||85^^Hexoquinasa^false|mg/dL|70 - 100|false||0302047|C|||20160804160300||Utente Demo^Sin RUT\r"
              + "SPM|2|2007402902||15^Suero|||||||||||||20160804000000\r"
              + "OBR|1|109101-2|20074029^DN^109101-20074029-201608040000|0302060^ALBUMINA^DN^0302060@1^^DN|||201608040000|||||||||admin241-1||||||||LAB-1|C||^^^201608040000\r"
              + "ORC|SC|109101-2|20074029^DN^109101-20074029-201608040000|109101^DN|CM||^^^201608040000||20160804160500|||admin241-1|||||||||DiagnomedLab^^^^^^FI^^^100\r"
              + "TQ1|1||||||201608040000||R\r"
              + "OBX|1|NM|0302060^ALBUMINA^DN^0302060@1^^DN||4.5^^BCP Mod.^false|g/dL|3.4 - 5|false||0302060|C|||20160804160300||Utente Demo^Sin RUT\r"
              + "OBR|2|109101-3|20074029^DN^109101-20074029-201608040000|0303024^HORMONA TIROESTIMULANTE^DN^0303024@1^^DN|||201608040000|||||||||admin241-1||||||||LAB-1|C||^^^201608040000\r"
              + "ORC|SC|109101-3|20074029^DN^109101-20074029-201608040000|109101^DN|CM||^^^201608040000||20160804160500|||admin241-1|||||||||DiagnomedLab^^^^^^FI^^^100\r"
              + "TQ1|1||||||201608040000||R\r"
              + "OBX|1|NM|0303024^HORMONA TIROESTIMULANTE^DN^0303024@1^^DN||4.1^^Quimioluminiscencia^false|uUI/mL|0.35 - 5.5|false||0303024|C|||20160804160300||Utente Demo^Sin RUT\r"
              + "OBR|3|109101-4|20074029^DN^109101-20074029-201608040000|0303027^TIROXINA (T4)^DN^0303027@1^^DN|||201608040000|||||||||admin241-1||||||||LAB-1|C||^^^201608040000\r"
              + "ORC|SC|109101-4|20074029^DN^109101-20074029-201608040000|109101^DN|CM||^^^201608040000||20160804160500|||admin241-1|||||||||DiagnomedLab^^^^^^FI^^^100\r"
              + "TQ1|1||||||201608040000||R\r"
              + "OBX|1|NM|0303027^TIROXINA (T4)^DN^0303027@1^^DN||13^^Quimioluminiscencia^false|ug/dL|4.5 - 12.5|false||0303027|C|||20160804160300||Utente Demo^Sin RUT\r"
              + "SPM|3|2007402903||14^Sangre|||||||||||||20160804000000\r"
              + "OBR|1|109101-5|20074029^DN^109101-20074029-201608040000|0301041^HEMOGLOBINA GLICOSILADA^DN^0301041@1^^DN|||201608040000|||||||||admin241-1||||||||LAB-1|C||^^^201608040000\r"
              + "ORC|SC|109101-5|20074029^DN^109101-20074029-201608040000|109101^DN|CM||^^^201608040000||20160804160500|||admin241-1|||||||||DiagnomedLab^^^^^^FI^^^100\r"
              + "TQ1|1||||||201608040000||R\r"
              + "OBX|1|NM|0301041^HEMOGLOBINA GLICOSILADA^DN^0301041@1^^DN||5.3^^HPLC-Tosoh G8^false|%|No Diab\\X00E9\\tico\\X000D\\.sp\\Diab\\X00E9\\tico bien controlado: <7.0\\X000D\\.sp\\Diab\\X00E9\\tico medio controlado: 7.00 - 8.00\\X000D\\.sp\\Diab\\X00E9\\tico mal controlado: >8.00|false||0301041|C|||20160804160300||Utente Demo^Sin RUT";

            var parser = new PipeParser();

            var result = parser.Parse(message);

            var oulR22 = result as NHapi.Model.V25.Message.OUL_R22;

            Assert.That(oulR22, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(oulR22.SPECIMENRepetitionsUsed, Is.EqualTo(3));
                Assert.That(oulR22.GetSPECIMEN(0).ORDERRepetitionsUsed, Is.EqualTo(1));
                Assert.That(oulR22.GetSPECIMEN(1).ORDERRepetitionsUsed, Is.EqualTo(3));
                Assert.That(oulR22.GetSPECIMEN(2).ORDERRepetitionsUsed, Is.EqualTo(1));
            });
        }

        /// <summary>
        ///  Fixes https://github.com/nHapiNET/nHapi/issues/56.
        /// </summary>
        [Test]
        public void Parse_V25_OML_033()
        {
            var message =
                "MSH|^~\\&|xxxx|homxtest_9||homxtest_9|20160205112211||OML^O33|000500006894|P|2.5|||NE|AL||8859/15\r"
                + "PID|1||1234567^^^Firstname~lastname^^^Firstname||Lastname&&Lastname^Firstname^B L J^^^^L||19991231|M|||Firstname^37^BE^^1234AB^nl|||||||||||||Y||||||N\r"
                + "SPM|1|1602050005&xxxx||EDTA^Paarse dop^xxxx||||||||3^ml&ml&xxxx|||||20160205111800|||N|||||||01^01^xxxx^paars^01\r"
                + "ORC|NW|1602-0006^xxxx|||IP||^^^20160205111800^^R||20160205112211||||^^^^^^^^^^xxxx\r"
                + "OBR|1|1602-0006^xxxx||Na^Natrium^xxxx|||20160421114000||0^ml&ml&xxxx||||||EDTA^Paarse dop&xxxx|||||||20160205112211||A|I||^^^20160205111800^^S\r"
                + "SPM|2|1602050004&xxxx||Citrate^Blauwe dop^xxxx||||||||0^ml&ml&xxxx|||||20160205111800|||N|||||||08^08^xxxx^blauw^08\r"
                + "ORC|NW|1602-0006^xxxx|||IP||^^^20160205111800^^R||20160205112211||||^^^^^^^^^^xxxx\r"
                + "OBR|2|1602-0006^xxxx||Na^Natrium^xxxx|||20160421114000||0^ml&ml&xxxx||||||Citrate^Blauwe dop&xxx|||||||20160205112211||A|I||^^^20160205111800^^S";

            var parser = new PipeParser();

            var result = parser.Parse(message);

            var oulR22 = result as NHapi.Model.V25.Message.OML_O33;

            Assert.That(oulR22, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(oulR22.SPECIMENRepetitionsUsed, Is.EqualTo(2));
                Assert.That(oulR22.GetSPECIMEN(0).ORDERRepetitionsUsed, Is.EqualTo(1));
                Assert.That(oulR22.GetSPECIMEN(1).ORDERRepetitionsUsed, Is.EqualTo(1));
            });
        }

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

            Assert.That(orm, Is.Not.Null);
            Assert.That(orm.PATIENT.PID.GetPatientName(0).GivenName.Value, Is.EqualTo("FirstName"));
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

            Assert.That(orm, Is.Not.Null);
            Assert.That(orm.PATIENT.PID.GetPatientName(0).GivenName.Value, Is.EqualTo("FirstName"));
        }

        #endregion

        #region v251

        /// <summary>
        /// Fixes https://github.com/nHapiNET/nHapi/issues/51.
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

            Assert.That(rdeO11, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(rdeO11.GetORDER().GetRXR().Route.Text.Value, Is.EqualTo("Oral"));
                Assert.That(rdeO11.GetORDER().GetRXR().Route.NameOfCodingSystem.Value, Is.EqualTo("HL70162"));
            });
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

            Assert.That(orm, Is.Not.Null);
            Assert.That(orm.PATIENT.PID.GetPatientName(0).GivenName.Value, Is.EqualTo("FirstName"));
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

            Assert.That(orm, Is.Not.Null);
            Assert.That(orm.PATIENT.PID.GetPatientName(0).GivenName.Value, Is.EqualTo("FirstName"));
        }

        #endregion
    }
}