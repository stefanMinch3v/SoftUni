using System;

namespace PrimeCheckerRefactor
{
    public class PrimeCheckerRefactor
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 2; i <= number; i++)
            {
                bool isPrime = true;
                for (int ii = 2; ii <= Math.Sqrt(i); ii++)
                {
                    if (i % ii == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{i} -> {isPrime}");
            }

        }
    }
}
