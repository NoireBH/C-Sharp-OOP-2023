using HeroVsDummy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroVsDummy.Models
{
    public class Weapon : IWeapon
    {
        public Weapon(string name, int attackDamage, int durability)
        {
            Name = name;
            AttackDamage = attackDamage;
            Durability = durability;
        }

        public string Name { get; private set; }

        public int AttackDamage { get; protected set; }

        public int Durability { get; private set; }

        public void ReduceDurability()
        {
            this.Durability -= 1;

            if (this.Durability <= 0)
            {
                Console.WriteLine("Weapon Broke!");
                Console.WriteLine("Please use another weapon!");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name:{this.Name}");
            sb.AppendLine($"AD:{this.AttackDamage}");
            sb.AppendLine($"Durability:{this.Durability}");
            return sb.ToString().Trim();
        }
    }
}
