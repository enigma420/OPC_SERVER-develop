using OPCServer1.Backend.Database;
using OPCServer1.Backend.Serwer.Model;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OPCServer1.Backend.Serwer.Model.PlcDataPackage;

namespace OPCServer1
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
                    Db3.WriteSingleVariableBool("DB14.DBX0.0", 1);
                    break;
                //Singaling Trips:
                case 1:
                    Db3.WriteSingleVariableBool("DB14.DBX1.4", 1);
                    break;
                case 2:
                    Db3.WriteSingleVariableBool("DB14.DBX1.5", 1);
                    break;
                case 3:
                    Db3.WriteSingleVariableBool("DB14.DBX1.6", 1);
                    break;
                case 4:
                    Db3.WriteSingleVariableBool("DB14.DBX1.7", 1);
                    break;
                case 5:
                    Db3.WriteSingleVariableBool("DB14.DBX2.0", 1);
                    break;
                case 6:
                    Db3.WriteSingleVariableBool("DB14.DBX2.1", 1);
                    break;
                case 7:
                    Db3.WriteSingleVariableBool("DB14.DBX2.2", 1);
                    break;
                case 8:
                    Db3.WriteSingleVariableBool("DB14.DBX2.3", 1);
                    break;
                default:
                    break;
            }
            
        }

    }
}
