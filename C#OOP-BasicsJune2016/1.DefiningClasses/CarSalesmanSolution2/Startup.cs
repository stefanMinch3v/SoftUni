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
        int rows = int.Parse(Console.ReadLine());
        for (int i = 0; i < rows; i++)
        {
            string[] commandLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Engine engine = null;
            string model = commandLine[0];
            int power = int.Parse(commandLine[1]);

            if (commandLine.Length == 4)
            {
                int displacement = int.Parse(commandLine[2]);
                string efficiency = commandLine[3];
                engine = new Engine(model, power, displacement, efficiency);
            }
            else if (commandLine.Length == 3)
            {
                
                int value;
                if (Int32.TryParse(commandLine[2], out value))
                {
                    int displacement = int.Parse(commandLine[2]);
                    engine = new Engine(model, power, displacement);
                }
                else
                {
                    string efficiency = commandLine[2];
                    engine = new Engine(model, power, efficiency);
                }

            }
            else if (commandLine.Length == 2)
            {
                engine = new Engine(model, power);
            }
            engines.Add(engine);
        }

        int rowsCar = int.Parse(Console.ReadLine());
        for (int i = 0; i < rowsCar; i++)
        {
            string[] commandLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Car car = null;
            string model = commandLine[0];
            string enginee = commandLine[1];
            Engine engine = engines.First(e => e.model == enginee);

            if (commandLine.Length == 4)
            {
                int weight = int.Parse(commandLine[2]);
                string color = commandLine[3];
                car = new Car(model, engine, weight, color);
            }
            else if(commandLine.Length == 3)
            {
                int value;
                if (int.TryParse(commandLine[2], out value))
                {
                    int weight = int.Parse(commandLine[2]);
                    car = new Car(model, engine, weight);
                }
                else
                {
                    string color = commandLine[2];
                    car = new Car(model, engine, color);
                }
            }
            else if (commandLine.Length == 2)
            {
                car = new Car(model, engine);
            }
            cars.Add(car);
        }
        PrintInfo(cars);
    }

    private static void PrintInfo(List<Car> cars)
    {
        foreach (var car in cars)
        {
            Console.WriteLine(car.model + ":");
            Console.WriteLine("  {0}:", car.engine.model);
            Console.WriteLine("    Power: {0}", car.engine.power);
            Console.WriteLine("    Displacement: {0}", car.engine.displacement == -1 ? @"n/a" : car.engine.displacement.ToString());
            Console.WriteLine("    Efficiency: {0}", car.engine.efficiency); 
            Console.WriteLine("  Weight: {0}", car.weight == -1 ? @"n/a" : car.weight.ToString());
            Console.WriteLine("  Color: {0}", car.color);
        }
    }
}
