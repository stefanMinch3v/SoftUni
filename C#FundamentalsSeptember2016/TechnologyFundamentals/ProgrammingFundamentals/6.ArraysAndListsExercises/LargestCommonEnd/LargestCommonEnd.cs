using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestCommonEnd
{
    class LargestCommonEnd
    {
        public static void Main()
        {
            /*string[] values = Console.ReadLine().Split(' ');
            List<int> nums = new List<int>();
            foreach (var item in values)
            {
                nums.Add(int.Parse(item));
            }*/
            //int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            
            var input = Console.ReadLine().Split(' ').ToArray();
            var input2 = Console.ReadLine().Split(' ').ToArray();

            var minArray = Math.Min(input.Length, input2.Length);

            string[] left = new string[minArray];
            string[] right = new string[minArray];

            int countLeft = 0;
            int countRight = 0;

            for (int i = 0; i < minArray; i++)
            {
                if (input[i].Equals(input2[i]))
                {
                    countLeft++;
                    left[i] = input[i];
                }
                else
                {
                    break;
                }
            }

            Array.Reverse(input);
            Array.Reverse(input2);
            for (int i = 0; i < minArray; i++)
            {

                if (input[i].Equals(input2[i]))
                {
                    countRight++;
                    right[i] = input[i];
                }
                else
                {
                    break;
                }
            }

            if (countLeft > 0 || countRight > 0)
            {
                if (countLeft > countRight)
                {
                    Console.WriteLine($"The largest common end is at the left: {string.Join(" ", left)}");
                }
                else
                {
                    Array.Reverse(right);
                    Console.WriteLine($"The largest common end is at the right: {string.Join(" ", right)}");
                }
            }
            else
            {
                Console.WriteLine("No common words at the left and right");
            }
            
            //second way
            /*
            var input = Console.ReadLine().Split(' ').ToArray();
            var input2 = Console.ReadLine().Split(' ').ToArray();

            var minArray = Math.Min(input.Length, input2.Length);

            string[] left = new string[minArray];
            string[] right = new string[minArray];

            int countLeft = 0;
            int countRight = 0;

            for (int i = 0; i < minArray; i++)
            {
                if (input[i].Equals(input2[i]))
                {
                    countLeft++;
                    left[i] = input[i];
                    continue;
                }

                break;
            }

            for (int i = 1; i <= minArray; i++)
            {
                if (input[input.Length - i].Equals(input2[input2.Length - i]))
                {
                    countLeft++;
                    left[i] = input[i];
                    continue;
                }
                break;
            }

            Console.WriteLine(Math.Max(countLeft, countRight));
            */
        }
    }
}
