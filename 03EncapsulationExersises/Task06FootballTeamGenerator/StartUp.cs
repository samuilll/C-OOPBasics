using System;

namespace Task06FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            var generator = new TeamGenerator();

            while (true)
            {
                var cmdArgs = Console.ReadLine().Split(';');

                if (cmdArgs[0]=="END")
                {
                    break;
                }

                switch (cmdArgs[0])
                {
                    case "Add":
                        {
                            try
                            {
                                AddFunction(generator, cmdArgs);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case "Remove":
                        {
                            try
                            {
                                RemoveFunction(generator, cmdArgs);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case "Rating":
                        {
                            try
                            {
                                RatingFunction(generator, cmdArgs);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case "Team":
                        {
                            try
                            {
                                TeamFunction(generator, cmdArgs);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    default:
                        break;                      
                }
            }
        }

        private static void TeamFunction(TeamGenerator generator, string[] cmdArgs)
        {
            var teamName = cmdArgs[1];
            generator.AddTeam(teamName);
        }

        private static void RatingFunction(TeamGenerator generator, string[] cmdArgs)
        {
            var teamName = cmdArgs[1];
            Console.WriteLine($"{teamName} - {Math.Round(generator.ShowStat(teamName))}");
        }

        private static void RemoveFunction(TeamGenerator generator, string[] cmdArgs)
        {
            var teamName = cmdArgs[1];
            if (!generator.ThereIsSuchATeam(teamName))
            {
                Console.WriteLine(ExceptionMessages.MissingTeamException(teamName));
                return;
            }
            var playerName = cmdArgs[2];
            generator.RemovePlayerToTheTeam(teamName, playerName);
        }

        private static void AddFunction(TeamGenerator generator, string[] cmdArgs)
        {
            var teamName = cmdArgs[1];
            if (!generator.ThereIsSuchATeam(teamName))
            {
                Console.WriteLine(ExceptionMessages.MissingTeamException(teamName));
                return;
            }
            var playerName = cmdArgs[2];
            var endurance = int.Parse(cmdArgs[3]);
            var sprint = int.Parse(cmdArgs[4]);
            var dribble = int.Parse(cmdArgs[5]);
            var passing = int.Parse(cmdArgs[6]);
            var shooting = int.Parse(cmdArgs[7]);
            var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            generator.AddPlayerToTheTeam(teamName, player);
        }
    }
}
