using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class MusicExercise
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Dictionary<string, Dictionary<string, long>> serbianMusic = new Dictionary<string, Dictionary<string, long>>();
        //string firstPatternCheck = @"\W(@)(?!@)[^\s]";
        //Regex firstRegex = new Regex(firstPatternCheck);

        while (!input.Equals("End"))
        {
            //bool isFirstCheck = firstRegex.IsMatch(input);
            //if (isFirstCheck)
            //{
                //check for @ name
            //}

            string[] validInput = Regex.Split(input, @"\W(@)(?!@)");
            string patternValidInput = @"([a-zA-Z]+\s)";
            Regex regex = new Regex(patternValidInput);

            if (validInput.Length > 1)
            {
                string cityAndPrice = validInput[2];
                bool isValidInput = regex.IsMatch(cityAndPrice);
                if (isValidInput)
                {
                    string[] inputCityPrice = Regex.Split(cityAndPrice, @"([^0-9]+)\s");
                    if (inputCityPrice.Length < 3)
                    {
                        goto readAgain;
                    }
                    else
                    {
                        string city = inputCityPrice[1];
                        string singer = validInput[0];
                        string[] splitDigits = inputCityPrice[2].Trim().Split();
                        long sumPrice = long.Parse(splitDigits[0]) * long.Parse(splitDigits[1]);

                        FillOutDictionary(serbianMusic, city, singer, sumPrice);
                    }
                }
                else
                {
                    goto readAgain;
                }
            }

        readAgain:
            input = Console.ReadLine();
        }

        PrintOutInfo(serbianMusic);


    }

    private static void PrintOutInfo(Dictionary<string, Dictionary<string, long>> serbianMusic)
    {
        foreach (var kvp in serbianMusic)
        {
            var city = kvp.Key;
            Console.WriteLine(city);
            foreach (var secondKvp in kvp.Value.OrderByDescending(price => price.Value))
            {
                var singer = secondKvp.Key;
                var price = secondKvp.Value;
                Console.WriteLine($"#  {singer} -> {price}");
            }
        }
    }

    private static void FillOutDictionary(Dictionary<string, Dictionary<string, long>> serbianMusic, string city, string singer, long sumPrice)
    {
        if (!serbianMusic.ContainsKey(city))
        {
            serbianMusic.Add(city, new Dictionary<string, long>());
            serbianMusic[city].Add(singer, sumPrice);
        }
        else
        {
            if (!serbianMusic[city].ContainsKey(singer))
            {
                serbianMusic[city].Add(singer, sumPrice);
            }
            else
            {
                serbianMusic[city][singer] += sumPrice;
            }
        }
    }
}
