using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            List<Person> buyers = new List<Person>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (buyers.Any(x => x.Name == input[0]))
                {
                    return;
                }

                if (input.Length == 4)
                {
                    buyers.Add(new Citizen(input[0], int.Parse(input[1]), input[2], input[3]));
                }
                else if (input.Length == 3)
                {
                    buyers.Add(new Rebel(input[0], int.Parse(input[1]), input[2]));
                }
            }

            string inputName = Console.ReadLine();

            while (inputName != "End")
            {
                var currentBuyer = buyers.FirstOrDefault(x => x.Name == inputName);

                if (currentBuyer != null)
                {
                    currentBuyer.BuyFood();
                }

                //currentBuyer?.BuyFood(); C# 6.0 extension => it saves if statement that is over this line with != null
                //buyers.FirstOrDefault(x => x.Name == inputName)?.BuyFood(); this is the same syntacs

                inputName = Console.ReadLine();
            }

            int countFood = 0;
            buyers.ForEach(x => countFood += x.Food);
            Console.WriteLine(countFood);
        }
    }
}
