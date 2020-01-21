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

        public PlcService()
        {
            //tworze DB3 ale łącze się dopiero po wprowadzeniu danych
            Db3 = new DB3();
        }

        public bool OpenConnection(CpuType plcCpuType, string ipAdress, short rack, short slot)
        {
            return Db3.OpenConnection(plcCpuType, ipAdress, rack, slot);
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
                    Db3.WriteSingleVariableBool("DB14.DBX0.0", true);
                    break;
                //Singaling Trips:
                case 1:
                    Db3.WriteSingleVariableBool("DB3.DBX1.0", true);
                    break;
                case 2:
                    Db3.WriteSingleVariableBool("DB3.DBX1.1", true);
                    break;
                case 3:
                    Db3.WriteSingleVariableBool("DB3.DBX1.2", true);
                    break;
                case 4:
                    Db3.WriteSingleVariableBool("DB3.DBX1.3", true);
                    break;
                case 5:
                    Db3.WriteSingleVariableBool("DB3.DBX1.4", true);
                    break;
                case 6:
                    Db3.WriteSingleVariableBool("DB3.DBX1.5", true);
                    break;
                case 7:
                    Db3.WriteSingleVariableBool("DB3.DBX1.6", true);
                    break;
                case 8:
                    Db3.WriteSingleVariableBool("DB3.DBX1.7", true);
                    break;
                default:
                    break;
            }
            
        }

    }
}
