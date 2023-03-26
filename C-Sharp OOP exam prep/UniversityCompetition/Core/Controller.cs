using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;
using System.Linq;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

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

            return result.TrimEnd();
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

            return result.TrimEnd();
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

            return result.TrimEnd();
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string result = string.Empty;
            string firstName = studentName.Split()[0];
            string lastName = studentName.Split()[1];

            var student = students.FindByName(studentName);
            var university = universities.FindByName(universityName);

            if (student == null)
            {
                result = string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }
            else if (university == null)
            {
                result = string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            else if (!university.RequiredSubjects.All(x => student.CoveredExams.Any(e => e == x)))
            {
                result = string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }
            else if (student.University != null && student.University.Name == universityName)
            {
                result = string.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);
            }
            else
            {
                student.JoinUniversity(university);
                result = string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
            }

            return result.TrimEnd();
        }

        public string TakeExam(int studentId, int subjectId)
        {
            string result = string.Empty;
            var student = students.FindById(studentId);
            var subject = subjects.FindById(subjectId);

            if (student == null)
            {
                result = string.Format(OutputMessages.InvalidStudentId);
            }

            else if (subject == null)
            {
                result = string.Format(OutputMessages.InvalidSubjectId);
            }

            else if (student.CoveredExams.Contains(subjectId))
            {
                result = String.Format(OutputMessages.StudentAlreadyCoveredThatExam,
                    student.FirstName, student.LastName, subject.Name);
            }

            else
            {
                student.CoverExam(subject);
                result = String.Format(OutputMessages.StudentSuccessfullyCoveredExam
                    , student.FirstName, student.LastName, subject.Name);
            }

            return result.TrimEnd();
        }

        public string UniversityReport(int universityId)
        {
            var university = universities.FindById(universityId);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {students.Models.Where(s => s.University == university).Count()}");
            sb.AppendLine($"University vacancy: {university.Capacity - students.Models.Where(s => s.University == university).Count()}");

            return sb.ToString().TrimEnd();
        }
    }
}
