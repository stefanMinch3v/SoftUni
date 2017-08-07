using System.Collections.Generic;

public class Trainer
{
    private string name;
    private int numOfBadges = 0;
    List<Pokemon> pokemons;

    public Trainer()
    {

    }
    public Trainer(string name)
    {
        this.name = name;
        pokemons = new List<Pokemon>();
    }

    public string GetName => this.name;
    public List<Pokemon> GetAllPokemons => this.pokemons;
    public int GetBadges => this.numOfBadges;
    public int GetNumOfPokemons => this.pokemons.Count;

    public void AddPokemon(Pokemon pokemon)
    {
        pokemons.Add(pokemon);
    }

    public void RemovePokemon(Pokemon pokemon)
    {
        pokemons.Remove(pokemon);
    }

    public void IncreaseBadges()
    {
        numOfBadges++;
    }
    //public int SampleWithAnotherMethod { set { numOfBadges++; } }
}
