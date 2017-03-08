using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldAndSum
{
    public class FoldAndSum
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = input.Length / 4;

            int[] leftSide = input.Take(k).Reverse().ToArray();
            int[] rightSide = input.Reverse().Take(k).ToArray();
            int[] middle = input.Skip(k).Take(k * 2).ToArray();
            int[] concatLeftRight = leftSide.Concat(rightSide).ToArray();

            var sum = concatLeftRight.Select((x, index) => x + middle[index]);
            Console.WriteLine(string.Join(" ", sum));

            // second way
            var sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int kk = input.Length / 4;

            int[] leftSeq = sequence.Take(kk).Reverse().ToArray();
            int[] rightSeq = sequence.Reverse().Take(kk).ToArray();
            int[] middleSeq = sequence.Skip(kk).Take(kk * 2).ToArray();

            for (int i = 0; i < leftSide.Length; i++)
            {
                middleSeq[i] += leftSide[i];
            }

            for (int i = 0; i < rightSeq.Length; i++)
            {
                middleSeq[i + k] += rightSeq[i];
            }

            Console.WriteLine(string.Join(" ", middleSeq));
        }
    }
}
