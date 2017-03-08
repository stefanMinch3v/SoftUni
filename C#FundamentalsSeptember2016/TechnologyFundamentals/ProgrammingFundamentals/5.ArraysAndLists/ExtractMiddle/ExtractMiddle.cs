using System;
using System.Linq;

namespace ExtractMiddle
{
    class ExtractMiddle
    {
        static void Main()
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            if (arr.Length == 1)
            {
                foreach (int item in arr)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                var odd = arr.Length / 2 - 1;
                var odd2 = arr.Length / 2;
                var odd3 = arr.Length / 2 + 1;

                var even = arr.Length / 2 - 1;
                var even2 = arr.Length / 2;

                if (arr.Length % 2 == 0)
                {
                    Console.WriteLine("{0}, {1}", arr[even], arr[even2]);
                }
                else
                {
                    Console.WriteLine("{0}, {1}, {2}", arr[odd], arr[odd2], arr[odd3]);
                }
            }
        }
    }
}
