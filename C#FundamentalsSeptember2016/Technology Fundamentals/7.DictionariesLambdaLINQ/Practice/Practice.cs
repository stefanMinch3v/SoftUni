using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise
{
    public class Practise
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int count = 0;
            int maxCount = 0;
            
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i; j < input.Length; j++)
                {
                    if (input[j] == input[i])
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }

                }
                if (count > maxCount)
                {
                    maxCount = count;
                }
                count = 0;
            }

            Console.WriteLine(maxCount);
        }
    }
}
