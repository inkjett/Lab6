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
        Int32 x = 10, y = 10;
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = this.CreateGraphics();
            Pen P1 = new Pen(Color.Red, 3);
            G.DrawRectangle(P1, 70, 50, 150, 100);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
   
        }

        private void button1_Click(object sender, EventArgs e)
        {



        }
    }
}
