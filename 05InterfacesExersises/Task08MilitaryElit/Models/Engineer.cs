
using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public List<Repair> Repairs { get; private set; }

    public Engineer(int id, string firstName, string lastName, double salary, string corps) : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = new List<Repair>();
    }

    public void AddReapir(Repair repair)
    {
        this.Repairs.Add(repair);
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder(base.ToString());

        builder.Append("\nRepairs:");
        foreach (var repair in this.Repairs)
        {
            builder.Append(Environment.NewLine+repair);
        }

        return builder.ToString();
    }
}
