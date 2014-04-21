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

        private void DrawAxis(Graphics G)
        {
            DrawLine(G, new Point2DD(), new Point2DD(maxX, 0));
            DrawLine(G, new Point2DD(), new Point2DD(0, minY));
            double step = minY / 7;
            for (int i = 1; i < 7; ++i)
            {
                G.DrawLine(Pens.Black, transX(0), transY(step * i), transX(0)+15, transY(step * i));
                G.DrawString((i * 10).ToString() + " dB", new Font("Times", 14), Brushes.Black, transX(0) + 20, transY(step * i) - 7);
            }
            for (int i = 1; i * 0.5 < maxX; ++i)
            {
                G.DrawLine(Pens.Black, transX(i * 0.5), transY(0), transX(i * 0.5), transY(0) + 10);
                G.DrawString((i * 0.5).ToString() + " c", new Font("Times", 14), Brushes.Black, transX(i * 0.5) -7, transY(0) +10);
            }
        }
        public void DrawGraph(Graphics G, Point2DD[] points)
        {
            minX = -0.02;// points[0].X;
            maxX = points[points.Length - 1].X;
            minY = points.Min(point => point.Y);
            maxY = 0.1;// points.Max(point => point.Y);
            DrawAxis(G);
            for (int i = 0; i < points.Length - 1; i++) DrawLine(G, points[i], points[i + 1]);
        }
        public void DrawLine(Graphics G, Point2DD coefs)
        {
            G.DrawLine(Pens.Red, transX(minX), transY(coefs.X * minX + coefs.Y), transX(maxX), transY(coefs.X * maxX + coefs.Y));
        }
        private void DrawLine(Graphics G, Point2DD point1, Point2DD point2)
        {
            G.DrawLine(Pens.Black, transX(point1.X), transY(point1.Y), transX(point2.X), transY(point2.Y));
        }
    }
}
