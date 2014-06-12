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
        public Bitmap pic1; // Копия комнаты с заливкой и без лучей
        public Bitmap room; // Пустая комната
        public Bitmap Graph_bmp;
        public double Perimetr = 0;
        public double Area = 0;
        public double Alpha = 0;
        public double RT;
   
        public void AddSource(string Text1 = "",string Text2 ="")
        {
            DelSource.Enabled = true;
            int SourceCount = sourceBox.Controls.OfType<Label>().Sum(label => 1) - 2;
            Label tempLabel = (sourceBox.Controls["SourceNum" + SourceCount.ToString()] as Label);
            Label NewLabel = new Label();
            NewLabel.Name = "SourceNum" + (SourceCount + 1).ToString();
            NewLabel.Size = tempLabel.Size;
            NewLabel.Top = tempLabel.Top + 24;
            NewLabel.Left = tempLabel.Left;
            NewLabel.Text = (SourceCount + 1).ToString();
            sourceBox.Controls.Add(NewLabel);
            TextBox tempX = (sourceBox.Controls["FirstPointX" + SourceCount.ToString()] as TextBox);
            TextBox tempY = (sourceBox.Controls["FirstPointY" + SourceCount.ToString()] as TextBox);
            TextBox NewX = new TextBox();
            TextBox NewY = new TextBox();
            NewX.Name = "FirstPointX" + (SourceCount + 1).ToString();
            NewY.Name = "FirstPointY" + (SourceCount + 1).ToString();
            NewX.Size = tempX.Size;
            NewY.Size = tempY.Size;
            NewX.Top = tempX.Top + 24;
            NewY.Top = tempY.Top + 24;
            NewX.Left = tempX.Left;
            NewY.Left = tempY.Left;
            if (Text1 == "") NewX.Text = tempX.Text;
            else NewX.Text = Text1;
            if (Text2 == "") NewY.Text = tempY.Text;
            else NewY.Text = Text2;
            sourceBox.Controls.Add(NewX);
            sourceBox.Controls.Add(NewY);
        }

        // Загрузить информацию
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Items.AddRange(File.ReadAllLines(comboBox1.SelectedItem.ToString() + ".points"));
            listBox2.Items.AddRange(File.ReadAllLines(comboBox2.SelectedItem.ToString() + ".ribs"));
            button3.Enabled = true;
            toolStripStatusLabel1.Text = "Комната загружена";
        }
        // Расчёты
        private void button3_Click(object sender, EventArgs e)
        {
            maxX = Convert.ToInt32(XRange.Text);
            maxY = Convert.ToInt32(YRange.Text);
            pic = new Bitmap(maxX, maxY);
            pic1 = new Bitmap(maxX, maxY);
            Graphics.FromImage(pic).Clear(Color.White);
            Graphics.FromImage(pic1).Clear(Color.White);
            col.Clear();
            AllRibs.Clear();

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
                if((FPNum>=listBox1.Items.Count)||SPNum>=listBox1.Items.Count)
                {
                    MessageBox.Show("Неверный формат введенных данных. Пожалуйста, проверьте исходные файлы комнаты.");
                    return;
                }
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
                //AllRibs[i].DrawRib(Graphics.FromImage(pic1));
                for (int t = 0; t <= (int)AllRibs[i].Length; t++)
                {
                    double x = AllRibs[i].FirstPoint.X + t * AllRibs[i].DirectingVector.X;
                    double y = AllRibs[i].FirstPoint.Y + t * AllRibs[i].DirectingVector.Y;
                    if (col[(int)x / XGR][(int)y / YGR].Contains(i) == false) col[(int)x / XGR][(int)y / YGR].Add(i); // Добавляем если надо информацию об отрезке
                }
            }
            pic1 = new Bitmap(pic);
            room = new Bitmap(pic);
            Perimetr = AllRibs.GetPerimetr();
            Area = AllRibs.GetArea();
            // Делаем доступными кнопки
            button5.Enabled = true;
            button7.Enabled = true;
            setPoints.Enabled = true;
            toolStripStatusLabel1.Text = "Расчёты произведены";
        }
        //Запуск лучей
        private void button5_Click(object sender, EventArgs e)
        {
            Head = new Listener(new Point2D(Convert.ToInt32(headX.Text), Convert.ToInt32(headY.Text)), Convert.ToInt32(headRad.Text));
            //Rays AllRays = new Rays(new Point2DD(int.Parse(FirstPointX1.Text), int.Parse(FirstPointY1.Text)), int.Parse(RayCount.Text));

            List<Rays> AllSources = new List<Rays>();
            int SourceCount = sourceBox.Controls.OfType<Label>().Sum(label => 1) - 2;
            for (int j = 1; j <= SourceCount; ++j) 
                AllSources.Add(
                    new Rays(
                        new Point2DD(int.Parse((sourceBox.Controls["FirstPointX"+j.ToString()] as TextBox).Text), 
                                     int.Parse((sourceBox.Controls["FirstPointY"+j.ToString()] as TextBox).Text)), 
                        int.Parse(RayCount.Text)));

            //Head.DrawHead(Graphics.FromImage(pic));
            double epsilon = Convert.ToDouble(Eps.Text);
            int numR;//, numR1=-1, numR2=-1;
            List<Point2DD> Results = new List<Point2DD>();
            List<double> Norms = new List<double>();
            List<int> Rnums = new List<int>();
            List<int> DelRNums = new List<int>();
           // Rib Bisector = new Rib();
            foreach (Rays AllRays in AllSources)
            {
                int i = 0;
            qwerty:
                //foreach (Ray ray in AllRays.List)
                while (i < AllRays.Count)
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
                            numR = Rnums[Norms.IndexOf(Norms.Min())];
                            ray.ReNew(AllRibs[numR]); // Отражаем луч
                        }
                        else ray.DrawRay(Graphics.FromImage(pic), Pens.Red);
                    }
                    i++;
                }
                Graphics.FromImage(pic).DrawEllipse(new Pen(Color.Green, 5), int.Parse(FirstPointX1.Text) - 1, int.Parse(FirstPointY1.Text) - 1, 2, 2);
            }
            Head.DrawHead(Graphics.FromImage(pic));
            
            toolStripStatusLabel1.Text = "Лучи пущены";

            // Построение графика

            Graph_bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(Graph_bmp);
            g.Clear(Color.White);
            Graph graph = new Graph(new Size(Graph_bmp.Width, Graph_bmp.Height));

            Point2DD[] points = Head.GetPoints(); // Получаем отсортированный массив
            graph.DrawGraph(g, points);
            Point2DD coefs = new Point2DD(MNK.GetLine(points)); // Метод наименьших квадратов
            double minY = points.Min(point => point.Y);
            RT = (minY * 6.0 / 7.0 - coefs.Y) / coefs.X;
            // RT = (minY - coefs.Y) / coefs.X * 6 / 7;
            Area = AllRibs.GetArea(); //Площадь комнаты
            Perimetr = AllRibs.GetPerimetr(); // Периметр
            Alpha = AllRibs.GetAlpha(); // Среднее арифметическое по всем коэфициентам звукопоглощения
            graph.DrawLine(g, coefs);
            g.Dispose();

            show_graph.Enabled = true;
            ShowT.Enabled = true;
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
            var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            foreach (FileInfo file in dir.GetFiles("*.points")) // извлекаем все файлы и кидаем их в список
            {
                comboBox1.Items.Add(Path.GetFileNameWithoutExtension(file.FullName)); // получаем полный путь к файлу и потом вычищаем ненужное, оставляем только имя файла.
            }
            comboBox1.SelectedIndex = 0;
            dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            foreach (FileInfo file in dir.GetFiles("*.ribs")) // извлекаем все файлы и кидаем их в список
            {
                comboBox2.Items.Add(Path.GetFileNameWithoutExtension(file.FullName)); // получаем полный путь к файлу и потом вычищаем ненужное, оставляем только имя файла.
            }
            comboBox2.SelectedIndex = 0;
            comboBox1_SelectionChangeCommitted(sender, e);
            XRange.Text = Screen.PrimaryScreen.Bounds.Width.ToString();
            YRange.Text = Screen.PrimaryScreen.Bounds.Height.ToString();
        }
        // Сброс
        private void btnAbort_Click(object sender, EventArgs e)
        {
            show_graph.Enabled = false;
            ShowT.Enabled = false;
            setPoints.Enabled = false;
            //listBox1.Items.Clear();
            //listBox2.Items.Clear();
            //BumpLog.Items.Clear();
            col.Clear();
            AllRibs.Clear();
        }
        // Вывод графика
        private void show_graph_Click(object sender, EventArgs e)
        {
            
            FormGraph f2 = new FormGraph();
            f2.Owner = this;
            f2.ShowDialog();
        }

        private void ShowT_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Инженерное RТ=" + (-0.128 * Area/ (Perimetr * Math.Log(1 - Alpha))).ToString() + "\n Программное RТ=" + RT.ToString());
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Items.AddRange(File.ReadAllLines(comboBox1.SelectedItem.ToString() + ".points"));
            listBox2.Items.AddRange(File.ReadAllLines(comboBox2.SelectedItem.ToString() + ".ribs"));
            button3.Enabled = true;
            toolStripStatusLabel1.Text = "Комната загружена";
        }

        private void Eps_TextChanged(object sender, EventArgs e)
        {

        }

        private void EpsLabel_Click(object sender, EventArgs e)
        {

        }

        private void setPoints_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Owner = this;
            f2.ShowDialog();
        }

        private void FirstPointY_TextChanged(object sender, EventArgs e)
        {

        }

        private void headY_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Area.ToString());
            
        }

        private void AddSource_Click(object sender, EventArgs e)
        {
            AddSource();
        }

        private void DelSource_Click(object sender, EventArgs e)
        {
            int SourceCount = sourceBox.Controls.OfType<Label>().Sum(label => 1) - 2;
            sourceBox.Controls.RemoveByKey("SourceNum" + SourceCount.ToString());
            sourceBox.Controls.RemoveByKey("FirstPointX" + SourceCount.ToString());
            sourceBox.Controls.RemoveByKey("FirstPointY" + SourceCount.ToString());
            if (SourceCount == 2) DelSource.Enabled = false;
        }
    }
}
