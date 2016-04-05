/*
    Problem 3. Read file contents
    Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console.
    Find in MSDN how to use System.IO.File.ReadAllText(…).
    Be sure to catch all possible exceptions and print user-friendly error messages. 
*/

namespace ReadFileContents
{
    using System;
    using System.IO;
    using System.Security;

    public class FileReader
    {
        public static void Main()
        {
            Console.Write("Enter a path of a file : ");
            string path = Console.ReadLine();

            try
            {
                string content = File.ReadAllText(path);

                Console.WriteLine(content);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (PathTooLongException ptle)
            {
                Console.WriteLine(ptle.Message);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                Console.WriteLine(dnfe.Message);
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine(uae.Message);
            }
            catch (NotSupportedException nse)
            {
                Console.WriteLine(nse.Message);
            }
            catch (SecurityException se)
            {
                Console.WriteLine(se.Message);
            }
        }
    }
}