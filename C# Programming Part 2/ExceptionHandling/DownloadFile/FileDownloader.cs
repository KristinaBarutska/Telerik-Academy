/*
    Problem 4. Download file
    Write a program that downloads a file from Internet (e.g. Ninja image) and stores it the current directory.
    Find in Google how to download files in C#.
    Be sure to catch all exceptions and to free any used resources in the finally block.
*/

namespace DownloadFile
{
    using System;
    using System.Net;

    public class FileDownloader
    {
        private static void Main()
        {
            string path = "https://i.ytimg.com/vi/78YjZXdJ8iM/maxresdefault.jpg";
            string downloadPath = @"C:\Users\g-belchev\Desktop\minimal.jpg";

            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(path, downloadPath);
                }

                Console.WriteLine("Download complete.");
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
            catch (WebException we)
            {
                Console.WriteLine(we.Message);
            }
            catch (NotSupportedException nse)
            {
                Console.WriteLine(nse.Message);
            }
        }
    }
}