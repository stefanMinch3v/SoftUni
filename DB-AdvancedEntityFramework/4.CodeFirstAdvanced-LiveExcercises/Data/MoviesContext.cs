namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Migrations;

    public class MoviesContext : DbContext
    {
        public MoviesContext()
            : base("name=MoviesContext")
        {
            //Database.SetInitializer(new InitializedAndSeed()); // custom strategy to initialize DB which is declated in InitializedAndSeed class
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesContext, Configuration>()); // last change for the migration test with config and without writing Update database in the p manager console (Automatically Migrations)
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MoviesContext>())  //drop every time database and create a new one in its place so there wont be any problems, useful in the development period when there arent any entries in the DB, only if there are some changes in the tables for example add new columns or keys!!
        }

        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Director> Directors { get; set; }

        public virtual DbSet<Actor> Actors { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

    }
}