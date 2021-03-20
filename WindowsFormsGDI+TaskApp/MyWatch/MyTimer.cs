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
    public partial class MyTimer : Form
    {
        public int MiddleX { get; set; }
        public int MiddleY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private readonly int Sec = 135;
        private readonly int Min = 100;
        private readonly int Hour = 80;

        public Tuple<int,int> HandCoord { get; set; }
        public MyTimer()
        {
            InitializeComponent();
            Width = 380;
            Height = 350;

            MiddleX = Width / 2;
            MiddleY = Height / 2;


            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
            int second = DateTime.Now.Second;
            int minute = DateTime.Now.Minute;
            int hour = DateTime.Now.Hour;

            
            e.Graphics.DrawEllipse(new Pen(Color.Black, 6f), 0, 0, 370, 350);

            e.Graphics.Clear(Color.Aqua);

            Font font = new Font("Ariel", 21);
            e.Graphics.DrawRectangle(new Pen(Color.Black, 6f), 30,10, 340, 340);
            e.Graphics.DrawString("12", new Font("Ariel", 25,FontStyle.Bold), Brushes.Black, new PointF(180, 23));
            e.Graphics.DrawString("1", font, Brushes.Black, new PointF(258, 42));
            e.Graphics.DrawString("2", font, Brushes.Black, new PointF(303, 90));
            e.Graphics.DrawString("3", new Font("Ariel", 25, FontStyle.Bold), Brushes.Black, new PointF(325, 160));
            e.Graphics.DrawString("4", font, Brushes.Black, new PointF(303, 232));
            e.Graphics.DrawString("5", font, Brushes.Black, new PointF(258, 279));
            e.Graphics.DrawString("6", new Font("Ariel", 25, FontStyle.Bold), Brushes.Black, new PointF(182, 299));
            e.Graphics.DrawString("7", font, Brushes.Black, new PointF(110, 279));
            e.Graphics.DrawString("8", font, Brushes.Black, new PointF(62, 232));
            e.Graphics.DrawString("9", new Font("Ariel", 25, FontStyle.Bold), Brushes.Black, new PointF(41, 160));
            e.Graphics.DrawString("10", font, Brushes.Black, new PointF(62, 90));
            e.Graphics.DrawString("11", font, Brushes.Black, new PointF(110, 42));

            
            HandCoord = SecundLocation(second, Sec);
            e.Graphics.DrawLine(new Pen(Color.Gold, 2), new Point(MiddleX, MiddleY), new Point(HandCoord.Item1, HandCoord.Item2));

            
            HandCoord = SecundLocation(minute, Min);
            e.Graphics.DrawLine(new Pen(Color.White, 3), new Point(MiddleX, MiddleY), new Point(HandCoord.Item1, HandCoord.Item2));

            
            HandCoord = HourLocation(hour % 12, minute);
            e.Graphics.DrawLine(new Pen(Color.White, 3), new Point(MiddleX, MiddleY), new Point(HandCoord.Item1, HandCoord.Item2));



        }

        private Tuple<int,int> SecundLocation(int val, int hlen)
        {
            val *= 6; // 360* / 60(sekcii) =6* (rastoyanie mejdu kajdoy sekcii)

            if (val >= 0 && val <= 100)
            {
                HandCoord = new Tuple<int, int>(
                    MiddleX + (int)(hlen * Math.Sin(Math.PI * val / 180)),
                    MiddleY - (int)(hlen * Math.Cos(Math.PI * val / 180)));               
            }
            else
            {
                HandCoord = new Tuple<int, int>(
                   MiddleX - (int)(hlen * -Math.Sin(Math.PI * val / 180)),
                   MiddleY - (int)(hlen * Math.Cos(Math.PI * val / 180)));
            }
            return HandCoord;


            if (val >= 0 && val <= 180)
            {
                HandCoord = new Tuple<int, int>(
                      MiddleX + (int)(hlen * Math.Sin(Math.PI * val / 180)),
                      MiddleY - (int)(hlen * Math.Cos(Math.PI * val / 180)));
            }
            else
            {
                HandCoord = new Tuple<int, int>(
                   MiddleX - (int)(hlen * -Math.Sin(Math.PI * val / 180)),
                   MiddleY - (int)(hlen * Math.Cos(Math.PI * val / 180)));
            }
            return HandCoord;
        }


        private Tuple<int, int> HourLocation(int hval, int mval)
        {
            int val = (int)((hval * 30) + (mval * 0.5));

            if (val >= 0 && val <= 180)
            {
                HandCoord = new Tuple<int, int>(
                    MiddleX + (int)(Hour * Math.Sin(Math.PI * val / 180)),
                    MiddleY - (int)(Hour * Math.Cos(Math.PI * val / 180)));
            }
            else
            {
                HandCoord = new Tuple<int, int>(
                  MiddleX - (int)(Hour * -Math.Sin(Math.PI * val / 180)),
                  MiddleY - (int)(Hour * Math.Cos(Math.PI * val / 180)));
            }
            return HandCoord;
        }
    }
}
