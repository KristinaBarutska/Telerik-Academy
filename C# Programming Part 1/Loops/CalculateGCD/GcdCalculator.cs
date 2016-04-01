/*
    Problem 17.* Calculate GCD
    Write a program that calculates the greatest common divisor (GCD) of given two integers a and b.
    Use the Euclidean algorithm (find it in Internet).
*/

namespace CalculateGCD
{
    using System;

    public class GcdCalculator
    {
        public static void Main()
        {
            Console.Write("a : ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b : ");
            int b = int.Parse(Console.ReadLine());
            int remainder = 1;

            while (remainder != 0)
            {
                remainder = a % b;
                a = b;
                b = remainder;
            }

            Console.WriteLine($"GCD : {a}");
        }
    }
}