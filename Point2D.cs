using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace raytraicing
{
    public class Point2D
    {
        public int X, Y;
        public Point2D(int x = 0, int y = 0) { X = x; Y = y; }
        public Point2D(Point2D point) { X = point.X; Y = point.Y; }
        public override string ToString() { return "{X=" + X.ToString() + ";Y=" + Y.ToString() + "}"; }

        public static Point2D operator +(Point2D point1, Point2D point2) { return new Point2D(point1.X + point2.X, point1.Y + point2.Y); }
        public static Point2D operator -(Point2D point1, Point2D point2) { return new Point2D(point1.X - point2.X, point1.Y - point2.Y); }
        public static Point2DD operator *(Point2D point, double mul) { return new Point2DD(point.X * mul, point.Y * mul); }
        public static double operator *(Point2D point1, Point2D point2) { return point1.X * point2.Y + point1.Y * point2.Y; }
        public static bool operator ==(Point2D point1, Point2D point2) { return point1.X == point2.X && point1.Y == point2.Y; }
        public static bool operator !=(Point2D point1, Point2D point2) { return !(point1 == point2); }

        public static explicit operator Point2D(Point2DD point)
        {
            return new Point2D((int)point.X, (int)point.Y);
        }
    }
    public class Point2DF
    {
        public float X, Y;
        public Point2DF(float x = 0, float y = 0) { X = x; Y = y; }
        public Point2DF(Point2DF point) { X = point.X; Y = point.Y; }
        public override string ToString() { return "{X=" + X.ToString() + ";Y=" + Y.ToString() + "}"; }
    }
    public class Point2DD
    {
        public double X, Y;
        public Point2DD(double x = 0, double y = 0) { X = x; Y = y; }
        public Point2DD(Point2DD point) { X = point.X; Y = point.Y; }
        public override string ToString() { return "{X=" + X.ToString() + ";Y=" + Y.ToString() + "}"; }

        public static Point2DD operator +(Point2DD point1, Point2DD point2) { return new Point2DD(point1.X + point2.X, point1.Y + point2.Y); }
        public static Point2DD operator -(Point2DD point1, Point2DD point2) { return new Point2DD(point1.X - point2.X, point1.Y - point2.Y); }
        public static Point2DD operator *(Point2DD point, double mul) { return new Point2DD(point.X * mul, point.Y * mul); }
        public static double operator *(Point2DD point1, Point2DD point2) { return point1.X * point2.Y + point1.Y * point2.Y; }
        public static bool operator ==(Point2DD point1, Point2DD point2) { return point1.X == point2.X && point1.Y == point2.Y; }
        public static bool operator !=(Point2DD point1, Point2DD point2) { return !(point1 == point2); }
    }
}
