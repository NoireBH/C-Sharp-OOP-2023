using HeroVsDummy.Exceptions;
using HeroVsDummy.Models;
using System;

namespace HeroVsDummy
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dummy dummy = new Dummy(100, 30);
            Weapon excalibur = new Weapon("Excalibur", 60, 1);
            Weapon enumaEish = new Weapon("EnumaEish", 100, 1);
            Weapon gaeBolg = new Weapon("GaeBolg", 80, 1);

            try
            {
                dummy.TakeDamage(enumaEish.AttackDamage + 15);
                dummy.TakeDamage(enumaEish.AttackDamage + 15);
            }
            catch (DeadDummyException e)
            {
                
                Console.WriteLine(e.Message);
                Console.WriteLine("Ending simulation...");
                
            }         

        }
    }
}
