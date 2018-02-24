using System;
using System.Collections.Generic;
using System.Text;


    class Car
    {
    public string Model { get; set; }

    public decimal FuelAmount { get; set; }

    public decimal FuelConsumptionFor1km { get; set; }

    public decimal DistanceTraveled { get; set; }

    public Car(string model, decimal fuelAmount, decimal perKilometer)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumptionFor1km = perKilometer;
    }
}

