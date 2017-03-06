using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhombusOfStars
{
    class RhombusOfStars
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int stars = 1;
            int spaces = n - stars;
            for (int row = 1; row <= n; row++)
            {
                for (int col = 1; col <= spaces ; col++)
                {
                    Console.Write(" ");
                }
                for (int col = 1; col <= stars; col++)
                {
                    Console.Write(" *");
                }
                spaces--;
                stars++;
                Console.WriteLine();
            }
            spaces = 1;
            stars = n - spaces;
            for (int row = 1; row <= 2 * n; row++)
            {
                for (int col = 1; col <= spaces; col++)
                {
                    Console.Write(" ");
                }
                for (int col = 1; col <= stars; col++)
                {
                    Console.Write(" *");
                }
                spaces++;
                stars--;
                Console.WriteLine();
            }
        }
    }
}
