using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        List<Engine> engines = new List<Engine>();
        List<Car> cars = new List<Car>();
        Engine engine = new Engine();

        int rowsEngine = int.Parse(Console.ReadLine());
        for (int i = 0; i < rowsEngine; i++)
        {
            string[] commandLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (commandLine.Length == 4)
            {
                string model = commandLine[0];
                int power = int.Parse(commandLine[1]);
                string displacement = commandLine[2];
                string efficiency = commandLine[3];
                engine = new Engine(model, power, displacement, efficiency);
                engines.Add(engine);
            }
            else if (commandLine.Length == 3)
            {
                string model = commandLine[0];
                int power = int.Parse(commandLine[1]);
                string displacementOrEfficiency = commandLine[2];
                engine = new Engine(model, power, displacementOrEfficiency);
                engines.Add(engine);
            }
            else if(commandLine.Length == 2)
            {
                string model = commandLine[0];
                int power = int.Parse(commandLine[1]);
                engine = new Engine(model, power);
                engines.Add(engine);
            }
        }
        int rowsCar = int.Parse(Console.ReadLine());
        for (int i = 0; i < rowsCar; i++)
        {
            string[] commandLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (commandLine.Length == 4)
            {
                string model = commandLine[0];
                string enginee = commandLine[1];
                string weight = commandLine[2];
                string color = commandLine[3];
                Car car = new Car(model, weight, color);
                engines.ForEach(x =>
                {
                    if (x.GetModel == enginee)
                    {
                        car.AddEngine(x);
                        cars.Add(car);
                    }
                });

            }
            else if (commandLine.Length == 3)
            {
                string model = commandLine[0];
                string enginee = commandLine[1];
                string colorOrWeight = commandLine[2];
                Car car = new Car(model, colorOrWeight);
                engines.ForEach(x =>
                {
                    if (x.GetModel == enginee)
                    {
                        car.AddEngine(x);
                        cars.Add(car);
                    }
                });
            }
            else if (commandLine.Length == 2)
            {
                string model = commandLine[0];
                string enginee = commandLine[1];
                Car car = new Car(model);
                engines.ForEach(x =>
                {
                    if (x.GetModel == enginee)
                    {
                        car.AddEngine(x);
                        cars.Add(car);
                    }
                });
            }
        }
        PrintoutCars(cars, engines);
    }

    private static void PrintoutCars(List<Car> cars, List<Engine> engines)
    {
        foreach (var car in cars)
        {
            Console.WriteLine(car.GetModel + ":");
            foreach (var item in car.GetEngine)
            {
                Console.WriteLine($"  {item.GetModel}:");
                Console.WriteLine($"    Power: {item.GetPower}");
                Console.WriteLine($"    Displacement: {item.GetDisplacement}");
                Console.WriteLine($"    Efficiency: {item.GetEfficiency}");
            }
            Console.WriteLine($"  Weight: {car.GetWeight}");
            Console.WriteLine($"  Color: {car.GetColor}");
        }
    }
}
