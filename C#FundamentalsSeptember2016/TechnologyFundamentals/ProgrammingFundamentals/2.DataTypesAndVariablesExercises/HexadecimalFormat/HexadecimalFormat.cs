using System;

namespace HexadecimalFormat
{
    public class HexadecimalFormat
    {
        public static void Main(string[] args)
        {
            string hexa = Console.ReadLine();
            int convert = Convert.ToInt32(hexa, 16);
            Console.WriteLine(convert);
        }
    }
}
