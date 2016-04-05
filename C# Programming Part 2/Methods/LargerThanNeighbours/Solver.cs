/* 
    Problem 5. Larger than neighbours
    Write a method that checks if the element at given position in given array of 
    integers is larger than its two neighbours (when such exist). 
*/

namespace LargerThanNeighbours
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
            Console.Write("Enter the index of number you want to check if it is larger than neighbors: ");
            int index = int.Parse(Console.ReadLine());
            
            if (numbers.Length <= 2)
            {
                Console.WriteLine($"{numbers[index]} does not have two neighbours.");
            }
            else
            {
                var result = CheckIsLarger(numbers, index);

                Console.WriteLine($"Is {numbers[index]} larger than its neighbours? {result}");
            }
        }

        private static bool CheckIsLarger(int[] numbers, int index)
        {
            if (numbers[index] > numbers[index - 1] && numbers[index] > numbers[index + 1])
            {
                return true;
            }

            return false;
        }
    }
}