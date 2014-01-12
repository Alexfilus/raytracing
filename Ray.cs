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
    public class Ray
    {
        public Point2D FirstPoint;
        public Point2DD DirectingVector;
        public double Power;
        public Point2D CurPoint;
        public int CurT;
        public double Way;

        public Ray(Point2D _FirstPoint, Point2DD _DirectingVector, double _Power = 1.0)
        {
            FirstPoint = _FirstPoint;
            DirectingVector = Useful.UVect(_DirectingVector);
            Power = _Power;
            CurPoint = new Point2D(_FirstPoint);
            CurT = 0;
            Way = 0;
        }

        public Line ToLine()
        {
            return new Line(this);
        }

        public void NextCell(int XGR, int YGR, Listener Head)
        {
            int curX = CurPoint.X / XGR;
            int curY = CurPoint.Y / YGR;
            do
            {
                CurT++;
                CurPoint.X = (int)(CurT * DirectingVector.X) + FirstPoint.X;
                CurPoint.Y = (int)(CurT * DirectingVector.Y) + FirstPoint.Y;
            } while ((CurPoint.X / XGR == curX) && (CurPoint.Y / YGR == curY));
        }

        public void DrawRay(Graphics g, Pen pen)
        {
            //g.DrawLine(pen, FirstPoint, CurPoint);
            g.DrawLine(pen, FirstPoint.X, FirstPoint.Y, CurPoint.X, CurPoint.Y);
            g.Dispose();
        }

        public float GetDistance(Point2D Cur)
        {
            return (float)this.ToLine().GetDistance(Cur);
        }

        public double GetLength()
        {
            return Useful.vect_length(CurPoint, FirstPoint);
        }

        public void ReNew(Rib CurRib)
        {
            Way += (float)Useful.vect_length(CurPoint, FirstPoint);
            DirectingVector = new Point2DD(DirectingVector.X - 2 * (DirectingVector.X * CurRib.Normal.X + DirectingVector.Y * CurRib.Normal.Y) * CurRib.Normal.X,
                                           DirectingVector.Y - 2 * (DirectingVector.X * CurRib.Normal.X + DirectingVector.Y * CurRib.Normal.Y) * CurRib.Normal.Y);
            FirstPoint = new Point2D(CurPoint);
            CurT = 0;
            Power *= 1 - CurRib.Coef;
        }
        public void ReNew(Point2DD RibNormal, double Coef)
        {
            Way += (float)Useful.vect_length(CurPoint, FirstPoint);
            DirectingVector = new Point2DD(DirectingVector.X - 2 * (DirectingVector * RibNormal) * RibNormal.X,
                                           DirectingVector.Y - 2 * (DirectingVector * RibNormal) * RibNormal.Y);
            FirstPoint = new Point2D(CurPoint);
            CurT = 0;
            Power *= 1 - Coef;
        }
    }
    class Rays
    {
        public int Count;
        public List<Ray> List;
        

        public Rays(Point2D _Position, int _Count)
        {
            Count = _Count;
            List = new List<Ray>(Count);
            for (int i = 0; i < Count; ++i)
                Add(_Position, new Point2DD(Math.Cos(2 * Math.PI * i / Count), Math.Sin(2 * Math.PI * i / Count)));
        }

        public void Add(Point2D _FirstPoint, Point2DD _DirectingVector, double _Power = 1.0)
        {
            List.Add(new Ray(_FirstPoint, _DirectingVector, _Power));
        }

        public Ray this[int index]
        {
            get
            {
                return List[index];
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
    }
}
