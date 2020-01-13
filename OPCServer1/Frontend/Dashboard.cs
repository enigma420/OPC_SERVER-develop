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
       

        public Dashboard()
        {
            InitializeComponent();
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

        public static void UpdateDbStatusLabel(string status)
        {
            
           // DbStatusLabel.Text = status;
        }

        public static void UpdatePlcStatusLabel(string status)
        {
           // PlcStatusLabel.Text = status;
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
    }
}
