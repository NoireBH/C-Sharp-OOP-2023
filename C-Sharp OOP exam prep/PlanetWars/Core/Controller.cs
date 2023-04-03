using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planetRepository;

        public Controller()
        {
            planetRepository = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = planetRepository.FindByName(planetName);

            if (planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName != nameof(AnonymousImpactUnit) &&
                unitTypeName != nameof(SpaceForces) &&
                unitTypeName != nameof(StormTroopers))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit unit;

            if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else
            {
                unit = new AnonymousImpactUnit();
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planetRepository.FindByName(planetName);

            if (planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format
                    (ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName != nameof(BioChemicalWeapon) &&
                weaponTypeName != nameof(NuclearWeapon) &&
                weaponTypeName != nameof(SpaceMissiles))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            IWeapon weapon;

            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else
            {
                weapon = new SpaceMissiles(destructionLevel);
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planetRepository.Models.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            planetRepository.AddItem(new Planet(name, budget));
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in this.planetRepository.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet planet1 = planetRepository.FindByName(planetOne);
            IPlanet planet2 = planetRepository.FindByName(planetTwo);
            bool planetOneWins = false;
            bool nobodyWins = false;

            if (planet1.MilitaryPower > planet2.MilitaryPower)
            {
                planetOneWins = true;
            }

            else if (planet1.MilitaryPower < planet2.MilitaryPower)
            {
                planetOneWins = false;
            }

            else 
            {
                if (planet1.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))
                   && !planet2.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    planetOneWins = true;
                }

                else if (planet1.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))
                   && planet2.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    nobodyWins = true;
                }

                else if (!planet1.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))
                   && !planet2.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    nobodyWins = true;
                }
            }

            if (nobodyWins)
            {
                planet1.Spend(planet1.Budget / 2);
                planet2.Spend(planet2.Budget / 2);
                return String.Format(OutputMessages.NoWinner);
            }


            if (planetOneWins)
            {
                planet1.Spend(planet1.Budget / 2);
                planet1.Profit(planet2.Budget / 2);
                var PlanetTwoWeaponAndUnitBudgetToAdd = planet2.Army.Sum(x => x.Cost) +
                planet2.Weapons.Sum(y => y.Price);
                planet1.Profit(PlanetTwoWeaponAndUnitBudgetToAdd);
                planetRepository.RemoveItem(planet2.Name);
                return String.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }

            else
            {
                planet2.Spend(planet2.Budget / 2);
                planet2.Profit(planet1.Budget / 2);
                var PlanetOneWeaponAndUnitBudgetToAdd = planet1.Army.Sum(x => x.Cost) +
                planet1.Weapons.Sum(y => y.Price);
                planet2.Profit(PlanetOneWeaponAndUnitBudgetToAdd);
                planetRepository.RemoveItem(planet1.Name);
                return String.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }


        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planetRepository.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NoUnitsFound));
            }

            double budgetToSpend = 1.25;
            planet.Spend(budgetToSpend);
            planet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
