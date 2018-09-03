using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public  class PowerHardwareComponent:HardwareComponent
    {
    public PowerHardwareComponent(string name, int maxCapacity, int maxMemory) :
        base(name, maxCapacity, maxMemory)
    {
        this.Type = "Power";
        this.ChangeParams();
    }

    public override void ChangeParams()
    {
        this.MaxCapacity -= (this.MaxCapacity*3)/4;
        this.MaxMemory+= (this.MaxMemory * 3) / 4;
    }
}

