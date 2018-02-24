using System;
using System.Collections.Generic;
using System.Linq;

class Task08RawData
{
    static void Main(string[] args)
    {
        var carsAmount = int.Parse(Console.ReadLine());

        var carsData = new List<Car>();

        StoreCarData(carsAmount, carsData);

        var searchedInfo = Console.ReadLine();

        PrintInfo(carsData, searchedInfo);
    }

    private static void PrintInfo(List<Car> carsData, string searchedInfo)
    {
        if (searchedInfo == "fragile")
        {
            foreach (var car in carsData.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t=>t.Pressure<1)))
            {
                Console.WriteLine(car.Model);
            }
        }
        else if (searchedInfo == "flamable")
        {
            foreach (var car in carsData.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250))
            {
                Console.WriteLine(car.Model);
            }
        }
    }

    private static void StoreCarData(int carsAmount, List<Car> carsData)
    {
        for (int i = 0; i < carsAmount; i++)
        {
            var cmdArgs = Console.ReadLine().Split();

            var model = cmdArgs[0];

            var engineSpeed = int.Parse(cmdArgs[1]);

            var enginePower = int.Parse(cmdArgs[2]);

            var cargoWeight = int.Parse(cmdArgs[3]);

            var cargoType = cmdArgs[4];

            var tires = new List<Tire>();

            var engine = new Engine(engineSpeed, enginePower);

            var cargo = new Cargo(cargoWeight, cargoType);

            for (int j = 5; j < 12; j += 2)
            {
                var pressure = double.Parse(cmdArgs[j]);

                var age = int.Parse(cmdArgs[j + 1]);

                var currentTire = new Tire(pressure, age);

                tires.Add(currentTire);
            }

            var car = new Car(model, engine, cargo, tires);

            carsData.Add(car);
        }
    }
}

