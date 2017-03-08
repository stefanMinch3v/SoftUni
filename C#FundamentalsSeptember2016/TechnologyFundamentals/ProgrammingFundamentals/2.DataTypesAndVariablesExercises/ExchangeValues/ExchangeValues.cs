using System;

namespace ExchangeValues
{
    public class ExchangeValues
    {
        public static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            Console.WriteLine($"Before:\na = {a}\nb = {b}");
            int tmp = b;
            b = a;
            a = tmp;
            Console.WriteLine("After:\na = {0}\nb = {1}", a, b);
        }
    }
}
