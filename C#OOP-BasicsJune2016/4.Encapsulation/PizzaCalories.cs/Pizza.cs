using System;
using System.Collections.Generic;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Toppings> toppings;

    public Pizza(string name)
    {
        Name = name;
        toppings = new List<Toppings>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }

    public void AddDough(string flour, string bakingTechnique, double weight)
    {
        dough = new Dough(flour, bakingTechnique, weight);
    }
    public void AddToppings(string toppingType, double weight)
    {
        Toppings topp = new Toppings(toppingType, weight);
        toppings.Add(topp);
    }
    public int GetNumberOfToppings()
    {
        return toppings.Count;
    }
    private double GetToppingsCalories()
    {
        double sum = 0;
        foreach (var item in toppings)
        {
            sum += item.GetCalories();
        }
        return sum;
    }
    private double GetDoughCalories()
    {
        return dough.GetCalories();
    }
    public double PrintAllCalories()
    {
        return GetDoughCalories() + GetToppingsCalories();
    }
}
