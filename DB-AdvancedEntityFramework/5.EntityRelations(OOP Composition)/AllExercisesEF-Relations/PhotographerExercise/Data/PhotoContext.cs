namespace PhotographerExercise.Data
{
    using PhotographerExercise.Migrations;
    using PhotographerExercise.Models;
    using PhotographerSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotoContext : DbContext
    {
        // Your context has been configured to use a 'PhotoContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PhotographerExercise.Data.PhotoContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PhotoContext' 
        // connection string in the application configuration file.
        public PhotoContext()
            : base("name=PhotoContext")
        {
           //Database.SetInitializer(new DropCreateDatabaseAlways<PhotoContext>());
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotoContext, Configuration>());
            
        }
        public virtual DbSet<Photographer> Photographers { get; set; }

        public virtual DbSet<Album> Albums { get; set; }

        public virtual DbSet<Picture> Pictures { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<PhotographerAlbum> PhotographerAlbums { get; set; }
    }
}