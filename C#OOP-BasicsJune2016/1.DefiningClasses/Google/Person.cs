using System;
using System.Collections.Generic;

public class Person
{
    private Company company;
    private Car car;
    private List<Parent> parents = new List<Parent>();
    private List<Children> children = new List<Children>();
    private List<Pokemon> pokemons = new List<Pokemon>();
    private string name;

    public Person(string name)
    {
        this.name = name;
    }

    public string GetName => this.name;

    public void ReplaceCompany(string name, string department, decimal salary)
    {
        this.company = new Company(name, department, salary);
    }
    public void ReplaceCar(string carModel, int carSpeed)
    {
        this.car = new Car(carModel, carSpeed);
    }
    public void AddParent(Parent p)
    {
        parents.Add(p);
    }
    public void AddChildren(Children ch)
    {
        children.Add(ch);
    }
    public void AddPokemon(Pokemon pok)
    {
        pokemons.Add(pok);
    }

    public List<Parent> GetParents => this.parents;
    public List<Children> GetChildren => this.children;
    public List<Pokemon> GetPokemons => this.pokemons;
    public Company GetCompany => this.company;
    public Car GetCar => this.car;
}
