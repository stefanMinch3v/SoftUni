using System;

public class Toppings
{
    private string type;
    private double weight;

    public Toppings(string type, double weight)
    {
        Type = type;
        Weight = weight;
    }

    public string Type
    {
        get
        {
            return this.type;
        }
        private set
        {
            switch (value.ToLower())
            {
                case "meat":
                    this.type = value;
                    break;
                case "veggies":
                    this.type = value;
                    break;
                case "cheese":
                    this.type = value;
                    break;
                case "sauce":
                    this.type = value;
                    break;
                default:
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
        }
    }
    public double Weight
    {
        get
        {
            return this.weight;
        }
        private set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
            }
            this.weight = value;
        }
    }
    public double GetCalories()
    {
        switch (this.type.ToLower())
        {
            case "meat":
                return 1.2 * (this.weight * 2);
            case "veggies":
                return 0.8 * (this.weight * 2);
            case "cheese":
                return 1.1 * (this.weight * 2);
            case "sauce":
                return 0.9 * (this.weight * 2);
            default:
                return 0;
        }
    }
}
