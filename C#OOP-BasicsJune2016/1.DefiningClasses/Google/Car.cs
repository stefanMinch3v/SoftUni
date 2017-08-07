using System;

public class Car
{
    private string model;
    private int speed;

    public Car(string model, int speed)
    {
        this.model = model;
        this.speed = speed;
    }

    public string GetDetails()
    {
        return $"{model} {speed}";
    }
}
