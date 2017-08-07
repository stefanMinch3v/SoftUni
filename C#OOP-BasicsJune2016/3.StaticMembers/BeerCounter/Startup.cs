using System;

public class Startup
{
    public static void Main()
    {
        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] commandLine = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            long boughtBeers = long.Parse(commandLine[0]);
            long drankBeers = long.Parse(commandLine[1]);
            BeerCount.BuyBeer(boughtBeers);
            BeerCount.DrinkBeer(drankBeers);

            input = Console.ReadLine();
        }
        Console.WriteLine($"{BeerCount.beerInStock} {BeerCount.asd}");
    }
}
