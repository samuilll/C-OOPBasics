
using System;

public abstract class Vehicle
{

    protected Vehicle(double fuelQuantity, double fuelConsumption,double tankCapacity)
    {
        this.FuelConsumption = fuelConsumption;
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuelQuantity;
    }

    private double tankCapacity;

  protected  double TankCapacity
    {
        get { return this.tankCapacity; }
        set
        {
            this.tankCapacity = value;
        }
    }


    private double fuelQuantity;

    protected double FuelQuantity
    {
        get { return fuelQuantity; }
        set
        {
            if (value>this.TankCapacity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                fuelQuantity = value;
            }
        }
    }

    private double fuelConsumption;

    protected double FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }

    protected abstract void InreaseFuelConsumtion();

    public virtual void RefuelVehicle(double addedFuelQuantity)
    {
        RefuelValidation(addedFuelQuantity);
        this.FuelQuantity += addedFuelQuantity;
    }

    protected void RefuelValidation(double addedFuelQuantity)
    {
        if (addedFuelQuantity <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        if (this.TankCapacity < this.FuelQuantity + addedFuelQuantity)
        {
            throw new ArgumentException($"Cannot fit {addedFuelQuantity} fuel in the tank");
        }
    }

    protected static void ThereIsMoreSpaceInTheTank(double addedFuelQuantity)
    {
      
    }

    private bool CanPassDistantion(double distantion)
    {
        if (this.FuelConsumption*distantion<=this.fuelQuantity)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public virtual void DriveVehicle(double destination)
    {
        if (CanPassDistantion(destination))
        {
            this.FuelQuantity -= (this.FuelConsumption * destination);
        }
        else
        {
            throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }
    }

    public override string ToString()
    {
        return $"{this.GetType()}: {this.FuelQuantity:f2}";
    }
}
