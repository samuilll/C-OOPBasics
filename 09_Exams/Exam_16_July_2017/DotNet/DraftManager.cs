using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


 public  class DraftManager
    {
    public DraftManager(SystemState systemState)
    {
        this.SystemState = systemState;
    }

    public SystemState SystemState { get;private set; }


    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            Harvester harvester = null;

            switch (arguments[1])
            {
                case "Sonic":
                    {
                        harvester = new SonicHarvester(arguments[2], double.Parse(arguments[3]), double.Parse(arguments[4]), int.Parse(arguments[5]));
                        break;
                    }
                case "Hammer":
                    {
                        harvester = new HammerHarvester(arguments[2], double.Parse(arguments[3]), double.Parse(arguments[4]));
                        break;
                    }
            }

            this.SystemState.Harvesters.Add(harvester);
            return $"Successfully registered {harvester.Type} Harvester - {harvester.Id}\n";
        }
        catch (Exception ex)
        {

            return ex.Message+Environment.NewLine;
        }
    }
     public string RegisterProvider(List<string> arguments)
      {
        try
        {
            Provider provider = null;

            switch (arguments[1])
            {
                case "Solar":
                    {
                        provider = new SolarProvider( arguments[2], double.Parse(arguments[3]));
                        break;
                    }
                case "Pressure":
                    {
                        provider = new PressureProvider(arguments[2], double.Parse(arguments[3]));
                        break;
                    }
            }

            this.SystemState.Providers.Add(provider);
            return $"Successfully registered {provider.Type} Provider - {provider.Id}\n";
        }
        catch (Exception ex)
        {

            return ex.Message+Environment.NewLine;
        }
    }
    public string Day()
    {
       return this.SystemState.Mining();
    }
    public string Mode(List<string> arguments)
    {
        this.SystemState.ChangeMode(arguments[1]);

        return $"Successfully changed working mode to {this.SystemState.Mode} Mode\n";
    }
    public string Check(List<string> arguments)
    {
        var harvester = this.SystemState.Harvesters.FirstOrDefault(h=>h.Id==arguments[1]);
        var provider = this.SystemState.Providers.FirstOrDefault(h => h.Id == arguments[1]);

        return harvester != null ? harvester.ToString() : provider!=null? provider.ToString():$"No element found with id - {arguments[1]}\n";

    }
    public string ShutDown()
    {
        var builder = new StringBuilder();

        builder.AppendLine("System Shutdown");
        builder.AppendLine($"Total Energy Stored: {this.SystemState.TotalEnergyStored}");
        builder.AppendLine($"Total Mined Plumbus Ore: {this.SystemState.TotalMinedPlumbusOre}");

        return builder.ToString();
    }

}


