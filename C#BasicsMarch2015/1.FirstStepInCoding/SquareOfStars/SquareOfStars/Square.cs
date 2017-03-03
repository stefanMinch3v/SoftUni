using System;

namespace SquareOfStars
{
    class Square
    {
        static void Main(string[] args)
        {
            //var n = int.Parse(Console.ReadLine());
            int val = 5;
            int i, j, k;
            for (i = 1; i <= val; i++)
            {
                for (j = 1; j <= val - i; j++)
                {
                    Console.Write("");
                }
                for (k = 1; k <= i; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
    }
}
/*int val = 10;
int i, j, k;
         for (i = 1; i <= val; i++)
         {
            for (j = 1; j <= val-i; j++)
            {
                Console.Write("");
            }
            for (k = 1; k <= i; k++)
            {
               Console.Write("*");
            }
            Console.WriteLine("");
         }
         Console.ReadLine();*/