using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private int id;
        private string name;
        private string category;
        private int capacity;
        private List<int> requiredSubjects;

        public University(int universityId, string universityName, string category,
            int capacity, List<int> requiredSubjects)
        {
            Id = universityId;
            Name = universityName;
            Category = category;
            Capacity = capacity;
            requiredSubjects = new List<int>();
        }
        public int Id {get; private set;}

        public string Name
        {

            get
            {
                return name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.NameNullOrWhitespace));
                }

                name = value;

            }
        }

        public string Category
        {

            get
            {
                return category;
            }

            private set
            {
                if (value == "Technical" || value == "Economical" || value == "Humanity")
                {
                    category = value;
                }

                else
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.CategoryNotAllowed, value));
                }
            }
        }

        public int Capacity 
        {
            get
            {
                return capacity;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.CapacityNegative));
                }

                capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects => requiredSubjects;
    }
}
