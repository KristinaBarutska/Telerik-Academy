namespace Point
{
    using System;
    using System.IO;
    using System.Linq;

    public static class PathStorage
    {
        private const string FilePath = "../../paths.txt";

        public static void Save(Path path)
        {
            StreamWriter writer = new StreamWriter(FilePath);

            using (writer)
            {
                writer.WriteLine(path);
            }
        }

        public static Path Load()
        {
            Path path = new Path();
            StreamReader reader = new StreamReader(FilePath);
            char[] separators = { ' ', ',', ':', 'X', 'Y', 'Z' };

            using (reader)
            {
                while (true)
                {
                    string currentReadLine = reader.ReadLine();

                    if (string.IsNullOrEmpty(currentReadLine))
                    {
                        break;
                    }

                    double[] pointTokens = currentReadLine.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                        .Select(double.Parse)
                        .ToArray();
                    Point point = new Point(pointTokens[0], pointTokens[1], pointTokens[2]);

                    path.AddPoint(point);
                }
            }

            return path;
        }
    }
}