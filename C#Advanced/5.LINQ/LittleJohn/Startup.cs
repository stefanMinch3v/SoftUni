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
        int countSmall = 0;
        int countMedium = 0;
        int countLarge = 0;

        string patternSmall = @"(^[\>]{1}\-{5}[\>]?)"; // (\>{1}\-{5}\>)
        string patternMedium = @"(^[\>]{2}\-{5}\>?)";
        string patternLarge = @"(\>{3}\-{5}\>{2})";

        for (int i = 0; i < 4; i++)
        {
            string input = Console.ReadLine();

            Regex regexSmall = new Regex(patternSmall);
            Regex regexMedium = new Regex(patternMedium);
            Regex regexLarge = new Regex(patternLarge);

            countSmall += Regex.Matches(input, patternSmall).Count;
            countMedium += Regex.Matches(input, patternMedium).Count;
            countLarge += Regex.Matches(input, patternLarge ).Count;
        }

        string unparsedNumber = $"{countSmall}{countMedium}{countLarge}";
        long number = long.Parse(unparsedNumber);
        string binary = Convert.ToString(number, 2);
        char[] arr = binary.ToCharArray();
        Array.Reverse(arr);
        string reversedString = string.Join("", arr);
        string mergeString = binary + reversedString;
        string result = Convert.ToInt32(mergeString, 2).ToString();
        Console.WriteLine(result);
    }
}
