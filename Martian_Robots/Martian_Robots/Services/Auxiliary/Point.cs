namespace Martian_Robots.Services.Auxiliary
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point()
        {
        }

        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public Point(Point point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }
    }
}