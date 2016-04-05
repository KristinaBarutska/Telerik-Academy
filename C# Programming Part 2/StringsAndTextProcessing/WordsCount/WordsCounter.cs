/*
    Problem 22. Words count
    Write a program that reads a string from the console and lists all different words in the string along with 
    information how many times each word is found.
*/

namespace WordsCount
{
    using System;
    using System.Collections.Generic;

    public class WordsCounter
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string[] words = text.Split(' ');

            Array.Sort(words);

            IDictionary<string, int> wordsOccurrences = new Dictionary<string, int>();
            int counter = 1;

            for (int i = 1; i < words.Length; i++)
            {
                if(words[i] == words[i - 1])
                {
                    counter++;
                }
                else
                {
                    wordsOccurrences.Add(words[i], counter);
                    counter = 1;
                }
            }

            foreach (var occurence in wordsOccurrences)
            {
                Console.WriteLine($"{occurence.Key} -> {occurence.Value} times");
            }
        }
    }
}