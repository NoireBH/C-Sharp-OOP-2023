﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int power = 100;
        public Warrior(string name) : base(name, power)
        {

        }
        public override string CastAbility()
        {
            return base.CastAbility() + $"hit for {power} damage";
        }
    }
}
