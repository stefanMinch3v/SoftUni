namespace Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.QueryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Data.QueryContext";
        }

        protected override void Seed(Data.QueryContext context)
        {
            var client = new Client()
            {
                Name = "Peter Ivanov",
                Address = "Strandza 5"
            };

            var client2 = new Client()
            {
                Name = "Ivan Hristov",
                Address = "Sportna 12"
            };

            var product = new Product()
            {
                Name = "Oil Pump"
            };

            //var order = new Order()
            //{
            //    Client = client
            //};

            //order.Products.Add(product);

            context.Clients.AddOrUpdate(c => c.Name, client, client2);
            context.Products.AddOrUpdate(p => p.Name, product);
            //context.Orders.AddOrUpdate(o => o.ClientId, order);

            context.SaveChanges();
        }
    }
}
