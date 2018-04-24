﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public  class AirMonument:Monument
    {
    public AirMonument(string name, int airAffinity):base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public int AirAffinity { get;private set; }

    public override int GetAffinityPower()
    {
        return this.AirAffinity;
    }
    public override string ToString()
    {
        return $"###Air Monument: {this.Name}, Air Affinity: {this.AirAffinity}";
    }
}

