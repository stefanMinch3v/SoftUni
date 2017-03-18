using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class NetherRealms
{
    public static void Main(string[] args)
    {
        string patternName = @"[a-zA-Z]+";
        Regex regexName = new Regex(patternName);

        string patternDamage = @"[0-9.-]+";
        Regex regexDamage = new Regex(patternDamage);

        string patternMath = @"[*/]+";
        Regex regexMath = new Regex(patternMath);

        List<string> finalResult = new List<string>();
        string[] input = Console.ReadLine().Split(new char[] { ',', '\t'}, StringSplitOptions.RemoveEmptyEntries);

        foreach (var item in input)
        {
            MatchCollection collectionDamage = regexDamage.Matches(item);
            MatchCollection collectionMath = regexMath.Matches(item);
            MatchCollection collectionName = regexName.Matches(item);

            List<char> name = new List<char>();
            List<double> damage = new List<double>();
            int countHealth = 0;
            double countDamage = 0.0;
            string monster = item.Trim();

            foreach (Match match in collectionName)
            {
                foreach (char charr in match.Value)
                {
                    name.Add(charr);
                }
            }

            for (int i = 0; i < name.Count; i++)
            {
                countHealth += name[i];
            }


            for (int i = 0; i < collectionDamage.Count; i++)
            {
                damage.Add(double.Parse(collectionDamage[i].ToString()));
            }
            countDamage = damage.Sum();

            foreach (Match match in collectionMath)
            {
                foreach (char charr in match.Value)
                {
                    if (charr == '*')
                    {
                        countDamage *= 2;
                    }
                    else if (charr == '/')
                    {
                        countDamage /= 2;
                    }
                }
                
            }
            string monsterLine = $"{monster} - {countHealth} health, {countDamage:f2} damage";
            finalResult.Add(monsterLine);
        }

        foreach (var item in finalResult.OrderBy(n => n))
        {
            Console.WriteLine(item);
        }
    }
}
