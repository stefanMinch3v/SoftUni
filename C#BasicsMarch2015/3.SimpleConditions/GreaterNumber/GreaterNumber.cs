using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreaterNumber
{
    class GreaterNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number :");
            var num = int.Parse(Console.ReadLine());
            Console.Write("Enter number2 :");
            var num2 = int.Parse(Console.ReadLine());
            if (num > num2)
            {
                Console.WriteLine("Greater number is :" + num);
            }
            else
            {
                Console.WriteLine("Greater number is :" + num2);
            }
        }
    }
}
