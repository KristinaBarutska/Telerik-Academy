/*
    Problem 13.* Comparing Floats
    Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001.
    Note: Two floating-point numbers a and b cannot be compared directly by a == b because of the nature of the 
    floating-point arithmetic. Therefore, we assume two numbers are equal if they are more closely to each other
    than a fixed constant eps.
*/

namespace ComparingFloats
{
    using System;

    public class FloatsComparer
    {
        public static void Main()
        {
            Console.Write("Enter first number : ");
            double firstNumber = double.Parse(Console.ReadLine());
            Console.Write("Enter second number : ");
            double secondNumber = double.Parse(Console.ReadLine());
            double difference = Math.Abs(firstNumber - secondNumber);
            double threshold = 0.000001; 
            bool areEqual = difference < threshold;

            Console.WriteLine($"Equal ? {areEqual}");
        }
    }
}