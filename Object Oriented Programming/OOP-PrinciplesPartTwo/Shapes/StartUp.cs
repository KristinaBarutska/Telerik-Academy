namespace Shapes
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Shape triangle = new Triangle(3, 4);
            Shape rectangle = new Rectangle(4, 6);
            Shape square = new Square(2);
            double triangleSurface = triangle.CalculateSurface();
            double rectangleSurface = rectangle.CalculateSurface();
            double squareSurface = square.CalculateSurface();

            Console.WriteLine($"Triangle's surface: {triangleSurface}\nRectangle's Surface: {rectangleSurface}\n"
                + $"Square's surface: {squareSurface}");
        }
    }
}