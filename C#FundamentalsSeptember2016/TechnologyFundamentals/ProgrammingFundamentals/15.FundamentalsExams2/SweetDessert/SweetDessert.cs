using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SweetDessert
{
    public static void Main(string[] args)
    {
        decimal moneyInWallet = decimal.Parse(Console.ReadLine());
        int numGuests = int.Parse(Console.ReadLine());
        decimal bananaPrice = decimal.Parse(Console.ReadLine());
        decimal eggsPrice = decimal.Parse(Console.ReadLine());
        decimal berriesPrice = decimal.Parse(Console.ReadLine());

        decimal totalMoney = 0;
        int countGuests = (int)Math.Ceiling(numGuests / 6.0);

        decimal minBanana = 2 * bananaPrice;
        decimal minEggs = 4 * eggsPrice;
        decimal minBerries = (decimal)0.2 * berriesPrice;
  
        totalMoney = (countGuests * minBanana) + (countGuests * minEggs) + (countGuests * minBerries);
        if (moneyInWallet >= totalMoney)
        {
            Console.WriteLine($"Ivancho has enough money - it would cost {totalMoney:f2}lv.");
        }
        else
        {
            Console.WriteLine($"Ivancho will have to withdraw money - he will need {totalMoney - moneyInWallet:f2}lv more.");
        }
        
    }
}

