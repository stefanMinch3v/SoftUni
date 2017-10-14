namespace Data
{
    using Models;
    using System.Data.Entity;
    public class InitializeWithThreeProducts : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            var productContext = new ProductContext();

            var product = new Product()
            {
                Name = "Waffle-Snickers",
                DistributorName = "Moreny",
                Price = 2.5m
            };

            var product2 = new Product()
            {
                Name = "Bread",
                DistributorName = "MilenaLtd",
                Price = 0.95m
            };

            var product3 = new Product()
            {
                Name = "Chocolate-Milka",
                DistributorName = "Lunii Foods LLC",
                Price = 1.65m
            };

            productContext.Products.Add(product);
            productContext.Products.Add(product2);
            productContext.Products.Add(product3);

            productContext.SaveChanges();

            base.Seed(context);
        }
    }
}
