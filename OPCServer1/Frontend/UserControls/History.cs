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
        public History()
        {
            InitializeComponent();
        }

        private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bindingSource1 = new BindingSource();
        private MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
        private static String Server;
        private static String Database;
        private static String Uid;
        private static String Password;

        public static void UpdateDatabaseConnectionData(string server, string database, string uid, string password)
        {
            Server = server;
            Database = database;
            Uid = uid;
            Password = password;
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            // Reload the data from the database.
            GetData(dataAdapter.SelectCommand.CommandText);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Update the database with changes.
            dataAdapter.Update((DataTable)bindingSource1.DataSource);
        }

        private void History_Load(object sender, EventArgs e)
        {
            
        }



        private void GetData(string selectCommand)
        {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                
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
            // Bind the DataGridView to the BindingSource
            // and load the data from the database.
            dataGridView2.DataSource = bindingSource1;
            GetData("SELECT * FROM PLC_DATA_PACKAGE_TABLE");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // Bind the DataGridView to the BindingSource
            // and load the data from the database.
            dataGridView2.DataSource = bindingSource1;
            GetData("SELECT * FROM PLC_DATA_PACKAGE_TABLE WHERE DATE_FORMAT(time, '%Y-%m-%d') = current_date;");
            
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            // Bind the DataGridView to the BindingSource
            // and load the data from the database.
            dataGridView2.DataSource = bindingSource1;
            GetData("SELECT measure_id,Voltage_L1,DATE_FORMAT(time, '%Y-%m-%d'),DATE_FORMAT(time, '%h:%i:%s') FROM PLC_DATA_PACKAGE_TABLE;");
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            // Bind the DataGridView to the BindingSource
            // and load the data from the database.
            dataGridView2.DataSource = bindingSource1;
            GetData("SELECT ROUND(SUM(True_Power_L1+True_Power_L2+True_Power_L3), 2) FROM measurement_table WHERE MOD(measure_id,10)=0;");
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
