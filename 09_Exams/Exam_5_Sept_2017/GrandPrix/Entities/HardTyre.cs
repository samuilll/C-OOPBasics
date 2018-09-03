using System;
using System.Collections.Generic;
using System.Text;


public class HardTyre : Tyre
{

    private const double blowUpLimit = 0;

    public HardTyre(double hardness) : base(hardness)
    {
        this.Name = "Hard";
    }

    public override void DriveOneLap(int trackLength)
    {
        this.Degradation -= ((this.Hardness));

        if (this.Degradation < blowUpLimit)
        {
            throw new ArgumentException("Blown Tyre");
        }
    }
}
