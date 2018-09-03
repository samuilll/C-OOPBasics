using System;
using System.Collections.Generic;
using System.Linq;

class Task12Google
    {
        static void Main(string[] args)
    {
        var personData = new Dictionary<string, Person>();

        SetTheInformation(personData);

        var searchedPersonName = Console.ReadLine();

        Person searchedPerson = personData.Values.First(p => p.Name == searchedPersonName);

        Console.WriteLine(searchedPerson);
    }

    private static void SetTheInformation(Dictionary<string, Person> personData)
    {
        while (true)
        {
            var cmdArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (cmdArgs[0] == "End")
            {
                break;
            }

            switch (cmdArgs[1])
            {

                case "company":
                    {
                        StoreTheCompanyInfo(cmdArgs, personData);
                        break;
                    }
                case "pokemon":
                    {
                        StoreThePokemonInfo(cmdArgs, personData);
                        break;
                    }
                case "parents":
                    {
                        StoreTheParentsInfo(cmdArgs, personData);
                        break;
                    }
                case "children":
                    {
                        StoreTheChildrenInfo(cmdArgs, personData);
                        break;
                    }
                case "car":
                    {
                        StoreTheCarInfo(cmdArgs, personData);
                        break;
                    }
                default:
                    break;
            }
        }
    }

    private static void StoreTheCarInfo(string[] cmdArgs, Dictionary<string, Person> personData)
    {
        var personName = cmdArgs[0];
        var carModel = cmdArgs[2];
        var carSpeed = cmdArgs[3];
        var car = new Car(carModel, carSpeed);

        if (personData.ContainsKey(personName))
        {
            personData[personName].Car = car;
            return;
        }

        personData[personName] = new Person(personName);
        personData[personName].Car = car;
    }

    private static void StoreTheChildrenInfo(string[] cmdArgs, Dictionary<string, Person> personData)
    {
        var personName = cmdArgs[0];
        var childName = cmdArgs[2];
        var childBirthay = cmdArgs[3];
        var child = new Child(childName, childBirthay);

        if (personData.ContainsKey(personName))
        {
            personData[personName].Children.Add(child);
            return;
        }

        personData[personName] = new Person(personName);
        personData[personName].Children.Add(child);
    }

    private static void StoreTheParentsInfo(string[] cmdArgs, Dictionary<string, Person> personData)
    {
        var personName = cmdArgs[0];
        var parentName = cmdArgs[2];
        var parentBirthay = cmdArgs[3];
        var parent = new Parent(parentName, parentBirthay);

        if (personData.ContainsKey(personName))
        {
            personData[personName].Parents.Add(parent);
            return;
        }

        personData[personName] = new Person(personName);
        personData[personName].Parents.Add(parent);
    }

    private static void StoreThePokemonInfo(string[] cmdArgs, Dictionary<string, Person> personData)
    {
        var personName = cmdArgs[0];
        var pokemonName = cmdArgs[2];
        var pokemonType = cmdArgs[3];
        var pokemon = new Pokemon(pokemonName, pokemonType);

        if (personData.ContainsKey(personName))
        {
            personData[personName].Pokemons.Add(pokemon);
            return;
        }

        personData[personName] = new Person(personName);
        personData[personName].Pokemons.Add(pokemon);
    }

    private static void StoreTheCompanyInfo(string[] cmdArgs, Dictionary<string, Person> personData)
    {
        var personName = cmdArgs[0];
        var companyName = cmdArgs[2];
        var department = cmdArgs[3];
        var salary = decimal.Parse(cmdArgs[4]);
        var company = new Company(companyName, department, salary);

        if (personData.ContainsKey(personName))
        {
            personData[personName].Company = company;
            return;
        }

        personData[personName] = new Person(personName);
        personData[personName].Company = company;
    }
}

