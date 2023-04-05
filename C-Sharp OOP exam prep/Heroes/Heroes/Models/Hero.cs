using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models
{
    public abstract class Hero : IHero
    {
        private string name;
        private int healt;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HeroNameNull);
                }

                name = value;
            }
        }

        public int Health
        {
            get { return healt; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroHealthBelowZero);
                }

                healt = value;
            }
        }

        public int Armour
        {
            get { return armour; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroArmourBelowZero);
                }

                armour = value;
            }
        }

        public IWeapon Weapon
        {
            get { return weapon; }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.WeaponNull);
                }

                weapon = value;
            }
        }

        public bool IsAlive => healt > 0;

        public void AddWeapon(IWeapon weapon)
        {
            if (Weapon == default)
            {
                Weapon = weapon;
            }
        }

        public void TakeDamage(int points)
        {   
            var leftArmour = Armour - points;


            if (leftArmour >= 0)
            {
                Armour = leftArmour;  
            }

            else
            {
                Armour = 0;
                var damage = -leftArmour;
                var healtLeft = Health - damage;

                if (healtLeft >= 0)
                {
                    Health = healtLeft;
                }

                else
                {
                    Health = 0;
                }
            }
        }
    }
}
