using System;
using System.Collections.Generic;
using System.Text;

namespace HeroVsDummy.Contracts
{
    public interface IHero
    {   
        public string Name { get;}
        public IReadOnlyList<IWeapon> Weapons { get;}

        public void AttackDummy(IDummy dummy);
       
    }
}
