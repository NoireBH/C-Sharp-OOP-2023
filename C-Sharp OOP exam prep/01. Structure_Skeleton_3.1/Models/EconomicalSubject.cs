using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models
{
    public class EconomicalSubject : Subject
    {
        private const double EconomicalSubjectRate = 1.0;

        public EconomicalSubject(int subjectId, string subjectName, double subjectRate) : base(subjectId, subjectName, subjectRate = EconomicalSubjectRate)
        {

        }
    }
}
