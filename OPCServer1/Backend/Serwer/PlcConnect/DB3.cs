using OPCServer1.Backend.Serwer.Model;
using S7.Net;
using System;

namespace OPCServer1.Backend.Database
{
    public class DB3
    {

        private CpuType PlcCpuType = CpuType.S71200;
        private string IpAdress = "192.168.0.2";
        private short Slot = 1;
        private short Rack = 0;

        Plc PlcConnection;

        public DB3()
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
            Console.WriteLine("Polaczono z PLC");
            if (result != ErrorCode.NoError)
            {
                Console.WriteLine("Error: " + PlcConnection.LastErrorCode + "\n" + PlcConnection.LastErrorString);
                return false;
            }

            return true;
        }

        public void WriteSingleVariableBool(string dataBlockVariable, int value)
        {
            PlcConnection.Write(dataBlockVariable, value);
            Console.WriteLine("dataBlock:{0} , value:{1}", dataBlockVariable, value);
        }


        public PlcDataPackage ReadPlcDataBytesPackage()
        {
            PlcDataPackage plcDataPackage = new PlcDataPackage{};
            try
            {
                plcDataPackage = ReadBytess(PlcConnection);
                //Console.WriteLine("Dane zostaja zczytane");
                Console.WriteLine(plcDataPackage.Ramp_actual_speed_freq);
            } catch (Exception ex)
            {
                //Console.WriteLine("Nie polaczony z PLC , Nie mozna zczytac danych: {0}",ex); //Console.WriteLine("Error: " + PlcConnection.LastErrorCode + "\n" + PlcConnection.LastErrorString);
            }
            return plcDataPackage;
        }


