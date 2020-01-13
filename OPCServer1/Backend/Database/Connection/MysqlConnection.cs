
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;



namespace OPCServer1
{
    public class MysqlConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private static bool isDbConnected;


        //Default Constructor
        public MysqlConnection()
        {
            //defaultInitialize();
            //openConnection();
        }

        //Constructor
        public MysqlConnection(string server, string database, string uid, string password)
        {
            initialize(server, database, uid, password);
            openConnection();
        }


        public bool IsDbConnected()
        {
            return isDbConnected;
        }

        //Default Initialize values
        private void defaultInitialize()
        {
            server = "localhost";
            database = "serveropc";
            uid = "dominik";
            password = "Qwerty123";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";MultipleActiveResultSets=true;";

            connection = new MySqlConnection(connectionString);
        }

        //Initialize values
        private void initialize(string server,string database,string uid,string password)
        {
            
            connection = new MySqlConnection(getConnectionString(server, database, uid, password));
        }

        private string getConnectionString(string server, string database, string uid, string password)
        {
            return "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        }

        //Display Sql Errors
         private static String DisplayMySqlErrors(MySqlException exception)
         {
                 Console.WriteLine(
                     "Error: " + exception.Message.ToString() + "\n");
             return Console.ReadLine();
         }
         

        //open connection to database
        public bool openConnection()
        {
            try
            {
                connection.Open();
                MessageBox.Show("UDAŁO SIĘ POŁĄCZYĆ Z BAZĄ DANYCH");
                isDbConnected = true;
                return true;
            }
            catch (MySqlException ex)
         {
                MessageBox.Show("NIE UDAŁO SIĘ POŁĄCZYĆ Z BAZĄ DANYCH");
                isDbConnected = false;
                return false;
            }
        }


        //Close connection
        public bool closeConnection()
        {
            try
            {
                connection.Close();
                return false;
            }
            catch (MySqlException ex)
            {
                return true;
            }
        }
        
        public String createTableQuery(String tableName, string[] columns)
        {
            String query = "CREATE TABLE IF NOT EXISTS " + tableName + "(";
            foreach (string column in columns)
            {
                query += column + ", ";
            }
            query = query.Substring(0, query.Length - 2);
            query += ")";
            Console.WriteLine(query);
            return query;
        }

        public void createTable(String tableName, string[] columns)
        {
            String query = createTableQuery(tableName, columns);
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error while creating table err: %s\n", ex);
            }
            catch (System.InvalidOperationException ex)
            {
                Console.WriteLine("Error while creating table err: %s\n", ex);
            }
        }

        public void dropTable(String tableName)
        {
            String query = "DROP TABLE IF EXISTS " + tableName + " ;";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error while dropping table %s err: %s", tableName, ex);
            }
        }

        //Insert Query statement
        public String insertIntoQuery(String tableName, string[] columns, string[] types, string[] values)
        {

            string query = "INSERT INTO " + tableName + " (";

            foreach (string column in columns)
            {
                query += column + ", ";
            }
            query = query.Substring(0, query.Length - 2); //delete last comma
            query += ") ";
            query += "VALUES (";

            for (int i = 0; i < values.Length; i++)
            {
                if (IsQuatUnnecessery(types[i]))
                {
                    query += values[i] +  ",";

                } else
                {
                    query += "'" + values[i] + "', ";
                }
            }
            query = query.Substring(0, query.Length - 2);
            query += ");";
            Console.WriteLine(query);
            return query;
        }

        private bool IsQuatUnnecessery(string type)
        {
            if (type.Equals("time") || type.Equals("string")) return false; //dodaje
            return true; // nie dodaje cudzyslowia
        }

        public void insertInto(String tableName, string[] columns, string[] types, string[] values)
        {
            String query = insertIntoQuery(tableName, columns, types, values);
            MySqlCommand cmd = new MySqlCommand(query, connection);
            try
            {
                var result = cmd.ExecuteScalar();
                Console.WriteLine("Result: {0}", result);
            }  catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0} \nMessage: {1}", ex.ToString(), ex.Message.ToString());
            } catch (System.NullReferenceException ex)
            {
                Console.WriteLine("Error: {0} \nMessage: {1}", ex.ToString(), ex.Message.ToString());
            }

        }

        private String selectFieldsFromTableQuery(String tableName, String []fields)
        {
            String query = "SELECT ";
            foreach(String field in fields)
            {
                query += field + ", ";
            }
            query = query.Substring(0, query.Length - 2);
            query += "FROM " + tableName;
            Console.WriteLine(query);
            return query;
        }

        //public void selectFieldsFromTable(String tableName, String []fields)
        //{
        //    String query = selectFieldsFromTableQuery(tableName, fields);
        //    MySqlCommand cmd = new MySqlCommand(query, connection);
        //    try
        //    {
        //        var result = cmd.ExecuteScalar();
        //        Console.WriteLine("Result: {0}", result);
        //    }
        //    catch (MySqlException e)
        //    {
        //        Console.WriteLine("Error while selecting %s from table %s err: %s", fields, tableName, e);
        //    }
        //}

        //private bool isDigit(String str)
        //{
        //    try
        //    {
        //        Convert.ToDouble(str);
        //    }
        //    catch (FormatException e)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        
        //Count statement
        public int count(String tableName)
        {
            string query = "SELECT Count(*) FROM " + tableName;
            int Count = -1;

            //Open Connection
            if (this.openConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.closeConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        public MySqlDataReader ExecuteReader(string query)
        {
            MySqlDataReader mySqlDataReader = null;
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            try
            {
                mySqlDataReader = cmd.ExecuteReader();
            } catch (MySqlException e)
            {
                Console.WriteLine("MySql error: {0}", e);
            }
            catch (System.InvalidOperationException ex)
            {
                Console.WriteLine("Error: {0}\n", ex);
            }

            return mySqlDataReader;

        }

        public DataTable GetData(string selectCommand)
        {
            MySqlDataAdapter dataAdapter = null;
            DataTable table = new DataTable();

            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.

                //string connectionString;
                //connectionString = "SERVER=" + Server + ";" + "DATABASE=" +
                //Database + ";" + "UID=" + Uid + ";" + "PASSWORD=" + Password + ";";

                // Create a new data adapter based on the specified query.
                //dataAdapter = new MySqlDataAdapter(selectCommand, getConnectionString());

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return table;        }

    }

}
