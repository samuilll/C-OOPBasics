using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public  class ExpressSoftwareComponent:SoftwareComponent
    {
    public ExpressSoftwareComponent(string hardwareComponent, string name, int capacityConsumption, int memoryConsumtion):
        base(hardwareComponent,name,capacityConsumption,memoryConsumtion)
    {
        this.Type = "Express";
        this.ChangeParams();
    }

    public override void ChangeParams()
    {
        this.MemoryConsumtion *= 2;
    }
}

