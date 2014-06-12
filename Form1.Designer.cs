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
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.show_graph = new System.Windows.Forms.Button();
            this.ShowT = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.setPoints = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.XRange = new System.Windows.Forms.TextBox();
            this.YRange = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.XGridRange = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.YGridRange = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FirstPointY1 = new System.Windows.Forms.TextBox();
            this.RayCount = new System.Windows.Forms.TextBox();
            this.FirstPointX1 = new System.Windows.Forms.TextBox();
            this.lRayCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.headRad = new System.Windows.Forms.TextBox();
            this.EpsLabel = new System.Windows.Forms.Label();
            this.RadLabel = new System.Windows.Forms.Label();
            this.Eps = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.headY = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.headX = new System.Windows.Forms.TextBox();
            this.sourceBox = new System.Windows.Forms.GroupBox();
            this.SourceNum1 = new System.Windows.Forms.Label();
            this.AddSourceBtn = new System.Windows.Forms.Button();
            this.DelSource = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.sourceBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(15, 57);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 27);
            this.button3.TabIndex = 14;
            this.button3.Text = "Предварительные расчёты";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(479, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Рёбра";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(353, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Вершины";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(482, 90);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(140, 316);
            this.listBox2.TabIndex = 16;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(356, 90);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 316);
            this.listBox1.TabIndex = 15;
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(13, 347);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 27);
            this.button5.TabIndex = 31;
            this.button5.Text = "Пустить лучи";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(115, 347);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(99, 27);
            this.button7.TabIndex = 34;
            this.button7.Text = "Рисунок";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(218, 414);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(402, 26);
            this.btnAbort.TabIndex = 43;
            this.btnAbort.Text = "Очистить";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // show_graph
            // 
            this.show_graph.Enabled = false;
            this.show_graph.Location = new System.Drawing.Point(15, 380);
            this.show_graph.Name = "show_graph";
            this.show_graph.Size = new System.Drawing.Size(99, 28);
            this.show_graph.TabIndex = 46;
            this.show_graph.Text = "График";
            this.show_graph.UseVisualStyleBackColor = true;
            this.show_graph.Click += new System.EventHandler(this.show_graph_Click);
            // 
            // ShowT
            // 
            this.ShowT.Enabled = false;
            this.ShowT.Location = new System.Drawing.Point(117, 381);
            this.ShowT.Name = "ShowT";
            this.ShowT.Size = new System.Drawing.Size(97, 27);
            this.ShowT.TabIndex = 47;
            this.ShowT.Text = "RT";
            this.ShowT.UseVisualStyleBackColor = true;
            this.ShowT.Click += new System.EventHandler(this.ShowT_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(15, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(199, 21);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 443);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(632, 22);
            this.statusStrip1.TabIndex = 50;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(114, 17);
            this.toolStripStatusLabel1.Text = "Комната загружена";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(355, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(151, 13);
            this.label10.TabIndex = 52;
            this.label10.Text = "Выберите набор мощностей";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(356, 32);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(266, 21);
            this.comboBox2.TabIndex = 51;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // setPoints
            // 
            this.setPoints.Enabled = false;
            this.setPoints.Location = new System.Drawing.Point(15, 413);
            this.setPoints.Name = "setPoints";
            this.setPoints.Size = new System.Drawing.Size(200, 27);
            this.setPoints.TabIndex = 53;
            this.setPoints.Text = "Установить приёмник и источник";
            this.setPoints.UseVisualStyleBackColor = true;
            this.setPoints.Click += new System.EventHandler(this.setPoints_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.XRange);
            this.groupBox1.Controls.Add(this.YRange);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.XGridRange);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.YGridRange);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.RayCount);
            this.groupBox1.Controls.Add(this.lRayCount);
            this.groupBox1.Controls.Add(this.headRad);
            this.groupBox1.Controls.Add(this.EpsLabel);
            this.groupBox1.Controls.Add(this.RadLabel);
            this.groupBox1.Controls.Add(this.Eps);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.headY);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.headX);
            this.groupBox1.Location = new System.Drawing.Point(13, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 251);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ручная настройка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "X =";
            // 
            // XRange
            // 
            this.XRange.Location = new System.Drawing.Point(46, 29);
            this.XRange.Name = "XRange";
            this.XRange.Size = new System.Drawing.Size(39, 20);
            this.XRange.TabIndex = 46;
            this.XRange.Text = "1920";
            this.XRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // YRange
            // 
            this.YRange.Location = new System.Drawing.Point(145, 29);
            this.YRange.Name = "YRange";
            this.YRange.Size = new System.Drawing.Size(39, 20);
            this.YRange.TabIndex = 48;
            this.YRange.Text = "1080";
            this.YRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Y = ";
            // 
            // XGridRange
            // 
            this.XGridRange.Location = new System.Drawing.Point(145, 55);
            this.XGridRange.Name = "XGridRange";
            this.XGridRange.Size = new System.Drawing.Size(39, 20);
            this.XGridRange.TabIndex = 50;
            this.XGridRange.Text = "40";
            this.XGridRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Размер сетки по X";
            // 
            // YGridRange
            // 
            this.YGridRange.Location = new System.Drawing.Point(145, 81);
            this.YGridRange.Name = "YGridRange";
            this.YGridRange.Size = new System.Drawing.Size(39, 20);
            this.YGridRange.TabIndex = 52;
            this.YGridRange.Text = "40";
            this.YGridRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Размер сетки по Y";
            // 
            // FirstPointY1
            // 
            this.FirstPointY1.Location = new System.Drawing.Point(93, 32);
            this.FirstPointY1.Name = "FirstPointY1";
            this.FirstPointY1.Size = new System.Drawing.Size(27, 20);
            this.FirstPointY1.TabIndex = 54;
            this.FirstPointY1.Text = "500";
            // 
            // RayCount
            // 
            this.RayCount.Location = new System.Drawing.Point(139, 217);
            this.RayCount.Name = "RayCount";
            this.RayCount.Size = new System.Drawing.Size(45, 20);
            this.RayCount.TabIndex = 67;
            this.RayCount.Text = "10000";
            this.RayCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FirstPointX1
            // 
            this.FirstPointX1.Location = new System.Drawing.Point(46, 32);
            this.FirstPointX1.Name = "FirstPointX1";
            this.FirstPointX1.Size = new System.Drawing.Size(27, 20);
            this.FirstPointX1.TabIndex = 55;
            this.FirstPointX1.Text = "160";
            // 
            // lRayCount
            // 
            this.lRayCount.AutoSize = true;
            this.lRayCount.Location = new System.Drawing.Point(14, 220);
            this.lRayCount.Name = "lRayCount";
            this.lRayCount.Size = new System.Drawing.Size(97, 13);
            this.lRayCount.TabIndex = 66;
            this.lRayCount.Text = "Количество лучей";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 56;
            this.label7.Text = "X";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(106, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 57;
            this.label8.Text = "Y";
            // 
            // headRad
            // 
            this.headRad.Location = new System.Drawing.Point(147, 159);
            this.headRad.Name = "headRad";
            this.headRad.Size = new System.Drawing.Size(37, 20);
            this.headRad.TabIndex = 65;
            this.headRad.Text = "15";
            this.headRad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // EpsLabel
            // 
            this.EpsLabel.AutoSize = true;
            this.EpsLabel.Location = new System.Drawing.Point(14, 190);
            this.EpsLabel.Name = "EpsLabel";
            this.EpsLabel.Size = new System.Drawing.Size(41, 13);
            this.EpsLabel.TabIndex = 58;
            this.EpsLabel.Text = "Epsilon";
            // 
            // RadLabel
            // 
            this.RadLabel.AutoSize = true;
            this.RadLabel.Location = new System.Drawing.Point(14, 162);
            this.RadLabel.Name = "RadLabel";
            this.RadLabel.Size = new System.Drawing.Size(111, 13);
            this.RadLabel.TabIndex = 64;
            this.RadLabel.Text = "Радиус слышимости";
            // 
            // Eps
            // 
            this.Eps.Location = new System.Drawing.Point(127, 187);
            this.Eps.Name = "Eps";
            this.Eps.Size = new System.Drawing.Size(57, 20);
            this.Eps.TabIndex = 59;
            this.Eps.Text = "0,0000001";
            this.Eps.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 63;
            this.label11.Text = "Y головы";
            // 
            // headY
            // 
            this.headY.Location = new System.Drawing.Point(147, 133);
            this.headY.Name = "headY";
            this.headY.Size = new System.Drawing.Size(37, 20);
            this.headY.TabIndex = 60;
            this.headY.Text = "600";
            this.headY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 62;
            this.label13.Text = "X головы";
            // 
            // headX
            // 
            this.headX.Location = new System.Drawing.Point(147, 107);
            this.headX.Name = "headX";
            this.headX.Size = new System.Drawing.Size(37, 20);
            this.headX.TabIndex = 61;
            this.headX.Text = "750";
            this.headX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sourceBox
            // 
            this.sourceBox.Controls.Add(this.SourceNum1);
            this.sourceBox.Controls.Add(this.FirstPointX1);
            this.sourceBox.Controls.Add(this.FirstPointY1);
            this.sourceBox.Controls.Add(this.label7);
            this.sourceBox.Controls.Add(this.label8);
            this.sourceBox.Location = new System.Drawing.Point(221, 90);
            this.sourceBox.Name = "sourceBox";
            this.sourceBox.Size = new System.Drawing.Size(129, 251);
            this.sourceBox.TabIndex = 55;
            this.sourceBox.TabStop = false;
            this.sourceBox.Text = "Источники";
            // 
            // SourceNum1
            // 
            this.SourceNum1.AutoSize = true;
            this.SourceNum1.Location = new System.Drawing.Point(17, 35);
            this.SourceNum1.Name = "SourceNum1";
            this.SourceNum1.Size = new System.Drawing.Size(13, 13);
            this.SourceNum1.TabIndex = 58;
            this.SourceNum1.Text = "1";
            // 
            // AddSourceBtn
            // 
            this.AddSourceBtn.Location = new System.Drawing.Point(221, 347);
            this.AddSourceBtn.Name = "AddSourceBtn";
            this.AddSourceBtn.Size = new System.Drawing.Size(129, 27);
            this.AddSourceBtn.TabIndex = 56;
            this.AddSourceBtn.Text = "Добавить источник";
            this.AddSourceBtn.UseVisualStyleBackColor = true;
            this.AddSourceBtn.Click += new System.EventHandler(this.AddSource_Click);
            // 
            // DelSource
            // 
            this.DelSource.Enabled = false;
            this.DelSource.Location = new System.Drawing.Point(220, 380);
            this.DelSource.Name = "DelSource";
            this.DelSource.Size = new System.Drawing.Size(129, 28);
            this.DelSource.TabIndex = 57;
            this.DelSource.Text = "Удалить источник";
            this.DelSource.UseVisualStyleBackColor = true;
            this.DelSource.Click += new System.EventHandler(this.DelSource_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 465);
            this.Controls.Add(this.DelSource);
            this.Controls.Add(this.AddSourceBtn);
            this.Controls.Add(this.sourceBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.setPoints);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ShowT);
            this.Controls.Add(this.show_graph);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Трассировка";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.sourceBox.ResumeLayout(false);
            this.sourceBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button show_graph;
        private System.Windows.Forms.Button ShowT;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button setPoints;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox XRange;
        private System.Windows.Forms.TextBox YRange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox XGridRange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox YGridRange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FirstPointY1;
        private System.Windows.Forms.TextBox RayCount;
        private System.Windows.Forms.TextBox FirstPointX1;
        private System.Windows.Forms.Label lRayCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox headRad;
        private System.Windows.Forms.Label EpsLabel;
        private System.Windows.Forms.Label RadLabel;
        private System.Windows.Forms.TextBox Eps;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox headY;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox headX;
        private System.Windows.Forms.GroupBox sourceBox;
        private System.Windows.Forms.Label SourceNum1;
        private System.Windows.Forms.Button AddSourceBtn;
        private System.Windows.Forms.Button DelSource;
    }
}

