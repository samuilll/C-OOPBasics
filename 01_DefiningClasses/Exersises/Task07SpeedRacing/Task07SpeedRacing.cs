using System;
using System.Collections.Generic;

class Task07SpeedRacing
{
    static void Main(string[] args)
    {
        var carsData = new Dictionary<string, Car>();

        var cmdNumber = int.Parse(Console.ReadLine());

        StoreTheCarsData(carsData, cmdNumber);

        TryToDrive(carsData);

        PrintDrivingHistory(carsData);
    }
    private static void PrintDrivingHistory(Dictionary<string, Car> carsData)
    {
        foreach (var car in carsData.Values)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
        }
    }

    private static void TryToDrive(Dictionary<string, Car> carsData)
    {
        while (true)
        {
            var cmdArgs = Console.ReadLine().Split();

            if (cmdArgs[0] == "End")
            {
                break;
            }

            var model = cmdArgs[1];

            var distance = decimal.Parse(cmdArgs[2]);

            var neededFuel = carsData[model].FuelConsumptionFor1km * distance;

            var fuelInTheCar = carsData[model].FuelAmount;

            if (neededFuel <= fuelInTheCar)
            {
                carsData[model].DistanceTraveled += distance;
                carsData[model].FuelAmount -= neededFuel;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }

    private static void StoreTheCarsData(Dictionary<string, Car> carsData, int cmdNumber)
    {
        for (int i = 0; i < cmdNumber; i++)
        {
            var cmdArgs = Console.ReadLine().Split();

            var model = cmdArgs[0];

            var fuelAmount = decimal.Parse(cmdArgs[1]);

            var perKilometer = decimal.Parse(cmdArgs[2]);

            var currentCar = new Car(model, fuelAmount, perKilometer);

            carsData[model] = currentCar;
        }
    }
}

