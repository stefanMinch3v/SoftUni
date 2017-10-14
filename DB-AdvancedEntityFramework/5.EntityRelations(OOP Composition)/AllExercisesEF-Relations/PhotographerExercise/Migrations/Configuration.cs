namespace PhotographerExercise.Migrations
{
    using PhotographerSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotographerExercise.Data.PhotoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "PhotographerExercise.Data.PhotoContext";
        }

        protected override void Seed(PhotographerExercise.Data.PhotoContext context)
        {
            //var pesho = new Photographer()
            //{
            //    Username = "Peshkata",
            //    Password = "nai qkata heshirana parola",
            //    Email = "pesho@abv.bg",
            //    RegisterDate = DateTime.Now
            //};

            //context.Photographers.AddOrUpdate(x => x.Username, pesho);

            //var gosho = new Photographer()
            //{
            //    Username = "Gogata",
            //    Password = "moqta e po qka",
            //    Email = "gogo@abv.bg",
            //    RegisterDate = DateTime.Now
            //};

            //context.Photographers.AddOrUpdate(x => x.Username, gosho);

            //var ivan = new Photographer()
            //{
            //    Username = "Vankata",
            //    Password = "apyk moqta e nai qka",
            //    Email = "vanio@abv.bg",
            //    RegisterDate = DateTime.Now
            //};

            //context.Photographers.AddOrUpdate(x => x.Username, ivan);
            //context.SaveChanges();

            //var pictureSummer = new Picture()
            //{
            //    Title = "IMG2017",
            //    Caption = "Something...",
            //    Path = "c:/dekstop.....blabla"
            //};

            //context.Pictures.AddOrUpdate(p => p.Title, pictureSummer);

            //var pictureSummer2 = new Picture()
            //{
            //    Title = "IMG2017234",
            //    Caption = "Something...",
            //    Path = "c:/dekstop.....blabla"
            //};

            //context.Pictures.AddOrUpdate(p => p.Title, pictureSummer2);

            //var pictureWinter = new Picture()
            //{
            //    Title = "IMG201112347",
            //    Caption = "Something...",
            //    Path = "c:/dekstop.....blabla"
            //};

            //context.Pictures.AddOrUpdate(p => p.Title, pictureWinter);

            //var pictureWinter2 = new Picture()
            //{
            //    Title = "IMG20172312314",
            //    Caption = "Something...",
            //    Path = "c:/dekstop.....blabla"
            //};

            //context.Pictures.AddOrUpdate(p => p.Title, pictureWinter2);
            //context.SaveChanges();

            //var albumSummer = new Album()
            //{
            //    Name = "Summer2017",
            //    BackgroundColor = BackgroundColor.Blue,
            //    PublicOrPrivate = PublicOrPrivate.Public
            //};

            //context.Albums.AddOrUpdate(a => a.Name, albumSummer);

            //var albumWinter = new Album()
            //{
            //    Name = "Winter2017",
            //    BackgroundColor = BackgroundColor.Red,
            //    PublicOrPrivate = PublicOrPrivate.Public
            //};

            //context.Albums.AddOrUpdate(a => a.Name, albumWinter);
            //context.SaveChanges();

            ////relations
            //albumSummer.Pictures.Add(pictureSummer);
            //albumSummer.Pictures.Add(pictureSummer2);

            //albumWinter.Pictures.Add(pictureWinter);
            //albumWinter.Pictures.Add(pictureWinter2);

            //context.SaveChanges();

            //pesho.Albums.Add(albumSummer);
            //gosho.Albums.Add(albumWinter);

            //context.SaveChanges();

            //Tag tagSummer = new Tag()
            //{
            //    Name = "#Summertime"
            //};

            //context.Tags.AddOrUpdate(t => t.Name, tagSummer);

            //tagSummer.Albums.Add(albumSummer);
            //context.SaveChanges();
        }
    }
}
