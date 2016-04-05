/*
    Problem 6. String length
    Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with *.
    Print the result string into the console.
*/

namespace StringLength
{
    using System;
    using System.Text;

    public class StringReader
    {
        public static void Main()
        {
            var validInput = new StringBuilder();
            int counter = -1;
            char inputChar = 'a';

            while (counter < 20)
            {
                inputChar = (char)Console.Read();

                if (inputChar == '\n')
                {
                    break;
                }

                validInput.Append(inputChar);
                counter++;
            }

            Console.WriteLine(validInput.ToString().PadLeft(20, '*'));
        }
    }
}