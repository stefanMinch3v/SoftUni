using System;

public class Car
{
    public string model;
    public double fuelAmount;
    public double fuelCostPerKm;
    public double amountOfKm;//

    public Car(string model, double fuelAmount, double fuelCostPerKm)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelCostPerKm = fuelCostPerKm;
        this.amountOfKm = 0;
    }

    public void Drive(int amountOfKm)
    {
        if (amountOfKm <= this.fuelAmount / this.fuelCostPerKm)
        {
            this.amountOfKm += amountOfKm;
            this.fuelAmount -= this.fuelCostPerKm * amountOfKm;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}
