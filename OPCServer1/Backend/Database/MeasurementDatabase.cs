using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections;
using static OPCServer1.Backend.Serwer.Model.PlcDataPackage;
using OPCServer1.Backend.Serwer.Model;
using System.Data;

namespace OPCServer1
{
    class MeasurementDatabase
    {
       
        static String PLC_DATA_PACKAGE = "PLC_DATA_PACKAGE_TABLE2";

        MysqlConnection Connection = null;

        public MeasurementDatabase()
        {
            Connection = new MysqlConnection();
        }

        public void UpdateMeasurementDatabaseData(string server, string database, string uid, string password)
        {
            Connection = new MysqlConnection(server, database, uid, password);
            createPlcDataPackageTableIfNotExists();
        }

        public bool IsDbConnected()
        {
            return Connection.IsDbConnected();
        }


        public void createPlcDataPackageTableIfNotExists()
        {
            Connection.createTable(PLC_DATA_PACKAGE, getCreatePlcDataPackageTableColumns());
        }

        private String[] getCreatePlcDataPackageTableColumns()
        {
            ArrayList columns = new ArrayList();
            //PRIMARY KEY
            columns.Add("plc_data_package_id INT AUTO_INCREMENT PRIMARY KEY");
            //BOOLEAN
            //DB3
            columns.Add("occupancy0 BOOLEAN");
            columns.Add("occupancy1 BOOLEAN");
            columns.Add("occupancy2 BOOLEAN");
            columns.Add("occupancy3 BOOLEAN");
            columns.Add("occupancy4 BOOLEAN");
            columns.Add("occupancy5 BOOLEAN");
            columns.Add("occupancy6 BOOLEAN");
            columns.Add("occupancy7 BOOLEAN");
            columns.Add("platformsize0 BOOLEAN");
            columns.Add("platformsize1 BOOLEAN");
            columns.Add("platformsize2 BOOLEAN");
            columns.Add("platformsize3 BOOLEAN");
            columns.Add("platformsize4 BOOLEAN");
            columns.Add("platformsize5 BOOLEAN");
            columns.Add("platformsize6 BOOLEAN");
            columns.Add("platformsize7 BOOLEAN");
            columns.Add("signalingTrips0 BOOLEAN");
            columns.Add("signalingTrips1 BOOLEAN");
            columns.Add("signalingTrips2 BOOLEAN");
            columns.Add("signalingTrips3 BOOLEAN");
            columns.Add("signalingTrips4 BOOLEAN");
            columns.Add("signalingTrips5 BOOLEAN");
            columns.Add("signalingTrips6 BOOLEAN");
            columns.Add("signalingTrips7 BOOLEAN");
            //DB14
            columns.Add("entrance BOOLEAN");
            columns.Add("entrance_enabled BOOLEAN");
            columns.Add("entrance_big_vehicle BOOLEAN");
            columns.Add("entrance_small_vehicle BOOLEAN");
            columns.Add("left_right BOOLEAN");
            columns.Add("parking_in_move BOOLEAN");
            columns.Add("parking_out BOOLEAN");
            columns.Add("out_enabled BOOLEAN");
            columns.Add("vehicle_too_heavy_for_small_platform BOOLEAN");
            columns.Add("parking_occupied BOOLEAN");
            columns.Add("big_platform_occupied BOOLEAN");
            //INT
            //DB3
            columns.Add("weight0 INT");
            columns.Add("weight1 INT");
            columns.Add("weight2 INT");
            columns.Add("weight3 INT");
            columns.Add("weight4 INT");
            columns.Add("weight5 INT");
            columns.Add("weight6 INT");
            columns.Add("weight7 INT");
            //DB14
            columns.Add("vehicle_weight INT");
            columns.Add("platform_to_rotate_down INT");
            columns.Add("rotation_angle INT");
            //DINT => INT
            //DB14
            columns.Add("rotation_time INT");
            //REAL => DOUBLE
            columns.Add("ramp_command_speed_freq DOUBLE(8,3)");
            columns.Add("ramp_engine_speed_freq DOUBLE(8,3)");
            columns.Add("ramp_actual_speed_freq DOUBLE(8,3)");
            columns.Add("minimum_weight DOUBLE(8,3)");
            columns.Add("boundary_weight DOUBLE(8,3)");
            columns.Add("maximum_weight DOUBLE(8,3)");
            //WORD => INT
            columns.Add("inventer_status INT");
            columns.Add("inventer_command_speed INT");
            columns.Add("inventer_actual_speed INT");
            //TIME
            columns.Add("time DATETIME NOT NULL");
            return columns.ToArray(typeof(string)) as string[];
        }


