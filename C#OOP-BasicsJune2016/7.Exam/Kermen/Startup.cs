using Kermen.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kermen
{
    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<HouseHold> kermen = new List<HouseHold>();
            int counter = 0;

            while (input != "Democracy")
            {
                counter++;
                try
                {
                    HouseHold entity = HouseHoldFactory.CreateHouseHolder(input);
                    kermen.Add(entity);
                    
                }
                catch (Exception)
                {
                    ////Console.WriteLine("whaaat?!");
                }

                if (counter % 3 == 0)
                {
                    kermen.ForEach(x => x.GetIncome());
                }

                if (input == "EVN bill")
                {
                    kermen.RemoveAll(x => !x.CanPayBills());
                    kermen.ForEach(x => x.PayBills());

                    //foreach (var entry in kermen) // long version of the upper one
                    //{
                    //    if (entry.CanPayBills())
                    //    {
                    //        entry.PayBills();
                    //    }
                    //}
                }
                else if (input == "EVN")
                {
                    Console.WriteLine($"Total consumption: {kermen.Sum(x => x.Consumption)}");
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Total population: {kermen.Sum(x => x.Population)}");
        }
    }   
}
