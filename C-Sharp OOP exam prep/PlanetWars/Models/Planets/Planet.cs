using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
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
        private List<IMilitaryUnit> army;
        private List<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            army = new List<IMilitaryUnit>();
            weapons = new List<IWeapon>();
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

        public double MilitaryPower
        {
            get { return militaryPower; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                militaryPower = CalculateMilitaryPower();
            }
        }

        private double CalculateMilitaryPower()
        {
          double militaryPower = army.Sum(x => x.EnduranceLevel) + Weapons.Sum(x => x.DestructionLevel);

            if (army.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
            {
                militaryPower *= 1.3;
            }

            if (weapons.Any(x => x.GetType().Name == "NuclearWeapon "))
            {
                militaryPower  *= 1.45;
            }

            return Math.Round(militaryPower, 3);
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => army;

        public IReadOnlyCollection<IWeapon> Weapons => weapons;

        public void AddUnit(IMilitaryUnit unit)
        {
            army.Add(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.Append($"--Forces: ");

            if (army.Count == 0)
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

            if (weapons.Count == 0)
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
            foreach (var unit in army)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
