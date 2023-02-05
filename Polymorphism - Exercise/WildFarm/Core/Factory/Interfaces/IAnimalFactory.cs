using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core.Factory.Interfaces
{
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string[] inputInfo);
    }
}
