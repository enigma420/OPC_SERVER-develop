using System.Drawing.Drawing2D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPCServer1.Frontend.Visualization
{
    public partial class WeightIndicator : UserControl
    {

       

       
        
        #region zmienne programu
        private float valueActual = 0;
        private float valueMin = 0;
        private float valueMax = 100;
        private float tipWidth = 2.0f;
        private Color tipColor = Color.Red;
        private Color circleColor = Color.Black;
        private Color backgroundColor = Color.White;
        private Font controlFont = new Font("Arial", 8, FontStyle.Italic);

        public WeightIndicator()
        {
            InitializeComponent();
        }

        #endregion

        #region właściwości kontrolki

        [Browsable(true), Category("Ustawienia"), Description("wartość minimalna")]
        public float valuemin
        {
            get { return valueMin; }
            set
            {
                if (valuemin != value)
                {
                    valueMin = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true), Category("Ustawienia"), Description("wartość maksymalna")]
        public float valuemax
        {
            get { return valueMax; }
            set
            {
                if (valuemax != value)
                {
                    valueMax = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true), Category("Ustawienia"), Description("szerokość wskazówki")]
        public float tipwidth
        {
            get { return tipWidth; }
            set
            {
                if (tipwidth != value)
                {
                    tipWidth = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true), Category("Ustawienia"), Description("wartość aktualna")]
        public float valueactual
        {
            get { return valueActual; }
            set
            {
                if (valueactual != value)
                {
                    valueActual = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true), Category("Ustawienia"), Description("kolor wskazówki")]
        public Color tipcolor
        {
            get { return tipColor; }
            set
            {
                if (tipcolor != value)
                {
                    tipColor = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true), Category("Ustawienia"), Description("kolor tła")]
        public Color backgroundcolor
        {
            get { return backgroundColor; }
            set
            {
                if (backgroundcolor != value)
                {
                    backgroundColor = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true), Category("Ustawienia"), Description("kolor wskazówki")]
        public Color circlecolor
        {
            get { return circleColor; }
            set
            {
                if (circlecolor != value)
                {
                    circleColor = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true), Category("Ustawienia"), Description("wartość aktualna")]
        public Font controlfont
        {
            get { return controlFont; }
            set
            {
                if (controlfont != value)
                {
                    controlFont = value;
                    Invalidate();
                }
            }
        }
        #endregion



        protected override void OnPaint(PaintEventArgs e)
        {
            //tutaj będziemy rysować kontrolkę
            this.Height = this.Width;

            try
            {
                float x_max = this.ClientRectangle.Width - 10;
                float y_max = this.ClientRectangle.Height - 10;
                int xb = 5;
                int yb = 5;

                Pen penCircleBlackThick = new Pen(circleColor, 2.0f);
                Pen penTip = new Pen(tipColor, tipWidth);

                Point center = new Point(this.ClientRectangle.Width / 2, this.ClientRectangle.Height / 2);
                Point tipBase = new Point(xb, this.ClientRectangle.Height / 2);

                SolidBrush brushBackground = new SolidBrush(backgroundColor);
                base.OnPaint(e);

                //wygładzamy kontrolkę
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                //wyrysowanie tła i obwódki
                e.Graphics.FillEllipse(brushBackground, xb, yb, x_max, y_max);
                e.Graphics.DrawEllipse(penCircleBlackThick, xb, yb, x_max, y_max);

                //wyrysowanie wartości aktualnej pod osią wskazówki
                StringFormat formatCenter = new StringFormat();
                formatCenter.Alignment = StringAlignment.Center;

                e.Graphics.DrawString("" + valueActual, controlFont, new SolidBrush(Color.Black), center.X, center.Y + 5, formatCenter);

                //wyrysowanie skali i wypisanie wartości
                int step = (int)((valueMax - valueMin) / 10);
                int value = 0;

                for (int i = 180; i <= 360; i++)
                {
                    if (i % 18 == 0)
                    {
                        double x1 = center.X - 10 * Math.Cos(degToRad(i)) + x_max / 2 * Math.Cos(degToRad(i));
                        double y1 = center.Y - 10 * Math.Sin(degToRad(i)) + y_max / 2 * Math.Sin(degToRad(i));
                        double x2 = center.X + x_max / 2 * Math.Cos(degToRad(i));
                        double y2 = center.Y + y_max / 2 * Math.Sin(degToRad(i));

                        double xt = center.X - 20 * Math.Cos(degToRad(i)) + x_max / 2 * Math.Cos(degToRad(i));
                        double yt = center.Y - 20 * Math.Sin(degToRad(i)) + y_max / 2 * Math.Sin(degToRad(i));

                        e.Graphics.DrawLine(penCircleBlackThick, new Point((int)x1, (int)y1), new Point((int)x2, (int)y2));
                        e.Graphics.DrawString("" + value, controlFont, new SolidBrush(Color.Black), (int)xt, (int)yt, formatCenter);
                        value += step;
                    }

                }

                //wyrysowanie wskazówki
                double xw = center.X + x_max / 2 * Math.Cos(degToRad(180 + valueActual * 180 / (valueMax - valueMin)));
                double yw = center.Y + y_max / 2 * Math.Sin(degToRad(180 + valueActual * 180 / (valueMax - valueMin)));
                e.Graphics.DrawLine(penTip, center, new Point((int)xw, (int)yw));

            }
            catch (Exception)
            {

                throw;
            }

        }


        //do obliczeń sin, cos musimy przeliczyć stopnie na radiany
        private float degToRad(float stopnie)
        {
            return stopnie * (float)Math.PI / 180;
        }


    }
}
