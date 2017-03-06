using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmSolution
{
    class FirmSolution
    {
        static void Main(string[] args)
        {
            var hours = int.Parse(Console.ReadLine());
            var days = int.Parse(Console.ReadLine());
            var employees = int.Parse(Console.ReadLine());

            double sumHours = 0;
            double overtimes = 0;
            double allHours = 0;
            double allsum = 0;

            sumHours = (((double)days * 90) / 100) * 8;
            overtimes = employees * (2 * days);
            allHours = Math.Truncate(sumHours + overtimes);
            allsum = Math.Abs(hours - allHours);
            if (hours <= allHours)
            {
                Console.WriteLine("Yes!{0} hours left.", allsum);
            }
            else
            {
                Console.WriteLine("Not enough time!{0} hours needed.", allsum);
            }
        }
    }
}
