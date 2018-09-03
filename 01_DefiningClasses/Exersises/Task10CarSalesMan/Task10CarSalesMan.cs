using System;
using System.Collections.Generic;
using System.Linq;

namespace Task10CarSalesMan
{
    class Task10CarSalesMan
    {
        static void Main(string[] args)
        {
            var engineData = new List<Engine>();
            var carData = new List<Car>();

            StoreTheEngineInformation(engineData);

            StoreTheCarsInformation(engineData, carData);

            PrintTheResult(carData);
        }

        private static void PrintTheResult(List<Car> carData)
        {
            foreach (var car in carData)
            {
                Console.WriteLine(car);
            }
        }

        private static void StoreTheCarsInformation(List<Engine> engineData, List<Car> carData)
        {
            var carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                var cmdArgs = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);

                var model = cmdArgs[0];
                Engine engine = engineData.First(e => e.Model == cmdArgs[1]);
                var weight = "n/a";
                var color = "n/a";

                if (cmdArgs.Length == 3)
                {
                    if (Int32.TryParse(cmdArgs[2], out int p))
                    {
                        weight = cmdArgs[2];
                    }
                    else
                    {
                        color = cmdArgs[2];
                    }
                }
                else if (cmdArgs.Length == 4)
                {
                    weight = cmdArgs[2];
                    color = cmdArgs[3];
                }

                carData.Add(new Car(model, engine, weight, color));
            }
        }

        private static void StoreTheEngineInformation(List<Engine> engineData)
        {
            var engineNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineNumber; i++)
            {
                var cmdArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var model = cmdArgs[0];
                var power = cmdArgs[1];
                var displacement = "n/a";
                var efficiency = "n/a";

                if (cmdArgs.Length == 3)
                {
                    if (Int32.TryParse(cmdArgs[2], out int p))
                    {
                        displacement = cmdArgs[2];
                    }
                    else
                    {
                        efficiency = cmdArgs[2];
                    }
                }
                else if (cmdArgs.Length == 4)
                {
                    displacement = cmdArgs[2];
                    efficiency = cmdArgs[3];
                }

                engineData.Add(new Engine(model, power, displacement, efficiency));
            }
        }
    }
}
