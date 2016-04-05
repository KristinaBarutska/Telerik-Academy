/*
    Problem 25. Extract text from HTML
    
        Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.
    
    Example input:
    
    <html>
      <head><title>News</title></head>
      <body><p><a href="http://academy.telerik.com">Telerik
        Academy</a>aims to provide free real-world practical
        training for young people who want to turn into
        skilful .NET software engineers.</p></body>
    </html>
    
    Output:
    
    Title: News
    Text: Telerik Academy aims to provide free real-world practical training for young people who want to turn into skilful .NET software engineers.
*/

namespace ExtractTextFromHtml
{
    using System;
    using System.Text;

    public class HtmlExtractor
    {
        /*
        <html><head><title>News</title></head><body><p><a href="http://academy.telerik.com">TelerikAcademy</a>aims to provide free real-world practicaltraining for young people who want to turn intoskilful .NET software engineers.</p></body></html>
        */
        public static void Main()
        {
            string html = Console.ReadLine();
            var title = new StringBuilder();
            var text = new StringBuilder();

            ExtractTitle(html, ref title);
            ExtractText(html, ref text);

            Console.WriteLine($"Title: {title.ToString()}");
            Console.WriteLine($"Text: {text.ToString()}");
        }

        private static void ExtractTitle(string html, ref StringBuilder titleContainer)
        {
            string titleOpeningTag = "<title>";
            string titleClosingTag = "</title>";
            bool inTitleText = false;

            for (int i = 0; i < html.Length; i++)
            {
                if (html.Substring(i, titleOpeningTag.Length) == titleOpeningTag)
                {
                    inTitleText = true;
                    i += titleOpeningTag.Length;
                }

                if(html.Substring(i, titleClosingTag.Length) == titleClosingTag)
                {
                    break;
                }

                if(inTitleText)
                {
                    titleContainer.Append(html[i]);
                }
            }
        }

        private static void ExtractText(string html, ref StringBuilder textContainer)
        {
            string titleClosingTag = "</title>";
            int indexOfClosingTag = html.IndexOf(titleClosingTag);
            bool inTag = false;
            bool inText = false;

            for (int i = indexOfClosingTag; i < html.Length; i++)
            {
                if(html[i] == '<')
                {
                    inTag = true;
                    inText = false;
                    continue;
                }

                if(html[i] == '>')
                {
                    inText = true;
                    inTag = false;

                    if(textContainer.Length != 0)
                    {
                        if (textContainer[textContainer.Length - 1] != ' ')
                        {
                            textContainer.Append(' ');
                        }
                    }

                    continue;
                }

                if(inText)
                {
                    textContainer.Append(html[i]);
                }
            }
        }
    }
}