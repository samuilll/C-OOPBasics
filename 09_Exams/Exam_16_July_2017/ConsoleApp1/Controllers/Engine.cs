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

        while (true)
        {
            var input = Console.ReadLine();
            List<string> inputParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = inputParts[0];
            inputParts.Remove(inputParts[0]);

            switch (command)
            {
                case "RegisterHarvester":
                    {
                        Console.WriteLine(this.draftManager.RegisterHarvester(inputParts));
                        break;
                    }
                case "RegisterProvider":
                    {
                        Console.WriteLine(this.draftManager.RegisterProvider(inputParts));
                        break;
                    }
                case "Day":
                    {
                        Console.WriteLine(this.draftManager.Day());
                        break;
                    }
                case "Mode":
                    {
                        Console.WriteLine(this.draftManager.Mode(inputParts));
                        break;
                    }
                case "Check":
                    {
                        Console.WriteLine(this.draftManager.Check(inputParts));
                        break;
                    }
                case "Shutdown":
                    {
                        Console.WriteLine(this.draftManager.ShutDown());
                        return;
                    }
            }
        }
    }
}

