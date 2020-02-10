using OPCServer1.Backend.Serwer.Model;
using S7.Net;
using System;
using System.Windows.Forms;

namespace OPCServer1.Backend.Database
{
    public class PlcConn
    {

        private CpuType PlcCpuType = CpuType.S71200;
        private string IpAdress = "192.168.0.2";
        private short Slot = 1;
        private short Rack = 0;

        Plc PlcConnection;

        public PlcConn()
        {
            PlcConnection = new Plc(PlcCpuType, IpAdress, Rack , Slot);
            PlcConnection.Open();
        }

        public bool OpenConnection(CpuType plcCpuType, string ipAdress, short rack, short slot)
        {
            PlcCpuType = plcCpuType;
            IpAdress = ipAdress;
            Slot = slot;
            Rack = rack;

            PlcConnection = new Plc(plcCpuType, ipAdress, rack, slot);
            ErrorCode result = PlcConnection.Open();            
            if (result != ErrorCode.NoError)
            {
                Console.WriteLine("Błąd: " + PlcConnection.LastErrorCode + "\n" + PlcConnection.LastErrorString);
                return false;
            }
            else
            {
                Console.WriteLine("Polaczono z PLC");
            }
            return true;
        }

        public void CloseConnection()
        {
            if (PlcConnection.IsConnected == true)
            {
                PlcConnection.Close();
            }
            else
            {
                MessageBox.Show("NIE MOŻNA ROZŁĄCZYĆ SIĘ ZE STEROWNIKIEM => NIE JESTEŚ POŁĄCZONY");
            }
        }

        public void WriteSingleVariableBool(string dataBlockVariable, int value)
        {
            PlcConnection.Write(dataBlockVariable, value);
        }
        public void WriteWeightSingleVariableBool(string dataBlockVariable, double weight)
        {
            double weightAfterConvert = weight.ConvertToUInt();           
            PlcConnection.Write(dataBlockVariable, weight);
        }


        public PlcDataPackage ReadPlcDataBytesPackage()
        {
            PlcDataPackage plcDataPackage = new PlcDataPackage{};
            try
            {
                plcDataPackage = ReadBytess(PlcConnection);            
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nie można pobrać danych");
            }
            return plcDataPackage;
        }


