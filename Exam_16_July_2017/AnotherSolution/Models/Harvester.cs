using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Harvester : Machine
{

    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    private double oreOutput;

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's OreOutput");
            }
            oreOutput = value;
        }
    }

    private double energyRequirement;

    // public string Type { get;protected set; }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's EnergyRequirement");
            }
            energyRequirement = value;
        }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine($"{this.GetTypeName()} Harvester - {this.Id}");
        builder.AppendLine($"Ore Output: {this.OreOutput}");
        builder.AppendLine($"Energy Requirement: {this.EnergyRequirement}");


        return builder.ToString();
    }

    internal object GetTypeName()
    {
        var typeName = this.GetType().Name;

        if (typeName.Contains("Sonic"))
        {
            return "Sonic";
        }
        return "Hammer";
    }
}

