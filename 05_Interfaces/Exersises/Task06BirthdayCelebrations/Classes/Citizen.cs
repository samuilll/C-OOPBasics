
public class Citizen : Mammal,IDetainable
{
    public Citizen(string name, int age,string id, string birthay) : base(name, birthay)
    {
        this.Age = age;
        this.Id = id;
    }

    public int Age { get; private set; }
    public string Id { get; private set; }
}
