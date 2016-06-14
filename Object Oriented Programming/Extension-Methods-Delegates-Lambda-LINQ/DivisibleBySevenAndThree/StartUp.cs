namespace DivisibleBySevenAndThree
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = { 3, 7, 21, 42, 0, 31, 84 };
            int[] extractedNumbersUsingExtMethods = ExtractNumbersUsingExtMethods(numbers);
            int[] extractedNumbersUsingLinq = ExtractNumbersUsingLinq(numbers);

            Console.WriteLine("Extension methods:");
            Console.WriteLine(string.Join(", ", extractedNumbersUsingExtMethods));
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Linq:");
            Console.WriteLine(string.Join(", ", extractedNumbersUsingLinq));
        }

        private static int[] ExtractNumbersUsingExtMethods(int[] numbers)
        {
            return numbers
                .Where(n => n % (3 * 7) == 0)
                .ToArray();
        }

        private static int[] ExtractNumbersUsingLinq(int[] numbers)
        {
            return (from num in numbers
                    where num % (3 * 7) == 0
                    select num).ToArray();
        }
    }
}