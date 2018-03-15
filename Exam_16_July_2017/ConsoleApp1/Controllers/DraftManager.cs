using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


 public  class DraftManager
    {
    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.mode = "Full";
        this.totalEnergyStored = 0;
        this.totalMinedPlumbusOre = 0;
    }

    private List<Harvester> harvesters;
    private List<Provider> providers;
    private string mode;
    private double totalEnergyStored;
   private double totalMinedPlumbusOre;


    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = HarvesterFactory.CreateHarvester(arguments);
            this.harvesters.Add(harvester);
            return $"Successfully registered {harvester.GetTypeName()} Harvester - {harvester.Id}";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }
     public string RegisterProvider(List<string> arguments)
      {
        try
        {
            var provider = ProviderFactory.CreateProvider(arguments);
            this.providers.Add(provider);
            return $"Successfully registered {provider.GetTypeName()} Provider - {provider.Id}";
        }
        catch (ArgumentException ex)
        {

            return ex.Message;
        }
    }
    public string Day()
    {
        var currentEnergyOutput = this.providers.Select(p => p.EnergyOutput).Sum();
        this.totalEnergyStored += currentEnergyOutput;
        var currentEnergyRequirement = this.harvesters.Select(h => h.EnergyRequirement).Sum();
        double currentMinedPlombusOre = 0.0;

        var builder = new StringBuilder();
        switch (this.mode)
        {
            case "Full":
                {
                    if (currentEnergyRequirement <= this.totalEnergyStored)
                    {
                        this.totalEnergyStored -= currentEnergyRequirement;
                        currentMinedPlombusOre = this.harvesters.Select(h => h.OreOutput).Sum();
                    }
                    break;
                }
            case "Energy":
                {
                    break;
                }
            case "Half":
                {
                    currentEnergyRequirement = currentEnergyRequirement * 60 / 100;

                    if (currentEnergyRequirement <= this.totalEnergyStored)
                    {
                        this.totalEnergyStored -= currentEnergyRequirement;
                        currentMinedPlombusOre = this.harvesters.Select(h => h.OreOutput).Sum() * 0.5;
                    }
                    break;
                }
            default:
                break;
        }
        this.totalMinedPlumbusOre += currentMinedPlombusOre;
        builder.AppendLine($"A day has passed.");
        builder.AppendLine($"Energy Provided: { currentEnergyOutput}");
        builder.Append($"Plumbus Ore Mined: {currentMinedPlombusOre}");

        return builder.ToString();
    }
    public string Mode(List<string> arguments)
    {
        switch (arguments[0])
        {
            case "Full":
                {
                    this.mode = "Full";
                    break;
                }
            case "Energy":
                {
                    this.mode = "Energy";
                    break;
                }
            case "Half":
                {
                    this.mode = "Half";
                    break;
                }

            default:
                break;
        }
        return $"Successfully changed working mode to {this.mode} Mode";
    }
    public string Check(List<string> arguments)
    {
        try
        {
            var harvester = this.harvesters.FirstOrDefault(h => h.Id == arguments[0]);
            var provider = this.providers.FirstOrDefault(h => h.Id == arguments[0]);

            return harvester != null ? harvester.ToString() : provider.ToString();
        }
        catch (Exception)
        {
            return $"No element found with id - {arguments[0]}";
        }

    }
    public string ShutDown()
    {
        var builder = new StringBuilder();

        builder.AppendLine("System Shutdown");
        builder.AppendLine($"Total Energy Stored: {this.totalEnergyStored}");
        builder.Append($"Total Mined Plumbus Ore: {this.totalMinedPlumbusOre}");

        return builder.ToString();
    }   

}


