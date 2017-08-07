using System.Collections.Generic;

class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private Tire tire;
    
    public Car(string model)
    {
        this.model = model;
    }

    public string GetModel => this.model;

    public void AddEngine(int speed, int power)
    {
        this.engine = new Engine(speed, power);
    }
    public void AddCargo(int weight, string type)
    {
        this.cargo = new Cargo(weight, type);
    }
    public void AddTire(double pressure1, int age1, double pressure2, int age2, double pressure3, int age3, double pressure4, int age4)
    {
        this.tire = new Tire(pressure1, age1, pressure2, age2, pressure3, age3, pressure4, age4);
    }
    public Engine GetEngine => this.engine;
    public Cargo GetCargo => this.cargo;
    public Tire GetTires => this.tire;
}
