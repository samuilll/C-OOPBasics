using System;
using System.Collections.Generic;
using System.Text;


public class Tesla : Car, IElectricCar
{

    public Tesla(string model, string color, int battery) : base(model, color)
    {
        this.Battery = battery;
    }

    public override string ToString()
    {
        return $"{this.Color} {this.GetType()} {this.Model} with {this.Battery} Batteries\n{this.Start()}\n{this.Stop()}";
    }

    public int Battery {get;private set;}
}

