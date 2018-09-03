using System;
using System.Collections.Generic;
using System.Text;


public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
        this.InreaseFuelConsumtion();
    }

    protected override void InreaseFuelConsumtion()
    {
        this.FuelConsumption += 1.6;
    }

    public override void RefuelVehicle(double addedFuelQuantity)
    {
        RefuelValidation(addedFuelQuantity);
        this.FuelQuantity += 0.95 * addedFuelQuantity;
    }
}

