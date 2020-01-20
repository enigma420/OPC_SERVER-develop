using OPCServer1.Backend.Serwer.Model;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OPCServer1.Backend.Serwer.Model.PlcDataPackage;
using static OPCServer1.Backend.Serwer.PlcService;

namespace OPCServer1.Backend.Database
{
    public class DB3 : PlcDataPackage
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
            //if (result != ErrorCode.NoError)
            //{
            //    Console.WriteLine("Error: " + PlcConnection.LastErrorCode + "\n" + PlcConnection.LastErrorString);
            //}
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

        public bool ReadSingleVariableBool(string dataBlockVariable)
        {
            return (bool)PlcConnection.Read(dataBlockVariable);
        }

        public uint ReadSingleVariableUint(string dataBlockVariable)
        {
            return (uint)PlcConnection.Read(dataBlockVariable);
        }

        public void WriteSingleVariableBool(string dataBlockVariable, bool value)
        {
            PlcConnection.Write(dataBlockVariable, value);
        }

        public void WriteSingleVariableUint(string dataBlockVariable, uint value)
        {
            PlcConnection.Write(dataBlockVariable, value);
        }

        //public PlcDataPackage ReadPlcBytesDataPackage()
        //{

        //}

        public PlcDataPackage ReadPlcDataBytesPackage()
        {
            try
            {
                PlcDataPackage plcDataPackage = ReadBytess(PlcConnection);
                Console.WriteLine("Dane zostaja zczytane");
            } catch (Exception ex)
            {
                Console.WriteLine("Nie polaczony z PLC , Nie mozna zczytac danych: {0}",ex); //Console.WriteLine("Error: " + PlcConnection.LastErrorCode + "\n" + PlcConnection.LastErrorString);
            }
            return new PlcDataPackage(Occupancy0, Occupancy1, Occupancy2, Occupancy3, Occupancy4, Occupancy5, Occupancy6, Occupancy7,
                PlatformSize0, PlatformSize1, PlatformSize2, PlatformSize3, PlatformSize4, PlatformSize5, PlatformSize6, PlatformSize7,
                SignalingTrips0, SignalingTrips1, SignalingTrips2, SignalingTrips3, SignalingTrips4, SignalingTrips5, SignalingTrips6, SignalingTrips7,
                Entrance, Entrance_enabled, Entrance_big_vehicle, Entrance_small_vehicle, Left_right, Parking_in_move, Parking_out, Out_enabled, Vehicle_too_heavy_for_small_platform, Parking_occupied, Big_platform_occupied,
                Weight0, Weight1, Weight2, Weight3, Weight4, Weight5, Weight6, Weight7, Vehicle_weight, Platform_to_rotate_down, Rotation_angle, Rotation_time, Ramp_command_speed_freq, Ramp_engine_speed_freq, Ramp_actual_speed_freq,
                Minimum_weight, Boundary_weight, Maximum_weight, Inventer_status, Inventer_command_speed, Inventer_actual_speed); ;
        }


