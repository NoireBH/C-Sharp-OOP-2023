using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        public int Id => throw new NotImplementedException();

        public string FirstName => throw new NotImplementedException();

        public string LastName => throw new NotImplementedException();

        public IReadOnlyCollection<int> CoveredExams => throw new NotImplementedException();

        public IUniversity University => throw new NotImplementedException();

        public void CoverExam(ISubject subject)
        {
            throw new NotImplementedException();
        }

        public void JoinUniversity(IUniversity university)
        {
            throw new NotImplementedException();
        }
    }
}
