using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Startup
{
    public static void Main()
    {
        string pattern = @"[\""]+.+[\""]";
        string patternDigits = @"\d+";
        List<string> finalResult = new List<string>();

        string input = Console.ReadLine();
        int counter = 1;

        while(!input.Contains("<stop/>"))
        {
            if (input.Contains("repeat"))
            {
                string[] commandLine = input.Split('=');
                string takeDigits = commandLine[1];
                string takeContent = commandLine[2];
                int digits = 0;
                string content = string.Empty;

                MatchCollection matchDigits = Regex.Matches(takeDigits, patternDigits);
                MatchCollection matchContent = Regex.Matches(takeContent, pattern);

                foreach (Match match in matchDigits)
                {
                    digits = int.Parse(match.Value.ToString());
                }

                foreach (Match match in matchContent)
                {
                    int length = match.Length - 2;
                    content = string.Join("",match.Value.Skip(1).Take(length));
                }

                for (int i = 0; i < digits; i++)
                {
                    finalResult.Add($"{counter}. {content}");
                    counter++;
                }

            }
            else
            {
                string content = string.Empty;
                MatchCollection matchContent = Regex.Matches(input, pattern);
                foreach (Match match in matchContent)
                {
                    int length = match.Length - 2;
                    content = string.Join("", match.Value.Skip(1).Take(length));
                }

                if (input.Contains("inverse") && content.Length != 0)
                { 
                    string inverseContent = string.Empty;               

                    foreach (var character in content)
                    {
                        if (char.IsLetter(character) && char.IsLower(character))
                        {
                            inverseContent += char.ToUpper(character);
                        }
                        else if (char.IsLetter(character) && char.IsUpper(character))
                        {
                            inverseContent += char.ToLower(character);
                        }
                        else
                        {
                            inverseContent += character;
                        }
                    }

                    finalResult.Add($"{counter}. {inverseContent}");
                    counter++;
                }
                else if (input.Contains("reverse") && content.Length != 0)
                {
                    string reversedContent = string.Join("",content.ToCharArray().Reverse());
                    finalResult.Add($"{counter}. {reversedContent}");
                    counter++;
                }
            }

            input = Console.ReadLine();
        }

        foreach (var item in finalResult)
        {
            Console.WriteLine(item);
        }
    }
}
