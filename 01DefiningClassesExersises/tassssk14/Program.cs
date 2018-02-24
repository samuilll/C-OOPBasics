using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Program
    {
        static void Main(string[] args)
        {
            var catalog = new List<Cat>();

            while (true)
            {
                var cmdArgs = Console.ReadLine().Split();

                if (cmdArgs[0] == "End")
                {
                    break;
                }

                var breed = cmdArgs[0];

                var name = cmdArgs[1];

                var characteristic = double.Parse(cmdArgs[2]);
                if (!catalog.Any(c => c.Name == name))
                {
                    catalog.Add(new Cat(breed, name, characteristic));
                }
                else
                {
                    catalog.Remove(catalog.First(c => c.Name == name));
                    catalog.Add(new Cat(breed, name, characteristic));
                }
            }

            string catToPrintName = Console.ReadLine();

            Console.WriteLine(catalog.FirstOrDefault(c => c.Name == catToPrintName));
        }
    }

