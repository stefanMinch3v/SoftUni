using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Startup
{
    public static void Main()
    {
        List<string> healedAnimals = new List<string>();
        List<string> rehabilitateAnimals = new List<string>();

        string input = Console.ReadLine();
        int countPatient = 0;
        while (input != "End")
        {
            string[] commandLine = input.Split();
            string name = commandLine[0];
            string breed = commandLine[1];
            string therapy = commandLine[2];
            Animal animal = new Animal(name, breed);

            AnimalClinic.patientId++;
            countPatient = AnimalClinic.patientId;

            if (therapy == "heal")
            {
                Console.WriteLine($"Patient {countPatient}: [{animal.name} ({animal.breed})] has been healed!");
                AnimalClinic.healedAnimalCount++;
                healedAnimals.Add($"{name} {breed}");
            }
            else if (therapy == "rehabilitate")
            {
                Console.WriteLine($"Patient {countPatient}: [{animal.name} ({animal.breed})] has been rehabilitated!");
                AnimalClinic.rehabilitedAnimalCount++;
                rehabilitateAnimals.Add($"{name} {breed}");
            }

            input = Console.ReadLine();
        }
        Console.WriteLine($"Total healed animals: {AnimalClinic.healedAnimalCount}");
        Console.WriteLine($"Total rehabilitated animals: {AnimalClinic.rehabilitedAnimalCount}");
        string getTherapy = Console.ReadLine();

        if (getTherapy == "heal")
        {
            foreach (var animal in healedAnimals)
            {
                Console.WriteLine(animal);
            }
        }
        else if (getTherapy == "rehabilitate" )
        {
            foreach (var animal in rehabilitateAnimals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
