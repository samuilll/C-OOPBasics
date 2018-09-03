using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


   public class Family
    {

    private List<Person> members;

    public List<Person> Members
    {
        get { return members; }
        set { members = value; }
    }

    public Family()
    {
        this.Members = new List<Person>();
    }
    public void AddMember(Person person)
    {
        this.Members.Add(person);
    }

    public  Person GetOldestMember()
    {
        return this.Members.OrderByDescending(p => p.Age).First();
    }



}

