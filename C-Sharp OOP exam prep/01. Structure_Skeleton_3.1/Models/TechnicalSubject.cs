using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models
{
    public class TechnicalSubject : Subject
    {
        private const double TechnicalsSubjectRate = 1.3;

        public TechnicalSubject(int subjectId, string subjectName, double subjectRate) : base(subjectId, subjectName, subjectRate = TechnicalsSubjectRate)
        {

        }
    }
}
