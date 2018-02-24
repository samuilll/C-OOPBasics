using System;
using System.Collections.Generic;
using System.Text;


  public  class Person
    {

    private string name;

    public string Name
    {
        get { return name; }
       private set
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.NameExeption);
            }
            this.name = value;
        }
    }

    private decimal money;

    public decimal Money
    {
        get { return money; }
       private set
        {
            if (value<0)
            {
                throw new ArgumentException(ExceptionMessages.MoneyException);

            }
            money = value;
        }
    }

    private List<Product> products;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.products = new List<Product>();
    }

    public bool TryToBuyTheProduct(Product product)
    {
        if (this.Money-product.Cost>=0)
        {
            this.Money -= product.Cost;
            this.products.Add(product);
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        if (this.products.Count>0)
        {
            return $"{this.Name} - {string.Join(", ", products)}";
        }
        else
        {
            return $"{this.Name} - Nothing bought";
        }
    }


}

