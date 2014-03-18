using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace raytraicing
{
    static class MNK
    {
        public static Line GetLine(Point2DD[] points)
        {
            Line result = new Line(0, 0, 0);
            double SumXi = 0;
            double SumYi = 0;
            double SumXiYi = 0;
            double SumXi2 = 0;
            points.Sum(point =>point.X*point.X);
            //foreach(Point2DD point
            return result;
        }
    }
}
