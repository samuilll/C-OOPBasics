using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public abstract class SoftwareComponent
    {
    protected SoftwareComponent(string hardwareComponent, string name, int capacityConsumption, int memoryConsumtion)
    {
        HardwareComponent = hardwareComponent;
        Name = name;
        CapacityConsumption = capacityConsumption;
        MemoryConsumtion = memoryConsumtion;
    }

    public string HardwareComponent { get;private set; }
    public string Name { get; private set; }
    public int CapacityConsumption { get; protected set; }
    public int MemoryConsumtion { get; protected set; }
    public string Type { get; protected set; }

    public abstract void ChangeParams();

}

