using System;


    class Program
    {
        static void Main(string[] args)
        {
            string[] elementsToAdd = Console.ReadLine().Split();

            int countOfRemoves = int.Parse(Console.ReadLine());

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            Console.WriteLine(string.Join(" ",addCollection.AddedIndexesCollection(elementsToAdd)));
            Console.WriteLine(string.Join(" ", addRemoveCollection.AddedIndexesCollection(elementsToAdd)));
            Console.WriteLine(string.Join(" ", myList.AddedIndexesCollection(elementsToAdd)));
            Console.WriteLine(string.Join(" ", addRemoveCollection.RemoveElementsCollection(countOfRemoves)));
            Console.WriteLine(string.Join(" ", myList.RemoveElementsCollection(countOfRemoves)));

    }
}

