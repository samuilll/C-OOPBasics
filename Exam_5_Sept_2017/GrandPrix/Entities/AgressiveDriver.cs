using System;
using System.Collections.Generic;
using System.Text;


public class AgressiveDriver:Driver
{
    public AgressiveDriver(string name, Car car):base(name,car)
    {
        this.ConsumptionPerKilometer = 2.7;
    }

    public override double Speed => base.Speed*1.3;
}

