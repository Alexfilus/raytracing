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
        //public int RayCount; // Количество лучей
        Listener Head;
        Ribs AllRibs = new Ribs(); // Список структур со всей информацией о рёбрах
        List<List<List<int>>> col = new List<List<List<int>>>(); // Списки рёбер в каждом сегменте
        public Bitmap pic; // Картинка
        public Bitmap Graph_bmp;
        public double Perimetr = 0;
        public double Area = 0;
   
        // Загрузить информацию
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(File.ReadAllLines(@"points.dat"));
            listBox2.Items.AddRange(File.ReadAllLines(@"ribs.dat"));
            button3.Enabled = true;
        }
        // Расчёты
        private void button3_Click(object sender, EventArgs e)
        {
            maxX = Convert.ToInt32(XRange.Text);
            maxY = Convert.ToInt32(YRange.Text);
            pic = new Bitmap(maxX, maxY);
            Graphics.FromImage(pic).Clear(Color.White);
            col.Clear();
            AllRibs.Clear();

            Head = new Listener(new Point2D(Convert.ToInt32(headX.Text), Convert.ToInt32(headY.Text)), Convert.ToInt32(headRad.Text));
            XGR = Convert.ToInt32(XGridRange.Text);
            YGR = Convert.ToInt32(YGridRange.Text);
            
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
                Point2DD FP = new Point2DD(Convert.ToInt32(listBox1.Items[FPNum].ToString().Substring(0, IndexOfSpaceFP)),
                                     Convert.ToInt32(listBox1.Items[FPNum].ToString().Substring(IndexOfSpaceFP + 1)));
                Point2DD SP = new Point2DD(Convert.ToInt32(listBox1.Items[SPNum].ToString().Substring(0, IndexOfSpaceSP)),
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
                    double x = AllRibs[i].FirstPoint.X + t * AllRibs[i].DirectingVector.X;
                    double y = AllRibs[i].FirstPoint.Y + t * AllRibs[i].DirectingVector.Y;
                    if (col[(int)x / XGR][(int)y / YGR].Contains(i) == false) col[(int)x / XGR][(int)y / YGR].Add(i); // Добавляем если надо информацию об отрезке
                }
            }
            Perimetr = AllRibs.GetPerimetr();
            Area = AllRibs.GetArea();
            // Делаем доступными кнопки
            button5.Enabled = true;
            button7.Enabled = true;
        }
        //Запуск лучей
        private void button5_Click(object sender, EventArgs e)
        {
            BumpLog.Items.Clear();
            Rays AllRays = new Rays(new Point2DD(int.Parse(FirstPointX.Text), int.Parse(FirstPointY.Text)), int.Parse(RayCount.Text));
            
            Head.DrawHead(Graphics.FromImage(pic));
            double epsilon = Convert.ToDouble(Eps.Text);
            int numR, numR1=-1, numR2=-1;
            List<Point2DD> Results = new List<Point2DD>();
            List<double> Norms = new List<double>();
            List<int> Rnums = new List<int>();
            List<int> DelRNums = new List<int>();
            Rib Bisector = new Rib();
            int i = 0;
            qwerty:
            //foreach (Ray ray in AllRays.List)
            while(i<AllRays.Count)
            {
                Ray ray = AllRays[i];
                numR = -1;
                DelRNums.Clear();
                
                while (ray.Power > epsilon)// Луч отражается пока его мощность не станет меньше epsilon
                {
                    Point2DD Res = new Point2DD();

                    // Ищем не пустую клетку

                    while (col[(int)ray.CurPoint.X / XGR][(int)ray.CurPoint.Y / YGR].Count.Equals(0))
                    {
                        ray.NextCell(XGR, YGR, Head);
                        if ((ray.CurPoint.X < 0) || (ray.CurPoint.X >= maxX) || (ray.CurPoint.Y < 0) || (ray.CurPoint.Y >= maxY))
                        {
                            //ray.DrawRay(Graphics.FromImage(pic), Pens.Black);
                            //MessageBox.Show("Ошибка! Выход за границы области!");
                            i++;
                            goto qwerty;
                            //return;
                        }
                    }
                    Results.Clear();
                    Norms.Clear();
                    Rnums.Clear();
                    Rnums = new List<int>(col[(int)ray.CurPoint.X / XGR][(int)ray.CurPoint.Y / YGR]); // Список рёбер этого сегмента копируем, он известен заранее

                    // Собираем информацию о точках пересечения
                    for (int j = 0; j < col[(int)ray.CurPoint.X / XGR][(int)ray.CurPoint.Y / YGR].Count; j++)
                    {
                        int num = col[(int)ray.CurPoint.X / XGR][(int)ray.CurPoint.Y / YGR][j];
                        Res = AllRibs[num].GetCrossPointXY(ray);
                        Results.Add(Res);
                        //Norms.Add(ray.GetDistance(Res));
                        Norms.Add(Useful.vect_length(ray.CurPoint, Res));
                    }

                    // Выясняем какие точки лишние
                    for (int j = 0; j < col[(int)ray.CurPoint.X / XGR][(int)ray.CurPoint.Y / YGR].Count; j++)
                    {
                        int num = col[(int)ray.CurPoint.X / XGR][(int)ray.CurPoint.Y / YGR][j];
                        // Отрезок параллелен лучу
                        if (AllRibs[num].IsParallel(ray))
                        {
                            DelRNums.Add(num);
                            continue;
                        }
                        // Мы остались в той же точке, либо отрезок находится раньше начала луча
                        if (AllRibs[num].GetCrossPointT(ray) < 0)
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
                        if (((int)Res.X / XGR != (int)ray.CurPoint.X / XGR) && ((int)Res.Y / YGR != (int)ray.CurPoint.X / YGR))
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
                        ray.NextCell(XGR, YGR, Head);
                        continue;
                    }

                    // Столкновение всё-таки произошло
                    ray.CurPoint = Results[Norms.IndexOf(Norms.Min())];
                    
                    int IsInHead = Head.Check(ray); // Пересекает ли луч голову
                    if (IsInHead != 0)
                    {
                        //ray.DrawRay(Graphics.FromImage(pic), Pens.Aquamarine);
                        numR = Rnums[Norms.IndexOf(Norms.Min())];
                        ray.ReNew(AllRibs[numR]);
                        //BumpLog.Items.Add(@"Было столкновение в точке: " + ray.FirstPoint.ToString() + " Сила луча: " + ray.Power.ToString() + " " + IsInHead.ToString());
                        //DelRNums.Add(numR);
                    }
                    else ray.DrawRay(Graphics.FromImage(pic), Pens.Red);
                }
                i++;
            }
            Head.DrawHead(Graphics.FromImage(pic));
        }
        // Получить размеры экрана
        private void button6_Click(object sender, EventArgs e)
        {
            XRange.Text = Screen.PrimaryScreen.Bounds.Width.ToString();
            YRange.Text = Screen.PrimaryScreen.Bounds.Height.ToString();
        }
        // Показать форму с рисунком
        private void button7_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Owner = this;
            f4.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
        // Сброс
        private void btnAbort_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            BumpLog.Items.Clear();
            col.Clear();
            AllRibs.Clear();
        }
        // Вывод графика
        private void show_graph_Click(object sender, EventArgs e)
        {
            Graph_bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(Graph_bmp);
            g.Clear(Color.White);
            Graph graph = new Graph(new Size(Graph_bmp.Width, Graph_bmp.Height));
            //graph.DrawGraph(g, Head.GetTimes(), Head.GetLouds());
            Point2DD[] points = Head.GetPoints();
            graph.DrawGraph(g, points);

            g.Dispose();
            FormGraph f2 = new FormGraph();
            f2.Owner = this;
            f2.ShowDialog();
        }

        private void ShowT_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Инженерное Т="+(-0.128 * AllRibs.GetArea() / (AllRibs.GetPerimetr() * Math.Log(1 - AllRibs.GetAlpha()))).ToString()+"\n Вычмсленное Т="+Head.GetRT(0.4).ToString());
        }
    }
}
