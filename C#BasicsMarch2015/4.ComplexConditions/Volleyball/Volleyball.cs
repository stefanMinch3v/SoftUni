using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Volleyball
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vladi's volleyball adventure");
            Console.Write("Enter a kind of year(leap or normal): ");
            var year = Console.ReadLine().ToLower();
            Console.Write("Enter number of feasts: ");
            var feast = double.Parse(Console.ReadLine());
            Console.Write("Enter number of weekends: ");
            var weekend = double.Parse(Console.ReadLine());
            var allweek = -1.00;
            var weekresult = -1.00;
            var allfeast = -1.00;
            var alltogether = -1.00;
            var leapyear = -1.00;
            var result = -1.00;
            if (year == "leap")
            {
                allweek = 48 - weekend;
                weekresult = allweek * 3.0 / 4;
                allfeast = feast * 2.0 / 3;
                alltogether = weekresult + weekend + allfeast;
                leapyear = 0.15 * alltogether;
                result = alltogether + leapyear;
                Console.WriteLine(Math.Truncate(result));
            }
            else if (year == "normal")
            {
                allweek = 48 - weekend;
                weekresult = allweek * 3.0 / 4;
                allfeast = feast * 2.0 / 3;
                alltogether = weekresult + weekend + allfeast;
                Console.WriteLine(Math.Truncate(alltogether));
            }
            else Console.WriteLine("Error with year or weekends");
        }
    }
}
