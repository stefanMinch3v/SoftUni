namespace Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("name=ProductContext")
        {
            Database.SetInitializer(new InitializeWithThreeProducts());// my own strategy for initiaizing db with products
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}