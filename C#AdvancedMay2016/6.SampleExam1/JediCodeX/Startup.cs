using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        List<string> commandLine = new List<string>();
        List<string> names = new List<string>();
        List<string> messages = new List<string>();

        for (int i = 0; i < input; i++)
        {
            commandLine.Add(Console.ReadLine());
        }

        string key1 = Console.ReadLine();
        string key2 = Console.ReadLine();
        
        string pattern1 = key1 + @"[a-zA-Z]{" + key1.Length + "}";
        string pattern2 = key2 + @"[a-zA-Z0-9]{" + key2.Length + "}";

        for (int i = 0; i < commandLine.Count; i++)
        {
            if (Regex.IsMatch(commandLine[i], pattern1))
            {
                Match matchFirst = Regex.Match(commandLine[i], pattern1);
                while (matchFirst.Success)
                {
                    names.Add(matchFirst.Groups[0].Value.Substring(key1.Length));
                    matchFirst = matchFirst.NextMatch();
                }
                
            }
            else if (Regex.IsMatch(commandLine[i], pattern2))
            {
                Match matchSecond = Regex.Match(commandLine[i], pattern2);
                while (matchSecond.Success)
                {
                    messages.Add(matchSecond.Groups[0].Value.Substring(key2.Length));
                    matchSecond = matchSecond.NextMatch();
                }
            }                            
        }

        int[] jediIndex = Console.ReadLine().Split().Select(int.Parse).ToArray();

        //int currentJediIndex = 0;
        //for (int i = 0; i < jediIndex.Length; i++)
        //{
        //    int saveJedi = jediIndex[i] - 1;
        //    if (saveJedi < messages.Count() && currentJediIndex < names.Count())
        //    {
        //        Console.WriteLine("{0} - {1}", names[currentJediIndex], messages[saveJedi]);
        //        currentJediIndex++;
        //    }
        //}

        for (int i = 0; i < Math.Min(jediIndex.Length, names.Count); i++)
        {
            int currentIndex = jediIndex[i];
            if (currentIndex <= messages.Count)
            {
                Console.WriteLine(names[i] + " - " + messages[currentIndex - 1]);
            }
        }

    }
}
