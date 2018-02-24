using System;
using System.Collections.Generic;
using System.Linq;


class Task11PokemonTrainer
    {
        static void Main(string[] args)
    {
        var trainersData = new Dictionary<string,Trainer>();

        SetInfoToTheData(trainersData);

        PlayTheGame(trainersData);

        PrintTheResult(trainersData);
    }

    private static void PrintTheResult(Dictionary<string, Trainer> trainersData)
    {
        foreach (var trainer in trainersData.OrderByDescending(t => t.Value.Badges))
        {
            Console.WriteLine($"{trainer.Value.Name} {trainer.Value.Badges} {trainer.Value.Pokemons.Count}");
        }
    }

    private static void PlayTheGame(Dictionary<string, Trainer> trainersData)
    {
        while (true)
        {
            var element = Console.ReadLine();

            if (element == "End")
            {
                break;
            }

            foreach (var trainer in trainersData.Values)
            {
                if (trainer.Pokemons.Any(p => p.Element == element))
                {
                    trainer.Badges += 1;
                }
                else
                {
                    trainer.CheckAndRemoveDeathPokemons();
                }
            }
        }
    }

    private static void SetInfoToTheData(Dictionary<string, Trainer> trainersData)
    {
        while (true)
        {
            var cmdArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (cmdArgs[0]=="Tournament")
            {
                break;
            }

            var trainerName = cmdArgs[0];
            var pokemonName = cmdArgs[1];
            var pokemonElement = cmdArgs[2];
            var pokemonHealth = int.Parse(cmdArgs[3]);

            var currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if (trainersData.ContainsKey(trainerName))
            {
                trainersData[trainerName].AddPokemon(currentPokemon);
                continue;
            }
            var currentTrainer = new Trainer(trainerName);
            currentTrainer.AddPokemon(currentPokemon);
            trainersData[trainerName] = currentTrainer;

        }
    }
}

