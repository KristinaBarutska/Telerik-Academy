﻿/*
    Problem 6. The Biggest of Five Numbers
    Write a program that finds the biggest of five numbers by using only five if statements.
*/

namespace TheBiggestOfFive
{
    using System;

    public class NumberComparer
    {
        public static void Main()
        {
            Console.Write("a : ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b : ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c : ");
            double c = double.Parse(Console.ReadLine());
            Console.Write("d : ");
            double d = double.Parse(Console.ReadLine());
            Console.Write("e : ");
            double e = double.Parse(Console.ReadLine());

            Console.Write("The biggest is : ");

            if ((a > b) && (a > c) && (a > d) && (a > e))
            {
                Console.WriteLine(a);
            }
            else if ((b > a) && (b > c) && (b > d) && (b > e))
            {
                Console.WriteLine(b);
            }
            else if ((c > a) && (c > b) && (c > d) && (c > e))
            {
                Console.WriteLine(c);
            }
            else if ((d > a) && (d > b) && (d > c) && (d > e))
            {
                Console.WriteLine(d);
            }
            else
            {
                Console.WriteLine(e);
            }
        }
    }
}