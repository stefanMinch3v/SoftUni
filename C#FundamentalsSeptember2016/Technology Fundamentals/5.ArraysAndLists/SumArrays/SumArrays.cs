using System;
using System.Linq;

namespace SumArrays
{
    public class SumArrays
    {
        public static void Main()
        {
            long[] arr = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            long[] arr2 = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            var functionMax = Math.Max(arr.Length, arr2.Length);

            long[] sum = new long[functionMax];

            for (int i = 0; i < functionMax; i++)
            {
                sum[i] = arr[i % arr.Length] + arr2[i % arr2.Length];
            }

            for (int i = 0; i < sum.Length; i++)
            {
                Console.Write(sum[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
