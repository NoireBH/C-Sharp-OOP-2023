using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models
{
    public class HumanitySubject : Subject
    {
        private const double HumanitysubjectRate = 1.15;

        public HumanitySubject(int subjectId, string subjectName, double subjectRate) : base(subjectId, subjectName, subjectRate = HumanitysubjectRate)
        {

        }
    }
}
