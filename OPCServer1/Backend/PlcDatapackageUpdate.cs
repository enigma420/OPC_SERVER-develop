using OPCServer1.Backend.Serwer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OPCServer1
{
    class PlcDatapackageUpdate
    {
        private DatabaseService databaseService;
        private PlcService plcService;
        private bool isDatabaseConnected = false;
        private bool isPlcConnected = false;

        public PlcDatapackageUpdate()
        {
            RunReadAndWriteToDbPlcDataPackageIntervalRoutine();
            databaseService = new DatabaseService();
            plcService = new PlcService();
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

                Thread.Sleep(10000);
            }
        }

        private void ReadAndWriteToDbPlcDataPackage()
        {
            //Initizalization

            PlcDataPackage dataPackage;

            //Read

            dataPackage = plcService.ReadPlcDataPackage();

            //Write

            //PlcSrv.WritePlcDataSingleVariablePackage(dataPackage);


            databaseService.CreatePlcDataPackage(dataPackage);
            Visualization.SetNewPlcDataPackage(dataPackage);
            Diagrams.SetNewSpeedAndTimeData(dataPackage.Ramp_actual_speed_freq, dataPackage.Time.ToOADate());
            CurrentlyMeasurement.CurrentlyMeasurement_LoadOne(dataPackage);

        }
    }
}
