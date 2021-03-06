﻿
using S7.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;

namespace OPCServer1.Forms
{
    public partial class ConnToPLC : Form
    {
        private PlcService plcService;
        //Plc PlcConnection;
        DispatcherTimer timer = new DispatcherTimer();

        public ConnToPLC()
        {
            InitializeComponent();
            plcService = new PlcService();
        }
        

        private void Button7_Click(object sender, EventArgs e)
        {
            plcService.CloseConnection();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool plcStatus = false;
            try
            {
                plcStatus = plcService.OpenConnection(CpuType.S71200, txtIpAddress.Text, short.Parse(textBox2.Text), short.Parse(textBox3.Text));
            }
            catch (System.NullReferenceException ex)
            {
                Console.WriteLine("Błąd podczas nawiązywania połączenia ze sterownikiem PLC: {0}", ex.ToString());
            }
           

            Dashboard.UpdatePlcConnectedStatus(plcStatus);
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
