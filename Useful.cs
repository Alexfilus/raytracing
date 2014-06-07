using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;//удалить

namespace raytraicing
{
    public class Useful
    {
        public static double sqr(double X) { return X * X; }
        public static float sqr(float X) { return X * X; }
        public static int sqr(int X) { return X * X; }
        public static float vect_length(PointF Vect) { return (float)Math.Sqrt(sqr(Vect.X) + sqr(Vect.Y)); }
        public static double vect_length(Point2DD Vect) { return Math.Sqrt(sqr(Vect.X) + sqr(Vect.Y)); }
        public static float vect_length(PointF Vect1, PointF Vect2) { return (float)Math.Sqrt(sqr(Vect1.X - Vect2.X) + sqr(Vect1.Y - Vect2.Y)); }
        public static double vect_length(Point2D Vect1, Point2D Vect2) { return Math.Sqrt(sqr(Vect1.X - Vect2.X) + sqr(Vect1.Y - Vect2.Y)); }
        public static double vect_length(Point2DD Vect1, Point2D Vect2) { return Math.Sqrt(sqr(Vect1.X - Vect2.X) + sqr(Vect1.Y - Vect2.Y)); }
        public static double vect_length(Point2DD Vect1, Point2DD Vect2) { return Math.Sqrt(sqr(Vect1.X - Vect2.X) + sqr(Vect1.Y - Vect2.Y)); }
        public static PointF UVect(PointF Vect) { return new PointF(Vect.X / Useful.vect_length(Vect), Vect.Y / Useful.vect_length(Vect)); }
        public static Point2DD UVect(Point2DD Vect) { return new Point2DD(Vect.X / Useful.vect_length(Vect), Vect.Y / Useful.vect_length(Vect)); }
        public static double VectorMulti(Point2DD Vect1, Point2DD Vect2) { return Vect1.X * Vect2.Y - Vect2.X * Vect1.Y; }
    }
}
