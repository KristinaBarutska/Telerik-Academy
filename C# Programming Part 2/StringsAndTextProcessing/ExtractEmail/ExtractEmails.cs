/*
    Problem 18. Extract e-mails
    Write a program for extracting all email addresses from given text.
    All sub-strings that match the format <identifier>@<host>…<domain> should be recognized as emails.
*/

namespace ExtractEmail
{
    using System;
    using System.Collections.Generic;

    public class ExtractEmails
    {
        public static void Main()
        {
            string text = "dsaoudsa%% & duash dasd@abv.bg jds, ledeniqSteevOstin@gmail.com !doas email@email.org";
            string[] tokens = text.Split(new char[] { ' ', ',', '%', '!', ',' }, StringSplitOptions.RemoveEmptyEntries);
            IList<string> emails = new List<string>();

            for (int i = 0; i < tokens.Length; i++)
            {
                string currentToken = tokens[i];

                if (currentToken.Contains("@"))
                {
                    bool hasIdentifier = false;
                    bool hasHost = false;
                    bool hasDomain = false;

                    if (currentToken[0] != '@')
                    {
                        hasIdentifier = true;
                    }

                    int atIndex = currentToken.IndexOf('@');

                    if (currentToken[atIndex + 1] != '.')
                    {
                        hasHost = true;
                    }

                    int indexOfDot = currentToken.IndexOf('.', atIndex);

                    if (hasIdentifier && hasHost && indexOfDot != currentToken.Length - 1 && currentToken[indexOfDot + 1] != ' ')
                    {
                        hasDomain = true;
                    }

                    if (hasIdentifier && hasHost && hasDomain)
                    {
                        emails.Add(currentToken);
                    }
                }                               
            }

            Console.WriteLine(string.Join("\n", emails));
        }
    }
}