namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Data.Migrations;

    public class SalesContext : DbContext
    {
        public SalesContext()
            : base("name=SalesContext")
        {
            //Database.SetInitializer(new InitializeStrategyWtihFiveEntries());//my own strategy
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SalesContext, Configuration>()); //turn on the automatic migrations
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }

        public virtual DbSet<StoreLocation> StoreLocations { get; set; }
    }
}