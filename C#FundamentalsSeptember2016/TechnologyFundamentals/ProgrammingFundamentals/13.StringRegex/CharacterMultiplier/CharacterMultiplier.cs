using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CharacterMultiplier
{
    public static void Main(string[] args)
    {
        string[] words = Console.ReadLine().Split();
        string first = words[0];
        string second = words[1];
        decimal totalSum = 0;
        int firstLength = first.Length;
        int secondLength = second.Length;

        if (firstLength == secondLength)
        {
            for (int i = 0; i < firstLength; i++)
            {
                totalSum += first[i] * second[i];
            }
        }
        else if (firstLength < secondLength)
        {
            for (int i = 0; i < firstLength; i++)
            {
                totalSum += first[i] * second[i];
            }

            string len = second.Substring(firstLength);
            for (int i = 0; i < len.Length; i++)
            {
                totalSum += len[i];
            }
        }
        else
        {
            for (int i = 0; i < secondLength; i++)
            {
                totalSum += second[i] * first[i];
            }

            string len = first.Substring(secondLength);
            for (int i = 0; i < len.Length; i++)
            {
                totalSum += len[i];
            }
        }

        Console.WriteLine(totalSum);

    }
}
