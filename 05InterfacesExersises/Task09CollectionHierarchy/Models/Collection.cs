
    using System.Collections.Generic;

public abstract class Collection
{
    private const int MaxCapacity = 100;
    private List<string> collection;

    protected Collection()
    {
        this.collection = new List<string>(MaxCapacity);
    }

    public List<string> Elements
    {
        get { return this.collection; }
    }
}
