using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsGDI_TaskApp
{
    public partial class Labyrinth : Form
    {
        public Labyrinth()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int with = this.Width / 12;
            int height = this.Height / 12;

            Pen pen = new Pen(Color.Black, 5);

            e.Graphics.DrawLine(pen, 0, height, 0, Height);
            e.Graphics.DrawLine(pen, with * 12 - 14, 0, with * 12 - 14, height * 9);
            e.Graphics.DrawLine(pen, with * 12 - 12, height * 10, with * 12 - 12, height * 13);
            e.Graphics.DrawLine(pen, 0, 2, Width, 2);
            e.Graphics.DrawLine(pen, 0, height * 12 - 37, with * 12, height * 12 - 37);
            e.Graphics.DrawLine(pen, with * 1, height * 2, with * 1, height * 9);
            e.Graphics.DrawLine(pen, with, height * 1, with * 10 + 10, height * 1);
            e.Graphics.DrawLine(pen, with, height * 10, with * 9 + 10, height * 10);
            e.Graphics.DrawLine(pen, with * 10 + 10, height * 1, with * 10 + 10, height * 9);
            e.Graphics.DrawLine(pen, with * 10 + 10, height * 9, with * 12 + 10, height * 9);
            e.Graphics.DrawLine(pen, with * 9 + 10, height * 2, with * 9 + 10, height * 10);
            e.Graphics.DrawLine(pen, with, height * 9, with * 7 + 10, height * 9);
            e.Graphics.DrawLine(pen, with * 8 + 10, height * 1, with * 8 + 10, height * 5);
            e.Graphics.DrawLine(pen, with * 8 + 10, height * 6, with * 8 + 10, height * 9);
            e.Graphics.DrawLine(pen, with * 8 + 10, height * 9, with * 9 + 10, height * 9);
            e.Graphics.DrawLine(pen, with * 2, height * 6, with * 8 + 10, height * 6);
            e.Graphics.DrawLine(pen, with * 3, height * 5, with * 8 + 10, height * 5);
            e.Graphics.DrawLine(pen, with * 2, height * 4, with * 2, height * 6);
            e.Graphics.DrawLine(pen, with * 2, height * 4, with * 7 + 10, height * 4);
            e.Graphics.DrawLine(pen, with * 7 + 10, height * 2, with * 7 + 10, height * 4);
            e.Graphics.DrawLine(pen, with * 6 + 10, height * 1, with * 6 + 10, height * 3);
            e.Graphics.DrawLine(pen, with * 1, height * 3, with * 6 + 10, height * 3);
            e.Graphics.DrawLine(pen, with * 1, height * 2, with * 5 + 10, height * 2);
            e.Graphics.DrawLine(pen, with * 2, height * 7, with * 7 + 10, height * 7);
            e.Graphics.DrawLine(pen, with * 7 + 10, height * 7, with * 7 + 10, height * 9);
            e.Graphics.DrawLine(pen, with * 1, height * 8, with * 6 + 10, height * 8);
            e.Graphics.DrawLine(pen, with * 5 + 10, height * 10, with * 5 + 10, height * 12);
            e.Graphics.DrawLine(pen, with * 10 + 10, height * 10, with * 12 + 10, height * 10);
            e.Graphics.DrawLine(pen, with * 9 + 10, height * 2, with * 9 + 10, height * 9);
        }

        private void Labyrinth_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
