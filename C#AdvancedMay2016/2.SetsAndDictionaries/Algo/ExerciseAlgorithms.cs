using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class ExerciseAlgorithms
    {
        public static void Main(string[] args)
        {
            //List<long> number = Console.ReadLine().Split().Select(long.Parse).ToList();

            //Console.WriteLine(string.Join(" ", number));

            //BubbleSort(number);
            //Console.WriteLine("Bubble sorting");
            //Console.WriteLine(string.Join(" ", number));

            //sum adjacent equal numbers
            //var nums = Console.ReadLine().Split().Select(double.Parse).ToList();
            //for (int i = 1; i < nums.Count; i++)
            //{
            //    if (nums[i - 1] == nums[i])
            //    {
            //        nums[i - 1] = nums[i - 1] + nums[i];
            //        nums.RemoveAt(i);
            //        i = 0;
            //    }
            //}
            //Console.WriteLine(string.Join(" ", nums));

            //search for equal elements in a sequence
            //var nums = Console.ReadLine().Split().Select(long.Parse).ToList();
            //Dictionary<long, long> result = new Dictionary<long, long>();
            //foreach (var item in nums)
            //{
            //    if (result.ContainsKey(item))
            //    {
            //        result[item]++;
            //    }
            //    else
            //    {
            //        result.Add(item, 1);
            //    }
            //}

            //foreach (var kvp in result.OrderBy(num => num.Key))
            //{
            //    Console.WriteLine("{0} -> {1}", kvp.Key, kvp.Value);
            //}
            // second way
            //var keys = nums.Distinct().OrderBy(x => x);
            //foreach (var key in keys)
            //{
            //    var countKeys = nums.Count(x => x == key);
            //    Console.WriteLine($"{key} -> {countKeys}");
            //}
            // complicated way 
            //var start = 0;
            //var count = 1;
            //for (int i = 0; i < nums.Count; i++)
            //{
            //    if (i == nums.Count - 1 || nums[i] != nums[i + 1])
            //    {
            //        // end of current sequence and starts a new one
            //        Console.WriteLine(nums[start] + " -> " + count);
            //        start = i + 1;
            //        count = 1;
            //    }
            //    else
            //    {
            //        count++;
            //    }
            //}

            //my way of solving the problem ///// 1 1 1 2 2 3 - simple counting of sequence 
            //var counter = 1;
            //for (int i = 0; i < nums.Count; i++)
            //{
            //    if (i + 1 > nums.Count - 1)
            //    {
            //        Console.WriteLine($"{nums[i]} -> {counter}");
            //        break;
            //    }
            //    else if (nums[i] == nums[i + 1])
            //    {
            //        counter++;
            //    }
            //    else
            //    {
            //        Console.WriteLine($"{nums[i]} -> {counter}");
            //        counter = 1;
            //    }
            //}

        }

        private static void BubbleSort(List<long> number)
        {
            bool isSorted = false;
            while (!isSorted)
            {
                isSorted = true;

                for (int i = 0; i < number.Count - 1; i++)
                {
                    if (number[i] > number[i + 1])
                    {
                        Swap(number, i, i + 1);
                        isSorted = false;
                    }
                }
            }
        }

        private static void Swap(List<long> number, int i, int v)
        {
            long temp = number[i];
            number[i] = number[v];
            number[v] = temp;
        }
    }
}
