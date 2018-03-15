using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class HardwareComponent
{
    protected HardwareComponent(string name, int maxCapacity, int maxMemory)
    {
        this.Name = name;
        this.MaxCapacity = maxCapacity;
        this.MaxMemory = maxMemory;
        this.SoftwareComponents = new List<SoftwareComponent>();
        this.Capcity = 0;
        this.Memory = 0;
    }

    public string Name { get; private set; }
    public int MaxCapacity { get; protected set; }
    public int MaxMemory { get; protected set; }

    public int Capcity { get;protected set; }

    public int Memory { get;private set; }
    public string Type { get; protected set; }
    public List<SoftwareComponent> SoftwareComponents{ get; private set; }

    public void AddSoftwareComponent(SoftwareComponent softwareComponent)
    {
        this.SoftwareComponents.Add(softwareComponent);
        this.Capcity += softwareComponent.CapacityConsumption;
        this.Memory += softwareComponent.MemoryConsumtion;
    }
    public bool CanTakeSoftware(SoftwareComponent softwareComponent)
    {
        bool haveEnoughCapacity = (softwareComponent.CapacityConsumption + this.Capcity) <= this.MaxCapacity;
        bool haveEnoughMemory = (softwareComponent.MemoryConsumtion + this.Memory) <= this.MaxMemory;
        if (haveEnoughCapacity && haveEnoughMemory)
        {
            return true;
        }
        return false;
    }

    public void RemoveSoftware(string softwareName)
    {
        var softwareComponent = this.SoftwareComponents.First(s => s.Name == softwareName);
        this.SoftwareComponents.Remove(softwareComponent);
        this.Capcity -= softwareComponent.CapacityConsumption;
        this.Memory -= softwareComponent.MemoryConsumtion;
    }
    public abstract void ChangeParams();

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine($"Hardware Component - {this.Name}");
        builder.AppendLine($"Express Software Components - {this.SoftwareComponents.Where(s=>s.Type=="Express").Count()}");
        builder.AppendLine($"Light Software Components - {this.SoftwareComponents.Where(s => s.Type == "Light").Count()}");
        builder.AppendLine($"Memory Usage: {this.Memory} / {this.MaxMemory}");
        builder.AppendLine($"Capacity Usage: {this.Capcity} / {this.MaxCapacity}");
        builder.AppendLine($"Type: {this.Type}");
        if (this.SoftwareComponents.Count>0)
        {
            builder.AppendLine($"Software Components: {string.Join(", ", this.SoftwareComponents.Select(s => s.Name))}");
        }
        else
        {
            builder.AppendLine($"Software Components: None");
        }
        return builder.ToString();
    }
}

//Hardware Component - HDD
//Express Software Components - 1
//Light Software Components - 1
//Memory Usage: 205 / 350
//Capacity Usage: 50 / 50
//Type: Power
//Software Components: Test, Test3
//Hardware Component - SSD
//Express Software Components - 0
//Light Software Components - 2
//Memory Usage: 50 / 300
//Capacity Usage: 60 / 800
//Type: Heavy
//Software Components: Windows, Unix