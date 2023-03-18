using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository<T> : IRepository<ISubject>
    {
        private List<ISubject> models;
        public IReadOnlyCollection<ISubject> Models => models;

        public void AddModel(ISubject model)
        {
            models.Add(model);
        }

        public ISubject FindById(int id)
        {
            ISubject subject = models.FirstOrDefault(x => x.Id == id);

            return subject;
        }

        public ISubject FindByName(string name)
        {
            ISubject subject = models.FirstOrDefault(x => x.Name == name);

            return subject;
        }
    }
}
