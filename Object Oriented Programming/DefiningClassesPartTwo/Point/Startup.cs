namespace Point
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            PathStorage.LoadPath(@"..\..\PointCoordinates.txt");
            Console.WriteLine(PathStorage.path);
        } 
    }
}