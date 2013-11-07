﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            Form4 f4 = new Form4();
            f4.Owner = this;
            InitializeComponent();
        }

        //public Form4 f4;

        public int GridXCount; // Количество ячеек по X
        public int GridYCount; // Количество ячеек по Y
        public int XGR; // Размер ячейки по X
        public int YGR; // Размер ячейки по Y
        public int maxX; // Наибольший X
        public int maxY; // Наибольший Y
        public int RayCount; // Количество лучей
        List<Point> Points = new List<Point>(); // Список точек
        List<Point> Ribs = new List<Point>(); // Список рёбер
        List<double> Coefs = new List<double>(); // Список коэфициентов звукопоглощения
        List<List<List<int>>> col = new List<List<List<int>>>(); // Списки рёбер в каждом сегменте
        List<List<List<int>>> ray = new List<List<List<int>>>(); // Списки лучей в каждом сегменте
        Point3D pos = new Point3D(1, 1, 1);
        public Bitmap pic; // Картинка
        //public PictureBox pic;
        
        public float norma(Point Vect)
        {
            return (float)Math.Sqrt((Vect.X * Vect.X) + (Vect.Y * Vect.Y));
        }
        public float norma(PointF Vect)
        {
            return (float)Math.Sqrt((Vect.X * Vect.X) + (Vect.Y * Vect.Y));
        }

        //Проверка не являются ли луч и отрезок параллельными
        public bool Parallel(int num, PointF UVect)
        {
            // Формируем направляющий, единичный вектор ребра
            PointF RUVect = new PointF();
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
            }
            return ((RUVect.Y * UVect.X - RUVect.X * UVect.Y) == 0);
        }

        //Нормаль к ребру
        public PointF RibNormal(int numR)
        {
            PointF NormalR = new PointF();
            if (((Points[Ribs[numR].Y].X - Points[Ribs[numR].X].X) != 0) && (Points[Ribs[numR].Y].Y - Points[Ribs[numR].X].Y) != 0) // Общий случай
            {
                NormalR.X = (float)1 / (Points[Ribs[numR].Y].X - Points[Ribs[numR].X].X);
                NormalR.Y = (float)1 / (Points[Ribs[numR].Y].Y - Points[Ribs[numR].X].Y);
                float temp = norma(NormalR);
                NormalR.X = NormalR.X / temp;
                NormalR.Y = -NormalR.Y / temp;
            }
            else if (Points[Ribs[numR].Y].X == Points[Ribs[numR].X].X) // Вертикальный отрезок
            {
                NormalR.X = 1;
                NormalR.Y = 0;
            }
            else // Горизонтальный отрезок
            {
                NormalR.X = 0;
                NormalR.Y = 1;
            }
            return NormalR;
        }

        public int GetCrossPoint2(int num, PointF UVect, Point FP)
        {
            PointF RUVect = new PointF();
            Point RFP = Points[Ribs[num].X];
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
            }
            // t для отрезка
            //return (int)((UVect.X * (FP.Y - RFP.Y) - UVect.Y * (FP.X - RFP.X)) / (RUVect.Y * UVect.X - RUVect.X * UVect.Y));
            // t для луча
            return (int)((RUVect.X * (FP.Y - RFP.Y) - RUVect.Y * (FP.X - RFP.X)) / (RUVect.Y * UVect.X - RUVect.X * UVect.Y));
        }

        public void GetCrossPoint(int num, PointF UVect, Point FP, ref Point Res, ref int tau)
        {
            PointF RUVect = new PointF();
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
            }

            int t = (int)((UVect.X * (FP.Y - RFP.Y) - UVect.Y * (FP.X - RFP.X)) / (RUVect.Y * UVect.X - RUVect.X * UVect.Y));
            tau = (int)((RUVect.X * (FP.Y - RFP.Y) - RUVect.Y * (FP.X - RFP.X)) / (RUVect.Y * UVect.X - RUVect.X * UVect.Y));
            Res = new Point(RFP.X + (int)(t * RUVect.X), RFP.Y + (int)(t * RUVect.Y));
        }

        public void NextCell(ref int t, ref int x, ref int y, PointF UVect, Point FirstPoint)
        {
            int curX = x / XGR;
            int curY = y / YGR;
            if (ray[curX][curY].Count < RayCount) ray[curX][curY].Add(RayCount); // Записываем если нужно информацию о луче
            do
            {
                t++;
                x = FirstPoint.X + (int)(t * UVect.X);
                y = FirstPoint.Y + (int)(t * UVect.Y);
                if ((x < 0) || (x >= maxX) || (y < 0) || (y >= maxY)) return; // Выход за границы
            } while ((x / XGR == curX) && (y / YGR == curY));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Form2 = new Form2();
            Form2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(File.ReadAllLines(@"points.dat"));
            listBox2.Items.AddRange(File.ReadAllLines(@"ribs.dat"));
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RayCount = 0;
            ray.Clear();
            col.Clear();
            Ribs.Clear();
            Points.Clear();
            XGR = Convert.ToInt32(XGridRange.Text);
            YGR = Convert.ToInt32(YGridRange.Text);
            maxX = Convert.ToInt32(XRange.Text);
            maxY = Convert.ToInt32(YRange.Text);
            pic = new Bitmap(maxX, maxY);
            Graphics g = Graphics.FromImage(pic);
            g.FillRectangle(Brushes.White, 0, 0, pic.Width, pic.Height);
            g.Dispose();
            GridXCount = maxX / XGR;
            GridYCount = maxY / YGR;

            // Список точек
            
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                int IndexOfSpace = listBox1.Items[i].ToString().IndexOf(' ');
                Points.Add(new Point(Convert.ToInt32(listBox1.Items[i].ToString().Substring(0,IndexOfSpace)),
                    Convert.ToInt32(listBox1.Items[i].ToString().Substring(IndexOfSpace+1))));
            }
            
            // Список рёбер

            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                int IndexOfSpace1 = listBox2.Items[i].ToString().IndexOf(' ');
                int IndexOfSpace2 = listBox2.Items[i].ToString().LastIndexOf(' ');
                Ribs.Add(new Point(Convert.ToInt32(listBox2.Items[i].ToString().Substring(0, IndexOfSpace1)),
                    Convert.ToInt32(listBox2.Items[i].ToString().Substring(IndexOfSpace1 + 1,IndexOfSpace2-IndexOfSpace1))));
                Coefs.Add(Convert.ToDouble(listBox2.Items[i].ToString().Substring(IndexOfSpace2+1)));
            }
            
            // Подготовка матрицы

            for (int i = 0; i <= GridXCount; i++)
            {
                col.Add(new List<List<int>>());
                for (int j = 0; j <= GridYCount; j++)
                {
                    col[i].Add(new List<int>());
                }
            }
            
            // Заполнение матрицы

            for (int i = 0; i < Ribs.Count; i++)
            {
                Point FirstPoint = Points[Ribs[i].X];
                // Формируем направляющий, единичный вектор ребра
                Point Vect = new Point(Points[Ribs[i].Y].X - Points[Ribs[i].X].X, Points[Ribs[i].Y].Y - Points[Ribs[i].X].Y);
                float CurNorm = norma(Vect);
                PointF UVect = new PointF(Vect.X / CurNorm, Vect.Y / CurNorm);
                Graphics gr = Graphics.FromImage(pic);
                gr.DrawLine(new Pen(Color.Black), Points[Ribs[i].X], Points[Ribs[i].Y]);
                gr.Dispose();
                for (int t = 0; t <= (int)CurNorm; t++)
                {
                    int x = FirstPoint.X + (int)(t * UVect.X);
                    int y = FirstPoint.Y + (int)(t * UVect.Y);
                    if (col[x / XGR][y / YGR].Contains(i) == false) col[x / XGR][y / YGR].Add(i); // Добавляем если надо информацию об отрезке
                }
            }

            // Делаем доступными кнопки
            button4.Enabled = true;
            button5.Enabled = true;
            button7.Enabled = true;

            // Подготовка матрицы для луча

            ray.Clear();
            for (int k = 0; k <= GridXCount; k++)
            {
                ray.Add(new List<List<int>>(GridYCount));
                for (int j = 0; j <= GridYCount; j++)
                    ray[k].Add(new List<int>());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Owner = this;
            f.Show();
            for (int i = 0; i < GridXCount; i++)
            {
                (Application.OpenForms["Form3"].Controls["dataGridView1"] as DataGridView).Columns.Add(i.ToString(), i.ToString());
                (Application.OpenForms["Form3"].Controls["dataGridView1"] as DataGridView).Columns[i].Width = 50;
            }
            (Application.OpenForms["Form3"].Controls["dataGridView1"] as DataGridView).Rows.Add(GridYCount);
            for (int i = 0; i < GridYCount; i++)
                (Application.OpenForms["Form3"].Controls["dataGridView1"] as DataGridView).Rows[i].HeaderCell.Value = i.ToString();

            /* Номера рёбер */
            for (int i = 0; i < GridXCount; i++)
            {
                for (int j = 0; j < GridYCount; j++)
                {
                    if (col[i][j].Count > 0)
                    {
                        string temp = "";
                        for (int k = 0; k < col[i][j].Count; k++)
                            temp += col[i][j][k].ToString()+"; ";
                        (Application.OpenForms["Form3"].Controls["dataGridView1"] as DataGridView)[i, j].Value = temp.Substring(0,temp.Length-2);
                    }
                    if (ray[i][j].Count > 0)
                    {
                        if (ray[i][j].Max() == RayCount)
                                (Application.OpenForms["Form3"].Controls["dataGridView1"] as DataGridView)[i, j].Style.BackColor = Color.Cyan;
                        else (Application.OpenForms["Form3"].Controls["dataGridView1"] as DataGridView)[i, j].Style.BackColor = Color.Gray;
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RayCount++; 
            BumpLog.Items.Clear();
            Graphics gr;
            int X1 = Convert.ToInt32(FirstPointX.Text);
            int X2 = Convert.ToInt32(SecondPointX.Text);
            int Y1 = Convert.ToInt32(FirstPointY.Text);
            int Y2 = Convert.ToInt32(SecondPointY.Text);
            int bcount = Convert.ToInt32(BumpCount.Text);
            Point FirstPoint = new Point(X1, Y1);

            // Формируем направляющий, единичный вектор луча
            Point Vect = new Point(X2 - X1, Y2 - Y1);
            PointF UVect = new PointF(Vect.X / norma(Vect), Vect.Y / norma(Vect));
            int numR = -1;

            int t = 0;
            int temp_t = 0;
            int x = FirstPoint.X;
            int y = FirstPoint.Y;
            double epsilon = Convert.ToDouble(Eps.Text);
            
            //for (int i = 0; i != bcount; ) // В цикле двигаемся до нужного количества столкновений либо выхода за границы
            for (double power = 1.0; power > epsilon;)
            {
                PointF NormalR = new PointF();
                Point Res = new Point();

                // Ищем не пустую клетку

                while (col[x / XGR][y / YGR].Count.Equals(0))
                {
                    NextCell(ref t, ref x, ref y, UVect, FirstPoint);
                    if ((x < 0) || (x >= maxX) || (y < 0) || (y >= maxY))
                    {
                        gr = Graphics.FromImage(pic);
                        gr.DrawLine(new Pen(Color.Aquamarine), FirstPoint, new Point(x,y));
                        gr.Dispose();
                        MessageBox.Show("Ошибка! Выход за границы области!");
                        return;
                    }
                }

                List<Point> Results = new List<Point>();
                List<float> Norms = new List<float>();
                List<int> Rnums = new List<int>(col[x / XGR][y / YGR]); // Список рёбер этого сегмента копируем, он известен заранее

                // Собираем информацию о точках пересечения
                for (int j = 0; j < col[x / XGR][y / YGR].Count; j++)
                {
                    int num = col[x / XGR][y / YGR][j];
                    GetCrossPoint(num, UVect, FirstPoint, ref Res, ref temp_t);
                    Results.Add(Res); 
                    Norms.Add(norma(new Point(Res.X - x, Res.Y - y)));
                }
                
                // Выясняем какие точки лишние
                List<int> DelRNums = new List<int>();

                for (int j = 0; j < col[x / XGR][y / YGR].Count; j++)
                {
                    int num = col[x / XGR][y / YGR][j];
                    if (Parallel(num, UVect))                                                   // Отрезок параллелен лучу
                    {
                        DelRNums.Add(num);
                        continue;
                    }
                    temp_t = GetCrossPoint2(num, UVect, FirstPoint);
                    if (temp_t < 0)                                                             // Мы остались в той же точке, либо отрезок находится раньше начала луча
                    {
                        DelRNums.Add(num);
                        continue;
                    }
                    GetCrossPoint(num, UVect, FirstPoint, ref Res, ref temp_t);
                    if ((Res.X > Math.Max(Points[Ribs[num].Y].X, Points[Ribs[num].X].X)) ||       // Проверяем принадлежит ли точка пересечения отрезку
                        (Res.X < Math.Min(Points[Ribs[num].Y].X, Points[Ribs[num].X].X)) ||
                        (Res.Y > Math.Max(Points[Ribs[num].Y].Y, Points[Ribs[num].X].Y)) ||
                        (Res.Y < Math.Min(Points[Ribs[num].Y].Y, Points[Ribs[num].X].Y)))
                    {
                        DelRNums.Add(num);
                        continue;
                    }
                    if ((Res.X / XGR != x / XGR) && (Res.Y / YGR != y / YGR))                   // Проверяем принадлежит ли точка пересечения клетке
                    {
                        DelRNums.Add(num);
                        continue;
                    }
                }
                // Удаляем лишние точки. Двигаемся с конца
                while (DelRNums.Count != 0)
                {
                    Results.RemoveAt(Rnums.IndexOf(DelRNums[DelRNums.Count - 1]));
                    Norms.RemoveAt(Rnums.IndexOf(DelRNums[DelRNums.Count - 1]));
                    Rnums.RemoveAt(Rnums.IndexOf(DelRNums[DelRNums.Count - 1]));
                    DelRNums.RemoveAt(DelRNums.Count - 1);
                }
                // Удалим то ребро от которого уже только что отражались
                if (Rnums.Contains(numR))
                {
                    Results.RemoveAt(Rnums.IndexOf(numR));
                    Norms.RemoveAt(Rnums.IndexOf(numR));
                    Rnums.Remove(numR);
                }
                // Проверям остались ли рёбра в списке
                if (Rnums.Count.Equals(0))  
                {
                    NextCell(ref t, ref x, ref y, UVect, FirstPoint);
                    continue;
                }
                
                // Столкновение всё-таки произошло
                
                gr = Graphics.FromImage(pic);
                gr.DrawLine(new Pen(Color.Aquamarine), FirstPoint, Results[Norms.IndexOf(Norms.Min())]);
                gr.Dispose();

                numR = Rnums[Norms.IndexOf(Norms.Min())];
                NormalR = RibNormal(numR);
                UVect = new PointF(UVect.X - 2 * (UVect.X * NormalR.X + UVect.Y * NormalR.Y) * NormalR.X, UVect.Y - 2 * (UVect.X * NormalR.X + UVect.Y * NormalR.Y) * NormalR.Y);
                FirstPoint = Results[Norms.IndexOf(Norms.Min())];
                t = 0;
                x = FirstPoint.X;
                y = FirstPoint.Y;
                power *= (1 - Coefs[Norms.IndexOf(Norms.Min())]);
                BumpLog.Items.Add(@"Было столкновение в точке: (" + FirstPoint.X.ToString() + ";" + FirstPoint.Y.ToString() + ") Сила луча: " + power.ToString());
                //BumpLog.Items.Add(@i.ToString() + " (" + x.ToString() + ";" + y.ToString() + ")" + " (" + UVect.X.ToString() + ";" + UVect.Y.ToString() + ")");
                //i++;
                

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            XRange.Text = Screen.PrimaryScreen.Bounds.Width.ToString();
            YRange.Text = Screen.PrimaryScreen.Bounds.Height.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Owner = this;
            f4.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToDouble("0,1").ToString());
        }
    }
}