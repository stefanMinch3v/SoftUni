using System;

class PriceChangeAlert
{
    public static void Main()
    {
        int numberOfPrices = int.Parse(Console.ReadLine());

        double threshold = double.Parse(Console.ReadLine());
        double firstPrice = double.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPrices - 1; i++)
        {
            double secondPrice = double.Parse(Console.ReadLine());
            double compare = ComparePrices(firstPrice, secondPrice);
            bool difference = HasDifference(compare, threshold);
            string infoPrices = GetStringFormat(secondPrice, firstPrice, compare, difference);
            Console.WriteLine(infoPrices);
            firstPrice = secondPrice;
        }
    }

    private static string GetStringFormat(double secondPrice, double firstPrice, double comparePrices, bool hasDifference)
    {
        string saveChanges = "";
        if (comparePrices == 0)
        {
            saveChanges = string.Format("NO CHANGE: {0}", secondPrice);
        }
        else if (hasDifference && (comparePrices > 0.01 && comparePrices < 9.99))
        {
            saveChanges = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", firstPrice, secondPrice, comparePrices);
        }
        else if (hasDifference && (comparePrices > 9.99))
        {
            saveChanges = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", firstPrice, secondPrice, comparePrices);
        }
        else if (hasDifference && (comparePrices < 0))
        {
            saveChanges = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", firstPrice, secondPrice, comparePrices);
        }
        return saveChanges;
    }

    private static bool HasDifference(double threshold, double comparePrices)
    {
        if (Math.Abs(threshold) >= comparePrices)
        {
            return true;
        }
        return false;
    }

    private static double ComparePrices(double firstPrice, double secondPrice)
    {
        double result = (secondPrice - firstPrice) / firstPrice * 100;
        return result;
    }
}
