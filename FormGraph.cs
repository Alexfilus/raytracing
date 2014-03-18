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
    public partial class FormGraph : Form
    {
        public FormGraph()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Middle)) MessageBox.Show(e.Location.ToString());
            if (e.Button.Equals(MouseButtons.Left)) this.Close();
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

        private void FormGraph_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Image = (Owner as Form1).Graph_bmp;
            pictureBox1.Refresh();
        }
    }
}
