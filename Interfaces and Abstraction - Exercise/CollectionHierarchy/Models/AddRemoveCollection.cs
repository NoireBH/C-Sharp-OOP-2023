using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAdd, IRemove
    {
        private readonly List<string> collection;
        private readonly List<string> removedItems;

        public AddRemoveCollection()
        {
            collection = new List<string>();
            removedItems = new List<string>();
        }
        public int Add(string item)
        {
            collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {   
            var removedItem = collection[collection.Count - 1];
            removedItems.Add(removedItem);
            collection.RemoveAt(collection.Count - 1);

            return removedItem;
        }
    }
}
