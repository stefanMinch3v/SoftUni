using System;

namespace DifferentIntegerSize
{
    public class DifferentIntegerSize
    {
        public static void Main(string[] args)
        {
            
            string number = Console.ReadLine();

            sbyte sb;
            byte b;
            short s;
            ushort us;
            int i;
            uint ui;
            long l;
            
            bool isByte = byte.TryParse(number, out b);
            bool isSByte = sbyte.TryParse(number, out sb);
            bool isShort = short.TryParse(number, out s);
            bool isUShort = ushort.TryParse(number, out us);
            bool isInt = int.TryParse(number, out i);
            bool isUInt = uint.TryParse(number, out ui);
            bool isLong = long.TryParse(number, out l);

            if (isByte || isSByte || isShort || isUShort || isInt || isUInt || isLong)
            {
                Console.WriteLine($"{number} can fit in:");
                if (isByte)
                {
                    Console.WriteLine("* byte");
                }
                if (isSByte)
                {
                    Console.WriteLine("* sbyte");
                }
                if (isShort)
                {
                    Console.WriteLine("* short");
                }
                if (isUShort)
                {
                    Console.WriteLine("* ushort");
                }
                if (isInt)
                {
                    Console.WriteLine("* int");
                }
                if (isUInt)
                {
                    Console.WriteLine("* uint");
                }
                if (isLong)
                {
                    Console.WriteLine("* long");
                }
            }
            else
            {
                Console.WriteLine($"{number} can't fit in any type");
            }
        }
    }
}
