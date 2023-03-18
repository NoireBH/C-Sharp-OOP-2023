using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {   
        private List<IStudent> models;
        public IReadOnlyCollection<IStudent> Models => models;

        public void AddModel(IStudent model)
        {
            models.Add(model);
        }

        public IStudent FindById(int id)
        {
            IStudent student = models.FirstOrDefault(x => x.Id == id);

            return student;
        }

        public IStudent FindByName(string name)
        {
            string[] fullName = name.Split();
            string firstName = fullName[0];
            string lastName = fullName[1];
            IStudent student = models.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            return student;
        }
    }
}
