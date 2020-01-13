using OPCServer1.Backend.Database;
using OPCServer1.Backend.Serwer;
using OPCServer1.Forms;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPCServer1
{
    class Program
    {
        static void Main(string[] args)
        {
            //MeasurementDatabase measurement = new MeasurementDatabase();

            //measurement.createMeasurementTableIfNotExists();

            //DateTime time = DateTime.Now;
            //Measurement measurementSaveToDbExample = new Measurement(1.25, 1.22, 1,126, 1, 18, 15, 14, 22, 34, 25, 45, 26, 5, 23, 4, 46, 5.353 ,time);

            //measurement.createMeasurement(measurementSaveToDbExample);


            //Console.WriteLine(time);

            //DatabaseService databaseService = new DatabaseService();
            //databaseService.UpdateDatabaseService("localhost", "serveropc", "dominik", "qwerty123");


            //void ReadBytess(Plc plc)
            //{
            //    Console.WriteLine("\n--- DB 3 ---\n");

            //    var db3Bytes = (byte[])plc.Read(DataType.DataBlock, 3, 0, VarType.Byte, 3);

            //    Console.WriteLine("\n--- ZAJETOSC ---\n");



            //    var Occupancy0 = db3Bytes[0].SelectBit(0);
            //    Console.WriteLine("DB3.DBX0.0: " + Occupancy0);
            //    var Occupancy1 = db3Bytes[0].SelectBit(1);
            //    Console.WriteLine("DB3.DBX0.1: " + Occupancy1);
            //    var Occupancy2 = db3Bytes[0].SelectBit(2);
            //    Console.WriteLine("DB3.DBX0.2: " + Occupancy2);
            //    var Occupancy3 = db3Bytes[0].SelectBit(3);
            //    Console.WriteLine("DB3.DBX0.3: " + Occupancy3);
            //    var Occupancy4 = db3Bytes[0].SelectBit(4);
            //    Console.WriteLine("DB3.DBX0.4: " + Occupancy4);
            //    var Occupancy5 = db3Bytes[0].SelectBit(5);
            //    Console.WriteLine("DB3.DBX0.5: " + Occupancy5);
            //    var Occupancy6 = db3Bytes[0].SelectBit(6);
            //    Console.WriteLine("DB3.DBX0.6: " + Occupancy6);
            //    var Occupancy7 = db3Bytes[0].SelectBit(7);
            //    Console.WriteLine("DB3.DBX0.7: " + Occupancy7);

            //    Console.WriteLine("\n---SYGNALIZACJA WYJAZDU ---\n");

            //    var SignalingTrips0 = db3Bytes[1].SelectBit(0);
            //    Console.WriteLine("DB3.DBX1.0: " + SignalingTrips0);
            //    var SignalingTrips1 = db3Bytes[1].SelectBit(1);
            //    Console.WriteLine("DB3.DBX1.1: " + SignalingTrips1);
            //    var SignalingTrips2 = db3Bytes[1].SelectBit(2);
            //    Console.WriteLine("DB3.DBX1.2: " + SignalingTrips2);
            //    var SignalingTrips3 = db3Bytes[1].SelectBit(3);
            //    Console.WriteLine("DB3.DBX1.3: " + SignalingTrips3);
            //    var SignalingTrips4 = db3Bytes[1].SelectBit(4);
            //    Console.WriteLine("DB3.DBX1.4: " + SignalingTrips4);
            //    var SignalingTrips5 = db3Bytes[1].SelectBit(5);
            //    Console.WriteLine("DB3.DBX1.5: " + SignalingTrips5);
            //    var SignalingTrips6 = db3Bytes[1].SelectBit(6);
            //    Console.WriteLine("DB3.DBX1.6: " + SignalingTrips6);
            //    var SignalingTrips7 = db3Bytes[1].SelectBit(7);
            //    Console.WriteLine("DB3.DBX1.7: " + SignalingTrips7);

            //    Console.WriteLine("\n--- WIELKOSC PLATFORM---\n");

            //    var PlatformSize0 = db3Bytes[2].SelectBit(0);
            //    Console.WriteLine("DB3.DBX2.0: " + PlatformSize0);
            //    var PlatformSize1 = db3Bytes[2].SelectBit(1);
            //    Console.WriteLine("DB3.DBX2.1: " + PlatformSize1);
            //    var PlatformSize2 = db3Bytes[2].SelectBit(2);
            //    Console.WriteLine("DB3.DBX2.2: " + PlatformSize2);
            //    var PlatformSize3 = db3Bytes[2].SelectBit(3);
            //    Console.WriteLine("DB3.DBX2.3: " + PlatformSize3);
            //    var PlatformSize4 = db3Bytes[2].SelectBit(4);
            //    Console.WriteLine("DB3.DBX2.4: " + PlatformSize4);
            //    var PlatformSize5 = db3Bytes[2].SelectBit(5);
            //    Console.WriteLine("DB3.DBX2.5: " + PlatformSize5);
            //    var PlatformSize6 = db3Bytes[2].SelectBit(6);
            //    Console.WriteLine("DB3.DBX2.6: " + PlatformSize6);
            //    var PlatformSize7 = db3Bytes[2].SelectBit(7);
            //    Console.WriteLine("DB3.DBX2.7: " + PlatformSize7);

            //    var Weight0 = ((ushort)plc.Read("DB3.DBW22.0")).ConvertToShort();
            //    Console.WriteLine("DB3.DBW22.0: " + Weight0);
            //    var Weight1 = ((ushort)plc.Read("DB3.DBW24.0")).ConvertToShort();
            //    Console.WriteLine("DB3.DBW24.0: " + Weight1);
            //    var Weight2 = ((ushort)plc.Read("DB3.DBW26.0")).ConvertToShort();
            //    Console.WriteLine("DB3.DBW26.0: " + Weight2);
            //    var Weight3 = ((ushort)plc.Read("DB3.DBW28.0")).ConvertToShort();
            //    Console.WriteLine("DB3.DBW28.0: " + Weight3);
            //    var Weight4 = ((ushort)plc.Read("DB3.DBW30.0")).ConvertToShort();
            //    Console.WriteLine("DB3.DBW30.0: " + Weight4);
            //    var Weight5 = ((ushort)plc.Read("DB3.DBW32.0")).ConvertToShort();
            //    Console.WriteLine("DB3.DBW32.0: " + Weight5);
            //    var Weight6 = ((ushort)plc.Read("DB3.DBW34.0")).ConvertToShort();
            //    Console.WriteLine("DB3.DBW34.0: " + Weight6);
            //    var Weight7 = ((ushort)plc.Read("DB3.DBW36.0")).ConvertToShort();
            //    Console.WriteLine("DB3.DBW36.0: " + Weight7);

            //}



            // void WriteSingleVariable(Plc plc)
            //{
            //    plc.Write("DB14.DBX0.0", true);
            //    plc.Write("DB3.DBX0.1", true);
            //    plc.Write("DB3.DBX0.2", true);
            //    plc.Write("DB3.DBX0.3", true);
            //    plc.Write("DB3.DBX0.4", true);
            //    plc.Write("DB3.DBX0.5", true);
            //    plc.Write("DB3.DBX0.6", true);
            //    plc.Write("DB3.DBX0.7", true);
            //}
            //void WriteBytes(Plc plc)
            //{


            //    byte[] db14Bytes = new byte[2];
            //    var db14Bytess = plc.WriteBytes(DataType.DataBlock, 14, 0, db14Bytes);

            //        S7.Net.Types.Boolean.SetBit(db14Bytes[1], 0); // DB14.DBX0.0

            //    //for(int i = 0; i < 8; i++)
            //    //{
            //    //    var x = S7.Net.Types.Boolean.GetValue(db14Bytes[2], i); // DB14.DBX0.0
            //    //    Console.WriteLine(x);
            //    //}



            //    plc.WriteBytes(DataType.DataBlock, 14, 0, db14Bytes);
            //}

            void WriteBytess(Plc plc)
            {
                //byte[] db14Bytes = new byte[1];


                //plc.Write("DB14.DBX0.1", 1);
                // DB14.DBX0.0

                //S7.Net.Types.Boolean.SetBit(db14Bytes[0], 1); // DB14.DBX0.0

                // plc.WriteBytes(DataType.DataBlock, 14, 0, db14Bytes);

                //plc.WriteBytes(DataType.DataBlock, 14, 0, db14Bytes);
               
                  //plc.Write("DB14.DBX0.0", 1);
                    
                    //plc.Write("DB14.DBX0.0", 0);

               
                
               
                
                

               
            }

            //using (var plc = new Plc(CpuType.S71200, "192.168.0.2", 0, 1))
            //{
            //    var result = plc.Open();
            //    if (result != ErrorCode.NoError)
            //    {
            //        Console.WriteLine("error: " + plc.LastErrorCode + "\n" + plc.LastErrorString);
            //    }
            //    else
            //    {

            //        //plc.Write("DB3.DBX4.1", 1);
            //        Thread.Sleep(8001);




            //                  }
            //                }



                    Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dashboard());

            System.Threading.Thread.Sleep(100000);

        }
    }
}
