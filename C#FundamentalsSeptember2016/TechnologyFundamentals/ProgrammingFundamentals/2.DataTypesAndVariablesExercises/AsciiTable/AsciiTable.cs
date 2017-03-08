using System;
using System.Text;

namespace AsciiTable
{
    public class AsciiTable
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.ASCII;
            byte start = byte.Parse(Console.ReadLine());
            byte end = byte.Parse(Console.ReadLine());
            for (byte i = start; i <= end; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
