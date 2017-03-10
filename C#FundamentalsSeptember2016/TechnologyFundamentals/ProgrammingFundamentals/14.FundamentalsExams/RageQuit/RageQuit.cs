using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RageQuit
{
    class RageQuit
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();
            string pattern = @"(\D+)(\d+)";
            Regex regexItem = new Regex(pattern);
            //StringBuilder sb = new StringBuilder();
            List<string> result = new List<string>();
            int countUnique = 0;

            MatchCollection collection = regexItem.Matches(input);

            foreach (Match match in collection)
            {
                for (int i = 0; i < int.Parse(match.Groups[2].ToString()); i++)
                {
                    result.Add(match.Groups[1].ToString());
                    //sb.Append();
                }
            }

            //countUnique = sb.ToString().Distinct().Count();
            countUnique = result.Distinct().Count();
            Console.WriteLine("Unique symbols used: {0}", countUnique);
            Console.WriteLine(string.Join("", result));
            //Console.WriteLine(sb);

        }
    }
}
