namespace PhotographerExercise
{
    using Data;
    using Models;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {

            var context = new Data.PhotoContext();
            var pesho = context.Photographers.FirstOrDefault(p => p.Username == "Peshkata");
            var summerAlbum = context.Albums.FirstOrDefault(a => a.Name == "Summer2017");

            PhotographerAlbum ph = new PhotographerAlbum()
            { 
                Photographer_Id = pesho.PhotographerId,
                Album_Id = summerAlbum.AlbumId,
                Role = Role.Viewer
            };

            //context.Photographers.Add(ph); should work but there is dependency between photo system and photo exercise and thats why doesnt work

            context.PhotographerAlbums.Add(ph);
            context.SaveChanges();
            //var tag = new Tag()
            //{
            //    Name = "asdasd  asd asd"
            //};

            //context.Tags.Add(tag);

            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    tag.Name = TagTransformer.Transform(tag.Name);
            //    context.SaveChanges();
            //    Console.WriteLine("Successfuly transform tag!");
            //}

            //context.Database.Initialize(true);
        }
    }
}
