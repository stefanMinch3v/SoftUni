using System;

public class Dough
{
    private string flour;
    private string bakingTechnique;
    private double weight;

    public Dough(string flour, string bakingTechnique, double weight)
    {  
        Flour = flour;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    public string BakingTechnique
    {
        get
        {
            return this.bakingTechnique;
        }
        private set
        {
            switch (value.ToLower())
            {
                case "crispy":
                    this.bakingTechnique = "crispy";
                    break;
                case "chewy":
                    this.bakingTechnique = "chewy";
                    break;
                case "homemade":
                    this.bakingTechnique = "homemade";
                    break;
                default:
                    throw new ArgumentException("Invalid type of dough.");
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
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weight = value;
        }
    }
    public string Flour
    {
        get
        {
            return this.flour;
        }
        private set
        {
            
            if (value.ToLower() == "white")
            {
                this.flour = "White";
            }
            else if (value.ToLower() == "wholegrain")
            {
                this.flour = "Wholegrain";
            }
            else
            {
                throw new ArgumentException("Invalid type of dough.");
            }
        }
    }
    public double GetCalories()
    {
        if (this.flour == "White")
        {
            return 1.5 * GetBakingTechniqueValue(this.bakingTechnique) * (this.weight * 2);
        }
        else if (this.flour == "Wholegrain")
        {
            return 1.0 * GetBakingTechniqueValue(this.bakingTechnique) * (this.weight * 2);
        }
        else
        {
            throw new ArgumentException("Invalid type of dough.");
        }
    }

    private double GetBakingTechniqueValue(string bakingTechnique)
    {
        switch (bakingTechnique)
        {
            case "crispy":
                return 0.9;
            case "chewy":
                return 1.1;
            case "homemade":
                return 1.0;
            default:
                throw new ArgumentException("Invalid type of dough.");
        }
    }
}
