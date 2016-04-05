/*
    Problem 3. Correct brackets
    Write a program to check if in a given expression the brackets are put correctly.
    Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)).
*/

namespace CorrectBrackets
{
    using System;

    public class BracketsChecker
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            int openedBracketsCounter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    openedBracketsCounter++;
                }

                if (input[i] == ')')
                {
                    openedBracketsCounter--;
                }
            }

            Console.WriteLine(openedBracketsCounter == 0 ? "Correct" : "Incorrect");
        }
    }
}