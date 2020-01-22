using OPCServer1.Backend.Serwer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPCServer1
{
    class PlcDatapackageUpdate2
    {
        private DatabaseService databaseService;
        private PlcService plcService;
        private PlcDataPackage plcDataPackage;

        private bool isDatabaseConnected = false;
        private bool isPlcConnected = false;



        public PlcDatapackageUpdate2()
        {
            //RunReadAndWriteToDbPlcDataPackageIntervalRoutine();
            databaseService = new DatabaseService();
            plcService = new PlcService();
            plcDataPackage = new PlcDataPackage{};
        }

        public void UpdateDatabaseServiceDbConnectionData(string server, string database, string uid, string password)
        {
            databaseService.UpdateDatabaseServiceDbConnectionData(server, database, uid, password);
        }

        public void UpdateIsDbConnected(bool isConnected)
        {
            isDatabaseConnected = isConnected;
        }

        public void UpdateIsPlcConnected(bool isConnected)
        {
            isPlcConnected = isConnected;
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
                if (isDatabaseConnected && isPlcConnected)
                {
                    ReadAndWriteToDbPlcDataPackage();
                }


            }
        }

        private void ReadAndWriteToDbPlcDataPackage()
        {
            DateTime now = DateTime.Now;

            plcDataPackage = plcService.ReadPlcDataPackage();

            databaseService.CreatePlcDataPackage(plcDataPackage);

            Diagrams.SetNewSpeedAndTimeData(plcDataPackage.Ramp_actual_speed_freq, plcDataPackage.Time.ToOADate());

            CurrentlyMeasurement.CurrentlyMeasurement_LoadOne(plcDataPackage);

            Visualization.SetNewPlcDataPackage(plcDataPackage);

        }




        //test

        PlcDataPackage data1 = new PlcDataPackage { 
            Occupancy0 = true,
            Occupancy1 = false,
            Occupancy2 = true,
            Occupancy3 = false,
            Occupancy4 = true,
            Occupancy5 = false,
            Occupancy6 = true,
            Occupancy7 = false,
            SignalingTrips0 = true,
            SignalingTrips1 = false,
            SignalingTrips2 = true,
            SignalingTrips3 = false,
            SignalingTrips4 = true,
            SignalingTrips5 = false,
            SignalingTrips6 = true,
            SignalingTrips7 = false,
            PlatformSize0 = true,
            PlatformSize1 = false,
            PlatformSize2 = true,
            PlatformSize3 = false,
            PlatformSize4 = true,
            PlatformSize5 = false,
            PlatformSize6 = true,
            PlatformSize7 = false,
            Weight0 = 123,
            Weight1 = 345,
            Weight2 = 234,
            Weight3 = 555,
            Weight4 = 10,
            Weight5 = 546,
            Weight6 = 59,
            Weight7 = 232,
            Entrance = true,
            Entrance_enabled = false,
            Entrance_big_vehicle = true,
            Entrance_small_vehicle = false,
            Left_right = true,
            Parking_in_move = false,
            Parking_out = true,
            Out_enabled = false,
            Vehicle_too_heavy_for_small_platform = true,
            Parking_occupied = false,
            Big_platform_occupied = true,
            Vehicle_weight = 123,
            Platform_to_rotate_down = 2,
            Rotation_angle = 3,
            Rotation_time = 12,
            Ramp_command_speed_freq = 43,
            Ramp_engine_speed_freq = 22,
            Ramp_actual_speed_freq = 21,
            Minimum_weight = 0,
            Boundary_weight = 54,
            Maximum_weight = 524,
            Inventer_status = 3,
            Inventer_command_speed = 123,
            Inventer_actual_speed = 21,
            RunStop = 2,
            RxTx = 2,
            link = 2,
            error = 2,
            maint = 3,
            RunTimeCycle = 123.12,
            WriteLocalTime = 305,
            engineError_Alarm = false,
            engineError_alarmReset = true,
            engineError_Notify = false,
            engineError_notifyReset = true,
            controlSystemError_Alarm = false,
            controlSystemError_alarmReset = true,
            controlSystemError_Notify = false,
            controlSystemError_notifyReset = true,
            entranceSensorError_Alarm = false,
            entranceSensorError_alarmReset = true,
            vehicleTooHeavy = false,
            Error_Alarm = true,
            Time = DateTime.Now
            };

        PlcDataPackage data2 = new PlcDataPackage
        {
            Occupancy0 = false,
            Occupancy1 = true,
            Occupancy2 = false,
            Occupancy3 = true,
            Occupancy4 = false,
            Occupancy5 = true,
            Occupancy6 = false,
            Occupancy7 = true,
            SignalingTrips0 = false,
            SignalingTrips1 = true,
            SignalingTrips2 = false,
            SignalingTrips3 = true,
            SignalingTrips4 = false,
            SignalingTrips5 = true,
            SignalingTrips6 = false,
            SignalingTrips7 = true,
            PlatformSize0 = false,
            PlatformSize1 = true,
            PlatformSize2 = false,
            PlatformSize3 = true,
            PlatformSize4 = false,
            PlatformSize5 = true,
            PlatformSize6 = false,
            PlatformSize7 = true,
            Weight0 = 13,
            Weight1 = 35,
            Weight2 = 24,
            Weight3 = 55,
            Weight4 = 100,
            Weight5 = 56,
            Weight6 = 9,
            Weight7 = 22,
            Entrance = false,
            Entrance_enabled = true,
            Entrance_big_vehicle = false,
            Entrance_small_vehicle = true,
            Left_right = false,
            Parking_in_move = true,
            Parking_out = false,
            Out_enabled = true,
            Vehicle_too_heavy_for_small_platform = false,
            Parking_occupied = true,
            Big_platform_occupied = false,
            Vehicle_weight = 13,
            Platform_to_rotate_down = 4,
            Rotation_angle = 3,
            Rotation_time = 12,
            Ramp_command_speed_freq = 43,
            Ramp_engine_speed_freq = 22,
            Ramp_actual_speed_freq = 21,
            Minimum_weight = 0,
            Boundary_weight = 54,
            Maximum_weight = 524,
            Inventer_status = 3,
            Inventer_command_speed = 123,
            Inventer_actual_speed = 21,
            RunStop = 2,
            RxTx = 2,
            link = 2,
            error = 2,
            maint = 3,
            RunTimeCycle = 123.12,
            WriteLocalTime = 305,
            engineError_Alarm = true,
            engineError_alarmReset = false,
            engineError_Notify = true,
            engineError_notifyReset = false,
            controlSystemError_Alarm = true,
            controlSystemError_alarmReset = false,
            controlSystemError_Notify = true,
            controlSystemError_notifyReset = false,
            entranceSensorError_Alarm = true,
            entranceSensorError_alarmReset = false,
            vehicleTooHeavy = true,
            Error_Alarm = false,
            Time = DateTime.Now
        };

        private static int TestSize = 1000;
        int wait = 0;
        int count = 0;
        int sleep = 120;

        public void startTest()
        {
            WriteToDbPlcDataPackageIntervalTest3();
        }

        private double average(DateTime[][] times)
        {
            double sum = 0;
            try
            {
                foreach (DateTime[] time in times)
                {
                    sum += (time[1].ToOADate() - time[0].ToOADate());
                }
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine("Error while counting average err: {0}", ex.ToString());
            }

            return sum / TestSize;
        }


        private void WriteToDbPlcDataPackageIntervalTest3()
        {
            DateTime startTime = DateTime.Now;
            Console.WriteLine("Test 3 started {0}", startTime.ToString());
            for (int i = 0; i < TestSize; i++)
            {
                WriteToDbPlcDataPackage3();
                Thread.Sleep(sleep);
                count++;
            }
            count = 0;
            DateTime endTime = DateTime.Now;

            double total = startTime.ToOADate() - endTime.ToOADate();
            Console.WriteLine("Test 3 start time {0}", startTime.ToString());
            //Console.WriteLine("Test 3 finished {0}\nAverage write1: {1}\nAverage write2: {2}\nAverage write3: {3}\nAverage write4: {4}\nAverage write all: {5}\nTotal: {6}",
            //    endTime.ToString(), average(writeTimes1), average(writeTimes2), average(writeTimes3), average(writeTimes4), average(startEndTimes), total);
            Console.WriteLine("Test 3 finished {0}\nTotal: {1}",
                endTime.ToString(), total);
        }


      

        private void WriteToDbPlcDataPackage3()
        {
            PlcDataPackage testData = data1;
            if (count%2 == 0)
            {
                testData = data2;
            }

            databaseService.CreatePlcDataPackage(testData);

            Diagrams.SetNewSpeedAndTimeData(testData.Ramp_actual_speed_freq, testData.Time.ToOADate());

            CurrentlyMeasurement.CurrentlyMeasurement_LoadOne(testData);

            Visualization.SetNewPlcDataPackage(testData);
        }

        

    }


}
