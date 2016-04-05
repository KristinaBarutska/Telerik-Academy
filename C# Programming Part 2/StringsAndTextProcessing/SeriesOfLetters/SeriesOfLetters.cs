/*
    Problem 23. Series of letters
    
        Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.
    
    Example:
    input 	                    output
    aaaaabbbbbcdddeeeedssaa 	abcdedsa
*/

namespace SeriesOfLetters
{
    using System;
    using System.Collections.Generic;

    public class SeriesOfLetters
    {
        public static void Main()
        {
            string series = "aaaaabbbbbcdddeeeedssaa";
            IList<char> letters = new List<char>();
            int index = 0;

            letters.Add(series[0]);

            for (int i = 0; i < series.Length; i++)
            {
                if (letters[index] != series[i])
                {
                    letters.Add(series[i]);
                    index++;
                }
            }

            Console.WriteLine(string.Join(string.Empty, letters));
        }
    }
}