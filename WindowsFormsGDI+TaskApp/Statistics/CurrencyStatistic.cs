using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsGDI_TaskApp.Statistics
{

    public partial class CurrencyStatistic : Form
    {
        public Point OldLocationDollar;
        public Point OldLocationManat;
        public Point OldLocationEUR;
        public int WidthFormHalf { get; set; }
        public int HeightFormHalf { get; set; }
        public Random Random { get; set; }
        public Course Course { get; set; }
        public DateTime DateTime { get; set; }

        public CurrencyStatistic()
        {
            InitializeComponent();

            DateTime = DateTime.Now;
            Random = new Random();
            RefreshCoordinat();


            try
            {
                WebClient webClient = new WebClient();
                string str = webClient.DownloadString(@"https://www.cbr-xml-daily.ru/daily_json.js");
                Course = JsonSerializer.Deserialize<Course>(str);
            }
            catch (Exception) {   }


            Timer Timer = new Timer();
            Timer.Interval = 9000;
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        public void RefreshCoordinat()
        {
            WidthFormHalf = Width / 2;
            HeightFormHalf = Height / 2;

            OldLocationDollar = new Point(2, HeightFormHalf);
            OldLocationManat = new Point(2, HeightFormHalf);
            OldLocationEUR = new Point(2, HeightFormHalf);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            NewCordinat(ref OldLocationDollar, Course.Valute.USD, labelDollar, Color.Green);   
            NewCordinat(ref OldLocationManat, Course.Valute.AZN, labelManat, Color.Black);
            NewCordinat(ref OldLocationEUR, Course.Valute.EUR, labelEUR, Color.Red);
        }

        public void NewCordinat(ref Point OldLocation,Money money,Label label, Color color)
        {
            bool cursUp=false;
            int x = Random.Next(OldLocation.X, OldLocation.X + 15);
            int y = Random.Next(HeightFormHalf - 50, HeightFormHalf  + 50);

            if (y < OldLocation.Y)
            {
                label.Text = "🔼";
                label.ForeColor = Color.Green;
                cursUp = true;
            }
            else
            {
                label.Text = "🔽";
                label.ForeColor = Color.Red;
                cursUp = false;
            }


            RefreshCurs(money,cursUp);

            var graphics = this.CreateGraphics() ;
            Point NewValuta = new Point(x, y);
            graphics.DrawLine(new Pen(color, 2), OldLocation, NewValuta);
            OldLocation = NewValuta;

           
            labelTime.Text = "Date : " + DateTime.ToShortDateString() ;
            DateTime = DateTime.AddDays(4);
        }


        // vizualnaya cast
        public void RefreshCurs(Money money, Boolean cursUp)
        {
            if (money is AZN azn)
            {               
                if (cursUp)
                {
                    azn.Value += 0.73F; ;
                    LabelManatMoney.Text = "+ "+ Math.Round(azn.Value, 2);
                }
                else
                {
                    azn.Value -= 0.67F; ;
                    LabelManatMoney.Text = "- " + Math.Round(azn.Value, 2);
                }
            }
            else if (money is USD usd)
            {
                if (cursUp)
                {
                    usd.Value += 0.73F; ;
                    LabelDollarMoney.Text = "+ " + Math.Round(usd.Value, 2);
                }
                else
                {
                    usd.Value -= 0.77F; ;
                    LabelDollarMoney.Text = "- " + Math.Round(usd.Value, 2);
                }
            }
            else if (money is EUR eur)
            {
                if (cursUp)
                {
                    eur.Value += 0.73F; ;
                    LabelEuroMoney.Text = "+ " + Math.Round(eur.Value, 2);
                }
                else
                {
                    eur.Value -= 0.67F; ;
                    LabelEuroMoney.Text = "- " + Math.Round(eur.Value, 2);
                }
            }
        }

        private void CurrencyStatistic_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
            RefreshCoordinat();
        }
    }
}
