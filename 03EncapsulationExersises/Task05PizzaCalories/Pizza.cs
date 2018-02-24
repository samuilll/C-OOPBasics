using System;
using System.Collections.Generic;
using System.Text;


    class Pizza
    {

    private string name;

    public string Name
    {
        get { return name; }
       private set
        {
            if (value.Length<1 || value.Length>15)
            {
                throw new ArgumentException(ExceptionMessages.PizzaNameException);
            }
            name = value;
        }
    }

    private List<Topping> toppings;

    private List<Topping> Toppings
    {
        get { return toppings; }
        set { toppings = value; }
    }

    private int toppingsCount;

    private Dough dough;

    private Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    public Pizza(string name, Dough dough):this(name)
    {
        this.Dough = dough;
        this.Toppings = new List<Topping>();
    }

    public Pizza(string name)
    {
        this.Name = name;
    }

    public void AddTopping(Topping topping)
    {
        if (this.Toppings.Count<10)
        {
            this.Toppings.Add(topping);
        }
        else
        {
            throw new ArgumentException(ExceptionMessages.TooMuchToppings);
        }
    }

    private double CalculateCallories()
    {
        double callories = 0;

        callories += this.Dough.GetTheCalories();

        foreach (var topping in this.Toppings)
        {
            callories += topping.GetTheCalories();
        }

        return callories;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.CalculateCallories():f2} Calories.";
    }

    public Pizza() { }

}

