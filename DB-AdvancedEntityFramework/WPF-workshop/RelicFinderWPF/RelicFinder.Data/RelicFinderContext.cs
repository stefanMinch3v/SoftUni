namespace RelicFinder.Data
{
    using RelicFinder.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RelicFinderContext : DbContext
    {
        public RelicFinderContext()
            : base("name=RelicFinderContext")
        {
            //Database.SetInitializer(new RelicDbInitializer());
        }

        public virtual DbSet<Relic> Relics { get; set; }
    }
}