using System;
using System.Collections.Generic;
using System.Text;


  public abstract  class Driver
    {
    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
        this.TotalTime = 0;
    }

    

    public string Name { get;}

    public double TotalTime { get;private set; }
    public Car Car { get;private set; }
    public double ConsumptionPerKilometer;

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public void DriveOneLap(int trackLength)
    {

        this.TotalTime += (60 / (trackLength / this.Speed));

        double fuelToDecrease = (trackLength * this.ConsumptionPerKilometer);

        this.Car.DecreaseFuelAmount(fuelToDecrease);

        this.Car.Tyre.DriveOneLap(trackLength);
    }

    public void DecreaseTime(double timeSpan)
    {
        this.TotalTime -= timeSpan;
    }

    public void IncreaseTime(double timeSpan)
    {
        this.TotalTime += timeSpan;
    }

    public void ChangeTyres(Tyre tyreToAdd)
    {
        this.Car.ChangeTyre(tyreToAdd);
        this.TotalTime += 20;
    }

    public void Refuel(double fuelToAdd)
    {
        this.Car.Refuel(fuelToAdd);
        this.TotalTime += 20;
    }
}

