namespace PhotoShare.Client
{
    using PhotoShare.Client.Core;

    public class Startup
    {
        public static void Main()
        {
            CommandDispatcher commandDispatcher = new CommandDispatcher();
            Engine engine = new Engine(commandDispatcher);
            engine.Run();
        }
    }
}