        public void CreatePlcDataPackage(PlcDataPackage plcDataPackage)
        {
            Connection.insertInto(PLC_DATA_PACKAGE, getPlcDataPackageTableColumns(), convertPlcDataPackageToTypesTable(plcDataPackage), convertPlcDataPackageStringTable(plcDataPackage));
        }

        private string[] getPlcDataPackageTableColumns()
        {
            ArrayList columns = new ArrayList();
            columns.Add("plc_data_package_id");
            columns.Add("occupancy0");
            columns.Add("occupancy1");
            columns.Add("occupancy2");
            columns.Add("occupancy3");
            columns.Add("occupancy4");
            columns.Add("occupancy5");
            columns.Add("occupancy6");
            columns.Add("occupancy7");
            columns.Add("platformsize0");
            columns.Add("platformsize1");
            columns.Add("platformsize2");
            columns.Add("platformsize3");
            columns.Add("platformsize4");
            columns.Add("platformsize5");
            columns.Add("platformsize6");
            columns.Add("platformsize7");
            columns.Add("signalingTrips0");
            columns.Add("signalingTrips1");
            columns.Add("signalingTrips2");
            columns.Add("signalingTrips3");
            columns.Add("signalingTrips4");
            columns.Add("signalingTrips5");
            columns.Add("signalingTrips6");
            columns.Add("signalingTrips7");
            //DB14
            columns.Add("entrance");
            columns.Add("entrance_enabled");
            columns.Add("entrance_big_vehicle");
            columns.Add("entrance_small_vehicle");
            columns.Add("left_right");
            columns.Add("parking_in_move");
            columns.Add("parking_out");
            columns.Add("out_enabled");
            columns.Add("vehicle_too_heavy_for_small_platform");
            columns.Add("parking_occupied");
            columns.Add("big_platform_occupied");
            //INT
            //DB3
            columns.Add("weight0");
            columns.Add("weight1");
            columns.Add("weight2");
            columns.Add("weight3");
            columns.Add("weight4");
            columns.Add("weight5");
            columns.Add("weight6");
            columns.Add("weight7");
            //DB14
            columns.Add("vehicle_weight");
            columns.Add("platform_to_rotate_down");
            columns.Add("rotation_angle");
            //DINT => INT
            //DB14
            columns.Add("rotation_time");
            //REAL => DOUBLE
            columns.Add("ramp_command_speed_freq");
            columns.Add("ramp_engine_speed_freq");
            columns.Add("ramp_actual_speed_freq");
            columns.Add("minimum_weight");
            columns.Add("boundary_weight");
            columns.Add("maximum_weight");
            //WORD => INT
            columns.Add("inventer_status");
            columns.Add("inventer_command_speed");
            columns.Add("inventer_actual_speed");
            //TIME
            columns.Add("time");
            return (string[])columns.ToArray(typeof(string));
        }

        private string[] convertPlcDataPackageToTypesTable(PlcDataPackage plcDataPackage)
        {
            ArrayList types = new ArrayList();
            types.Add("int");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("bool");
            types.Add("int");
            types.Add("int");
            types.Add("int");
            types.Add("int");
            types.Add("int");
            types.Add("int");
            types.Add("int");
            types.Add("int");
            types.Add("int");
            types.Add("int");
            types.Add("int");
            types.Add("int");
            types.Add("double");
            types.Add("double");
            types.Add("double");
            types.Add("double");
            types.Add("double");
            types.Add("double");
            types.Add("int");
            types.Add("int");
            types.Add("int");
            types.Add("time");
            return types.ToArray(typeof(string)) as string[];
        }

