/*
    Problem 6. First larger than neighbours
    Write a method that returns the index of the first element in array that is larger than its neighbours, or -1, if there’s no such element.
    Use the method from the previous exercise.
*/

namespace FirstLargerThanNeighbours
{
    using System;
    using System.Linq;

    public class Solver
    {
        private static void Main()
        {
            Console.Write("Enter sequence of numbers on a single line : ");
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(n => int.Parse(n))
                .ToArray();
            var result = GetFirstLarger(numbers);

            if (result == -1)
            {
                Console.WriteLine("There is no such number,that is larger than its neighbors.");
            }
            else
            {
                Console.WriteLine($"The first larger than its neighbors is with index {result} and " +
                    $"value {numbers[result]}");
            }
        }

        private static int GetFirstLarger(int[] numbers)
        {
            for (int i = 1; i < numbers.Length - 1; i++)
            {
                if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i - 1])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}