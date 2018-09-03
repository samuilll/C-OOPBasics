using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Engine
{

    RaceTower raceTower = new RaceTower();

    public void Run()
    {
        var lapsNumber = int.Parse(Console.ReadLine());
         var  trackLenght = int.Parse(Console.ReadLine());

        raceTower.SetTrackInfo(lapsNumber, trackLenght);

        while (raceTower.IsInProgress)
        {
            var input = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).ToList();

            var command = input[0];

            input = input.Skip(1).ToList();

            try
            {
                switch (command)
                {
                    case "RegisterDriver":
                        {
                            raceTower.RegisterDriver(input);
                            break;
                        }
                    case "Leaderboard":
                        {
                            Console.Write(raceTower.GetLeaderboard());
                            break;
                        }
                    case "CompleteLaps":
                        {
                            Console.Write(raceTower.CompleteLaps(input));
                            break;
                        }
                    case "Box":
                        {
                            raceTower.DriverBoxes(input);
                            break;
                        }
                    case "ChangeWeather":
                        {
                            raceTower.ChangeWeather(input);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);            }
        }

        Console.WriteLine($"{raceTower.Winner.Name} wins the race for {raceTower.Winner.TotalTime:f3} seconds.");
    }
}

