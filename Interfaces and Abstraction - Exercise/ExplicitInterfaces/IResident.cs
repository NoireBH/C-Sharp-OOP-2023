using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    internal interface IResident
    {
        public string Name{ get;}
        public string Country { get; }

        string GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }

    }
}
