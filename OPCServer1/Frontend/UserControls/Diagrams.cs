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
using OPCServer1.Backend.Serwer.Model;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Threading;

namespace OPCServer1
{
    partial class Diagrams : UserControl
    {
        private static Diagrams Instance = null;
        private static DatabaseService databaseService;
        private int lastId = 0;
        private PointF centrePoint;

        public Diagrams()
        {
            InitializeComponent();
            databaseService = new DatabaseService();
            Instance = this;
            //RunAddNewestSpeedAndTimeDataIntervalRoutine();
        }
        
        public static void UpdateDatabaseConnectionData(String server, String database, String uid, String password)
        {
            databaseService.UpdateDatabaseServiceDbConnectionData(server, database, uid, password);

            Instance.AddAllSpeedAndTimeDataToDiagram();
        }
        
        

        private void CreateGraph(ZedGraphControl zgc)
        {
            GraphPane mypane = zgc.GraphPane;

            //// set the titles and axis labels
            mypane.Title.Text = "Speed = f(Time)";
            //mypane.xaxis.title.text = "time";
            mypane.YAxis.Title.Text = "Actual speed";

            mypane.XAxis.Type = AxisType.Date;
            mypane.XAxis.Title.Text = "time (hh:mm:ss)";
            mypane.XAxis.Scale.Format = "hh:mm:ss.fff";
            mypane.XAxis.Scale.MajorUnit = DateUnit.Second;
            mypane.XAxis.Scale.MajorUnit = DateUnit.Second;
            mypane.XAxis.Scale.Max = DateTime.Now.ToOADate();

            PointPairList curve = new PointPairList();
            LineItem mycurve2 = mypane.AddCurve("Actual Speed", curve, Color.Red, SymbolType.Circle);
            mycurve2.Line.Width = 5.0F;

            mypane.YAxis.Scale.MinAuto = true;
            mypane.YAxis.Scale.MaxAuto = true;
            mypane.XAxis.Scale.MinAuto = true;
            mypane.XAxis.Scale.MaxAuto = true;

            zgc.IsShowPointValues = true;
            zgc.AxisChange();
            zgc.Refresh();
            zgc.Visible = true;
        }

        private void AddAllSpeedAndTimeDataToDiagram()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();

            PointPairList curve = new PointPairList();

            List<double[]> speedAndTimeList = getAllSpeedAndTimeData();
            for (int i = 0; i < speedAndTimeList.Count; i++)
            {
                try
                {
                    curve.Add(speedAndTimeList[i][0], speedAndTimeList[i][1]);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Error: {0}", ex.ToString());
                }
            }


            LineItem myCurve = myPane.AddCurve("f(Time)", curve, Color.Red, SymbolType.Circle);
            myCurve.Line.Width = 2.0F;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private List<double[]> getAllSpeedAndTimeData()
        {
            List<double[]> list = new List<double[]>();
            MySqlDataReader data = databaseService.GetAllSpeedAndTimeData();

            if (data != null)
            {
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        lastId = Convert.ToInt32(data["plc_data_package_id"]);
                        double speed = Convert.ToDouble(data["ramp_actual_speed_freq"]);
                        double time = Convert.ToDateTime(data["time"]).ToOADate();
                        double[] speedAndTime = { time, speed };

                        list.Add(speedAndTime);
                    }
                }

                data.Close();
            }

            return list;
        }

        private void AddNewestSpeedAndTimeData(double speed, double time)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;

            //Console.WriteLine("Adding speed: {0} time: {1}", speed, time);
            ((IPointListEdit)myPane.CurveList[0].Points).Add(speed,time);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            //zedGraphControl1.Refresh();
        }


        private void Diagrams_Load(object sender, EventArgs e)
        {

           CreateGraph(zedGraphControl1);

            //CreateCommand("SELECT ramp_actual_speed_freq, time from PLC_DATA_PACKAGE_TABLE", connectionString);
        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl1);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AddAllSpeedAndTimeDataToDiagram();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            zedGraphControl1.ZoomPane(myPane, 1.5, centrePoint, false);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            zedGraphControl1.ZoomPane(myPane, 0.5, centrePoint, false);
        }

        public static void SetNewSpeedAndTimeData(double speed, double time)
        {
            Instance.AddNewestSpeedAndTimeData(speed, time);
        }
    }
}
