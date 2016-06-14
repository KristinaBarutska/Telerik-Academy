namespace StringBuilderSubstring
{
    using System;
    using System.Text;

    using StringBuilderSubstring.Extensions;

    public class StartUp
    {
        public static void Main()
        {
            StringBuilder text = new StringBuilder("Jessica is a horse!");
            StringBuilder substring = text.Substring(0, 6);

            Console.WriteLine(substring);
        }
    }
}