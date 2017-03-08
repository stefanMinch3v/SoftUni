using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateSum
{
    public class RotateSum
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int rotations = int.Parse(Console.ReadLine());

            int[] numbers = ParseNumbers(input);
            long[] sum = new long[input.Length];

            MakeRotations(numbers, sum, rotations);

            Console.WriteLine(string.Join(" ", sum));
        }

        public static void MakeRotations(int[] numbers, long[] sum, int rotations)
        {
            for (int rotation = 0; rotation < rotations; rotation++)
            {
                int lastElement = numbers[numbers.Length - 1];

                for (int element = numbers.Length - 1; element > 0; element--)
                {
                    numbers[element] = numbers[element - 1];
                }

                numbers[0] = lastElement;

                for (int i = 0; i < numbers.Length; i++)
                {
                    sum[i] += numbers[i];
                }
            }
        }

        public static int[] ParseNumbers(string[] input)
        {
            int[] numbers = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                numbers[i] = int.Parse(input[i]);
            }
            return numbers;
        }
    }
}
