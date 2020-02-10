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
        
        private PlcConn plcConn;

        public PlcService()
        {
            //tworze DB3 ale łącze się dopiero po wprowadzeniu danych
            plcConn = new PlcConn();
        }

        public bool OpenConnection(CpuType plcCpuType, string ipAdress, short rack, short slot)
        {
            return plcConn.OpenConnection(plcCpuType, ipAdress, rack, slot);
        }

        public void CloseConnection()
        {
           plcConn.CloseConnection();
        }

        public PlcDataPackage ReadPlcDataPackage()
        {
            return plcConn.ReadPlcDataBytesPackage();
        }

        public void WriteEntrancePlcDataSingleVariablePackage(int value)
        {
            switch (value)
            {
                case 0:
                    plcConn.WriteSingleVariableBool("DB14.DBX0.0", 1);
                    break;
                case 1:
                    plcConn.WriteSingleVariableBool("DB14.DBX1.4", 1);
                    break;
                case 2:
                    plcConn.WriteSingleVariableBool("DB14.DBX1.5", 1);
                    break;
                case 3:
                    plcConn.WriteSingleVariableBool("DB14.DBX1.6", 1);
                    break;
                case 4:
                    plcConn.WriteSingleVariableBool("DB14.DBX1.7", 1);
                    break;
                case 5:
                    plcConn.WriteSingleVariableBool("DB14.DBX2.0", 1);
                    break;
                case 6:
                    plcConn.WriteSingleVariableBool("DB14.DBX2.1", 1);
                    break;
                case 7:
                    plcConn.WriteSingleVariableBool("DB14.DBX2.2", 1);
                    break;
                case 8:
                    plcConn.WriteSingleVariableBool("DB14.DBX2.3", 1);
                    break;
                default:
                    break;
            }
            
        }
        public void WriteWeightPlcDataSingleVariablePackage(int value, double weight)
        {
            switch (value)
            {
                case 0:
                    plcConn.WriteWeightSingleVariableBool("DB14.DBD26.0", weight);
                    break;
                case 1:
                    plcConn.WriteWeightSingleVariableBool("DB14.DBD30.0", weight);
                    break;
                case 2:
                    plcConn.WriteWeightSingleVariableBool("DB14.DBD34.0", weight);
                    break;
                default:
                    break;
            }
        }

        public void WriteEliminateErrorsPlcDataSingleVariablePackage(int value)
        {
            switch (value)
            {
                case 0:
                    plcConn.WriteSingleVariableBool("DB16.DBX0.1", 1);
                    break;
                case 1:
                    plcConn.WriteSingleVariableBool("DB16.DBX0.3", 1);
                    break;
                case 2:
                    plcConn.WriteSingleVariableBool("DB16.DBX0.5", 1);
                    break;
                case 3:
                    plcConn.WriteSingleVariableBool("DB16.DBX0.7", 1);
                    break;
                case 4:
                    plcConn.WriteSingleVariableBool("DB16.DBX1.1", 1);
                    break;
                default:
                    break;
            }
        }

    }
}
