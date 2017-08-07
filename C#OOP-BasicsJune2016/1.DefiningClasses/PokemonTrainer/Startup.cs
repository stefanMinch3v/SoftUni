using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        List<Trainer> trainers = new List<Trainer>();
        Trainer trainer = new Trainer();

        string input = Console.ReadLine();
        while (input != "Tournament")
        {
            string[] commandLine = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string trainerName = commandLine[0];
            string pokemonName = commandLine[1];
            string pokemonElement = commandLine[2];
            int pokemonHealth = int.Parse(commandLine[3]);
            bool unique = true;

            trainers.ForEach(t =>
            {
                t.GetAllPokemons.ForEach(pok =>
                {
                    if(pok.GetName == pokemonName)
                    {
                        unique = false;
                    }
                });
            });

            if (unique == false)
            {
                input = Console.ReadLine();
                continue;
            }

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if (trainers.Count == 0)
            {
                trainer = new Trainer(trainerName);
                trainer.AddPokemon(pokemon);
                trainers.Add(trainer);
            }
            else
            {
                foreach (var tr in trainers)
                {
                    if (tr.GetName == trainerName)
                    {
                        tr.AddPokemon(pokemon);
                        goto end;
                    }
                }
                trainer = new Trainer(trainerName);
                trainer.AddPokemon(pokemon);
                trainers.Add(trainer);
            }

            end: input = Console.ReadLine();
        }

        string inputElement = Console.ReadLine();
        while (inputElement != "End")
        {
            foreach (var t in trainers)
            {
                if (t.GetAllPokemons.Any(p => p.GetElement == inputElement))
                {
                    t.IncreaseBadges();
                }
                else
                {
                    foreach (var pok in t.GetAllPokemons)
                    {
                        pok.DecreaseHealthBy10();
                        if (pok.GetHealth < 1)
                        {
                            t.RemovePokemon(pok);
                            break;
                        }
                    }
                }
            }
           

            inputElement = Console.ReadLine();
        }
        PrintoutResult(trainers);
    }

    private static void PrintoutResult(List<Trainer> trainers)
    {
        foreach (var trainer in trainers.OrderByDescending(b => b.GetBadges))
        {
            Console.WriteLine($"{trainer.GetName} {trainer.GetBadges} {trainer.GetNumOfPokemons}");
        }
    }
}
