using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyProfit
{
    class DailyProfit
    {
        static void Main(string[] args)
        {
            var workingDays = int.Parse(Console.ReadLine());
            var dailyMoney = double.Parse(Console.ReadLine());
            var currency = double.Parse(Console.ReadLine());
            double month = 0;
            double year = 0;
            double tax = 0;
            double realTax = 0;
            double averageWage = 0;

            if ((workingDays >= 5 && workingDays <= 30) && (dailyMoney >= 10 && dailyMoney <= 2000) && (currency >= 0.99 && currency <= 1.99))
            {
                month = workingDays * dailyMoney;
                year = (month * 12) + (month * 2.5);
                tax = (year * 25) / 100;
                realTax = (year - tax) * currency;
                averageWage = realTax / 365;
            }
            Console.WriteLine("{0:f2}", averageWage);
        }
    }
}
