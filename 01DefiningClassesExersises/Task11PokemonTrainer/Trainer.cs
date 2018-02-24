using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


    class Trainer
    {
    public string Name { get; set; }
    public int Badges { get; set; }
    public List<Pokemon> Pokemons { get; set; }

    public Trainer(string name)
    {
        this.Name = name;
        this.Badges = 0;
        this.Pokemons = new List<Pokemon>();
    }

    public void AddPokemon(Pokemon pokemon)
    {
        this.Pokemons.Add(pokemon);
    }
    public void CheckAndRemoveDeathPokemons()
    {
        foreach (var pokemon in Pokemons)
        {
            pokemon.Health -= 10;
        }

        while (Pokemons.Where(p=>p.Health<=0).Count()>0)
        {
            Pokemons.Remove(Pokemons.First(p => p.Health <= 0));
        }
    }
}

