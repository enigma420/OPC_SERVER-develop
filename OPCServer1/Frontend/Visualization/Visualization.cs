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
      

        //Diagnostyczne DB29 inty
        //0.0
        public int RunStop { get; set; }
        public int RxTx { get; set; }
        public int link { get; set; }
        public int error { get; set; }
        public int maint { get; set; }
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

        public void WeightLogic(int i)
        {

            if (Entrance_enabled)
            {
                if (Entrance)
                {
                    Entrance_Green_Diode.Visible = true;
                    Entrance_Red_Diode.Visible = false;
                    entrance_weight.Text = Vehicle_weight.ToString();
                }
                else
                {
                    Entrance_Green_Diode.Visible = false;
                    Entrance_Red_Diode.Visible = true;
                }
            }

            switch (i)
            {
                case 0:
                    if (Weight0 < Maximum_weight || Minimum_weight < Weight0)
                    {
                        if (Boundary_weight > Weight0)
                        {
                            Zero_Small_Car.Visible = true;
                            Zero_Big_Car.Visible = false;
                            Zero_Car_Weight.Text = Weight0.ToString();
                        }
                        else
                        {
                            Zero_Small_Car.Visible = false;
                            Zero_Big_Car.Visible = true;
                            Zero_Car_Weight.Text = Weight0.ToString();
                        }
                    }
                    else
                    {
                        Zero_Small_Car.Visible = false;
                        Zero_Big_Car.Visible = false;
                    }
                    break;
                case 1:
                    if (Weight1 < Maximum_weight || Minimum_weight < Weight1)
                    {
                        if (Boundary_weight > Weight1)
                        {
                            First_Small_Car.Visible = true;
                            First_Big_Car.Visible = false;
                            First_Car_Weight.Text = Weight1.ToString();
                        }
                        else
                        {
                            First_Small_Car.Visible = false;
                            First_Big_Car.Visible = true;
                            First_Car_Weight.Text = Weight1.ToString();
                        }
                    }
                    else
                    {
                        First_Small_Car.Visible = false;
                        First_Big_Car.Visible = false;
                    }
                    break;
                case 2:
                    if (Weight2 < Maximum_weight || Minimum_weight < Weight2)
                    {
                        if (Boundary_weight > Weight2)
                        {
                            Second_Small_Car.Visible = true;
                            Second_Big_Car.Visible = false;
                            Second_Car_Weight.Text = Weight2.ToString();
                        }
                        else
                        {
                            Second_Small_Car.Visible = false;
                            Second_Big_Car.Visible = true;
                            Second_Car_Weight.Text = Weight2.ToString();
                        }
                    }
                    else
                    {
                        Second_Small_Car.Visible = false;
                        Second_Big_Car.Visible = false;
                    }
                    break;
                case 3:
                    if (Weight3 < Maximum_weight || Minimum_weight < Weight3) { 
                        if (Boundary_weight > Weight3)
                        {
                            Third_Small_Car.Visible = true;
                            Third_Big_Car.Visible = false;
                            Third_Car_Weight.Text = Weight3.ToString();
                        }
                        else
                        {
                            Third_Small_Car.Visible = false;
                            Third_Big_Car.Visible = true;
                            Third_Car_Weight.Text = Weight3.ToString();
                        } }
                    else
                    {
                        Third_Small_Car.Visible = false;
                        Third_Big_Car.Visible = false;
                    }
                    break;
                case 4:
                    if (Weight4 < Maximum_weight || Minimum_weight < Weight4)
                    {
                        if (Boundary_weight > Weight4)
                        {
                            Fourth_Small_Car.Visible = true;
                            Fourth_Big_Car.Visible = false;
                            Fourth_Car_Weight.Text = Weight4.ToString();
                        }
                        else
                        {
                            Fourth_Small_Car.Visible = false;
                            Fourth_Big_Car.Visible = true;
                            Fourth_Car_Weight.Text = Weight4.ToString();
                        }
                    }
                    else
                    {
                        Fourth_Small_Car.Visible = false;
                        Fourth_Big_Car.Visible = false;
                    } 
                    break;
                case 5:
                    if (Weight5 < Maximum_weight || Minimum_weight < Weight5)
                    {
                        if (Boundary_weight > Weight5)
                        {
                            Fifth_Small_Car.Visible = true;
                            Fifth_Big_Car.Visible = false;
                            Fifth_Car_Weight.Text = Weight5.ToString();
                        }
                        else
                        {
                            Fifth_Small_Car.Visible = false;
                            Fifth_Big_Car.Visible = true;
                            Fifth_Car_Weight.Text = Weight5.ToString();
                        }
                    }
                    else
                    {
                        Fifth_Small_Car.Visible = false;
                        Fifth_Big_Car.Visible = false;
                    }
                    break;
                case 6:
                    if (Weight6 < Maximum_weight || Minimum_weight < Weight6)
                    {
                        if (Boundary_weight > Weight6)
                        {
                            Sixth_Small_Car.Visible = true;
                            Sixth_Big_Car.Visible = false;
                            Sixth_Car_Weight.Text = Weight6.ToString();
                        }
                        else
                        {
                            Sixth_Small_Car.Visible = false;
                            Sixth_Big_Car.Visible = true;
                            Sixth_Car_Weight.Text = Weight6.ToString();
                        }
                    }
                    else
                    {
                        Sixth_Small_Car.Visible = false;
                        Sixth_Big_Car.Visible = false;
                    }
                    break;
                case 7:
                    if (Weight7 < Maximum_weight || Minimum_weight < Weight7)
                    {
                        if (Boundary_weight > Weight7)
                        {
                            Seventh_Small_Car.Visible = true;
                            Seventh_Big_Car.Visible = false;
                            Seventh_Car_Weight.Text = Weight7.ToString();
                        }
                        else
                        {
                            Seventh_Small_Car.Visible = false;
                            Seventh_Big_Car.Visible = true;
                            Seventh_Car_Weight.Text = Weight7.ToString();
                        }
                    }
                    else
                    {
                        Seventh_Small_Car.Visible = false;
                        Seventh_Big_Car.Visible = false;
                    }
                    break;
                default:
                    break;

            }
            
        }

        public void CarAndWeightAndDiodeLogic()
        {
            if (Occupancy0) {
                Zero_Place_Red_Diode.Visible = true;
                Zero_Place_Green_Diode.Visible = false;
                WeightLogic(0);
            }
            else
            {
                Zero_Place_Red_Diode.Visible = false;
                Zero_Place_Green_Diode.Visible = true;
                Zero_Big_Car.Visible = false;
                Zero_Small_Car.Visible = false;
                Zero_Car_Weight.Text = "0";

            }
            if (Occupancy1)
            {
                First_Place_Red_Diode.Visible = true;
                First_Place_Green_Diode.Visible = false;
                WeightLogic(1);
            }
            else
            {
                First_Place_Red_Diode.Visible = false;
                First_Place_Green_Diode.Visible = true;
                First_Big_Car.Visible = false;
                First_Small_Car.Visible = false;
                First_Car_Weight.Text = "0";
            }
            if (Occupancy2)
            {
                Second_Place_Red_Diode.Visible = true;
                Second_Place_Green_Diode.Visible = false;
                WeightLogic(2);
            }
            else
            {
                Second_Place_Red_Diode.Visible = false;
                Second_Place_Green_Diode.Visible = true;
                Second_Big_Car.Visible = false;
                Second_Small_Car.Visible = false;
                Second_Car_Weight.Text = "0";
            }
            if (Occupancy3)
            {
                Third_Place_Red_Diode.Visible = true;
                Third_Place_Green_Diode.Visible = false;
                WeightLogic(3);
            }
            else
            {
                Third_Place_Red_Diode.Visible = false;
                Third_Place_Green_Diode.Visible = true;
                Third_Big_Car.Visible = false;
                Third_Small_Car.Visible = false;
                Third_Car_Weight.Text = "0";
            }
            if (Occupancy4)
            {
                Fourth_Place_Red_Diode.Visible = true;
                Fourth_Place_Green_Diode.Visible = false;
                WeightLogic(4);
            }
            else
            {
                Fourth_Place_Red_Diode.Visible = false;
                Fourth_Place_Green_Diode.Visible = true;
                Fourth_Big_Car.Visible = false;
                Fourth_Small_Car.Visible = false;
                Fourth_Car_Weight.Text = "0";
            }
            if (Occupancy5)
            {
                Fifth_Place_Red_Diode.Visible = true;
                Fifth_Place_Green_Diode.Visible = false;
                WeightLogic(5);
            }
            else
            {
                Fifth_Place_Red_Diode.Visible = false;
                Fifth_Place_Green_Diode.Visible = true;
                Fifth_Big_Car.Visible = false;
                Fifth_Small_Car.Visible = false;
                Fifth_Car_Weight.Text = "0";
            }
            if (Occupancy6)
            {
                Sixth_Place_Red_Diode.Visible = true;
                Sixth_Place_Green_Diode.Visible = false;
                WeightLogic(6);
            }
            else
            {
                Sixth_Place_Red_Diode.Visible = false;
                Sixth_Place_Green_Diode.Visible = true;
                Sixth_Big_Car.Visible = false;
                Sixth_Small_Car.Visible = false;
                Sixth_Car_Weight.Text = "0";
            }
            if (Occupancy7)
            {
                Seventh_Place_Red_Diode.Visible = true;
                Seventh_Place_Green_Diode.Visible = false;
                WeightLogic(7);
            }
            else
            {
                Seventh_Place_Red_Diode.Visible = false;
                Seventh_Place_Green_Diode.Visible = true;
                Seventh_Big_Car.Visible = false;
                Seventh_Small_Car.Visible = false;
                Seventh_Car_Weight.Text = "0";
            }
        }

        public void AlarmsLogic()
        {
            if (engineError_Alarm) {
                engine_error_alarm_green_diode.Visible = true;
                engine_error_alarm_red_diode.Visible = false;
            }
            else
            {
                engine_error_alarm_green_diode.Visible = false;
                engine_error_alarm_red_diode.Visible = true;
            }
            if (controlSystemError_Alarm)
            {
                control_system_error_alarm_green_diode.Visible = true;
                control_system_error_alarm_red_diode.Visible = false;
            }
            else
            {
                control_system_error_alarm_green_diode.Visible = false;
                control_system_error_alarm_red_diode.Visible = true;
            }
            if (entranceSensorError_Alarm)
            {
                entrance_sensors_error_alarm_green_diode.Visible = true;
                entrance_sensors_error_alarm_red_diode.Visible = false;
            }
            else
            {
                entrance_sensors_error_alarm_green_diode.Visible = false;
                entrance_sensors_error_alarm_red_diode.Visible = true;
            }
            if (Error_Alarm)
            {
                algorithm_error_green_diode.Visible = true;
                algorithm_error_red_diode.Visible = false;
            }
            else
            {
                algorithm_error_green_diode.Visible = false;
                algorithm_error_red_diode.Visible = true;
            }
        }

        public void DiagnosticConvert(int i , PictureBox green_diode, PictureBox red_diode)
        {
            switch (i)
            {
                case 2:
                    green_diode.Visible = true;
                    break;
                case 3:
                    red_diode.Visible = false;
                    break;
                default:
                    break;

            }
        }

        public void DiagnosticLogic()
        {
            DiagnosticConvert(RunStop, plc_run_green_diode, plc_run_red_diode);
            DiagnosticConvert(error, plc_error_green_diode, plc_error_red_diode);
            DiagnosticConvert(maint, plc_diagnosing_green_diode, plc_diagnosing_red_diode);
            DiagnosticConvert(link, plc_link_green_diode, plc_link_red_diode);
            DiagnosticConvert(RxTx, plc_rxtx_green_diode, plc_rxtx_red_diode);
        }

        public void RotorLogic()
        {
            if(Parking_in_move == true) 
            {
                Rotor_2.Visible = false;
                Rotor_1.Visible = true;

                Thread.Sleep(20);

                Rotor_1.Visible = false;
                Rotor_2.Visible = true;

                Thread.Sleep(20);
            }
            else
            {
                Rotor_1.Visible = false;
                Rotor_2.Visible = true;
            }
        }

        public void DirectionMovement()
        {
            if (Parking_in_move)
            {
                if (Left_right == true)
                {
                    arrow_right.Visible = true;
                    arrow_left.Visible = false;
                }
                if (Left_right == false)
                {
                    arrow_left.Visible = true;
                    arrow_right.Visible = false;
                }
            }
            else
            {
                arrow_right.Visible = false;
                arrow_left.Visible = false;
            }
            
        }

        public void MainLogic()
        {
            DiagnosticLogic();
            AlarmsLogic();
            RotorLogic();
            DirectionMovement();
            CarAndWeightAndDiodeLogic();

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            
        }
        
        private void Visualization_Load(object sender, EventArgs e)
        {

        }

        private void Weight_Indicator_Load(object sender, EventArgs e)
        {

        }
    }
}
