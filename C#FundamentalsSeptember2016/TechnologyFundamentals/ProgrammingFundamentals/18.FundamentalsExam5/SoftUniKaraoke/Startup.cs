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
        string[] participants = Console.ReadLine().Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
        string[] songs = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
        Dictionary<string, List<string>> awards = new Dictionary<string, List<string>>();
        string input = Console.ReadLine();

        while (input != "dawn")
        {
            string[] commandLine = input.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            string name = commandLine[0];
            string song = commandLine[1];
            string award = commandLine[2];

            AddListOfAwards(awards, participants, songs, name, song, award);

            input = Console.ReadLine();
        }

        if (awards.Count() > 0)
        {
            var finalResults = awards.OrderByDescending(x => x.Value.Count()).ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in finalResults)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count()} awards");
                var results = finalResults[kvp.Key].OrderBy(x => x).ToArray();

                foreach (var award in results)
                {
                    Console.WriteLine($"--{award}");
                }
            }
        }
        else
        {
            Console.WriteLine("No awards");
        }
        
    }

    private static void AddListOfAwards(Dictionary<string, List<string>> awards, string[] participants, string[] songs, string name, string song, string award)
    {
        if (participants.Any(n => n == name) && songs.Any(s => s == song))
        {
            if (!awards.ContainsKey(name))
            {
                awards.Add(name, new List<string>());
                awards[name].Add(award);
            }
            else
            {
                if (!awards[name].Contains(award)) // works as distinct fucnction
                {
                    awards[name].Add(award);
                }
            }
            
        }
        

        //bool foundParticipant = false;
        //bool foundSong = false;

        //for (int i = 0; i < participants.Length; i++)
        //{
        //    if (name == participants[i])
        //    {
        //        foundParticipant = true;
        //        break;
        //    }
        //}
        //for (int i = 0; i < songs.Length; i++)
        //{
        //    if (song == songs[i])
        //    {
        //        foundSong = true;
        //        break;
        //    }
        //}
        //if (foundParticipant && foundSong)
        //{
        //    if (!awards.ContainsKey(name))
        //    {
        //        awards.Add(name, new List<string>());
        //    }
        //    string checkAward = string.Join("", awards[name]);
        //    if (checkAward != award)
        //    {
        //        awards[name].Add(award);
        //    }

        //}
    }
}
