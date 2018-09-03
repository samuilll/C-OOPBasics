using System;
using System.Collections.Generic;
using System.Text;

   public class Human
    {

    private string firstName;

    protected string FirstName
    {
        get { return firstName; }
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }
            if (value.Length<=3)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");

            }
            firstName = value;
        }
    }

    private string lastName;

    protected string LastName
    {
        get { return lastName; }
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: lastName");
            }
            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastname");

            }
            lastName = value;
        }
    }

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

}

