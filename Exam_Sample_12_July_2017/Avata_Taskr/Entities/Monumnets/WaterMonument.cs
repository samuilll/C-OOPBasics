using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public  class WaterMonument:Monument
    {
    public WaterMonument(string name, int waterAffinity) : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public int WaterAffinity { get; private set; }

    public override int GetAffinityPower()
    {
        return this.WaterAffinity;
    }
    public override string ToString()
    {
        return $"###Water Monument: {this.Name}, Water Affinity: {this.WaterAffinity}";
    }
}

