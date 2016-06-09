namespace Point
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Point firstPoint = new Point(1, 2, 3);
            Point secondPoint = new Point(3, 2, 1);
            Point thirdPoint = new Point(4, 4, 1);
            Path path = new Path();

            path.AddPoints(firstPoint, secondPoint, thirdPoint);

            PathStorage.Save(path);

            Path readPath = PathStorage.Load();

            Console.WriteLine(readPath);
        }
    }
}