using System;
using System.Collections.Generic;
using System.Text;


    class Person
    {
    public string Name { get; set; }

    public Company Company { get; set; }

    public List<Pokemon> Pokemons { get; set; }

    public List<Parent> Parents { get; set; }

    public List<Child> Children { get; set; }

    public Car Car { get; set; }

    public Person(string name)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>();
        this.Parents = new List<Parent>();
        this.Children = new List<Child>();
    }

    public override string ToString()
    {
        var result = new StringBuilder();

        result.Append(Name + Environment.NewLine);
        result.Append("Company:"+ Environment.NewLine);
        result.Append(Company);
        result.Append("Car:"+ Environment.NewLine);
        result.Append(Car);
        result.Append("Pokemon:" + Environment.NewLine);
        foreach (var pokemon in Pokemons)
        {
            result.Append($"{pokemon.Name} {pokemon.Type}" + Environment.NewLine);
        }
        result.Append("Parents:" + Environment.NewLine);
        foreach (var parent in Parents)
        {
            result.Append($"{parent.Name} {parent.Birthay}" + Environment.NewLine);
        }
        result.Append("Children:" + Environment.NewLine);
        foreach (var child in Children)
        {
            result.Append($"{child.Name} {child.Birthay}");
        }

        return result.ToString();   
    }
}

//JelioJelev
//Company:
//JeleInc Jelior 777.77
//Car:
//AudiA4 180
//Pokemon:
//Onyx Rock
//Charizard Fire
//Parents:
//JeleJelev 13/03/1933
//Children:
//PudingJelev 01/01/2001