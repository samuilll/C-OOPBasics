using System;
using System.Collections.Generic;
using System.Text;


    class Topping
    {
    private string type;

    private string Type
    {
        get { return type; }

        set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies"&& value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }

  
    private double weight;

    private double Weight
    {
        get { return weight; }

        set
        {
            if (!(value >= 1 && value <= 50))
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public double GetTheCalories()
    {
        double modifier = this.Type.ToLower() == "meat" ? 1.2 : this.Type.ToLower() == "veggies" ? 0.8 : this.Type.ToLower() == "cheese"?1.1:this.Type.ToLower() == "sauce"?0.9:0;

        return 2 * this.Weight * modifier;
    }

}

