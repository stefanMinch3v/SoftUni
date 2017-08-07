using System.Collections.Generic;
using System;
using System.Linq;

public class Car
{
    private string model;
    private string weight; // optional
    private string color; // optional
    private List<Engine> engine = new List<Engine>();

    public Car(string model)
    {
        this.model = model;
        weight = "n/a";
        color = "n/a";
    }
    public Car(string model, string weight, string color)
    {
        this.model = model;
        this.color = color;
        this.weight = weight;
    }
    public Car(string model, string colorOrWeight)
    {
        this.model = model;
        double parseWeight;

        if (Double.TryParse(colorOrWeight, out parseWeight))
        {
            weight = colorOrWeight;
            color = "n/a";
        }
        else
        {
            color = colorOrWeight;
            weight = "n/a";
        }
        
    }

    public void AddEngine(Engine en)
    {
        engine.Add(en);
    }

    public List<Engine> GetEngine
    {
         get { return engine; }
    }

    public string GetModel => this.model;
    public string GetColor => this.color;
    public string GetWeight => this.weight;
}
