namespace LongestString
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] words = { "a", "aaaaaa", "dsadsa", "21", "Konq spi" };
            string longestString = words
                .OrderBy(w => w.Length)
                .Last();

            Console.WriteLine(longestString);
        }
    }
}