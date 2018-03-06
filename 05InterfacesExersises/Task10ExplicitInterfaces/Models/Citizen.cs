using System;
using System.Collections.Generic;
using System.Text;

public class Citizen:IResident,IPerson
    {
        private string name;
        private int age;
        private string country;

        public string Country => this.country;
        public int Age => this.age;
        public string Name => this.name;

    public Citizen(string name, string country,int age)
        {
            this.name = name;
            this.age = age;
            this.country = country;
        }


    string IPerson.GetName()
        {
            return this.Name;
        }

        string IResident.GetName()
        {
            return "Mr/Ms/Mrs " + this.Name;
        }
}

