using System;

namespace IntHexBinary
{
    public class IntHexBinary
    {
        public static void Main(string[] args)
        {
            int dec = int.Parse(Console.ReadLine());
            int[] bases = {16, 2};
            foreach (int b in bases)
            {
                Console.WriteLine(Convert.ToString(dec, b).ToUpper());
            }
        }
    }
}
