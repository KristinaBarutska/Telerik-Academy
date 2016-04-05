namespace Point
{
    using System;

    public static class DistanceCalculator
    {
        public static double CalculateDistanceBetweenPoitns(Point3D firstPoint, Point3D secondPoint)
        {
            var distance = Math.Sqrt(Math.Pow((secondPoint.X - firstPoint.X), 2) +
                Math.Pow((secondPoint.Y - firstPoint.Y), 2)) +
                Math.Pow((secondPoint.Z - firstPoint.Z), 2);

            return distance;
        }
    }
}