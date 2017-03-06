using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvalidNumber
{
    class InvalidNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            var num = double.Parse(Console.ReadLine());
            var all = (num >= 100 && num <= 200) || num == 0;
            if(!all)
            {
                Console.WriteLine("Invalid");
            }
            else
            {
                Console.WriteLine("valid");
            }
        }
    }
}
