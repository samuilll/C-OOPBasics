using System;
using System.Collections.Generic;
using System.Text;


public abstract class Animal
{

    private string name;

    private int age;

    private string gender;

    protected string Gender
    {
        get
        {
            return this.gender;
        }
        set
        {
            this.gender = value;
        }
            }

    public Animal(string name, int age, string gender)
    {
        this.name = name;
        this.age = age;
        this.Gender = gender;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}\n{this.name} {this.age} {this.Gender}";
    }

}

