using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        Color[] col = { Color.Red, Color.Green,Color.Gray,Color.Gold};
        //Int32 x = 250, y = 250;

        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = this.CreateGraphics();
            //G.FillEllipse(new SolidBrush(col[1]), x, y, 40, 40);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics G = pictureBox1.CreateGraphics();
            for (int x = 30; x<150;x++ )
            {
                pictureBox1.Refresh();
                G.FillEllipse(new SolidBrush(col[1]), x, 40, 40, 40);

            }

        }
    }
}
