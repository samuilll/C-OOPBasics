using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public  class Person
    {

    protected int age;

    public virtual int Age
    {
        get { return age; }
       protected  set
        {
            if (value<0)
            {
                throw new ArgumentException("Age must be positive!");
            }
            age = value;
        }
    }

    protected  string name;

    public virtual string Name
    {
        get { return name; }
      protected  set
        {
            if (value.Length<3)
            {
                throw new ArgumentException("Name’s length should not be less than 3 symbols!");
            }
            name = value;
        }
    }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"Name: {this.Name}, Age: {this.Age}";
    }
}

