using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models
{
    public class Hero : IHero
    {
        private string name;
        private int healt;
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
                    throw new ArgumentException(ExceptionMessages.HeroNameNull);
                }

                healt = value;
            }
        }

        public int Armour => throw new NotImplementedException();

        public IWeapon Weapon => throw new NotImplementedException();

        public bool IsAlive => throw new NotImplementedException();

        public void AddWeapon(IWeapon weapon)
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(int points)
        {
            throw new NotImplementedException();
        }
    }
}
