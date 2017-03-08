using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondenseArray
{
    class CondenseArray
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] condensed = new int[arr.Length - 1];

            for (int i = 0; i < arr.Length - 1; i++)
            {
                condensed[i] = arr[i] + arr[i + 1];
            }

            int[] arr2 = new int[condensed.Length - 1];

            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = condensed[i] + condensed[i + 1];
            }

            foreach (var num in arr2)
            {
                Console.WriteLine(num);
            }
        }
    }
}
