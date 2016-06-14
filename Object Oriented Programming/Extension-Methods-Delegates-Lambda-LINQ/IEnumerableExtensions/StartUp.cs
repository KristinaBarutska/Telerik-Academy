namespace IEnumerableExtensions
{
    using System;

    using IEnumerableExtensions.Extensions;

    public class StartUp
    {
        public static void Main()
        {
            int[] elements = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int min = elements.Min<int>();
            int max = elements.Max<int>();
            int sum = elements.Sum<int>();
            int product = elements.Product<int>();
            int average = elements.Average<int>();

            Console.WriteLine(min + Environment.NewLine + max + Environment.NewLine + sum +
                Environment.NewLine + product + Environment.NewLine + average);
        }
    }
}