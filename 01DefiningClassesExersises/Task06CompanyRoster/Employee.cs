using System;
using System.Collections.Generic;
using System.Text;


    class Employee
    {

    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    private string position;

    public string Position
    {
        get { return position; }
        set { position = value; }
    }

    private int age;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    private string department;

    public string Department
    {
        get { return department; }
        set { department = value; }
    }

    private string email;

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public Employee(string name, decimal salary, string position, string department)
    {
        this.Name = name;
        this.Position = position;
        this.Salary = salary;
        this.department = department;
        this.Email = "n/a";
        this.Age = -1;
    }
    public Employee(string name, decimal salary, string position, string department, int age, string email) : this(name, salary, position, department)
    {
        this.Email = email;
        this.Age = age;
    }
    public Employee(string name, decimal salary, string position, string department, int age) : this(name, salary, position, department)
    {
        this.Age = age;
    }
    public Employee(string name, decimal salary, string position, string department, string email) : this(name, salary, position, department)
    {
        this.Email = email;
    }
}

