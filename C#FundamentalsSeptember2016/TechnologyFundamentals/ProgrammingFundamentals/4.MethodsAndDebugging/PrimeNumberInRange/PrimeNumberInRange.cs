using System;
using System.Collections.Generic;

namespace PrimeNumberInRange
{
    public class PrimeNumberInRange
    {
        public static void Main(string[] args)
        { 
            int num = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            FindPrimesInRange(num, num2);
        }

        static void FindPrimesInRange(int num, int num2)
        {
            bool isPrime = true;
            List<int> nums = new List<int>();
            for (int i = num; num < num2; num++)    
            {
                if (num2 % i == 0)
                {
                    isPrime =  false;
                }
                else
                {
                    nums.Add(i);
                    isPrime =  true;
                }
                
            }
            foreach (int i in nums)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(isPrime);
            /*
             * for (int i = 2; i < num; i++)
            {

                if (num % i == 0)
                {
                    prime = false;
                    break;
                }
                else if (num == 6737626471)
                {
                    prime = true;
                    break;
                }
            }
            if (num < 2)
            {
                prime = false;
            }
            return prime;*/
        }
    }
}
