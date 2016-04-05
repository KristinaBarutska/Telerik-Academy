/*
    Problem 21. Letters count
    Write a program that reads a string from the console and prints all different letters in the string along with
    information how many times each letter is found.
*/

namespace LettersCount
{
    using System;
    using System.Collections.Generic;

    public class LettersCounter
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            ICollection<char> uniqueLetters = new HashSet<char>();

            for (int i = 0; i < text.Length; i++)
            {
                uniqueLetters.Add(text[i]);
            }

            Console.WriteLine(uniqueLetters.Count);
        }
    }
}