using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> army;

        public UnitRepository()
        {
            army = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => army;

        public void AddItem(IMilitaryUnit model)
        {
            army.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return army.FirstOrDefault(x => x.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            var unitToRemove = army.FirstOrDefault(x => x.GetType().Name == name);

            if (unitToRemove == null)
            {
                return false;
            }

            army.Remove(unitToRemove);
            return true;
        }
    }
}
