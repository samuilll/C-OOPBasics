using System;
using System.Collections.Generic;
using System.Text;


   public class Car
    {
    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;

        if (this.FuelAmount>160)
        {
            this.FuelAmount = 160;
        }
    }

    public int Hp { get;private set; }
    public double FuelAmount { get;private set; }

    public Tyre Tyre { get; private set; }

    public void DecreaseFuelAmount(double fuelToDecrease)
    {
        this.FuelAmount -= fuelToDecrease;

        if (this.FuelAmount<0)
        {
            throw new ArgumentException("Out of fuel");
        }
    }

    public void ChangeTyre(Tyre tyreToAdd)
    {
        this.Tyre = tyreToAdd;
    }

    public void Refuel(double fuelToAdd)
    {
        this.FuelAmount += fuelToAdd;

        if (this.FuelAmount>160)
        {
            this.FuelAmount = 160;
        }
    }
}

