﻿using System;
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
    public class Rib
    {
        public Point2D FirstPoint;
        public Point2D SecondPoint;
        public Point2DD DirectingVector;
        public Point2DD Normal;
        public double Coef;
        public double Length;

        public Rib() { }
        public Rib(Point2D _FirstPoint, Point2D _SecondPoint, double _Coef)
        {
            FirstPoint = _FirstPoint;
            SecondPoint = _SecondPoint;
            Coef = _Coef;
            Length = GetLength();
            DirectingVector = GetVector();
            Normal = GetNormal();
        }

        public Line ToLine()
        {
            return new Line(this);
        }

        private double GetLength()
        {
            return Useful.vect_length(SecondPoint, FirstPoint);
        }

        private Point2DD GetVector()
        {
            return new Point2DD((SecondPoint.X - FirstPoint.X) / Length, (SecondPoint.Y - FirstPoint.Y) / Length);
        }

        public Point2DD GetNormal()
        {
            return new Point2DD(-DirectingVector.Y, DirectingVector.X);
        }

        public void DrawRib(Graphics g)
        {
            g.DrawLine(Pens.Black, FirstPoint.X, FirstPoint.Y, SecondPoint.X, SecondPoint.Y);
            g.Dispose();
        }

        public Point2D GetCrossPointXY(Ray CurRay)
        {
            int t = (int)((CurRay.DirectingVector.X * (CurRay.FirstPoint.Y - FirstPoint.Y) - CurRay.DirectingVector.Y * (CurRay.FirstPoint.X - FirstPoint.X)) / (DirectingVector.Y * CurRay.DirectingVector.X - DirectingVector.X * CurRay.DirectingVector.Y));
            //tau = (int)((RUVect.X * (FP.Y - RFP.Y) - RUVect.Y * (FP.X - RFP.X)) / (RUVect.Y * UVect.X - RUVect.X * UVect.Y));
            return new Point2D(FirstPoint.X + (int)(t * DirectingVector.X), FirstPoint.Y + (int)(t * DirectingVector.Y));
        }

        public int GetCrossPointT(Ray CurRay)
        {
            // t для отрезка
            //return (int)((CurRay.DirectingVector.X * (CurRay.FirstPoint.Y - FirstPoint.Y) - CurRay.DirectingVector.Y * (CurRay.FirstPoint.X - FirstPoint.X)) / (DirectingVector.Y * CurRay.DirectingVector.X - DirectingVector.X * CurRay.DirectingVector.Y));
            // t для луча
            return (int)((DirectingVector.X * (CurRay.FirstPoint.Y - FirstPoint.Y) - DirectingVector.Y * (CurRay.FirstPoint.X - FirstPoint.X)) / (DirectingVector.Y * CurRay.DirectingVector.X - DirectingVector.X * CurRay.DirectingVector.Y));
        }

        public bool IsParallel(Ray CurRay)
        {
            return ((CurRay.DirectingVector.Y * DirectingVector.X - CurRay.DirectingVector.X * DirectingVector.Y) == 0);
        }
        public bool IsInhere(Ray CurRay) // Проверяем принадлежит ли точка пересечения отрезку
        {
            Point2D Res = GetCrossPointXY(CurRay);
            return ((Res.X > Math.Max(FirstPoint.X, SecondPoint.X)) ||  (Res.X < Math.Min(FirstPoint.X, SecondPoint.X)) ||
                        (Res.Y > Math.Max(FirstPoint.Y, SecondPoint.Y)) || (Res.Y < Math.Min(FirstPoint.Y, SecondPoint.Y)));
        }
        public bool IsInhere(Point2D Res) // Проверяем принадлежит ли точка пересечения отрезку
        {
            return ((Res.X > Math.Max(FirstPoint.X, SecondPoint.X)) || (Res.X < Math.Min(FirstPoint.X, SecondPoint.X)) ||
                        (Res.Y > Math.Max(FirstPoint.Y, SecondPoint.Y)) || (Res.Y < Math.Min(FirstPoint.Y, SecondPoint.Y)));
        }
        public static Rib GetBisector(Rib FRib, Rib SRib, Ray ray)
        {
            Line FL = new Line(FRib);
            Line SL = new Line(SRib);
            Line FB = new Line(FL.a - SL.a, FL.b - SL.b, FL.c - SL.c);
            Line SB = new Line(FL.a + SL.a, FL.b + SL.b, FL.c + SL.c);
            double FLDist = FL.GetDistance(ray.FirstPoint);
            double SLDist = SL.GetDistance(ray.FirstPoint);

            Point2DD RayDVect = new Point2DD(ray.DirectingVector);
            Point2DD RibNormal = new Point2DD(FB.a,FB.b);
            RibNormal = Useful.UVect(RibNormal);
            Ray new_ray = new Ray(
                new Point2D(ray.FirstPoint),
                new Point2DD(RayDVect.X - 2 * (RayDVect * RibNormal) * RibNormal.X,
                             RayDVect.Y - 2 * (RayDVect * RibNormal) * RibNormal.Y)
                             );
            //new_ray.CurPoint.X = new_ray.FirstPoint.X + (int)(new_ray.DirectingVector.X * ray.GetLength());
            //new_ray.CurPoint.Y = new_ray.FirstPoint.Y + (int)(new_ray.DirectingVector.Y * ray.GetLength());
            new_ray.CurPoint = new_ray.FirstPoint+(Point2D)(new_ray.DirectingVector*ray.GetLength());
            double FLDist_new = FL.GetDistance(new_ray.CurPoint);
            double SLDist_new = SL.GetDistance(new_ray.CurPoint);
            if ((FLDist * FLDist_new > 0) && (SLDist * SLDist_new > 0))
            {
                return new Rib(new Point2D(new_ray.FirstPoint + (Point2D)(new_ray.DirectingVector * 10.0)), 
                    new Point2D(new_ray.FirstPoint - (Point2D)(new_ray.DirectingVector * 10.0)), 
                    (FRib.Coef + SRib.Coef) / 2);
            }
            RibNormal = new Point2DD(SB.a, SB.b);
            RibNormal = Useful.UVect(RibNormal);
            new_ray = new Ray(
                new Point2D(ray.FirstPoint),
                new Point2DD(RayDVect.X - 2 * (RayDVect * RibNormal) * RibNormal.X,
                             RayDVect.Y - 2 * (RayDVect * RibNormal) * RibNormal.Y)
                             );
            FLDist_new = FL.GetDistance(new_ray.CurPoint);
            SLDist_new = SL.GetDistance(new_ray.CurPoint);
            return new Rib(new Point2D(new_ray.FirstPoint + (Point2D)(new_ray.DirectingVector * 10.0)), 
                            new Point2D(new_ray.FirstPoint - (Point2D)(new_ray.DirectingVector * 10.0)), 
                            (FRib.Coef + SRib.Coef) / 2);
        }
    }

    class Ribs
    {
        private List<Rib> List = new List<Rib>();

        public Ribs()
        {

        }

        public void Add(Point2D _FirstPoint, Point2D _SecondPoint, double _Coef)
        {
            List.Add(new Rib(_FirstPoint, _SecondPoint, _Coef));
        }

        public Rib this[int index]
        {
            get
            {
                try
                {
                    return List[index];
                }
                catch 
                { 
                    return List[1];
                }
            }
        }
        public int GetCount()
        {
            return List.Count;
        }
        public void Clear()
        {
            List.Clear();
        }
        public List<Point2D> GetFirstPoints()
        {
            List<Point2D> result = new List<Point2D>();
            foreach (Rib rib in List)
            {
                result.Add(rib.FirstPoint);
            }
            return result;
        }
        public List<Point2D> GetSecondPoints()
        {
            List<Point2D> result = new List<Point2D>();
            foreach (Rib rib in List)
            {
                result.Add(rib.SecondPoint);
            }
            return result;
        }
    }
}
