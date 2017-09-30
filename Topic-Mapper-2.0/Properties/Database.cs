using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Topic_Mapper_2._0.Properties
{
    class Database
    {
        private string datasource;
        private string port;
        private string database;
        private string username;
        private string password;


        public Database(string datasource, string port, string database, string username, string password)
        {
            this.datasource = datasource;
            this.port = port;
            this.database = database;
            this.username = username;
            this.password = password;
        }
        public void Insert(string fileName, string filePath, string date_origin, string date_accessed, string type, string summary)
        {
            string MyConnection2 = String.Format("datasource={0};port={1};database={2};username={3};password={4}", datasource, port, database, username, password);
            //Console.WriteLine(MyConnection2);
            string Query = "insert into files (fileName, filePath, date_origin) VALUES ('2','Testing');";
            //This is  MySqlConnection here i have created the object and pass my connection string. 
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);

            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

            MySqlDataReader MyReader2;

            MyConn2.Open();

            MyReader2 = MyCommand2.ExecuteReader();
        }
    }
}
