using System;
using System.Collections.Generic;
using System.Text;

public class UltrasoftTyre : Tyre
{
    private const double blowUpLimit = 30;

    public UltrasoftTyre(double hardness, double grip) : base(hardness)
    {
        this.Name = "Ultrasoft";
        this.Grip = grip;
    }
    public double Grip { get; private set; }

    public override void DriveOneLap(int trackLength)
    {
        this.Degradation -= ((this.Hardness+this.Grip) );

        if (this.Degradation<blowUpLimit)
        {
            throw new ArgumentException("Blown Tyre");
        }
    }
}

