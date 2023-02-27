using Fake_Axe_and_Dummy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fake_Axe_and_Dummy.Models
{
    public class Hero : IHero
    { private List<IWeapon> weapons;
        public IReadOnlyList<IWeapon> Weapons {get; private set;}

        public string Name {get; private set;}

        public void AttackDummy(IDummy dummy)
        {
            bool crit = DoesAttackCrit();

            if (crit)
            {
                dummy.TakeDamage(Weapons[0].AttackDamage * 2);
                
            }

            else
            {
                dummy.TakeDamage(Weapons[0].AttackDamage);
            }

            Weapons[0].ReduceDurability();

            if (Weapons[0].Durability <= 0)
            {
                weapons.Remove(weapons[0]);
            }
        }

        private bool DoesAttackCrit()
        {
            Random random = new Random();
            int critNumber = random.Next(1, 4);
            int critLuckyNumber = random.Next(1, 4);

            if (critNumber == critLuckyNumber)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name of Hero: {this.Name}");
            sb.AppendLine("Current weapon of hero :");
            sb.AppendLine(this.weapons[0].ToString());
            sb.AppendLine("Hero's arsenal of weapons :");
            foreach (var weapon in weapons)
            {
                weapon.ToString();
            }
            return sb.ToString().Trim();
        }
    }
}
