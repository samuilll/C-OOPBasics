public class Ferrari : ICar
{
    private const string model = "488-Spider";

    public  string Model
    {
        get {return model;}
    }
    public string Driver { get; private set; }

    public Ferrari(string driver)
    {
        this.Driver = driver;
    }

    public string Brakes()
    {
        return "Brakes!";
    }

    public string GazPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.Brakes()}/{this.GazPedal()}/{this.Driver}";
    }
}
