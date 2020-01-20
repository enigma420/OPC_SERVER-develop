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

        private static string dbStatus = "disconnected";

        public Dashboard()
        {
            InitializeComponent();
            RunUpdateDbStatusIntervalRoutine();
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

        private void RunUpdateDbStatusIntervalRoutine()
        {
            Thread InstanceCaller = new Thread(new ThreadStart(UpdateDbStatusInterval));
            InstanceCaller.Start();
        }

        private void UpdateDbStatusInterval()
        {
            for (; ; )
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        DbStatusLabel.Text = dbStatus;
                    });

                    Console.WriteLine("DbStatus: {0}", dbStatus);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error exception: {0}", ex);
                }
                Thread.Sleep(1000);
            }
        }

        public static void UpdateDatabaseConnectedStatus(bool newDbStatus)
        {
            if (newDbStatus)
            {
                dbStatus = "connected";
            }
            else
            {
                dbStatus = "disconnected";
            }
        }
    }
}
