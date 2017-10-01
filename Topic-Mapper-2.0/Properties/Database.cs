using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Topic_Mapper_2._0.DB
{
    class Database
    {
        private string datasource;
        private string port;
        private string database;
        private string username;
        private string password;
        private string connection;


        //Takes in MySql Database Information
        public Database(string datasource, string port, string database, string username, string password)
        {
            this.datasource = datasource;
            this.port = port;
            this.database = database;
            this.username = username;
            this.password = password;
            connectionString();
        }
        public void connectionString()
        {
            this.connection = String.Format("datasource={0};port={1};database={2};username={3};password={4}", datasource, port, database, username, password);
        }

        public string checkNull(string str)
        {
            if (str == null)
            {
                Console.WriteLine("NULL VALUE");
                return "null";
            }
            else
            {
                str = String.Format("'{0}'", str);
                return str;
            }
        }

        //Test the connection of the database
        public bool testConnection()
        {
            if (datasource == null || port == null || database == null || username == null || password == null)
            {
                if (datasource == null)
                {
                    Console.WriteLine("Database Datasource information is not provided.");
                    return false;
                }
                if (port == null)
                {
                    Console.WriteLine("Database Port information is not provided.");
                    return false;
                }
                if (database == null)
                {
                    Console.WriteLine("Database name information is not provided.");
                    return false;
                }
                if (username == null)
                {
                    Console.WriteLine("Database username is not provided.");
                    return false;
                }
                if (password == null)
                {
                    Console.WriteLine("Database password is not provided.");
                    return false;
                }
            }
            string MyConnection2 = String.Format("datasource={0};port={1};database={2};username={3};password={4}", datasource, port, database, username, password);
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

            try
            {
                MyConn2.Open();
            }
            catch(Exception ex)
            {
                Console.WriteLine("ERROR:" + ex.ToString());
                return false;
            }
            MyConn2.Close();
            return true;
        }

        //Insert file information into the database
        public void InsertNewFile(string fileName, string filePath, string date_origin, string type, string summary)
        {
            
            //Check for null values
            fileName = checkNull(fileName);
            filePath = checkNull(filePath);
            date_origin = checkNull(date_origin);
            type = checkNull(type);
            summary = checkNull(summary);

            string MyConnection2 = connection;

            //Console.WriteLine(MyConnection2);
            string Query = String.Format("insert into files (fileName, filePath, date_origin, type, summary) VALUES ( {0}, {1}, {2}, {3}, {4});", fileName, filePath, date_origin, type, summary);
           
            //This is MySqlConnection here i have created the object and pass my connection string. 
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

            MySqlDataReader MyReader2;

            MyConn2.Open();

            MyReader2 = MyCommand2.ExecuteReader();

            MyConn2.Close();
        }

        public void changeFileName(int fileID, string fileName)
        {

            //Determine fileName is null
            fileName = checkNull(fileName);

            //Create UPDATE string
            string update = string.Format("UPDATE files SET fileName = {0} where idfiles = {1}", fileName,  fileID);

            string MyConnection = connection;
           
            MySqlConnection MyConn = new MySqlConnection(MyConnection);

            MySqlCommand MyCommand = new MySqlCommand(update, MyConn);

            MySqlDataReader MyReader;

            try
            {
                MyConn.Open();

                //Execute UPDATE
                MyReader = MyCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:" + ex.ToString());
            }
            MyConn.Close();

        }

        public void changeDate_origin(int fileID, string date_origin)
        {
            //Determine date_origin is null
            date_origin = checkNull(date_origin);

            //Create UPDATE string
            string update = string.Format("UPDATE files SET date_origin = {0} where idfiles = {1}", date_origin, fileID);

            string MyConnection = connection;

            MySqlConnection MyConn = new MySqlConnection(MyConnection);

            MySqlCommand MyCommand = new MySqlCommand(update, MyConn);

            MySqlDataReader MyReader;

            try
            {
                MyConn.Open();

                //Execute UPDATE
                MyReader = MyCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:" + ex.ToString());
            }
            MyConn.Close();
        }
        
        public void changeSummary(int fileID, string summary)
        {
            //Determine summary is null
            summary = checkNull(summary);

            //Create UPDATE string
            string update = string.Format("UPDATE files SET summary = {0} where idfiles = {1}", summary, fileID);

            string MyConnection = connection;

            MySqlConnection MyConn = new MySqlConnection(MyConnection);

            MySqlCommand MyCommand = new MySqlCommand(update, MyConn);

            MySqlDataReader MyReader;

            try
            {
                MyConn.Open();

                //Execute UPDATE
                MyReader = MyCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:" + ex.ToString());
            }
            MyConn.Close();
        }

        public void changeDate_accessed(int fileID, string date_accessed)
        {
            //Determine date_accessed is null
            date_accessed = checkNull(date_accessed);

            //Create UPDATE string
            string update = string.Format("UPDATE files SET date_accessed = {0} where idfiles = {1}", date_accessed, fileID);

            string MyConnection = connection;

            MySqlConnection MyConn = new MySqlConnection(MyConnection);

            MySqlCommand MyCommand = new MySqlCommand(update, MyConn);

            MySqlDataReader MyReader;

            try
            {
                MyConn.Open();

                //Execute UPDATE
                MyReader = MyCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:" + ex.ToString());
            }
            MyConn.Close();
        }
    
    }
}
