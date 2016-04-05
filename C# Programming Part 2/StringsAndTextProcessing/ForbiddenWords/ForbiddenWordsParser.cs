/*
    Problem 9. Forbidden words
    
        We are given a string containing a list of forbidden words and a text containing some of these words.
        Write a program that replaces the forbidden words with asterisks.
    
    Example text: Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as
    a dynamic language in CLR.
    
    Forbidden words: PHP, CLR, Microsoft
    
    The expected result: ********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented
    as a dynamic language in ***.
*/

namespace ForbiddenWords
{
    using System;
    using System.Text;

    public class ForbiddenWordsParser
    {
        public static void Main()
        {
            string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and " +
                "is implemented as a dynamic language in CLR.";
            string[] forbiddenWords = { "PHP", "CLR", "Microsoft" };
            var textContainer = new StringBuilder(text);

            for (int i = 0; i < forbiddenWords.Length; i++)
            {
                string currentWord = forbiddenWords[i];

                textContainer.Replace(currentWord, new string('*', currentWord.Length));
            }

            Console.WriteLine(textContainer.ToString());
        }
    }
}