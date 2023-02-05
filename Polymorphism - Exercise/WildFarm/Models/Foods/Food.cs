using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Foods
{
    public abstract class Food : IFood
    {
        public Food(int quality)
        {
            Quantity = quality;
        }

        public int Quantity { get; private set; }
    }
}
