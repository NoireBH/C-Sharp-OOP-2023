using Raiding.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Factory : IFactory
    {
        public Factory()
        {

        }
        public IHero CreateHero(string type, string name)
        {
            IHero hero = null;

            switch (type)
            {
                case "Druid": return hero = new Druid(name);
                case "Paladin": return hero = new Paladin(name);
                case "Rogue": return hero = new Rogue(name);
                case "Warrior": return hero = new Warrior(name);
                default: throw new ArgumentException("Invalid hero!");
            }
        }
    }
}
