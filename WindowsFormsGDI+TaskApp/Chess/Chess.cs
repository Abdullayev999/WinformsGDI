using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;

namespace WindowsFormsGDI_TaskApp
{
    public partial class Chess : Form
    {
        public Brush Brush { get; set; }
        public Color ColorShape { get; set; }
        public Color ColorBoardFrame { get; set; }

        public HashSet<object> Shape { get; set; }
        public Chess()
        {
            InitializeComponent();
            Shape = new HashSet<object>();
            InitializeShapes();


            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (ColorShape == Color.LightYellow)  ColorShape = Color.Black;            
            else ColorShape = Color.LightYellow;
            
            Brush = new SolidBrush(ColorShape);

            var Graphics = this.CreateGraphics();

            foreach (var item in Shape)
            {
                if (item is Rectangle rectangle) Graphics.FillRectangle(Brush, rectangle);                
                else if (item is RectangleF Ellipse) Graphics.FillEllipse(Brush, Ellipse);                
            }

            if (ColorBoardFrame == Color.Black)  ColorBoardFrame = Color.Brown;
            else ColorBoardFrame = Color.Black;
            
            Brush = new SolidBrush(ColorBoardFrame);
            Pen pen = new Pen(Brush, 10);
            Graphics.DrawLine(pen, 20, 19, Width - 140, 19);
            Graphics.DrawLine(pen, 20, Height - 135, Width - 140, Height - 135);
            Graphics.DrawLine(pen, 19, 14, 19, Height - 130);
            Graphics.DrawLine(pen, Width - 136, 14, Width - 136, Height - 130);
        }

        protected override void OnPaint(PaintEventArgs e)
        {           
            int width = this.Width / 8 - 20;
            int height = this.Height / 8 - 20;

            Brush = new SolidBrush(Color.Black);

            for (int a = 0, otstup = 25; a < 8; a++)
            {
                for (int b = 1; b < 8; b += 2)
                {
                    e.Graphics.FillRectangle(Brush, width * b + otstup, height * a + otstup, width, height);
                    System.Threading.Thread.Sleep(45);
                }
                a++;
                for (int c = 0; c < 7; c += 2)
                {
                    e.Graphics.FillRectangle(Brush, width * c + otstup, height * a + otstup, width, height);
                    System.Threading.Thread.Sleep(45);
                }
                System.Threading.Thread.Sleep(45);
            }

            Brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(Brush, 10);
            e.Graphics.DrawLine(pen, 20, 19, Width - 140, 19);
            e.Graphics.DrawLine(pen, 20, Height - 135, Width - 140, Height - 135);
            e.Graphics.DrawLine(pen, 19, 14, 19, Height - 130);
            e.Graphics.DrawLine(pen, Width - 136, 14, Width - 136, Height - 130);



            e.Graphics.DrawString("A", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(45, 2));
            e.Graphics.DrawString("B", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(90, 2));
            e.Graphics.DrawString("C", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(140, 2));
            e.Graphics.DrawString("D", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(190, 2));
            e.Graphics.DrawString("E", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(240, 2));
            e.Graphics.DrawString("F", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(290, 2));
            e.Graphics.DrawString("G", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(340, 2));
            e.Graphics.DrawString("H", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(390, 2));

            e.Graphics.DrawString("A", new Font("Ariel", 5, FontStyle.Bold), Brushes.Black, new PointF(45, 260));
            e.Graphics.DrawString("B", new Font("Ariel", 5, FontStyle.Bold), Brushes.Black, new PointF(90, 260));
            e.Graphics.DrawString("C", new Font("Ariel", 5, FontStyle.Bold), Brushes.Black, new PointF(140,260));
            e.Graphics.DrawString("D", new Font("Ariel", 5, FontStyle.Bold), Brushes.Black, new PointF(190,260));
            e.Graphics.DrawString("E", new Font("Ariel", 5, FontStyle.Bold), Brushes.Black, new PointF(240,260));
            e.Graphics.DrawString("F", new Font("Ariel", 5, FontStyle.Bold), Brushes.Black, new PointF(292,260));
            e.Graphics.DrawString("G", new Font("Ariel", 5, FontStyle.Bold), Brushes.Black, new PointF(340,260));
            e.Graphics.DrawString("H", new Font("Ariel", 5, FontStyle.Bold), Brushes.Black, new PointF(390,260));


            e.Graphics.DrawString("1", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(2, 30));
            e.Graphics.DrawString("2", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(2, 60));
            e.Graphics.DrawString("3", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(2, 90));
            e.Graphics.DrawString("4", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(2, 117));
            e.Graphics.DrawString("5", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(2, 145));
            e.Graphics.DrawString("6", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(2, 173));
            e.Graphics.DrawString("7", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(2, 200));
            e.Graphics.DrawString("8", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(2, 230));

            e.Graphics.DrawString("1", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(430, 30));
            e.Graphics.DrawString("2", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(430, 60));
            e.Graphics.DrawString("3", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(430, 90));
            e.Graphics.DrawString("4", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(430, 117));
            e.Graphics.DrawString("5", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(430, 145));
            e.Graphics.DrawString("6", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(430, 173));
            e.Graphics.DrawString("7", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(430, 200));
            e.Graphics.DrawString("8", new Font("Ariel", 7, FontStyle.Bold), Brushes.Black, new PointF(430, 230));


            Brush = new SolidBrush(ColorShape);

            foreach (var item in Shape)
            {
                if (item is Rectangle rectangle)
                {
                    e.Graphics.FillRectangle(Brush, rectangle);
                }
                else if (item is RectangleF Ellipse)
                {
                    e.Graphics.FillEllipse(Brush, Ellipse);
                }
            }            
        }


