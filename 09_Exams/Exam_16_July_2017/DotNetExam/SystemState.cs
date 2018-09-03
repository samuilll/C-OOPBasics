using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


  public  class SystemState
    {
    public SystemState()
    {
        this.Harvesters = new List<Harvester>();
        this.Providers = new List<Provider>();
        this.Mode = "Full";
        this.TotalEnergyStored = 0;
        this.TotalMinedPlumbusOre = 0;
        this.CurrentMinedPlumbusOre = 0;
    }

    public List<Harvester> Harvesters { get;private set; }

    public List<Provider> Providers { get; private set; }

    public string Mode { get;private set; }

    public double CurrentMinedPlumbusOre { get; private set; }
    public double TotalEnergyStored { get;private set; }

    public double TotalMinedPlumbusOre { get;private set; }

    public string Mining()
    {
        var currentEnergyOutput = this.Providers.Select(p => p.EnergyOutput).Sum();
        this.TotalEnergyStored += currentEnergyOutput;
        var currentEnergyRequirement = this.Harvesters.Select(h => h.EnergyRequirement).Sum();
        double currentMinedPlombusOre = 0.0;

        var builder = new StringBuilder();
        switch (this.Mode)
        {
            case "Full":
                {                 
                    if (currentEnergyRequirement<=this.TotalEnergyStored)
                    {
                        this.TotalEnergyStored -= currentEnergyRequirement;
                        currentMinedPlombusOre = this.Harvesters.Select(h => h.OreOutput).Sum();
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

                    if (currentEnergyRequirement <= this.TotalEnergyStored)
                    {
                        this.TotalEnergyStored -= currentEnergyRequirement;
                        currentMinedPlombusOre = this.Harvesters.Select(h => h.OreOutput).Sum()*0.5;
                    }
                    break;
                }
            default:
                break;
        }
        this.TotalMinedPlumbusOre += currentMinedPlombusOre;
        builder.AppendLine($"A day has passed.");
        builder.AppendLine($"Energy Provided: { currentEnergyOutput}");
        builder.AppendLine($"Plumbus Ore Mined: {currentMinedPlombusOre}");

        return builder.ToString();
    }

    public void ChangeMode(string mode)
    {
        switch (mode)
        {
            case "Full":
            {
                    this.Mode = "Full";
                    break;
                }
            case "Energy":
                {
                    this.Mode = "Energy";
                    break;
                }
            case "Half":
                {
                    this.Mode = "Half";
                    break;
                }

            default:
                break;
        }
    }
}

//“A day has passed.
//“Energy Provided: { summedEnergyOutput}”.
//“Plumbus Ore Mined: {summedOreOutput}”.
