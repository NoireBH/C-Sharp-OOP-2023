using System;
using System.Collections.Generic;
using System.Linq;
using Raiding.Interfaces;
using Raiding.Models;
namespace Raiding
{
    public class Program
    {   
        static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());
            List<IHero> heroes = new List<IHero>();

            while (heroes.Count != numberOfHeroes)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    Factory factory = new Factory();
                    IHero hero = factory.CreateHero(heroType, heroName);
                    heroes.Add(hero);
                    
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                                              
            }



            int bossHp = int.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int RaidPower = heroes.Select(h => h.Power).Sum();

            if (RaidPower >= bossHp)
            {
                Console.WriteLine("Victory!");
            }

            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
