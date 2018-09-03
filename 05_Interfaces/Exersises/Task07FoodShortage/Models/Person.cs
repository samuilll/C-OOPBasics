
public class Person : IBayer
{
    public int Food { get; protected set; }
    public string Name { get; private set; }
    public int Age { get; private set; }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.Food = 0;
    }
    public virtual void BuyFood()
    {
        this.Food += 5;
    }


}
