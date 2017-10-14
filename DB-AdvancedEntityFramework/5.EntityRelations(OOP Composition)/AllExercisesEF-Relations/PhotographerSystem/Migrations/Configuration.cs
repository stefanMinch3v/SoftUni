namespace PhotographerSystem.Migrations
{
    using PhotographerSystem.Data;
    using PhotographerSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotograptherContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "PhotograptherContext";
        }

        protected override void Seed(PhotographerSystem.Data.PhotograptherContext context)
        {
            Photographer pesho = new Photographer()
            {
                Username = "Peshkata",
                Password = "nai qkata heshirana parola",
                Email = "pesho@abv.bg",
                RegisterDate = DateTime.Now
            };

            //context.Photographers.AddOrUpdate(p => p.Username, pesho);
            context.Photographers.Add(pesho);
            context.SaveChanges();

            Photographer gosho = new Photographer()
            {
                Username = "Gogata",
                Password = "moqta e po qka",
                Email = "gogo@abv.bg",
                RegisterDate = DateTime.Now
            };

            //context.Photographers.AddOrUpdate(p => p.Username, gosho);
            context.Photographers.Add(gosho);
            context.SaveChanges();

            Photographer ivan = new Photographer()
            {
                Username = "Vankata",
                Password = "apyk moqta e nai qka",
                Email = "vanio@abv.bg",
                RegisterDate = DateTime.Now
            };
            
            //context.Photographers.AddOrUpdate(p => p.Username, ivan);
            context.Photographers.Add(ivan);
            context.SaveChanges();

            PutSomePicturesAndAlbums(context);
        }

        private static void PutSomePicturesAndAlbums(PhotograptherContext context)
        {
            var pictureSummer = new Picture()
            {
                Title = "IMG2017",
                Caption = "Something...",
                Path = "c:/dekstop.....blabla"
            };

            context.Pictures.AddOrUpdate(p => p.Title, pictureSummer);
            context.SaveChanges();

            var pictureSummer2 = new Picture()
            {
                Title = "IMG2017234",
                Caption = "Something...",
                Path = "c:/dekstop.....blabla"
            };

            context.Pictures.AddOrUpdate(p => p.Title, pictureSummer2);
            context.SaveChanges();

            var pictureWinter = new Picture()
            {
                Title = "IMG201112347",
                Caption = "Something...",
                Path = "c:/dekstop.....blabla"
            };

            context.Pictures.AddOrUpdate(p => p.Title, pictureWinter);
            context.SaveChanges();

            var pictureWinter2 = new Picture()
            {
                Title = "IMG20172312314",
                Caption = "Something...",
                Path = "c:/dekstop.....blabla"
            };
            
            context.Pictures.AddOrUpdate(p => p.Title, pictureWinter2);
            context.SaveChanges();

            var albumSummer = new Album()
            {
                Name = "Summer2017",
                BackgroundColor = BackgroundColor.Blue,
                PublicOrPrivate = PublicOrPrivate.Public
            };

            context.Albums.AddOrUpdate(a => a.Name, albumSummer);
            context.SaveChanges();

            var albumWinter = new Album()
            {
                Name = "Winter2017",
                BackgroundColor = BackgroundColor.Red,
                PublicOrPrivate = PublicOrPrivate.Public
            };

            context.Albums.AddOrUpdate(a => a.Name, albumWinter);
            context.SaveChanges();

            //relations
            albumSummer.Pictures.Add(pictureSummer);
            albumSummer.Pictures.Add(pictureSummer2);

            albumWinter.Pictures.Add(pictureWinter);
            albumWinter.Pictures.Add(pictureWinter2);

            context.Photographers.FirstOrDefault(p => p.Username == "Peshkata").Albums.Add(albumSummer);
            context.Photographers.FirstOrDefault(p => p.Username == "Gogata").Albums.Add(albumWinter);

            context.SaveChanges();

            Tag tagSummer = new Tag()
            {
                Name = "Summer time"
            };

            context.Tags.AddOrUpdate(t => t.Name, tagSummer);
            context.SaveChanges();

            tagSummer.Albums.Add(albumSummer);
            context.SaveChanges();
        }
    }
}
