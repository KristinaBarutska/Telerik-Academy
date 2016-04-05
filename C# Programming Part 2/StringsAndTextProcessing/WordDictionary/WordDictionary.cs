/*
    Problem 14. Word dictionary
    
        A dictionary is stored as a sequence of text lines containing words and their explanations.
        Write a program that enters a word and translates it by using the dictionary.
    
    Sample dictionary:
    input 	output
    .NET 	platform for applications from Microsoft
    CLR 	managed execution environment for .NET
    namespace 	hierarchical organization of classes
*/

namespace WordDictionary
{
    using System;
    using System.Collections.Generic;

    public class WordDictionary
    {
        public static void Main()
        {
            IDictionary<string, string> wordDictionary = ReadWordsWithValues();
            Console.Write("Word to retrieve value of: ");
            string keyWord = Console.ReadLine();

            Console.WriteLine($"Value of keyword: {wordDictionary[keyWord]}");
        }

        private static IDictionary<string, string> ReadWordsWithValues()
        {
            IDictionary<string, string> wordDictionary = new Dictionary<string, string>();
            string key = "placeholder value";
            string value = "placeholder value";

            while (key != string.Empty || value != string.Empty)
            {
                Console.Write("Dictionary key: ");
                key = Console.ReadLine();

                if (string.IsNullOrEmpty(key))
                {
                    break;
                }

                Console.Write("Dictionary value: ");
                value = Console.ReadLine();

                wordDictionary.Add(key, value);
            }

            return wordDictionary;
        }
    }
}