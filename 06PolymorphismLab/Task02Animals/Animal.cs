using System;
using System.Collections.Generic;
using System.Text;


  public abstract  class Animal
    {

    protected Animal(string name, string favouriteFood)
    {
        this.Name = name;
        this.FavouriteFood = favouriteFood;
    }

    private string name;

    protected string Name
    {
        get { return name; }
      private  set { name = value; }
    }

    private string favouriteFood;

    protected string FavouriteFood
    {
        get { return favouriteFood; }
      private  set { favouriteFood = value; }
    }

    public virtual string ExplainSelf()
    {
        return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";

    }



}

