/*
    Problem 12. Parse URL
    
        Write a program that parses an URL address given in the format: [protocol]://[server]/[resource] and extracts from it
        the [protocol], [server] and [resource] elements.
    
    Example:
    URL 	Information
    http://telerikacademy.com/Courses/Courses/Details/212 	[protocol] = http
    [server] = telerikacademy.com
    [resource] = /Courses/Courses/Details/212
*/

namespace ParseUrl
{
    using System;
    using System.Text;

    public class UrlParser
    {
        public static void Main()
        {
            string url = "http://telerikacademy.com/Courses/Courses/Details/212";
            var protocol = new StringBuilder();
            var server = new StringBuilder();
            var resource = new StringBuilder();

            bool inProtocol = true;
            bool inServer = false;
            bool inResource = false;

            for (int i = 0; i < url.Length; i++)
            {
                if(i < url.Length - 3)
                {
                    if (url.Substring(i, 3) == "://")
                    {
                        inServer = true;
                        inProtocol = false;
                        i += 3;
                    }
                }

                if(i < url.Length - 1)
                {
                    if (inServer == true && url[i] == '/')
                    {
                        inResource = true;
                        inServer = false;
                    }
                }

                if (inProtocol)
                {
                    protocol.Append(url[i]);
                }

                if(inServer)
                {
                    server.Append(url[i]);
                }

                if(inResource)
                {
                    resource.Append(url[i]);
                }
            }

            Console.WriteLine($"[protocol] = {protocol.ToString()}\n[server] = {server.ToString()}\n[resource] = {resource.ToString()}");
        }
    }
}