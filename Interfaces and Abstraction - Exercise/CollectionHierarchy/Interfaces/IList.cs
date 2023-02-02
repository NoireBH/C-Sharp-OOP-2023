using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Interfaces
{
    public interface IList : IRemove
    {
        public int Count { get; }
    }
}
