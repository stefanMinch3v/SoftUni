using System;

public class Startup
{
    public static void Main()
    {
        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] commandLine = input.Split();
            int temperature = int.Parse(commandLine[0]);
            string unit = commandLine[1];
            if (unit == "Celsius")
            {
                TConverter.CelsiusToFahrenheit(temperature, unit);
            }
            else if (unit == "Fahrenheit")
            {
                double result = TConverter.FahrenheitToCelsius(temperature, unit);
                Console.WriteLine($"{result:F2} Celsius");
            }

            input = Console.ReadLine();
        }
    }
}
