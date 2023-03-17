using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        public int Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public string Category => throw new NotImplementedException();

        public int Capacity => throw new NotImplementedException();

        public IReadOnlyCollection<int> RequiredSubjects => throw new NotImplementedException();
    }
}
