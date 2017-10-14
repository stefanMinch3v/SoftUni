namespace Data
{
    using Models;
    using System.Data.Entity;
    using System.Linq;

    public class InitializeStrategyWtihFiveEntries : CreateDatabaseIfNotExists<SalesContext>
    {
        protected override void Seed(SalesContext context)
        {
            var salesContext = new SalesContext();

            AddFiveProducts(salesContext);
            AddFiveCustomers(salesContext);
            AddFiveLocations(salesContext);

            salesContext.SaveChanges();

            AddFiveSales(salesContext);

            salesContext.SaveChanges();

            base.Seed(context);
        }

        private static void AddFiveSales(SalesContext context)
        {
            var sale = new Sale()
            {
                Customer = context.Customers.FirstOrDefault(c => c.CustomerId == 1),
                Product = context.Products.FirstOrDefault(p => p.ProductId == 1),
                StoreLocation = context.StoreLocations.FirstOrDefault(s => s.StoreLocationId == 1)
            };

            var sale2 = new Sale()
            {
                Customer = context.Customers.FirstOrDefault(c => c.CustomerId == 2),
                Product = context.Products.FirstOrDefault(p => p.ProductId == 2),
                StoreLocation = context.StoreLocations.FirstOrDefault(s => s.StoreLocationId == 2)
            };

            var sale3 = new Sale()
            {
                Customer = context.Customers.FirstOrDefault(c => c.CustomerId == 3),
                Product = context.Products.FirstOrDefault(p => p.ProductId == 3),
                StoreLocation = context.StoreLocations.FirstOrDefault(s => s.StoreLocationId == 3)
            };

            var sale4 = new Sale()
            {
                Customer = context.Customers.FirstOrDefault(c => c.CustomerId == 4),
                Product = context.Products.FirstOrDefault(p => p.ProductId == 4),
                StoreLocation = context.StoreLocations.FirstOrDefault(s => s.StoreLocationId == 4)
            };

            var sale5 = new Sale()
            {
                Customer = context.Customers.FirstOrDefault(c => c.CustomerId == 5),
                Product = context.Products.FirstOrDefault(p => p.ProductId == 5),
                StoreLocation = context.StoreLocations.FirstOrDefault(s => s.StoreLocationId == 5)
            };

            context.Sales.Add(sale);
            context.Sales.Add(sale2);
            context.Sales.Add(sale3);
            context.Sales.Add(sale4);
            context.Sales.Add(sale5);
        }

        private static void AddFiveLocations(SalesContext context)
        {
            var storeLocation = new StoreLocation()
            {
                LocationName = "Area-A"
            };

            var storeLocation2 = new StoreLocation()
            {
                LocationName = "Area-B"
            };

            var storeLocation3 = new StoreLocation()
            {
                LocationName = "Area-C"
            };

            var storeLocation4 = new StoreLocation()
            {
                LocationName = "Area-D"
            };

            var storeLocation5 = new StoreLocation()
            {
                LocationName = "Area-E"
            };

            context.StoreLocations.Add(storeLocation);
            context.StoreLocations.Add(storeLocation2);
            context.StoreLocations.Add(storeLocation3);
            context.StoreLocations.Add(storeLocation4);
            context.StoreLocations.Add(storeLocation5);
        }

        private static void AddFiveCustomers(SalesContext context)
        {
            var customer = new Customer()
            {
                //Name = "Pesho",
                Email = "nenormalen@abv.bg"
            };

            var customer2 = new Customer()
            {
                //Name = "Gosho",
                Email = "gogata@abv.bg"
            };

            var customer3 = new Customer()
            {
                //Name = "Rumen",
                Email = "rumkata@abv.bg"
            };

            var customer4 = new Customer()
            {
                //Name = "Stanimir",
                Email = "stambeto@gmail.com"
            };

            var customer5 = new Customer()
            {
                //Name = "Kiril",
                Email = "kikata@edu.org"
            };

            context.Customers.Add(customer);
            context.Customers.Add(customer2);
            context.Customers.Add(customer3);
            context.Customers.Add(customer4);
            context.Customers.Add(customer5);
        }

        private static void AddFiveProducts(SalesContext context)
        {
            var product = new Product()
            {
                ProductName = "Laptop",
                Price = 2500.00m,
                Quantity = 5
            };

            var product2 = new Product()
            {
                ProductName = "LCD-Monitor",
                Price = 500.00m,
                Quantity = 50
            };

            var product3 = new Product()
            {
                ProductName = "Motorola-c3",
                Price = 100.00m,
                Quantity = 522
            };

            var product4 = new Product()
            {
                ProductName = "Mini-pc",
                Price = 700.00m,
                Quantity = 15
            };

            var product5 = new Product()
            {
                ProductName = "IPhone3S",
                Price = 900.00m,
                Quantity = 8
            };

            context.Products.Add(product);
            context.Products.Add(product2);
            context.Products.Add(product3);
            context.Products.Add(product4);
            context.Products.Add(product5);
        }
    }
}