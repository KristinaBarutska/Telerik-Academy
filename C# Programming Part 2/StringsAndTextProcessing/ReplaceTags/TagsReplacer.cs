/*
    Problem 15. Replace tags

    Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].

    Example:
    input 	output
    <p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a>
    to discuss the courses.</p> 	<p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose a training course. Also 
    visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>
*/

namespace ReplaceTags
{
    using System;
    using System.Text;

    public class TagsReplacer
    {
        public static void Main()
        {
            /*
                <p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
            */
            string text = Console.ReadLine();
            var textToModify = new StringBuilder(text);

            ReplaceAllOpeningTags(ref textToModify);
            ReplaceAllClosingTags(ref textToModify);

            Console.WriteLine(textToModify.ToString());
        }

        private static void ReplaceAllOpeningTags(ref StringBuilder textToModify)
        {
            textToModify.Replace("<a href", "[URL");

            for (int i = 0; i < textToModify.Length; i++)
            {
                if(i < textToModify.Length - 1)
                {
                    if (textToModify[i] == '"' && textToModify[i + 1] == '>')
                    {
                        textToModify.Replace(">", "]", i + 1, 1);
                    }
                }
            }
        }

        private static void ReplaceAllClosingTags(ref StringBuilder textToModify)
        {
            string closingHrefTag = "</a>";
            string closingUrlTag = "[/URL]";

            textToModify.Replace(closingHrefTag, closingUrlTag);
        }
    }
}