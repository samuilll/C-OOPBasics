using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public abstract  class Bender
    {
    protected Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public string Name { get;protected set; }

    public int Power { get;protected set; }

    public abstract double TotalPower();
}

