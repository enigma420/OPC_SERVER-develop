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

namespace OPCServer1
{
    partial class CurrentlyMeasurement : UserControl
    {

        private static DatabaseService databaseService = null;

     
        public CurrentlyMeasurement()
        {
            databaseService = new DatabaseService();
            InitializeComponent();
        }

        public static void UpdateDatabaseService(String server, String database, String uid, String password)
        {
            databaseService.UpdateDatabaseServiceDbConnectionData(server, database, uid, password);

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void CurrentlyMeasurement_Load(object sender, EventArgs e)
        {
            Thread InstanceCaller = new Thread(new ThreadStart(RunIntervalCheckingMeasurment));
            InstanceCaller.Start();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void RunIntervalCheckingMeasurment()
        {
            for (; ; )
            {
                CurrentlyMeasurement_LoadOne();
                
                Thread.Sleep(1000);
            }
        }

        private void CurrentlyMeasurement_LoadOne()
        {
            if (databaseService == null || !databaseService.IsDbConnected())
            {
                resetMeasurmentTextboxes();
            }

            //try
            //{
            //    DataTable data = databaseService.GetNewestMeasurment();
            //    int newest = 0;
            //    DataRow row = null;
            //    DataRow[] rows = data.Select();
            //    for (int i = 0; i < rows.Length; i++)
            //    {
            //        DataRow newRow = rows[i];
            //        int index = data.Rows.IndexOf(newRow);
            //        if (index > newest)
            //        {
            //            row = newRow;
            //        }
            //    }

            //    if (row != null)
            //    {
            //        this.Invoke((MethodInvoker)delegate () {
            //            row.Field

            //            //checkBox24.Checked = Convert.ToBoolean(columns["occupancy0"]);
            //            //checkBox23.Checked = Convert.ToBoolean(columns["occupancy1"]);
            //            //checkBox22.Checked = Convert.ToBoolean(columns["occupancy2"]);
            //            //checkBox21.Checked = Convert.ToBoolean(columns["occupancy3"]);
            //            //checkBox20.Checked = Convert.ToBoolean(columns["occupancy4"]);
            //            //checkBox19.Checked = Convert.ToBoolean(columns["occupancy5"]);
            //            //checkBox18.Checked = Convert.ToBoolean(columns["occupancy6"]);
            //            //checkBox17.Checked = Convert.ToBoolean(columns["occupancy7"]);
            //            //checkBox16.Checked = Convert.ToBoolean(columns["platformsize0"]);
            //            //checkBox15.Checked = Convert.ToBoolean(columns["platformsize1"]);
            //            //checkBox14.Checked = Convert.ToBoolean(columns["platformsize2"]);
            //            //checkBox13.Checked = Convert.ToBoolean(columns["platformsize3"]);
            //            //checkBox12.Checked = Convert.ToBoolean(columns["platformsize4"]);
            //            //checkBox11.Checked = Convert.ToBoolean(columns["platformsize5"]);
            //            //checkBox10.Checked = Convert.ToBoolean(columns["platformsize6"]);
            //            //checkBox9.Checked = Convert.ToBoolean(columns["platformsize7"]);
            //            //checkBox1.Checked = Convert.ToBoolean(columns["signalingTrips0"]);
            //            //checkBox2.Checked = Convert.ToBoolean(columns["signalingTrips1"]);
            //            //checkBox3.Checked = Convert.ToBoolean(columns["signalingTrips2"]);
            //            //checkBox4.Checked = Convert.ToBoolean(columns["signalingTrips3"]);
            //            //checkBox5.Checked = Convert.ToBoolean(columns["signalingTrips4"]);
            //            //checkBox6.Checked = Convert.ToBoolean(columns["signalingTrips5"]);
            //            //checkBox7.Checked = Convert.ToBoolean(columns["signalingTrips6"]);
            //            //checkBox8.Checked = Convert.ToBoolean(columns["signalingTrips7"]);
            //            //checkBox32.Checked = Convert.ToBoolean(columns["entrance"]);
            //            //checkBox31.Checked = Convert.ToBoolean(columns["entrance_enabled"]);
            //            //checkBox29.Checked = Convert.ToBoolean(columns["entrance_big_vehicle"]);
            //            //checkBox28.Checked = Convert.ToBoolean(columns["entrance_small_vehicle"]);
            //            //checkBox27.Checked = Convert.ToBoolean(columns["left_right"]);
            //            //checkBox26.Checked = Convert.ToBoolean(columns["parking_in_move"]);
            //            //checkBox25.Checked = Convert.ToBoolean(columns["parking_out"]);
            //            //checkBox30.Checked = Convert.ToBoolean(columns["out_enabled"]);
            //            //checkBox33.Checked = Convert.ToBoolean(columns["vehicle_too_heavy_for_small_platform"]);
            //            //checkBox34.Checked = Convert.ToBoolean(columns["parking_occupied"]);
            //            //checkBox35.Checked = Convert.ToBoolean(columns["big_platform_occupied"]);
            //            //textBox43.Text = Convert.ToString(columns["weight0"]);
            //            //textBox42.Text = Convert.ToString(columns["weight1"]);
            //            //textBox41.Text = Convert.ToString(columns["weight2"]);
            //            //textBox40.Text = Convert.ToString(columns["weight3"]);
            //            //textBox39.Text = Convert.ToString(columns["weight4"]);
            //            //textBox38.Text = Convert.ToString(columns["weight5"]);
            //            //textBox37.Text = Convert.ToString(columns["weight6"]);
            //            //textBox36.Text = Convert.ToString(columns["weight7"]);
            //            //textBox51.Text = Convert.ToString(columns["vehicle_weight"]);
            //            //textBox50.Text = Convert.ToString(columns["platform_to_rotate_down"]);
            //            //textBox49.Text = Convert.ToString(columns["rotation_angle"]);
            //            //textBox48.Text = Convert.ToString(columns["rotation_time"]);
            //            //textBox47.Text = Convert.ToString(columns["ramp_command_speed_freq"]);
            //            //textBox46.Text = Convert.ToString(columns["ramp_engine_speed_freq"]);
            //            //textBox45.Text = Convert.ToString(columns["ramp_actual_speed_freq"]);
            //            //textBox44.Text = Convert.ToString(columns["minimum_weight"]);
            //            //textBox52.Text = Convert.ToString(columns["boundary_weight"]);
            //            //textBox53.Text = Convert.ToString(columns["maximum_weight"]);
            //            //textBox54.Text = Convert.ToString(columns["inventer_status"]);
            //            textBox55.Text = Convert.ToString(row["inventer_command_speed"]);
            //            textBox56.Text = Convert.ToString(row["inventer_actual_speed"]);
            //            textBox19.Text = Convert.ToString(row["time"]);
            //        });
            //    }


            //} catch(System.NullReferenceException ex)
            //{
            //    Console.WriteLine("Error: {0}\n", ex);
            //}


            MySqlDataReader sdr = null;

            try
            {
                sdr = databaseService.GetNewestMeasurment();
            }
            catch (System.NullReferenceException ex)
            {

            }

            if (sdr == null)
            {
                resetMeasurmentTextboxes();
            }


            if (sdr != null)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {

                            checkBox24.Checked = Convert.ToBoolean(sdr["occupancy0"]);
                            checkBox23.Checked = Convert.ToBoolean(sdr["occupancy1"]);
                            checkBox22.Checked = Convert.ToBoolean(sdr["occupancy2"]);
                            checkBox21.Checked = Convert.ToBoolean(sdr["occupancy3"]);
                            checkBox20.Checked = Convert.ToBoolean(sdr["occupancy4"]);
                            checkBox19.Checked = Convert.ToBoolean(sdr["occupancy5"]);
                            checkBox18.Checked = Convert.ToBoolean(sdr["occupancy6"]);
                            checkBox17.Checked = Convert.ToBoolean(sdr["occupancy7"]);
                            checkBox16.Checked = Convert.ToBoolean(sdr["platformsize0"]);
                            checkBox15.Checked = Convert.ToBoolean(sdr["platformsize1"]);
                            checkBox14.Checked = Convert.ToBoolean(sdr["platformsize2"]);
                            checkBox13.Checked = Convert.ToBoolean(sdr["platformsize3"]);
                            checkBox12.Checked = Convert.ToBoolean(sdr["platformsize4"]);
                            checkBox11.Checked = Convert.ToBoolean(sdr["platformsize5"]);
                            checkBox10.Checked = Convert.ToBoolean(sdr["platformsize6"]);
                            checkBox9.Checked = Convert.ToBoolean(sdr["platformsize7"]);
                            checkBox1.Checked = Convert.ToBoolean(sdr["signalingTrips0"]);
                            checkBox2.Checked = Convert.ToBoolean(sdr["signalingTrips1"]);
                            checkBox3.Checked = Convert.ToBoolean(sdr["signalingTrips2"]);
                            checkBox4.Checked = Convert.ToBoolean(sdr["signalingTrips3"]);
                            checkBox5.Checked = Convert.ToBoolean(sdr["signalingTrips4"]);
                            checkBox6.Checked = Convert.ToBoolean(sdr["signalingTrips5"]);
                            checkBox7.Checked = Convert.ToBoolean(sdr["signalingTrips6"]);
                            checkBox8.Checked = Convert.ToBoolean(sdr["signalingTrips7"]);
                            checkBox32.Checked = Convert.ToBoolean(sdr["entrance"]);
                            checkBox31.Checked = Convert.ToBoolean(sdr["entrance_enabled"]);
                            checkBox29.Checked = Convert.ToBoolean(sdr["entrance_big_vehicle"]);
                            checkBox28.Checked = Convert.ToBoolean(sdr["entrance_small_vehicle"]);
                            checkBox27.Checked = Convert.ToBoolean(sdr["left_right"]);
                            checkBox26.Checked = Convert.ToBoolean(sdr["parking_in_move"]);
                            //checkBox25.Checked = Convert.ToBoolean(sdr["parking_out"]);
                            //checkBox30.Checked = Convert.ToBoolean(sdr["out_enabled"]);
                            //checkBox33.Checked = Convert.ToBoolean(sdr["vehicle_too_heavy_for_small_platform"]);
                            checkBox34.Checked = Convert.ToBoolean(sdr["parking_occupied"]);
                            checkBox35.Checked = Convert.ToBoolean(sdr["big_platform_occupied"]);
                            textBox43.Text = sdr["weight0"].ToString();
                            textBox42.Text = sdr["weight1"].ToString();
                            textBox41.Text = sdr["weight2"].ToString();
                            textBox40.Text = sdr["weight3"].ToString();
                            textBox39.Text = sdr["weight4"].ToString();
                            textBox38.Text = sdr["weight5"].ToString();
                            textBox37.Text = sdr["weight6"].ToString();
                            textBox36.Text = sdr["weight7"].ToString();
                            textBox51.Text = sdr["vehicle_weight"].ToString();
                            //textBox50.Text = sdr["platform_to_rotate_down"].ToString();
                            textBox49.Text = sdr["rotation_angle"].ToString();
                            textBox48.Text = sdr["rotation_time"].ToString();
                            //textBox47.Text = sdr["ramp_command_speed_freq"].ToString();
                            textBox46.Text = sdr["ramp_engine_speed_freq"].ToString();
                            textBox45.Text = sdr["ramp_actual_speed_freq"].ToString();
                            //textBox44.Text = sdr["minimum_weight"].ToString();
                            //textBox52.Text = sdr["boundary_weight"].ToString();
                            //textBox53.Text = sdr["maximum_weight"].ToString();
                            //textBox54.Text = sdr["inventer_status"].ToString();
                            //textBox55.Text = sdr["inventer_command_speed"].ToString();
                            textBox56.Text = sdr["inventer_actual_speed"].ToString();
                            textBox19.Text = sdr["time"].ToString();
                        });
                        break;
                    }
                }

