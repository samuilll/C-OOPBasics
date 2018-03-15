using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class LightSoftwareComponent:SoftwareComponent
    {
    public LightSoftwareComponent(string hardwareComponent, string name, int capacityConsumption, int memoryConsumtion) :
        base(hardwareComponent, name, capacityConsumption, memoryConsumtion)
    {
        this.Type = "Light";
        this.ChangeParams();
    }

    public override void ChangeParams()
    {
        this.CapacityConsumption += this.CapacityConsumption / 2;
        this.MemoryConsumtion -= this.MemoryConsumtion / 2;
    }
}

