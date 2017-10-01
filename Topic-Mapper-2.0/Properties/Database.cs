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

        //Takes in MySql Database Information
        public Database(string datasource, string port, string database, string username, string password)
        {
            this.datasource = datasource;
            this.port = port;
            this.database = database;
            this.username = username;
            this.password = password;
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
            string MyConnection2 = String.Format("datasource={0};port={1};database={2};username={3};password={4}", datasource, port, database, username, password);

                if (fileName == null)
                {
                    fileName = "null";
                }
                else
                {
                    fileName = String.Format("'{0}'", fileName);
                }
                if (filePath == null)
                {
                    filePath = "null";
                }
                else
                {
                    filePath = String.Format("'{0}'", filePath);
                }
                if (date_origin == null)
                {
                    date_origin = "null";
                }
                else
                {
                    date_origin = String.Format("'{0}'", date_origin);
                }
                if (type == null)
                {
                    type = "null";
                }
                else
                {
                    type = String.Format("'{0}'", type);
                }
                if (summary == null)
                {
                    summary = "null";
                }
                else
                {
                    summary = String.Format("'{0}'", summary);
                }

         
            //Console.WriteLine(MyConnection2);
            string Query = String.Format("insert into files (fileName, filePath, date_origin, type, summary) VALUES ( {0}, {1}, {2}, {3}, {4});", fileName, filePath, date_origin, type, summary);
            Console.WriteLine(Query);
            //This is MySqlConnection here i have created the object and pass my connection string. 
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

            MySqlDataReader MyReader2;

            MyConn2.Open();

            MyReader2 = MyCommand2.ExecuteReader();

            MyConn2.Close();
        }


    }
}
