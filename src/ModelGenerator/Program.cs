namespace ModelGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var command = Args.Configuration.Configure<ModelBuilder>().CreateAndBind(args);
            command.Execute();
        }
    }
}