        public PlcDataPackage ReadBytess(Plc plc)
        {
            // Console.WriteLine("\n--- DB 3 ---\n");

            

            var db3Bytes = (byte[])plc.Read(DataType.DataBlock, 3, 0, VarType.Byte, 3);

            //  Console.WriteLine("\n--- ZAJETOSC ---\n");



            Occupancy0 = db3Bytes[0].SelectBit(0);
            //Console.WriteLine("DB3.DBX0.0: " + db3Bool1);
            Occupancy1 = db3Bytes[0].SelectBit(1);
            // Console.WriteLine("DB3.DBX0.1: " + db3Bool2);
            Occupancy2 = db3Bytes[0].SelectBit(2);
            // Console.WriteLine("DB3.DBX0.2: " + db3Bool3);
            Occupancy3 = db3Bytes[0].SelectBit(3);
            // Console.WriteLine("DB3.DBX0.3: " + db3Bool4);
            Occupancy4 = db3Bytes[0].SelectBit(4);
            // Console.WriteLine("DB3.DBX0.4: " + db3Bool5);
            Occupancy5 = db3Bytes[0].SelectBit(5);
            // Console.WriteLine("DB3.DBX0.5: " + db3Bool6);
            Occupancy6 = db3Bytes[0].SelectBit(6);
            //  Console.WriteLine("DB3.DBX0.6: " + db3Bool7);
            Occupancy7 = db3Bytes[0].SelectBit(7);
            //Console.WriteLine("DB3.DBX0.7: " + db3Bool8);

            // Console.WriteLine("\n---SYGNALIZACJA WYJAZDU ---\n");

            SignalingTrips0 = db3Bytes[1].SelectBit(0);
            // Console.WriteLine("DB3.DBX1.0: " + db3Bool11);
            SignalingTrips1 = db3Bytes[1].SelectBit(1);
          //  Console.WriteLine("DB3.DBX1.1: " + db3Bool12);
            SignalingTrips2 = db3Bytes[1].SelectBit(2);
            //  Console.WriteLine("DB3.DBX1.2: " + db3Bool13);
            SignalingTrips3 = db3Bytes[1].SelectBit(3);
            //  Console.WriteLine("DB3.DBX1.3: " + db3Bool14);
            SignalingTrips4 = db3Bytes[1].SelectBit(4);
            //  Console.WriteLine("DB3.DBX1.4: " + db3Bool15);
            SignalingTrips5 = db3Bytes[1].SelectBit(5);
            //  Console.WriteLine("DB3.DBX1.5: " + db3Bool16);
            SignalingTrips6 = db3Bytes[1].SelectBit(6);
            //  Console.WriteLine("DB3.DBX1.6: " + db3Bool17);
            SignalingTrips7 = db3Bytes[1].SelectBit(7);
            //  Console.WriteLine("DB3.DBX1.7: " + db3Bool18);

            //   Console.WriteLine("\n--- WIELKOSC PLATFORM---\n");

            PlatformSize0 = db3Bytes[2].SelectBit(0);
            //   Console.WriteLine("DB3.DBX2.0: " + db3Bool21);
            PlatformSize1 = db3Bytes[2].SelectBit(1);
            //   Console.WriteLine("DB3.DBX2.1: " + db3Bool22);
            PlatformSize2 = db3Bytes[2].SelectBit(2);
            //    Console.WriteLine("DB3.DBX2.2: " + db3Bool23);
            PlatformSize3 = db3Bytes[2].SelectBit(3);
            //   Console.WriteLine("DB3.DBX2.3: " + db3Bool24);
            PlatformSize4 = db3Bytes[2].SelectBit(4);
            //   Console.WriteLine("DB3.DBX2.4: " + db3Bool25);
            PlatformSize5 = db3Bytes[2].SelectBit(5);
            //    Console.WriteLine("DB3.DBX2.5: " + db3Bool26);
            PlatformSize6 = db3Bytes[2].SelectBit(6);
            //   Console.WriteLine("DB3.DBX2.6: " + db3Bool27);
            PlatformSize7 = db3Bytes[2].SelectBit(7);
            //    Console.WriteLine("DB3.DBX2.7: " + db3Bool28);

            //   Console.WriteLine("\n--- WAGA POJAZDU---\n");

            Weight0 = ((ushort)plc.Read("DB3.DBW22.0")).ConvertToShort();
            //   Console.WriteLine("DB3.DBW22.0: " + db3IntVariable1);
            Weight1 = ((ushort)plc.Read("DB3.DBW24.0")).ConvertToShort();
            //    Console.WriteLine("DB3.DBW24.0: " + db3IntVariable2);
            Weight2 = ((ushort)plc.Read("DB3.DBW26.0")).ConvertToShort();
            //    Console.WriteLine("DB3.DBW26.0: " + db3IntVariable3);
            Weight3 = ((ushort)plc.Read("DB3.DBW28.0")).ConvertToShort();
            //    Console.WriteLine("DB3.DBW28.0: " + db3IntVariable4);
            Weight4 = ((ushort)plc.Read("DB3.DBW30.0")).ConvertToShort();
            ////    Console.WriteLine("DB3.DBW30.0: " + db3IntVariable5);
            Weight5 = ((ushort)plc.Read("DB3.DBW32.0")).ConvertToShort();
            //    Console.WriteLine("DB3.DBW32.0: " + db3IntVariable6);
            Weight6 = ((ushort)plc.Read("DB3.DBW34.0")).ConvertToShort();
            //   Console.WriteLine("DB3.DBW34.0: " + db3IntVariable7);
            Weight7 = ((ushort)plc.Read("DB3.DBW36.0")).ConvertToShort();
        //    Console.WriteLine("DB3.DBW36.0: " + db3IntVariable8);

        //    Console.WriteLine("\n--- DB 14 ---\n");

            var db14Bytes = (byte[])plc.Read(DataType.DataBlock, 14, 0, VarType.Byte, 2);

            //     Console.WriteLine("\n--- BOOLEAN: ---\n");

            Entrance = db14Bytes[0].SelectBit(0);
            //    Console.WriteLine("DB14.DBX0.0: " + db14Bool1);
            Entrance_enabled = db14Bytes[0].SelectBit(1);
            //     Console.WriteLine("DB14.DBX0.1: " + db14Bool2);
            Entrance_big_vehicle = db14Bytes[0].SelectBit(2);
            //     Console.WriteLine("DB14.DBX0.2: " + db14Bool3);
            Entrance_small_vehicle = db14Bytes[0].SelectBit(3);
            //    Console.WriteLine("DB14.DBX0.3: " + db14Bool4);
            Left_right = db14Bytes[0].SelectBit(4);
            //     Console.WriteLine("DB14.DBX0.4: " + db14Bool5);
            Parking_in_move = db14Bytes[0].SelectBit(5);
            //     Console.WriteLine("DB14.DBX0.5: " + db14Bool6);
            Parking_out = db14Bytes[0].SelectBit(6);
            //     Console.WriteLine("DB14.DBX0.6: " + db14Bool7);
            Out_enabled = db14Bytes[0].SelectBit(7);
            //     Console.WriteLine("DB14.DBX0.7: " + db14Bool8);
            Vehicle_too_heavy_for_small_platform = db14Bytes[1].SelectBit(0);
            //     Console.WriteLine("DB14.DBX0.7: " + db14Bool8);
            Parking_occupied = db14Bytes[1].SelectBit(1);
            //    Console.WriteLine("DB14.DBX1.0: " + db14Bool9);
            Big_platform_occupied = db14Bytes[1].SelectBit(2);
            //    Console.WriteLine("DB14.DBX1.1: " + db14Bool10);

            //     Console.WriteLine("\n--- INT ---\n");

            Vehicle_weight = ((ushort)plc.Read("DB14.DBW2.0")).ConvertToShort();
            //     Console.WriteLine("DB14.DBW2.0: " + db14IntVariable1);
            Platform_to_rotate_down = ((ushort)plc.Read("DB14.DBW4.0")).ConvertToShort();
            //     Console.WriteLine("DB14.DBW4.0: " + db14IntVariable2);
            Rotation_angle = ((ushort)plc.Read("DB14.DBW6.0")).ConvertToShort();
            //     Console.WriteLine("DB14.DBW6.0: " + db14IntVariable3);

            //      Console.WriteLine("\n--- DINT ---\n");

            Rotation_time = ((uint)plc.Read("DB14.DBD8.0")).ConvertToInt();
            //     Console.WriteLine("DB14.DBD8.0: " + db14DintVariable1);

            //      Console.WriteLine("\n--- REAL ---\n");

            Ramp_command_speed_freq = ((uint)plc.Read("DB14.DBD12.0")).ConvertToDouble();
            //     Console.WriteLine("DB14.DBD12.0: " + db14RealVariable1);
            Ramp_engine_speed_freq = ((uint)plc.Read("DB14.DBD16.0")).ConvertToDouble();
            //     Console.WriteLine("DB14.DBD16.0: " + db14RealVariable2);
            Ramp_actual_speed_freq = ((uint)plc.Read("DB14.DBD20.0")).ConvertToDouble();
            //      Console.WriteLine("DB14.DBD20.0: " + db14RealVariable3);
            Minimum_weight = ((uint)plc.Read("DB14.DBD24.0")).ConvertToDouble();
            //     Console.WriteLine("DB14.DBD12.0: " + db14RealVariable1);
            Boundary_weight = ((uint)plc.Read("DB14.DBD28.0")).ConvertToDouble();
            //     Console.WriteLine("DB14.DBD16.0: " + db14RealVariable2);
            Maximum_weight = ((uint)plc.Read("DB14.DBD32.0")).ConvertToDouble();
            //      Console.WriteLine("DB14.DBD20.0: " + db14RealVariable3);

            //     Console.WriteLine("\n--- WORD ---\n");

            Inventer_status = ((ushort)plc.Read("DB14.DBW36.0")).ConvertToShort();
            //     Console.WriteLine("DB14.DBW24.0: " + db14WordVariable1);
            Inventer_command_speed = ((ushort)plc.Read("DB14.DBW38.0")).ConvertToShort();
            //    Console.WriteLine("DB14.DBW28.0: " + db14WordVariable2);
            Inventer_actual_speed = ((ushort)plc.Read("DB14.DBW40.0")).ConvertToShort();
            //    Console.WriteLine("DB14.DBW32.0: " + db14WordVariable3);

            return new PlcDataPackage();
        }


        public void WritePlcDataSingleVariable(String key, bool value)
        {
                PlcConnection.Write(key, value);
                Console.WriteLine("key:{0} , value:{1}", key, value);  
        }
    }
}