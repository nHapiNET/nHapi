namespace NHapi.NUnit
{
    using System;

    using global::NUnit.Framework;

    using NHapi.Base;
    using NHapi.Base.Parser;
    using NHapi.Base.Validation.Implementation;
    using NHapi.Model.V251.Datatype;
    using NHapi.Model.V251.Message;

    [TestFixture]
    public class ValidationTests
    {
        private const string MessageSINegativeNumber =
            @"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5.1|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|SI|||-1||||||F";

        [Test]
        public void TestStrictValidation_NegativeNumber()
        {
            var message = MessageSINegativeNumber.Replace(Environment.NewLine, "\r");

            var parser = new PipeParser();

            // default validation context should pass with no exceptions
            var oru = (ORU_R01)parser.Parse(message);
            foreach (var obs in oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION().OBX.GetObservationValue())
            {
                Assert.That(obs.Data, Is.InstanceOf<SI>());
            }

            // strict validation context should throw a DataTypeException for negative number values in a SI field.
            parser.ValidationContext = new StrictValidation();
            Assert.That(
                () => (ORU_R01)parser.Parse(message),
                Throws.TypeOf<DataTypeException>(),
                $"Strict validation should throw a {nameof(DataTypeException)} when parsing a SI field with a negative value");
        }

        private const string MessageNMAlpha =
            @"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5.1|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|NM|||Hello||||||F";

        private const string MessageNMChar =
            @"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5.1|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|NM|||!@#$||||||F";

        private const string MessageNMNumber =
            @"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5.1|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|NM|||10||||||F";

        private const string MessageNMNegativeNumber =
            @"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5.1|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|NM|||-1||||||F";

        private const string MessageNMDecimal =
            @"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5.1|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|NM|||1.5||||||F";

        [TestCase(MessageNMAlpha, true)]
        [TestCase(MessageNMChar, true)]
        [TestCase(MessageNMNumber, false)]
        [TestCase(MessageNMNegativeNumber, false)]
        [TestCase(MessageNMDecimal, false)]
        public void TestStrictValidation_NMFields_ValidNumbers(string testMessage, bool shouldThrow)
        {
            testMessage = testMessage.Replace(Environment.NewLine, "\r");

            var parser = new PipeParser();

            parser.ValidationContext = new StrictValidation();
            var message =
                $"Strict validation {(shouldThrow ? "should" : "should not")} throw a {nameof(DataTypeException)} when parsing a NM field with alpha values";

            if (shouldThrow)
            {
                Assert.That(() => (ORU_R01)parser.Parse(testMessage), Throws.TypeOf<DataTypeException>(), message);
            }
            else
            {
                Assert.That(() => (ORU_R01)parser.Parse(testMessage), Throws.Nothing, message);
            }
        }
    }
}