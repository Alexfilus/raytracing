using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace raytraicing
{
    public class Point3D
    {
        public int X, Y, Z;
        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
    public class Point3DF
    {
        public float X;
        public float Y;
        public float Z;
        public Point3DF(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
