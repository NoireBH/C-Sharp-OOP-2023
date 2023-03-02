using FakeAxeAndDummy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Models
{
    public class Hero : IHero
    {
        public Hero(IWeapon weapon)
        {
            Weapon = weapon;
            Xp = 0;
        }

        public IWeapon Weapon {get; private set;}

        public int Xp {get; private set;}

        public void SwingAxe(Itarget target)
        {
            target.takeDamage(this.Weapon.Damage);

            if (target.isDead())
            {
                Xp += target.GiveXP();
            }
        }
    }
}
