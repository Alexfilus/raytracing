using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace raytraicing
{
    public class Useful
    {
        public static double sqr(double X) { return X * X; }
        public static float sqr(float X) { return X * X; }
        public static int sqr(int X) { return X * X; }
        public static float vect_length(PointF Vect) { return (float)Math.Sqrt(sqr(Vect.X) + sqr(Vect.Y)); }
        public static PointF UVect(PointF Vect) { return new PointF(Vect.X / Useful.vect_length(Vect), Vect.Y / Useful.vect_length(Vect)); }
    }
}
