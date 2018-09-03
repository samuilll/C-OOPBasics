using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : IDetainable
{
    private string Name { get;  set; }
    private int Age { get;  set; }
    public string Id { get; private set; }
    
    public Citizen(string name, int age, string id)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
    }

    public bool IsDetained(string id)
    {
        if (this.Id.LastIndexOf(id) == this.Id.Length - id.Length)
        {
            return true;
        }
        return false;
    }
}