        public PlcDataPackage ReadBytess(Plc plc)
        {
            PlcDataPackage data = new PlcDataPackage{};

            var db3Bytes = (byte[])plc.Read(DataType.DataBlock, 3, 0, VarType.Byte, 3);

            data.Occupancy0 = db3Bytes[0].SelectBit(0);
            data.Occupancy1 = db3Bytes[0].SelectBit(1);
            data.Occupancy2 = db3Bytes[0].SelectBit(2);
            data.Occupancy3 = db3Bytes[0].SelectBit(3);
            data.Occupancy4 = db3Bytes[0].SelectBit(4);
            data.Occupancy5 = db3Bytes[0].SelectBit(5);
            data.Occupancy6 = db3Bytes[0].SelectBit(6);
            data.Occupancy7 = db3Bytes[0].SelectBit(7);

            data.SignalingTrips0 = db3Bytes[1].SelectBit(0);
            data.SignalingTrips1 = db3Bytes[1].SelectBit(1);
            data.SignalingTrips2 = db3Bytes[1].SelectBit(2);
            data.SignalingTrips3 = db3Bytes[1].SelectBit(3);
            data.SignalingTrips4 = db3Bytes[1].SelectBit(4);
            data.SignalingTrips5 = db3Bytes[1].SelectBit(5);
            data.SignalingTrips6 = db3Bytes[1].SelectBit(6);
            data.SignalingTrips7 = db3Bytes[1].SelectBit(7);
        
            data.PlatformSize0 = db3Bytes[2].SelectBit(0);
            data.PlatformSize1 = db3Bytes[2].SelectBit(1);
            data.PlatformSize2 = db3Bytes[2].SelectBit(2);
            data.PlatformSize3 = db3Bytes[2].SelectBit(3);
            data.PlatformSize4 = db3Bytes[2].SelectBit(4);
            data.PlatformSize5 = db3Bytes[2].SelectBit(5);
            data.PlatformSize6 = db3Bytes[2].SelectBit(6);
            data.PlatformSize7 = db3Bytes[2].SelectBit(7);
   
            data.Weight0 = ((ushort)plc.Read("DB3.DBW22.0")).ConvertToShort();
            data.Weight1 = ((ushort)plc.Read("DB3.DBW24.0")).ConvertToShort();
            data.Weight2 = ((ushort)plc.Read("DB3.DBW26.0")).ConvertToShort();
            data.Weight3 = ((ushort)plc.Read("DB3.DBW28.0")).ConvertToShort();
            data.Weight4 = ((ushort)plc.Read("DB3.DBW30.0")).ConvertToShort();
            data.Weight5 = ((ushort)plc.Read("DB3.DBW32.0")).ConvertToShort();
            data.Weight6 = ((ushort)plc.Read("DB3.DBW34.0")).ConvertToShort();
            data.Weight7 = ((ushort)plc.Read("DB3.DBW36.0")).ConvertToShort();

            //var db33Bytes = (byte[])plc.Read(DataType.DataBlock, 3, 38, VarType.Byte, 1);

            //data.VehicleSize0 = db33Bytes[0].SelectBit(0);
            //data.VehicleSize1 = db33Bytes[0].SelectBit(1);
            //data.VehicleSize2 = db33Bytes[0].SelectBit(2);
            //data.VehicleSize3 = db33Bytes[0].SelectBit(3);
            //data.VehicleSize4 = db33Bytes[0].SelectBit(4);
            //data.VehicleSize5 = db33Bytes[0].SelectBit(5);
            //data.VehicleSize6 = db33Bytes[0].SelectBit(6);
            //data.VehicleSize7 = db33Bytes[0].SelectBit(7);

            var db14Bytes = (byte[])plc.Read(DataType.DataBlock, 14, 0, VarType.Byte, 2);

            data.Entrance = db14Bytes[0].SelectBit(0);
            data.Entrance_enabled = db14Bytes[0].SelectBit(1);
            data.Entrance_big_vehicle = db14Bytes[0].SelectBit(2);
            data.Entrance_small_vehicle = db14Bytes[0].SelectBit(3);
            data.Left_right = db14Bytes[0].SelectBit(4);
            data.Parking_in_move = db14Bytes[0].SelectBit(5);
            data.Parking_out = db14Bytes[0].SelectBit(6);
            data.Out_enabled = db14Bytes[0].SelectBit(7);
            data.Vehicle_too_heavy_for_small_platform = db14Bytes[1].SelectBit(0);
            data.Parking_occupied = db14Bytes[1].SelectBit(1);
            data.Big_platform_occupied = db14Bytes[1].SelectBit(2);
            

            data.Vehicle_weight = ((ushort)plc.Read("DB14.DBW4.0")).ConvertToShort();
            data.Platform_to_rotate_down = ((ushort)plc.Read("DB14.DBW6.0")).ConvertToShort();
            data.Rotation_angle = ((ushort)plc.Read("DB14.DBW8.0")).ConvertToShort();
            data.Rotation_time = ((uint)plc.Read("DB14.DBD10.0")).ConvertToInt();
            data.Ramp_command_speed_freq = ((uint)plc.Read("DB14.DBD14.0")).ConvertToDouble();
            data.Ramp_engine_speed_freq = ((uint)plc.Read("DB14.DBD18.0")).ConvertToDouble();
            data.Ramp_actual_speed_freq = ((uint)plc.Read("DB14.DBD22.0")).ConvertToDouble();
            data.Minimum_weight = ((uint)plc.Read("DB14.DBD26.0")).ConvertToDouble();
            data.Boundary_weight = ((uint)plc.Read("DB14.DBD30.0")).ConvertToDouble();
            data.Maximum_weight = ((uint)plc.Read("DB14.DBD34.0")).ConvertToDouble();
            data.Inventer_status = ((ushort)plc.Read("DB14.DBW38.0")).ConvertToShort();
            data.Inventer_command_speed = ((ushort)plc.Read("DB14.DBW40.0")).ConvertToShort();
            data.Inventer_actual_speed = ((ushort)plc.Read("DB14.DBW42.0")).ConvertToShort();

            data.RunStop = ((ushort)plc.Read("DB29.DBW0.0")).ConvertToShort();
            data.RxTx = ((ushort)plc.Read("DB29.DBW2.0")).ConvertToShort();
            data.link = ((ushort)plc.Read("DB29.DBW4.0")).ConvertToShort();
            data.error = ((ushort)plc.Read("DB29.DBW6.0")).ConvertToShort();
            data.maint = ((ushort)plc.Read("DB29.DBW8.0")).ConvertToShort();
            data.RunTimeCycle = ((uint)plc.Read("DB14.DBD18.0")).ConvertToDouble();
            data.WriteLocalTime = ((ushort)plc.Read("DB29.DBW26.0")).ConvertToShort();

            var db16Bytes = (byte[])plc.Read(DataType.DataBlock, 16, 0, VarType.Byte, 2);

            data.engineError_Alarm = db16Bytes[0].SelectBit(0);
            data.engineError_alarmReset = db16Bytes[0].SelectBit(1);
            data.engineError_Notify = db16Bytes[0].SelectBit(2);
            data.engineError_notifyReset = db16Bytes[0].SelectBit(3);
            data.controlSystemError_Alarm = db16Bytes[0].SelectBit(4);
            data.controlSystemError_alarmReset = db16Bytes[0].SelectBit(5);
            data.controlSystemError_Notify = db16Bytes[0].SelectBit(6);
            data.controlSystemError_notifyReset = db16Bytes[0].SelectBit(7);
            data.entranceSensorError_Alarm = db16Bytes[1].SelectBit(0);
            data.entranceSensorError_alarmReset = db16Bytes[1].SelectBit(1);
            data.vehicleTooHeavy = db16Bytes[1].SelectBit(2);
            data.Error_Alarm = db16Bytes[1].SelectBit(3);

            data.Time = DateTime.Now;

            return data;
        }
    }
}