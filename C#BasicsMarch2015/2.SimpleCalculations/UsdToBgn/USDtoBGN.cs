using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsdToBgn
{
    class USDtoBGN
    {
        static void Main(string[] args)
        {
            Console.Write("USD = ");
            double usd = double.Parse(Console.ReadLine());
            double convert = usd * 1.79549f;
            Console.WriteLine("BGN = {0}", Math.Round(convert, 2));
        }
    }
}
