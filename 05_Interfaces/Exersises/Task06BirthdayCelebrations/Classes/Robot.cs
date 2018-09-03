
public class Robot : IDetainable, INameable
{
    public string Name { get; }
    public string Id { get; }

    public Robot(string name, string id)
    {
        this.Name = name;
        this.Id = id;
    }
}
