using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeSameNumbers
{
    class ThreeSameNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Check if the 3 numbers are same");
            Console.Write("Enter a number: ");
            var num = float.Parse(Console.ReadLine());
            Console.Write("Enter another number: ");
            var num2 = float.Parse(Console.ReadLine());
            Console.Write("Enter last number: ");
            var num3 = float.Parse(Console.ReadLine());
            if(num == num2 && num == num3 && num2 == num3)
            {
                Console.WriteLine("YEs");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
