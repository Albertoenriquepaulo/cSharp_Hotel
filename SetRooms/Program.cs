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
            DataTable dTable;
            ConfigFile myConfigFile = new ConfigFile();
            SqlDataReader readerCollection;
            SQLDBConnection myDB = new SQLDBConnection(myConfigFile.GetKeyValue("Data Source"), myConfigFile.GetKeyValue("Catalog"),
                                     Convert.ToBoolean(myConfigFile.GetKeyValue("Integrated Security")));

            dTable = RUDI.Read(myDB, "Orders");

            //for (int i = 0; i < dTable.Rows.Count; i++)
            //    for (int j = 0; j < dTable.Columns.Count; j++)
            //    {
            //        object oTest = dTable.Rows[i].ItemArray[j];
            //        //if you want to get the string
            //        //string s = o = dt.Rows[i].ItemArray[j].ToString();
            //    }

            //readerCollection.Read();
            //Console.WriteLine($"RoomID: {readerCollection[0]}\nAvailable: {readerCollection[1]}");

            //test = RUDI.Delete(myDB, "Rooms", "RoomID = 0");
            //test = RUDI.Delete(myDB, "Rooms", "RoomID = 2");
           
        }
    }

    internal class T
    {
        public T()
        {
        }
    }

}
