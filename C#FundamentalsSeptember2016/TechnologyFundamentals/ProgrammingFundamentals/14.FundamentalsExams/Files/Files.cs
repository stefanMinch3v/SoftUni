using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


public class Files
{
    public static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine());
        Dictionary<string, Dictionary<string, decimal>> files = new Dictionary<string, Dictionary<string, decimal>>();

        string patternFirst = @"^[^\\]*";//catches the first letters regard directory
        string patternKey = @"(\w[^\\]*);";//catches the file name
        string patternValue = @"(\d+)(?!.*\d)";//catches the extension 

        for (int i = 0; i < num; i++)
        {
            string input = Console.ReadLine();
            string directory = string.Empty;
            string dictKey = string.Empty;
            decimal dictValue = 0;

            Regex regexFirst = new Regex(patternFirst);
            Regex regexKey = new Regex(patternKey);
            Regex regexValue = new Regex(patternValue);

            MatchCollection collection1 = regexFirst.Matches(input);
            MatchCollection collection2 = regexKey.Matches(input);
            MatchCollection collection3 = regexValue.Matches(input);

            foreach (Match match in collection1)
            {
                directory = match.ToString();
            }

            foreach (Match match in collection2)
            {
                dictKey = match.Groups[1].ToString();
            }

            foreach (Match match in collection3)
            {
                dictValue = decimal.Parse(match.ToString());
            }

            FillOutDictionary(files, directory, dictKey, dictValue);
        }

        string[] checkFile = Console.ReadLine().Split();

        string searchDirectory = checkFile[2];
        string searchFile = checkFile[0];

        if (files.ContainsKey(searchDirectory))
        {
            bool found = false;
            foreach (var item in files[searchDirectory].OrderByDescending(value => value.Value).ThenBy(key => key.Key))
            {
                string search = string.Join("", item.Key);
                if (search.Substring(search.Length - 3).Contains(searchFile))
                {
                    string keys = string.Join("", item.Key);
                    string values = string.Join("", item.Value);
                    Console.WriteLine($"{keys} - {values} KB");
                    found = true;
                }
            }
            if (found == false)
            {
                Console.WriteLine("No");
            }
        }
        else
        {
            Console.WriteLine("No");
        }
    }

    private static void FillOutDictionary(Dictionary<string, Dictionary<string, decimal>> files, string directory, string dictKey, decimal dictValue)
    {
        if (!files.ContainsKey(directory))
        {
            files.Add(directory, new Dictionary<string, decimal>());
            files[directory].Add(dictKey, dictValue);
        }
        else
        {
            if (!files[directory].ContainsKey(dictKey))
            {
                files[directory].Add(dictKey, dictValue);
            }
            else
            {
                files[directory][dictKey] = dictValue;
            }
        }
        if (files[directory].ContainsKey(dictKey))
        {
            files[directory][dictKey] = dictValue;
        }
    }
}

