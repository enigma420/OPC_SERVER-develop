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
            isPlcConnected = PlcService.IsPlcConnected();
            RunReadAndWriteToDbPlcDataPackageIntervalRoutine();
        }

        public void UpdateDatabaseServiceDbConnectionData(string server, string database, string uid, string password)
        {
            MeasurementDatabase.UpdateMeasurementDatabaseData(server, database, uid, password);
            isDbConnected = MeasurementDatabase.IsDbConnected();
        }

        public static void UpdateIsPlcConnected()
        {
            isPlcConnected = PlcService.IsPlcConnected();
        }

        public bool IsDbConnected()
        {
            return MeasurementDatabase.IsDbConnected();
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
                
                Thread.Sleep(1000);
            }
        }

        private void ReadAndWriteToDbPlcDataPackage()
        {
            //Initizalization

            PlcDataPackage dataPackage;

            //Read

            dataPackage = PlcSrv.ReadPlcDataPackage();

            //Write

            //First Option

            //PlcSrv./*WritePlcDataBytesPackage*/(dataPackage);

            //Second Option

            //PlcSrv.WritePlcDataSingleVariablePackage(dataPackage);
            

            MeasurementDatabase.CreatePlcDataPackage(dataPackage);


            
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
