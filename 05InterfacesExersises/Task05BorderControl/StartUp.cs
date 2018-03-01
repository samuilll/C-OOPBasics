using System;
using System.Collections.Generic;


class StartUp
{
    static void Main(string[] args)
    {

        List<IDetainable> units = new List<IDetainable>();

        AllCitizensAndRobotsToTheList(units);

        var borderCod = Console.ReadLine();

        PrintDetainedIds(units, borderCod);
    }

    private static void PrintDetainedIds(List<IDetainable> units, string borderCod)
    {
        foreach (var unit in units)
        {
            if (unit.IsDetained(borderCod))
            {
                Console.WriteLine(unit.Id);
            }
        }
    }

    private static void AllCitizensAndRobotsToTheList(List<IDetainable> units)
    {
        while (true)
        {
            var input = Console.ReadLine().Split();
            IDetainable unit;

            if (input[0] == "End")
            {
                break;
            }

            if (input.Length == 2)
            {
                unit = new Robot(input[0], input[1]);
            }
            else
            {
                unit = new Citizen(input[0], Int32.Parse(input[1]), input[2]);
            }
            units.Add(unit);
        }
    }
}

