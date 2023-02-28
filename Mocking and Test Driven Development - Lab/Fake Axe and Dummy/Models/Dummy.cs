using HeroVsDummy.Contracts;
using HeroVsDummy.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroVsDummy.Models
{
    public class Dummy : IDummy
    {
        public Dummy(int hP, int armour)
        {
            HP = hP;
            Armour = armour;
        }

        public int HP {get; private set;}

        public int Armour { get; private set; }

        public void TakeDamage(int damage)
        {   
          int damageToTake =  damage - Armour / 2;

            if (damageToTake > 0)
            {
                this.HP -= damageToTake;
                Console.WriteLine($"Dummy took {damage - Armour / 2} damage!");
            }

            else
            {
                Console.WriteLine("No Damage Taken!");
            }
            
            if (this.HP <= 0)
            {
                this.HP = 0;
                throw new DeadDummyException();
            }

            Console.WriteLine($"Dummy has {HP} HP remaining!");
        }
    }
}
