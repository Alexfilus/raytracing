using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace raytraicing
{
    
    public class Listener
    {
        public Point2D Position;
        public int Radius;
        public List<double> LoudList;
        public List<double> Ways;

        public Listener(Point2D _Position, int _Radius)
        {
            Position = _Position;
            Radius = _Radius;
            LoudList = new List<double>();
            Ways = new List<double>();
        }
        public void AddRay(double power, double Way)
        {
            LoudList.Add(power);
            Ways.Add(Way);
        }
        public void AddRay(Ray ray)
        {
            LoudList.Add(ray.Power);
            Ways.Add(ray.Way);
        }
        public int Check(Ray ray)
        {
            Point2DD m = ray.DirectingVector;
            Point2DD d = new Point2DD(Position.X - ray.FirstPoint.X, Position.Y - ray.FirstPoint.Y);
            double scal = m.X * d.X + m.Y * d.Y;
            if (scal < 0) return 1;
            double dist1 = ray.GetLength();
            if (dist1 < scal) return 2;

            double dist2 = Math.Abs(ray.GetDistance(Position));
            if (dist2 < Radius)
            {
                double LastDist = GetDistance(ray);
                ray.Way += LastDist;
                ray.CurPoint.X = ray.FirstPoint.X + (int)(ray.DirectingVector.X * LastDist);
                ray.CurPoint.Y = ray.FirstPoint.Y + (int)(ray.DirectingVector.Y * LastDist);
                AddRay(ray);
                ray.Power = 0;
                return 0;
            }
            else return 3;
        }
        public void DrawHead(Graphics g)
        {
            g.DrawEllipse(Pens.Pink, Position.X - Radius, Position.Y - Radius, 2 * Radius, 2 * Radius);
            g.Dispose();
        }
        private double GetDistance(Ray ray)
        {
            double x0 = ray.FirstPoint.X;
            double y0 = ray.FirstPoint.Y;
            double x1 = Position.X;
            double y1 = Position.Y;
            double Ax = ray.DirectingVector.X;
            double Ay = ray.DirectingVector.Y;
            double R = Radius;
            double left_part = -x0 * Ax - y0 * Ay + Ay * y1 + Ax * x1;
            double right_part = 2 * x0 * Ax * y0 * Ay - 2 * x0 * Ax * Ay * y1 - 2 * y0 * Ay * Ax * x1 + 2 * Ay * y1 * Ax * x1 - Ay * Ay * x0 * x0 - Ay * Ay * x1 * x1 + 2 * Ay * Ay * x0 * x1 + Ay * Ay * R * R - Ax * Ax * y1 * y1 + 2 * Ax * Ax * y0 * y1 - Ax * Ax * y0 * y0 + Ax * Ax * R * R;
            right_part = (float)Math.Sqrt(right_part);
            Point2DD FirstRoot = new Point2DD(ray.FirstPoint.X + (left_part + right_part) * ray.DirectingVector.X, ray.FirstPoint.Y + (left_part + right_part) * ray.DirectingVector.Y);
            Point2DD SecondRoot = new Point2DD(ray.FirstPoint.X + (left_part - right_part) * ray.DirectingVector.X, ray.FirstPoint.Y + (left_part - right_part) * ray.DirectingVector.Y);
            return Math.Min(Useful.vect_length(FirstRoot, ray.FirstPoint), Useful.vect_length(SecondRoot, ray.FirstPoint));
        }
    }
}
