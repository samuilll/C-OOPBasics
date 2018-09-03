using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class SystemState
    {
    public SystemState()
    {
        this.Hardware = new List<HardwareComponent>();
        this.DumpedHardware = new List<HardwareComponent>();
    }

    public List<HardwareComponent> Hardware { get;private set; }
    public List<HardwareComponent> DumpedHardware { get; private set; }


}

