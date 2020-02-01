using SetRooms.Class;
using System;
using System.Data.SqlClient;

using FastMember;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;

namespace SetRooms
{
    class Program
    {
        static void Main(string[] args)
        {
            int test;
            var newObject = new T();
            Task<T> Testing = null;
            List<T> Testing1 = new List<T>();
            DataTable dt = new DataTable();

            Task Objeto1 = null;      

            ConfigFile myConfigFile = new ConfigFile();
            SqlDataReader readerCollection;
            SQLDBConnection myDB = new SQLDBConnection(myConfigFile.GetKeyValue("Data Source"), myConfigFile.GetKeyValue("Catalog"),
                                     Convert.ToBoolean(myConfigFile.GetKeyValue("Integrated Security")));

            
            //test = RUDI.Insert(myDB, "Rooms", "Available", "1");

            //test = RUDI.Update(myDB, "Rooms", "Available = 0", "RoomID = 3");
            Testing = RUDI.Read<T>(myDB, "Orders");

            Testing1 = RUDI.Read1<T>(myDB, "Orders");
            dt = RUDI.Read2(myDB, "Orders");

            for (int i = 0; i < dt.Rows.Count; i++)
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    object oTest = dt.Rows[i].ItemArray[j];
                    //if you want to get the string
                    //string s = o = dt.Rows[i].ItemArray[j].ToString();
                }

            //readerCollection.Read();
            //Console.WriteLine($"RoomID: {readerCollection[0]}\nAvailable: {readerCollection[1]}");

            //test = RUDI.Delete(myDB, "Rooms", "RoomID = 0");
            //test = RUDI.Delete(myDB, "Rooms", "RoomID = 2");

            if (myDB.GetConnection())
            {
                Console.WriteLine("Connection established successfully...\n");
                myDB.CreateCMD();
                //myDB.SetSQLQuery("SELECT * FROM Person.Person");
                //myDB.SetSQLQuery("SELECT TOP 50 * FROM Person.Person ORDER BY FirstName ASC");
                myDB.SetSQLQuery("SELECT * FROM Rooms");


                try
                {
                    //connection.Open();
                    //cmd.ExecuteNonQuery();
                    readerCollection = myDB.CMD.ExecuteReader();
                    //myDB.CMD.CommandType = System.Data.CommandType.Text;
                    while (readerCollection.Read() != false)
                    {
                        Console.WriteLine($"{readerCollection["RoomID"]} {readerCollection["Available"]}");
                        //Console.WriteLine(reader["FirstName"]);
                        //Console.Write(reader["LastName"]);
                    }

                    //Console.ReadLine();

                }
                catch (SqlException MySqlError)
                {
                    Console.WriteLine(MySqlError.Message);
                }
            }
            else
            {
                Console.WriteLine("ERROR Trying to connect");
            }

            if (myDB.Close())
            {
                Console.WriteLine("\nConnenction to the DataBase has been closed...");
            }
        
        }
    }

    internal class T
    {
        public T()
        {
        }
    }

}
