using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCServer1.Backend.Serwer.Model
{
    public struct PlcDataPackage
    {
        public DateTime Time;

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
        public bool engineError_Notify { get; set; }
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

    }     
}
