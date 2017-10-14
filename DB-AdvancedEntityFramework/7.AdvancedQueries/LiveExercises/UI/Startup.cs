namespace UI
{
    using Data;
    using EntityFramework.Extensions;
    using Models;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Data.Entity;

    public class Startup
    {
        public static void Main()
        {
            var context = new QueryContext();
            context.Database.Initialize(true);
            //context.Clients.Update(c => new Client { Age = 18 });
            //context.SaveChanges();
            //context.Clients.Where(c => c.Name == "Plamen").Update(c => new Client() { Age = 44 });

            //var order = context.Orders.Include(o => o.Client).FirstOrDefault();

            //var query = "SELECT * FROM Clients WHERE Name LIKE @nameParam";
            //var nameParam = new SqlParameter("@nameParam", "Peter%");
            //var client = context.Database.SqlQuery<Client>(query, nameParam);

            //foreach (var item in client)
            //{
            //    System.Console.WriteLine(item.Name + " " + item.Address);
            //}

            //context.Clients.Where(c => c.Name == "Goran Goranov").Delete();// extension method from entity extension asyc where the queries are smarter than before and will use a single sql query to filter and delete the data instead of take 10 queries for 10 users
        }
    }
}
