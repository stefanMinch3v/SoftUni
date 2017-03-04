using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcellentOrNot
{
    class ExcellentOrNot
    {
        static void Main(string[] args)
        {
            var num = double.Parse(Console.ReadLine());
            if(num >= 5.50)
            {
                Console.WriteLine("Excellent !");
            }
            else if (num <= 5.49)
            {
                Console.WriteLine("Not excellent .");
            }
        }
    }
}
