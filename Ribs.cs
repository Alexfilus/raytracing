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
    public class Rib
    {
        public Point FirstPoint;
        public Point SecondPoint;
        public PointF DirectingVector;
        public PointF Normal;
        public double Coef;
        public float Length;

        public Rib(Point _FirstPoint, Point _SecondPoint, double _Coef)
        {
            FirstPoint = _FirstPoint;
            SecondPoint = _SecondPoint;
            Coef = _Coef;
            Length = GetLength();
            DirectingVector = GetVector();
            Normal = GetNormal();
        }

        private float GetLength()
        {
            return (float)Math.Sqrt(((SecondPoint.X - FirstPoint.X) * (SecondPoint.X - FirstPoint.X)) + ((SecondPoint.Y - FirstPoint.Y) * (SecondPoint.Y - FirstPoint.Y)));
        }

        private PointF GetVector()
        {
            return new PointF((SecondPoint.X - FirstPoint.X) / Length, (SecondPoint.Y - FirstPoint.Y) / Length);
        }

        public PointF GetNormal()
        {
            return new PointF(-DirectingVector.Y, DirectingVector.X);
        }

        public void DrawRib(Graphics g)
        {
            g.DrawLine(Pens.Black, FirstPoint, SecondPoint);
            g.Dispose();
        }

        public Point GetCrossPointXY(Ray CurRay)
        {
            /*PointF RUVect = new PointF();
            Point RFP = Points[Ribs[num].X];
            // Формируем направляющий, единичный вектор ребра
            if (Points[Ribs[num].Y].X == Points[Ribs[num].X].X)
            {
                RUVect.X = 0;
                RUVect.Y = (Points[Ribs[num].Y].Y - Points[Ribs[num].X].Y) / Math.Abs(Points[Ribs[num].Y].Y - Points[Ribs[num].X].Y);
            }
            else
            {
                Point Vect = new Point(Points[Ribs[num].Y].X - Points[Ribs[num].X].X, Points[Ribs[num].Y].Y - Points[Ribs[num].X].Y);
                float CurNorm = norma(Vect);
                RUVect.X = Vect.X / CurNorm;
                RUVect.Y = Vect.Y / CurNorm;
            }*/
            int t = (int)((CurRay.DirectingVector.X * (CurRay.FirstPoint.Y - FirstPoint.Y) - CurRay.DirectingVector.Y * (CurRay.FirstPoint.X - FirstPoint.X)) / (DirectingVector.Y * CurRay.DirectingVector.X - DirectingVector.X * CurRay.DirectingVector.Y));
            //tau = (int)((RUVect.X * (FP.Y - RFP.Y) - RUVect.Y * (FP.X - RFP.X)) / (RUVect.Y * UVect.X - RUVect.X * UVect.Y));
            return new Point(FirstPoint.X + (int)(t * DirectingVector.X), FirstPoint.Y + (int)(t * DirectingVector.Y));
        }

        public int GetCrossPointT(Ray CurRay)
        {
            // t для отрезка
            //return (int)((UVect.X * (FP.Y - RFP.Y) - UVect.Y * (FP.X - RFP.X)) / (RUVect.Y * UVect.X - RUVect.X * UVect.Y));
            // t для луча
            return (int)((DirectingVector.X * (CurRay.FirstPoint.Y - FirstPoint.Y) - DirectingVector.Y * (CurRay.FirstPoint.X - FirstPoint.X)) / (DirectingVector.Y * CurRay.DirectingVector.X - DirectingVector.X * CurRay.DirectingVector.Y));
        }

        public bool IsParallel(Ray CurRay)
        {
            return ((CurRay.DirectingVector.Y * DirectingVector.X - CurRay.DirectingVector.X * DirectingVector.Y) == 0);
        }
        public bool IsInhere(Ray CurRay) // Проверяем принадлежит ли точка пересечения отрезку
        {
            Point Res = GetCrossPointXY(CurRay);
            return ((Res.X > Math.Max(FirstPoint.X, SecondPoint.X)) ||  (Res.X < Math.Min(FirstPoint.X, SecondPoint.X)) ||
                        (Res.Y > Math.Max(FirstPoint.Y, SecondPoint.Y)) || (Res.Y < Math.Min(FirstPoint.Y, SecondPoint.Y)));
        }
        public bool IsInhere(Point Res) // Проверяем принадлежит ли точка пересечения отрезку
        {
            return ((Res.X > Math.Max(FirstPoint.X, SecondPoint.X)) || (Res.X < Math.Min(FirstPoint.X, SecondPoint.X)) ||
                        (Res.Y > Math.Max(FirstPoint.Y, SecondPoint.Y)) || (Res.Y < Math.Min(FirstPoint.Y, SecondPoint.Y)));
        }
    }

    class Ribs
    {
        private List<Rib> List = new List<Rib>();

        public Ribs()
        {

        }

        public void Add(Point _FirstPoint, Point _SecondPoint, double _Coef)
        {
            List.Add(new Rib(_FirstPoint, _SecondPoint, _Coef));
        }

        public Rib this[int index]
        {
            get
            {
                return List[index];
            }
            //set
            //{
            //    List[index] = value;
            //}
        }
        public int GetCount()
        {
            return List.Count;
        }
        public void Clear()
        {
            List.Clear();
        }
    }
}
