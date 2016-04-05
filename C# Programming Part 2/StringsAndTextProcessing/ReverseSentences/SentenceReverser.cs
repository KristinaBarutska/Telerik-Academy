/*
    Problem 13. Reverse sentence
    
        Write a program that reverses the words in given sentence.
    
    Example:
    input 	output
    C# is not C++, not PHP and not Delphi! 	Delphi not and PHP, not C++ not is C#!
*/

namespace ReverseSentences
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SentenceReverser
    {
        public static void Main()
        {
            string text = "C# is not C++, not PHP and not Delphi!";
            IList<char> signs = new List<char> { ',', ';', ':', '-' };
            IDictionary<char, int> signsWithPositions = GetSignsWithPositions(text, signs);
            StringBuilder reversedSentenceWithoutSigns = ReverseSentenceWithoutSigns(text);
            string reversedText = PlacePunctuations(reversedSentenceWithoutSigns, signsWithPositions);

            Console.WriteLine(reversedText);
        }

        private static IDictionary<char, int> GetSignsWithPositions(string text, ICollection<char> signs)
        {
            var signsWithPositions = new Dictionary<char, int>();
            int whiteSpaceCounter = 0;

            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == ' ')
                {
                    whiteSpaceCounter++;
                }

                if (signs.Contains(text[i]))
                {
                    signsWithPositions.Add(text[i], whiteSpaceCounter);
                }
            }

            return signsWithPositions;
        }

        private static StringBuilder ReverseSentenceWithoutSigns(string text)
        {
            var reversedText = new StringBuilder();
            char lastSign = text[text.Length - 1];
            char[] charsToSplitBy = { ',', ';', ':', '-', ' ', '.', '?', '+', '/', '\\', '(', ')', '!' };
            string[] textSplitted = text.Split(charsToSplitBy);

            for (int i = textSplitted.Length - 1; i >= 0; i--)
            {
                if (textSplitted[i] != string.Empty)
                {
                    reversedText.Append(textSplitted[i] + ' ');
                }
            }

            reversedText.Remove(reversedText.Length - 1, 1);
            reversedText.Append(lastSign);

            return reversedText;
        }

        private static string PlacePunctuations(StringBuilder reversedText, IDictionary<char, int> punctuations)
        {
            int counter = 0;

            foreach (var punctuationSign in punctuations)
            {
                int currentWhiteSpaceCounter = punctuationSign.Value;
                char currentSign = punctuationSign.Key;

                for (int i = 0; i < reversedText.Length; i++)
                {
                    if (reversedText[i] == ' ')
                    {
                        counter++;
                    }

                    if (counter == currentWhiteSpaceCounter + 1)
                    {
                        reversedText.Insert(i, currentSign);
                    }
                }
            }

            return reversedText.ToString();
        }
    }
}