using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostFrequentNumber
{
    public class MostFrequentNumber
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int number = 0;
            int greaterNumber = 0;
            int count = 0;
            int greaterCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (int ii = 0; ii < input.Length; ii++)
                {
                    if (input[i] == input[ii])
                    {
                        number = input[i];
                        count++;
                    }
                }
                if (count > greaterCount)
                {
                    greaterNumber = number;
                    number = 0;
                    greaterCount = count;
                    count = 0;
                }
                else
                {
                    count = 0;
                }
            }

            Console.WriteLine(greaterNumber);
        }
    }
}
