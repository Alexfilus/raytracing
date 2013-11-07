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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int countP = Convert.ToInt32(textBox1.Text);
            int countR = Convert.ToInt32(textBox4.Text);
            int X = Convert.ToInt32(textBox2.Text);
            int Y = Convert.ToInt32(textBox3.Text);
            Random rand = new Random();
            for (int i = 0; i < countP; i++)
            {
                listBox1.Items.Add(rand.Next(X).ToString() + " " + rand.Next(Y).ToString());
            }
            listBox1.Items.Add("0 0");
            listBox1.Items.Add("0 " + (Y - 1).ToString());
            listBox1.Items.Add((X - 1).ToString() + " 0");
            listBox1.Items.Add((X - 1).ToString() + " " + (Y - 1).ToString());
            for (int i = 0; i < countR; i++)
            {
                int num1 = rand.Next(countP);
                int num2;
                do
                {
                    num2 = rand.Next(countP);
                } while (num1 == num2);
                listBox2.Items.Add(num1.ToString() + " " + num2.ToString());
            }
            listBox2.Items.Add(countP.ToString() + " " + (countP + 1).ToString());
            listBox2.Items.Add((countP + 1).ToString() + " " + (countP + 3).ToString());
            listBox2.Items.Add((countP + 3).ToString() + " " + (countP + 2).ToString());
            listBox2.Items.Add((countP + 2).ToString() + " " + countP.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(@"points.dat", listBox1.Items.OfType<string>());
            File.WriteAllLines(@"ribs.dat", listBox2.Items.OfType<string>());
        }
    }
}
