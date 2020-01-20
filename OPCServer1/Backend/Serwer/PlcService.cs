using OPCServer1.Backend.Database;
using OPCServer1.Backend.Serwer.Model;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OPCServer1.Backend.Serwer.Model.PlcDataPackage;

namespace OPCServer1.Backend.Serwer
{
    public class PlcService
    {
        
        private DB3 Db3;
        private static bool isPlcConnected = false;

        public struct Measurement
        {
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
        }

        private Measurement[] data;

        public Measurement[] ExportData()
        {
            return data;
        }

        public Measurement[] DataProperty
        {
            get { return data; }
        }


        public PlcService()
        {
            //tworze DB3 ale łącze się dopiero po wprowadzeniu danych
            Db3 = new DB3();
        }

        public bool OpenConnection(CpuType plcCpuType, string ipAdress, short rack, short slot)
        {
            isPlcConnected = Db3.OpenConnection(plcCpuType, ipAdress, rack, slot);
            return isPlcConnected;
        }

        public PlcDataPackage ReadPlcDataPackage()
        {
            return Db3.ReadPlcDataBytesPackage();
        }

        public void WritePlcDataSingleVariablePackage(int value)
        {
            switch (value)
            {
                //Entrance:
                case 0:
                    Db3.WritePlcDataSingleVariable("DB14.DBX0.0", true);
                    break;
                //Singaling Trips:
                case 1:
                    Db3.WritePlcDataSingleVariable("DB3.DBX1.0", true);
                    break;
                case 2:
                    Db3.WritePlcDataSingleVariable("DB3.DBX1.1", true);
                    break;
                case 3:
                    Db3.WritePlcDataSingleVariable("DB3.DBX1.2", true);
                    break;
                case 4:
                    Db3.WritePlcDataSingleVariable("DB3.DBX1.3", true);
                    break;
                case 5:
                    Db3.WritePlcDataSingleVariable("DB3.DBX1.4", true);
                    break;
                case 6:
                    Db3.WritePlcDataSingleVariable("DB3.DBX1.5", true);
                    break;
                case 7:
                    Db3.WritePlcDataSingleVariable("DB3.DBX1.6", true);
                    break;
                case 8:
                    Db3.WritePlcDataSingleVariable("DB3.DBX1.7", true);
                    break;
                default:
                    break;
            }
            
        }

        public static bool IsPlcConnected()
        {
            return isPlcConnected;
        }

    }
}
