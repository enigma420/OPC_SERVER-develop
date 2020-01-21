using OPCServer1.Backend.Serwer;
using OPCServer1.Backend.Serwer.Model;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static OPCServer1.Backend.Serwer.Model.PlcDataPackage;
using MySql.Data.MySqlClient;
using System.Data;

namespace OPCServer1
{
    class DatabaseService
    {
        private MeasurementDatabase MeasurementDatabase;
        private PlcService PlcSrv;
        private bool isDbConnected = false;
        private static bool isPlcConnected = false;

        public DatabaseService()
        {
            MeasurementDatabase = new MeasurementDatabase();
            PlcSrv = new PlcService();
            isDbConnected = MeasurementDatabase.IsDbConnected();
            isPlcConnected = false;
            RunReadAndWriteToDbPlcDataPackageIntervalRoutine();
        }

        public void UpdateDatabaseServiceDbConnectionData(string server, string database, string uid, string password)
        {
            try
            {
                MeasurementDatabase.UpdateMeasurementDatabaseData(server, database, uid, password);
                isDbConnected = MeasurementDatabase.IsDbConnected();
            } catch (System.NullReferenceException ex)
            {
                Console.WriteLine("Error while updating database service: {0}", ex.ToString());
            }

            testSetNewDataPackageVisualizationAndCurrentlyMeasurment();

        }

        public static void UpdateIsPlcConnected(bool isConnected)
        {
            isPlcConnected = isConnected;
        }

        public bool IsDbConnected()
        {
            bool isConnected = false;
            try
            {
                 isConnected = MeasurementDatabase.IsDbConnected();
            }
            catch (System.NullReferenceException ex)
            {
                Console.WriteLine("Error checking if db is connected: {0}", ex.ToString());
            }
            return isConnected;
        }

        public bool IsDbAndPlcConnected()
        {
            return isDbConnected && isPlcConnected;
        }

        private void RunReadAndWriteToDbPlcDataPackageIntervalRoutine()
        {
            Thread InstanceCaller = new Thread(new ThreadStart(ReadAndWriteToDbPlcDataPackageInterval));
            InstanceCaller.Start();
        }

        private void ReadAndWriteToDbPlcDataPackageInterval()
        {
            for (; ; )
            {
                if (isDbConnected && isPlcConnected)
                {
                    ReadAndWriteToDbPlcDataPackage();
                }
                
                Thread.Sleep(10000);
            }
        }

        private void ReadAndWriteToDbPlcDataPackage()
        {
            //Initizalization

            PlcDataPackage dataPackage;

            //Read

            dataPackage = PlcSrv.ReadPlcDataPackage();

            //Write

            //PlcSrv.WritePlcDataSingleVariablePackage(dataPackage);
            

            MeasurementDatabase.CreatePlcDataPackage(dataPackage);
            Visualization.SetNewPlcDataPackage(dataPackage);
            Diagrams.SetNewSpeedAndTimeData(dataPackage.Ramp_actual_speed_freq, dataPackage.Time.ToOADate());
            CurrentlyMeasurement.CurrentlyMeasurement_LoadOne(dataPackage);

        }

        private void testSetNewDataPackageVisualizationAndCurrentlyMeasurment()
        {
            PlcDataPackage data = new PlcDataPackage{};

            data.Occupancy0 = true;
            data.Occupancy1 = false;
            data.Occupancy2 = true;
            data.Occupancy3 = false;
            data.Occupancy4 = true;
            data.Occupancy5 = false;
            data.Occupancy6 = true;
            data.Occupancy7 = false;

            data.SignalingTrips0 = true;
            data.SignalingTrips1 = false;
            data.SignalingTrips2 = true;
            data.SignalingTrips3 = false;
            data.SignalingTrips4 = true;
            data.SignalingTrips5 = false;
            data.SignalingTrips6 = true;
            data.SignalingTrips7 = false;

            data.PlatformSize0 = true;
            data.PlatformSize1 = false;
            data.PlatformSize2 = true;
            data.PlatformSize3 = false;
            data.PlatformSize4 = true;
            data.PlatformSize5 = false;
            data.PlatformSize6 = true;
            data.PlatformSize7 = false;

            data.Weight0 = 123;
            data.Weight1 = 345;
            data.Weight2 = 234;
            data.Weight3 = 555;
            data.Weight4 = 10;
            data.Weight5 = 546;
            data.Weight6 = 59;
            data.Weight7 = 232;

            data.Entrance = true;
            data.Entrance_enabled = false;
            data.Entrance_big_vehicle = true;
            data.Entrance_small_vehicle = false;
            data.Left_right = true;
            data.Parking_in_move = false;
            data.Parking_out = true;
            data.Out_enabled = false;
            data.Vehicle_too_heavy_for_small_platform = true;
            data.Parking_occupied = false;
            data.Big_platform_occupied = true;

            data.Vehicle_weight = 123;
            data.Platform_to_rotate_down = 2;
            data.Rotation_angle = 3;

            data.Rotation_time = 12;

            data.Ramp_command_speed_freq = 43;
            data.Ramp_engine_speed_freq = 22;
            data.Ramp_actual_speed_freq = 21;
            data.Minimum_weight = 0;
            data.Boundary_weight = 54;
            data.Maximum_weight = 524;

            data.Inventer_status = 3;
            data.Inventer_command_speed = 123;
            data.Inventer_actual_speed = 21;


            //Diagnostyczne DB29 inty
            //0.0
            data.RunStop =1;
            data.RxTx = 2;
            data.link = 3;
            data.error = 4;
            data.maint = 5;
            data.RunTimeCycle = true;
            data.WriteLocalTime = true;
            //Alarmowe DB16 od 0.0 do 1.3
            data.engineError_Alarm = false;
            data.engineError_alarmReset = true;
            data.engineError_Notify = false;
            data.engineError_notifyReset = true;
            data.controlSystemError_Alarm = false;
            data.controlSystemError_alarmReset = true;
            data.controlSystemError_Notify = false;
            data.controlSystemError_notifyReset = true;
            data.entranceSensorError_Alarm = false;
            data.entranceSensorError_alarmReset = true;
            data.vehicleTooHeavy = false;
            data.Error_Alarm = true;

            data.Time = DateTime.Now;

            Visualization.SetNewPlcDataPackage(data);
            CurrentlyMeasurement.CurrentlyMeasurement_LoadOne(data);
            Diagrams.SetNewSpeedAndTimeData(data.Ramp_actual_speed_freq, data.Time.ToOADate());
        }

        public MySqlDataReader GetNewestMeasurment()
        {
            return MeasurementDatabase.GetNewestMeasurment();
        }

        public MySqlDataReader GetAllSpeedAndTimeData()
        {
            return MeasurementDatabase.GetAllSpeedAndTimeData();
        }

        public MySqlDataReader GetNewestSpeedAndTimeData()
        {
            return MeasurementDatabase.GetNewestSpeedAndTimeData();
        }

        public bool CloseConnection()
        {
            return MeasurementDatabase.CloseConnection();
        }

        public DataTable GetData(string selectCommand)
        {
            return MeasurementDatabase.GetData(selectCommand);
        }
    }
}
