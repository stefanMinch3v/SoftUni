namespace PhotographerSystem
{
    using PhotographerSystem.Data;

    public class Startup
    {
        public static void Main()
        {
            var context = new PhotograptherContext();
            context.Database.Initialize(true);

        }

        
    }
}