        private string[] convertPlcDataPackageStringTable(PlcDataPackage plcDataPackage)
        {
            ArrayList values = new ArrayList();
            values.Add("DEFAULT");
            values.Add(plcDataPackage.Occupancy0.ToString());
            values.Add(plcDataPackage.Occupancy1.ToString());
            values.Add(plcDataPackage.Occupancy2.ToString());
            values.Add(plcDataPackage.Occupancy3.ToString());
            values.Add(plcDataPackage.Occupancy4.ToString());
            values.Add(plcDataPackage.Occupancy5.ToString());
            values.Add(plcDataPackage.Occupancy6.ToString());
            values.Add(plcDataPackage.Occupancy7.ToString());
            values.Add(plcDataPackage.PlatformSize0.ToString());
            values.Add(plcDataPackage.PlatformSize1.ToString());
            values.Add(plcDataPackage.PlatformSize2.ToString());
            values.Add(plcDataPackage.PlatformSize3.ToString());
            values.Add(plcDataPackage.PlatformSize4.ToString());
            values.Add(plcDataPackage.PlatformSize5.ToString());
            values.Add(plcDataPackage.PlatformSize6.ToString());
            values.Add(plcDataPackage.PlatformSize7.ToString());
            values.Add(plcDataPackage.SignalingTrips0.ToString());
            values.Add(plcDataPackage.SignalingTrips1.ToString());
            values.Add(plcDataPackage.SignalingTrips2.ToString());
            values.Add(plcDataPackage.SignalingTrips3.ToString());
            values.Add(plcDataPackage.SignalingTrips4.ToString());
            values.Add(plcDataPackage.SignalingTrips5.ToString());
            values.Add(plcDataPackage.SignalingTrips6.ToString());
            values.Add(plcDataPackage.SignalingTrips7.ToString());
            values.Add(plcDataPackage.Entrance.ToString());
            values.Add(plcDataPackage.Entrance_enabled.ToString());
            values.Add(plcDataPackage.Entrance_big_vehicle.ToString());
            values.Add(plcDataPackage.Entrance_small_vehicle.ToString());
            values.Add(plcDataPackage.Left_right.ToString());
            values.Add(plcDataPackage.Parking_in_move.ToString());
            values.Add(plcDataPackage.Parking_out.ToString());
            values.Add(plcDataPackage.Out_enabled.ToString());
            values.Add(plcDataPackage.Vehicle_too_heavy_for_small_platform.ToString());
            values.Add(plcDataPackage.Parking_occupied.ToString());
            values.Add(plcDataPackage.Big_platform_occupied.ToString());
            values.Add(plcDataPackage.Weight0.ToString());
            values.Add(plcDataPackage.Weight1.ToString());
            values.Add(plcDataPackage.Weight2.ToString());
            values.Add(plcDataPackage.Weight3.ToString());
            values.Add(plcDataPackage.Weight4.ToString());
            values.Add(plcDataPackage.Weight5.ToString());
            values.Add(plcDataPackage.Weight6.ToString());
            values.Add(plcDataPackage.Weight7.ToString());
            values.Add(plcDataPackage.Vehicle_weight.ToString());
            values.Add(plcDataPackage.Platform_to_rotate_down.ToString());
            values.Add(plcDataPackage.Rotation_angle.ToString());
            values.Add(plcDataPackage.Rotation_time.ToString());
            values.Add(plcDataPackage.Ramp_command_speed_freq.ToString());
            values.Add(plcDataPackage.Ramp_engine_speed_freq.ToString());
            values.Add(plcDataPackage.Ramp_actual_speed_freq.ToString());
            values.Add(plcDataPackage.Minimum_weight.ToString());
            values.Add(plcDataPackage.Boundary_weight.ToString());
            values.Add(plcDataPackage.Maximum_weight.ToString());
            values.Add(plcDataPackage.Inventer_status.ToString());
            values.Add(plcDataPackage.Inventer_command_speed.ToString());
            values.Add(plcDataPackage.Inventer_actual_speed.ToString());
            values.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            return values.ToArray(typeof(string)) as string[];
        }

        public MySqlDataReader GetAllSpeedAndTimeData()
        {
            String query = "SELECT plc_data_package_id, ramp_actual_speed_freq, time FROM " + PLC_DATA_PACKAGE + ";";
            return Connection.ExecuteReader(query);
          
        }

        public bool CloseConnection()
        {
            return Connection.closeConnection();
        }
    }
}

      