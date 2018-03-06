using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;


class StartUp
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();

        GetInputLinesAndExecuteLineByLine(animals);

        PrintAnimals(animals);
    }

    private static void PrintAnimals(List<Animal> animals)
    {
        foreach (var ani in animals)
        {
            Console.WriteLine(ani);
        }
    }

    private static void GetInputLinesAndExecuteLineByLine(List<Animal> animals)
    {
        int counter = 0;

        Animal animal = null;
        Food food = null;

        while (true)
        {
            string[] input = Console.ReadLine().Split();

            if (input[0] == "End")
            {
                break;
            }

            if (counter % 2 == 0)
            {
                animal = CreateNewAnimal(input);
                Console.WriteLine(animal.AskForFood());
            }
            else
            {
                try
                {
                    string foodType = input[0];
                    int foodQuantity = int.Parse(input[1]);
                    food = CreateNewFood(foodType, foodQuantity);
                    animal.EatFood(food);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                animals.Add(animal);
            }

            counter++;
        }
    }

    private static Food CreateNewFood(string foodType, int foodQuantity)
    {
        switch (foodType)
        {
            case "Meat": return new Meat(foodQuantity);
            case "Vegetable": return new Vegetable(foodQuantity);
            case "Fruit": return new Fruit(foodQuantity);
            case "Seed": return new Seed(foodQuantity);
            default: return null;
        }
    }

    private static Animal CreateNewAnimal(string[] input)
    {
        string typeOfAnimal = input[0];

        switch (typeOfAnimal)
        {
            case "Cat": return new Cat(input[1], double.Parse(input[2]), input[3], input[4]);
            case "Tiger": return new Tiger(input[1], double.Parse(input[2]), input[3], input[4]);
            case "Owl": return new Owl(input[1], double.Parse(input[2]), double.Parse(input[3]));
            case "Hen": return new Hen(input[1], double.Parse(input[2]), double.Parse(input[3]));
            case "Mouse": return new Mouse(input[1], double.Parse(input[2]), input[3]);
            case "Dog": return new Dog(input[1], double.Parse(input[2]), input[3]);
            default: return null;
        }
    }
}

