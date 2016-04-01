/*
    Problem 10. Point Inside a Circle & Outside of a Rectangle
    Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5)
    and out of the rectangle R(top=1, left=-1, width=6, height=2).
*/

namespace InsideCircleOutsideRectangle
{
    using System;

    public class PointChecker
    {
        public static void Main()
        {
            Console.Write("X : ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Y : ");
            double y = double.Parse(Console.ReadLine());

            bool isInCircle = ((x - 1) * (x - 1)) + ((y - 1) * (y - 1)) <= (1.5 * 1.5);
            bool isOutsideRectangle = (x > 1 || x < 6) && (y > -1 || y < 2);

            string result = "Is inside the circle and outside the rectangle ? : ";
            if (x == 0 || y == 0)
            {
                result += "no";
            }
            else if (isInCircle == true && isOutsideRectangle == true)
            {
                result += "yes";
            }
            else
            {
                result += "no";
            }

            Console.WriteLine(result);
        }
    }
}