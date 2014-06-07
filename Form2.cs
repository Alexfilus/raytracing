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

        private void DrawPoints()
        {
            pictureBox1.Image = ((Owner as Form1).room.Clone() as Image);
            int Radius = int.Parse(((Owner as Form1).Controls["HeadRad"] as TextBox).Text);
            Graphics.FromImage(pictureBox1.Image).DrawEllipse(new Pen(Color.Green, 5), int.Parse(((Owner as Form1).Controls["FirstPointX"] as TextBox).Text) - 1, int.Parse(((Owner as Form1).Controls["FirstPointY"] as TextBox).Text) - 1, 2, 2);
            Graphics.FromImage(pictureBox1.Image).DrawEllipse(Pens.Pink, int.Parse(((Owner as Form1).Controls["HeadX"] as TextBox).Text) - Radius, int.Parse(((Owner as Form1).Controls["HeadY"] as TextBox).Text) - Radius, 2 * Radius, 2 * Radius);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //pictureBox1.Image = buf;
            //pictureBox1.Image = (Owner as Form1).room;
            DrawPoints();
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left)) this.Close();
            if (e.Button.Equals(MouseButtons.Middle))
            {
                ((Owner as Form1).Controls["FirstPointX"] as TextBox).Text = e.X.ToString();
                ((Owner as Form1).Controls["FirstPointY"] as TextBox).Text = e.Y.ToString();
                DrawPoints();
            }
            if (e.Button.Equals(MouseButtons.Right))
            {
                ((Owner as Form1).Controls["HeadX"] as TextBox).Text = e.X.ToString();
                ((Owner as Form1).Controls["HeadY"] as TextBox).Text = e.Y.ToString();
                DrawPoints();
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
