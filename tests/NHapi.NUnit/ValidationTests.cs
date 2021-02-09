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
        public const string MessageSINegativeNumber =
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
            ORU_R01 oru;

            // default validation context should pass with no exceptions
            oru = (ORU_R01)parser.Parse(message);
            foreach (var obs in oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION().OBX.GetObservationValue())
            {
                Assert.IsTrue(obs.Data is SI);
            }

            // strict validation context should throw a DataTypeException for negative number values in a SI field.
            parser.ValidationContext = new StrictValidation();
            Assert.Throws<DataTypeException>(
                () => { oru = (ORU_R01)parser.Parse(message); },
                $"Strict validation should throw a {typeof(DataTypeException).Name} when parsing a SI field with a negative value");
        }

        public const string MessageNMAlpha =
            @"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5.1|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|NM|||Hello||||||F";

        public const string MessageNMChar =
            @"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5.1|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|NM|||!@#$||||||F";

        public const string MessageNMNumber =
            @"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5.1|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|NM|||10||||||F";

        public const string MessageNMNegativeNumber =
            @"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5.1|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|NM|||-1||||||F";

        public const string MessageNMDecimal =
            @"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5.1|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|NM|||1.5||||||F";

        [Test]
        [TestCase(new object[] { MessageNMAlpha, true })]
        [TestCase(new object[] { MessageNMChar, true })]
        [TestCase(new object[] { MessageNMNumber, false })]
        [TestCase(new object[] { MessageNMNegativeNumber, false })]
        [TestCase(new object[] { MessageNMDecimal, false })]
        public void TestStrictValidation_NMFields_ValidNumbers(string testMessage, bool shouldThrow)
        {
            testMessage = testMessage.Replace(Environment.NewLine, "\r");

            var parser = new PipeParser();
            ORU_R01 oru;

            parser.ValidationContext = new StrictValidation();
            string message = string.Format(
                "Strict validation {0} throw a {1} when parsing a NM field with alpha values",
                shouldThrow ? "should" : "should not",
                typeof(DataTypeException).Name);

            if (shouldThrow)
            {
                Assert.Throws<DataTypeException>(() => { oru = (ORU_R01)parser.Parse(testMessage); }, message);
            }
            else
            {
                Assert.DoesNotThrow(() => { oru = (ORU_R01)parser.Parse(testMessage); }, message);
            }
        }
    }
}