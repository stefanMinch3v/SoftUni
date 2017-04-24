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
        string[] input = Console.ReadLine().Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        string pattern = @"([$,@,#,^]{6,})";
        Regex regex = new Regex(pattern);

        foreach (var item in input)
        {
            MatchCollection matchCollection = regex.Matches(item);
            bool validTicket = Regex.IsMatch(item, pattern);
            int checkLength = 0;
            char symbol = 'a';

            if (validTicket)
            {
                foreach (Match match in matchCollection)
                {
                    checkLength += int.Parse(match.Length.ToString());
                }
                checkLength /= 2;

                if (checkLength >= 10)
                {
                    symbol = GetSymbol(matchCollection, symbol);
                    Console.WriteLine($"ticket \"{item}\" - 10{symbol} Jackpot!");
                }
                else
                {
                    symbol = GetSymbol(matchCollection, symbol);
                    Console.WriteLine($"ticket \"{item}\" - 6{symbol}");
                }
            }
            else
            {
                if (item.Length < 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    Console.WriteLine($"ticket \"{item}\" - no match");
                }
            }
        } 
    }

    private static char GetSymbol(MatchCollection matchCollection, char symbol)
    {
        foreach (Match match in matchCollection)
        {
            foreach (var character in match.Value)
            {
                symbol = character;
                break;
            }
            break;
        }
        return symbol;
    }
}
