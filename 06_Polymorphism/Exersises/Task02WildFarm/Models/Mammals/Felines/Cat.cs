
    using System;

public class Cat:Feline
    {
    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "Meow";
        }

        public override void EatFood(Food food)
        {
        if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Meat")
        {
            this.Weight += food.Quantity * 0.30;

            this.FoodEaten += food.Quantity;
        }
        else
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
