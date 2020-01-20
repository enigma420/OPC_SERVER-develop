using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Drawing2D;
using OPCServer1.Backend.Serwer;
using System.Threading;

namespace OPCServer1.Frontend.Visualization
{
    public partial class Visualization : Form
    {
        private static DatabaseService databaseService = null;
        private static PlcService plcService;


        //Diagnostyczne DB29
        //0.0
        public bool RunStop { get; set; }
        public bool RxTx { get; set; }
        public bool link { get; set; }
        public bool error { get; set; }
        public bool maint { get; set; }
        public bool RunTimeCycle { get; set; }
        public bool WriteLocalTime { get; set; }
        //Alarmowe DB16 od 0.0 do 1.3
        public bool engineError_Alarm { get; set; }
        public bool engineError_alarmReset { get; set; }
        public bool engineError_Notify {get; set;}
        public bool engineError_notifyReset { get; set; }
        public bool controlSystemError_Alarm { get; set; }
        public bool controlSystemError_alarmReset { get; set; }
        public bool controlSystemError_Notify { get; set; }
        public bool controlSystemError_notifyReset { get; set; }
        public bool entranceSensorError_Alarm { get; set; }
        public bool entranceSensorError_alarmReset { get; set; }
        public bool vehicleTooHeavy { get; set; }
        public bool Error_Alarm { get; set; }
        public bool Occupancy0 { get; set; }
        public bool Occupancy1 { get; set; }
        public bool Occupancy2 { get; set; }
        public bool Occupancy3 { get; set; }
        public bool Occupancy4 { get; set; }
        public bool Occupancy5 { get; set; }
        public bool Occupancy6 { get; set; }
        public bool Occupancy7 { get; set; }
        public bool PlatformSize0 { get; set; }
        public bool PlatformSize1 { get; set; }
        public bool PlatformSize2 { get; set; }
        public bool PlatformSize3 { get; set; }
        public bool PlatformSize4 { get; set; }
        public bool PlatformSize5 { get; set; }
        public bool PlatformSize6 { get; set; }
        public bool PlatformSize7 { get; set; }
        public bool SignalingTrips0 { get; set; }
        public bool SignalingTrips1 { get; set; }
        public bool SignalingTrips2 { get; set; }
        public bool SignalingTrips3 { get; set; }
        public bool SignalingTrips4 { get; set; }
        public bool SignalingTrips5 { get; set; }
        public bool SignalingTrips6 { get; set; }
        public bool SignalingTrips7 { get; set; }
        public bool Entrance { get; set; }
        public bool Entrance_enabled { get; set; }
        public bool Entrance_big_vehicle { get; set; }
        public bool Entrance_small_vehicle { get; set; }
        public bool Left_right { get; set; }
        public bool Parking_in_move { get; set; }
        public bool Parking_out { get; set; }
        public bool Out_enabled { get; set; }
        public bool Vehicle_too_heavy_for_small_platform { get; set; }
        public bool Parking_occupied { get; set; }
        public bool Big_platform_occupied { get; set; }


        public int Weight0 { get; set; }
        public int Weight1 { get; set; }
        public int Weight2 { get; set; }
        public int Weight3 { get; set; }
        public int Weight4 { get; set; }
        public int Weight5 { get; set; }
        public int Weight6 { get; set; }
        public int Weight7 { get; set; }


        public int Vehicle_weight { get; set; }
        public int Platform_to_rotate_down { get; set; }
        public int Rotation_angle { get; set; }
        public int Rotation_time { get; set; }

        public double Ramp_command_speed_freq { get; set; }
        public double Ramp_engine_speed_freq { get; set; }
        public double Ramp_actual_speed_freq { get; set; }
        public double Minimum_weight { get; set; }
        public double Boundary_weight { get; set; }
        public double Maximum_weight { get; set; }
        public int Inventer_status { get; set; }
        public int Inventer_command_speed { get; set; }
        public int Inventer_actual_speed { get; set; }






