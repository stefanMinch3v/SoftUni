using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldAndSum
{
    public class FoldAndSum
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int k = numbers.Length / 4;

            int[] firstRow = new int[2 * k];
            int[] secondRow = new int[2 * k];

            for (int i = 0; i < k; i++)
            {
                firstRow[i] = numbers[k - 1 - i];
            }

            for (int i = 0; i < k; i++)
            {
                firstRow[i + k] = numbers[4 * k - 1 - i];
            }

            for (int i = 0; i < 2*k; i++)
            {
                secondRow[i] = numbers[k + i];
            }

            for (int i = 0; i < 2*k; i++)
            {
                Console.Write(firstRow[i] + secondRow[i] + " ");
            }
            Console.WriteLine();

            //another way to solve the problem

            /*var number = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int kk = numbers.Length / 4;
            int[] firstKElement = new int[kk];
            int[] lastKElement = new int[kk];

            for (int i = 0; i < kk; i++)
            {
                firstKElement[i] = numbers[i];
                lastKElement[i] = numbers[3 * k + i];
            }

            int[] finalArray = new int[2 * k];
            Array.Reverse(firstKElement);
            Array.Reverse(lastKElement);

            for (int i = 0; i < k; i++)
            {
                finalArray[i] = firstKElement[i] + numbers[k + i];
                finalArray[k + i] = lastKElement[i] + numbers[2 * k + i];
            }

            Console.WriteLine(string.Join(" ", finalArray));*/
        }
    }
}
