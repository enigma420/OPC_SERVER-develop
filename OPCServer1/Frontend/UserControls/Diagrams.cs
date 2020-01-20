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
        private static DatabaseService databaseService;
        private int lastId = 0;
        private PointF centrePoint;

        public Diagrams()
        {
            InitializeComponent();
            databaseService = new DatabaseService();

            //RunAddNewestSpeedAndTimeDataIntervalRoutine();
        }
        
        public static void UpdateDatabaseConnectionData(String server, String database, String uid, String password)
        {
            databaseService.UpdateDatabaseServiceDbConnectionData(server, database, uid, password);

            //AddAllSpeedAndTimeDataToDiagram(zedGraphControl1);
        }
        
        private void RunAddNewestSpeedAndTimeDataIntervalRoutine()
        {
            Thread InstanceCaller = new Thread(new ThreadStart(RunAddNewestSpeedAndTimeDataInterval));
            InstanceCaller.Start();
        }

        private void RunAddNewestSpeedAndTimeDataInterval()
        {
            for (; ; )
            {
                //if (databaseService.IsDbAndPlcConnected())
                //{
                AddNewestSpeedAndTimeData(zedGraphControl1);
                //}

                Thread.Sleep(1000);
            }
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

        private void AddAllSpeedAndTimeDataToDiagram(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            zgc.GraphPane.CurveList.Clear();
            zgc.GraphPane.GraphObjList.Clear();

            ZedGraph.PointPairList curve = new ZedGraph.PointPairList();

            List<double[]> speedAndTimeList = getAllSpeedAndTimeData();
            for (int i = 0; i < speedAndTimeList.Count; i++)
            {
                try
                {
                    curve.Add(speedAndTimeList[i][0], speedAndTimeList[i][1]);
                }
                catch (System.ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Error: {0}", ex.ToString());
                }
            }


            LineItem myCurve = myPane.AddCurve("f(Time)", curve, Color.Red, ZedGraph.SymbolType.Circle);
            myCurve.Line.Width = 2.0F;

            zgc.AxisChange();
            zgc.Invalidate();
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

        private void AddNewestSpeedAndTimeData(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            if (myPane.CurveList.Count <= 0)
                return;

            double[] speedAndTime = getNewestSpeedAndTimeData();
            if (speedAndTime[1] != 0)
            {
                ((IPointListEdit)myPane.CurveList[0].Points).Add(speedAndTime[0], speedAndTime[1]);
                Console.WriteLine("speed {0} time {0}", speedAndTime[0], speedAndTime[1]);
            }

            zgc.Invalidate();
        }

        private double[] getNewestSpeedAndTimeData()
        {
            double[] speedAndTime = { 0, 0 };
            MySqlDataReader data = databaseService.GetNewestSpeedAndTimeData();

            if (data != null)
            {
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        int id = Convert.ToInt32(data["plc_data_package_id"]);

                        if (lastId != 0 && id != lastId)
                        {
                            lastId = id;
                            speedAndTime[0] = Convert.ToDouble(data["ramp_actual_speed_freq"]);
                            speedAndTime[1] = new XDate(Convert.ToDateTime(data["time"]));

                        }
                        return speedAndTime;
                    }
                }

                data.Close();
            }

            return speedAndTime;
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
            AddAllSpeedAndTimeDataToDiagram(zedGraphControl1);
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
    }
}
