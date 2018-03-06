using System;
using System.Text;

public class SpecialisedSoldier:Private,ISpecializedSoldier
    {
        private string corps;

        public string Corps
        {
            get { return this.corps;}
            private set
            {
                if (value!= "Airforces"&& value!="Marines")
                {
                    throw new ArgumentException("Invalid Corps");
                }

                this.corps = value;
            }
        }

       

        protected SpecialisedSoldier(int id, string firstName, string lastName, double salary,string corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(base.ToString());

            builder.Append($"\nCorps: {this.Corps}");

            return builder.ToString();
        }
    }
