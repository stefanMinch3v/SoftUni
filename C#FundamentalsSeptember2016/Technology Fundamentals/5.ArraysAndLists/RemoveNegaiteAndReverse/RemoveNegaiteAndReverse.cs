using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNegaiteAndReverse
{
    class RemoveNegaiteAndReverse
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
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> positiveNums = new List<int>();

            foreach (var item in nums)
            {
                if (item > 0)
                {
                    positiveNums.Add(item);
                }
            }
            if (!positiveNums.Any())
            {
                Console.WriteLine("empty");
            }
            else
            {
                positiveNums.Reverse();
                string join = string.Join(" ", positiveNums);
                Console.WriteLine(join);
            }
        }
    }
}
