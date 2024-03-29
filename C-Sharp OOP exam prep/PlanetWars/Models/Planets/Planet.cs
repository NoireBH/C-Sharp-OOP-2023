﻿using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;
        private UnitRepository army;
        private WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            army = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }


        public double Budget
        {
            get { return budget; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                budget = value;
            }
        }

        public double MilitaryPower => Math.Round(CalculateMilitaryPower(), 3);

        private double CalculateMilitaryPower()
        {
          double militaryPower = army.Models.Sum(x => x.EnduranceLevel) + Weapons.Sum(x => x.DestructionLevel);

            if (army.Models.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                militaryPower *= 1.3;
            }

            if (weapons.Models.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                militaryPower  *= 1.45;
            }

            return militaryPower;
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => army.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            army.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.Append($"--Forces: ");

            if (army.Models.Count == 0)
            {
                sb.AppendLine("No units");
            }

            else
            {
                var units = new Queue<string>();

                foreach (var unit in Army)
                {
                    units.Enqueue(unit.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", units));
            }

            sb.Append($"--Combat equipment: ");

            if (weapons.Models.Count == 0)
            {
                sb.AppendLine("No weapons");
            }

            else
            {
                var weapons = new Queue<string>();

                foreach (var weapon in Weapons)
                {
                    weapons.Enqueue(weapon.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", weapons));
            }

            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (Budget - amount < 0)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in army.Models)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
