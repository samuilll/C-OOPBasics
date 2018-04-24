using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Engine
{

    public Engine()
    {
        this.nationsBuilder = new NationsBuilder();
    }

    private NationsBuilder nationsBuilder;

    public void Run()
    {
        while (true)
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = input[0];

            input = input.Skip(1).ToList();

            switch (command)
            {
                case "Bender":
                    {
                        nationsBuilder.AssignBender(input);
                        break;
                    }
                case "Monument":
                    {
                        nationsBuilder.AssignMonument(input);
                        break;
                    }
                case "Status":
                    {
                        Console.WriteLine(nationsBuilder.GetStatus(input[0]));
                        break;
                    }
                case "War":
                    {
                        nationsBuilder.IssueWar(input[0]);
                        break;
                    }
                case "Quit":
                    {
                        Console.WriteLine(nationsBuilder.GetWarsRecord());
                        return;
                    }
            }
        }
    }
    
    }

