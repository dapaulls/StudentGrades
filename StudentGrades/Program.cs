/* HND Computing and Systems Development
 * Unit 19 - Object Orientated Programming
 * Semester 2, June - October 2013 (updated March 2015)
 * by David Paulls
 * This program calculates a student's grades and final score from the subject marks input.
 *
 * PSEUDOCODE:
 *      1. Get the number of subjects
 *      2. Get the name and mark for each subject
 *      3. Calculate the grade for each subject
 *      4. Add the subject marks together to find the total
 *      5. Divide the total by the number of subjects to find the course average
 *      6. From the course average calculate the final overall grade
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                GradeCalculation newStudent = new GradeCalculation();

                Console.Clear();
                Console.WriteLine("STUDENT'S GRADE CALCULATION PROGRAM");
                Console.WriteLine("-----------------------------------\n");

                // Get number of subjects.
                int noOfSubjects = newStudent.InputNoOfSubjects();

                // Create a list to store the subject names, marks and calculated grade.
                List<SubjectAndMark> subjectandMark = new List<SubjectAndMark>();

                // Get the subject names and marks and add them to the list. 
                for (int i = 0; i < noOfSubjects; i++)
                {
                    SubjectAndMark newSubject = newStudent.AddSubjectAndMark(i + 1);
                    subjectandMark.Add(newSubject);
                }

                // Calculate the course total.
                newStudent.CalculateCourseTotal(subjectandMark);

                // Calculate the course average mark.
                newStudent.CalculateCourseAverage();

                // Calculate the course grade.
                newStudent.CalculateCourseGrade();

                // Print report.
                newStudent.DisplayTable(subjectandMark);

                Console.WriteLine("\nWould you like to run the program again? ('Y' for yes, any other key to quit.)");
            }
            while (Console.ReadLine().ToLower() == "y");
        }
    }
}

