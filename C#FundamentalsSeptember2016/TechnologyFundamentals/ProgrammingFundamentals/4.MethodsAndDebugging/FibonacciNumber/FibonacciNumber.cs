using System;

namespace FibonacciNumber
{
    public class FibonacciNumber
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibonacci(number));
        }

        static int GetFibonacci(int number)
        {
            int fib0 = 1;
            int fib1 = 1;
            for (int i = 0; i < number - 1; i++)
            {
                int fNext = fib0 + fib1;
                fib0 = fib1;
                fib1 = fNext;
            }
            return fib1;
        }
    }
}
