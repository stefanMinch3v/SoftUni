using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MagicExchangeableWords
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        Dictionary<char, char> magicWords = new Dictionary<char, char>();
        string first = input[0];
        string second = input[1];
        bool ok = true;

        FillOutWords(magicWords, first, second, ok);
    }

    private static void FillOutWords(Dictionary<char, char> magicWords, string first, string second, bool ok)
    {
        if (first.Length < second.Length)// abc defg : a => d, b => e, c => f, g doesn't exist in the dictionary => false
        {
            for (int i = 0; i < first.Length; i++)
            {

                if (!magicWords.ContainsKey(first[i]))
                {
                    if (magicWords.ContainsValue(second[i]))
                    {
                        Console.WriteLine("false");
                        return;
                    }
                    magicWords.Add(first[i], second[i]);
                }
            }

            for (int i = 0; i < second.Length; i++)
            {
                if (!magicWords.ContainsValue(second[i]))
                {
                    ok = false;
                }
            }
            Console.WriteLine(ok.ToString().ToLower());
        }

        else if (first.Length > second.Length)
        {
            for (int i = 0; i < second.Length; i++)
            {

                if (!magicWords.ContainsKey(second[i]))
                {
                    if (magicWords.ContainsValue(first[i]))
                    {
                        Console.WriteLine("false");
                        return;
                    }
                    magicWords.Add(second[i], first[i]);
                }
            }

            for (int i = 0; i < first.Length; i++)
            {
                if (!magicWords.ContainsValue(first[i]))
                {
                    ok = false;
                }
            }
            Console.WriteLine(ok.ToString().ToLower());
        }
        else
        {
            for (int i = 0; i < first.Length; i++)
            {
                if (!magicWords.ContainsKey(first[i]))
                {
                    if (magicWords.ContainsValue(second[i]))
                    {
                        Console.WriteLine("false");
                        return;
                    }
                    magicWords.Add(first[i], second[i]);
                }

                else
                {
                    if (magicWords.ContainsValue(second[i]) != magicWords.ContainsKey(first[i]))
                    {
                        ok = false;
                    }
                }
            }
            Console.WriteLine(ok.ToString().ToLower());
        }

    }
}

