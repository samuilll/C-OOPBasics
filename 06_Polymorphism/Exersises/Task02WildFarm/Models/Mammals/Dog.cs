
using System;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    public override string AskForFood()
    {
        return "Woof!";
    }

    public override void EatFood(Food food)
    {
        if (food.GetType().Name == "Meat")
        {
            this.Weight += food.Quantity * 0.40;

            this.FoodEaten += food.Quantity;
        }
        else
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
