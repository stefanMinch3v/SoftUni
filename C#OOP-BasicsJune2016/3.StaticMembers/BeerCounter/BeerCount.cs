public class BeerCount
{
    public static long beerInStock;
    public static long beersDrankCount;

    public static void BuyBeer(long bottlesCount)
    {
        beerInStock += bottlesCount; 
    }

    public static void DrinkBeer(long bottlesCount)
    {
        beersDrankCount += bottlesCount;
        beerInStock -= bottlesCount;
    }
}
