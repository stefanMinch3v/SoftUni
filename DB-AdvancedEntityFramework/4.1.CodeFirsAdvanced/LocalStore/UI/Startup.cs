namespace UI
{
    using System;
    using Data;
    using Models;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var context = new ProductContext();
            //context.Database.Initialize(true);

            // Console.WriteLine(string.Join(Environment.NewLine, products.Select(e => (int?)e.Value ?? 0)));
        }
    }
}
