namespace NHapi.NUnit.Parser
{
    using global::NUnit.Framework;

    using NHapi.Base.Parser;
    using NHapi.Model.V231.Message;

    [TestFixture]
    public class LegacyPipeParserORMO01Tests
    {
        private const string MessageORMSample =
            "MSH|^~\\&|HIS|MedCenter|LIS|MedCenter|20060307110114||ORM^O01|MSGID20060307110114|P|2.3.1\r"
        + "PID|||12001||Jones^John^^^Mr.||19670824|M|||123 West St.^^Denver^CO^80020^USA|||||||\r"
        + "PV1||O|OP^PAREG^||||2342^Jones^Bob|||OP|||||||||2|||||||||||||||||||||||||20060307110111|\r"
        + "ORC|NW|20060307110114\r"
        + "OBR|1|20060307110114||003038^Urinalysis^L|||20060307110114";

        [Test]
        public void TestORMDescriptionExtract()
        {
            var parser = new LegacyPipeParser();
            var results = (ORM_O01)parser.Parse(MessageORMSample);

            Assert.That(results.PATIENT.PID.DateTimeOfBirth.Description, Is.EqualTo(@"Date/Time Of Birth"));
        }
    }
}
