using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KG4
{
    public partial class Form2 : Form
    {
        public int projection = 1;
        static List<double[][]> points_projection;
        double[][] matrix ={new double[] {1, 0, 0, 0},
                            new double[] {0, 1, 0, 0},
                            new double[] {0, 0, 0, 0},
                            new double[] {0, 0, 0, 1}};
        public Form2()
        {
            InitializeComponent();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "oblique":
                    projection = 0;
                    comboBox1.Visible = false; 
                    break;
                case "central":
                    projection = 1;
                    comboBox1.Visible = false; 
                    break;
                case "orthogonal..":
                    projection = 2;
                    comboBox1.Visible = true;
                    break;
                default: projection = 0; break;
            }
            this.Invalidate();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int x = ClientSize.Width / 2;
            int y = ClientSize.Height / 2;

            //нарисуем оси
            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, x, 0, x, y * 2);
            g.DrawLine(pen, 0, y, x * 2, y);

            switch (projection)
            {
                case 0:
                    {
                        double l = 0.5;
                        double B = Math.Atan(2);
                        double[,] matrix = { {1, 0, 0, 0},
                              {0, 1, 0, 0},
                              {l * Math.Cos(B), l * Math.Sin(B), 0, 0},
                              {0, 0, 0, 1}};
                        //Form1.WireframeDraw(g, matrix, ClientSize.Width, ClientSize.Height);
                    }
                    break;
                case 1:
                    {
                        double k = -10;
                        double r = 1 / k;
                        double[,] matrix = { {1, 0, 0, 0},
                              {0, 1, 0, 0},
                              {0, 0, 0, r},
                              {0, 0, 0, 1}};
                        //Form1.WireframeDraw(g, matrix, ClientSize.Width, ClientSize.Height);
                    }
                    break;
                case 2:
                    {
                        WireframeDraw(g, matrix, ClientSize.Width, ClientSize.Height);
                    }
                    break;
            }

        }

        private void WireframeDraw(Graphics g, double[][] matrix, int Form_x, int Form_y)
        {
            Pen pen = new Pen(Color.Black);

            int x = Form_x / 2;
            int y = Form_y / 2;

            //points_projection = Form1.MatrixMult(Form1.points, matrix);
            points_projection = Form1.MatrixNorm(points_projection);

            //Point[] points_toDraw = new Point[Form1.points.GetUpperBound(0) + 1];

                for (int i = 0; i < points_projection.Count + 1; i++)
                {
                    //points_toDraw[i] = new Point(Convert.ToInt32(points_projection[i, 0] * Form1.scale + x), Convert.ToInt32(y - points_projection[i, 1] * Form1.scale));
                }

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            //path.AddLines(points_toDraw);

            g.DrawPath(pen, path);
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double[][] matrix_3 ={ new double[] {0.93, 0.13, -0.35, 0},
                              new double[]{0, 0.93, 0.35, 0},
                              new double[]{0.38, -0.33, 0.36, 0},
                              new double[]{0, 0, 0, 1}};
            double[][] matrix_4 ={ new double[]{0.71, 0.41, -0.58, 0},
                              new double[]{0, 0.82, 0.58, 0},
                              new double[]{0.71, -0.41, 0.58, 0},
                              new double[]{0, 0, 0, 1}};
            switch (comboBox1.Text)
            {
                case "dimetric":
                    matrix = matrix_3;
                    this.Invalidate();
                    break;
                case "isometric":
                    matrix = matrix_4;
                    this.Invalidate();
                    break;
                default:
                    break;
            }
        }
    }
}
