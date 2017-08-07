using System;

public class Engine
{
    public string model;
    public int power;
    public int displacement; // optional
    public string efficiency; // optional

    public Engine(string model, int power) : this(model, power, -1, @"n/a")
    {

    }

    public Engine(string model, int power, int displacement) : this(model, power, displacement, @"n/a")
    {

    }

    public Engine(string model, int power, string efficiency) : this(model, power, -1, efficiency)
    {

    }

    public Engine(string model, int power, int displacement, string efficiency)
    {
        this.model = model;
        this.power = power;
        this.displacement = displacement;
        this.efficiency = efficiency;
    }
}
