/*
    Problem 3. Circle Perimeter and Area
    Write a program that reads the radius r of a circle and prints its perimeter
    and area formatted with 2 digits after the decimal point.
*/

namespace CirclePerimeterAndArea
{
    using System;

    public class CircleCalculations
    {
        public static void Main()
        {
            Console.Write("Radius: ");
            double radius = double.Parse(Console.ReadLine());
            double perimeter = 2 * Math.PI * radius;
            double area = Math.PI * radius * radius;

            Console.WriteLine($"Perimeter: {perimeter:0.##}, Radius: {area:#.##}");
        }
    }
}