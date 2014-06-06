using System;
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

        public Bitmap buf;

        private void floodFill4(int x, int y, int newColor, int oldColor)
        {
            if (x >= 0 && x < w && y >= 0 && y < h && screenBuffer[x][y] == oldColor && screenBuffer[x][y] != newColor)
            {
                screenBuffer[x][y] = newColor; //set color before starting recursion

                floodFill4(x + 1, y, newColor, oldColor);
                floodFill4(x - 1, y, newColor, oldColor);
                floodFill4(x, y + 1, newColor, oldColor);
                floodFill4(x, y - 1, newColor, oldColor);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //pictureBox1.Image = buf;
            pictureBox1.Image = (Owner as Form1).room;
            pictureBox1.Refresh();
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left)) this.Close();
            if (e.Button.Equals(MouseButtons.Middle))
            {
                ((Owner as Form1).Controls["FirstPointX"] as TextBox).Text = e.X.ToString();
                ((Owner as Form1).Controls["FirstPointY"] as TextBox).Text = e.Y.ToString();
            }
            if (e.Button.Equals(MouseButtons.Right))
            {
                ((Owner as Form1).Controls["HeadX"] as TextBox).Text = e.X.ToString();
                ((Owner as Form1).Controls["HeadY"] as TextBox).Text = e.Y.ToString();
                Listener temp = new Listener(new Point2D(e.X, e.Y), int.Parse(((Owner as Form1).Controls["headRad"] as TextBox).Text));
                temp.DrawHead(Graphics.FromImage(buf));
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            buf = new Bitmap((Owner as Form1).pic1);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            (Owner as Form1).pic1 = new Bitmap(buf);
        }

    }
}
