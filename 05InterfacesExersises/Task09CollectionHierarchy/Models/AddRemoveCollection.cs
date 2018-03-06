
using System.Collections.Generic;

public class AddRemoveCollection : Collection, IAddable, IRemovable
{
    public int Add(string element)
    {
        base.Elements.Insert(0, element);
        return 0;
    }

    public string Remove()
    {
        var element = base.Elements[base.Elements.Count - 1];

        base.Elements.RemoveAt(base.Elements.Count - 1);

        return element;
    }
    public List<int> AddedIndexesCollection(string[] elements)
    {
        List<int> indexers = new List<int>();

        foreach (var element in elements)
        {
            indexers.Add(this.Add(element));
        }

        return indexers;
    }

    public List<string> RemoveElementsCollection(int count)
    {
        List<string> removedElements = new List<string>();

        for (int i = 0; i < count; i++)
        {
            removedElements.Add(this.Remove());
        }
        return removedElements;
    }
}
