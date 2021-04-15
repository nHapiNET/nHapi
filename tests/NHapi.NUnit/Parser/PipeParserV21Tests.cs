namespace NHapi.NUnit.Parser
{
    using System;
    using System.Collections.Generic;

    using global::NUnit.Framework;

    using NHapi.Base.Parser;
    using NHapi.Model.V21.Datatype;
    using NHapi.Model.V21.Message;

    [TestFixture]
    public class PipeParserV21Tests
    {
        [Test]
        public void ParseADTA01()
        {
            var message = "MSH|^~\\&|ADT|Admitting|RADIO|ARTEFACT|200710061035||ADT^A01|00000040|P|2.1\r"
                        + "EVN|A01|200710061035\r"
                        + "PID||1144270^4^M10|0699999^2^M10||XXXXXX|XXXCXCXX|20071006|F|||10 THE ADDRESS||(450)999-9999|||S||||||||||||||N\r"
                        + "NK1|1\r"
                        + "PV1||I|19^D415^01P|05|07008496||180658^DOCTOR NAME|||81|||||||180658^DOCTOR NAME|NN||01||||||||||||||||||||||||200710061018\r"
                        + "DG1|1|I9|412|NAISSANCE||01\r"
                        + "Z01|1||S|NOUVEAU-NE||FATHER NAME^D|||||0||||A||||||N|||1|GFATHER NAME|G-PERE||(450)432-9999|21||S||20071006101800||N||0||||0000000000||||||||00000000000000|00000000||||||||||01|00000000|00000000000000|05|00|75017|00|00|||||||||||||||||||000000000|000000000|||00000000000000|||01|0";

            var parser = new PipeParser();

            var m = parser.Parse(message);

            var parsedMessage = m as ADT_A01;

            Assert.IsNotNull(parsedMessage);
            Assert.AreEqual("1144270", parsedMessage.PID.PATIENTIDEXTERNALEXTERNALID.IDNumber.Value);
        }

        /// <summary>
        /// https://github.com/nHapiNET/nHapi/issues/135.
        /// </summary>
        [TestCaseSource(nameof(validV21ValueTypes))]
        public void TestObx5DataTypeIsSetFromObx2_AndAllDataTypesAreConstructable(Type expectedObservationValueType)
        {
            var message =
                "MSH|^~\\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.1|||AL|||ASCII\r"
              + "PID|1||1711114||Appt^Test||19720501||||||||||||001020006\r"
              + "ORC|||||F\r"
              + "OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F\r"
             + $"OBX|1|{expectedObservationValueType.Name}|||{expectedObservationValueType.Name}Value||||||F\r";

            var parser = new PipeParser();

            var parsed = (ORU_R01)parser.Parse(message);

            var actualObservationValueInstance = parsed.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.OBSERVATIONRESULTS.Data;

            Assert.IsAssignableFrom(expectedObservationValueType, actualObservationValueInstance);
        }

        /// <summary>
        /// Specified in Table 0125.
        /// </summary>
        private static IEnumerable<Type> validV21ValueTypes = new List<Type>
        {
            typeof(AD),
            typeof(CE),
            typeof(CK),
            typeof(CN),
            typeof(DT),
            typeof(FT),
            typeof(NM),
            typeof(PN),
            typeof(ST),
            typeof(TM),
            typeof(TN),
            typeof(TS),
            typeof(TX),
        };
    }
}