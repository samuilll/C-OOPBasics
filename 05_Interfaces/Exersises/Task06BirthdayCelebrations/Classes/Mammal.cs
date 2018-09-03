using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public abstract class Mammal : IMammal
{
    public string Name { get; private set; }
    public string Birthay { get; private set; }

    protected Mammal(string name, string birthay)
    {
        this.Name = name;
        this.Birthay = birthay;
    }

    public bool HaveBirthay(string givenYear)
    {
        string mammalBirthdayYear = this.Birthay.Split('/').Last();
        if (mammalBirthdayYear == givenYear)
        {

            return true;
        }
        return false;
    }
}

