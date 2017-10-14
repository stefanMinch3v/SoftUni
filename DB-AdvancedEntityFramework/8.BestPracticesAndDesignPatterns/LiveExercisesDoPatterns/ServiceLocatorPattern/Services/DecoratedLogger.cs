namespace ServiceLocatorPattern.Services
{
    public class DecoratedLogger : Logger
    {
        public override void Log(string line)
        {
            System.Console.WriteLine($"Action received: {line}");
        }
    }
}
