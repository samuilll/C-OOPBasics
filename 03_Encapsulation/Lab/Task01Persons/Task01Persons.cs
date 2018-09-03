using System;
using System.Collections.Generic;
using System.Linq;

public class Task01Persons
    {
        static void Main(string[] args)
        {
        var lines = int.Parse(Console.ReadLine());
        var persons = new List<Person>();
        var team = new Team("Apricot");

        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            try
            {
                var currentPerson = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), double.Parse(cmdArgs[3]));
                persons.Add(currentPerson);
                team.AddPlayer(currentPerson);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }

        var bonusPercent = int.Parse(Console.ReadLine());


        Console.WriteLine($"First team have {team.FirstTeam.Count} players");
        Console.WriteLine($"Reserve team have {team.ReserveTeam.Count} players");
    }
}

