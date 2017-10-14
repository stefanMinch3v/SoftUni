namespace PhotographerSystem.Data
{
    using PhotographerSystem.Migrations;
    using PhotographerSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotograptherContext : DbContext
    {
        public PhotograptherContext()
            : base("name=PhotograptherContext")
        {
            //Database.SetInitializer(new MyInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotograptherContext, Configuration>());
        }

        public virtual DbSet<Photographer> Photographers { get; set; }

        public virtual DbSet<Album> Albums { get; set; }

        public virtual DbSet<Picture> Pictures { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

    }
}