        public Visualization()
        {
            InitializeComponent();
            databaseService = new DatabaseService();
            plcService = new PlcService();
        }

        private PlcService.Measurement[] data;

        public void ImportData(PlcService source)
        {
            this.data = source.ExportData();
        }

        public void DiodeLogic()
        {
            if (Occupancy0) {
                Zero_Place_Red_Diode.Visible = true;
                Zero_Place_Green_Diode.Visible = false;
            }
            else
            {
                Zero_Place_Red_Diode.Visible = false;
                Zero_Place_Green_Diode.Visible = true;
            }
            if (Occupancy1)
            {
                First_Place_Red_Diode.Visible = true;
                First_Place_Green_Diode.Visible = false;
            }
            else
            {
                First_Place_Red_Diode.Visible = false;
                First_Place_Green_Diode.Visible = true;
            }
            if (Occupancy2)
            {
                Second_Place_Red_Diode.Visible = true;
                Second_Place_Green_Diode.Visible = false;
            }
            else
            {
                Second_Place_Red_Diode.Visible = false;
                Second_Place_Green_Diode.Visible = true;
            }
            if (Occupancy3)
            {
                Third_Place_Red_Diode.Visible = true;
                Third_Place_Green_Diode.Visible = false;
            }
            else
            {
                Third_Place_Red_Diode.Visible = false;
                Third_Place_Green_Diode.Visible = true;
            }
            if (Occupancy4)
            {
                Fourth_Place_Red_Diode.Visible = true;
                Fourth_Place_Green_Diode.Visible = false;
            }
            else
            {
                Fourth_Place_Red_Diode.Visible = false;
                Fourth_Place_Green_Diode.Visible = true;
            }
            if (Occupancy5)
            {
                Fifth_Place_Red_Diode.Visible = true;
                Fifth_Place_Green_Diode.Visible = false;
            }
            else
            {
                Fifth_Place_Red_Diode.Visible = false;
                Fifth_Place_Green_Diode.Visible = true;
            }
            if (Occupancy6)
            {
                Sixth_Place_Red_Diode.Visible = true;
                Sixth_Place_Green_Diode.Visible = false;
            }
            else
            {
                Sixth_Place_Red_Diode.Visible = false;
                Sixth_Place_Green_Diode.Visible = true;
            }
            if (Occupancy7)
            {
                Seventh_Place_Red_Diode.Visible = true;
                Seventh_Place_Green_Diode.Visible = false;
            }
            else
            {
                Seventh_Place_Red_Diode.Visible = false;
                Seventh_Place_Green_Diode.Visible = true;
            }
        }

        public void CarLogic()
        {

        }

        public void AlarmsLogic()
        {

        }

        public void DiagnosticLogic()
        {
            if (RunStop) runstop_label.Text = "RUN";
            else runstop_label.Text = "STOP";
            if (error) error_label.Text = "ERROR";
            else error_label.Text = "CORRECT";
            if (maint) maint_label.Text = "DIAGNOSING";
            else maint_label.Text = "NOT DIAGNOSING";
            if (link) link_label.Text = "PODŁĄCZONY";
            else link_label.Text = "NIEPODŁĄCZONY";
            if (RxTx) rxtx_label.Text = "TRANSMITUJE";
            else rxtx_label.Text = "NIETRANSMITUJE";
        }

        public void RotorLogic()
        {
            if(Ramp_actual_speed_freq != 0.0) 
            {
                Rotor_2.Visible = false;
                Rotor_1.Visible = true;

                Thread.Sleep(50);

                Rotor_1.Visible = false;
                Rotor_2.Visible = true;

                Thread.Sleep(50);
            }
            else
            {
                Rotor_1.Visible = false;
                Rotor_2.Visible = true;
            }
        }

        public void WeightLogic()
        {

        }

        public void MainLogic()
        {
            AlarmsLogic();
            RotorLogic();
            CarLogic();
            DiodeLogic();
            WeightLogic();
            
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            
        }
        
        private void Visualization_Load(object sender, EventArgs e)
        {

        }
    }
}
