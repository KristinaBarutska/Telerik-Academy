/* 
    Problem 13. Solve tasks
    Write a program that can solve these tasks:
    Reverses the digits of a number
    Calculates the average of a sequence of integers
    Solves a linear equation a * x + b = 0
    Create appropriate methods.
    Provide a simple text-based menu for the user to choose which task to solve.
    Validate the input data:
    The decimal number should be non-negative
    The sequence should not be empty
    a should not be equal to 0 
*/

namespace SolveTask
{
    using System;
    using System.Linq;

    public class TaskSolver
    {
        private static void Main()
        {
            Console.WriteLine("Select a task : ");
            Console.Write("1) Reverse digits of a number.");
            Console.Write("2) Calculate average of a sequence of integer numbers: ");
            Console.Write("3) Solve linear equation \"a * x + b = 0\"");
            int choise = int.Parse(Console.ReadLine());

            switch (choise)
            {
                case 1:
                    Console.Write("Enter a number : ");
                    var number = double.Parse(Console.ReadLine());
                    var result = ReverseDigits(number);

                    Console.WriteLine($"{number} reversed is : {result}");
                    break;
                case 2:
                    Console.Write("Enter a sequence of integer numbers on a single line : ");
                    var numbers = Console.ReadLine()
                        .Split(new char[] { ',', ' ', '.' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(n => int.Parse(n))
                        .ToArray();
                    var average = CalcAverage(numbers);

                    Console.WriteLine($"The average of {string.Join(", ", numbers)} is {average}");
                    break;
                case 3:
                    Console.Write("Enter \"a\" and \"b\" separated by space : ");
                    var members = Console.ReadLine()
                        .Split(' ')
                        .Select(m => double.Parse(m))
                        .ToArray();
                    var x = SolveLinearEquation(members[0], members[1]);

                    Console.WriteLine($"X = {x}");
                    break;
                default:
                    Console.WriteLine("There is no such option.");
                    break;
            }
        }

        private static double ReverseDigits(double number)
        {
            if (number < 0)
            {
                Console.WriteLine("The number cannot be less than 0.");
            }

            var resultAsString = string.Empty;
            var numberAsString = number.ToString();

            for (int i = numberAsString.Length - 1; i >= 0; i--)
            {
                resultAsString += numberAsString[i];
            }

            var result = double.Parse(resultAsString);

            return result;
        }

        private static double CalcAverage(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                Console.WriteLine("Please provide non empty array of numbers.");
            }

            double average = numbers.Sum() / numbers.Length;

            return average;
        }

        private static double SolveLinearEquation(double a, double b)
        {
            if (a == 0)
            {
                Console.WriteLine("a cannot be 0.");
            }

            return b < 0 ? -(b / a) : (b / a);
        }
    }
}