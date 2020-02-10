using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;
using OPCServer1.Backend.Serwer.Model;

namespace OPCServer1
{
    partial class CurrentlyMeasurement : UserControl
    {
        private static CurrentlyMeasurement Instance = null;
     
        public CurrentlyMeasurement()
        {
            InitializeComponent();
            Instance = this;
        }

        
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void CurrentlyMeasurement_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        public static void CurrentlyMeasurement_LoadOne(PlcDataPackage plcDataPackage)
        {
            try
            {
                Instance.UpdateCurrentlyMeasurmentFields(plcDataPackage);
            } catch (System.NullReferenceException ex)
            {
                Console.WriteLine("Error : {0}", ex.ToString());
            }
            
        }

        public void UpdateCurrentlyMeasurmentFields(PlcDataPackage data)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                checkBox24.Checked = data.Occupancy0;
                checkBox23.Checked = data.Occupancy1;
                checkBox22.Checked = data.Occupancy2;
                checkBox21.Checked = data.Occupancy3;
                checkBox20.Checked = data.Occupancy4;
                checkBox19.Checked = data.Occupancy5;
                checkBox18.Checked = data.Occupancy6;
                checkBox17.Checked = data.Occupancy7;
                checkBox16.Checked = data.PlatformSize0;
                checkBox15.Checked = data.PlatformSize1;
                checkBox14.Checked = data.PlatformSize2;
                checkBox13.Checked = data.PlatformSize3;
                checkBox12.Checked = data.PlatformSize4;
                checkBox11.Checked = data.PlatformSize5;
                checkBox10.Checked = data.PlatformSize6;
                checkBox9.Checked = data.PlatformSize7;
                checkBox1.Checked = data.SignalingTrips0;
                checkBox2.Checked = data.SignalingTrips1;
                checkBox3.Checked = data.SignalingTrips2;
                checkBox4.Checked = data.SignalingTrips3;
                checkBox5.Checked = data.SignalingTrips4;
                checkBox6.Checked = data.SignalingTrips5;
                checkBox7.Checked = data.SignalingTrips6;
                checkBox8.Checked = data.SignalingTrips7;
                checkBox32.Checked = data.Entrance;
                checkBox29.Checked = data.Entrance_big_vehicle;
                checkBox28.Checked = data.Entrance_small_vehicle;
                checkBox26.Checked = data.Parking_in_move;
                checkBox34.Checked = data.Parking_occupied;
                checkBox35.Checked = data.Big_platform_occupied;
                textBox43.Text = data.Weight0.ToString();
                textBox42.Text = data.Weight1.ToString();
                textBox41.Text = data.Weight2.ToString();
                textBox40.Text = data.Weight3.ToString();
                textBox39.Text = data.Weight4.ToString();
                textBox38.Text = data.Weight5.ToString();
                textBox37.Text = data.Weight6.ToString();
                textBox36.Text = data.Weight7.ToString();
                textBox51.Text = data.Vehicle_weight.ToString();
                textBox49.Text = data.Rotation_angle.ToString();
                textBox48.Text = data.Rotation_time.ToString();
                textBox45.Text = data.Ramp_actual_speed_freq.ToString();
                textBox19.Text = data.Time.ToString();
                textBox44.Text = data.Minimum_weight.ToString();
                textBox52.Text = data.Boundary_weight.ToString();
                textBox53.Text = data.Maximum_weight.ToString();
            });
        }
        
    }
}
