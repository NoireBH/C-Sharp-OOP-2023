﻿using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public  class Student : IStudent
    {
        private int id;
        private string firstName;
        private string lastName;
        private readonly List<int> coveredExams;
        private IUniversity university;

        public Student(int studentId,string firstName,string lastName)
        {
            Id = studentId;
            FirstName = firstName;
            LastName = lastName;
            coveredExams = new List<int>();
        }

        public int Id {get; private set;}

        public string FirstName
        {

            get
            {
                return firstName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.NameNullOrWhitespace));
                }

                firstName = value;

            }
        }

        public string LastName
        {

            get
            {
                return lastName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.NameNullOrWhitespace));
                }

                lastName = value;

            }
        }

        public IReadOnlyCollection<int> CoveredExams => coveredExams;

        public IUniversity University => university;

        public void CoverExam(ISubject subject)
        {
            coveredExams.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {   
            this.university = university;
        }
    }
}
