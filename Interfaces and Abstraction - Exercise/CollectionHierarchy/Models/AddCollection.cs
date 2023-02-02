using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAdd
    {
        private readonly List<string> collection;

        public AddCollection()
        {
            collection = new List<string>();
        }
        public int Add(string item)
        {
            collection.Add(item);
            return collection.Count - 1;
        }
    }
}
