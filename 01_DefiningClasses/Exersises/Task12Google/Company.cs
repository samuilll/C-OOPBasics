using System;
using System.Collections.Generic;
using System.Text;


    class Company
    {
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }

    public Company(string name,string department,decimal salary)
    {
        this.Name = name;
        this.Department = department;
        this.Salary = salary;
    }

    public override string ToString()
    {
        if (this==null)
        {
            return null;
        }
        else
        {
            return $"{this.Name} {this.Department} {this.Salary:f2}{Environment.NewLine}";
        }
    }
}

// name,department,salary