using System;

public class Engine
{
    private string model;
    private int power;
    private string displacement; // optional
    private string efficiency; // optional

    public Engine()
    {

    }
    public Engine(string model, int power)
    {
        this.model = model;
        this.power = power;
        efficiency = "n/a";
        displacement = "n/a";
    }
    public Engine(string model, int power, string displacement, string efficiency)
    {
        this.model = model;
        this.power = power;
        this.displacement = displacement;
        this.efficiency = efficiency;
    }
    public Engine(string model, int power, string displacementOrEfficiency)
    {
        this.model = model;
        this.power = power;
        int parseDisplacement;

        if (Int32.TryParse(displacementOrEfficiency, out parseDisplacement))
        {
            displacement = displacementOrEfficiency;
            efficiency = "n/a";
        }
        else
        {
            efficiency = displacementOrEfficiency;
            displacement = "n/a";
        }
    }

    public string GetModel => this.model;
    public int GetPower => this.power;
    public string GetDisplacement => this.displacement;
    public string GetEfficiency => this.efficiency;
}
