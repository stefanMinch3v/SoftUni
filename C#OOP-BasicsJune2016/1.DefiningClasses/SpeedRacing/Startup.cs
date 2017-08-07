using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        List<Car> vehicles = new List<Car>();
        int rows = int.Parse(Console.ReadLine());

        for (int i = 0; i < rows; i++)
        {
            string[] commandLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string carModel = commandLine[0];
            double carFuel = double.Parse(commandLine[1]);
            double fuelCostPer1Km = double.Parse(commandLine[2]);
            Car car = new Car(carModel, carFuel, fuelCostPer1Km);

            if (vehicles.Count == 0)
            {
                vehicles.Add(car);
            }
            else
            {
                if (vehicles.Any(x => x.Model != carModel))
                {
                    vehicles.Add(car);
                }
            }
        }
        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] commandLine = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string drive = commandLine[0];
            if (drive != "Drive")
            {
                input = Console.ReadLine();
                continue;
            }
            string carModel = commandLine[1];
            double amountOfKm = double.Parse(commandLine[2]);
            double sum = vehicles.Where(x => x.Model == carModel).Select(x => x.CalculateFuelAndDistance(amountOfKm)).Sum();
            if (sum <= 0)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                input = Console.ReadLine();
                continue;
            }
            
            vehicles.ForEach(x =>
            {
                if (x.Model == carModel) {
                    x.SetAmountOfKm(amountOfKm);
                }
            });

            input = Console.ReadLine();
        }

        foreach (var item in vehicles)
        {
            Console.WriteLine($"{item.Model} {item.FuelAmount:F2} {item.AmountOfKm}");
        }
    }
}


