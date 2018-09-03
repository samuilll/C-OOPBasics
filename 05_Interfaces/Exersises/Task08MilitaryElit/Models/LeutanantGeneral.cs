using System;
using System.Collections.Generic;
using System.Text;

    public class LeutanantGeneral : Private, ILeutanantGeneral
    {
        public LeutanantGeneral(int id, string firstName, string lastName, double salary) : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<Soldier>();
        }

        public List<Soldier> Privates { get; private set; }

        public void AddPrivate(Soldier soldier)
        {
            this.Privates.Add(soldier);

        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(base.ToString());

            builder.Append("\nPrivates:");

            foreach (var soldier in this.Privates)
            {
                builder.Append(Environment.NewLine+soldier);
            }

            return builder.ToString();
        }
    }
