/*
    Problem 6. Quadratic Equation
    Write a program that reads the coefficients a, b and c of a quadratic equation 
    ax2 + bx + c = 0 and solves it (prints its real roots)
*/

namespace QuadraticEquation
{
    using System;

    public class EquationSolver
    {
        public static void Main()
        {
            Console.Write("a : ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b : ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c : ");
            double c = double.Parse(Console.ReadLine());
            double disc = Math.Sqrt(Math.Pow(b, 2) - (4 * a * c));

            if (disc > 0 && a != 0)
            {
                double firstRoot = (-b - disc) / (2.0 * a);
                double secondRoot = (-b + disc) / (2.0 * a);

                Console.WriteLine($"x1={firstRoot}; x2={secondRoot}");
            }
            else if (disc == 0 && a != 0)
            {
                double root = -b / (2.0 * a);
                Console.WriteLine($"x1=x2={root}");
            }
            else
            {
                Console.WriteLine("no real roots");
            }
        }
    }
}