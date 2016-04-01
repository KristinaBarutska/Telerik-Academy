/*
   Problem 7. Sort 3 Numbers with Nested Ifs
   Write a program that enters 3 real numbers and prints them sorted in descending order.
   Use nested if statements.
*/

namespace SortThreeNumbers
{
    using System;

    public class NumbersSorter
    {
        public static void Main()
        {
            Console.Write("a : ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b : ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c : ");
            double c = double.Parse(Console.ReadLine());

            Console.Write("Sorted : ");

            if ((a > b) && (a > c))
            {
                if (b > c)
                {
                    Console.WriteLine($"{a} {b} {c}");
                }
                else
                {
                    Console.WriteLine($"{a} {c} {b}");
                }
            }
            else if ((b > a) && (b > c))
            {
                if (a > c)
                {
                    Console.WriteLine($"{b} {a} {c}");
                }
                else
                {
                    Console.WriteLine($"{b} {c} {a}");
                }
            }
            else if ((c > a) && (c > b))
            {
                if (a > b)
                {
                    Console.WriteLine($"{c} {a} {b}", c, a, b);
                }
                else
                {
                    Console.WriteLine($"{c} {b} {a}");
                }
            }
        }
    }
}