using System;

namespace DrawSquare
{
    public class DrawSquare
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintTopAndBottom(n);
            for (int i = 0; i < n - 2; i++)
            {
                PrintBody(n);
            }
            PrintTopAndBottom(n);
        }

        static void PrintTopAndBottom(int num)
        {
            Console.WriteLine(new string('-', 2 * num));
        }

        static void PrintBody(int num)
        {
            Console.Write("-");
            for (int i = 1; i < num; i++)
            {
                Console.Write(@"\/");
            }
            Console.WriteLine("-");
        }
    }
}
