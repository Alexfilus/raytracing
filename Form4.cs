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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void DrawPoints()
        {
            pictureBox1.Image = ((Owner as Form1).pic.Clone() as Image);
            //int Radius = int.Parse(((Owner as Form1).Controls["HeadRad"] as TextBox).Text);
            int Radius = int.Parse((((Owner as Form1).Controls["groupBox1"] as GroupBox).Controls["HeadRad"] as TextBox).Text);
            Graphics.FromImage(pictureBox1.Image).DrawEllipse(
                new Pen(Color.Green, 5), 
                    int.Parse((((Owner as Form1).Controls["groupBox1"] as GroupBox).Controls["FirstPointX"] as TextBox).Text) - 1, 
                    int.Parse((((Owner as Form1).Controls["groupBox1"] as GroupBox).Controls["FirstPointY"] as TextBox).Text) - 1, 
                    2, 
                    2);
            Graphics.FromImage(pictureBox1.Image).DrawEllipse(
                Pens.Pink, 
                    int.Parse((((Owner as Form1).Controls["groupBox1"] as GroupBox).Controls["HeadX"] as TextBox).Text) - Radius, 
                    int.Parse((((Owner as Form1).Controls["groupBox1"] as GroupBox).Controls["HeadY"] as TextBox).Text) - Radius, 
                    2 * Radius, 
                    2 * Radius);
        }

        private void Form4_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Image = (Owner as Form1).pic;
            pictureBox1.Refresh();
            DrawPoints();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Middle)) MessageBox.Show(e.Location.ToString());
            if (e.Button.Equals(MouseButtons.Left))
            {
                switch (Control.ModifierKeys)
                {
                    case Keys.Control:
                        (((Owner as Form1).Controls["groupBox1"] as GroupBox).Controls["FirstPointX"] as TextBox).Text = e.X.ToString();
                        (((Owner as Form1).Controls["groupBox1"] as GroupBox).Controls["FirstPointY"] as TextBox).Text = e.Y.ToString();
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
            if (e.Button.Equals(MouseButtons.Right))
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как ...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter =
                    "Bitmap File(*.bmp)|*.bmp|" +
                    "GIF File(*.gif)|*.gif|" +
                    "JPEG File(*.jpg)|*.jpg|" +
                    "TIF File(*.tif)|*.tif|" +
                    "PNG File(*.png)|*.png";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    string strFilExtn = savedialog.FileName.Remove(0, savedialog.FileName.Length - 3);
                    switch (strFilExtn)
                    {
                        case "bmp":
                            pictureBox1.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case "jpg":
                            pictureBox1.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case "gif":
                            pictureBox1.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case "tif":
                            pictureBox1.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Tiff);
                            break;
                        case "png":
                            pictureBox1.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
