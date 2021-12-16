using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace KG4
{
    public partial class Form1 : Form
    {
        public List<double[][]> points_projection;
        public double scale;
        public int axi_rot;
        int CoefX;
        int CoefY;

        private static List<double[][]> vertices_3d = new List<double[][]>()
        {
        new double[][]{       //vertices hexagon
            new double[] { -1, -3, 0, 1}, //1
            new double[] { -2, -1, -1, 1}, //2
            new double[] { -2, 1, -1, 1}, //3
            new double[] { -1, 2, 0, 1}, //4
            new double[] { 0, 0, 1, 1}, //5
            new double[] { 0, -2, 1, 1}, //6
        },
         new double[][]{      //vertices_triangle
            new double[] { -2, 1, -1, 1}, //1 //3
            new double[] { -1, 2, 0, 1}, //2 //4
            new double[] { 3, 2.5, -1, 1}, //3
        },
         new double[][]{      //vertices_trapeze
            new double[] { 3, -3, -1, 1}, //1
            new double[] { -2, -1, -1, 1}, //2 //2
            new double[] { -2, 1, -1, 1}, //3  //3
            new double[] { 3, 2.5, -1, 1}, //4 //3tr
        },
        new double[][]{       //vertices_triangle_right
            new double[] { 3, 2.5, -1, 1}, //1 //3tr
            new double[] { 4, 0, 1, 1}, //2
            new double[] { 3, -3, -1, 1}, //3 //1 peze
        },
        new double[][]{           //vertices_trapeze_forward
            new double[] { 4, 0, 1, 1}, //1 //2trr
            new double[] { 0, 0, 1, 1}, //3 //5
            new double[] { -1, 2, 0, 1}, //2 //4
            new double[] { 3, 2.5, -1, 1}, //1 //3tr
        },
        new double[][]{       //vertices_triangle_forward
            new double[] { 0, -2, 1, 1}, //1 //6
            new double[] { 0, 0, 1, 1}, //2 //5
            new double[] { 4, 0, 1, 1}, //3 //2trr
        },
        new double[][]{               //vertices_trapeze_down
            new double[] { 3, -3, -1, 1}, //1 //1 peze
            new double[] { -1, -3, 0, 1}, //2
            new double[] { 0, -2, 1, 1}, //3
            new double[] { 4, 0, 1, 1}, //4 //2 trr
        },
        new double[][]{          //vertices_triangle_back
            new double[] { -1, -3, 0, 1}, //1 //1
            new double[] { -2, -1, -1, 1}, //2 //2
            new double[] { 3, -3, -1, 1}, //3 //1 peze
        }
    };
        private List<double[][]> vertices_3d_copy = vertices_3d;
        public Form1()
        {
            InitializeComponent();
            CoefX = ClientSize.Width / 2;
            CoefY = ClientSize.Height / 2;
        }

        public List<double[][]> matrixMultiply(double[][] matrix)
        {
            List<double[][]> vertices = new List<double[][]>();
            int iter = 0;
            foreach (var shape_2d in vertices_3d)
            {
                int vertices_count = shape_2d.Length;
                int matrix_columns = matrix[0].Length;
                int vertice_coord_count;

                vertices.Add(new double[vertices_count][]);
                for (int i = 0; i < vertices_count; i++)
                {
                    vertice_coord_count = shape_2d[i].Length;
                    vertices[iter][i] = new double[matrix_columns];
                    for (int j = 0; j < matrix_columns; j++)
                    {
                        vertices[iter][i][j] = 0;
                        for (int k = 0; k < vertice_coord_count; k++)
                            vertices[iter][i][j] += shape_2d[i][k] * matrix[k][j];
                    }
                }
                iter++;
            }
            return vertices;
        }
        public static List<double[][]> MatrixNorm(List<double[][]> A)
        {

            List<double[][]> vertices = new List<double[][]>();
            int iter = 0;
            foreach (var shape_2d in A)
            {
                int vertices_count = shape_2d.Length;
                vertices.Add(new double[vertices_count][]);
                int ColA = shape_2d[0].Length;
                for (int i = 0; i < vertices_count; i++)
                {
                    int vertice_coord_count = shape_2d[i].Length;
                    vertices[iter][i] = new double[vertice_coord_count];
                    for (int j = 0; j < ColA; j++)
                        vertices[iter][i][j] = shape_2d[i][j] / shape_2d[i][ColA - 1];
                }
                    
                iter++;
            }
            return vertices;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scale = 30;
            Graphics g = e.Graphics;

            int x = ClientSize.Width / 2;
            int y = ClientSize.Height / 2;

            Draw_ax(g, x, y);

            //нарисуем фигуру
            double l = 1;
            double B = 26.8 * Math.PI / 180;
            //double B = Math.Atan(2);
            double[][] matrix = { new double[] {1, 0, 0, 0},
                                 new double[] {0, 1, 0, 0},
                                 new double[] {l * Math.Cos(B), l * Math.Sin(B), 0, 0},
                                 new double[] {0, 0, 0, 1}};
            if (checkBox1.Checked == true)
            {
                WireframeDraw(g, matrix);
            }
            else
            {
                PolygonDraw(g, matrix);
            }
        }

        private void PolygonDraw(Graphics g, double[][] matrix)
        {

            /*int j = 0;
            int x = Form_x / 2;
            int y = Form_y / 2;

            PointF[] points_toDraw = new PointF[6];
            //double[,] check = new double[1, 1];
            points_projection = matrixMultiply(points, matrix);

            for (var i = 0; i < points.GetUpperBound(0); i += 4) // points.GetUpperBound(0)
            {
                double x1 = points[i, 0];
                double x2 = points[i + 1, 0];
                double x3 = points[i + 2, 0];
                double y1 = points[i, 1];
                double y2 = points[i + 1, 1];
                double y3 = points[i + 2, 1];
                double z1 = points[i, 2];
                double z2 = points[i + 1, 2];
                double z3 = points[i + 2, 2];

                *//*double norm_x = y1 * (z2 - z3) + y2 * (z3 - z1) + y3 * (z1 - z2);
                double norm_y = z1 * (x2 - x3) + z2 * (x3 - x1) + z3 * (x1 - x2);
                double norm_z = x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2);*//*

                double norm_x = (y2 - y1) * (z3 - z2) - (z2 - z1) * (y3 - y2);
                double norm_y = (z2 - z1) * (x3 - x2) - (x2 - x1) * (z3 - z2);
                double norm_z = (x2 - x1) * (y3 - y2) - (y2 - y1) * (x3 - x2);

*//*                double a = x1 * (y2 * z3 - y3 * z2);
                double b = x2 * (y3 * z1 - y1 * z3);
                double c = x3 * (y1 * z2 - y1 * z1);

                double norm_diag = -(a + b + c);
                if (norm_diag != 0)
                {
                    norm_x /= norm_diag;
                    norm_y /= norm_diag;
                    norm_z /= norm_diag;
                    norm_diag = 1;
                }
                double[,] V = { { norm_x }, { norm_y }, { norm_z }, { 1 } };*//*
                double[] v = { 3, 3, -3, 0 };
                //check = matrixMultiply(v, V);
                //check[0, 0] = 1;

                //if (i+5 > points.GetUpperBound(0)) break;
                double ch = norm_x * v[0] + norm_y * v[1] + norm_z * (v[2]);

                if (ch > 0)
                {
                    if (j < 2)
                    {
                        points_toDraw[0] = new PointF(Convert.ToInt32(points_projection[i, 0] * scale + x), Convert.ToInt32(y - points_projection[i, 1] * scale));
                        points_toDraw[1] = new PointF(Convert.ToInt32(points_projection[i + 1, 0] * scale + x), Convert.ToInt32(y - points_projection[i + 1, 1] * scale));
                        points_toDraw[2] = new PointF(Convert.ToInt32(points_projection[i + 2, 0] * scale + x), Convert.ToInt32(y - points_projection[i + 2, 1] * scale));
                        points_toDraw[3] = new PointF(Convert.ToInt32(points_projection[i + 3, 0] * scale + x), Convert.ToInt32(y - points_projection[i + 3, 1] * scale));
                        points_toDraw[4] = new PointF(Convert.ToInt32(points_projection[i + 4, 0] * scale + x), Convert.ToInt32(y - points_projection[i + 4, 1] * scale));
                        points_toDraw[5] = new PointF(Convert.ToInt32(points_projection[i + 5, 0] * scale + x), Convert.ToInt32(y - points_projection[i + 5, 1] * scale));

                    }
                    else
                    {
                        points_toDraw[0] = new PointF(Convert.ToInt32(points_projection[i, 0] * scale + x), Convert.ToInt32(y - points_projection[i, 1] * scale));
                        points_toDraw[1] = new PointF(Convert.ToInt32(points_projection[i + 1, 0] * scale + x), Convert.ToInt32(y - points_projection[i + 1, 1] * scale));
                        points_toDraw[2] = new PointF(Convert.ToInt32(points_projection[i + 2, 0] * scale + x), Convert.ToInt32(y - points_projection[i + 2, 1] * scale));
                        points_toDraw[3] = new PointF(Convert.ToInt32(points_projection[i + 3, 0] * scale + x), Convert.ToInt32(y - points_projection[i + 3, 1] * scale));
                        points_toDraw[4] = new PointF(Convert.ToInt32(points_projection[i + 3, 0] * scale + x), Convert.ToInt32(y - points_projection[i + 3, 1] * scale));
                        points_toDraw[5] = new PointF(Convert.ToInt32(points_projection[i + 3, 0] * scale + x), Convert.ToInt32(y - points_projection[i + 3, 1] * scale));
                    }

                    SolidBrush brush = new SolidBrush(Color.FromArgb(i / 2 * 10, i / 2 * 10, i / 2 * 10));
                    Pen pen = new Pen(Color.Black);

                    GraphicsPath path = new GraphicsPath();
                    path.AddLines(points_toDraw);
                    g.FillPath(brush, path);
                    //g.DrawPath(pen, path);

                    path.Dispose();
                }
                if (j < 2) i += 2;
                j++;
            }*/
        }
        private void drawShape2d(Graphics g, GraphicsPath graphics_path, Pen pen, double[][] vertices, int enclosing)
        {
            PointF[] points_toDraw = new PointF[vertices.GetUpperBound(0) + 1 + enclosing];
            int i = 0;

            for (; i < vertices.Length; i++)
                points_toDraw[i] = new PointF(Convert.ToInt32(vertices[i][0] * scale + CoefX), Convert.ToInt32(CoefY - vertices[i][1] * scale));
            if (enclosing == 1)
                points_toDraw[i] = new PointF(Convert.ToInt32(vertices[0][0] * scale + CoefX), Convert.ToInt32(CoefY - vertices[0][1] * scale));

            graphics_path.AddLines(points_toDraw);
            g.DrawPath(pen, graphics_path);
        }
        public void WireframeDraw(Graphics g, double[][] matrix)
        {
            GraphicsPath path = new GraphicsPath();
            Pen pen = new Pen(Color.Black);
            points_projection = matrixMultiply(matrix);

            drawShape2d(g, path, pen, points_projection[0], 1);
            drawShape2d(g, path, pen, points_projection[1], 1);
            drawShape2d(g, path, pen, points_projection[2], 0);
            drawShape2d(g, path, pen, points_projection[3], 1);
            drawShape2d(g, path, pen, points_projection[4], 0);
            drawShape2d(g, path, pen, points_projection[5], 1);
            drawShape2d(g, path, pen, points_projection[6], 0);
            drawShape2d(g, path, pen, points_projection[7], 1);
        }

        private void Draw_ax(Graphics g, int x, int y)
        {
            Pen pen = new Pen(Color.Black);
            Pen pen2 = new Pen(Color.Silver);
            pen2.DashStyle = DashStyle.Dash;

            //0X
            g.DrawLine(pen, x, 0, x, y);
            g.DrawLine(pen2, x, y, x, ClientSize.Height);
            //OY
            g.DrawLine(pen, x, y, ClientSize.Width, y);
            g.DrawLine(pen2, x, y, 0, y);
            //OZ
            g.DrawLine(pen, x, y, x - y * 2, ClientSize.Height);
            g.DrawLine(pen2, x, y, x + y * 2, 0);

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
        /*        private void radioButton1_CheckedChanged(object sender, EventArgs e)
                {
                    if ((sender as RadioButton).Checked)
                        RB_text = (sender as RadioButton).Text;
                }*/

        private void button1_Click(object sender, EventArgs e)
        {
            double[][] move = { new double[] {1, 0, 0, 0},
                               new double[]{0, 1, 0, 0},
                               new double[]{0, 0, 1, 0},
                              new double[] {1, 0, 0, 1}};
            vertices_3d = matrixMultiply(move);
            Invalidate();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            double[][] move = { new double[] {1, 0, 0, 0},
                              new double[] {0, 1, 0, 0},
                              new double[] {0, 0, 1, 0},
                              new double[] {-1, 0, 0, 1}};
            vertices_3d = matrixMultiply(move);
            Invalidate();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            double[][] move = { new double[] {1, 0, 0, 0},
                               new double[]{0, 1, 0, 0},
                               new double[]{0, 0, 1, 0},
                              new double[] {0,1, 0, 1}};
            vertices_3d = matrixMultiply(move);
            Invalidate();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            double[][] move = { new double[] {1, 0, 0, 0},
                               new double[]{0, 1, 0, 0},
                               new double[]{0, 0, 1, 0},
                              new double[] {0,-1, 0, 1}};
            vertices_3d = matrixMultiply(move);
            Invalidate();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            double[][] move = { new double[] {1, 0, 0, 0},
                               new double[]{0, 1, 0, 0},
                               new double[]{0, 0, 1, 0},
                              new double[] {0,0, 1, 1}};
            vertices_3d = matrixMultiply(move);
            Invalidate();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            double[][] move = { new double[] {1, 0, 0, 0},
                               new double[]{0, 1, 0, 0},
                               new double[]{0, 0, 1, 0},
                              new double[] {0,0, -1, 1}};
            vertices_3d = matrixMultiply(move);
            Invalidate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double[][] move = { new double[] {1, 0, 0, 0},
                               new double[]{0, -1, 0, 0},
                               new double[]{0, 0, 1, 0},
                              new double[] {0,0, 0, 1}};
            vertices_3d = matrixMultiply(move);
            Invalidate();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double[][] move = { new double[] {-1, 0, 0, 0},
                               new double[]{0, 1, 0, 0},
                               new double[]{0, 0, 1, 0},
                              new double[] {0,0, 0, 1}};
            vertices_3d = matrixMultiply(move);
            Invalidate();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double[][] move = { new double[] {1, 0, 0, 0},
                               new double[]{0, 1, 0, 0},
                               new double[]{0, 0, -1, 0},
                              new double[] {0,0, 0, 1}};
            vertices_3d = matrixMultiply(move);
            Invalidate();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out double fi))
            {
                MessageBox.Show(
                "Degree must be not empty. Ex: 1.5, 30",
                "Warning");
                return;
            }
            fi = fi * Math.PI / 180;
            double[][] matrix_OX = new double[][] {new double[] {1, 0, 0, 0},
                                                new double[] {0, Math.Cos(fi), Math.Sin(fi), 0},
                                                new double[] {0, -Math.Sin(fi), Math.Cos(fi), 0},
                                                new double[] {0, 0, 0, 1}};
            double[][] matrix_OY = new double[][] {new double[] {Math.Cos(fi), 0, -Math.Sin(fi), 0},
                                               new double[] { 0, 1, 0, 0},
                                               new double[] { Math.Sin(fi), 0, Math.Cos(fi), 0},
                                               new double[] { 0, 0, 0, 1}};
            double[][] matrix_OZ = new double[][] { new double[] {Math.Cos(fi), Math.Sin(fi), 0, 0},
                                              new double[] { -Math.Sin(fi), Math.Cos(fi), 0, 0},
                                               new double[]{ 0, 0, 1, 0},
                                              new double[] { 0, 0, 0, 1}};
            switch (axi_rot)
            {
                case 0:
                    vertices_3d = matrixMultiply(matrix_OX);
                    break;
                case 1:
                    vertices_3d = matrixMultiply(matrix_OY);
                    break;
                case 2:
                    vertices_3d = matrixMultiply(matrix_OZ);
                    break;
                default:
                    break;
            }
            vertices_3d = MatrixNorm(vertices_3d);
            Invalidate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "X rotate":
                    axi_rot = 0; break;
                case "Y rotate":
                    axi_rot = 1; break;
                case "Z rotate":
                    axi_rot = 2; break;
                default: axi_rot = 0; break;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Owner = this;
            form2.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            vertices_3d = vertices_3d_copy;
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Flat;
            button10.FlatAppearance.BorderSize = 0;
            button10.FlatStyle = FlatStyle.Flat;
            button11.FlatAppearance.BorderSize = 0;
            button11.FlatStyle = FlatStyle.Flat;
            button12.FlatAppearance.BorderSize = 0;
            button12.FlatStyle = FlatStyle.Flat;
            button13.FlatAppearance.BorderSize = 0;
            button13.FlatStyle = FlatStyle.Flat;
            button14.FlatAppearance.BorderSize = 0;
            button14.FlatStyle = FlatStyle.Flat;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            double[][] matrix = { new double[] {1, 0, 0, 0},
                                 new double[] {0, 1, 0, 0},
                                 new double[] {0, 0, 1, 0},
                                 new double[] {0, 0, 0, 0.835}};
            vertices_3d = matrixMultiply(matrix);
            vertices_3d = MatrixNorm(vertices_3d);
            Invalidate();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            double[][] matrix = { new double[] {1, 0, 0, 0},
                                 new double[] {0, 1, 0, 0},
                                 new double[] {0, 0, 1, 0},
                                 new double[] {0, 0, 0, 1.2}};
            vertices_3d = matrixMultiply(matrix);
            vertices_3d = MatrixNorm(vertices_3d);
            Invalidate();
        }
    }
}
