using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Lab6
{
    public partial class Form1 : Form
    {
        public void method_elips_run_triangl(ref PictureBox pictureBox) // метод движения круга
        {
            Graphics G = pictureBox.CreateGraphics();
            Color[] col = { Color.Red, Color.Green, Color.Gray, Color.Gold };
            Random rnd = new Random();
            
            Color color_in = col[rnd.Next(1,4)];
            for (int i = 0; i < 240; i++)
            {
                pictureBox.Refresh();
                G.FillEllipse(new SolidBrush(color_in), 280 - i, 260 - i, 40, 40);
                Thread.Sleep(1);
            }
            color_in = col[rnd.Next(1, 4)];
            for (int i = 0; i < 500; i++)
            {
                pictureBox.Refresh();
                G.FillEllipse(new SolidBrush(color_in), 40 + i, 20, 40, 40);
                Thread.Sleep(1);
            }
            color_in = col[rnd.Next(1, 4)];
            for (int i = 0; i < 240; i++)
            {
                pictureBox.Refresh();
                G.FillEllipse(new SolidBrush(color_in), 540 - i, 20 + i, 40, 40);
                Thread.Sleep(1);
            }                                 
        }
                          
        public Form1()
        {
            InitializeComponent();
        }


        Double xmin = -1, xmax = 2, ymin = -1, ymax = 1, hx, hy, mx, my;
        int ax1 = 50, ax2 = 50, ay1 = 0, ay2 = 0, d, c, sx=3, sy=3;
        Pen pn = new Pen(Color.Red, 3); // перо для графика
        Pen pn1 = new Pen(Color.Green, 3); // перо для сетки
        Pen pn2 = new Pen(Color.Black, 3); // перо для осей
        Font fn = new Font("Arial", 12);// шрифт для осей
        Font fn1 = new Font("Arial", 11);// шфрифт для засечек 

        private Double f(double x)// функция, граифк которой рисуется
        {
            return 7 * ((x * Math.Tan(x)) / 2);
        }

        private void Extrem() // расчет масштаба и смещения
        {
            mx = (d - ax1) / (ymax - xmin);//Масштаб по оси X
            my = (c - ay1) / (ymin - ymax);//Масштаю по оси Y
            sx = ax1 - Convert.ToInt32(mx * xmin);
            sy = ay1 - Convert.ToInt32(my * ymax);
        }



        private void grid_x(Graphics F)
        {
            double x;
            int i, n;
            x = xmin;
            n = Convert.ToInt32((xmax - xmin) / hx) + 1;
            for (i = 0; i <= n; i++)
            {
                F.DrawLine(pn2, Convert.ToInt32(x * mx) + sx,
                Convert.ToInt32(ymin * my) + sy,
                Convert.ToInt32(x * mx) + sx,
                Convert.ToInt32(ymax * my) + sy);
                x += hx;
            }
        }

        private void grid_y(Graphics F)
        {
            double y;
            int i, n;
            y = ymin;
            n = Convert.ToInt32((ymax - ymin) / hy) + 1;
            for (i = 1; i <= n; i++)
            {
                F.DrawLine(pn1, Convert.ToInt32(xmin * mx) + sx,
                Convert.ToInt32(y * my) + sy,
                Convert.ToInt32(xmax * mx) + sx,
                Convert.ToInt32(y * my) + sy);
                y += hy;
            }                       
        }

        private void axis_x(Graphics Graph)
        {
            Graph.DrawLine(pn2, Convert.ToInt32(xmin * mx) + sx, sy,
            Convert.ToInt32(xmax * mx) + sx, sy);
            Graph.DrawString("", fn, Brushes.Black,
            Convert.ToInt32(xmax * mx) + sx + 20, sy);
        }

        private void axis_y(Graphics Graph)
        {
            Graph.DrawLine(pn2, sx, Convert.ToInt32(ymin * my) + sy,
            sx, Convert.ToInt32(ymax * my) + sy);
            Graph.DrawString("Y", fn, Brushes.Black, sx - 20,
            Convert.ToInt32(ymax * my) + sy);
        }


        private void z_x(Graphics F)
        {
            for (double i = xmin; i <= xmax; i += hx)
            {
                F.DrawLine(pn2, Convert.ToInt32(i * mx) + sx,
                sy, Convert.ToInt32(i * mx) + sx, 5 + sy);
                F.DrawString(Convert.ToString(i), fn1,
                Brushes.Black, Convert.ToInt32(i * mx) + sx - 60, 2 + sy);
            }
        }

        private void z_y(Graphics F)
        {
            for (double i = ymin; i <= ymax; i += hy)
            {
                F.DrawLine(pn2, sx,
                Convert.ToInt32(i * my) + sy, 5 + sx,
                Convert.ToInt32(i * my) + sy);
                if (i != 0) F.DrawString(Convert.ToString(i),
                fn1, Brushes.Black, 3 + sx,
                Convert.ToInt32(i * my) + sy);
            }
        }

               
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            method_elips_run_triangl(ref pictureBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics F = pictureBox1.CreateGraphics();
            double h;
            pictureBox1.Refresh();
            ax1 = 30; ay1 = 20; ax2 = 30; ay2 = 15;
            c = pictureBox1.Size.Height - ay1 - ay2;
            d = pictureBox1.Size.Width - ax1 - ax2;
            xmin = Convert.ToDouble(textBox1.Text);
            xmax = Convert.ToDouble(textBox2.Text);
            ymin = Convert.ToDouble(textBox3.Text);
            ymax = Convert.ToDouble(textBox4.Text);
            hx = Convert.ToDouble(textBox5.Text);
            hy = Convert.ToDouble(textBox6.Text);
            Extrem();
            grid_x(F);
            grid_y(F);
            axis_x(F);
            axis_y(F);
            z_x(F); z_y(F);
            h = 0.001;
            for (double x = -1; x <= 1; x += h)
                F.DrawLine(pn, Convert.ToInt32(x * mx) + sx,
                Convert.ToInt32(f(x) * my) + sy,
                Convert.ToInt32((x + h) * mx) + sx,
                Convert.ToInt32(f(x + h) * my) + sy);
        }
    }
}
