using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


public class ExtractEmails
{
    public static void Main(string[] args)
    {
        string text = Console.ReadLine();
        string pattern = @"(?:^|\s)([a-zA-Z0-9][\-\._a-zA-Z0-9]*@[a-zA-Z\-]+(\.[a-z]+)+\b)";
        Regex regex = new Regex(pattern);
        MatchCollection matchCollection = regex.Matches(text);

        foreach (Match match in matchCollection)
        {
            Console.WriteLine(match.Groups[1]);
        }
    }
}

