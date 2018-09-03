using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class HeavyHarwareComponent:HardwareComponent
    {
    public HeavyHarwareComponent(string name, int maxCapacity, int maxMemory):
        base(name,maxCapacity,maxMemory)
    {
        this.Type = "Heavy";
        this.ChangeParams();
    }

    public override void ChangeParams()
    {
        this.MaxCapacity *= 2; 
        this.MaxMemory -= (this.MaxMemory) / 4;
    }
}

