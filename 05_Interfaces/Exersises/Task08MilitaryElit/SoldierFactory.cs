
using System;
using System.Collections.Generic;
using System.Linq;

public class SoldierFactory
{
    public static Soldier CreateSoldier(string[] cmdArgs,List<Soldier> soldiers)
    {
        int id = int.Parse(cmdArgs[1]);
        string firstName = cmdArgs[2];
        string lastName = cmdArgs[3];
        switch (cmdArgs[0])
        {
            case "Private":
                {
                    double salary = double.Parse(cmdArgs[4]);
                    return CreatePrivate(id, firstName, lastName, salary);
                }
            case "Spy":
                {
                    int codeName = int.Parse(cmdArgs[4]);
                    return CreateSpy(id, firstName, lastName, codeName);
                }
            case "Engineer":
                {
                    double salary = double.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];
                    return CreateEngineer(id, firstName, lastName, salary, corps, cmdArgs);
                }
            case "Commando":
                {
                    double salary = double.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];
                    return CreateCommando(id, firstName, lastName, salary, corps, cmdArgs);
                }
            case "LeutenantGeneral":
                {
                    double salary = double.Parse(cmdArgs[4]);

                    return CreateLeutanantGeneral(id, firstName, lastName, salary, cmdArgs,soldiers);
                }
            default: return null;
        }
    }

    private static Soldier CreateLeutanantGeneral(int id, string firstName, string lastName, double salary, string[] cmdArgs, List<Soldier> soldiers)
    {
        LeutanantGeneral general = new LeutanantGeneral(id,firstName,lastName,salary);

        for (int i = 5; i < cmdArgs.Length; i++)
        {
            int currentId = int.Parse(cmdArgs[i]);

            general.AddPrivate(soldiers.First(s=>s.Id==currentId));
        }

        return general;
    }

    private static Soldier CreateCommando(int id, string firstName, string lastName, double salary, string corps, string[] cmdArgs)
    {
        Commando commando = null;

        try
        {
            commando = new Commando(id, firstName, lastName, salary, corps);
        }
        catch (ArgumentException)
        {
            return null;
        }

        for (int i = 6; i < cmdArgs.Length - 1; i += 2)
        {
            try
            {
                string codeName = cmdArgs[i];

                string state = cmdArgs[i + 1];

                commando.AddMission(new Mission(codeName, state));
            }
            catch (Exception)
            {
               continue;
            }
        }

        return commando;
    }

    private static Soldier CreateEngineer(int id, string firstName, string lastName, double salary, string corps, string[] cmdArgs)
    {

        Engineer engineer = null;

        try
        {
             engineer = new Engineer(id, firstName, lastName, salary, corps);
        }
        catch (ArgumentException)
        {
            return null;
        }

        for (int i = 6; i < cmdArgs.Length-1; i+=2)
        {
            string partName = cmdArgs[i];

            int hoursWorked = int.Parse(cmdArgs[i + 1]);

            engineer.AddReapir(new Repair(partName,hoursWorked));
        }

        return engineer;
    }

    private static Soldier CreateSpy(int id, string firstName, string lastName, int codeName)
    {
        return new Spy(id, firstName, lastName, codeName);
    }

    private static Soldier CreatePrivate(int id, string firstName, string lastName, double salary)
    {
        return new Private(id, firstName, lastName, salary);
    }
}
