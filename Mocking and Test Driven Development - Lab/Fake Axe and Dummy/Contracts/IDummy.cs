using System;
using System.Collections.Generic;
using System.Text;

namespace HeroVsDummy.Contracts
{
    public interface IDummy
    {
        public int HP { get; }
        public int Armour { get; }
        public void TakeDamage(int damage);
    }
}
