using System;
using System.Collections.Generic;
using System.Text;


public class Product
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

    private decimal cost;

    public decimal Cost
    {
        get { return cost; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.MoneyException);

            }
            this.cost = value;
        }
    }

    public Product(string name, decimal cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

    public override string ToString()
    {
        return this.Name;
    }


}