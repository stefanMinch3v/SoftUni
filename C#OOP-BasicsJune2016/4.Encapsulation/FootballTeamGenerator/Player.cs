using System;
using System.Linq;

public class Player
{
    private string name;
    private double endurance;
    private double sprint;
    private double dribble;
    private double passing;
    private double shooting;

    public Player(string name, double endurance, double sprint, double dribble, double passing, double shooting)
    {
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }
    public double Endurance
    {
        get
        {
            return this.endurance;
        }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(Endurance)} should be between 0 and 100.");
            }
            this.endurance = value;
        }
    }
    public double Sprint
    {
        get
        {
            return this.sprint;
        }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(Sprint)} should be between 0 and 100.");
            }
            this.sprint = value;
        }
    }
    public double Dribble
    {
        get
        {
            return this.dribble;
        }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(Dribble)} should be between 0 and 100.");
            }
            this.dribble = value;
        }
    }
    public double Passing
    {
        get
        {
            return this.passing;
        }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(Passing)} should be between 0 and 100.");
            }
            this.passing = value;
        }
    }
    public double Shooting
    {
        get
        {
            return this.shooting;
        }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(Shooting)} should be between 0 and 100.");
            }
            this.shooting = value;
        }
    }

    public double GetPlayerStats()
    {
        double[] stats = new double[] { this.endurance, this.sprint, this.dribble, this.passing, this.shooting };
        return stats.Average();
    }
}
