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
        double x, y, teta_1, r_2, r_4;
        int offset_x, offset_y, a_1, a_3, b_3;
        Graphics gr;
        SolidBrush brush = new SolidBrush(Color.Red);

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex=0;
        }
        private void pictureboxPaint()
        {
            gr.FillEllipse(brush, (float)x, (float)y, 10, 10);
        }
        private void timerStop(ref Timer t)
        {
            t.Stop();
            teta_1 = 0.001; r_2 = 1; r_4 = 0.01;
            a_1 = 50; a_3 = 10; b_3 = 10;
        }
        private void checkAndStop(ref Timer t, double a, double b, bool compare_mode)
        {
            if(!compare_mode)
            {
                if (a >= b)
                    timerStop(ref t);
            }
            else
            {
                if (a < b)
                    timerStop(ref t);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timerStop(ref timer1); timerStop(ref timer2); timerStop(ref timer3); timerStop(ref timer4); ;

            gr=pictureBox1.CreateGraphics();
            gr.Clear(Color.White);

            switch (comboBox1.SelectedItem)
            {
                case "Параболическая спираль":
                    offset_x = pictureBox1.Width / 2; offset_y = pictureBox1.Height / 2;
                    timer1.Start();
                    break;
                case "Логарифмическая спираль":
                    offset_x = pictureBox1.Width / 2; offset_y = pictureBox1.Height / 2;
                    timer2.Start();
                    break;
                case "Архимедова спираль":
                    offset_x = pictureBox1.Width / 2; offset_y = pictureBox1.Height / 2;
                    timer3.Start();
                    break;
                case "Спираль Корню":
                    timer4.Start();
                    break;
                default:
                    MessageBox.Show("Фигура не выбрана.");
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x = offset_x + Math.Sign(a_1) * Math.Abs(a_1) * Math.Pow(teta_1, 0.5) * Math.Cos(teta_1);
            y = offset_y + Math.Sign(a_1) * Math.Abs(a_1) * Math.Pow(teta_1, 0.5) * Math.Sin(teta_1);
            pictureboxPaint();
            x = offset_x - Math.Sign(a_1) * Math.Abs(a_1) * Math.Pow(teta_1, 0.5) * Math.Cos(teta_1);
            y = offset_y - Math.Sign(a_1) * Math.Abs(a_1) * Math.Pow(teta_1, 0.5) * Math.Sin(teta_1);
            pictureboxPaint();
            teta_1 += 0.01;
            checkAndStop(ref timer1, y, pictureBox1.Height, false);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            x = offset_x + r_2*Math.Cos(teta_1);
            y = offset_y + r_2*Math.Sin(teta_1);
            pictureboxPaint();
            teta_1 += 0.01;
            r_2+=0.2;
            checkAndStop(ref timer2, y, pictureBox1.Height, false);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            x = offset_x + (a_3 + b_3 * teta_1) * Math.Cos(teta_1);
            y = offset_y + (a_3 + b_3 * teta_1) * Math.Sin(teta_1);
            pictureboxPaint();
            teta_1 += 0.01;
            checkAndStop(ref timer3, y, pictureBox1.Height, false);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            offset_x = 200; offset_y = 200;
            x = offset_x + r_4 * Math.Cos(teta_1);
            y = offset_y + r_4 * Math.Sin(teta_1);
            pictureboxPaint();
            offset_x = 561; offset_y = 330;
            x = offset_x - r_4 * Math.Cos(teta_1);
            y = offset_y - r_4 * Math.Sin(teta_1);
            pictureboxPaint();
            teta_1 += 0.01;
            r_4 += 0.1;
            checkAndStop(ref timer3, teta_1, 19.2, false);
        }
    }
}
