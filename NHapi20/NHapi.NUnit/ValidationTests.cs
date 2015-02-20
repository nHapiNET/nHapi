using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.validation.impl;
using NHapi.Model.V251.Datatype;
using NHapi.Model.V251.Message;
using NUnit.Framework;

namespace NHapi.NUnit
{
	[TestFixture]
	public class ValidationTests
	{
		public string GetNegativeNumberMessage()
		{
			return @"MSH|^~\&|XPress Arrival||||200610120839||ORU^R01|EBzH1711114101206|P|2.5.1|||AL|||ASCII
PID|1||1711114||Appt^Test||19720501||||||||||||001020006
ORC|||||F
OBR|1|||ehipack^eHippa Acknowlegment|||200610120839|||||||||00002^eProvider^Electronic|||||||||F
OBX|1|SI|||-1||||||F";
		}
		
		[Test]
		public void TestStrictValidation_NegativeNumber()
		{
			var parser = new PipeParser();
			ORU_R01 oru;
			
			// default validation context should pass with no exceptions
			oru = (ORU_R01) parser.Parse(GetNegativeNumberMessage());
			foreach (var obs in oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION().OBX.GetObservationValue())
			{
				Assert.IsTrue(obs.Data is SI);
			}

			// strict validation context should throw a DataTypeException for negative number values in a SI field.
			parser.ValidationContext = new StrictValidation();
			Assert.Throws<DataTypeException>(() =>
			{
				oru = (ORU_R01)parser.Parse(GetNegativeNumberMessage());
			}, string.Format("Strict validation should throw a {0} when parsing a SI field with a negative value", typeof(DataTypeException).Name));
		}

		[Test]
		public void TestStrictValidation_NMFields_ContainOnlyNumbers()
		{

		}
	}
}
