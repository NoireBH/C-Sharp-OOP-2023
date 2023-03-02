using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Models.Interfaces
{
    public interface Itarget
    {
        int Hp { get; }
        int XpDrop { get; }

        bool IsDead { get; }

        void takeDamage(int damage);
        bool isDead();
        int GiveXP();
    }
}
