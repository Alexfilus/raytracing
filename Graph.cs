using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace raytraicing
{
    class Graph
    {
        private Size size;
        private double maxX, maxY, minX, minY;

        public Graph(Size size, double maxX = 2, double maxY = 2, double minX = -2, double minY = -2)
        {
            this.size = size;
            this.maxX = maxX;
            this.maxY = maxY;
            this.minX = minX;
            this.minY = minY;
        }

        private int transX(double x)
        {
            return (int)((x - minX) / (maxX - minX) * size.Width);
        }

        private int transY(double y)
        {
            return (int)((maxY - y) / (maxY - minY) * size.Height);
        }

        public void DrawGraph(Graphics G, double[] axis1, double[] axis2)
        {
            // Сортировка выбором
            for (int i = 0; i < axis1.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < axis1.Length; j++)
                {
                    if (axis1[j] < axis1[min])
                    {
                        min = j;
                    }
                }
                double temp = axis1[i];
                axis1[i] = axis1[min];
                axis1[min] = temp;
                temp = axis2[i];
                axis2[i] = axis2[min];
                axis2[min] = temp;
            }
            minX = axis1[0];
            maxX = axis1[axis1.Length - 1];
            minY = axis2.Min();
            maxY = axis2.Max();
            /*MessageBox.Show(minX.ToString() + "  " + maxX.ToString() + "  " + minY.ToString() + "  " + maxY.ToString());*/

            for (int i = 0; i < axis1.Length - 1; i++)
            {
                G.DrawLine(Pens.Black, transX(axis1[i]), transY(axis2[i]), transX(axis1[i + 1]), transY(axis2[i + 1]));
            }
        }
        public void DrawGraph(Graphics G, Point2DD[] points)
        {
            minX = points[0].X;
            maxX = points[points.Length - 1].X;
            minY = points.Min(point => point.Y);
            maxY = points.Max(point => point.Y);
            for (int i = 0; i < points.Length - 1; i++)
            {
                G.DrawLine(Pens.Black, transX(points[i].X), transY(points[i].Y), transX(points[i + 1].X), transY(points[i + 1].Y));
            }
        }
        public void DrawLine(Graphics G, Point2DD coefs)
        {
            G.DrawLine(Pens.Red, transX(minX), transY(coefs.X * minX + coefs.Y), transX(maxX), transY(coefs.X * maxX + coefs.Y));
        }
    }
}
