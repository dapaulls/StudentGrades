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

        public void DisplayProgramTitle()
        {
            Console.Clear();
            Console.WriteLine("STUDENT'S GRADE CALCULATION PROGRAM");
            Console.WriteLine("-----------------------------------\n");
        }

        public int GetNoOfSubjects()
        {
            Console.WriteLine("How many subjects do you wish to enter?");
            NoOfSubjects = ValidateInput.CheckInt("number", minSubject, maxSubject);
            return NoOfSubjects;
        }

        public List<SubjectAndMark> CreateMarksTable()
        {
            List<SubjectAndMark> marksTable = new List<SubjectAndMark>();
            return marksTable;
        }
        
        public List<SubjectAndMark> PopulateMarksTable(int noOfSubjects, List<SubjectAndMark> marksTable)
        {
            for (int i = 0; i < noOfSubjects; i++)
            {
                SubjectAndMark newMark = CreateNewMark(i + 1);
                marksTable.Add(newMark);
            }
            return marksTable;
        }

        private SubjectAndMark CreateNewMark(int subjectNumber)
        {
            SubjectAndMark newMark = new SubjectAndMark();
            Console.Write("\nEnter the name of subject {0}: ", subjectNumber);
            newMark.SubjectName = Console.ReadLine();
            newMark.SubjectMark = ValidateInput.CheckInt("mark", minMark, maxMark);
            newMark.SubjectGrade = CalculateGrade(newMark.SubjectMark);
            return newMark;
        }

        private string CalculateGrade(float Mark)
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

        public int CalculateCourseTotal(List<SubjectAndMark> marksTable)
        {
            CourseTotal = 0;
            CourseTotal = marksTable.Sum(s => s.SubjectMark);
            return CourseTotal;
        }

        public float CalculateCourseAverage(int courseTotal, int noOfSubjects)
        {
            CourseAverage = 0;
            CourseAverage = (float)courseTotal / noOfSubjects;
            return CourseAverage;
        }

        public string CalculateCourseGrade(float courseAverage)
        {
            CourseGrade = "";
            CourseGrade = CalculateGrade(courseAverage);
            return CourseGrade;
        }

        public void DisplayTable(List<SubjectAndMark> marksTable, int courseTotal, float courseAverage, string overallGrade)
        {
            Console.WriteLine("\nSubject\t\t\tMark\t\t\tGrade");
            Console.WriteLine("-------\t\t\t----\t\t\t-----");
            foreach (SubjectAndMark s in marksTable)
            {
                Console.WriteLine("{0}{1}\t\t\t{2}", s.SubjectName.PadRight(24), s.SubjectMark.ToString(), s.SubjectGrade);
            }
            Console.WriteLine("\nTotal marks for the course = {0}", courseTotal.ToString());
            Console.WriteLine("Average mark = {0:P}", courseAverage / 100);
            Console.WriteLine("Overall course grade = {0}", overallGrade);
        }
    }
}

