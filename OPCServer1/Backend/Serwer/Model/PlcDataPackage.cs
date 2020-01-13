using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCServer1.Backend.Serwer.Model
{
    public class PlcDataPackage
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
            
            
           public PlcDataPackage(bool occupancy0, bool occupancy1, bool occupancy2, bool occupancy3, bool occupancy4, bool occupancy5, bool occupancy6, bool occupancy7,
              bool platformSize0, bool platformSize1, bool platformSize2, bool platformSize3, bool platformSize4, bool platformSize5, bool platformSize6, bool platformSize7,
              bool signalingTrips0, bool signalingTrips1, bool signalingTrips2, bool signalingTrips3, bool signalingTrips4, bool signalingTrips5, bool signalingTrips6, bool signalingTrips7,
              bool entrance, bool entrance_enabled, bool entrance_big_vehicle, bool entrance_small_vehicle, bool left_right, bool parking_in_move, bool parking_out, bool out_enabled, bool vehicle_too_heavy_for_small_platform, bool parking_occupied, bool big_platform_occupied,
              int weight0, int weight1, int weight2, int weight3, int weight4, int weight5, int weight6, int weight7, int vehicle_weight, int platform_to_rotate_down, int rotation_angle, int rotation_time,
              double ramp_command_speed_freq, double ramp_engine_speed_freq, double ramp_actual_speed_freq, double minimum_weight, double boundary_weight, double maximum_weight, int inventer_status, int inventer_command_speed, int inventer_actual_speed)
        {
            this.Occupancy0 = occupancy0;
            this.Occupancy1 = occupancy1;
            this.Occupancy2 = occupancy2;
            this.Occupancy3 = occupancy3;
            this.Occupancy4 = occupancy4;
            this.Occupancy5 = occupancy5;
            this.Occupancy6 = occupancy6;
            this.Occupancy7 = occupancy7;

            this.PlatformSize0 = platformSize0;
            this.PlatformSize1 = platformSize1;
            this.PlatformSize2 = platformSize2;
            this.PlatformSize3 = platformSize3;
            this.PlatformSize4 = platformSize4;
            this.PlatformSize5 = platformSize5;
            this.PlatformSize6 = platformSize6;
            this.PlatformSize7 = platformSize7;

            this.SignalingTrips0 = signalingTrips0;
            this.SignalingTrips1 = signalingTrips1;
            this.SignalingTrips2 = signalingTrips2;
            this.SignalingTrips3 = signalingTrips3;
            this.SignalingTrips4 = signalingTrips4;
            this.SignalingTrips5 = signalingTrips5;
            this.SignalingTrips6 = signalingTrips6;
            this.SignalingTrips7 = signalingTrips7;

            this.Entrance = entrance;
            this.Entrance_enabled = entrance_enabled;
            this.Entrance_big_vehicle = entrance_big_vehicle;
            this.Entrance_small_vehicle = entrance_small_vehicle;
            this.Left_right = left_right;
            this.Parking_in_move = parking_in_move;
            this.Parking_out = parking_out;
            this.Out_enabled = out_enabled;
            this.Vehicle_too_heavy_for_small_platform = vehicle_too_heavy_for_small_platform;
            this.Parking_occupied = parking_occupied;
            this.Big_platform_occupied = big_platform_occupied;

            this.Weight0 = weight0;
            this.Weight1 = weight1;
            this.Weight2 = weight2;
            this.Weight3 = weight3;
            this.Weight4 = weight4;
            this.Weight5 = weight5;
            this.Weight6 = weight6;
            this.Weight7 = weight7;

            this.Vehicle_weight = vehicle_weight;
            this.Platform_to_rotate_down = platform_to_rotate_down;
            this.Rotation_angle = rotation_angle;
            this.Rotation_time = rotation_time;

            this.Ramp_command_speed_freq = ramp_command_speed_freq;
            this.Ramp_engine_speed_freq = ramp_engine_speed_freq;
            this.Ramp_actual_speed_freq = ramp_actual_speed_freq;
            this.Minimum_weight = minimum_weight;
            this.Boundary_weight = boundary_weight;
            this.Maximum_weight = maximum_weight;

            this.Inventer_status = inventer_status;
            this.Inventer_command_speed = inventer_command_speed;
            this.Inventer_actual_speed = inventer_actual_speed;

        }

        public PlcDataPackage()
        {
            
        }
        
    }
}
