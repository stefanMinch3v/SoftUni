using System;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        double[] commandLine = Console.ReadLine().Split().Select(double.Parse).ToArray();
        double speed = commandLine[0];
        double fuel = commandLine[1];
        double fuelEconomy = commandLine[2];
        Car car = new Car(speed, fuel, fuelEconomy);

        string input = Console.ReadLine();
        while (!input.Contains("END"))
        {
            string[] commandCar = input.Split();
            switch (commandCar[0])
            {
                case "Travel":
                    car.Travel(double.Parse(commandCar[1]));
                    break;
                case "Distance":
                    car.Distance();
                    break;
                case "Time":
                    car.Time();
                    break;
                case "Fuel":
                    car.Fuel();
                    break;
                case "Refuel":
                    car.Refuel();
                    break;
                default:
                    break;
            }

            input = Console.ReadLine();
        }
    }
}
