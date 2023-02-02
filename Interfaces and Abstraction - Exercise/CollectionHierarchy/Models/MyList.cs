using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class MyList : IList 
    {
        private readonly List<string> collection;
        private readonly List<string> removedItems;

        public MyList()
        {
            collection = new List<string>();
            removedItems = new List<string>();            
        }
        public int Count => collection.Count;

        public int Add(string item)
        {
            collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            var removedItem = collection[0];
            removedItems.Add(removedItem);
            collection.RemoveAt(0);
            return removedItem;           
        }
    }
}
