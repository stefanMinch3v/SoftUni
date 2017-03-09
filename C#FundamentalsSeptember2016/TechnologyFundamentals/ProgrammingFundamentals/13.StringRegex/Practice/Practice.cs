using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Program
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pattern = @"([a-zA-Z0-9]*\s[a-zA-Z0-9]*\s[a-zA-z0-9]+!)\D*";
        Regex regex = new Regex(pattern);
        MatchCollection matchCollection = regex.Matches(input);

        foreach (Match match in matchCollection)
        {
            Console.WriteLine(match.Groups.Count);
        }
        /*
          string input = Console.ReadLine();
          string pattern = "(\\w+\\@+\\w+\\.\\w{2,3})";
          Regex regex = new Regex(pattern);
          Match match = regex.Match(input);
          Console.WriteLine(match.Groups[0]);
          */
    }
}

