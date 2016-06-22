namespace Shapes
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Shape[] shapes = new Shape[3]
            {
                new Rectangle(3, 4),
                new Square(2),
                new Triangle(2, 4)
            };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine("Surface of {0} = {1:0.00}", shape.GetType().Name, shape.CalculateSurface());
                Console.WriteLine(new string('=', 30));
            }
        }
    }
}