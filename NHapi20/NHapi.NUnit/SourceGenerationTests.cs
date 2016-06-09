using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelGenerator;
using NUnit.Framework;

namespace NHapi.NUnit
{
	[TestFixture]
	public class SourceGenerationTests
	{
		[Test, Explicit]
		public void Test_Generate_251()
		{
			var builder = new ModelBuilder();
			builder.BasePath = @"D:\Checkouts\duane\nHapi_superduperclean_codegen\nhapi\NHapi20";
			builder.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\hl7_72_HQ.mdb;";
			builder.MessageTypeToBuild = ModelBuilder.MessageType.EventMapping;
			builder.Version = "2.5.1";

			builder.Execute();
		}
	}
}
