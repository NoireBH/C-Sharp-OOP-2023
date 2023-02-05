using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public abstract class BaseHero : IHero
    {
        public BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }
        public string Name { get; private set; }

        public int Power { get; protected set; }

        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} ";
        }
    }
}
