using System;

public static class TConverter
{
    public static void CelsiusToFahrenheit(int temperature, string unit)
    {
        double result = temperature * 1.8 + 32;
        Console.WriteLine($"{result:F2} Fahrenheit");
    }

    public static double FahrenheitToCelsius(int temperature, string unit)
    {
        double result = (temperature - 32) / 1.8;
        return result;
    }
}
