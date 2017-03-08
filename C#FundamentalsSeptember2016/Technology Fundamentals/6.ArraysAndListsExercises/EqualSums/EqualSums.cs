using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSums
{
    public class EqualSums
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int maxIndex = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int ii = i; ii < numbers.Length; ii++)
                {
                    if (maxIndex < numbers[ii])
                    {
                        maxIndex = numbers[ii];
                    }
                }
            }

            int sumLeft = 0;
            int sumRight = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == maxIndex)
                {
                    for (int ii = 0; ii < Array.IndexOf(numbers, maxIndex); ii++)
                    {
                        sumLeft += numbers[ii];
                    }
                }
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == maxIndex)
                {
                    for (int ii = numbers.Length - 1; ii > Array.IndexOf(numbers, maxIndex); ii--)
                    {
                        sumRight += numbers[ii];
                    }
                }
            }

            if (sumLeft == sumRight)
            {
                Console.WriteLine(Array.IndexOf(numbers, maxIndex));
            }
            else if (sumLeft > sumRight || sumRight > sumLeft)
            {
                Console.WriteLine("no");
            }
            else
            {
                Console.WriteLine(string.Join("", numbers));
            }

            /// 80 points on softuni judge my way <<<

            //second way with 100 points
            /*
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                long leftSum = 0;
                long rightSum = 0;

                for (int j = 0; j < i; j++)
                {
                    leftSum += nums[j];
                }

                for (int k = i + 1; k < nums.Length; k++)
                {
                    rightSum += nums[k];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");


            ///ili poslednata 4ast moje da e taka
            /// bool found = false;
            /// for (int k = i + 1; k < nums.Length; k++)
            ///{
            ///    rightSum += nums[k];
           /// }
           ///
           /// if (leftSum == rightSum)
           /// {
           ///     Console.WriteLine(i);
           ///     found = true;
           ///     break;
           /// }
           /// if(!found) 
           /// {
           ///      console.writeline("no");
           /// }
           */

        }
    }
}
