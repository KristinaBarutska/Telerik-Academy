/* 
    Problem 16.* Subset with sum S
   We are given an array of integers and a number S.
   Write a program to find if there exists a subset of the elements of the array 
   that has a sum S. 
*/

namespace SubsetWithSumS
{
    using System;
    using System.Linq;

    public class SubsetSumFInder
    {
        private static void Main()
        {
            int[] numbers = { 2, 1, 2, 4, 3, 5, 2, 6 };
            int sum = 14;

            Array.Sort(numbers);

            bool hasSubset = CheckForSubsetWithSum(numbers, sum);

            Console.WriteLine(hasSubset ? "Yes" : "No");
        }

        private static bool CheckForSubsetWithSum(int[] numbers, int sum)
        {
            int a = numbers.Where(x => x < 0).Sum();
            int b = numbers.Where(x => x > 0).Sum();

            if (a > sum || b < sum)
            {
                return false;
            }

            int rows = numbers.Length + 1;
            int cols = sum + 1;
            var table = new bool[rows, cols];

            for (int i = 0; i <= sum; i++)
            {
                table[0, i] = false;
            }

            for (int i = 1; i <= sum; i++)
            {
                for (int j = 1; j <= numbers.Length; j++)
                {
                    table[j, i] = (numbers[j - 1] == i) || table[j - 1, i] ||
                    ((i - numbers[j - 1] >= numbers.Take(j).Where(number => number < 0).Sum()) &&
                    (i - numbers[j - 1] <= numbers.Take(j).Where(number => number > 0).Sum()) &&
                    table[j - 1, i - numbers[j - 1]]);
                }
            }

            return table[numbers.Length, sum];
        }
    }
}