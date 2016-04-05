/*
    Problem 8. Extract sentences
    
        Write a program that extracts from a given text all sentences containing given word.
    
    Example:
    
    The word is: in
    
    The text is: We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight.
    So we are drinking all the day. We will move out of it in 5 days.
    
    The expected result is: We are living in a yellow submarine. We will move out of it in 5 days.
    
    Consider that the sentences are separated by . and the words – by non-letter symbols.
*/

namespace ExtractSentences
{
    using System;
    using System.Collections.Generic;

    public class SentenceExtractor
    {
        public static void Main()
        {
            string text = " We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight." +
                " So we are drinking all the day. We will move out of it in 5 days.";
            string[] sentences = text.Split('.');
            IList<string> extractedSentences = new List<string>();

            for (int i = 0; i < sentences.Length; i++)
            {
                if (sentences[i].Contains(" in "))
                {
                    extractedSentences.Add(sentences[i].Trim());
                }
            }

            Console.WriteLine(string.Join("\n", extractedSentences));
        }
    }
}