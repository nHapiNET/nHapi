using System;
using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Model.V21.Message;
using NUnit.Framework;

namespace NHapi.NUnit
{
	[TestFixture]
	public class PipeParsingFixture21
	{
		[Test]
		public void ParseADTA01()
		{
			string message = @"MSH|^~\&|ADT|Admitting|RADIO|ARTEFACT|200710061035||ADT^A01|00000040|P|2.1
EVN|A01|200710061035
PID||1144270^4^M10|0699999^2^M10||XXXXXX|XXXCXCXX|20071006|F|||10 THE ADDRESS||(450)999-9999|||S||||||||||||||N
NK1|1
PV1||I|19^D415^01P|05|07008496||180658^DOCTOR NAME|||81|||||||180658^DOCTOR NAME|NN||01||||||||||||||||||||||||200710061018
DG1|1|I9|412|NAISSANCE||01
Z01|1||S|NOUVEAU-NE||FATHER NAME^D|||||0||||A||||||N|||1|GFATHER NAME|G-PERE||(450)432-9999|21||S||20071006101800||N||0||||0000000000||||||||00000000000000|00000000||||||||||01|00000000|00000000000000|05|00|75017|00|00|||||||||||||||||||000000000|000000000|||00000000000000|||01|0";

			PipeParser parser = new PipeParser();

			IMessage m = parser.Parse(message);

			ADT_A01 parsedMessage = m as ADT_A01;

			Assert.IsNotNull(parsedMessage);
			Assert.AreEqual("1144270", parsedMessage.PID.PATIENTIDEXTERNALEXTERNALID.IDNumber.Value);
		}
	}
}