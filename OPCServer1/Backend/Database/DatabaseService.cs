using OPCServer1.Backend.Serwer.Model;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace OPCServer1
{
    class DatabaseService
    {
        private MeasurementDatabase MeasurementDatabase;

        public DatabaseService()
        {
            MeasurementDatabase = new MeasurementDatabase();
        }

        public void UpdateDatabaseServiceDbConnectionData(string server, string database, string uid, string password)
        {
            try
            {
                MeasurementDatabase.UpdateMeasurementDatabaseData(server, database, uid, password);
                bool isDbConnected = IsDbConnected();

            } catch (System.NullReferenceException ex)
            {
                Console.WriteLine("Error while updating database service: {0}", ex.ToString());
            }


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

        public MySqlDataReader GetAllSpeedAndTimeData()
        {
            return MeasurementDatabase.GetAllSpeedAndTimeData();
        }

        public bool CloseConnection()
        {
            return MeasurementDatabase.CloseConnection();
        }


        public void CreatePlcDataPackage(PlcDataPackage plcDataPackage)
        {
            MeasurementDatabase.CreatePlcDataPackage(plcDataPackage);
        }
    }
}
