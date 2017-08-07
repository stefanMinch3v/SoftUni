using System;

namespace Ferrari
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            string driverName = Console.ReadLine();

            ICar car = new Ferrari(driverName);

            Console.WriteLine(car.ToString());

            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }

        }
    }
}
