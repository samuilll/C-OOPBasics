using System;
using System.Collections.Generic;
using System.Text;


  public  class Worker:Human
    {
    private decimal weekSalary;

    public Worker(string firstName, string lastname, decimal weekSalary, decimal workingHours) : base(firstName, lastname)
    {
        this.WeekSalary = weekSalary;
        this.WorkingHours = workingHours;
    }

    private decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value<=10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    private decimal workingHours;

    private decimal WorkingHours
    {
        get { return workingHours; }
        set
        {
            if (value<1 || value>12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workingHours = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {this.FirstName}\nLast Name: {this.LastName}\nWeek Salary: {this.WeekSalary:f2}\nHours per day: {this.WorkingHours:f2}\nSalary per hour: {this.WeekSalary/(this.workingHours*5):f2}\n";
    }


}

