/* HND Computing and Systems Development
 * Unit 19 - Object Orientated Programming
 * Semester 2, June - October 2013 (updated March 2015)
 * by David Paulls
 * This program calculates a student's grades and final score from the subject marks input.
 *
 * PSEUDOCODE:
 *      1. Get the number of subjects.
 *      2. Get the name and mark for each subject.
 *      3. Calculate the grade for each subject.
 *      4. Add the subject marks together to find the total.
 *      5. Divide the total by the number of subjects to find the course average.
 *      6. From the course average calculate the final overall grade.
 *      7. Display the report.
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
                // Create a new instance of the GradeCalculationProgram
                GradeCalculation newStudent = new GradeCalculation();

                // Display the program's title
                newStudent.DisplayProgramTitle();

                // Get number of subjects.
                int noOfSubjects = newStudent.GetNoOfSubjects();

                // Create a list to store the subject names, marks and calculated grade.
                List<SubjectAndMark> marksTable = newStudent.CreateMarksTable();

                // Populate the table with the student's results
                marksTable = newStudent.PopulateMarksTable(noOfSubjects, marksTable);
                
                // Calculate the course total.
                int courseTotal = newStudent.CalculateCourseTotal(marksTable);

                // Calculate the course average mark.
                float courseAverage = newStudent.CalculateCourseAverage(courseTotal, noOfSubjects);

                // Calculate the course grade.
                string overallGrade = newStudent.CalculateCourseGrade(courseAverage);

                // Print report.
                newStudent.DisplayTable(marksTable, courseTotal, courseAverage, overallGrade);

                Console.WriteLine("\n\nWould you like to run the program again? ('Y' for yes, any other key to quit.)");
            }
            while (Console.ReadLine().ToLower() == "y");
        }
    }
}

