namespace Client
{
    using Data;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var context = new FootballContext();
            context.Database.Initialize(true);
        }
    }
}
