/* HND Computing and Systems Development
 * Unit 19 - Object Orientated Programming
 * Semester 2, June - October 2013 (updated August 2014)
 * by David Paulls
 * This program calculates a student's grades and final score from the subject marks input.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Subjects newStudent = new Subjects();

                Console.Clear();
                Console.WriteLine("STUDENT'S GRADE CALCULATION PROGRAM");
                Console.WriteLine("-----------------------------------\n");

                newStudent.InputNoOfSubjects();
                newStudent.EnterSubjectAndMark();
                newStudent.CalcFinalAverage(newStudent.CourseTotal, newStudent.NoOfSubjects);

                Console.WriteLine("\nWould you like to run the program again? ('Y' for yes, any other key to quit.)");
            }
            while (Console.ReadLine().ToLower() == "y");
        }
    }
}
