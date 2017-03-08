using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareCharArrays
{
    class CompareCharArrays
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            var arr2 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

            var compareMax = Math.Max(arr.Length, arr2.Length);
            var compareMin = Math.Min(arr.Length, arr2.Length);

            int countFirst = 0;
            int countSecond = 0;

            for (int i = 0; i < compareMax; i++)
            {
                if (arr[i % arr.Length] > arr2[i % arr2.Length])
                {
                    countFirst++;
                }
                else
                {
                    countSecond++;
                }
            }

            if (countSecond > countFirst)
            {
                if (arr2.Length < arr.Length)
                {
                    Console.WriteLine(string.Join("", arr2));
                    Console.WriteLine(string.Join("", arr));
                }
                else
                {
                    Console.WriteLine(string.Join("", arr));
                    Console.WriteLine(string.Join("", arr2));
                }

            }
            else if (countFirst > countSecond)
            {
                Console.WriteLine(string.Join("", arr2));
                Console.WriteLine(string.Join("", arr));
            }
            else
            {
                Console.WriteLine(string.Join("", arr));
                Console.WriteLine(string.Join("", arr2));
            }

            //another way to solve this problem
            var firstChar = Console.ReadLine().Split(' ').Select(char.Parse).ToList();
            var secondChar = Console.ReadLine().Split(' ').Select(char.Parse).ToList();

            int len = Math.Min(firstChar.Count, secondChar.Count);
            bool areDifferent = false;

            for (int i = 0; i < len; i++)
            {
                if (firstChar[i] > secondChar[i])
                {
                    Console.WriteLine(string.Join("", secondChar));
                    Console.WriteLine(string.Join("", firstChar));
                    areDifferent = true;
                    break;
                }
                else if (firstChar[i] < secondChar[i])
                {
                    Console.WriteLine(string.Join("", firstChar));
                    Console.WriteLine(string.Join("", secondChar));
                    areDifferent = true;
                    break;
                }
            }

            if (!areDifferent)
            {
                if (firstChar.Count <= secondChar.Count)
                {
                    Console.WriteLine(string.Join("", firstChar));
                    Console.WriteLine(string.Join("", secondChar));
                }
                else
                {
                    Console.WriteLine(string.Join("", secondChar));
                    Console.WriteLine(string.Join("", firstChar));
                }
            }
        }
    }
}
