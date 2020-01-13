﻿using OPCServer1.Backend.Database;
using OPCServer1.Backend.Serwer;
using OPCServer1.Properties;
using S7.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace OPCServer1.Forms
{
    public partial class ConnToPLC : Form
    {
        private DB3 Db3;
        //Plc PlcConnection;
        DispatcherTimer timer = new DispatcherTimer();

        public ConnToPLC()
        {
            InitializeComponent();
            Db3 = new DB3();
        }
        

        private void Button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool plcStatus = false;
            try
            {
                plcStatus = Db3.OpenConnection(CpuType.S71200, txtIpAddress.Text, short.Parse(textBox2.Text), short.Parse(textBox3.Text));
            }
            catch (System.NullReferenceException ex)
            {
                Console.WriteLine("Error while opening connection with plc: {0}", ex.ToString());
            }
           

            string plcStatusLabel = "";
            if (plcStatus)
            {
                plcStatusLabel = "connected";
            }
            else
            {
                plcStatusLabel = "disconnected";
            }

            label7.Text = plcStatusLabel;

            DatabaseService.UpdateIsPlcConnected();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtIpAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
