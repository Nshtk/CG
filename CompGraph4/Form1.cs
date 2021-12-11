using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompGraph4
{
    public partial class Form1 : Form
    {
        private List<string> custom_data = new List<string>();
        private GraphicsPath[] graphics_paths = new GraphicsPath[8];

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
            PreviewKeyDown += new PreviewKeyDownEventHandler(Form1_PreviewKeyDown);
            Shown += new EventHandler(Form1_Shown);
        }
        public Form1()
        {
            InitializeComponent();

            toolTip1.SetToolTip(textBox1, "Перечислите дополнительные данные через запятую. Данные используются в соответствии с порядком ключевых слов в текущем действии.");

            
            int half_height = pictureBox1.Height / 2, half_width = pictureBox1.Width / 2;
            int size_x_1 = 300, size_x_2 = 200, size_y_1 = 100, size_y_2 = 200;
            int x_1 = half_width - size_x_1 / 2, y_1 = half_height - size_y_1 / 2;
            int x_2 = half_width - size_x_2 / 2, y_2 = half_height - size_y_2 / 2;

            for (int i = 0; i < graphics_paths.Length; i++)
                graphics_paths[i] = new GraphicsPath();


            //PointF point1 = new PointF(190, 180), point2 = new PointF(100, 220), point3 = new PointF(100, 320), point4 = new PointF(160, 410), point5 = new PointF(250, 370), point6 = new PointF(250, 270);
            PointF[] polygon1 = new PointF[]
            {
                new PointF(190, 180),
                new PointF(100, 220),
                new PointF(100, 320),
                new PointF(160, 410),
                new PointF(250, 370),
                new PointF(250, 270)
            };
            PointF[] polygon2 = new PointF[]
            {
                polygon1[0],
                new PointF(polygon1[0].X+220, polygon1[0].Y-40),
                polygon1[1]
            };
            PointF[] polygon3 = new PointF[]
            {
                polygon1[0],
                polygon2[1],
                new PointF(polygon1[5].X+240, polygon1[5].Y+5),
                polygon1[5]
            };
            PointF[] polygon4 = new PointF[]
            {
                polygon1[5],
                polygon3[2],
                polygon1[4]
            };
            PointF[] polygon5 = new PointF[]
            {
                polygon1[4],
                polygon3[2],
                new PointF(polygon1[3].X+240, polygon1[3].Y+5),
                polygon1[3]
            };
            PointF[] polygon6 = new PointF[]
            {
                polygon1[2],
                polygon5[2],
                polygon1[3]
            };
            PointF[] polygon7 = new PointF[]
            {
                polygon1[1],
                polygon2[1],
                polygon5[2],
                polygon1[2]
            };
            PointF[] polygon8 = new PointF[]
            {
                polygon3[0],
                polygon3[1],
                polygon5[2]
            };
            
            List<PointF[]> polygons = new List<PointF[]>(){ polygon1, polygon2, polygon3, polygon4, polygon5, polygon6, polygon7 };
            for (int i = 0; i < polygons.Count; i++)
                graphics_paths[i].AddPolygon(polygons[i]);
        }
        private void Form1_Shown(Object sender, EventArgs e)
        {
            textBox1.Focus();
        }
        private bool getCustomData(uint number_of_parameters)
        {
            string str = textBox1.Text, buf = "";

            int length_minus_one = str.Length - 1;
            custom_data.Clear();
            for (int i = 0; i < str.Length; i++)
            {
                if ((Char.IsDigit(str[i]) || str[i] == '.') && str[i] != ' ' && str[i] != ',' && str[i] != '-')
                    buf += str[i];
                else if (str[i] != '.' && str[i] != ' ' && str[i] != ',' && str[i] != '-')
                {
                    MessageBox.Show("Данные введены в неверном формате.");
                    return false;
                }
                if (buf.Length != 0 && (str[i] == ',' || i == length_minus_one))
                    custom_data.Add(buf);
            }

            if (custom_data.Count != number_of_parameters)
            {
                MessageBox.Show("Данные не введены или введены неверно.");
                return false;
            }

            return true;
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }
        public void Form1_AxisShiftKeyDown(object sender, KeyEventArgs e)
        {
            int offset = 20;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    transformShape(1, 0, 0, 0, 1, 0, 0, -offset, 1);
                    break;
                case Keys.Down:
                    transformShape(1, 0, 0, 0, 1, 0, 0, offset, 1);
                    break;
                case Keys.Left:
                    transformShape(1, 0, 0, 0, 1, 0, -offset, 0, 1);
                    break;
                case Keys.Right:
                    transformShape(1, 0, 0, 0, 1, 0, offset, 0, 1);
                    break;
            }
        }
        public void Form1_AxisMirroringKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    transformShape(1, 0, 0, 0, -1, 0, 0, 400, 1);
                    break;
                case Keys.Down:
                    transformShape(1, 0, 0, 0, -1, 0, 0, 700, 1);
                    break;
                case Keys.Left:
                    transformShape(-1, 0, 0, 0, 1, 0, 500, 0, 1);
                    break;
                case Keys.Right:
                    transformShape(-1, 0, 0, 0, 1, 0, 1000, 0, 1);
                    break;
            }
        }
        public void Form1_EquationMirroringKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    transformShape(0, 1, 0, 1, 0, 0, 0, 0, 1);
                    break;
            }
        }
        public void Form1_ScalingKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    transformShape(1, 0, 0, 0, 1.4, 0, 0, -110, 1);
                    break;
                case Keys.Down:
                    transformShape(1, 0, 0, 0, 0.4, 0, 0, 160, 1);
                    break;
                case Keys.Left:
                    transformShape(0.4, 0, 0, 0, 1, 0, 210, 0, 1);
                    break;
                case Keys.Right:
                    transformShape(1.4, 0, 0, 0, 1, 0, -140, 0, 1);
                    break;
            }
        }
        public void Form1_CenterRotationKeyDown(object sender, KeyEventArgs e)
        {
            double angle, n, m;
            Double.TryParse(custom_data[0], out angle);

            angle = angle * Math.PI / 180;
            m = 371;
            n = 270;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    transformShape(Math.Cos(angle), Math.Sin(angle), 0, -Math.Sin(angle), Math.Cos(angle), 0, -m * (Math.Cos(angle) - 1) + n * Math.Sin(angle), -n * (Math.Cos(angle) - 1) - m * Math.Sin(angle), 0.01);
                    break;
                case Keys.Down:
                    transformShape(Math.Cos(-angle), Math.Sin(-angle), 0, -Math.Sin(-angle), Math.Cos(-angle), 0, -m * (Math.Cos(-angle) - 1) + n * Math.Sin(-angle), -n * (Math.Cos(-angle) - 1) - m * Math.Sin(-angle), 0.01);
                    break;
            }
        }
        public void Form1_CustomRotationKeyDown(object sender, KeyEventArgs e)
        {
            double angle, n, m;
            Double.TryParse(custom_data[0], out angle);
            Double.TryParse(custom_data[1], out m);
            Double.TryParse(custom_data[2], out n);

            angle = angle * Math.PI / 180;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    transformShape(Math.Cos(angle), Math.Sin(angle), 0, -Math.Sin(angle), Math.Cos(angle), 0, -m * (Math.Cos(angle) - 1) + n * Math.Sin(angle), -n * (Math.Cos(angle) - 1) - m * Math.Sin(angle), 0.01);
                    break;
                case Keys.Down:
                    transformShape(Math.Cos(-angle), Math.Sin(-angle), 0, -Math.Sin(-angle), Math.Cos(-angle), 0, -m * (Math.Cos(-angle) - 1) + n * Math.Sin(-angle), -n * (Math.Cos(-angle) - 1) - m * Math.Sin(-angle), 0.01);
                    break;
            }
        }

        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            int half_height = pictureBox1.Height / 2, half_width = pictureBox1.Width / 2;
            Pen pen = new Pen(Color.Black);
            pen.Width = 3;
            Graphics gr = e.Graphics;

            gr.Clear(Color.White);

            //gr.DrawLine(Pens.Black, half_width, 0, half_width, pictureBox1.Height);
            //gr.DrawLine(Pens.Black, 0, half_height, pictureBox1.Width, half_height);
           

            Region[] regions = new Region[graphics_paths.Length];
            for (int i = 0; i < graphics_paths.Length; i++)
                regions[i] = new Region(graphics_paths[i]);

            gr.FillRegion(Brushes.DarkRed, regions[1]);
            gr.FillRegion(Brushes.DarkRed, regions[4]);
            gr.FillRegion(Brushes.DarkRed, regions[5]);
            gr.FillRegion(Brushes.DarkRed, regions[6]);
            gr.FillRegion(Brushes.DarkRed, regions[7]);
            gr.FillRegion(Brushes.Red, regions[0]);
            gr.FillRegion(Brushes.IndianRed, regions[2]);
            gr.FillRegion(Brushes.IndianRed, regions[3]);
            for (int i = 0; i < graphics_paths.Length; i++)
                gr.DrawPath(pen, graphics_paths[i]);
        }
        private void matrixMultiply(ref PointF[] points, in double[,] transform_matrix)
        {
            double[,] result = new double[points.Length, 3];
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] += points[i].X * transform_matrix[0, j];
                    result[i, j] += points[i].Y * transform_matrix[1, j];
                    result[i, j] += 1 * transform_matrix[2, j];
                }
                points[i].X = (float)result[i, 0];
                points[i].Y = (float)result[i, 1];
            }
        }
        private void transformShape(double a, double b, int p, double c, double d, double q, double m, double n, double s)
        {
            double[,] transform_matrix = new double[3, 3]
            {
                {a,b,p},
                {c,d,q},
                {m,n,s}
            };

            PointF[] points;
            for (int i = 0; i < graphics_paths.Length; i++)
            {
                points = graphics_paths[i].PathPoints;
                matrixMultiply(ref points, in transform_matrix);
                graphics_paths[i] = new GraphicsPath(points, graphics_paths[i].PathTypes);
            }

            pictureBox1.Invalidate();
        }
        private void restoreDefaults()
        {
            textBox1.Text = "";
            label4.Text = "—";

            int half_height = pictureBox1.Height / 2, half_width = pictureBox1.Width / 2;
            int size_x_1 = 300, size_x_2 = 200, size_y_1 = 100, size_y_2 = 200;
            int x_1 = half_width - size_x_1 / 2, y_1 = half_height - size_y_1 / 2;
            int x_2 = half_width - size_x_2 / 2, y_2 = half_height - size_y_2 / 2;

            for (int i = 0; i < graphics_paths.Length; i++)
                graphics_paths[i].Reset();

            graphics_paths[0].AddEllipse(x_1, y_1, size_x_1, size_y_1);
            graphics_paths[1].AddEllipse(x_2, y_2, size_x_2, size_y_2);

            pictureBox1.Invalidate();
        }
        private void unsubscribeFromKeyEvent()
        {
            KeyDown -= Form1_AxisShiftKeyDown;
            KeyDown -= Form1_AxisMirroringKeyDown;
            KeyDown -= Form1_EquationMirroringKeyDown;
            KeyDown -= Form1_ScalingKeyDown;
            KeyDown -= Form1_CenterRotationKeyDown;
            KeyDown -= Form1_CustomRotationKeyDown;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Focus();
            unsubscribeFromKeyEvent();
            KeyPreview = true;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    label4.Text = "Стрелки: вверх, вниз, влево,\nвправо.";
                    KeyDown += Form1_AxisShiftKeyDown;
                    break;
                case 1:
                    label4.Text = "Стрелки: вверх, вниз, влево,\nвправо.";
                    KeyDown += Form1_AxisMirroringKeyDown;
                    break;
                case 2:
                    label4.Text = "Стрелки: вверх.";
                    KeyDown += Form1_EquationMirroringKeyDown;
                    break;
                case 3:
                    label4.Text = "Стрелки: вверх, вниз, влево,\nвправо.";
                    KeyDown += Form1_ScalingKeyDown;
                    break;
                case 6:
                    restoreDefaults();
                    break;
                default:
                    MessageBox.Show("Введите дополнительные данные и нажмите \"Принять\".");
                    label4.Text = "—";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 4:
                    if (getCustomData(1))
                    {
                        label4.Text = "Стрелки: вверх, вниз.";
                        KeyDown += Form1_CenterRotationKeyDown;
                    }
                    else
                        KeyDown -= Form1_CenterRotationKeyDown;
                    break;
                case 5:
                    if (getCustomData(3))
                    {
                        label4.Text = "Стрелки: вверх, вниз.";
                        KeyDown += Form1_CustomRotationKeyDown;
                    }
                    else
                        KeyDown -= Form1_CustomRotationKeyDown;
                    break;
            }
        }
    }
}