                sdr.Close();
            }


        }

        private void resetMeasurmentTextboxes()
        {
            try
            {
                this.Invoke((MethodInvoker)delegate ()
                {

                    checkBox24.Checked = false;
                    checkBox23.Checked = false;
                    checkBox22.Checked = false;
                    checkBox21.Checked = false;
                    checkBox20.Checked = false;
                    checkBox19.Checked = false;
                    checkBox18.Checked = false;
                    checkBox17.Checked = false;
                    checkBox16.Checked = false;
                    checkBox15.Checked = false;
                    checkBox14.Checked = false;
                    checkBox13.Checked = false;
                    checkBox12.Checked = false;
                    checkBox11.Checked = false;
                    checkBox10.Checked = false;
                    checkBox9.Checked = false;
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                    checkBox8.Checked = false;
                    checkBox32.Checked = false;
                    checkBox31.Checked = false;
                    checkBox29.Checked = false;
                    checkBox28.Checked = false;
                    checkBox27.Checked = false;
                    checkBox26.Checked = false;
                    checkBox25.Checked = false;
                    checkBox30.Checked = false;
                    checkBox33.Checked = false;
                    checkBox34.Checked = false;
                    checkBox35.Checked = false;
                    textBox43.Text = "";
                    textBox42.Text = "";
                    textBox41.Text = "";
                    textBox40.Text = "";
                    textBox39.Text = "";
                    textBox38.Text = "";
                    textBox37.Text = "";
                    textBox36.Text = "";
                    textBox51.Text = "";
                    //textBox50.Text = "";
                    textBox49.Text = "";
                    textBox48.Text = "";
                    //textBox47.Text = "";
                    textBox46.Text = "";
                    textBox45.Text = "";
                    //textBox44.Text = "";
                    //textBox52.Text = "";
                    //textBox53.Text = "";
                    //textBox54.Text = "";
                    //textBox55.Text = "";
                    textBox56.Text = "";
                    textBox19.Text = "";
                });
            }
            catch(System.InvalidOperationException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
        }


    }
}
