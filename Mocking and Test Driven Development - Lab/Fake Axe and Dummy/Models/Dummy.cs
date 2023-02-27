using Fake_Axe_and_Dummy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fake_Axe_and_Dummy.Models
{
    public class Dummy : IDummy
    {
        public int HP {get; private set;}

        public int Armour { get; private set; }

        public void TakeDamage(int damage)
        {
            this.HP -= damage;

            if (this.HP <= 0)
            {
                Console.WriteLine("Dummy has been defeated!");
                Console.WriteLine("Ending Simulation");
                return;
            }
        }
    }
}
