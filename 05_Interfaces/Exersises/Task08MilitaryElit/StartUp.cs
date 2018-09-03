using System;
using System.Collections.Generic;

class StartUp
{
    static void Main(string[] args)
    {
        List<Soldier> soldiers = new List<Soldier>();

        GatheringArmy(soldiers);

        PrintSoldiers(soldiers);
    }
    private static void PrintSoldiers(List<Soldier> soldiers)
    {
        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }

    private static void GatheringArmy(List<Soldier> soldiers)
    {
        while (true)
        {
            string[] cmdArgs = Console.ReadLine().Split();

            if (cmdArgs[0] == "End")
            {
                break;
            }

            Soldier currentSoldier = SoldierFactory.CreateSoldier(cmdArgs, soldiers);

            if (currentSoldier != null)
            {
                soldiers.Add(currentSoldier);
            }
        }
    }
}

