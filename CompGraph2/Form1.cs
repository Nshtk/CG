using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompGraph2
{
    public partial class Form1 : Form
    {
        Bitmap image = null;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            openFileDialog1.Filter = "Images(*.BMP; *.JPG; *.GIF,*.PNG,*.TIFF)| *.BMP; *.JPG; *.GIF; *.PNG; *.TIFF | " + "All files (*.*)|*.*";
            openFileDialog1.Title = "Выберите изображение:";
            saveFileDialog1.Filter = "Images(*.BMP; *.JPG; *.GIF,*.PNG,*.TIFF)| *.BMP; *.JPG; *.GIF; *.PNG; *.TIFF | " + "All files (*.*)|*.*";
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(openFileDialog1.FileNames.First());
                pictureBox1.Image = image;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(image!=null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
            else
                MessageBox.Show("Изображение не открыто.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        applyTriangleFilter();
                        break;
                    case 1:
                        applyNegativeFilter();
                        break;
                    case 2:
                        applyBWFilter();
                        break;
                }
                pictureBox1.Image = image;
            }
            else
                MessageBox.Show("Изображение не открыто.");
        }
        private void applyTriangleFilter()
        {
            Graphics gr = Graphics.FromImage(image);
            Point point1 = new Point(210, 270);
            Point point2 = new Point(310, 140);
            Point point3 = new Point(410, 270);
            Point[] points = { point1, point2, point3 };
            gr.DrawPolygon(new Pen(Color.Black, 2), points);

            Color pixel;
            int result1, result2, result3, t;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    pixel = image.GetPixel(i, j);
                    result1 = (point1.X - i) * (point2.Y - point1.Y) - (point1.Y - j) * (point2.X - point1.X);
                    result2 = (point2.X - i) * (point3.Y - point2.Y) - (point2.Y - j) * (point3.X - point2.X);
                    result3 = (point3.X - i) * (point1.Y - point3.Y) - (point3.Y - j) * (point1.X - point3.X);
                    if ((result1>0 && result2>0 && result3>0) || result1 < 0 && result2 < 0 && result3 < 0)
                    {
                        t = (pixel.R + pixel.G + pixel.B) / 3;
                        image.SetPixel(i, j, Color.FromArgb(255, t, t, t));
                    }
                    else
                        image.SetPixel(i, j, Color.FromArgb(255, 0, 0, pixel.B));
                }
            }

        }
        private void applyNegativeFilter()
        {
            Color pixel;
            int r, g, b;
            for(int i=0; i<image.Width; i++)
            {
                for(int j=0; j<image.Height; j++)
                {
                    pixel=image.GetPixel(i, j);
                    r = 255 - pixel.R;
                    g = 255 - pixel.G;
                    b = 255 - pixel.B;
                    image.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                }
            }
        }
        private void applyBWFilter()
        {
            Color pixel;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    pixel = image.GetPixel(i, j);
                    if((pixel.R+pixel.G+pixel.B)>382)
                        image.SetPixel(i, j, Color.White);
                    else
                        image.SetPixel(i, j, Color.Black);
                }
            }
        }
    }
}
