using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    partial class Paladin : BaseHero
    {
        private const int power = 100;
        public Paladin(string name) : base(name, power)
        {

        }

        public override string CastAbility()
        {
            return base.CastAbility() + $"healed for {power}";
        }
    }
}
