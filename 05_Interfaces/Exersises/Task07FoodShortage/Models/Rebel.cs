namespace Task07FoodShortage.Models
{
    public class Rebel : Person, IGroupable
    {

        public string Group { get; private set; }

        public Rebel(string name, int age, string group) : base(name, age)
        {
            this.Group = @group;
        }
    }
}