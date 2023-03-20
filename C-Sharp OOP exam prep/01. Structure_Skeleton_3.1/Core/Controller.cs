using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public string AddStudent(string firstName, string lastName)
        {
            string result = string.Empty;

            if (students.FindByName($"{firstName} {lastName}") != null)
            {
                result = string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            else
            {
                IStudent student = new Student(students.Models.Count + 1, firstName, lastName);
                students.AddModel(student);
                result = string
                    .Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, nameof(StudentRepository));
            }

            return result.Trim();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            string result = String.Empty;

            if (subjectType != nameof(TechnicalSubject) &&
                subjectType != nameof(EconomicalSubject) &&
                subjectType != nameof(HumanitySubject))
            {
                result = string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            else if (subjects.FindByName(subjectName) != null)
            {
                result = String.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            else
            {
                ISubject subject;
                int subjectId = subjects.Models.Count + 1;

                if (subjectType == nameof(TechnicalSubject))
                {
                    subject = new TechnicalSubject(subjectId, subjectName);
                }
                else if (subjectType == nameof(EconomicalSubject))
                {
                    subject = new EconomicalSubject(subjectId, subjectName);
                }
                else
                {
                    subject = new HumanitySubject(subjectId, subjectName);
                }

                this.subjects.AddModel(subject);
                result = string
                    .Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, nameof(SubjectRepository));
            }

            return result.Trim();
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            string result = string.Empty;

            if (universities.FindByName(universityName) != null)
            {
                result = string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            else
            {
                var subjectList = new List<int>();

                foreach (var subj in requiredSubjects)
                {
                    subjectList.Add(subjects.FindByName(subj).Id);
                }

                IUniversity university = new University(universities.Models.Count + 1, universityName,
                    category, capacity, subjectList);
                universities.AddModel(university);

                result = string
                    .Format(OutputMessages.UniversityAddedSuccessfully, universityName, nameof(UniversityRepository));
            }

            return result.Trim();
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            throw new NotImplementedException();
        }

        public string TakeExam(int studentId, int subjectId)
        {
            throw new NotImplementedException();
        }

        public string UniversityReport(int universityId)
        {
            throw new NotImplementedException();
        }
    }
}
