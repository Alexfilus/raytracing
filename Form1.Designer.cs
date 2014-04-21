namespace raytraicing
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.YRange = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.XRange = new System.Windows.Forms.TextBox();
            this.XGridRange = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.YGridRange = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.FirstPointY = new System.Windows.Forms.TextBox();
            this.FirstPointX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.EpsLabel = new System.Windows.Forms.Label();
            this.Eps = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.headX = new System.Windows.Forms.TextBox();
            this.headY = new System.Windows.Forms.TextBox();
            this.RadLabel = new System.Windows.Forms.Label();
            this.headRad = new System.Windows.Forms.TextBox();
            this.btnAbort = new System.Windows.Forms.Button();
            this.lRayCount = new System.Windows.Forms.Label();
            this.RayCount = new System.Windows.Forms.TextBox();
            this.show_graph = new System.Windows.Forms.Button();
            this.ShowT = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(13, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Загрузить информацию";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Y = ";
            // 
            // YRange
            // 
            this.YRange.Location = new System.Drawing.Point(43, 111);
            this.YRange.Name = "YRange";
            this.YRange.Size = new System.Drawing.Size(39, 20);
            this.YRange.TabIndex = 8;
            this.YRange.Text = "1080";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "X =";
            // 
            // XRange
            // 
            this.XRange.Location = new System.Drawing.Point(43, 88);
            this.XRange.Name = "XRange";
            this.XRange.Size = new System.Drawing.Size(39, 20);
            this.XRange.TabIndex = 6;
            this.XRange.Text = "1920";
            // 
            // XGridRange
            // 
            this.XGridRange.Location = new System.Drawing.Point(120, 132);
            this.XGridRange.Name = "XGridRange";
            this.XGridRange.Size = new System.Drawing.Size(46, 20);
            this.XGridRange.TabIndex = 10;
            this.XGridRange.Text = "40";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Размер сетки по X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Размер сетки по Y";
            // 
            // YGridRange
            // 
            this.YGridRange.Location = new System.Drawing.Point(120, 158);
            this.YGridRange.Name = "YGridRange";
            this.YGridRange.Size = new System.Drawing.Size(46, 20);
            this.YGridRange.TabIndex = 12;
            this.YGridRange.Text = "40";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(15, 193);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 27);
            this.button3.TabIndex = 14;
            this.button3.Text = "Расчёты";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(360, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Рёбра";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Вершины";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(363, 93);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(140, 329);
            this.listBox2.TabIndex = 16;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(237, 93);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 329);
            this.listBox1.TabIndex = 15;
            // 
            // FirstPointY
            // 
            this.FirstPointY.Location = new System.Drawing.Point(120, 226);
            this.FirstPointY.Name = "FirstPointY";
            this.FirstPointY.Size = new System.Drawing.Size(50, 20);
            this.FirstPointY.TabIndex = 20;
            this.FirstPointY.Text = "400";
            // 
            // FirstPointX
            // 
            this.FirstPointX.Location = new System.Drawing.Point(45, 226);
            this.FirstPointX.Name = "FirstPointX";
            this.FirstPointX.Size = new System.Drawing.Size(50, 20);
            this.FirstPointX.TabIndex = 23;
            this.FirstPointX.Text = "160";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "X1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(94, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Y1";
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(120, 193);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 27);
            this.button5.TabIndex = 31;
            this.button5.Text = "Пустить лучи";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(88, 88);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(129, 38);
            this.button6.TabIndex = 33;
            this.button6.Text = "Взять разрешение монитора";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(14, 318);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(99, 27);
            this.button7.TabIndex = 34;
            this.button7.Text = "Рисунок";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // EpsLabel
            // 
            this.EpsLabel.AutoSize = true;
            this.EpsLabel.Location = new System.Drawing.Point(9, 289);
            this.EpsLabel.Name = "EpsLabel";
            this.EpsLabel.Size = new System.Drawing.Size(41, 13);
            this.EpsLabel.TabIndex = 35;
            this.EpsLabel.Text = "Epsilon";
            this.EpsLabel.Click += new System.EventHandler(this.EpsLabel_Click);
            // 
            // Eps
            // 
            this.Eps.Location = new System.Drawing.Point(56, 289);
            this.Eps.Name = "Eps";
            this.Eps.Size = new System.Drawing.Size(57, 20);
            this.Eps.TabIndex = 36;
            this.Eps.Text = "0,0000001";
            this.Eps.TextChanged += new System.EventHandler(this.Eps_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(112, 354);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Y головы";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 354);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "X головы";
            // 
            // headX
            // 
            this.headX.Location = new System.Drawing.Point(68, 351);
            this.headX.Name = "headX";
            this.headX.Size = new System.Drawing.Size(41, 20);
            this.headX.TabIndex = 38;
            this.headX.Text = "750";
            // 
            // headY
            // 
            this.headY.Location = new System.Drawing.Point(169, 351);
            this.headY.Name = "headY";
            this.headY.Size = new System.Drawing.Size(50, 20);
            this.headY.TabIndex = 37;
            this.headY.Text = "400";
            // 
            // RadLabel
            // 
            this.RadLabel.AutoSize = true;
            this.RadLabel.Location = new System.Drawing.Point(11, 380);
            this.RadLabel.Name = "RadLabel";
            this.RadLabel.Size = new System.Drawing.Size(111, 13);
            this.RadLabel.TabIndex = 41;
            this.RadLabel.Text = "Радиус слышимости";
            // 
            // headRad
            // 
            this.headRad.Location = new System.Drawing.Point(128, 377);
            this.headRad.Name = "headRad";
            this.headRad.Size = new System.Drawing.Size(92, 20);
            this.headRad.TabIndex = 42;
            this.headRad.Text = "15";
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(115, 289);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(104, 22);
            this.btnAbort.TabIndex = 43;
            this.btnAbort.Text = "Сброс";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // lRayCount
            // 
            this.lRayCount.AutoSize = true;
            this.lRayCount.Location = new System.Drawing.Point(16, 259);
            this.lRayCount.Name = "lRayCount";
            this.lRayCount.Size = new System.Drawing.Size(97, 13);
            this.lRayCount.TabIndex = 44;
            this.lRayCount.Text = "Количество лучей";
            // 
            // RayCount
            // 
            this.RayCount.Location = new System.Drawing.Point(120, 256);
            this.RayCount.Name = "RayCount";
            this.RayCount.Size = new System.Drawing.Size(50, 20);
            this.RayCount.TabIndex = 45;
            this.RayCount.Text = "10000";
            // 
            // show_graph
            // 
            this.show_graph.Location = new System.Drawing.Point(120, 317);
            this.show_graph.Name = "show_graph";
            this.show_graph.Size = new System.Drawing.Size(99, 28);
            this.show_graph.TabIndex = 46;
            this.show_graph.Text = "График";
            this.show_graph.UseVisualStyleBackColor = true;
            this.show_graph.Click += new System.EventHandler(this.show_graph_Click);
            // 
            // ShowT
            // 
            this.ShowT.Location = new System.Drawing.Point(12, 396);
            this.ShowT.Name = "ShowT";
            this.ShowT.Size = new System.Drawing.Size(75, 23);
            this.ShowT.TabIndex = 47;
            this.ShowT.Text = "RT";
            this.ShowT.UseVisualStyleBackColor = true;
            this.ShowT.Click += new System.EventHandler(this.ShowT_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(205, 21);
            this.comboBox1.TabIndex = 48;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Выберите комнату";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 493);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(511, 22);
            this.statusStrip1.TabIndex = 50;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(107, 17);
            this.toolStripStatusLabel1.Text = "Комната загружена";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(234, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(151, 13);
            this.label10.TabIndex = 52;
            this.label10.Text = "Выберите набор мощностей";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(235, 32);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(205, 21);
            this.comboBox2.TabIndex = 51;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 515);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ShowT);
            this.Controls.Add(this.show_graph);
            this.Controls.Add(this.RayCount);
            this.Controls.Add(this.lRayCount);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.headRad);
            this.Controls.Add(this.RadLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.headX);
            this.Controls.Add(this.headY);
            this.Controls.Add(this.Eps);
            this.Controls.Add(this.EpsLabel);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.FirstPointX);
            this.Controls.Add(this.FirstPointY);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.YGridRange);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.XGridRange);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.YRange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.XRange);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Трассировка";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox YRange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox XRange;
        private System.Windows.Forms.TextBox XGridRange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox YGridRange;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox FirstPointY;
        private System.Windows.Forms.TextBox FirstPointX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label EpsLabel;
        private System.Windows.Forms.TextBox Eps;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox headX;
        private System.Windows.Forms.TextBox headY;
        private System.Windows.Forms.Label RadLabel;
        private System.Windows.Forms.TextBox headRad;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Label lRayCount;
        private System.Windows.Forms.TextBox RayCount;
        private System.Windows.Forms.Button show_graph;
        private System.Windows.Forms.Button ShowT;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

