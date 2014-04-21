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
        public Point2DD FirstPoint;
        public Point2DD DirectingVector;
        public double Power;
        public Point2DD CurPoint;
        public int CurT;
        public double Way;

        public Ray(Point2DD _FirstPoint, Point2DD _DirectingVector, double _Power = 1.0)
        {
            FirstPoint = _FirstPoint;
            DirectingVector = Useful.UVect(_DirectingVector);
            Power = _Power;
            CurPoint = new Point2DD(_FirstPoint);
            CurT = 0;
            Way = 0;
        }

        public Line ToLine()
        {
            return new Line(this);
        }

        public void NextCell(int XGR, int YGR, Listener Head)
        {
            int curX = (int)CurPoint.X / XGR;
            int curY = (int)CurPoint.Y / YGR;
            do
            {
                CurT++;
                CurPoint.X = CurT * DirectingVector.X + FirstPoint.X;
                CurPoint.Y = CurT * DirectingVector.Y + FirstPoint.Y;
            } while (((int)CurPoint.X / XGR == curX) && ((int)CurPoint.Y / YGR == curY));
        }

        public void DrawRay(Graphics g, Pen pen)
        {
            g.DrawLine(pen, (int)FirstPoint.X, (int)FirstPoint.Y, (int)CurPoint.X, (int)CurPoint.Y);
            g.Dispose();
        }

        public double GetDistance(Point2D Cur)
        {
            return this.ToLine().GetDistance(Cur);
        }

        public double GetLength()
        {
            return Useful.vect_length(CurPoint, FirstPoint);
        }

        public void ReNew(Rib CurRib)
        {
            Way += Useful.vect_length(CurPoint, FirstPoint);
            DirectingVector = new Point2DD(DirectingVector.X - 2 * (DirectingVector.X * CurRib.Normal.X + DirectingVector.Y * CurRib.Normal.Y) * CurRib.Normal.X,
                                           DirectingVector.Y - 2 * (DirectingVector.X * CurRib.Normal.X + DirectingVector.Y * CurRib.Normal.Y) * CurRib.Normal.Y);
            FirstPoint = new Point2DD(CurPoint);
            CurT = 0;
            Power *= 1 - CurRib.Coef;
        }
        public void ReNew(Point2DD RibNormal, double Coef)
        {
            Way += Useful.vect_length(CurPoint, FirstPoint);
            DirectingVector = new Point2DD(DirectingVector.X - 2 * (DirectingVector * RibNormal) * RibNormal.X,
                                           DirectingVector.Y - 2 * (DirectingVector * RibNormal) * RibNormal.Y);
            FirstPoint = new Point2DD(CurPoint);
            CurT = 0;
            Power *= 1 - Coef;
        }
    }
    class Rays
    {
        public int Count;
        public List<Ray> List;
        

        public Rays(Point2DD _Position, int _Count)
        {
            Count = _Count;
            List = new List<Ray>(Count);
            for (int i = 0; i < Count; ++i)
                Add(_Position, new Point2DD(Math.Cos(2 * Math.PI * i / Count), Math.Sin(2 * Math.PI * i / Count)));
        }

        public void Add(Point2DD _FirstPoint, Point2DD _DirectingVector, double _Power = 1.0)
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
