using System;

namespace HelloName
{
    public class HelloName
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            PrintName(name);
        }

        static void PrintName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
