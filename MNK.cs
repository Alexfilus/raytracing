using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace raytraicing
{
    static class MNK
    {
        public static Point2DD GetLine(Point2DD[] points)
        {
            double SumXi = points.Sum(point => point.X);
            double SumYi = points.Sum(point => point.Y);
            double SumXiYi = points.Sum(point => point.X*point.Y);
            double SumXi2 = points.Sum(point => point.X*point.X);
            int n = points.Length;
            double a = (n * SumXiYi - SumXi * SumYi) / (n * SumXi2 - SumXi * SumXi);
            double b = (SumYi - a * SumXi) / n;
            //points.Sum(point =>point.X*point.X);
            //foreach(Point2DD point
            return new Point2DD(a,b);
        }
    }
}
