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
using OPCServer1.Backend.Serwer.Model;

namespace OPCServer1
{
    public partial class Visualization : Form
    {
        private static Visualization Instance = null;
        private static PlcDataPackage data;
      

        public Visualization()
        {
            InitializeComponent();
            Instance = this;
        }


        public static void SetNewPlcDataPackage(PlcDataPackage newData)
        {
            try
            {
                data = newData;
                Instance.updateVisualizationData();
            } catch(NullReferenceException ex)
            {
                //błąd występuje jak użytkonik nie otworzyl wizualizacji
                Console.WriteLine("Visualization is not open, err: {0}", ex);
            }
            
        }

        private void updateVisualizationData()
        {
            MainLogic();
        }

        public void WeightLogic(int i)
        {

            if (data.Entrance_enabled)
            {
                if (data.Entrance)
                {
                    Entrance_Green_Diode.Visible = true;
                    Entrance_Red_Diode.Visible = false;
                    entrance_weight.Text = data.Vehicle_weight.ToString();
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
                    if (data.Weight0 < data.Maximum_weight || data.Minimum_weight < data.Weight0)
                    {
                        if (data.Boundary_weight > data.Weight0)
                        {
                            Zero_Small_Car.Visible = true;
                            Zero_Big_Car.Visible = false;
                            Zero_Car_Weight.Text = data.Weight0.ToString();
                        }
                        else
                        {
                            Zero_Small_Car.Visible = false;
                            Zero_Big_Car.Visible = true;
                            Zero_Car_Weight.Text = data.Weight0.ToString();
                        }
                    }
                    else
                    {
                        Zero_Small_Car.Visible = false;
                        Zero_Big_Car.Visible = false;
                    }
                    break;
                case 1:
                    if (data.Weight1 < data.Maximum_weight || data.Minimum_weight < data.Weight1)
                    {
                        if (data.Boundary_weight > data.Weight1)
                        {
                            First_Small_Car.Visible = true;
                            First_Big_Car.Visible = false;
                            First_Car_Weight.Text = data.Weight1.ToString();
                        }
                        else
                        {
                            First_Small_Car.Visible = false;
                            First_Big_Car.Visible = true;
                            First_Car_Weight.Text = data.Weight1.ToString();
                        }
                    }
                    else
                    {
                        First_Small_Car.Visible = false;
                        First_Big_Car.Visible = false;
                    }
                    break;
                case 2:
                    if (data.Weight2 < data.Maximum_weight || data.Minimum_weight < data.Weight2)
                    {
                        if (data.Boundary_weight > data.Weight2)
                        {
                            Second_Small_Car.Visible = true;
                            Second_Big_Car.Visible = false;
                            Second_Car_Weight.Text = data.Weight2.ToString();
                        }
                        else
                        {
                            Second_Small_Car.Visible = false;
                            Second_Big_Car.Visible = true;
                            Second_Car_Weight.Text = data.Weight2.ToString();
                        }
                    }
                    else
                    {
                        Second_Small_Car.Visible = false;
                        Second_Big_Car.Visible = false;
                    }
                    break;
                case 3:
                    if (data.Weight3 < data.Maximum_weight || data.Minimum_weight < data.Weight3) { 
                        if (data.Boundary_weight > data.Weight3)
                        {
                            Third_Small_Car.Visible = true;
                            Third_Big_Car.Visible = false;
                            Third_Car_Weight.Text = data.Weight3.ToString();
                        }
                        else
                        {
                            Third_Small_Car.Visible = false;
                            Third_Big_Car.Visible = true;
                            Third_Car_Weight.Text = data.Weight3.ToString();
                        } }
                    else
                    {
                        Third_Small_Car.Visible = false;
                        Third_Big_Car.Visible = false;
                    }
                    break;
                case 4:
                    if (data.Weight4 < data.Maximum_weight || data.Minimum_weight < data.Weight4)
                    {
                        if (data.Boundary_weight > data.Weight4)
                        {
                            Fourth_Small_Car.Visible = true;
                            Fourth_Big_Car.Visible = false;
                            Fourth_Car_Weight.Text = data.Weight4.ToString();
                        }
                        else
                        {
                            Fourth_Small_Car.Visible = false;
                            Fourth_Big_Car.Visible = true;
                            Fourth_Car_Weight.Text = data.Weight4.ToString();
                        }
                    }
                    else
                    {
                        Fourth_Small_Car.Visible = false;
                        Fourth_Big_Car.Visible = false;
                    } 
                    break;
                case 5:
                    if (data.Weight5 < data.Maximum_weight || data.Minimum_weight < data.Weight5)
                    {
                        if (data.Boundary_weight > data.Weight5)
                        {
                            Fifth_Small_Car.Visible = true;
                            Fifth_Big_Car.Visible = false;
                            Fifth_Car_Weight.Text = data.Weight5.ToString();
                        }
                        else
                        {
                            Fifth_Small_Car.Visible = false;
                            Fifth_Big_Car.Visible = true;
                            Fifth_Car_Weight.Text = data.Weight5.ToString();
                        }
                    }
                    else
                    {
                        Fifth_Small_Car.Visible = false;
                        Fifth_Big_Car.Visible = false;
                    }
                    break;
                case 6:
                    if (data.Weight6 < data.Maximum_weight || data.Minimum_weight < data.Weight6)
                    {
                        if (data.Boundary_weight > data.Weight6)
                        {
                            Sixth_Small_Car.Visible = true;
                            Sixth_Big_Car.Visible = false;
                            Sixth_Car_Weight.Text = data.Weight6.ToString();
                        }
                        else
                        {
                            Sixth_Small_Car.Visible = false;
                            Sixth_Big_Car.Visible = true;
                            Sixth_Car_Weight.Text = data.Weight6.ToString();
                        }
                    }
                    else
                    {
                        Sixth_Small_Car.Visible = false;
                        Sixth_Big_Car.Visible = false;
                    }
                    break;
                case 7:
                    if (data.Weight7 < data.Maximum_weight || data.Minimum_weight < data.Weight7)
                    {
                        if (data.Boundary_weight > data.Weight7)
                        {
                            Seventh_Small_Car.Visible = true;
                            Seventh_Big_Car.Visible = false;
                            Seventh_Car_Weight.Text = data.Weight7.ToString();
                        }
                        else
                        {
                            Seventh_Small_Car.Visible = false;
                            Seventh_Big_Car.Visible = true;
                            Seventh_Car_Weight.Text = data.Weight7.ToString();
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
            if (data.Occupancy0) {
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
            if (data.Occupancy1)
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
            if (data.Occupancy2)
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
            if (data.Occupancy3)
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
            if (data.Occupancy4)
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
            if (data.Occupancy5)
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
            if (data.Occupancy6)
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
            if (data.Occupancy7)
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
            if (data.engineError_Alarm) {
                engine_error_alarm_green_diode.Visible = true;
                engine_error_alarm_red_diode.Visible = false;
            }
            else
            {
                engine_error_alarm_green_diode.Visible = false;
                engine_error_alarm_red_diode.Visible = true;
            }
            if (data.controlSystemError_Alarm)
            {
                control_system_error_alarm_green_diode.Visible = true;
                control_system_error_alarm_red_diode.Visible = false;
            }
            else
            {
                control_system_error_alarm_green_diode.Visible = false;
                control_system_error_alarm_red_diode.Visible = true;
            }
            if (data.entranceSensorError_Alarm)
            {
                entrance_sensors_error_alarm_green_diode.Visible = true;
                entrance_sensors_error_alarm_red_diode.Visible = false;
            }
            else
            {
                entrance_sensors_error_alarm_green_diode.Visible = false;
                entrance_sensors_error_alarm_red_diode.Visible = true;
            }
            if (data.Error_Alarm)
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
            DiagnosticConvert(data.RunStop, plc_run_green_diode, plc_run_red_diode);
            DiagnosticConvert(data.error, plc_error_green_diode, plc_error_red_diode);
            DiagnosticConvert(data.maint, plc_diagnosing_green_diode, plc_diagnosing_red_diode);
            DiagnosticConvert(data.link, plc_link_green_diode, plc_link_red_diode);
            DiagnosticConvert(data.RxTx, plc_rxtx_green_diode, plc_rxtx_red_diode);
        }

        public void RotorLogic()
        {
            if(data.Parking_in_move == true) 
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
            if (data.Parking_in_move)
            {
                if (data.Left_right == true)
                {
                    arrow_right.Visible = true;
                    arrow_left.Visible = false;
                }
                if (data.Left_right == false)
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
