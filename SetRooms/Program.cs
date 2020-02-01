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
            int result; //Para los resultados de las consultas RUDI
            ConfigFile myConfigFile = new ConfigFile();
            SQLDBConnection myDB = new SQLDBConnection(myConfigFile.GetKeyValue("Data Source"), myConfigFile.GetKeyValue("Catalog"),
                                     Convert.ToBoolean(myConfigFile.GetKeyValue("Integrated Security")));
            DataTable dTable;
            bool exit = true;

            //dTable = RUDI.Read(myDB, "Orders");
            Helper.LoadRooms(myDB);

            
        }
    }

    internal class T
    {
        public T()
        {
        }
    }

}
