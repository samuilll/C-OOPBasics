using System;
using System.Collections.Generic;
using System.Text;


  public abstract  class Tyre
    {
    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public string Name { get;protected set; }
    public double Hardness { get;protected set; }
    public double Degradation { get;protected set; }

    public abstract void DriveOneLap(int trackLength);
}

