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

        public void WritePlcDataBytesPackage(PlcDataPackage plcDataPackage)
        {
            Db3.WritePlcDataBytesPackage(plcDataPackage);
        }

        public void WritePlcDataSingleVariablePackage(PlcDataPackage plcDataPackage)
        {
            Db3.WritePlcDataSingleVariable(plcDataPackage);
        }

        public static bool IsPlcConnected()
        {
            return isPlcConnected;
        }

    }
}
