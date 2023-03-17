using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Models
{
    public abstract class Subject : ISubject
    {
        public int Id {get; private set;}

        public string Name
        {

            get
            {
                return Name;
            }

            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
            }
        }


        public double Rate => throw new NotImplementedException();
    }
}
