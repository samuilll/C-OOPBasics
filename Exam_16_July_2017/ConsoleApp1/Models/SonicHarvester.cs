using System;
using System.Collections.Generic;
using System.Text;


  public  class SonicHarvester:Harvester
    {
    public SonicHarvester(string id, double oreOutput, double energyRequirement,int sonicFactor):base(id,oreOutput,energyRequirement)
    {
        //this.Type = "Sonic";
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement /= this.SonicFactor;
    }
    private int sonicFactor;

    public int SonicFactor
    {
        get { return sonicFactor; }
     private   set
        {
            if (value<=0)
            {
                throw new ArgumentException("Harvester is not registered, because of it's SonicFactor");
            }
            sonicFactor = value;
        }
    }

}

