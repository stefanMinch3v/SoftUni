using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeComissions
{
    class TradeComissions
    {
        static void Main(string[] args)
        {
            Console.Write("Choose a city(Sofia, Varna or Plovdiv): ");
            var city = Console.ReadLine().ToLower();
            Console.Write("Choose some sales: ");
            var sales = double.Parse(Console.ReadLine());
            var comission = -1.0;
            if(city == "sofia")
            {
                if (0 <= sales && sales <= 500) comission = 0.05;
                else if (500 <= sales && sales <= 1000) comission = 0.07;
                else if (1000 <= sales && sales <= 10000) comission = 0.08;
                else if (sales > 10000) comission = 0.12;
            }

            else if (city == "varna")
            {
                if (0 <= sales && sales <= 500) comission = 0.045;
                else if (500 <= sales && sales <= 1000) comission = 0.075;
                else if (1000 <= sales && sales <= 10000) comission = 0.10;
                else if (sales > 10000) comission = 0.13;
            }

            else if (city == "plovdiv")
            {
                if (0 <= sales && sales <= 500) comission = 0.055;
                else if (500 <= sales && sales <= 1000) comission = 0.08;
                else if (1000 <= sales && sales <= 10000) comission = 0.12;
                else if (sales > 10000) comission = 0.145;
            }

            if (comission <= 0) Console.WriteLine("Error");
            else Console.WriteLine("{0:f2}", sales * comission);
        }
    }
}
