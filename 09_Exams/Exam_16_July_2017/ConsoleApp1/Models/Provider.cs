using System;
using System.Collections.Generic;
using System.Text;


   public abstract class Provider:Machine
    {

    protected Provider(string id, double energyOutput):base(id)
    {
        this.EnergyOutput = energyOutput;
    }

  //  public string Type { get; protected set; }

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

        builder.AppendLine($"{this.GetTypeName()} Provider - {this.Id}");
        builder.Append($"Energy Output: {this.EnergyOutput}");
        return builder.ToString();
    }

    public object GetTypeName()
    {
        var typeName = this.GetType().Name;

        if (typeName.Contains("Solar"))
        {
            return "Solar";
        }
        return "Pressure";

    }
}

//Solar Provider - Falcon
//Energy Output: 100
