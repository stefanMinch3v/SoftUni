namespace Client
{
    using System;
    using Data;
    using Models;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var context = new MoviesContext();

            #region Initialize Database movies and fill it out with some actors, movies and directors
            //context.Database.Initialize(true);

            //context.Movies.Add(new Movie()
            //{
            //    Title = "Rocky 5",
            //    Genre = "Action",
            //    Rating = 9.5f,
            //    YearOfRelease = 2002,
            //    Director = new Director()
            //    {
            //        FirstName = "Silvester",
            //        LastName = "Stallone"
            //    }
            //});

            //context.SaveChanges();

            //var actorYoung = new Actor()
            //{
            //    FirstName = "Burt",
            //    LastName = "Young",
            //};

            //var actorStatham = new Actor()
            //{
            //    FirstName = "Jason",
            //    LastName = "Statham"
            //};

            //var actorStallone = new Actor()
            //{
            //    FirstName = "Silvester",
            //    LastName = "Stallone"
            //};

            //var actorJetLi = new Actor()
            //{
            //    FirstName = "Jet",
            //    LastName = "Li"
            //};

            //context.Actors.AddRange(new[] { actorStallone, actorStatham, actorYoung, actorJetLi });

            //we can do either actor.add or movie.add and automatically entity will do the mapping connection between them in the DB

            //actorStallone.Movies.Add(context.Movies.Where(m => m.Title == "Expandables").FirstOrDefault());
            //actorStallone.Movies.Add(context.Movies.Where(m => m.Title == "Rocky 5").FirstOrDefault());
            //actorStatham.Movies.Add(context.Movies.Where(m => m.Title == "Expandables").FirstOrDefault());
            //actorYoung.Movies.Add(context.Movies.Where(m => m.Title == "Rocky 5").FirstOrDefault());
            //actorJetLi.Movies.Add(context.Movies.Where(m => m.Title == "Expandables").FirstOrDefault());

            //context.SaveChanges();
            #endregion

            /*context.Genres.Add(new Genre()
            {
                Value = "Action"
            });

            context.Genres.Add(new Genre()
            {
                Value = "Drama"
            });*/


            //context.Movies.FirstOrDefault(m => m.Title == "Rocky 5")
            //              .Genres.Add(context.Genres.FirstOrDefault(m => m.Value == "Action"));
            //context.Movies.FirstOrDefault(m => m.Title == "Rocky 5")
            //              .Genres.Add(context.Genres.FirstOrDefault(m => m.Value == "Drama"));
            //context.Movies.FirstOrDefault(m => m.Title == "Expandables")
            //              .Genres.Add(context.Genres.FirstOrDefault(m => m.Value == "Action"));
            //context.Movies.FirstOrDefault(m => m.Title == "Nikko")
            //              .Genres.Add(context.Genres.FirstOrDefault(m => m.Value == "Action"));
            //context.SaveChanges();

            context.Movies.FirstOrDefault(m => m.Title == "Nikko").DurationInMinutes = 150;
            context.SaveChanges();

            
        }
    }
}
