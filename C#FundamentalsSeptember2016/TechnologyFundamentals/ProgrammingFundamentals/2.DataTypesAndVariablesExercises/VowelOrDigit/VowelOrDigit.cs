using System;

namespace VowelOrDigit
{
    public class VowelOrDigit
    {
        public static void Main(string[] args)
        {
            string symbol = Console.ReadLine();
            int num = Int32.MaxValue;
            if (int.TryParse(symbol, out num))
            {
                Console.WriteLine("digit");
            }
            else if (symbol.Equals("a") || symbol.Equals("e") || symbol.Equals("u") || symbol.Equals("i") || symbol.Equals("o"))
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
