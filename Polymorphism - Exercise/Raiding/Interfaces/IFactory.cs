using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Interfaces
{
    public interface IFactory
    {
        IHero CreateHero(string type, string name);
    }
}
