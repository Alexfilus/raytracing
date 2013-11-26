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
        public Point FirstPoint;
        public PointF DirectingVector;
        public double Power;
        public Point CurPoint;
        public int CurT;

        public Ray(Point _FirstPoint, PointF _DirectingVector, double _Power)
        {
            FirstPoint = _FirstPoint;
            DirectingVector = new PointF(_DirectingVector.X/GetLength(_DirectingVector),_DirectingVector.Y/GetLength(_DirectingVector));
            Power = _Power;
            CurPoint = _FirstPoint;
            CurT = 0;
        }

        public Ray(Point _FirstPoint, PointF _DirectingVector)
        {
            FirstPoint = _FirstPoint;
            DirectingVector = new PointF(_DirectingVector.X / GetLength(_DirectingVector), _DirectingVector.Y / GetLength(_DirectingVector));
            Power = 1.0;
            CurPoint = _FirstPoint;
            CurT = 0;
        }

        private float GetLength(PointF Vect)
        {
            return (float)Math.Sqrt(Vect.X * Vect.X + Vect.Y * Vect.Y);
        }

        public void NextCell(int XGR, int YGR, Listener Head)
        {
            int curX = CurPoint.X / XGR;
            int curY = CurPoint.Y / YGR;
        //    if (ray[curX][curY].Count < RayCount) ray[curX][curY].Add(RayCount); // Записываем если нужно информацию о луче
            do
            {
                CurT++;
                CurPoint.X = FirstPoint.X + (int)(CurT * DirectingVector.X);
                CurPoint.Y = FirstPoint.Y + (int)(CurT * DirectingVector.Y);
                Head.Check(this);
             //   if ((x < 0) || (x >= maxX) || (y < 0) || (y >= maxY)) return; // Выход за границы
            } while ((CurPoint.X / XGR == curX) && (CurPoint.Y / YGR == curY));
        }

        public void DrawRay(Graphics g)
        {
            g.DrawLine(Pens.Black, FirstPoint, CurPoint);
            g.Dispose();
        }

        public float GetDistance(Point Cur)
        {
            return GetLength(new PointF(Cur.X - CurPoint.X, Cur.Y - CurPoint.Y));
        }

        public void ReNew(Rib CurRib, Point NewFP)
        {
            DirectingVector = new PointF(DirectingVector.X - 2 * (DirectingVector.X * CurRib.Normal.X + DirectingVector.Y * CurRib.Normal.Y) * CurRib.Normal.X,
                                         DirectingVector.Y - 2 * (DirectingVector.X * CurRib.Normal.X + DirectingVector.Y * CurRib.Normal.Y) * CurRib.Normal.Y);
            FirstPoint = NewFP;
            CurPoint = NewFP;
            CurT = 0;
            Power *= 1 - CurRib.Coef;
        }
    }
}
