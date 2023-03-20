using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;

        public RaceRepository()
        {
            models = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => models;

        public void Add(IRace race)
        {
            models.Add(race);
        }

        public IRace FindByName(string raceName)
        {
            return models.FirstOrDefault(c => c.RaceName == raceName);
        }

        public bool Remove(IRace race)
        {
            var modelToRemove = models.FirstOrDefault(c => c.Equals(race));

            if (modelToRemove == null)
            {
                return false;
            }

            models.Remove(modelToRemove);
            return true;
        }
    }
}
