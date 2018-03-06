using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        List<Vehicle> vehicles = CreateTheVehiclesAndAddThemToTheList();

        ExecuteTheOperations(vehicles);

        PrintTheVehiclesState(vehicles);
    }

    private static void PrintTheVehiclesState(List<Vehicle> vehicles)
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle);
        }
    }

    private static void ExecuteTheOperations(List<Vehicle> vehicles)
    {
        int inputsNumber = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputsNumber; i++)
        {
            string[] input = Console.ReadLine().Split();

            string operation = input[0];

            string kindOfVehicle = input[1];

            ExecuteCurrentOperation(vehicles, input, operation, kindOfVehicle);
        }
    }

    private static void ExecuteCurrentOperation(List<Vehicle> vehicles, string[] input, string operation, string kindOfVehicle)
    {
        try
        {
            switch (operation)
            {
                case "Drive":
                    {
                        DriveVehicle(vehicles, input, kindOfVehicle);
                        break;
                    }
                case "Refuel":
                    {
                        RefuelVehicle(vehicles, input, kindOfVehicle);
                        break;
                    }
                case "DriveEmpty":
                    {
                        DriveEmptyVehicle(vehicles, input, kindOfVehicle);
                        break;
                    }
                default:
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void DriveEmptyVehicle(List<Vehicle> vehicles, string[] input, string kindOfVehicle)
    {
        double destination = double.Parse(input[2]);
        Bus bus = (Bus)vehicles.First(v => v.GetType().Name == "Bus");
        bus.DriveEmptyBus(destination);
        Console.WriteLine($"{kindOfVehicle} travelled {destination} km");
    }

    private static void RefuelVehicle(List<Vehicle> vehicles, string[] input, string kindOfVehicle)
    {
        double fuelToAdd = double.Parse(input[2]);
        vehicles.First(v => v.GetType().Name == kindOfVehicle).RefuelVehicle(fuelToAdd);
    }

    private static void DriveVehicle(List<Vehicle> vehicles, string[] input, string kindOfVehicle)
    {
        double destination = double.Parse(input[2]);

        vehicles.First(v => v.GetType().Name == kindOfVehicle).DriveVehicle(destination);
                 
            Console.WriteLine($"{kindOfVehicle} travelled {destination} km");
    }

    private static List<Vehicle> CreateTheVehiclesAndAddThemToTheList()
    {
        string[] carParams = Console.ReadLine().Split();
        string[] truckParams = Console.ReadLine().Split();
        string[] busParams = Console.ReadLine().Split();

        Vehicle car = new Car(double.Parse(carParams[1]), double.Parse(carParams[2]), double.Parse(carParams[3]));
        Vehicle truck = new Truck(double.Parse(truckParams[1]), double.Parse(truckParams[2]), double.Parse(truckParams[3]));
        Vehicle bus = new Bus(double.Parse(busParams[1]), double.Parse(busParams[2]), double.Parse(busParams[3]));

        List<Vehicle> vehicles = new List<Vehicle>() { car, truck,bus };
        return vehicles;
    }
}

