using System;
using System.Collections.Generic;
using System.Linq;


class StartUp
    {
        static void Main(string[] args)
    {
        List<Person> persons = new List<Person>();

        RegisterPersons(persons);
        EveryBodyBuysFood(persons);
        PrintFoodSum(persons);
    }

    private static void PrintFoodSum(List<Person> persons)
    {
        Console.WriteLine(persons.Select(p => p.Food).Sum());
    }

    private static void EveryBodyBuysFood(List<Person> persons)
    {
        while (true)
        {
            string name = Console.ReadLine();

            if (name == "End")
            {
                break;
            }
            if (persons.Any(p => p.Name == name))
            {
                persons.First(p => p.Name == name).BuyFood();
            }
        }
    }

    private static void RegisterPersons(List<Person> persons)
    {
        int personNumber = int.Parse(Console.ReadLine());

        for (int i = 0; i < personNumber; i++)
        {
            string[] input = Console.ReadLine().Split();
            persons.Add(PersonFactory.CreatePerson(input));
        }
    }
}

