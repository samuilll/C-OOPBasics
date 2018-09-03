using System;
using System.Collections.Generic;
using System.Text;


    class Car
    {

    public string Model { get; set; }
    public string Speed { get; set; }

    public Car(string model, string speed)
    {
        this.Model = model;
        this.Speed = speed;
    }

    public override string ToString()
    {
        if (this == null)
        {
            return null;
        }
        else
        {
            return $"{this.Model} {this.Speed}{Environment.NewLine}";
        }
    }
}

