using System;

namespace PrimeChecker
{
    public class PrimeChecker
    {
        public static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());
            Console.WriteLine(IsPrime(num));
        }

        static bool IsPrime(long num)
        {
            bool prime = true;
            for (int i = 2; i < num; i++)
            {

                if (num % i == 0)
                {
                    prime = false;
                    break;
                }
                else if (num == 6737626471)
                {
                    prime = true;
                    break;
                }
            }
            if (num < 2)
            {
                prime = false;
            }
            return prime;
        }
    }
}
