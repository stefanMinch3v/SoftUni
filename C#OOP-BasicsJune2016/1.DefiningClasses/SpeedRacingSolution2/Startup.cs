using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        List<Car> cars = new List<Car>();
        int rows = int.Parse(Console.ReadLine());

        for (int i = 0; i < rows; i++)
        {
            string[] commandLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string carModel = commandLine[0];
            double carFuel = double.Parse(commandLine[1]);
            double fuelCostPer1Km = double.Parse(commandLine[2]);
            Car car = new Car(carModel, carFuel, fuelCostPer1Km);
            cars.Add(car);
        }
        string driveCar = Console.ReadLine();
        while(driveCar != "End")
        {
            string[] commandLine = driveCar.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string carModel = commandLine[1];
            int amountOfKm = int.Parse(commandLine[2]);
            Car carToDrive = cars.First(c => c.model == carModel);
            carToDrive.Drive(amountOfKm);

            driveCar = Console.ReadLine();
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.model} {car.fuelAmount:F2} {car.amountOfKm}");
        }
    }
}
