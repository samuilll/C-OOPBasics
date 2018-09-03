using System;
using System.Collections.Generic;
using System.Text;


    class Engine
    {

    public string Model { get; set; }
    public string Power { get; set; }
    public string Displacement { get; set; }
    public string Efficiency { get; set; }

    public Engine(string model, string power)
    {
        this.Model = model;
        this.Power = power;
    }
    public Engine(string model, string power, string displacement,string efficiency):this(model,power)
    {
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }
    
}

