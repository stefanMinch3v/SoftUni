using System;
using System.Collections.Generic;
using System.Linq;

public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelCostPerKm;
    private double amountOfKm;//

    public Car(string model, double fuelAmount, double fuelCostPerKm)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelCostPerKm = fuelCostPerKm;
        this.amountOfKm = 0;
    }

    public string Model => this.model;
    public double FuelAmount => this.fuelAmount;
    public double FuelCostPerKm => this.fuelCostPerKm;
    public double AmountOfKm => this.amountOfKm;//

    public double CalculateFuelAndDistance(double amountOfKm)
    {
        double sum = 0;
        sum = fuelAmount - (amountOfKm * fuelCostPerKm);
        if (sum > 0)
        {
            fuelAmount = sum;
        }
        return sum;
    }

    public void SetAmountOfKm(double amount)//
    {
        amountOfKm += amount;
    }

}


