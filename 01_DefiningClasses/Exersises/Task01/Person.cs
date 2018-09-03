using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private int age;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Person()
    {
        this.Age = 1;
        this.Name = "No name";
    }

    public Person(int age):this()
    {
        this.Age = age;
    }
    public Person(string name, int age):this(age)
    {
        this.Name = name;
    }

    public  override string ToString()
    {
        return $"{this.Name} - {this.Age}";
    }

}

