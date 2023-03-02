using FakeAxeAndDummy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Models
{
    public class Hero : IHero
    {
        public IWeapon Weapon {get; private set;}

        public void SwingAxe(Itarget target)
        {
            target.Hp -= this.Weapon.Damage
        }
    }
}
