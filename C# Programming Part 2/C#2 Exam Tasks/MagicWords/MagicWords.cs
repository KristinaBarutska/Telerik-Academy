namespace MagicWords
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MagicWords
    {
        public static void Main()
        {
            List<string> words = ReadWords();

            ReOrder(words);
            Print(words);
        }

        private static List<string> ReadWords()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            List<string> words = new List<string>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string currentWord = Console.ReadLine();

                words.Add(currentWord);
            }

            return words;
        }

        private static void ReOrder(List<string> words)
        {
            for (int i = 0; i < words.Count; i++)
            {
                string currentWord = words[i];
                int positionToMove = currentWord.Length % (words.Count + 1);

                words[i] = null;
                words.Insert(positionToMove, currentWord);
                words.Remove(null);
            }
        }

        private static void Print(List<string> words)
        {
            int longestWordLength = GetLongestWordLength(words);
            StringBuilder resultWord = new StringBuilder();

            for (int i = 0; i < longestWordLength; i++)
            {
                for (int j = 0; j < words.Count; j++)
                {
                    string currentWord = words[j];

                    if (i < currentWord.Length)
                    {
                        resultWord.Append(currentWord[i]);
                    }
                }
            }

            Console.WriteLine(resultWord.ToString());
        }

        private static int GetLongestWordLength(List<string> words)
        {
            int longestWordLength = words[0].Length;

            for (int i = 1; i < words.Count; i++)
            {
                string currentWord = words[i];

                if (currentWord.Length > longestWordLength)
                {
                    longestWordLength = currentWord.Length;
                }
            }

            return longestWordLength;
        }
    }
}