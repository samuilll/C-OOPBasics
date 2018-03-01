using System;
using System.Collections.Generic;

class StartUp
{
    static void Main(string[] args)
    {


        var animals = new List<Animal>();

        GetCommandAndAddToTheData(animals);

        PrintTheResult(animals);
    }

    private static void PrintTheResult(List<Animal> animals)
    {
        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
            SoundProducer.ProduceSound(animal);
        }
    }

    private static void GetCommandAndAddToTheData(List<Animal> animals)
    {
        while (true)
        {
            var animalType = Console.ReadLine();

            if (animalType == "Beast!")
            {
                break;
            }

            var cmdArgs = Console.ReadLine().Split();

            if (cmdArgs.Length != 3 || !Int32.TryParse(cmdArgs[1], out int n) || n < 0)
            {
                PrintTheExeptionMessage();
                continue;
            }
            var name = cmdArgs[0];
            var age = int.Parse(cmdArgs[1]);
            var gender = cmdArgs[2];

            var currentAnimal = AnimalFactory.ProduceAnimal(animalType, name, age, gender);

            if (currentAnimal == null)
            {
                PrintTheExeptionMessage();
                continue;
            }
            else
            {
                animals.Add(currentAnimal);
            }
        }
    }

    private static void PrintTheExeptionMessage()
    {
        Console.WriteLine(new ArgumentException("Invalid input!").Message);
    }
}

