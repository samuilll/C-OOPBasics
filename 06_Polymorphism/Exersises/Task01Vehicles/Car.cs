using System;
using System.Collections.Generic;
using System.Text;


public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumption,double tankCapacity) : base(fuelQuantity, fuelConsumption,tankCapacity)
    {
        this.InreaseFuelConsumtion();
    }

    protected override void InreaseFuelConsumtion()
    {
        this.FuelConsumption+=0.9;
    }
}

