using System;
using System.Collections.Generic;
using System.Text;


public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    public override string AskForFood()
    {
        return "Hoot Hoot";
    }

    public override void EatFood(Food food)
    {
        if (food.GetType().Name=="Meat")
        {
            this.Weight += food.Quantity * 0.25;

            this.FoodEaten += food.Quantity;
        }
        else
        {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}

