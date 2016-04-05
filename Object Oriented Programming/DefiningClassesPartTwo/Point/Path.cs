namespace Point
{
    using System.Collections.Generic;

    public class Path
    {
        private List<Point3D> points;

        public Path()
        {
            this.points = new List<Point3D>();
        }

        public Path(Point3D point)
        {
            this.points = new List<Point3D>();
            this.points.Add(point);
        }

        public List<Point3D> Points
        {
            get { return this.points; }
            private set { this.points = value; }
        }

        public override string ToString()
        {
            return string.Join("\n", points);
        }
    }
}