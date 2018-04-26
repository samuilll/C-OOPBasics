using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster
{
  public  class Engine
    {
        private StorageMaster storageMaster;

        public Engine(StorageMaster storageMaster)
        {
            this.storageMaster = storageMaster;
        }

        public void Run()
        {
            while (true)
            {
                var args = Console.ReadLine().Split();

                var command = args[0];

                if (command=="END")
                {
                    Console.WriteLine(storageMaster.GetSummary());
                    break;
                }

                try
                {
                    args = args.Skip(1).ToArray();

                    string result = this.ReadCommand(command, args);

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(result);
                    Console.ResetColor();
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private string ReadCommand(string command,string[] args)
        {
            switch (command)
            {
                case "AddProduct":
                    {
                        string type = args[0];
                        double price = double.Parse(args[1]);
                        return storageMaster.AddProduct(type,price);
                    }
                case "RegisterStorage":
                    {
                        string type = args[0];
                        string name = args[1];
                        return storageMaster.RegisterStorage(type, name);
                    }
                case "SelectVehicle":
                    {
                        string storageName = args[0];
                        int garageSlot = int.Parse(args[1]);
                        return storageMaster.SelectVehicle(storageName, garageSlot);
                    }
                case "LoadVehicle":
                    {
                        return storageMaster.LoadVehicle(args);
                    }
                case "SendVehicleTo":
                    {
                        string sourceName = args[0];
                        int garageSlot = int.Parse(args[1]);
                        string destinationName = args[2];

                        return storageMaster.SendVehicleTo(sourceName, garageSlot,destinationName);
                    }
                case "UnloadVehicle":
                    {
                        string storageName = args[0];
                        int garageSlot = int.Parse(args[1]);
                        return storageMaster.UnloadVehicle(storageName,garageSlot);
                    }
                case "GetStorageStatus":
                    {
                        string storageName = args[0];
                        return storageMaster.GetStorageStatus(storageName);
                    }
                default:
                    return "";
            }
        }
    }
}
