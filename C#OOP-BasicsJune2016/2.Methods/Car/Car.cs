using System;

class Car
{
    private double speed, fuel, fuelEconomy, passedDistance;

    public Car(double speed, double fuel, double fuelEconomy)
    {
        this.speed = speed;
        this.fuel = fuel;
        this.fuelEconomy = fuelEconomy;
        this.passedDistance = 0;
    }

    public void Distance()
    {
        Console.WriteLine($"Total distance: {passedDistance:F1} kilometers");
    }
    public void Refuel()
    {
        this.fuel += this.fuel;
    }
    public void Fuel()
    {
        Console.WriteLine($"Fuel left: {this.fuel:F1} liters");
    }
    public void Travel(double distance)
    {
        double fuelPer1Km = fuelEconomy / 100;
        double neededFuel = distance * fuelPer1Km;

        if (neededFuel > this.fuel)
        {
            double kmPerLiter = 100 / this.fuelEconomy;
            this.passedDistance += this.fuel * kmPerLiter;
            this.fuel = 0;
        }
        else
        {
            this.fuel -= neededFuel;
            this.passedDistance += distance;
        }
    }
    public void Time()
    {
        double time = this.passedDistance / this.speed;
        double hours = Math.Floor(time);
        double minutes = Math.Floor((time - hours) * 60);
        Console.WriteLine($"Total time: {hours} hours and {minutes} minutes");
    }
}
