namespace Froggy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            var collection = Console.ReadLine().Split(',').Select(int.Parse).ToList();
            Lake lake = new Lake(collection);

            Console.WriteLine(string.Join(", ", lake));

        }
    }
}
