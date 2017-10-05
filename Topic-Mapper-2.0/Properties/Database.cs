using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Topic_Mapper_2._0.keywords;
using Topic_Mapper_2._0.files;


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
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:" + ex.ToString());
                return false;
            }
            MyConn2.Close();
            return true;
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
            
           // Console.WriteLine("MyReader: " +  MyCommand2.LastInsertedId);
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

        public void addKeyword(int fileID, string keyword, int category)
        {

            keyword = checkNull(keyword);
            int keywordID = 0;
            //Statement to check if it exist
            string Query = String.Format("SELECT COUNT(keyword) from keywords where keyword = {0}", keyword);
            string MyConnection = connection;

            //This is MySqlConnection here i have created the object and pass my connection string. 
            MySqlConnection MyConn = new MySqlConnection(MyConnection);
            MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
            MySqlDataReader MyReader;

            //Execute keyword count statement to look if it exist
            MyConn.Open();
            MyReader = MyCommand.ExecuteReader();
            MyConn.Close();

            //If keyword does exist
            MyConn.Open();
            if (int.Parse(MyCommand.ExecuteScalar().ToString()) == 1)
            {
                //Find keywordID 
                MyConn.Close();
                Query = String.Format("SELECT idkeywords from keywords where keyword = {0}", keyword);
                MyCommand = new MySqlCommand(Query, MyConn);
               

                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                MyConn.Close();

                MyConn.Open();
                keywordID = int.Parse(MyCommand.ExecuteScalar().ToString());
                MyConn.Close();

            }
            else
            {
                MyConn.Close();

                Query = String.Format("insert into keywords (keyword, category) VALUES ({0}, {1})", keyword, category);
                MyCommand = new MySqlCommand(Query, MyConn);


                MyConn.Open();
                MyReader = MyCommand.ExecuteReader();
                MyConn.Close();

                // Add connection with Keyword and File
                MyConn.Open();
                keywordID = (int)MyCommand.LastInsertedId;
                Console.WriteLine("KeywordID: " + keywordID);
                MyConn.Close();
            }


            MyConn.Open();

            Query = String.Format("insert into files_has_keywords (fileID, keywordID) VALUES ('{0}', '{1}')", fileID, keywordID);

            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn);
            MyReader = MyCommand2.ExecuteReader();

            MyConn.Close();
        }

        public void deleteKeyword(int fileID, int keywordID)
        {
            //DELETE FROM files_has_keywords where (fileID = 1 AND keywordID = 4);
            string delete = String.Format("DELETE FROM files_has_keywords where (fileID = '{0}' AND keywordID = '{1}')", fileID, keywordID);

            string MyConnection = connection;

            //This is MySqlConnection here i have created the object and pass my connection string. 
            MySqlConnection MyConn = new MySqlConnection(MyConnection);

            MySqlCommand MyCommand = new MySqlCommand(delete, MyConn);

            MySqlDataReader MyReader;

            MyConn.Open();

            MyReader = MyCommand.ExecuteReader();

            MyConn.Close();
        }

        //Retrieve all keywords related to the file
        public Stack retrieveKeywords(int fileID)
        {
            Stack keywords = new Stack();
            Keywords k = new Keywords();
            String Query = String.Format("SELECT idkeywords, keyword, category from files, files_has_keywords, keywords where (fileID = {0} AND idfiles = {1} AND keywordID = idkeywords)", fileID, fileID);
            string MyConnection = connection;
            MySqlConnection MyConn = new MySqlConnection(MyConnection);
            MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
            MySqlDataReader MyReader;

            MyConn.Open();
            MyReader = MyCommand.ExecuteReader();

            while (MyReader.Read())
            {
                k.setID((int)MyReader["idkeywords"]);
                k.setKeyword((string)MyReader["keyword"]);
                k.setCategory((int)MyReader["category"]);
                keywords.Push(k);
            }
          
            MyConn.Close();
            return keywords;
            
        }

        //Retrieve all files & keywords related to keyword
        public Stack retrieveFiles(int keywordID)
        {
            //SELECT fileID, fileName, filePath, type, date_origin, summary from files, files_has_keywords, keywords where (fileID = idfiles AND keywordID = 9 AND idkeywords = 9)
            Stack Files = new Stack();
            Files F = new Files();
            String Query = String.Format("SELECT fileID, fileName, filePath, type, date_origin, summary from files, files_has_keywords, keywords where (fileID = idfiles AND keywordID = {0} AND idkeywords = {1})", keywordID, keywordID);
            string MyConnection = connection;
            MySqlConnection MyConn = new MySqlConnection(MyConnection);
            MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
            MySqlDataReader MyReader;

            MyConn.Open();
            MyReader = MyCommand.ExecuteReader();

            while (MyReader.Read())
            {
                F.setFileID((int)MyReader["fileID"]);
                F.setFileName((string)MyReader["fileName"]);
                F.setFilePath((string)MyReader["filePath"]);
                F.setFileType((string)MyReader["type"]);
                F.setCreationDate((string)MyReader["date_origin"]);
                F.setSummary((string)MyReader["summary"]);
                Files.Push(F);
            }

            MyConn.Close();
            return Files;
        }

    }
}
