using System;
using System.Collections;
using System.Text;
using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Model.V23;
using NHapi.Model.V23.Message;
using NHapi.Model.V23.Segment;
using NUnit.Framework;

namespace NHapi.NUnit
{
	/// <summary>
	/// This test case was created from BUG 1812261 on the SourceForge project site
	/// Chad Chenoweth
	/// </summary>
	[TestFixture]
	public class TestMSH3
	{
		[Test]
		public void TestMSH3Set()
		{
			ADT_A01 a01 = new ADT_A01();
			a01.MSH.SendingApplication.UniversalID.Value = "TEST";

			PipeParser parser = new PipeParser();
			string hl7 = parser.Encode(a01);

			string[] data = hl7.Split('|');
			Assert.AreEqual("ADT^A01", data[8]);
		}
	}
}
