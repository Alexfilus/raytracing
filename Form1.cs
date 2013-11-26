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

        public int GridXCount; // Количество ячеек по X
        public int GridYCount; // Количество ячеек по Y
        public int XGR; // Размер ячейки по X
        public int YGR; // Размер ячейки по Y
        public int maxX; // Наибольший X
        public int maxY; // Наибольший Y
        public int RayCount; // Количество лучей
        Ribs AllRibs = new Ribs(); // Список структур со всей информацией о рёбрах
        List<List<List<int>>> col = new List<List<List<int>>>(); // Списки рёбер в каждом сегменте
        public Bitmap pic; // Картинка

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
            col.Clear();
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
            
            // Заполнение структуры
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                int IndexOfSpace1 = listBox2.Items[i].ToString().IndexOf(' ');
                int IndexOfSpace2 = listBox2.Items[i].ToString().LastIndexOf(' ');
                int FPNum = Convert.ToInt32(listBox2.Items[i].ToString().Substring(0, IndexOfSpace1));
                int SPNum = Convert.ToInt32(listBox2.Items[i].ToString().Substring(IndexOfSpace1 + 1, IndexOfSpace2 - IndexOfSpace1));
                int IndexOfSpaceFP = listBox1.Items[FPNum].ToString().IndexOf(' ');
                int IndexOfSpaceSP = listBox1.Items[SPNum].ToString().IndexOf(' ');
                Point FP = new Point(Convert.ToInt32(listBox1.Items[FPNum].ToString().Substring(0, IndexOfSpaceFP)),
                                     Convert.ToInt32(listBox1.Items[FPNum].ToString().Substring(IndexOfSpaceFP + 1)));
                Point SP = new Point(Convert.ToInt32(listBox1.Items[SPNum].ToString().Substring(0, IndexOfSpaceSP)),
                                     Convert.ToInt32(listBox1.Items[SPNum].ToString().Substring(IndexOfSpaceSP + 1)));

                AllRibs.Add(FP, SP, Convert.ToDouble(listBox2.Items[i].ToString().Substring(IndexOfSpace2 + 1)));
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

            for (int i = 0; i < AllRibs.GetCount(); i++)
            {
                AllRibs[i].DrawRib(Graphics.FromImage(pic));
                for (int t = 0; t <= (int)AllRibs[i].Length; t++)
                {
                    int x = AllRibs[i].FirstPoint.X + (int)(t * AllRibs[i].DirectingVector.X);
                    int y = AllRibs[i].FirstPoint.Y + (int)(t * AllRibs[i].DirectingVector.Y);
                    if (col[x / XGR][y / YGR].Contains(i) == false) col[x / XGR][y / YGR].Add(i); // Добавляем если надо информацию об отрезке
                }
            }

            // Делаем доступными кнопки
            button5.Enabled = true;
            button7.Enabled = true;
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
            Ray ray = new Ray(new Point(X1, Y1), new PointF(X2 - X1, Y2 - Y1));
            int numR = -1;

            int temp_t = 0;
            double epsilon = Convert.ToDouble(Eps.Text);
            
            while (ray.Power > epsilon)// Луч отражается пока его мощность не станет меньше epsilon
            {
                Point Res = new Point();

                // Ищем не пустую клетку

                while (col[ray.CurPoint.X / XGR][ray.CurPoint.Y / YGR].Count.Equals(0))
                {
                    ray.NextCell(XGR, YGR);
                    if ((ray.CurPoint.X < 0) || (ray.CurPoint.X >= maxX) || (ray.CurPoint.Y < 0) || (ray.CurPoint.Y >= maxY))
                    {
                        ray.DrawRay(Graphics.FromImage(pic));
                        MessageBox.Show("Ошибка! Выход за границы области!");
                        return;
                    }
                }

                List<Point> Results = new List<Point>();
                List<float> Norms = new List<float>();
                List<int> Rnums = new List<int>(col[ray.CurPoint.X / XGR][ray.CurPoint.Y / YGR]); // Список рёбер этого сегмента копируем, он известен заранее

                // Собираем информацию о точках пересечения
                for (int j = 0; j < col[ray.CurPoint.X / XGR][ray.CurPoint.Y / YGR].Count; j++)
                {
                    int num = col[ray.CurPoint.X / XGR][ray.CurPoint.Y / YGR][j];
                    Res = AllRibs[num].GetCrossPointXY(ray);
                    Results.Add(Res);
                    Norms.Add(ray.GetDistance(Res));
                }

                // Выясняем какие точки лишние
                List<int> DelRNums = new List<int>();

                for (int j = 0; j < col[ray.CurPoint.X / XGR][ray.CurPoint.Y / YGR].Count; j++)
                {
                    int num = col[ray.CurPoint.X / XGR][ray.CurPoint.Y / YGR][j];
                    // Отрезок параллелен лучу
                    if (AllRibs[num].IsParallel(ray))                                           
                    {
                        DelRNums.Add(num);
                        continue;
                    }
                    temp_t = AllRibs[num].GetCrossPointT(ray);
                    // Мы остались в той же точке, либо отрезок находится раньше начала луча
                    if (temp_t < 0)                                                             
                    {
                        DelRNums.Add(num);
                        continue;
                    }
                    Res = AllRibs[num].GetCrossPointXY(ray);
                    if (AllRibs[num].IsInhere(ray))//if (AllRibs[num].IsInhere(ray))
                    {
                        DelRNums.Add(num);
                        continue;
                    }
                    // Проверяем принадлежит ли точка пересечения клетке
                    if ((Res.X / XGR != ray.CurPoint.X / XGR) && (Res.Y / YGR != ray.CurPoint.X / YGR))                   
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
                    ray.NextCell(XGR, YGR);
                    continue;
                }

                // Столкновение всё-таки произошло

                gr = Graphics.FromImage(pic);
                gr.DrawLine(Pens.Aquamarine, ray.FirstPoint, Results[Norms.IndexOf(Norms.Min())]);
                gr.Dispose();

                numR = Rnums[Norms.IndexOf(Norms.Min())];
                ray.ReNew(AllRibs[numR], Results[Norms.IndexOf(Norms.Min())]);
                BumpLog.Items.Add(@"Было столкновение в точке: (" + ray.FirstPoint.X.ToString() + ";" + ray.FirstPoint.Y.ToString() + ") Сила луча: " + ray.Power.ToString());
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
