using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGrades
{
    class GradeCalculation
    {
        public int NoOfSubjects { get; set; }
        public int CourseTotal { get; set; }
        public float CourseAverage { get; set; }
        public string CourseGrade { get; set; }
        private const int minSubject = 1;
        private const int maxSubject = 10;
        private const int minMark = 0;
        private const int maxMark = 100;

        public int InputNoOfSubjects()
        {
            Console.WriteLine("How many subjects do you wish to enter?");
            NoOfSubjects = ValidateInput.CheckInt("number", minSubject, maxSubject);
            return NoOfSubjects;
        }

        public SubjectAndMark AddSubjectAndMark(int subjectNumber)
        {
            SubjectAndMark newSubject = new SubjectAndMark();
            Console.Write("\nEnter the name of subject {0}: ", subjectNumber);
            newSubject.SubjectName = Console.ReadLine();
            newSubject.SubjectMark = ValidateInput.CheckInt("mark", minMark, maxMark);
            newSubject.SubjectGrade = CalculateGrade(newSubject.SubjectMark);
            return newSubject;
        }

        public string CalculateGrade(float Mark)
        {
            string grade = "";
            if (Mark >= 80) grade = "A+";
            else if (Mark >= 70) grade = "A";
            else if (Mark >= 60) grade = "B";
            else if (Mark >= 50) grade = "C";
            else if (Mark >= 40) grade = "D";
            else if (Mark >= 30) grade = "E";
            else grade = "FAIL";
            return grade;
        }

        public void CalculateCourseTotal(List<SubjectAndMark> subjectAndMark)
        {
            CourseTotal = 0;
            CourseTotal = subjectAndMark.Sum(s => s.SubjectMark);
        }

        public void CalculateCourseAverage()
        {
            CourseAverage = 0;
            CourseAverage = (float)CourseTotal / NoOfSubjects;
        }

        public void CalculateCourseGrade()
        {
            CourseGrade = "";
            CourseGrade = CalculateGrade(CourseAverage);
        }

        public void DisplayTable(List<SubjectAndMark> subjectAndMark)
        {
            Console.WriteLine("\nSubject\t\t\tMark\t\t\tGrade");
            Console.WriteLine("-------\t\t\t----\t\t\t-----");
            foreach (SubjectAndMark s in subjectAndMark)
            {
                Console.WriteLine("{0}{1}\t\t\t{2}", s.SubjectName.PadRight(24), s.SubjectMark.ToString(), s.SubjectGrade);
            }
            Console.WriteLine("\nTotal marks for the course = {0}", CourseTotal.ToString());
            Console.WriteLine("Average mark = {0:P}", CourseAverage / 100);
            Console.WriteLine("Overall course grade = {0}", CourseGrade);
        }
    }
}

