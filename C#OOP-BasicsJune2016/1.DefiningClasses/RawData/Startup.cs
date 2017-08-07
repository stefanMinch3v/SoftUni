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
            Car car = null;
            string[] commandLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = commandLine[0];
            int engineSpeed = int.Parse(commandLine[1]);
            int enginePower = int.Parse(commandLine[2]);
            int cargoWeight = int.Parse(commandLine[3]);
            string cargoType = commandLine[4];
            double tire1Pressure = double.Parse(commandLine[5]);
            int tire1Age = int.Parse(commandLine[6]);
            double tire2Pressure = double.Parse(commandLine[7]);
            int tire2Age = int.Parse(commandLine[8]);
            double tire3Pressure = double.Parse(commandLine[9]);
            int tire3Age = int.Parse(commandLine[10]);
            double tire4Pressure = double.Parse(commandLine[11]);
            int tire4Age = int.Parse(commandLine[12]);

            if (cars.Count == 0)
            {
                car = new Car(model);
                car.AddEngine(engineSpeed, enginePower);
                car.AddCargo(cargoWeight, cargoType);
                car.AddTire(tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age);
                cars.Add(car);
            }
            else
            {
                if (cars.Any(c => c.GetModel != model))
                {
                    car = new Car(model);
                    car.AddEngine(engineSpeed, enginePower);
                    car.AddCargo(cargoWeight, cargoType);
                    car.AddTire(tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age);
                    cars.Add(car);
                }
            }
        }
        string printCommand = Console.ReadLine();
        PrintResults(cars, printCommand);
    }

    private static void PrintResults(List<Car> cars, string printCommand)
    {
        if (printCommand == "fragile")
        {
            var carResults = cars.Where(car => car.GetCargo.GetCargoType == "fragile" 
                                            && car.GetTires.GetPressure.Any(pressure => pressure < 1)).Select(car => car.GetModel);
            foreach (var car in carResults)
            {
                Console.WriteLine(car);
            }
        }
        else if (printCommand == "flamable")
        {
            var carResults = cars.Where(car => car.GetCargo.GetCargoType == "flamable"
                                            && car.GetEngine.GetPower > 250).Select(car => car.GetModel);
            foreach (var car in carResults)
            {
                Console.WriteLine(car);
            }
        }
    }
}
