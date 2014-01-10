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
        public double Way;

        public Ray(Point _FirstPoint, PointF _DirectingVector, double _Power = 1.0)
        {
            FirstPoint = _FirstPoint;
            DirectingVector = new PointF(_DirectingVector.X/GetLength(_DirectingVector),_DirectingVector.Y/GetLength(_DirectingVector));
            Power = _Power;
            CurPoint = _FirstPoint;
            CurT = 0;
            Way = 0;
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
            Way += (float)Useful.vect_length(CurPoint, FirstPoint);
            DirectingVector = new PointF(DirectingVector.X - 2 * (DirectingVector.X * CurRib.Normal.X + DirectingVector.Y * CurRib.Normal.Y) * CurRib.Normal.X,
                                         DirectingVector.Y - 2 * (DirectingVector.X * CurRib.Normal.X + DirectingVector.Y * CurRib.Normal.Y) * CurRib.Normal.Y);
            FirstPoint = CurPoint;
            CurT = 0;
            Power *= 1 - CurRib.Coef;
        }
    }
    class Rays
    {
        public int Count;
        public List<Ray> List;
        

        public Rays(Point _Position, int _Count)
        {
            Count = _Count;
            List = new List<Ray>(Count);
            for (int i = 0; i < Count; ++i)
                Add(_Position, new PointF((float)Math.Cos(2 * Math.PI * i / Count), (float)Math.Sin(2 * Math.PI * i / Count)));
        }

        public void Add(Point _FirstPoint, PointF _DirectingVector, double _Power = 1.0)
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
