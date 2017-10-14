namespace PhotoShare.Client
{
    using Core;
    using PhotoShare.Data;

    public class Startup
    {
        public static void Main()
        {
            //CommandDispatcher commandDispatcher = new CommandDispatcher();
            //Engine engine = new Engine(commandDispatcher);
            //engine.Run();
            var context = new PhotoShareContext();
            context.Database.Initialize(true);
        }
    }
}
