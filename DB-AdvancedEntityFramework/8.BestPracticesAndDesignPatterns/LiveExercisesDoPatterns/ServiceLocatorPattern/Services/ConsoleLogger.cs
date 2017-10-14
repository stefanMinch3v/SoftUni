
namespace ServiceLocatorPattern.Services
{
    public class ConsoleLogger : Logger
    {
        public override void Log(string line)
        {
            System.Console.WriteLine(line);
        }
    }
}
