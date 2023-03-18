using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> models;
        public IReadOnlyCollection<IUniversity> Models => models;

        public void AddModel(IUniversity model)
        {
            models.Add(model);
        }

        public IUniversity FindById(int id)
        {
            IUniversity university = models.FirstOrDefault(x => x.Id == id);

            return university;
        }

        public IUniversity FindByName(string name)
        {
            IUniversity university = models.FirstOrDefault(x => x.Name == name);

            return university;
        }
    }
}
