using System;
using System.Collections.Generic;
using System.Text;


    class Car
    {

    public string Model { get; set; }
    public Engine Engine { get; set; }
    public string Weight { get; set; }
    public string Color { get; set; }

    public Car(string model, Engine engine)
    {
        this.Model=model;
        this.Engine = engine;
    }
    public Car(string model, Engine engine,string weight,string color):this(model,engine)
    {
        this.Weight = weight;
        this.Color = color;
    }

    public override string ToString()
    {
        return $"{Model}:\n  {Engine.Model}:\n    Power: {Engine.Power}\n    Displacement: {Engine.Displacement}\n    Efficiency: {Engine.Efficiency}\n  Weight: {Weight}\n  Color: {Color}";
    }

  //  Power: 140
  //  Displacement: 28
  //  Efficiency: B
  //Weight: 1300
  //Color: Silver
}

