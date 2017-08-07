using System;


namespace Vehicles
{
    public class Startup
    {
        public static void Main()
        {
            Car car = null;
            Truck truck = null;
            Bus bus = null;

            for (int i = 0; i < 3; i++)
            {
                string[] inputLine = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string vehicle = inputLine[0];
                double fuelQuantity = double.Parse(inputLine[1]);
                double fuelConsumption = double.Parse(inputLine[2]);
                double tankCapacity = double.Parse(inputLine[3]);
                switch (vehicle)
                {
                    case "Car":
                        car = new Car(fuelQuantity, fuelConsumption, tankCapacity);
                        break;
                    case "Truck":
                        truck = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                        break;
                    case "Bus":
                        bus = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                        break;
                    default:
                        break;
                }
            }

            int numOfRows = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfRows; i++)
            {
                string[] commandLine = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string driveCommand = commandLine[0];
                string vehicleType = commandLine[1];
                double kmOrLiters = double.Parse(commandLine[2]);

                try
                {
                    if (driveCommand == "Drive")
                    {
                        switch (vehicleType)
                        {
                            case "Car":
                                car.Drive(kmOrLiters);
                                break;
                            case "Truck":
                                truck.Drive(kmOrLiters);
                                break;
                            case "Bus":
                                bus.Drive(kmOrLiters);
                                break;
                            default:
                                break;
                        }
                    }
                    else if (driveCommand == "Refuel")
                    {
                        switch (vehicleType)
                        {
                            case "Car":
                                car.Refuel(kmOrLiters);
                                break;
                            case "Truck":
                                truck.Refuel(kmOrLiters);
                                break;
                            case "Bus":
                                bus.PeopleOnBus();
                                bus.Refuel(kmOrLiters);
                                break;
                            default:
                                break;
                        }
                    }
                    else if (driveCommand == "DriveEmpty" && vehicleType == "Bus")
                    {
                        bus.Drive(kmOrLiters);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
               

            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");

        }
    }
}
