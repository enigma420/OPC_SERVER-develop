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
            RunReadAndWriteToDbPlcDataPackageIntervalRoutine();
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

        private void ReadToDbPlcDataPackage()
        {
            plcDataPackage = plcService.ReadPlcDataPackage();

            databaseService.CreatePlcDataPackage(plcDataPackage);

            Diagrams.SetNewSpeedAndTimeData(plcDataPackage.Ramp_actual_speed_freq, plcDataPackage.Time.ToOADate());

            Visualization.SetNewPlcDataPackage(plcDataPackage);
        }
        private void ReadToDbPlcDataPackageInterval()
        {
            for (; ; )
            {
                if (isDatabaseConnected && isPlcConnected)
                {
                    ReadToDbPlcDataPackage();
                }
            }
        }
        private void RunReadAndWriteToDbPlcDataPackageIntervalRoutine()
        {
            Thread InstanceCaller = new Thread(new ThreadStart(ReadToDbPlcDataPackageInterval));
            InstanceCaller.Start();
        }


       
    }


}
