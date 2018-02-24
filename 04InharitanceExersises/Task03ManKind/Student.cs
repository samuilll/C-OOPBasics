using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


  public  class Student:Human
    {
    private string facultyNumber;

    private string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if (value.Length<5 || value.Length>50)
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value;
        }
    }


    public Student(string firstName, string lastname, string number) : base(firstName, lastname)
    {
        this.FacultyNumber = number;
    }

    public override string ToString()
    {
        return ($"First Name: {this.FirstName}\nLast Name: {this.LastName}\nFaculty number: {this.FacultyNumber}\n");
    }
}

