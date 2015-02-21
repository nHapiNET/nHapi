using Microsoft.Test.CommandLineParsing;

namespace ModelGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelBuilder builder = new ModelBuilder();
            CommandLineParser.ParseArguments(builder, args);
            builder.Execute();
            

            
        }


    }
}
