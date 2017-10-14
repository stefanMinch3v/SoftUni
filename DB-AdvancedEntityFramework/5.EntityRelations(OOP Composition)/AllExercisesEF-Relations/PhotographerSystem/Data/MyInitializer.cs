namespace PhotographerSystem.Data
{
    using PhotographerSystem.Models;
    using System;
    using System.Data.Entity;

    public class MyInitializer : DropCreateDatabaseAlways<PhotograptherContext>
    {
        protected override void Seed(PhotograptherContext context)
        {
            Photographer pesho = new Photographer()
            {
                Username = "Peshkata",
                Password = "nai qkata heshirana parola",
                Email = "pesho@abv.bg",
                RegisterDate = DateTime.Now
            };

            Photographer gosho = new Photographer()
            {
                Username = "Gogata",
                Password = "moqta e po qka",
                Email = "gogo@abv.bg",
                RegisterDate = DateTime.Now
            };

            Photographer ivan = new Photographer()
            {
                Username = "Vankata",
                Password = "apyk moqta e nai qka",
                Email = "vanio@abv.bg",
                RegisterDate = DateTime.Now
            };

            context.Photographers.Add(pesho);
            context.Photographers.Add(gosho);
            context.Photographers.Add(ivan);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
