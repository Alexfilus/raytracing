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
        public void Check(Ray ray)
        {
            if ((ray.CurPoint.X - Position.X) * (ray.CurPoint.X - Position.X) + (ray.CurPoint.Y - Position.Y) * (ray.CurPoint.Y - Position.Y) <= Radius * Radius)
            {
                AddRay(ray.Power);
            }
        }
    }
}
