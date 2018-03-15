﻿using System;
using System.Collections.Generic;
using System.Text;


  public  class SonicHarvester:Harvester
    {
    public SonicHarvester(string id, double oreOutput, double energyRequirement,int sonicFactor):base(id,oreOutput,energyRequirement)
    {
        this.Type = "Sonic";
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement /= this.SonicFactor;
    }
    public int SonicFactor { get;private set; }
}

