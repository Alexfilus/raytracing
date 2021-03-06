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
        public Point2DD FirstPoint;
        public Point2DD SecondPoint;
        public Point2DD DirectingVector;
        public Point2DD Normal;
        public double Coef;
        public double Length;

        public Rib() { }
        public Rib(Point2DD _FirstPoint, Point2DD _SecondPoint, double _Coef)
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

        public double GetLength()
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
            g.DrawLine(Pens.Black, (int)FirstPoint.X, (int)FirstPoint.Y, (int)SecondPoint.X, (int)SecondPoint.Y);
            g.Dispose();
        }

        public Point2DD GetCrossPointXY(Ray CurRay)
        {
            double t = (CurRay.DirectingVector.X * (CurRay.FirstPoint.Y - FirstPoint.Y) - CurRay.DirectingVector.Y * (CurRay.FirstPoint.X - FirstPoint.X)) / (DirectingVector.Y * CurRay.DirectingVector.X - DirectingVector.X * CurRay.DirectingVector.Y);
            //int t = (int)((CurRay.DirectingVector.X * (CurRay.FirstPoint.Y - FirstPoint.Y) - CurRay.DirectingVector.Y * (CurRay.FirstPoint.X - FirstPoint.X)) / (DirectingVector.Y * CurRay.DirectingVector.X - DirectingVector.X * CurRay.DirectingVector.Y));
            //tau = (int)((RUVect.X * (FP.Y - RFP.Y) - RUVect.Y * (FP.X - RFP.X)) / (RUVect.Y * UVect.X - RUVect.X * UVect.Y));
            return new Point2DD(FirstPoint.X + t * DirectingVector.X, FirstPoint.Y + t * DirectingVector.Y);
        }

        public double GetCrossPointT(Ray CurRay)
        {
            // t для отрезка
            //return (int)((CurRay.DirectingVector.X * (CurRay.FirstPoint.Y - FirstPoint.Y) - CurRay.DirectingVector.Y * (CurRay.FirstPoint.X - FirstPoint.X)) / (DirectingVector.Y * CurRay.DirectingVector.X - DirectingVector.X * CurRay.DirectingVector.Y));
            // t для луча
            return (DirectingVector.X * (CurRay.FirstPoint.Y - FirstPoint.Y) - DirectingVector.Y * (CurRay.FirstPoint.X - FirstPoint.X)) / (DirectingVector.Y * CurRay.DirectingVector.X - DirectingVector.X * CurRay.DirectingVector.Y);
        }

        public bool IsParallel(Ray CurRay)
        {
            return ((CurRay.DirectingVector.Y * DirectingVector.X - CurRay.DirectingVector.X * DirectingVector.Y) == 0);
        }
        public bool IsInhere(Ray CurRay) // Проверяем принадлежит ли точка пересечения отрезку
        {
            Point2DD Res = GetCrossPointXY(CurRay);
            return ((Res.X > Math.Max(FirstPoint.X, SecondPoint.X)) ||  (Res.X < Math.Min(FirstPoint.X, SecondPoint.X)) ||
                        (Res.Y > Math.Max(FirstPoint.Y, SecondPoint.Y)) || (Res.Y < Math.Min(FirstPoint.Y, SecondPoint.Y)));
        }
        public bool IsInhere(Point2D Res) // Проверяем принадлежит ли точка пересечения отрезку
        {
            return ((Res.X > Math.Max(FirstPoint.X, SecondPoint.X)) || (Res.X < Math.Min(FirstPoint.X, SecondPoint.X)) ||
                        (Res.Y > Math.Max(FirstPoint.Y, SecondPoint.Y)) || (Res.Y < Math.Min(FirstPoint.Y, SecondPoint.Y)));
        }
       /* public static Rib GetBisector(Rib FRib, Rib SRib, Ray ray)
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
                new Point2DD(ray.FirstPoint),
                new Point2DD(RayDVect.X - 2 * (RayDVect * RibNormal) * RibNormal.X,
                             RayDVect.Y - 2 * (RayDVect * RibNormal) * RibNormal.Y)
                             );
            //new_ray.CurPoint.X = new_ray.FirstPoint.X + (int)(new_ray.DirectingVector.X * ray.GetLength());
            //new_ray.CurPoint.Y = new_ray.FirstPoint.Y + (int)(new_ray.DirectingVector.Y * ray.GetLength());
            new_ray.CurPoint = new_ray.FirstPoint + new_ray.DirectingVector * ray.GetLength();
            double FLDist_new = FL.GetDistance(new_ray.CurPoint);
            double SLDist_new = SL.GetDistance(new_ray.CurPoint);
            if ((FLDist * FLDist_new > 0) && (SLDist * SLDist_new > 0))
            {
                return new Rib(new Point2DD(new_ray.FirstPoint + new_ray.DirectingVector * 10.0), 
                    new Point2DD(new_ray.FirstPoint - new_ray.DirectingVector * 10.0), 
                    (FRib.Coef + SRib.Coef) / 2);
            }
            RibNormal = new Point2DD(SB.a, SB.b);
            RibNormal = Useful.UVect(RibNormal);
            new_ray = new Ray(
                new Point2DD(ray.FirstPoint),
                new Point2DD(RayDVect.X - 2 * (RayDVect * RibNormal) * RibNormal.X,
                             RayDVect.Y - 2 * (RayDVect * RibNormal) * RibNormal.Y)
                             );
            FLDist_new = FL.GetDistance(new_ray.CurPoint);
            SLDist_new = SL.GetDistance(new_ray.CurPoint);
            return new Rib(new Point2DD(new_ray.FirstPoint + new_ray.DirectingVector * 10.0), 
                            new Point2DD(new_ray.FirstPoint - new_ray.DirectingVector * 10.0), 
                            (FRib.Coef + SRib.Coef) / 2);
        }*/
    }

    public class Ribs
    {
        List<Rib> List = new List<Rib>();

        public Ribs()
        {

        }

        public void Add(Point2DD _FirstPoint, Point2DD _SecondPoint, double _Coef)
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
        public double GetPerimetr()
        {
            return List.Sum(rib => rib.GetLength()/100); 
        }
        private double GetFigureArea(Point2D bounds)
        {
            double Sum = 0;
            for(int i = bounds.X;i<=bounds.Y;++i)
            {
                Sum += Useful.VectorMulti(List[i].FirstPoint,i!=bounds.Y?List[i].SecondPoint:List[bounds.X].FirstPoint);
                //MessageBox.Show(Sum.ToString());
            }
            /*for (int i = bounds.X; i < bounds.Y; ++i)
            {
                Sum += Useful.VectorMulti(List[i].FirstPoint, List[i].SecondPoint);
            }
            Sum += Useful.VectorMulti(List[bounds.Y].FirstPoint, List[bounds.X].FirstPoint);
            MessageBox.Show((0.5 * Math.Abs(Sum)).ToString());*/
            return 0.5 * Math.Abs(Sum);
        }
        public double GetArea()
        {
            //Point2D MainFigure = new Point2D(0, List.FindIndex(delegate(Rib rib) { return rib.SecondPoint.X == List[0].FirstPoint.X && rib.SecondPoint.Y == List[0].FirstPoint.Y; }));
            int j = 1;
            for (; j < List.Count && !(List[j].SecondPoint.X == List[0].FirstPoint.X && List[j].SecondPoint.Y == List[0].FirstPoint.Y); ++j) ;
            Point2D MainFigure = new Point2D(0, j);
            List<Point2D> InnerFigures = new List<Point2D>();
            if(MainFigure.Y != List.Count-1)
            {
                InnerFigures.Add(new Point2D(MainFigure.Y+1,-1));
                for(int i=MainFigure.Y+2;i<List.Count;++i)
                {
                    if(List[i].SecondPoint == List[InnerFigures[InnerFigures.Count-1].X].FirstPoint)
                    {
                        InnerFigures[InnerFigures.Count - 1].Y = i;
                        InnerFigures.Add(new Point2D(i + 1, -1));
                    }
                }
            }

            return (GetFigureArea(MainFigure) - InnerFigures.Sum(bounds => GetFigureArea(bounds)))/10000;
            //return List[0].GetLength()/100 * List[1].GetLength()/100;
        }

        public double GetAlpha()
        {
            return List.Sum(rib => rib.Coef*rib.GetLength()) / this.GetPerimetr()/100;
        }
    }
}
