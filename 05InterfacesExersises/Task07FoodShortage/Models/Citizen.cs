
    public class Citizen:Person,IBirthable
    {     
        public string Birthdate { get; private set; }
        public string Id { get; private set; }

        public Citizen(string name, int age, string id, string birthdate) : base(name, age)
        {
            this.Birthdate = birthdate;
            this.Id = id;
        }

    public override void BuyFood()
        {
            this.Food += 10;
        }
    }