        public void InitializeShapes()
        {
            Shape.Add(new RectangleF(10, Height - 68, 50, 20));
            Shape.Add(new RectangleF(10, Height - 57, 50, 12));
            Shape.Add(new RectangleF(10, Height - 72, 50, 20));
            Shape.Add(new RectangleF(27, Height - 125, 15, 80));
            Shape.Add(new RectangleF(22, Height - 125, 25, 30));
            Shape.Add(new RectangleF(20, Height - 99, 30, 15));

            Shape.Add(new RectangleF(85, Height - 68, 70, 20));
            Shape.Add(new RectangleF(85, Height - 57, 70, 12));
            Shape.Add(new RectangleF(90, Height - 72, 60, 20));
            Shape.Add(new RectangleF(102, Height - 110, 36, 45));
            Shape.Add(new RectangleF(22, Height - 125, 25, 30));
            Shape.Add(new Rectangle(103, Height - 110, 35, 23));

            Shape.Add(new Rectangle(103, Height - 120, 5, 20));
            Shape.Add(new Rectangle(113, Height - 120, 5, 20));
            Shape.Add(new Rectangle(123, Height - 120, 5, 20));
            Shape.Add(new Rectangle(133, Height - 120, 5, 20));

            Shape.Add(new RectangleF(180, Height - 68, 50, 20));
            Shape.Add(new RectangleF(180, Height - 57, 50, 12));
            Shape.Add(new RectangleF(180, Height - 72, 50, 20));

            Shape.Add(new Rectangle(185, Height - 110, 15, 50));
            Shape.Add(new Rectangle(186, Height - 114, 5, 10));
            Shape.Add(new Rectangle(188, Height - 116, 5, 10));
            Shape.Add(new Rectangle(190, Height - 118, 5, 10));
            Shape.Add(new Rectangle(192, Height - 120, 5, 10));
            Shape.Add(new Rectangle(194, Height - 122, 8, 10));
            Shape.Add(new Rectangle(196, Height - 122, 8, 10));
            Shape.Add(new Rectangle(194, Height - 112, 31, 20));
            Shape.Add(new RectangleF(190, Height - 90, 20, 21));
            Shape.Add(new RectangleF(200, Height - 80, 20, 25));

            /////////////////////////////////////////////////////////////////

            Shape.Add(new RectangleF(260, Height - 68, 46, 20));
            Shape.Add(new RectangleF(260, Height - 57, 46, 12));
            Shape.Add(new RectangleF(277, Height - 125, 14, 80));
            Shape.Add(new RectangleF(271, Height - 127, 26, 30));
            Shape.Add(new RectangleF(270, Height - 96, 28, 10));

            Shape.Add(new RectangleF(270, Height - 81, 28, 15));
            Shape.Add(new RectangleF(270, Height - 79, 28, 15));
            Shape.Add(new RectangleF(270, Height - 76, 28, 15));
            Shape.Add(new RectangleF(265, Height - 73, 40, 15));

            /////////////////////////////////////////////////////////////////

            Shape.Add(new RectangleF(330, Height - 68, 50, 20));
            Shape.Add(new RectangleF(330, Height - 57, 50, 12));
            Shape.Add(new RectangleF(347, Height - 124, 15, 80));

            Shape.Add(new RectangleF(349, Height - 129, 10, 10));
            Shape.Add(new RectangleF(337, Height - 123, 35, 30));
            Shape.Add(new RectangleF(340, Height - 96, 30, 10));

            Shape.Add(new RectangleF(340, Height - 81, 30, 15));
            Shape.Add(new RectangleF(340, Height - 79, 30, 15));
            Shape.Add(new RectangleF(340, Height - 76, 30, 15));
            Shape.Add(new RectangleF(335, Height - 73, 40, 15));


            /////////////////////////////////////////////////////////////////

            Shape.Add(new RectangleF(Width - 110, Height - 68, 90, 20));
            Shape.Add(new RectangleF(Width - 110, Height - 57, 90, 12));
            Shape.Add(new RectangleF(Width - 85, Height - 156, 35, 110));


            Shape.Add(new RectangleF(Width - 100, Height - 80, 70, 20));
            Shape.Add(new RectangleF(Width - 85, Height - 156, 35, 15));
            Shape.Add(new RectangleF(Width - 85, Height - 166, 35, 15));
            Shape.Add(new Rectangle(Width - 74, Height - 246, 15, 55));
            Shape.Add(new Rectangle(Width - 88, Height - 235, 44, 15));
            Shape.Add(new RectangleF(Width - 90, Height - 195, 45, 35));
            Shape.Add(new RectangleF(Width - 85, Height - 206, 35, 15));
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = $" X = {e.X}   Y = {e.Y}";
        }

    }
}
