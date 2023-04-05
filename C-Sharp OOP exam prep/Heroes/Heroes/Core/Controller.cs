using Heroes.Core.Contracts;
using Heroes.Models;
using Heroes.Models.Contracts;
using Heroes.Repositories;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.FindByName(heroName);
            IWeapon weapon = weapons.FindByName(weaponName);
           
            if (hero == default)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroDoesNotExist, heroName));
            }

            if (weapon == default)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponDoesNotExist, weaponName));
            }

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyHasWeapon, heroName));
            }

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);
            return String.Format(OutputMessages.WeaponAddedToHero, heroName, weapon.GetType().Name.ToLower());
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero;

            if (heroes.Models.Any(h => h.Name == name))
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyExist, name));
            }

            if (type != nameof(Barbarian) && type != nameof(Knight))
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroTypeIsInvalid));
            }

            if (type == nameof(Barbarian))
            {
                hero = new Barbarian(name, health, armour);
                heroes.Add(hero);
                return String.Format(OutputMessages.SuccessfullyAddedBarbarian, name);
            }

            else
            {
                hero = new Knight(name, health, armour);
                heroes.Add(hero);
                return String.Format(OutputMessages.SuccessfullyAddedKnight, name);
            }


        }

        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weapon;

            if (weapons.Models.Any(w => w.Name == name))
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponAlreadyExists, name));
            }

            if (type != nameof(Mace) && type != nameof(Claymore))
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponTypeIsInvalid));
            }

            if (type == nameof(Mace))
            {
                weapon = new Mace(name, durability);
                weapons.Add(weapon);
                return String.Format(OutputMessages.WeaponAddedSuccessfully, type.ToLower() ,name);
            }

            else
            {
                weapon = new Claymore(name, durability);
                weapons.Add(weapon);
                return String.Format(OutputMessages.WeaponAddedSuccessfully, type.ToLower(), name);
            }
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in heroes.Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Name))              
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");

                if (hero.Weapon != null)
                {
                    sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
                }

                else
                {
                    sb.AppendLine("--Weapon: Unarmed");
                }

            }

            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            Map map = new Map();
            return map.Fight(heroes.Models.ToList());
            
        }
    }
}
