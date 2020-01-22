using OPCServer1.Frontend.Visualization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPCServer1.Forms
{
    public partial class Dashboard : Form
    {
        private static Dashboard Instance = null;
        private PlcDatapackageUpdate2 plcDataUpdate = null;

        public Dashboard()
        {
            InitializeComponent();
            Instance = this;
            plcDataUpdate = new PlcDatapackageUpdate2();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ConnToDB f2 = new ConnToDB();
            f2.Show();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            ConnToPLC f2 = new ConnToPLC();
            f2.Show();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            controllerValues1.Visible = false;
            history1.Visible = false;
            currentlyMeasurement1.Visible = true;
            diagrams1.Visible = false;
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            controllerValues1.Visible = true;
            history1.Visible = false;
            currentlyMeasurement1.Visible = false;
            diagrams1.Visible = false;
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            controllerValues1.Visible = false;
            history1.Visible = true;
            currentlyMeasurement1.Visible = false;
            diagrams1.Visible = false;

            Thread watek3 = new Thread(new ThreadStart(startTest));
            watek3.Start();
        }

        private void startTest()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Test started");
            Instance.plcDataUpdate.startTest();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            controllerValues1.Visible = false;
            history1.Visible = false;
            currentlyMeasurement1.Visible = false;
            diagrams1.Visible = false;
            //refreshForm();

        }
        private void Button6_Click(object sender, EventArgs e)
        {
            controllerValues1.Visible = false;
            history1.Visible = false;
            currentlyMeasurement1.Visible = false;
            diagrams1.Visible = true;
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            controllerValues1.Visible = false;
            history1.Visible = false;
            currentlyMeasurement1.Visible = false;
            diagrams1.Visible = false;
        }

        private void diagrams1_Load(object sender, EventArgs e)
        {

        }



        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Visualization f2 = new Visualization();
            f2.Show();
        }

        public static void UpdateDatabaseServiceDbConnectionData(string server, string database, string uid, string password)
        {
            Instance.plcDataUpdate.UpdateDatabaseServiceDbConnectionData(server, database, uid, password);
        }

        public static void UpdateDatabaseConnectedStatus(bool newDbStatus)
        {
            string dbStatus = "disconnected";
            if (newDbStatus)
            {
                dbStatus = "connected";
            }

            Instance.UpdateDbStatusLabel(dbStatus);
            Instance.plcDataUpdate.UpdateIsDbConnected(newDbStatus);

        }

        private void UpdateDbStatusLabel(string isDbConnected)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                DbStatusLabel.Text = isDbConnected;
            });
        }

        public static void UpdatePlcConnectedStatus(bool newPlcStatus)
        {
            string plcStatus = "disconnected";
            if (newPlcStatus)
            {
                plcStatus = "connected";
            }
            Instance.UpdatePlcStatusLabel(plcStatus);
            Instance.plcDataUpdate.UpdateIsPlcConnected(newPlcStatus);
        }

        private void UpdatePlcStatusLabel(string isPlcConnected)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                PlcStatusLabel.Text = isPlcConnected;
            });
        }
    }
}