        public PlcDataPackage ReadBytess(Plc plc)
        {
            // Console.WriteLine("\n--- DB 3 ---\n");
            PlcDataPackage data = new PlcDataPackage{};
            

            var db3Bytes = (byte[])plc.Read(DataType.DataBlock, 3, 0, VarType.Byte, 3);

            //  Console.WriteLine("\n--- ZAJETOSC ---\n");



            data.Occupancy0 = db3Bytes[0].SelectBit(0);
            //Console.WriteLine("DB3.DBX0.0: " + db3Bool1);
            data.Occupancy1 = db3Bytes[0].SelectBit(1);
            // Console.WriteLine("DB3.DBX0.1: " + db3Bool2);
            data.Occupancy2 = db3Bytes[0].SelectBit(2);
            // Console.WriteLine("DB3.DBX0.2: " + db3Bool3);
            data.Occupancy3 = db3Bytes[0].SelectBit(3);
            // Console.WriteLine("DB3.DBX0.3: " + db3Bool4);
            data.Occupancy4 = db3Bytes[0].SelectBit(4);
            // Console.WriteLine("DB3.DBX0.4: " + db3Bool5);
            data.Occupancy5 = db3Bytes[0].SelectBit(5);
            // Console.WriteLine("DB3.DBX0.5: " + db3Bool6);
            data.Occupancy6 = db3Bytes[0].SelectBit(6);
            //  Console.WriteLine("DB3.DBX0.6: " + db3Bool7);
            data.Occupancy7 = db3Bytes[0].SelectBit(7);
            //Console.WriteLine("DB3.DBX0.7: " + db3Bool8);

            // Console.WriteLine("\n---SYGNALIZACJA WYJAZDU ---\n");

            data.SignalingTrips0 = db3Bytes[1].SelectBit(0);
            // Console.WriteLine("DB3.DBX1.0: " + db3Bool11);
            data.SignalingTrips1 = db3Bytes[1].SelectBit(1);
            //  Console.WriteLine("DB3.DBX1.1: " + db3Bool12);
            data.SignalingTrips2 = db3Bytes[1].SelectBit(2);
            //  Console.WriteLine("DB3.DBX1.2: " + db3Bool13);
            data.SignalingTrips3 = db3Bytes[1].SelectBit(3);
            //  Console.WriteLine("DB3.DBX1.3: " + db3Bool14);
            data.SignalingTrips4 = db3Bytes[1].SelectBit(4);
            //  Console.WriteLine("DB3.DBX1.4: " + db3Bool15);
            data.SignalingTrips5 = db3Bytes[1].SelectBit(5);
            //  Console.WriteLine("DB3.DBX1.5: " + db3Bool16);
            data.SignalingTrips6 = db3Bytes[1].SelectBit(6);
            //  Console.WriteLine("DB3.DBX1.6: " + db3Bool17);
            data.SignalingTrips7 = db3Bytes[1].SelectBit(7);
            //  Console.WriteLine("DB3.DBX1.7: " + db3Bool18);

            //   Console.WriteLine("\n--- WIELKOSC PLATFORM---\n");

            data.PlatformSize0 = db3Bytes[2].SelectBit(0);
            //   Console.WriteLine("DB3.DBX2.0: " + db3Bool21);
            data.PlatformSize1 = db3Bytes[2].SelectBit(1);
            //   Console.WriteLine("DB3.DBX2.1: " + db3Bool22);
            data.PlatformSize2 = db3Bytes[2].SelectBit(2);
            //    Console.WriteLine("DB3.DBX2.2: " + db3Bool23);
            data.PlatformSize3 = db3Bytes[2].SelectBit(3);
            //   Console.WriteLine("DB3.DBX2.3: " + db3Bool24);
            data.PlatformSize4 = db3Bytes[2].SelectBit(4);
            //   Console.WriteLine("DB3.DBX2.4: " + db3Bool25);
            data.PlatformSize5 = db3Bytes[2].SelectBit(5);
            //    Console.WriteLine("DB3.DBX2.5: " + db3Bool26);
            data.PlatformSize6 = db3Bytes[2].SelectBit(6);
            //   Console.WriteLine("DB3.DBX2.6: " + db3Bool27);
            data.PlatformSize7 = db3Bytes[2].SelectBit(7);
            //    Console.WriteLine("DB3.DBX2.7: " + db3Bool28);

            //   Console.WriteLine("\n--- WAGA POJAZDU---\n");

            data.Weight0 = ((ushort)plc.Read("DB3.DBW22.0")).ConvertToShort();
            //   Console.WriteLine("DB3.DBW22.0: " + db3IntVariable1);
            data.Weight1 = ((ushort)plc.Read("DB3.DBW24.0")).ConvertToShort();
            //    Console.WriteLine("DB3.DBW24.0: " + db3IntVariable2);
            data.Weight2 = ((ushort)plc.Read("DB3.DBW26.0")).ConvertToShort();
            //    Console.WriteLine("DB3.DBW26.0: " + db3IntVariable3);
            data.Weight3 = ((ushort)plc.Read("DB3.DBW28.0")).ConvertToShort();
            //    Console.WriteLine("DB3.DBW28.0: " + db3IntVariable4);
            data.Weight4 = ((ushort)plc.Read("DB3.DBW30.0")).ConvertToShort();
            ////    Console.WriteLine("DB3.DBW30.0: " + db3IntVariable5);
            data.Weight5 = ((ushort)plc.Read("DB3.DBW32.0")).ConvertToShort();
            //    Console.WriteLine("DB3.DBW32.0: " + db3IntVariable6);
            data.Weight6 = ((ushort)plc.Read("DB3.DBW34.0")).ConvertToShort();
            //   Console.WriteLine("DB3.DBW34.0: " + db3IntVariable7);
            data.Weight7 = ((ushort)plc.Read("DB3.DBW36.0")).ConvertToShort();
        //    Console.WriteLine("DB3.DBW36.0: " + db3IntVariable8);

        //    Console.WriteLine("\n--- DB 14 ---\n");

            var db14Bytes = (byte[])plc.Read(DataType.DataBlock, 14, 0, VarType.Byte, 2);

            //     Console.WriteLine("\n--- BOOLEAN: ---\n");

            data.Entrance = db14Bytes[0].SelectBit(0);
            //    Console.WriteLine("DB14.DBX0.0: " + db14Bool1);
            data.Entrance_enabled = db14Bytes[0].SelectBit(1);
            //     Console.WriteLine("DB14.DBX0.1: " + db14Bool2);
            data.Entrance_big_vehicle = db14Bytes[0].SelectBit(2);
            //     Console.WriteLine("DB14.DBX0.2: " + db14Bool3);
            data.Entrance_small_vehicle = db14Bytes[0].SelectBit(3);
            //    Console.WriteLine("DB14.DBX0.3: " + db14Bool4);
            data.Left_right = db14Bytes[0].SelectBit(4);
            //     Console.WriteLine("DB14.DBX0.4: " + db14Bool5);
            data.Parking_in_move = db14Bytes[0].SelectBit(5);
            //     Console.WriteLine("DB14.DBX0.5: " + db14Bool6);
            data.Parking_out = db14Bytes[0].SelectBit(6);
            //     Console.WriteLine("DB14.DBX0.6: " + db14Bool7);
            data.Out_enabled = db14Bytes[0].SelectBit(7);
            //     Console.WriteLine("DB14.DBX0.7: " + db14Bool8);
            data.Vehicle_too_heavy_for_small_platform = db14Bytes[1].SelectBit(0);
            //     Console.WriteLine("DB14.DBX0.7: " + db14Bool8);
            data.Parking_occupied = db14Bytes[1].SelectBit(1);
            //    Console.WriteLine("DB14.DBX1.0: " + db14Bool9);
            data.Big_platform_occupied = db14Bytes[1].SelectBit(2);
            //    Console.WriteLine("DB14.DBX1.1: " + db14Bool10);

            //     Console.WriteLine("\n--- INT ---\n");

            data.Vehicle_weight = ((ushort)plc.Read("DB14.DBW4.0")).ConvertToShort();
            //     Console.WriteLine("DB14.DBW2.0: " + db14IntVariable1);
            data.Platform_to_rotate_down = ((ushort)plc.Read("DB14.DBW6.0")).ConvertToShort();
            //     Console.WriteLine("DB14.DBW4.0: " + db14IntVariable2);
            data.Rotation_angle = ((ushort)plc.Read("DB14.DBW8.0")).ConvertToShort();
            //     Console.WriteLine("DB14.DBW6.0: " + db14IntVariable3);

            //      Console.WriteLine("\n--- DINT ---\n");

            data.Rotation_time = ((uint)plc.Read("DB14.DBD10.0")).ConvertToInt();
            //     Console.WriteLine("DB14.DBD8.0: " + db14DintVariable1);

            //      Console.WriteLine("\n--- REAL ---\n");

            data.Ramp_command_speed_freq = ((uint)plc.Read("DB14.DBD14.0")).ConvertToDouble();
            //     Console.WriteLine("DB14.DBD12.0: " + db14RealVariable1);
            data.Ramp_engine_speed_freq = ((uint)plc.Read("DB14.DBD18.0")).ConvertToDouble();
            //     Console.WriteLine("DB14.DBD16.0: " + db14RealVariable2);
            data.Ramp_actual_speed_freq = ((uint)plc.Read("DB14.DBD22.0")).ConvertToDouble();
            //      Console.WriteLine("DB14.DBD20.0: " + db14RealVariable3);
            data.Minimum_weight = ((uint)plc.Read("DB14.DBD26.0")).ConvertToDouble();
            //     Console.WriteLine("DB14.DBD12.0: " + db14RealVariable1);
            data.Boundary_weight = ((uint)plc.Read("DB14.DBD30.0")).ConvertToDouble();
            //     Console.WriteLine("DB14.DBD16.0: " + db14RealVariable2);
            data.Maximum_weight = ((uint)plc.Read("DB14.DBD34.0")).ConvertToDouble();
            //      Console.WriteLine("DB14.DBD20.0: " + db14RealVariable3);

            //     Console.WriteLine("\n--- WORD ---\n");

            data.Inventer_status = ((ushort)plc.Read("DB14.DBW38.0")).ConvertToShort();
            //     Console.WriteLine("DB14.DBW24.0: " + db14WordVariable1);
            data.Inventer_command_speed = ((ushort)plc.Read("DB14.DBW40.0")).ConvertToShort();
            //    Console.WriteLine("DB14.DBW28.0: " + db14WordVariable2);
            data.Inventer_actual_speed = ((ushort)plc.Read("DB14.DBW42.0")).ConvertToShort();
            //    Console.WriteLine("DB14.DBW32.0: " + db14WordVariable3);




            //Diagnostyczne DB29 inty
            //0.0
            data.RunStop = ((ushort)plc.Read("DB29.DBW0.0")).ConvertToShort();
            data.RxTx = ((ushort)plc.Read("DB29.DBW2.0")).ConvertToShort();
            data.link = ((ushort)plc.Read("DB29.DBW4.0")).ConvertToShort();
            data.error = ((ushort)plc.Read("DB29.DBW6.0")).ConvertToShort();
            data.maint = ((ushort)plc.Read("DB29.DBW8.0")).ConvertToShort();
            data.RunTimeCycle = ((uint)plc.Read("DB14.DBD18.0")).ConvertToDouble();
            data.WriteLocalTime = ((ushort)plc.Read("DB29.DBW26.0")).ConvertToShort();
            //Alarmowe DB16 od 0.0 do 1.3

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