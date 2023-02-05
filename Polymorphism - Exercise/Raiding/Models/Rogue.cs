using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    internal class Rogue : BaseHero
    {
        private const int power = 80;
        public Rogue(string name) : base(name, power)
        {

        }

        public override string CastAbility()
        {
            return base.CastAbility() + $"hit for {power} damage";
        }
    }
}
