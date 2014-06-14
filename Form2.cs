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
            pictureBox1.Image = ((Owner as Form1).pic.Clone() as Image);
            //int Radius = int.Parse(((Owner as Form1).Controls["HeadRad"] as TextBox).Text);
            int Radius = int.Parse((((Owner as Form1).Controls["groupBox1"] as GroupBox).Controls["HeadRad"] as TextBox).Text);
            Graphics.FromImage(pictureBox1.Image).DrawEllipse(
                Pens.Pink,
                    int.Parse((((Owner as Form1).Controls["groupBox1"] as GroupBox).Controls["HeadX"] as TextBox).Text) - Radius,
                    int.Parse((((Owner as Form1).Controls["groupBox1"] as GroupBox).Controls["HeadY"] as TextBox).Text) - Radius,
                    2 * Radius,
                    2 * Radius);
            int SourceCount = ((Owner as Form1).Controls["sourceBox"] as GroupBox).Controls.OfType<Label>().Sum(label => 1) - 2;
            for (int i = 1; i <= SourceCount; ++i)
                Graphics.FromImage(pictureBox1.Image).DrawEllipse(
                    new Pen(Color.Green, 5),
                    int.Parse((((Owner as Form1).Controls["sourceBox"] as GroupBox).Controls["FirstPointX" + i.ToString()] as TextBox).Text) - 1,
                    int.Parse((((Owner as Form1).Controls["sourceBox"] as GroupBox).Controls["FirstPointY" + i.ToString()] as TextBox).Text) - 1,
                    2,
                    2);
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
            if (e.Button.Equals(MouseButtons.Left))
            {
                switch (Control.ModifierKeys)
                {
                    case Keys.Control:
                        (Owner as Form1).AddSource(e.X.ToString(), e.Y.ToString());
                        DrawPoints();
                        break;
                    case Keys.Alt:
                        (((Owner as Form1).Controls["groupBox1"] as GroupBox).Controls["HeadX"] as TextBox).Text = e.X.ToString();
                        (((Owner as Form1).Controls["groupBox1"] as GroupBox).Controls["HeadY"] as TextBox).Text = e.Y.ToString();
                        DrawPoints();
                        break;
                    default:
                        this.Close();
                        break;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            buf = new Bitmap((Owner as Form1).pic);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            (Owner as Form1).pic = new Bitmap(buf);
        }

    }
}
