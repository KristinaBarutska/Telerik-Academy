/*
    Problem 4. Triangle surface
    Write methods that calculate the surface of a triangle by given:
    Side and an altitude to it;
    Three sides;
    Two sides and an angle between them;
    Use System.Math. 
*/

namespace TriangleSurface
{
    using System;

    public class SurfaceCalculator
    {
        private static void Main()
        {
            Console.WriteLine("Chose a way to calculate surface of triangle : ");
            Console.WriteLine("1) By side and an altitude to it.");
            Console.WriteLine("2) By three sides.");
            Console.WriteLine("3) By two sides and an angle between them.");
            Console.Write("Choise : ");
            var choise = int.Parse(Console.ReadLine());

            switch (choise)
            {
                case 1:
                    Console.Write("Enter a side : ");
                    double side = double.Parse(Console.ReadLine());
                    Console.Write("Enter an altitude to the side : ");
                    double altitude = double.Parse(Console.ReadLine());
                    double choiseOneResult = CalcBySideAndAltitude(side, altitude);

                    Console.WriteLine($"Area: {choiseOneResult:0.##}");
                    break;
                case 2:
                    Console.Write("a : ");
                    double a = double.Parse(Console.ReadLine());
                    Console.Write("b : ");
                    double b = double.Parse(Console.ReadLine());
                    Console.Write("c : ");
                    double c = double.Parse(Console.ReadLine());
                    double choiseTwoResult = CalcByThreeSides(a, b, c);

                    Console.WriteLine($"Area: {choiseTwoResult:0.##}");
                    break;
                case 3:
                    Console.Write("First side : ");
                    double firstSide = double.Parse(Console.ReadLine());
                    Console.Write("Second side : ");
                    double secondSide = double.Parse(Console.ReadLine());
                    Console.Write("Angle between them : ");
                    double angle = double.Parse(Console.ReadLine());
                    double choiseThreeResult = CalcByTwoSidesAndAngle(firstSide, secondSide, angle);

                    Console.WriteLine($"Area: {choiseThreeResult:0.##}");
                    break;
                default:
                    Console.WriteLine("There is no such choise.");
                    break;
            }
        }

        private static double CalcBySideAndAltitude(double size, double altitude)
        {
            double result = (size * altitude) / 2;

            return result;
        }

        private static double CalcByThreeSides(double a, double b, double c)
        {
            double perimeter = (a + b + c) / 2;
            double result = Math.Sqrt((double)(perimeter * (perimeter - a) * (perimeter - b) * (perimeter - c)));

            return result;
        }

        private static double CalcByTwoSidesAndAngle(double firstSide, double secondSide, double angle)
        {
            double result = 0;

            angle = angle * Math.PI / 180.0;
            result = (Math.Sin((double)angle) * firstSide * secondSide) / 2.0;

            return result;
        }
    }
}