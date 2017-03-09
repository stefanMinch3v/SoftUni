using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes
{
    class Palindromes
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ',', ' ', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> palindromes = new List<string>();

            foreach (var item in input)
            {
                //way 1 

                string reverse = string.Empty;
                Stack<char> stack = new Stack<char>();
                for (int i = 0; i < item.Length; i++)
                {
                    stack.Push(item[i]);
                }
                for (int i = 0; i < item.Length; i++)
                {
                    reverse += stack.Pop();
                }
                if (reverse == item)
                {
                    palindromes.Add(item);
                }

                //way 2 - 
                //List<char> reverse = new List<char>();
                //reverse.AddRange(item);
                //reverse.Reverse();
                //string result = string.Empty;
                //for (int i = 0; i < reverse.Count; i++)
                //{
                //    result += reverse[i];
                //}
                //if (result == item)
                //{
                //    palindromes.Add(item);
                //}
                //reverse.Clear();

                //way 3 -
                //if (item.SequenceEqual(item.Reverse()))
                //{
                //    palindromes.Add(item)
                //}

            }
            string finalResult = string.Join(", ",palindromes.OrderBy(p => p).Distinct());
            Console.WriteLine(finalResult);
        }
    }
}
