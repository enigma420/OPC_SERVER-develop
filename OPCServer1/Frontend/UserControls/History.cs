using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OPCServer1
{
    public partial class History : UserControl
    {
        private DataGridView dataGridView1;
        private BindingSource bindingSource1;
        private MySqlDataAdapter dataAdapter;
        private static String Server = "localhost";
        private static String Database = "serveropc";
        private static String Uid = "dominik";
        private static String Password = "Qwerty123";

        public History()
        {
            dataGridView1 = new DataGridView();
            bindingSource1 = new BindingSource();
            dataAdapter = new MySqlDataAdapter();
            InitializeComponent();
        }

        public static void UpdateDatabaseConnectionData(string server, string database, string uid, string password)
        {
            Server = server;
            Database = database;
            Uid = uid;
            Password = password;
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            GetData(dataAdapter.SelectCommand.CommandText);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            dataAdapter.Update((DataTable)bindingSource1.DataSource);
        }

        private void History_Load(object sender, EventArgs e)
        {
            
        }
        private void GetData(string selectCommand)
        {
            try
            {
          
                string connectionString;
                connectionString = "SERVER=" + Server + ";" + "DATABASE=" +
                Database + ";" + "UID=" + Uid + ";" + "PASSWORD=" + Password + ";";

                // Create a new data adapter based on the specified query.
                dataAdapter = new MySqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;
                

                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = bindingSource1;
            GetData("SELECT * FROM PLC_DATA_PACKAGE_TABLE");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = bindingSource1;
            GetData("SELECT * FROM PLC_DATA_PACKAGE_TABLE WHERE DATE_FORMAT(time, '%Y-%m-%d') = current_date;");
        }

      

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = bindingSource1;
            GetData("SELECT plc_data_package_id,occupancy0,platformsize0,signalingTrips0,entrance,parking_occupied,big_platform_occupied,weight0,vehicle_weight,rotation_angle,rotation_time,ramp_actual_speed_freq,minimum_weight,boundary_weight,maximum_weight,time FROM PLC_DATA_PACKAGE_TABLE");
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = bindingSource1;
            GetData("SELECT plc_data_package_id,minimum_weight,boundary_weight,maximum_weight,time FROM PLC_DATA_PACKAGE_TABLE");

        }
    }
}
