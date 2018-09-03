using System;
using System.Collections.Generic;
using System.Text;


   public abstract class Animal
    {
    protected Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }

    public string Name { get; protected set; }

    public double Weight { get;protected set; }

    public int FoodEaten { get;protected set; }

    public abstract string AskForFood();

    public abstract void EatFood(Food food);
    }

