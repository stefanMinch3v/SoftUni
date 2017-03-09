using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFromBase10toN
{
    class ConvertFromBase10toN
    {
        static void Main(string[] args)
        {
            Stack<BigInteger> divideByN = new Stack<BigInteger>();
            List<BigInteger> result = new List<BigInteger>();
            BigInteger[] input = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();
            BigInteger numberBase = input[0];
            BigInteger numberConvert = input[1];

            if ((numberBase >= 2 && numberBase <= 10) && (numberConvert >= 10))
            {
                while (numberConvert > 0)
                {
                    BigInteger sum = numberConvert % numberBase;
                    divideByN.Push(sum);
                    numberConvert = numberConvert / numberBase;
                }

                while (divideByN.Count > 0)
                {
                    result.Add(divideByN.Pop());
                }

                Console.WriteLine(string.Join("", result));
            }
        }
    }
}
