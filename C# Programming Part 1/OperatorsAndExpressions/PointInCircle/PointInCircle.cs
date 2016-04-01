/*
    Problem 7. Point in a Circle
    Write an expression that checks if given point (x, y) is inside a circle K({0, 0}, 2).
*/

namespace PointInCircle
{
    using System;

    public class PointInCircle
    {
        public static void Main()
        {
            Console.Write("X: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Y: ");
            double y = double.Parse(Console.ReadLine());
            bool isInsideCircle = (x * x) + (y * y) <= 4;

            Console.WriteLine($"Inside? {isInsideCircle}");
        }
    }
}