using System;
using System.Collections.Generic;
using System.Text;


   public abstract class Provider
    {

    protected Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public string Id { get;private set; }
    public string Type { get; protected set; }

    private double energyOutput;

    public double EnergyOutput
    {
        get { return energyOutput; }
       protected set
        {
            if (value<0 || value>10000)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine($"{this.Type} Provider - {this.Id}");
        builder.AppendLine($"Energy Output: {this.EnergyOutput}");

        return builder.ToString();
    }

}

//Solar Provider - Falcon
//Energy Output: 100
