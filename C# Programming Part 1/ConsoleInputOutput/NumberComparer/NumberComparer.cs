/*
    Problem 4. Number Comparer
    Write a program that gets two numbers from the console and prints the greater of them.
    Try to implement this without if statements.
*/

namespace NumberComparer
{
    using System;

    public class NumberComparer
    {
        public static void Main()
        {
            Console.Write("First number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Second number: ");
            int secondNumber = int.Parse(Console.ReadLine());
            int maxNumber = Math.Max(firstNumber, secondNumber);

            Console.WriteLine($"Max number: {maxNumber}");
        }
    }
}