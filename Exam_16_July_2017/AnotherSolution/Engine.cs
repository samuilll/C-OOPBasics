using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Engine
{
    public Engine()
    {
        this.draftManager = new DraftManager();
    }
    private DraftManager draftManager;

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            var input = Console.ReadLine().Split().ToList();

            var command = input[0];

            switch (command)
            {
                case "RegisterHarvester":
                    {
                        var commands = input.Skip(1).ToList();
                        Console.Write(this.draftManager.RegisterHarvester(commands));
                        break;
                    }
                case "RegisterProvider":
                    {
                        var commands = input.Skip(1).ToList();
                        Console.Write(this.draftManager.RegisterProvider(commands));
                        break;
                    }
                case "Day":
                    {
                        Console.Write(this.draftManager.Day());
                        break;
                    }
                case "Mode":
                    {
                        var commands = input.Skip(1).ToList();
                        Console.Write(this.draftManager.Mode(commands));
                        break;
                    }
                case "Check":
                    {
                        var commands = input.Skip(1).ToList();
                        Console.Write(this.draftManager.Check(commands));
                        break;
                    }
                case "Shutdown":
                    {
                        isRunning = false;
                        Console.Write(this.draftManager.ShutDown());
                        break;
                    }
            }
        }
    }
}

