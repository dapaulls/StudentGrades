using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentGrades
{
    // A static class to check the user's input is a valid integer
    static class ValidateInput
    {
        static private bool result;
        static private int inputNum;

        static public int InputNum
        {
            get { return inputNum; }
            set { inputNum = value; }
        }

        // Method to check that the value input is an integer and between the allowed values
        static public int CheckInt(string promptText, int min, int max)
        {
        tryAgain:
            Console.WriteLine("Please enter a {0} between {1} and {2}: ", promptText, min, max);
            result = int.TryParse(Console.ReadLine(), out inputNum);
            if (!result || (inputNum < min || inputNum > max))
            {
                goto tryAgain;
            }
            return inputNum;
        }

    }
}
