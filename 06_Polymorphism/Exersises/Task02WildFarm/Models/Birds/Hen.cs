
    using System;

public class Hen:Bird
    {
    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Cluck";
        }

        public override void EatFood(Food food)
        {
            if (food.GetType().Name == "Meat"|| food.GetType().Name == "Vegetable"|| food.GetType().Name == "Seed"|| food.GetType().Name == "Fruit")
            {
                this.Weight += food.Quantity * 0.35;

                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

    }
}
