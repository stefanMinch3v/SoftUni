namespace Data
{
    using System.Data.Entity;
    using Models;

    /// <summary>
    /// Here we can use our own strategy whatever we want, just override the seed command and execute first our code then invoke the base Seed
    /// </summary>
    public class InitializedAndSeed : DropCreateDatabaseAlways<MoviesContext>
    {
        protected override void Seed(MoviesContext context)
        {
            /*
            var directorStallone = new Director()
            {
                FirstName = "Silvester",
                LastName = "Stallone"
            };

            var directorSeagal = new Director()
            {
                FirstName = "Steven Seagal"
            };

            var movieNikko = new Movie()
            {
                Title = "Nikko",
                Genre = "Action",
                Rating = 7.6f,
                YearOfRelease = 1990,
                Director = directorSeagal
            };

            var movieExpandables = new Movie()
            {
                Title = "Expandables",
                Genre = "Action",
                Rating = 8f,
                YearOfRelease = 2013,
                Director = directorStallone
            };

            var movieRocky = context.Movies.Add(new Movie()
            {
                Title = "Rocky 5",
                Genre = "Action",
                Rating = 9.5f,
                YearOfRelease = 2002,
                Director = directorStallone
            });

            //automatically add the directors in the db because it sees that each movie is depend on director and will create first all of them
            context.Movies.Add(movieExpandables);
            context.Movies.Add(movieRocky);
            context.Movies.Add(movieNikko);

            context.SaveChanges();

            base.Seed(context);
            */
        }
    }
}
