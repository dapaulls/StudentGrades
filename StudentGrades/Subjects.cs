using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentGrades
{
    class Subjects
    {
        private int minSubject = 1;         // The minimum no. of subjects allowed
        private int maxSubject = 10;        // The maximum no. of subjects allowed
        private int noOfSubjects = 0;       // The no. of subjects the student sat
        private int minMark = 0;            // The minimum mark allowed
        private int maxMark = 100;          // The maximum mark allowed
        private int courseTotal = 0;        // The sum of the subject marks
        private string subjectGrade = "";   // The calculated grade for each subject 
        private string courseGrade = "";    // The overall calculated grade for the course                

        public int MinSubject
        {
            get { return minSubject; }
            set { minSubject = value; }
        }

        public int MaxSubject
        {
            get { return maxSubject; }
            set { maxSubject = value; }
        }

        public int NoOfSubjects
        {
            get { return noOfSubjects; }
            set { noOfSubjects = value; }
        }

        public int MinMark
        {
            get { return minMark; }
            set { minMark = value; }
        }

        public int MaxMark
        {
            get { return maxMark; }
            set { maxMark = value; }
        }

        public int CourseTotal
        {
            get { return courseTotal; }
            set { courseTotal = value; }
        }

        public string SubjectGrade
        {
            get { return subjectGrade; }
            set { subjectGrade = value; }
        }

        public string CourseGrade
        {
            get { return courseGrade; }
            set { courseGrade = value; }
        }

        public void InputNoOfSubjects()
        {
            Console.WriteLine("How many subjects do you wish to enter?");
            ValidateInput.CheckInt("number", MinSubject, MaxSubject);
            NoOfSubjects = ValidateInput.InputNum;
        }

        // Ask the user to input each subject name & mark
        // Keep a running total of the marks and display the calculated grade for each subject 
        public void EnterSubjectAndMark()
        {
            string[] subjectNameArray = new string[NoOfSubjects];
            int[] subjectMarkArray = new int[NoOfSubjects];
            for (int i = 0; i < NoOfSubjects; i++)
            {
                Console.Write("\nEnter the name of subject {0}: ", i + 1);
                subjectNameArray[i] = Console.ReadLine();
                subjectMarkArray[i] = ValidateInput.CheckInt("mark", MinMark, MaxMark);
                CourseTotal += subjectMarkArray[i];
                SubjectGrade = CalcGrade(subjectMarkArray[i]);
                Console.WriteLine("Subject Grade = {0}", SubjectGrade);
            }
            Console.WriteLine("\nCourse Total = {0}", CourseTotal);
        }

        // Calculate the grade based on the mark
        public string CalcGrade(float mark)
        {
            string grade = "";
            if (mark >= 80) grade = "A+";
            else if (mark >= 70) grade = "A";
            else if (mark >= 60) grade = "B";
            else if (mark >= 50) grade = "C";
            else if (mark >= 40) grade = "D";
            else if (mark >= 30) grade = "E";
            else grade = "FAIL";
            return grade;
        }

        // Calculate the average mark and overall grade
        public void CalcFinalAverage(int CourseTotal, int NoOfSubjects)
        {
            float courseAverage = (float)CourseTotal / NoOfSubjects;
            Console.WriteLine("Course Average = {0}", courseAverage);
            CourseGrade = CalcGrade(courseAverage);
            Console.WriteLine("Overall Grade = {0}", courseGrade);
        }
    }
}
