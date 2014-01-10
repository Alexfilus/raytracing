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
            this.BumpLog = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(3, 10);
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
            this.label3.Location = new System.Drawing.Point(4, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Y = ";
            // 
            // YRange
            // 
            this.YRange.Location = new System.Drawing.Point(33, 62);
            this.YRange.Name = "YRange";
            this.YRange.Size = new System.Drawing.Size(39, 20);
            this.YRange.TabIndex = 8;
            this.YRange.Text = "1080";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "X =";
            // 
            // XRange
            // 
            this.XRange.Location = new System.Drawing.Point(33, 39);
            this.XRange.Name = "XRange";
            this.XRange.Size = new System.Drawing.Size(39, 20);
            this.XRange.TabIndex = 6;
            this.XRange.Text = "1920";
            // 
            // XGridRange
            // 
            this.XGridRange.Location = new System.Drawing.Point(108, 88);
            this.XGridRange.Name = "XGridRange";
            this.XGridRange.Size = new System.Drawing.Size(46, 20);
            this.XGridRange.TabIndex = 10;
            this.XGridRange.Text = "20";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Размер сетки по X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-1, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Размер сетки по Y";
            // 
            // YGridRange
            // 
            this.YGridRange.Location = new System.Drawing.Point(108, 114);
            this.YGridRange.Name = "YGridRange";
            this.YGridRange.Size = new System.Drawing.Size(46, 20);
            this.YGridRange.TabIndex = 12;
            this.YGridRange.Text = "20";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(3, 149);
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
            this.label5.Location = new System.Drawing.Point(353, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Рёбра";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Вершины";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(356, 41);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 329);
            this.listBox2.TabIndex = 16;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(230, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 329);
            this.listBox1.TabIndex = 15;
            // 
            // FirstPointY
            // 
            this.FirstPointY.Location = new System.Drawing.Point(108, 182);
            this.FirstPointY.Name = "FirstPointY";
            this.FirstPointY.Size = new System.Drawing.Size(50, 20);
            this.FirstPointY.TabIndex = 20;
            this.FirstPointY.Text = "400";
            // 
            // FirstPointX
            // 
            this.FirstPointX.Location = new System.Drawing.Point(33, 182);
            this.FirstPointX.Name = "FirstPointX";
            this.FirstPointX.Size = new System.Drawing.Size(50, 20);
            this.FirstPointX.TabIndex = 23;
            this.FirstPointX.Text = "160";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "X1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(82, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Y1";
            // 
            // BumpLog
            // 
            this.BumpLog.FormattingEnabled = true;
            this.BumpLog.Location = new System.Drawing.Point(483, 41);
            this.BumpLog.Name = "BumpLog";
            this.BumpLog.Size = new System.Drawing.Size(546, 329);
            this.BumpLog.TabIndex = 30;
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(108, 149);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 27);
            this.button5.TabIndex = 31;
            this.button5.Text = "Пустить лучи";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(480, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Столкновения";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(78, 39);
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
            this.button7.Location = new System.Drawing.Point(2, 274);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(205, 27);
            this.button7.TabIndex = 34;
            this.button7.Text = "Рисунок";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // EpsLabel
            // 
            this.EpsLabel.AutoSize = true;
            this.EpsLabel.Location = new System.Drawing.Point(9, 251);
            this.EpsLabel.Name = "EpsLabel";
            this.EpsLabel.Size = new System.Drawing.Size(41, 13);
            this.EpsLabel.TabIndex = 35;
            this.EpsLabel.Text = "Epsilon";
            // 
            // Eps
            // 
            this.Eps.Location = new System.Drawing.Point(56, 248);
            this.Eps.Name = "Eps";
            this.Eps.Size = new System.Drawing.Size(42, 20);
            this.Eps.TabIndex = 36;
            this.Eps.Text = "0,01";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(114, 310);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Y головы";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 310);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "X головы";
            // 
            // headX
            // 
            this.headX.Location = new System.Drawing.Point(67, 307);
            this.headX.Name = "headX";
            this.headX.Size = new System.Drawing.Size(41, 20);
            this.headX.TabIndex = 38;
            this.headX.Text = "750";
            // 
            // headY
            // 
            this.headY.Location = new System.Drawing.Point(174, 307);
            this.headY.Name = "headY";
            this.headY.Size = new System.Drawing.Size(50, 20);
            this.headY.TabIndex = 37;
            this.headY.Text = "400";
            // 
            // RadLabel
            // 
            this.RadLabel.AutoSize = true;
            this.RadLabel.Location = new System.Drawing.Point(7, 336);
            this.RadLabel.Name = "RadLabel";
            this.RadLabel.Size = new System.Drawing.Size(111, 13);
            this.RadLabel.TabIndex = 41;
            this.RadLabel.Text = "Радиус слышимости";
            // 
            // headRad
            // 
            this.headRad.Location = new System.Drawing.Point(124, 333);
            this.headRad.Name = "headRad";
            this.headRad.Size = new System.Drawing.Size(100, 20);
            this.headRad.TabIndex = 42;
            this.headRad.Text = "15";
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(120, 245);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(87, 22);
            this.btnAbort.TabIndex = 43;
            this.btnAbort.Text = "Сброс";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // lRayCount
            // 
            this.lRayCount.AutoSize = true;
            this.lRayCount.Location = new System.Drawing.Point(4, 215);
            this.lRayCount.Name = "lRayCount";
            this.lRayCount.Size = new System.Drawing.Size(97, 13);
            this.lRayCount.TabIndex = 44;
            this.lRayCount.Text = "Количество лучей";
            // 
            // RayCount
            // 
            this.RayCount.Location = new System.Drawing.Point(108, 212);
            this.RayCount.Name = "RayCount";
            this.RayCount.Size = new System.Drawing.Size(50, 20);
            this.RayCount.TabIndex = 45;
            this.RayCount.Text = "9";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 379);
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
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.BumpLog);
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
        private System.Windows.Forms.ListBox BumpLog;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label12;
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
    }
}

