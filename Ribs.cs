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
        public float Coef;
        public float Length;

        public Rib(Point _FirstPoint, Point _SecondPoint, float _Coef)
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
            return new PointF(DirectingVector.Y, -DirectingVector.X);
        }
    }

    class Ribs
    {
        //private Rib[] List;
        private List<Rib> List = new List<Rib>();

        public Ribs()
        {

        }

        public void Add(Point _FirstPoint, Point _SecondPoint, float _Coef)
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
    }
}
