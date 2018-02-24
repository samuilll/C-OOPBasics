using System;


class Task05PizzaCalories
{
    static void Main(string[] args)
    {
        var pizzaNameAndToppingsCount = Console.ReadLine().Split();

        var doughParams = Console.ReadLine().Split();

        var pizza = new Pizza();

        try
        {
            pizza = new Pizza(pizzaNameAndToppingsCount[1]);          
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }
        try
        {
            pizza = new Pizza(pizzaNameAndToppingsCount[1], new Dough(doughParams[1], doughParams[2], double.Parse(doughParams[3])));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }
        try
        {
            while (true)
            {
                var toppingParams = Console.ReadLine().Split();

                if (toppingParams[0] == "END")
                {
                    break;
                }
                pizza.AddTopping(new Topping(toppingParams[1], double.Parse(toppingParams[2])));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }

        Console.WriteLine(pizza);
    }
}