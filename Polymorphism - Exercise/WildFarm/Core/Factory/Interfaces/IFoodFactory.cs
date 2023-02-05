using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core.Factory.Interfaces
{
    public interface IFoodFactory
    {
        IFood CreateFood(string type, int quantity);
    }
}
