using System;
using System.Collections.Generic;
using System.Text;


   public class Bus:Vehicle
    {
    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
        this.InreaseFuelConsumtion();
    }

    protected override void InreaseFuelConsumtion()
    {
    }

    public override void DriveVehicle(double destination)
    {
        this.FuelConsumption += 1.4;
        base.DriveVehicle(destination);
        this.FuelConsumption -= 1.4;
    }
    public void DriveEmptyBus(double destination)
    {
        base.DriveVehicle(destination);
    }
}

