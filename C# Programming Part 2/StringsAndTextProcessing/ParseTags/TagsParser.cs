/*
    Problem 5. Parse tags
    
        You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to upper-case.
        The tags cannot be nested.
    
    Example: We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
    
    The expected result: We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.
*/

namespace ParseTags
{
    using System;
    using System.Text;

    public class TagsParser
    {
        private static string openingTag = "<upcase>";
        private static string closingTag = "</upcase>";

        public static void Main()
        {
            string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
            string tagsParsed = ParseTags(text);

            Console.WriteLine(tagsParsed);
        }

        private static string ParseTags(string text)
        {
            var tagsParsed = new StringBuilder();
            bool inParseTag = false;

            for (int i = 0; i < text.Length; i++)
            {
                if(text.Length - i >= closingTag.Length)
                {
                    if (text.Substring(i, openingTag.Length) == openingTag)
                    {
                        inParseTag = true;
                        i += openingTag.Length;
                    }

                    if (text.Substring(i, closingTag.Length) == closingTag)
                    {
                        inParseTag = false;
                        i += closingTag.Length;
                    }
                }

                if (inParseTag)
                {
                    tagsParsed.Append(char.ToUpper(text[i]));
                }
                else
                {
                    tagsParsed.Append(text[i]);
                }
            }

            return tagsParsed.ToString();
        }
    }
}