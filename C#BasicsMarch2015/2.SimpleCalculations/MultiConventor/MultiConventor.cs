using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiConventor
{
    class MultiConventor
    {
        static void Main(string[] args)
        {
            Console.Write("Write some value to convert = ");
            double[] numbers = { 1, 1.79549, 1.95583, 2.53405 };
            var currency = double.Parse(Console.ReadLine());
            Console.WriteLine("Choose from what currency do you want to convert 0-BGN, 1-USD, 2-EUR, 3-GBP.");
            var from = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose your currency to convert 0-BGN, 1-USD, 2-EUR, 3-GBP.");
            var to = int.Parse(Console.ReadLine());
            Console.WriteLine(Math.Round(((numbers[from] / numbers[to]) * currency), 2));
        }
    }
}
