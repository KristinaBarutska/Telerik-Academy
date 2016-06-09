namespace Point
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
        private List<Point> points;

        public Path()
        {
            this.points = new List<Point>();
        }

        public List<Point> Points
        {
            get
            {
                return this.points;
            }

            private set
            {
                this.points = value;
            }
        }

        public void AddPoint(Point point)
        {
            this.points.Add(point);
        }

        public void AddPoints(params Point[] points)
        {
            this.points.AddRange(points);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.points);
        }
    }
}