using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {   
        private List<ISupplement> supplements;

        public SupplementRepository()
        {
            supplements = new List<ISupplement>();
        }

        public void AddNew(ISupplement model)
        {
            supplements.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            return supplements.FirstOrDefault(x => x.InterfaceStandard == interfaceStandard);
        }

        public IReadOnlyCollection<ISupplement> Models()
        {
            return supplements.AsReadOnly();
        }

        public bool RemoveByName(string typeName)
        {
            var supplementToRemove = supplements.FirstOrDefault(x => x.GetType().Name == typeName);

            if (supplementToRemove == default)
            {
                return false;
            }

            supplements.Remove(supplementToRemove);

            return true;
        }
    }
}
