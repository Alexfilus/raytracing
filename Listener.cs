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
        public Point Position;
        public int Radius;
        //public List<Ray> RayList;
        public List<double> LoudList;

        public Listener(Point _Position, int _Radius)
        {
            Position = _Position;
            Radius = _Radius;
            //RayList = new List<Ray>();
            LoudList = new List<double>();
        }
        /*public void AddRay(Ray ray)
        {
            if(!RayList.Contains(ray)) RayList.Add(ray);
        }*/
        public void AddRay(double power)
        {
            if (!LoudList.Contains(power)) LoudList.Add(power);
        }
        public int Check(Ray ray)
        {
            if (Useful.vect_length(new PointF(Position.X - ray.FirstPoint.X, Position.Y - ray.FirstPoint.Y)) < Radius)
            {
                AddRay(ray.Power);
                return 0;
            }
            if (Useful.vect_length(new PointF(Position.X - ray.CurPoint.X, Position.Y - ray.CurPoint.Y)) < Radius)
            {
                AddRay(ray.Power);
                return 0;
            }
            PointF m = ray.DirectingVector;
            PointF d = new PointF(Position.X - ray.FirstPoint.X, Position.Y - ray.FirstPoint.Y);
            double scal = m.X * d.X + m.Y * d.Y;
            if (scal < 0) return 1;
            double dist1 = Useful.vect_length(new PointF(ray.CurPoint.X - ray.FirstPoint.X, ray.CurPoint.Y - ray.FirstPoint.Y));
            if (dist1 < scal) return 2;

            double a = ray.DirectingVector.Y;
            double b = -ray.DirectingVector.X;
            double c = -a * ray.FirstPoint.X - b * ray.FirstPoint.Y;
            double dist2 = a * Position.X + b * Position.Y + c;
            dist2 = Math.Abs(dist2);
            if (dist2 < Radius)
            {
                AddRay(ray.Power);
                return 0;
            }
            else return 3;
        }
        public void DrawHead(Graphics g)
        {
            g.DrawEllipse(Pens.Pink, Position.X - Radius, Position.Y - Radius, 2 * Radius, 2 * Radius);
            g.Dispose();
        }
    }
}
