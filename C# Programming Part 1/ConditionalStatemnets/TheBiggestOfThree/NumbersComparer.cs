/*
    Problem 5. The Biggest of 3 Numbers
    Write a program that finds the biggest of three numbers.
*/

namespace TheBiggestOfThree
{
    using System;

    public class NumbersComparer
    {
        public static void Main()
        {
            Console.Write("a : ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b : ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c : ");
            double c = double.Parse(Console.ReadLine());

            if (a > b)
            {
                if (a > c)
                {
                    Console.WriteLine($"{a}");
                }
            }
            else if (b > a)
            {
                if (b > c)
                {
                    Console.WriteLine($"{b}");
                }
            }
            else if (c > a)
            {
                if (c > b)
                {
                    Console.WriteLine($"{c}");
                }
            }
        }
    }
}