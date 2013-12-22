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

        public Ray(Point _FirstPoint, PointF _DirectingVector, double _Power = 1.0)
        {
            FirstPoint = _FirstPoint;
            DirectingVector = new PointF(_DirectingVector.X/GetLength(_DirectingVector),_DirectingVector.Y/GetLength(_DirectingVector));
            Power = _Power;
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
            do
            {
                CurT++;
                CurPoint.X = FirstPoint.X + (int)(CurT * DirectingVector.X);
                CurPoint.Y = FirstPoint.Y + (int)(CurT * DirectingVector.Y);
            } while ((CurPoint.X / XGR == curX) && (CurPoint.Y / YGR == curY));
        }

        public void DrawRay(Graphics g, Pen pen)
        {
            g.DrawLine(pen, FirstPoint, CurPoint);
            g.Dispose();
        }

        public float GetDistance(Point Cur)
        {
            return GetLength(new PointF(Cur.X - CurPoint.X, Cur.Y - CurPoint.Y));
        }

        public void ReNew(Rib CurRib)
        {
            DirectingVector = new PointF(DirectingVector.X - 2 * (DirectingVector.X * CurRib.Normal.X + DirectingVector.Y * CurRib.Normal.Y) * CurRib.Normal.X,
                                         DirectingVector.Y - 2 * (DirectingVector.X * CurRib.Normal.X + DirectingVector.Y * CurRib.Normal.Y) * CurRib.Normal.Y);
            FirstPoint = CurPoint;
            CurT = 0;
            Power *= 1 - CurRib.Coef;
        }
    }
}
