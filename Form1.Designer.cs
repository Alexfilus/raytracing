﻿namespace raytraicing
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
            this.button2 = new System.Windows.Forms.Button();
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
            this.SecondPointY = new System.Windows.Forms.TextBox();
            this.FirstPointX = new System.Windows.Forms.TextBox();
            this.SecondPointX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.BumpLog = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.EpsLabel = new System.Windows.Forms.Label();
            this.Eps = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(12, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Загрузить информацию";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(205, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Сгенерировать тестовые файлы";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Y = ";
            // 
            // YRange
            // 
            this.YRange.Location = new System.Drawing.Point(42, 93);
            this.YRange.Name = "YRange";
            this.YRange.Size = new System.Drawing.Size(39, 20);
            this.YRange.TabIndex = 8;
            this.YRange.Text = "1080";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "X =";
            // 
            // XRange
            // 
            this.XRange.Location = new System.Drawing.Point(42, 70);
            this.XRange.Name = "XRange";
            this.XRange.Size = new System.Drawing.Size(39, 20);
            this.XRange.TabIndex = 6;
            this.XRange.Text = "1920";
            // 
            // XGridRange
            // 
            this.XGridRange.Location = new System.Drawing.Point(117, 119);
            this.XGridRange.Name = "XGridRange";
            this.XGridRange.Size = new System.Drawing.Size(46, 20);
            this.XGridRange.TabIndex = 10;
            this.XGridRange.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Размер сетки по X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Размер сетки по Y";
            // 
            // YGridRange
            // 
            this.YGridRange.Location = new System.Drawing.Point(117, 145);
            this.YGridRange.Name = "YGridRange";
            this.YGridRange.Size = new System.Drawing.Size(46, 20);
            this.YGridRange.TabIndex = 12;
            this.YGridRange.Text = "10";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(12, 180);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(205, 27);
            this.button3.TabIndex = 14;
            this.button3.Text = "Проверка";
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
            this.FirstPointY.Location = new System.Drawing.Point(117, 255);
            this.FirstPointY.Name = "FirstPointY";
            this.FirstPointY.Size = new System.Drawing.Size(50, 20);
            this.FirstPointY.TabIndex = 20;
            this.FirstPointY.Text = "100";
            // 
            // SecondPointY
            // 
            this.SecondPointY.Location = new System.Drawing.Point(117, 281);
            this.SecondPointY.Name = "SecondPointY";
            this.SecondPointY.Size = new System.Drawing.Size(50, 20);
            this.SecondPointY.TabIndex = 21;
            this.SecondPointY.Text = "200";
            // 
            // FirstPointX
            // 
            this.FirstPointX.Location = new System.Drawing.Point(42, 255);
            this.FirstPointX.Name = "FirstPointX";
            this.FirstPointX.Size = new System.Drawing.Size(50, 20);
            this.FirstPointX.TabIndex = 23;
            this.FirstPointX.Text = "480";
            // 
            // SecondPointX
            // 
            this.SecondPointX.Location = new System.Drawing.Point(42, 281);
            this.SecondPointX.Name = "SecondPointX";
            this.SecondPointX.Size = new System.Drawing.Size(50, 20);
            this.SecondPointX.TabIndex = 24;
            this.SecondPointX.Text = "450";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "X1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(91, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Y1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "X2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(91, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Y2";
            // 
            // BumpLog
            // 
            this.BumpLog.FormattingEnabled = true;
            this.BumpLog.Location = new System.Drawing.Point(483, 41);
            this.BumpLog.Name = "BumpLog";
            this.BumpLog.Size = new System.Drawing.Size(403, 329);
            this.BumpLog.TabIndex = 30;
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(11, 343);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(208, 23);
            this.button5.TabIndex = 31;
            this.button5.Text = "Пустить луч";
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
            this.button6.Location = new System.Drawing.Point(87, 70);
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
            this.button7.Location = new System.Drawing.Point(11, 213);
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
            this.EpsLabel.Location = new System.Drawing.Point(18, 324);
            this.EpsLabel.Name = "EpsLabel";
            this.EpsLabel.Size = new System.Drawing.Size(41, 13);
            this.EpsLabel.TabIndex = 35;
            this.EpsLabel.Text = "Epsilon";
            // 
            // Eps
            // 
            this.Eps.Location = new System.Drawing.Point(65, 321);
            this.Eps.Name = "Eps";
            this.Eps.Size = new System.Drawing.Size(42, 20);
            this.Eps.TabIndex = 36;
            this.Eps.Text = "0,01";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 379);
            this.Controls.Add(this.Eps);
            this.Controls.Add(this.EpsLabel);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.BumpLog);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SecondPointX);
            this.Controls.Add(this.FirstPointX);
            this.Controls.Add(this.SecondPointY);
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
            this.Controls.Add(this.button2);
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
        private System.Windows.Forms.Button button2;
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
        private System.Windows.Forms.TextBox SecondPointY;
        private System.Windows.Forms.TextBox FirstPointX;
        private System.Windows.Forms.TextBox SecondPointX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox BumpLog;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label EpsLabel;
        private System.Windows.Forms.TextBox Eps;
    }
}

