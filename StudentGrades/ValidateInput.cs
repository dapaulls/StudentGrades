using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGrades
{
    class ValidateInput
    {
        // Method to check that the value input is an integer and between the allowed values.
        static public int CheckInt(string promptText, int min, int max)
        {
            bool result = false;
            int inputNum = 0;

            while (!result || (inputNum < min || inputNum > max))
            {
                Console.Write("Please enter a {0} between {1} and {2}: ", promptText, min, max);
                result = int.TryParse(Console.ReadLine(), out inputNum);
            }
            return inputNum;
        }
    }
}
