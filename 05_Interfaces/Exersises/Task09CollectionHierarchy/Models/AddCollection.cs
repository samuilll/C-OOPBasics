using System;
using System.Collections.Generic;
using System.Text;


    class AddCollection:Collection,IAddable
    {
        public int Add(string element)
        {
            base.Elements.Add(element);
            return base.Elements.Count - 1;
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
    }

