using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository<T> : IRepository<T>
    {
        public IReadOnlyCollection<T> Models => throw new NotImplementedException();

        public void AddModel(T model)
        {
            throw new NotImplementedException();
        }

        public T FindById(int id)
        {
            throw new NotImplementedException();
        }

        public T FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
