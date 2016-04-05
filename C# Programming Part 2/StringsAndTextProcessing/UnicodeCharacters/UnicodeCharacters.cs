/*
    Problem 10. Unicode characters
    
        Write a program that converts a string to a sequence of C# Unicode character literals.
        Use format strings.
    
    Example:
    input 	output
    Hi! 	\u0048\u0069\u0021
*/

namespace UnicodeCharacters
{
    using System;
    using System.Text;

    public class UnicodeCharacters
    {
        public static void Main()
        {
            string word = "Hi!";
            var result = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                result.AppendFormat("\\u{0:X4}", (int)word[i]);
            }

            Console.WriteLine(result.ToString());
        }
    }
}