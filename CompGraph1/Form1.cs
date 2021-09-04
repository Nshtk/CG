using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompGraph1
{
    public partial class Form1 : Form
    {
        double x, y;
        double teta_1 = 0.001, r_2 = 1, r_4 = 0.01;
        int a_1 = 50, a_3=10, b_3=10;
        Graphics gr;
        SolidBrush brush = new SolidBrush(Color.Red);
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex=0;
        }
        private void pictureBox1_Paint()
        {
            gr.FillEllipse(brush, (float)x, (float)y, 10, 10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop(); timer2.Stop(); timer3.Stop(); timer4.Stop();

            gr = pictureBox1.CreateGraphics();
            gr.Clear(Color.White);

            switch (comboBox1.SelectedItem)
            {
                case "Параболическая спираль":
                    timer1.Start();
                    break;
                case "Логарифмическая спираль":
                    timer2.Start();
                    break;
                case "Архимедова спираль":
                    timer3.Start();
                    break;
                case "Спираль Корню":
                    timer4.Start();
                    break;
                default:
                    System.Console.WriteLine(comboBox1.SelectedItem);
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int offset_x = pictureBox1.Width / 2, offset_y = pictureBox1.Height / 2;
            x = offset_x + Math.Sign(a_1) * Math.Abs(a_1) * Math.Pow(teta_1, 0.5) * Math.Cos(teta_1);
            y = offset_y + Math.Sign(a_1) * Math.Abs(a_1) * Math.Pow(teta_1, 0.5) * Math.Sin(teta_1);
            pictureBox1_Paint();
            x = offset_x - Math.Sign(a_1) * Math.Abs(a_1) * Math.Pow(teta_1, 0.5) * Math.Cos(teta_1);
            y = offset_y - Math.Sign(a_1) * Math.Abs(a_1) * Math.Pow(teta_1, 0.5) * Math.Sin(teta_1);
            pictureBox1_Paint();
            teta_1 += 0.01;
            if (y > pictureBox1.Height)
                timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int offset_x = pictureBox1.Width / 2, offset_y = pictureBox1.Height / 2;
            x = offset_x + r_2*Math.Cos(teta_1);
            y = offset_y + r_2*Math.Sin(teta_1);
            pictureBox1_Paint();
            teta_1 += 0.01;
            r_2+=0.2;
            if (y > pictureBox1.Height)
                timer2.Stop();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int offset_x = pictureBox1.Width / 2, offset_y = pictureBox1.Height / 2;
            x = offset_x + (a_3 + b_3 * teta_1) * Math.Cos(teta_1);
            y = offset_y + (a_3 + b_3 * teta_1) * Math.Sin(teta_1);
            pictureBox1_Paint();
            teta_1 += 0.01;
            if (y > pictureBox1.Height)
                timer3.Stop();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            int offset_x = 200, offset_y = 200;
            x = offset_x + r_4 * Math.Cos(teta_1);
            y = offset_y + r_4 * Math.Sin(teta_1);
            pictureBox1_Paint();
            offset_x = 561; offset_y = 330;
            x = offset_x - r_4 * Math.Cos(teta_1);
            y = offset_y - r_4 * Math.Sin(teta_1);
            pictureBox1_Paint();
            teta_1 += 0.01;
            r_4 += 0.1;
            if (teta_1>19.2)
                timer4.Stop();
        }
    }
}
