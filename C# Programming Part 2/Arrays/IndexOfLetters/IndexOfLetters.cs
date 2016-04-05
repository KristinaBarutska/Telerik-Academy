/*  
    Problem 12. Index of letters
    Write a program that creates an array containing all letters from the alphabet (A-Z).
    Read a word from the console and print the index of each of its letters in the array. 
*/

namespace IndexOfLetters
{
    using System;

    public class IndexOfLetters
    {
        private static void Main()
        {
            string word = Console.ReadLine();
            int[] indexes = GetIndexOfLetters(word);

            foreach (var index in indexes)
            {
                Console.Write($"{index} ");
            }

            Console.WriteLine();
        }

        private static int[] GetIndexOfLetters(string word)
        {
            char[] letters = new char[26];
            string wordForSearch = word.ToLower();
            int[] indexes = new int[word.Length];
            int index = 0;

            for (char i = 'a'; i <= 'z'; i++)
            {
                letters[index] = i;
                index++;
            }

            for (int i = 0; i < wordForSearch.Length; i++)
            {
                indexes[i] = Array.IndexOf(letters, wordForSearch[i]);
            }

            return indexes;
        }
    }
}