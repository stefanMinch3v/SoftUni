using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int someInt = int.Parse(Console.ReadLine());
        for (int i = 0; i < someInt; i++)
        {
            int[] saveInt = Console.ReadLine().Split().Select(int.Parse).ToArray();
        }
        int sum = 0;

        foreach (var resource in input)
        {
            if (resource.Contains("stone"))
            {
                string stone = string.Empty;
                if (resource.Contains("stone_"))
                {
                    stone = resource.Substring(6, resource.Length - 6);
                }
                else
                {
                    stone = "1";
                }
                sum += int.Parse(stone);
            }
            else if (resource.Contains("gold"))
            {
                string gold = string.Empty;
                if (resource.Contains("gold_"))
                {
                    gold = resource.Substring(5, resource.Length - 5);
                }
                else
                {
                    gold = "1";
                }
                sum += int.Parse(gold);
            }
            else if (resource.Contains("wood"))
            {
                string wood = string.Empty;
                if (resource.Contains("wood_"))
                {
                    wood = resource.Substring(5, resource.Length - 5);
                }
                else
                {
                    wood = "1";
                }
                sum += int.Parse(wood);
            }
            else if (resource.Contains("food"))
            {
                string food = string.Empty;
                if (resource.Contains("food_"))
                {
                    food = resource.Substring(5, resource.Length - 5);
                }
                else
                {
                    food = "1";
                }
                sum += int.Parse(food);
            }
        }
        Console.WriteLine(sum);
    }
}
