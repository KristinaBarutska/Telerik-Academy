/*
    Problem 20. Palindromes
    Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe
*/

namespace Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PalindromesExtractor
    {
        public static void Main()
        {
            string[] words = "ABBA dsadas dasij lamal dasjdhu 2 hdla exe dsad".Split(' ');
            IList<string> palindromes = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                if (CheckStringIsPalindrome(words[i]))
                {
                    palindromes.Add(words[i]);
                }
            }

            Console.WriteLine(string.Join(", ", palindromes));
        }

        private static bool CheckStringIsPalindrome(string word)
        {
            var reversedWord = new StringBuilder();

            for (int i = word.Length - 1; i >= 0; i--)
            {
                reversedWord.Append(word[i]);
            }

            bool isPalindrome = word == reversedWord.ToString();

            return isPalindrome;
        }
    }
}