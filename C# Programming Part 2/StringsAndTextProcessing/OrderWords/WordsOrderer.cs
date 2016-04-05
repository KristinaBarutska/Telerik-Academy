/*
    Problem 24. Order words
    Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.
*/

namespace OrderWords
{
    using System.Collections.Generic;
    using System.Linq;

    public class WordsOrderer
    {
        public static void Main()
        {
            string text = "Write a program that reads a list of words separated by spaces and prints the list in an alphabetical order";
            List<string> words = text
                .Split(' ')
                .ToList();

            words.Sort();

            System.Console.WriteLine(string.Join(" ", words));
        }
    }
}