using Microsoft.Test.CommandLineParsing;

namespace ModelGenerator
{
	public class Program
	{
		public static void Main(string[] args)
		{
			ModelBuilder builder = new ModelBuilder();
			CommandLineParser.ParseArguments(builder, args);
			builder.Execute();
		}
	}
}