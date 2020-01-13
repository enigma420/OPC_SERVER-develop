using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Drawing;

namespace OPCServer1.Frontend.UserControls.Diagram_Components
{
    public partial class Diagram_1 : UserControl
    {
        public Diagram_1()
        {
            InitializeComponent();
        }

        private void CreateGraph(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "Test Graph";
            myPane.XAxis.Title.Text = "Time";
            myPane.YAxis.Title.Text = "Voltage_L1";

            // Make up some data points from the Sine function
            PointPairList list = new PointPairList();
            //for (double x = 0; x < 36; x++)
            //{
            //  double y = Math.Sin(x * Math.PI / 15.0);

            //  list.Add(x, y);
            //}
            DateTime time = DateTime.Now;
            Measurement measure = new Measurement(126.2, 123.2, 111, 126, 175, 186, 156, 147, 232, 434, 425, 545, 626, 235, 6523, 654, 7546, 54353, time);
            for (double x = 0; x < 18; x++)
            {
                double y = measure.UL1;
                list.Add(x, y);
            }

            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve = myPane.AddCurve("My Curve", list, Color.Blue,
                              SymbolType.Circle);
            // Fill the area under the curve with a white-red gradient at 45 degrees
            myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);

            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
        }


        private void Diagram_1_Load(object sender, EventArgs e)
        {
          //  CreateGraph(ZedGraphControl);
        }

        private void ZedGraphControl1_Load(object sender, EventArgs e)
        {
          //  CreateGraph(ZedGraphControl);
        }
    }
}
