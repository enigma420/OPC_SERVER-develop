using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPCServer1.Forms
{
    public partial class ConnToDB : Form
    {
        DatabaseService databaseService = null;
        
        public ConnToDB()
        {
            InitializeComponent();
            databaseService = new DatabaseService();
        }

        private void ConnToDB_Load(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void Button6_Click(object sender, EventArgs e) 
        {
            databaseService.UpdateDatabaseServiceDbConnectionData(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);

            UpdateDbStatus();

            //try
            //    {


            //    dash.Show();
            //        Console.WriteLine("try => label6: {0}", label6);
            //    }
            //    catch (MySqlException ex)
            //    {

            //    Console.WriteLine("catch => label6: {0}", label6);
            //    }

            CurrentlyMeasurement.UpdateDatabaseService(databaseService);

            History.UpdateDatabaseConnectionData(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);

            Diagrams.UpdateDatabaseConnectionData(databaseService);

            //CurrentlyMeasurement.UpdateDatabaseConnectionData(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            //    History.UpdateDatabaseConnectionData(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);

            //to trzeba ogarnac jakos innym sposobem
            //OPCServer1.Backend.Database.DatabaseService.UpdateDatabaseService(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
        }


        private void UpdateDbStatus()
        {
            bool dbStatus = databaseService.IsDbConnected();

            string dbStatusLabelText = "";
            if (dbStatus)
            {
                dbStatusLabelText = "connected";
            }
            else
            {
                dbStatusLabelText = "disconnected";
            }
            Dashboard.UpdateDbStatusLabel(dbStatusLabelText);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(databaseService.IsDbConnected())
            {
                databaseService.CloseConnection();

                UpdateDbStatus();

                CurrentlyMeasurement.UpdateDatabaseService(databaseService);
                History.UpdateDatabaseConnectionData("","","","");

            }
            else
            {
                MessageBox.Show("Nie mozesz rozłączyć się, ponieważ nie jesteś połączony z żadną bazą danych");
            }
            

            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
