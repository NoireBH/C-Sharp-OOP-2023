﻿using FakeAxeAndDummy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Models
{
    public class Target : Itarget
    {
        public Target(int hp, int xpDrop)
        {
            Hp = hp;
            XpDrop = xpDrop;
        }

        public int Hp { get; private set; }

        public int XpDrop {get; private set; }


        public void takeDamage(int damage)
        {
            this.Hp -= damage;

            if (isDead())
            {
                GiveXP();
                throw new ArgumentException("Target is dead");
            }
        }

        public bool isDead()
        {
            return this.Hp >= 0;
        }

        public int GiveXP()
        {
            return this.XpDrop;
        }
    }
}
