using System;
using System.Collections.Generic;
using System.Text;

namespace Fake_Axe_and_Dummy.Contracts
{
    public interface IWeapon
    {   
        public string Name { get; }
        public int AttackDamage { get; }
        public int Durability { get; }

        public void ReduceDurability();
    }
}
