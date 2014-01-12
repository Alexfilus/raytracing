using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace raytraicing
{
    public class Line
    {
        double a, b, c;

        public Line(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public Line(Ray ray)
        {
            a = ray.DirectingVector.Y;
            b = -ray.DirectingVector.X;
            c = -a * ray.FirstPoint.X - b * ray.FirstPoint.Y;
        }
        public Line(Rib rib)
        {
            a = rib.DirectingVector.Y;
            b = -rib.DirectingVector.X;
            c = -a * rib.FirstPoint.X - b * rib.FirstPoint.Y;
        }

        public double GetDistance(Point point)
        {
            return a * point.X + b * point.Y + c;
        }
    }
}
