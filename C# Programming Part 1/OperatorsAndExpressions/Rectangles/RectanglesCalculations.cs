/*
    Problem 4. Rectangles
    Write an expression that calculates rectangle’s perimeter and area by given width and height.
*/

namespace Rectangles
{
    using System;

    public class RectanglesCalculations
    {
        public static void Main()
        {
            Console.Write("Width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            double height = double.Parse(Console.ReadLine());
            double perimeter = (2 * width) + (2 * height);
            double area = width * height;

            Console.WriteLine($"Perimeter: {perimeter}, Area: {area}");
        }
    }
}