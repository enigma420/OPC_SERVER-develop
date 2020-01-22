
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
        private static string server;
        private static string database;
        private static string uid;
        private static string password;
        private static bool isDbConnected;


        //Default Constructor
        public MysqlConnection()
        {
            server = "";
            database = "";
            uid = "";
            password = "";
            connection = new MySqlConnection();
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

        //Initialize values
        private void initialize(string Server,string Database,string Uid,string Password)
        {
            server = Server;
            database = Database;
            uid = Uid;
            password = Password;
            try
            {
                connection = new MySqlConnection(getConnectionString(server, database, uid, password));
            } catch (System.ArgumentException ex)
            {
                Console.WriteLine("Error while initializating db: {0}", ex);
            }
            
        }

        private string getConnectionString(string server, string database, string uid, string password)
        {
            return "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        }

        //open connection to database
        public bool openConnection()
        {
            try
            {
                connection.Open();
                //MessageBox.Show("UDAŁO SIĘ POŁĄCZYĆ Z BAZĄ DANYCH");
                isDbConnected = true;
                return true;
            }
            catch (MySqlException ex)
         {
                //MessageBox.Show("NIE UDAŁO SIĘ POŁĄCZYĆ Z BAZĄ DANYCH");
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
            //Console.WriteLine(query);
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
                //Console.WriteLine("Result: {0}", result);
            }  catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0} \nMessage: {1}", ex.ToString(), ex.Message.ToString());
            } catch (System.NullReferenceException ex)
            {
                Console.WriteLine("Error: {0} \nMessage: {1}", ex.ToString(), ex.Message.ToString());
            }

        }

        public MySqlDataReader ExecuteReader(string query)
        {
            MySqlDataReader mySqlDataReader = null;
            MySqlCommand cmd = new MySqlCommand(query);
            DataTable results = new DataTable();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            try
            {
                mySqlDataReader = cmd.ExecuteReader();
                //results.Load(mySqlDataReader);
            } catch (MySqlException e)
            {
                Console.WriteLine("MySql error: {0}", e);
            }
            catch (System.InvalidOperationException ex)
            {
                Console.WriteLine("Error: {0}\n", ex);
            } catch (System.NullReferenceException ex)
            {
                Console.WriteLine("Error: {0}\n", ex);
            }

            
            return mySqlDataReader;

        }

        struct results
        {
            Dictionary<string, string> resultMap;
        }

    }

}
