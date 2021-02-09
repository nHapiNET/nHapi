namespace NHapi.NUnit
{
    using System;

    using global::NUnit.Framework;

    using NHapi.Base.Parser;
    using NHapi.Model.V231.Message;

    [TestFixture]
    public class PipeParsingORM
    {
        private const string MessageORMSample =
            @"MSH|^~\&|HIS|MedCenter|LIS|MedCenter|20060307110114||ORM^O01|MSGID20060307110114|P|2.3.1
PID|||12001||Jones^John^^^Mr.||19670824|M|||123 West St.^^Denver^CO^80020^USA|||||||
PV1||O|OP^PAREG^||||2342^Jones^Bob|||OP|||||||||2|||||||||||||||||||||||||20060307110111|
ORC|NW|20060307110114
OBR|1|20060307110114||003038^Urinalysis^L|||20060307110114";

        [Test]
        public void TestORMDescriptionExtract()
        {
            var parser = new PipeParser();
            var results = parser.Parse(MessageORMSample.Replace(Environment.NewLine, "\r"));
            var typed = results as ORM_O01;

            Assert.AreEqual(typed.PATIENT.PID.DateTimeOfBirth.Description, @"Date/Time Of Birth");
        }
    }
}
