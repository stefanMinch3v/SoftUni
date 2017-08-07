using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        List<Person> persons = new List<Person>();
        Person person = null;

        string input = Console.ReadLine();
        while (!input.Equals("End"))
        {
            string[] commandLine = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string name = commandLine[0];
            if (persons.Count == 0)
            {
                person = new Person(name);
                persons.Add(person);
            }
            else
            {
                if (persons.Any(x => x.GetName == name))
                {
                    person = persons.First(p => p.GetName == name);
                }
                else
                {
                    person = new Person(name);
                    persons.Add(person);
                }
                
            }
            switch (commandLine[1])
            {
                case "company":
                    string companyName = commandLine[2];
                    string department = commandLine[3];
                    decimal salary = decimal.Parse(commandLine[4]);
                    person.ReplaceCompany(companyName, department, salary);
                    break;
                case "car":
                    string carModel = commandLine[2];
                    int carSpeed = int.Parse(commandLine[3]);
                    person.ReplaceCar(carModel, carSpeed);
                    break;
                case "pokemon":
                    string pokemonName = commandLine[2];
                    string pokemonType = commandLine[3];
                    Pokemon pokemon = new Pokemon(pokemonName, pokemonType);
                    person.AddPokemon(pokemon);
                    break;
                case "parents":
                    string parentName = commandLine[2];
                    string parentBirthday = commandLine[3];
                    Parent parent = new Parent(parentName, parentBirthday);
                    person.AddParent(parent);
                    break;
                case "children":
                    string childName = commandLine[2];
                    string childBirthday = commandLine[3];
                    Children children = new Children(childName, childBirthday);
                    person.AddChildren(children);
                    break;
                default:
                    break;
            }

            input = Console.ReadLine();
        }
        string pickName = Console.ReadLine();
        PrintInfo(persons, pickName);
    }

    private static void PrintInfo(List<Person> persons, string pickName)
    {
        foreach (var entry in persons.Where(p => p.GetName == pickName))
        {
            Console.WriteLine(entry.GetName);
            Console.WriteLine("Company:");
            if (entry.GetCompany != null)
            {
                Console.WriteLine(entry.GetCompany.GetDetails());
            }
            Console.WriteLine("Car:");
            if (entry.GetCar != null)
            {
                Console.WriteLine(entry.GetCar.GetDetails());
            }
            Console.WriteLine("Pokemon:");
            if (entry.GetPokemons.Count > 0)
            {
                foreach (var pokemon in entry.GetPokemons)
                {
                    Console.WriteLine(pokemon.GetDetails());
                }
            }
            Console.WriteLine("Parents:");
            if (entry.GetParents.Count > 0)
            {
                foreach (var parent in entry.GetParents)
                {
                    Console.WriteLine(parent.GetDetails());
                }
            }
            Console.WriteLine("Children:");
            if (entry.GetChildren.Count > 0)
            {
                foreach (var child in entry.GetChildren)
                {
                    Console.WriteLine(child.GetDetails());
                }
            }
        }
    }
}
